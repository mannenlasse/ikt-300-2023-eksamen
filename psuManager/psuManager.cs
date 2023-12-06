using System.Diagnostics;
using System.IO.Ports;
using System.Text.Json;
using MyMQTTClient;
using PsuManager;
using uPLibrary.Networking.M2Mqtt.Messages;
using PsuController;
using uPLibrary.Networking.M2Mqtt;

namespace PsuManager;

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
}
