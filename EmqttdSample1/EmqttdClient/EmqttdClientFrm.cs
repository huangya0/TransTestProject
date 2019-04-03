using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace EmqttdClient
{
    public partial class EmqttdClientFrm : Form
    {
        public EmqttdClientFrm()
        {
            InitializeComponent();
        }

        private void EmqttdClientFrm_Load(object sender, EventArgs e)
        {
            //http://www.emqtt.com/
            //https://blog.csdn.net/liluyuan/article/details/80445896

            //    2.下载复制到D:盘,进行解压 到emqttd目录,

            //2.1在cmd模式下, 进入D:\emqttd\bin目录: 执行如下命令: emqttd start

            //2.2:执行完成后,可以在浏览器中,打开如下网站: http://127.0.0.1:18083 可以打开什么安装成功

            //        默认用户名: admin 密码:public
            //--------------------- 
        
        }

    public void WriteMsg(string msg)
        {
            //string msg = "Topic:" + e.Topic + "   Message:" + System.Text.Encoding.Default.GetString(e.Message);

            this.txtMsg.AppendText("\r\n" + msg);
        }

        public void messageReceive(object sender, MqttMsgPublishEventArgs e)
        {
            string msg = "Topic:" + e.Topic + "   Message:" + System.Text.Encoding.Default.GetString(e.Message);
            this.WriteMsg(msg);
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

        MqttClient client = null;
        private void btnConnect_Click(object sender, EventArgs e)
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
                client = new MqttClient(brokerHostUrl);
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            string topic = "topic";
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE };
            //client.Subscribe(topic,  qosLevels);

            string msg = "msg sent from client!Q";
            client.Publish(topic, System.Text.Encoding.UTF8.GetBytes(msg));
        }
    }
}
