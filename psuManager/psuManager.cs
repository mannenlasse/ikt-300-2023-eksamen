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

public class PsuManager
{
    private Dictionary<string, IPsu> _psuControllerStore;
    private PsuDiscoveryService _psuDiscovery;
    
    public PsuManager()
    {
        _psuControllerStore = new Dictionary<string, IPsu>();
        _psuDiscovery = new PsuDiscoveryService();
        var Ps2000 = new PsuDiscoveryService.ComDeviceFilter { Pid = "a", Vid = "a" };
        _psuDiscovery.ComDeviceFilterList.Add(Ps2000);
        InitialDictionaryFill();
        
        _psuDiscovery.DeviceConnected += AddController;
        _psuDiscovery.DeviceDisconnected += RemoveController;
    }

    private void InitialDictionaryFill()
    {
        var dictionaryToAdd = _psuDiscovery.InitialComPortDiscover();

        foreach (var psu in dictionaryToAdd)
        {
            _psuControllerStore.Add(psu.Key, psu.Value);
        }
    }

    private void AddController(object sender, DeviceEventArgs e)
    {
        var psuController = e.PsuController;
        var psuSerialNumber = e.SerialNumber;

        if (psuController == null)
            return;
        
        _psuControllerStore.Add(psuSerialNumber, psuController);
        Console.WriteLine("Added: " + psuSerialNumber);
    }

    private void RemoveController(object sender, DeviceEventArgs e)
    {
        var psuSerialNumber = e.SerialNumber;
        
        _psuControllerStore.Remove(psuSerialNumber);
        Console.WriteLine("Removed: " + psuSerialNumber);
    }
    
    public void StartRuntimeComportCheck(int totalRuntimeMs, int checkIntervalMs)
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
        _psuDiscovery.RegularComPortCheck();
    }
}