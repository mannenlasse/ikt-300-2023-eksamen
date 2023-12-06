using System.Runtime.InteropServices.ComTypes;
using System.Text;
using PsuManager;
using PsuController;

namespace PsuManager
{
    

    public class psuManager
    {
        private Psu2000 _psuController = new Psu2000();

/*
        public psuManager()
        {
            _mqttClient = new MyMqtt();
            _mqttClient.connectClient();
            _mqttClient.Subscribe("+");
        }

*/
        public void SerialNumber()
        {
            Console.WriteLine("The serial number for this PSU is: " + _psuController.GetSerialNumber() );
        }

    }
    
}
