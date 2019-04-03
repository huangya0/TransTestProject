using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace EmqttdSample1
{
    class Program
    {
        static void messageReceive(object sender, MqttMsgPublishEventArgs e)
        {
            string msg = "Topic:" + e.Topic + "   Message:" + System.Text.Encoding.Default.GetString(e.Message);
            Console.WriteLine(msg);
        }
        static bool cafileValidCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            string msg = "X509 链状态:";
            foreach (X509ChainStatus status in chain.ChainStatus)
            {
                msg += status.StatusInformation + "\n";
            }
            msg += "SSL策略问题：" + (int)sslPolicyErrors;

            Console.WriteLine(msg);

            if (sslPolicyErrors != SslPolicyErrors.None)
                return false;
            return true;
        }

        static void Main(string[] args)
        {
            string brokerHostName = "127.0.0.1";
            int brokerPort = 8883;
            string brokerHostUrl = "127.0.0.1";
            string clientId = Guid.NewGuid().ToString(); //"m2mqtt";
            string username = "develop";
            string password = "666666";
            string[] topic = { "topic" };
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
            //string caPath = "C:/MqttSSL/ca.crt";
            string caPath = @"D:\emqttd\zacktest.cer";
            X509Certificate caCert = new X509Certificate(caPath);
            Console.WriteLine(caCert.ToString(true) + "\n" + caCert.ToString());
            Console.ReadKey();
            Console.WriteLine("------------------------分割线-------------------------------");
            //无SSL连接
            //MqttClient client = new MqttClient(brokerHostName,brokerPort,false,null,null,MqttSslProtocols.None);
            try
            {
                //单向SSL通信
                // MqttClient client = new MqttClient(brokerHostName, brokerPort, true, caCert, null, MqttSslProtocols.TLSv1_2, new RemoteCertificateValidationCallback(cafileValidCallback));
                //MqttClient client = new MqttClient(brokerHostName, brokerPort, true, null, null, MqttSslProtocols.TLSv1_2);
                MqttClient client = new MqttClient(brokerHostUrl);
                //消息接受
                client.MqttMsgPublishReceived += new MqttClient.MqttMsgPublishEventHandler(messageReceive);
                //连接Broker
                client.Connect(clientId, username, password);

                client.Subscribe(topic, qosLevels);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("连接失败! msg : " + ex.Message);
                Console.ReadKey();
            }

        }


    }
}
