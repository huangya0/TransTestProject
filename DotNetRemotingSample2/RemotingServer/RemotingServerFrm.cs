using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemotingServer
{
    public partial class RemotingServerFrm : Form
    {
        //声明一个Server变量
        Server server = null;

        public RemotingServerFrm()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            server = new Server(this);
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            server.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            server.Stop();
        }

        //Server里启动服务端后,调用f.Start()，就是修改一下按钮的状态而已
        public void Start()
        {
            this.btnStop.Enabled = true;
            this.btnBegin.Enabled = false;
        }


        public void Stop()
        {
            this.btnBegin.Enabled = true;
            this.btnStop.Enabled = false;
        }

        public void WriteMsg(string msg)
        {
            this.txtMsg.AppendText("\r\n" + msg);
        }
    }
}
