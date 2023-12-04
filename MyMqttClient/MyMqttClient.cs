using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;

namespace MyMQTTClient
{
    public class MyMqttClient
    {
        

        static MqttClient m_Client;
        static string clientID;
        static string m_PSUID;



        public void Connect(object sender, EventArgs e)
        {

            string connectionString = "localhost";
            m_Client = new MqttClient(connectionString);
            clientID = Guid.NewGuid().ToString();
            m_Client.Connect(clientID);
        }
        
        

        private void Publish(object sender, EventArgs e)
        {
            string topic = string.Format("/PSU/PSU2000/{0}/{1}", m_PSUID);
            m_Client.Publish(topic, Encoding.UTF8.GetBytes(topic), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
        }
        
        
    }
    
    
    
}
