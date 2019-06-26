using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadSample616;

namespace Kill616
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var list = System.Diagnostics.Process.GetProcessesByName("Kill616");
                foreach (var item in list)
                {
                    item.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("kill failed, mssage is --" + ex.Message);
            }
            MessageBox.Show("killed all");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int maxCount = int.Parse(textBox1.Text);
            for (int i = 0; i < maxCount; i++)
            {
                Form616 frm = new Form616();
                frm.Show();
                frm.btnStart_Click(null, EventArgs.Empty);
            }
        }
    }
}
