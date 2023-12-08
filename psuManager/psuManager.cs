using System.Globalization;
using PsuController;
using UsbDiscovery;
using MyMqttClientWrapper;

namespace PsuManager;

public class PsuManager
{
    private Dictionary<string, ComDeviceFilter> _nameToFilter;
    private List<PsuControllerContainer> _psuControllerList;
    private ComPortDiscovery _psuDiscovery;

    private MyMqttClient _mqttClient;
    public bool IsRunning { get; set; }
    public int PortCheckInterval { get; set; }
    private int PsuValuesUpdate { get; set; }
    
    public PsuManager()
    {
        _nameToFilter = new Dictionary<string, ComDeviceFilter>();
        _psuControllerList = new List<PsuControllerContainer>();
        _psuDiscovery = new ComPortDiscovery();
        _mqttClient = new MyMqttClient("localhost");

        IsRunning = true;
        PortCheckInterval = 1000;
        
        _nameToFilter.Add("PS2000", new ComDeviceFilter { Pid = "0010", Vid = "232E"});
        _psuDiscovery.ComDeviceFilterList.Add(_nameToFilter["PS2000"]);
        
        _psuDiscovery.DeviceConnected += AddPsuController;
        _psuDiscovery.DeviceDisconnected += RemovePsuController;
        _mqttClient.OnSubscribedTopicUpdated += TopicUpdateEventHandler;
    }

    public async Task RunAsync()
    {
        while (IsRunning)
        {
            await Task.Delay(PortCheckInterval);
            
            _psuDiscovery.RegularComPortCheck();
        }
    }
    
    private void AddPsuController(object sender, DeviceEventArgs e)
    {
        var psuName = "";
        foreach (var name in _nameToFilter)
        {
            if (name.Value.Pid == e.ComFilter.Pid && name.Value.Vid == e.ComFilter.Vid)
                psuName = name.Key;
        }

        var psuController = PsuFactory.CreatePsu(psuName, e.ComPort);
        
        var newPsuController = new PsuControllerContainer
        {
            PsuName = psuName,
            ComPort = e.ComPort,
            SerialNumber = psuController.GetSerialNumber(),
            PsuController = psuController,
        };
        
        _psuControllerList.Add(newPsuController);
        Console.WriteLine("Added " + newPsuController.SerialNumber + " on " + newPsuController.ComPort);
        
        var topic = "PSU/" + newPsuController.PsuName + "/" + newPsuController.SerialNumber + "/";
        var currentVoltage = newPsuController.PsuController.GetVoltage();
        var currentCurrent = newPsuController.PsuController.GetCurrent();
        _mqttClient.Publish(topic + "Voltage/Get", currentVoltage);
        _mqttClient.Publish(topic + "Current/Get", currentCurrent);
        _mqttClient.Publish(topic + "Status", "1");
        SubscribeAll(topic);
    }

    private void RemovePsuController(object sender, DeviceEventArgs e)
    {
        foreach (var psuController in _psuControllerList)
        {
            if (e.ComPort != psuController.ComPort)
                continue;

            _psuControllerList.Remove(psuController);
            Console.WriteLine("Removed " + psuController.SerialNumber + " on " + psuController.ComPort);
            
            var topic = "PSU/" + psuController.PsuName + "/" + psuController.SerialNumber + "/";
            UnSubscribeAll(topic);
            
            _mqttClient.Publish(topic + "Status", "0");
            break;
        }
    }

    private void SubscribeAll(string topic)
    {
        _mqttClient.Subscribe(topic + "Voltage/Set");
        _mqttClient.Subscribe(topic + "Stop");
        _mqttClient.Subscribe(topic + "LockUnlock");
        _mqttClient.Subscribe(topic + "X");
    }

    private void UnSubscribeAll(string topic)
    {
        var topicArray = new string[4];

        topicArray[0] = topic + "Voltage/Set";
        topicArray[1] = topic + "Stop";
        topicArray[2] = topic + "LockUnlock";
        topicArray[3] = topic + "X";
        
        _mqttClient.Unsubscribe(topicArray);
    }

    private void TopicUpdateEventHandler(object sender, MyMqttClient.TopicUpdate e)
    {
        foreach (var psuController in _psuControllerList)
        {
            if(!e.Topic.Contains(psuController.SerialNumber))
                continue;
            
            var topic = "PSU/" + psuController.PsuName + "/" + psuController.SerialNumber + "/";

            if (e.Topic == topic + "Voltage/Set")
            {
                if(float.TryParse(e.Message, out var voltageToSet))
                    psuController.PsuController.SetVoltage(voltageToSet);
                else
                {
                    voltageToSet = float.Parse(e.Message, CultureInfo.InvariantCulture);
                    psuController.PsuController.SetVoltage(voltageToSet);
                }
            }
            else if (e.Topic == topic + "Stop")
            {
                psuController.PsuController.StopOperation();
            }
            else if (e.Topic == topic + "LockUnlock")
            {
                var shouldLockInt = int.Parse(e.Message);
                var shouldLock = Convert.ToBoolean(shouldLockInt);
                
                psuController.PsuController.LockUnlock(shouldLock);
            }
            else
            {
                Console.WriteLine("ERROR: Unknown operation " + e.Topic);
            }
        }
    }

    public struct PsuControllerContainer
    {
        public string PsuName;
        public string ComPort;
        public string SerialNumber;
        public IPsu PsuController;
    }
}