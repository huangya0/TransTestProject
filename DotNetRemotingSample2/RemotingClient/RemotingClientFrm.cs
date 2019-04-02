using RemotingLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemotingClient
{
    public partial class RemotingClientFrm : Form
    {
        public RemotingClientFrm()
        {
            InitializeComponent();
        }

        private void RemotingClientFrm_Load(object sender, EventArgs e)
        {

        }

        //连接服务器的方法
        private bool Connect()
        {
            string str = string.Format("tcp://{0}:7575/Config", "127.0.0.1");

            TcpClientChannel tcp = null;
            try
            {


                tcp = new TcpClientChannel();
                ChannelServices.RegisterChannel(tcp, false);
                ConfigObject obj = (ConfigObject)Activator.GetObject(typeof(ConfigObject), str);

                string result = obj.RemoteMethod("key");
                this.txtValue.Text = result;


                if (string.IsNullOrEmpty(result))
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (tcp != null) ChannelServices.UnregisterChannel(tcp);
            }


            return true;
        }


        private void btnGetListData_Click(object sender, EventArgs e)
        {
            string str = string.Format("tcp://{0}:7575/Config", "127.0.0.1");

            TcpClientChannel tcp = null;
            try
            {


                tcp = new TcpClientChannel();
                ChannelServices.RegisterChannel(tcp, false);
                ConfigObject obj = (ConfigObject)Activator.GetObject(typeof(ConfigObject), str);

                List< ListDataModel> listData = obj.GetListDataModel(11);
                this.dataGridView1.DataSource = listData;
                


                //if (string.IsNullOrEmpty(result))
                //{
                //    //return false;
                //}

            }
            catch (Exception ex)
            {
                //return false;
            }
            finally
            {
                if (tcp != null) ChannelServices.UnregisterChannel(tcp);
            }


            //return true;
        }

        private void btnGetSimpleData_Click_1(object sender, EventArgs e)
        {
            this.Connect();
        }
    }
}
