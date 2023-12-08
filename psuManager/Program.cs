using UsbDiscovery;

namespace PsuManager;

public class Program
{
    private static async Task Main(string[] args)
    {
        var program = new Program();
        var psuManager = new PsuManager();

        var managerTask = psuManager.RunAsync();

        Console.WriteLine("Press key to stop...");
        Console.Read();

        psuManager.IsRunning = false;

        await managerTask;
    }
}
