using System.Diagnostics;
using System.IO.Ports;
using System.Text.Json;
using MyMQTTClient;
using uPLibrary.Networking.M2Mqtt.Messages;
using PsuController;
using uPLibrary.Networking.M2Mqtt;
using System.Management;
using System.Timers;
using UsbDiscovery;

namespace PsuManager;

public class PsuManager
{
    private Dictionary<string, Psu2000?> _psuControllerStore;
    
    public bool IsRunning { get; set; } = true;
    
    public PsuManager(ComPortDiscovery comPortDiscovery)
    {
        _psuControllerStore = new Dictionary<string, Psu2000?>();
        
        //var ps2000 = new ComPortDiscovery.ComDeviceFilter { Pid = "0010", Vid = "232E" };
        //_psuDiscovery.ComDeviceFilterList.Add(ps2000);
        
        comPortDiscovery.DeviceConnected += AddController;
        comPortDiscovery.DeviceDisconnected += RemoveController;
    }

    public async Task RunAsync()
    {
        while (IsRunning)
        {
            await Task.Delay(1000);
            
            // Console.WriteLine("Manager is running.");
        }
    }

    private void AddController(object sender, DeviceEventArgs e)
    {
        _psuControllerStore.Add(e.ComPort, null);
        
        Console.WriteLine("Added controller on: " + e.ComPort);
    }

    private void RemoveController(object sender, DeviceEventArgs e)
    {
        _psuControllerStore.Remove(e.ComPort);
        
        Console.WriteLine("Removed controller on: " + e.ComPort);
    }
    /*
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
        .RegularComPortCheck();
    } */
}