using EF_FromDBCodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_Test1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(ctx.Table_1.First().Name);
            using (var ctx =  new EmsWebDB1())
            {
                MessageBox.Show(ctx.Table_1.First().Name);
            }

        }
    }
}
