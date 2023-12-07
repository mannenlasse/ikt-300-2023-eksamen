using PsuController;
using PsuManager;
using UsbDiscovery;

namespace UserInterface;

public class Program
{
    [STAThread]
    private static async Task Main(string[] args)
    {/*
        ApplicationConfiguration.Initialize();
        var formCool = new Form1();
        Application.Run(formCool);
        var p = new Program();
        p.ProgramStart(formCool); */

        var comPortDiscovery = new ComPortDiscovery();
        var ps2000 = new ComPortDiscovery.ComDeviceFilter { Pid = "0010", Vid = "232E" };
        comPortDiscovery.ComDeviceFilterList.Add(ps2000);
        
        var psuManager = new PsuManager.PsuManager(comPortDiscovery);

        var discoveryTask = comPortDiscovery.RunAsync();
        var managerTask = psuManager.RunAsync();

        Console.WriteLine("Press key to stop...");
        Console.Read();

        psuManager.IsRunning = false;
        comPortDiscovery.IsRunning = false;

        await Task.WhenAll(discoveryTask, managerTask);
    }

    private void ProgramStart(Form1 form)
    {
        
    }
}
