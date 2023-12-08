using UsbDiscovery;

namespace UserInterface;

public class Program
{
    private static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        var formCool = new Form1();
        Application.Run(formCool);
        var p = new Program();
    }
}
