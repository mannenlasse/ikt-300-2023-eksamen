using System.Management;
using System.IO.Ports;
using PsuController;
using System.Timers;

namespace PsuManager;

public class DeviceEventArgs : EventArgs
{
    public string SerialNumber { get; }
    public Psu2000? PsuController { get; }

    public DeviceEventArgs(string serialNumber, Psu2000? psuController)
    {
        SerialNumber = serialNumber;
        PsuController = psuController;
    }
}

public class PsuDiscoveryService
{
    public event EventHandler<DeviceEventArgs> DeviceConnected;
    public event EventHandler<DeviceEventArgs> DeviceDisconnected;

    public List<ComDeviceFilter> ComDeviceFilterList = new List<ComDeviceFilter>();
    private const string ExpectedPid = "0010";
    private const string ExpectedVid = "232E";
    
    private Dictionary<string, string> _comPortsInUse = new Dictionary<string, string>();

    public Dictionary<string, Psu2000> InitialComPortDiscover()
    {
        var availablePorts = SerialPort.GetPortNames();
        var psuToAdd = new Dictionary<string, Psu2000>();

        foreach (var comPort in availablePorts)
        {
            if(!ValidateComPort(comPort))
                continue;

            _comPortsInUse.Add(comPort, "");
            
            var psuController = new Psu2000(comPort);
            var psuSerial = psuController.GetSerialNumber();

            _comPortsInUse[comPort] = psuSerial;
                
            psuToAdd.Add(psuSerial, psuController);
        }

        return psuToAdd;
    }
    
    public void RegularComPortCheck()
    {
        var availablePorts = SerialPort.GetPortNames();

        // Check for new connected comports
        foreach (var comPort in availablePorts)
        {
            if(!ValidateComPort(comPort) || _comPortsInUse.ContainsKey(comPort))
                continue;
            
            var newPsuController = new Psu2000(comPort);
            var newPsuSerial = newPsuController.GetSerialNumber();

            var newComport = new KeyValuePair<string, string>(comPort, newPsuSerial);
            _comPortsInUse.Add(newComport.Key, newComport.Value);
            
            OnDeviceConnected(newPsuSerial, newPsuController);
        }

        // Check for disconnected comports
        foreach (var comPort in _comPortsInUse)
        {
            if(availablePorts.Contains(comPort.Key))
                continue;


            var serialToRemove = comPort.Value;
            _comPortsInUse.Remove(comPort.Key);
            
            OnDeviceDisconnected(serialToRemove, null);
        }
    }

    private void OnDeviceConnected(string serialNumber, Psu2000? psuController)
    {
        DeviceConnected?.Invoke(this, new DeviceEventArgs(serialNumber, psuController));
    }

    private void OnDeviceDisconnected(string serialNumber, Psu2000? psuController)
    {
        DeviceDisconnected?.Invoke(this, new DeviceEventArgs(serialNumber, psuController));
    }

    private static bool ValidateComPort(string comPort)
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

                if (thisPid != ExpectedPid || thisVid != ExpectedVid) 
                    continue;
                
                return true;
            }
        }

        return false;
    }
    
    public struct ComDeviceFilter
    {
        public string Pid;
        public string Vid;
    }
}