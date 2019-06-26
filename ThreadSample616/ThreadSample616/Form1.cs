using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSample616
{
    public partial class Form616 : Form
    {
        public Form616()
        {
            InitializeComponent();
        }

        public void btnStart_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(RunThread);
            t.Start();
            textBox1.AppendText($"主线程_start");

            //_freshTxtThread = new Thread(RefreshTxt);
            //_freshTxtThread.Start();
        }

        private void RunThread()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                Thread thread = new Thread(RunLevel3Thread);
                thread.Start();

                this.Invoke(new EventHandler(delegate {
                    textBox1.AppendText($"二级线程_{i.ToString()}");
                }));
            }
        }

        private void RunLevel3Thread()
        {
            for (int k = 0; k < int.MaxValue; k++)
            {
                this.Invoke(new EventHandler(delegate {
                    //textBox1. = //Thread.CurrentThread.;
                    textBox1.AppendText($"三级线程_{k.ToString()}");
                }));
            }
        }

        //private Thread _freshTxtThread;
        //private void RefreshTxt()
        //{
        //    textBox1.Refresh();
        //}

    }
}
