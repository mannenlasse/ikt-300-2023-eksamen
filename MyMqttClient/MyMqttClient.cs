using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;

namespace MyMQTTClient
{
    public class MyMqtt
    {
        private string clientID;
        private string message_PSUID;
        static string connectionstring = "localhost";
        

        MqttClient client = new MqttClient(connectionstring);

 
        public void connectClient()
        {
            
            clientID = Guid.NewGuid().ToString();
            
            client.Connect(clientID);
            Console.WriteLine("Connected to: " + clientID );
            Console.WriteLine(" Connectionstring  is: " + connectionstring );
        }
        

        public void Subscribe(string topic)
        {

            client.Subscribe(new String[] { topic }, new byte[] { 2 });
            Console.WriteLine("Subscribed to " + topic );


        }

        
        
        
        

        public void publish(string sender, string e)
        {
            string topic = string.Format("/PSU/PSU2000/{0}/{1}", "test");
            client.Publish(topic, Encoding.UTF8.GetBytes(topic), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            Console.WriteLine("Published to topic: " + topic );

        }
        
        
        
        /*
         public void Connect(object sender, EventArgs e) {
             string connectionString = "localhost";
             m_Client = new MqttClient(connectionString);
             clientID = Guid.NewGuid().ToString();
             m_Client.Connect(clientID);
         }

         private void Publish(object sender, EventArgs e) {
             string topic = string.Format("/PSU/PSU2000/{0}/{1}", m_PSUID);
             m_Client.Publish(topic, Encoding.UTF8.GetBytes(topic), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
         }
        */

    }



}