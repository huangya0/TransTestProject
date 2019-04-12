using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevExpressControlsSample1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOpenDataPagingFrm_Click(object sender, EventArgs e)
        {
            DataPagingFrm frm = new DataPagingFrm();
            frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
            frm.Show();
        }

        private void btnOpenUCPagerSamge_Click(object sender, EventArgs e)
        {
            DataPagingUseUCPagerFrm frm = new DataPagingUseUCPagerFrm();
            frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
            frm.Show();
        }
    }
}
