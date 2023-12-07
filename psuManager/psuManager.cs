using System.Diagnostics;
using System.IO.Ports;
using System.Text.Json;
using MyMQTTClient;
using uPLibrary.Networking.M2Mqtt.Messages;
using PsuController;
using uPLibrary.Networking.M2Mqtt;
using System.Management;
using System.Timers;

namespace PsuManager;
/*
public class PsuManager
{
    private IPsu _psu;
    private MyMqtt _mqttClient;
    
    public PsuManager()
    {
        _mqttClient = new MyMqtt();
        _mqttClient.connectClient();
        _mqttClient.Subscribe("+");
    }
    
    private void PublishVoltage()
    {
        _mqttClient.publish($"{_psu.GetSerialNumber()}/Voltage", _psu.GetVoltage());
    }
} */
public class PsuManager
{
    private Dictionary<string, Psu2000> _psuControllerDictionary = 
        new Dictionary<string, Psu2000>();

    private const string ExpectedPid = "0010";
    private const string ExpectedVid = "232E";

    public PsuManager()
    {
        InitialFind(ExpectedPid, ExpectedVid);
        
        StartRuntimeComportCheck(10000, 1000);
    }

    public void InitialFind(string pid, string vid)
    {
        var availablePorts = SerialPort.GetPortNames();

        foreach (var comPort in availablePorts)
        {
            if(!ValidateComPort(comPort, pid, vid))
                continue;
            
            AddNewController(comPort);
        }
    }

    public void RegularCheck(string pid, string vid)
    {
        var availablePorts = SerialPort.GetPortNames();

        // Check if entry in dictionary is not in availablePorts
        foreach (var entry in _psuControllerDictionary)
        {
            var currentPsu = entry.Value.ComPort;

            if (availablePorts.Contains(currentPsu))
                continue;
            
            RemoveController(entry);
        }
        
        foreach (var comPort in availablePorts)
        {
            // Check if comport is valid psu
            if(!ValidateComPort(comPort, pid, vid))
                continue;

            // Check if comport is already in dictionary
            var comPortInDictionary = false;
            foreach (var entry in _psuControllerDictionary)
            {
                if (comPort == entry.Value.ComPort)
                {
                    // Comport is already in the dictionary
                    comPortInDictionary = true;
                    break;
                }
            }

            if (!comPortInDictionary)
            {
                AddNewController(comPort);
            }
        }
    }
    
    private bool ValidateComPort(string comPort, string pid, string vid)
    {
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_SerialPort");
        foreach (ManagementObject queryObject in searcher.Get())
        {
            var deviceId = queryObject["DeviceID"].ToString();
            if (deviceId.Contains(comPort))
            {
                var pnpId = queryObject["PNPDeviceID"].ToString();
                var pidIndex = pnpId.IndexOf("PID_") + "PID_".Length;
                var vidIndex = pnpId.IndexOf("VID_") + "VID_".Length;

                var thisPid = pnpId.Substring(pidIndex, 4);
                var thisVid = pnpId.Substring(vidIndex, 4);

                if (thisPid != pid || thisVid != vid) 
                    continue;
                
                return true;
            }
        }

        return false;
    }

    private void AddNewController(string comPort)
    {
        var newPsuController = new Psu2000(comPort);
        var newPsuSerialNumber = newPsuController.GetSerialNumber();
        _psuControllerDictionary.Add(newPsuSerialNumber, newPsuController);
        Console.WriteLine("Added: " + comPort);
    }
    
    private void RemoveController(KeyValuePair<string, Psu2000> dictionaryKeyValue)
    {
        _psuControllerDictionary.Remove(dictionaryKeyValue.Key);
        Console.WriteLine("Removed comport: " + dictionaryKeyValue.Value.ComPort);
    }

    private void StartRuntimeComportCheck(int totalRuntimeMs, int checkIntervalMs)
    {
        var timer = new System.Timers.Timer(checkIntervalMs);
        timer.Elapsed += OnTimerElapsed;
        timer.AutoReset = true;

        Console.WriteLine("Started runtime...");
        timer.Start();
        Thread.Sleep(totalRuntimeMs);
        timer.Stop();
        timer.Dispose();
        Console.WriteLine("Stopped runtime.");
        
        Console.WriteLine();
    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        Console.WriteLine("Searching...");
        RegularCheck(ExpectedPid, ExpectedVid);
    }
}