using UsbDiscovery;

namespace PsuManager;

public class Program
{
    private static async Task Main(string[] args)
    {
        var program = new Program();
        
        var comPortDiscovery = new ComPortDiscovery();
        var ps2000 = new ComPortDiscovery.ComDeviceFilter { Pid = "0010", Vid = "232E" };
        comPortDiscovery.ComDeviceFilterList.Add(ps2000);
        
        var psuManager = new PsuManager(comPortDiscovery);

        var discoveryTask = comPortDiscovery.RunAsync();
        var managerTask = psuManager.RunAsync();

        Console.WriteLine("Press key to stop...");
        Console.Read();

        psuManager.IsRunning = false;
        comPortDiscovery.IsRunning = false;

        await Task.WhenAll(discoveryTask, managerTask);
    }
}
