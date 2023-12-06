using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;

namespace MyMQTTClient
{
    public class MyMqtt
    {
        private string clientID;
        static string connectionstring = "localhost";
        private string topic;

        MqttClient client = new MqttClient(connectionstring);

 
        public void connectClient()
        {
            
            clientID = Guid.NewGuid().ToString();
            
            client.Connect(clientID);
            Console.WriteLine("Connected to: " + clientID );
            Console.WriteLine(" Connectionstring  is: " + connectionstring );
        }
        

        
        public void Subscribe(string topicInput)
        {
            
            Console.WriteLine(topicInput);
            string topic = string.Format("/PSU/PSU2000/{0}/#", topicInput);
            client.Subscribe(new string[] { topic }, new byte[] { 2 });
            Console.WriteLine("Subscribed to " + topic );

            
        }

        

        public void publish(string topic, string message)
        {
     
             topic = string.Format("/PSU/PSU2000/{0}/{1}", topic, message);
            client.Publish(topic, Encoding.UTF8.GetBytes(topic), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
            Console.WriteLine("Published message " + message + " to the topic: " + topic );
        }
        
        
        

    }



}