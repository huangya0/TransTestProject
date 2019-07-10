using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Action<int> setValue = (i) => { textBox1.Text = i.ToString(); };
                for (int i = 0; i < 1000000; i++)
                {
                    textBox1.Invoke(setValue, i);
                }
            });
        }
    }
}
