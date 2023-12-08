using PsuController;
using UsbDiscovery;
using MyMqttClientWrapper;

namespace PsuManager;

public class PsuManager
{
    private Dictionary<string, Psu2000?> _psuControllerStore;

    private MyMqttClient _client; 
    
    public bool IsRunning { get; set; } = true;
    
    public PsuManager(ComPortDiscovery comPortDiscovery)
    {
        _psuControllerStore = new Dictionary<string, Psu2000?>();
        _client = new MyMqttClient("localhost");
        
        _client.Publish("Psu/Psu2000/21717848381/GetVoltage", "24");
        _client.Subscribe("Psu/Psu2000/21717848381/GetVoltage");
        
        //var ps2000 = new ComPortDiscovery.ComDeviceFilter { Pid = "0010", Vid = "232E" };
        //_psuDiscovery.ComDeviceFilterList.Add(ps2000);
        
        comPortDiscovery.DeviceConnected += AddController;
        comPortDiscovery.DeviceDisconnected += RemoveController;
        _client.OnSubscribedTopicUpdated += TopicUpdateEventHandler;
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

    private void TopicUpdateEventHandler(object sender, MyMqttClient.TopicUpdate e)
    {
        Console.WriteLine(e.Topic + ": " + e.Message);
    }
}