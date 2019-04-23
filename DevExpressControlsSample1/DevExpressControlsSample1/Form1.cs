using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        private void btnRepositoryItemMemoFrm_Click(object sender, EventArgs e)
        {
            RepositoryItemMemoFrm frm = new RepositoryItemMemoFrm();
            frm.StartPosition = FormStartPosition.CenterParent;
            //frm.ShowDialog();
            frm.Show();
        }

        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {

            }
        }

        //private List<KeyValuePair<string, string>> lsDirFileName = new List<KeyValuePair<string, string>>();
        private Dictionary<string, string> lsDirFileName = new Dictionary<string, string>();
        public void FindFile(string dirPath) //参数dirPath为指定的目录
        {
            //在指定目录及子目录下查找文件,在listBox1中列出子目录及文件
            DirectoryInfo Dir = new DirectoryInfo(dirPath);
            foreach (DirectoryInfo d in Dir.GetDirectories())//查找子目录 
            {
                FindFile(Dir + d.ToString() + @"\");
                //listBox1.Items.Add(Dir + d.ToString() + "\");	//listBox1中填加目录名
            }
            foreach (FileInfo f in Dir.GetFiles("*.*")) //查找文件
            {
                //listBox1.Items.Add(Dir + f.ToString()); //listBox1中填加文件名
                lsDirFileName.Add(f.FullName, f.Name);
            }
        }
        private void btnReadFolder_Click(object sender, EventArgs e)
        {
            this.FindFile(@"D:\Downloads\");
            this.gridControlFiles.DataSource = lsDirFileName;
        }

        private void btnSelectedFile_Click(object sender, EventArgs e)
        {
            string fileName = ((KeyValuePair<string, string>) this.gridViewFiles.GetFocusedRow()).Key;

        }
    }
}
