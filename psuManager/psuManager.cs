using System.Text;
using MyMQTTClient;
using PsuManager;

using uPLibrary.Networking.M2Mqtt.Messages;
using PsuController;
using uPLibrary.Networking.M2Mqtt;

namespace PsuManager
{
    

    public class psuManager
    {
        private IPsu _psu;
        private MyMqtt _mqttClient;


        public psuManager()
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
    
}
