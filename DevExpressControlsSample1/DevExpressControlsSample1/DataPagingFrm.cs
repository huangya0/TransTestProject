using DevExpressControlsSample1.EF;
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
    //参考链接 https://blog.csdn.net/david_520042/article/details/50675645

    public partial class DataPagingFrm : Form
    {
        public DataPagingFrm()
        {
            InitializeComponent();
        }


        //private int pageSize = 10;     //每页显示行数
        //private int nMax = 0;         //总记录数
        //private int pageCount = 0;    //页数＝总记录数/每页显示行数
        //private int pageCurrent = 0;   //当前页号

        private void DataPagingFrm_Load(object sender, EventArgs e)
        {
            this.LoadData();

        }

        ELMAH_Error_SearchModel searchModel = new ELMAH_Error_SearchModel();
        private void LoadData()
        {
           // using (DataPagingBL bl = new DataPagingBL())
            {
                DataPagingBL bl = new DataPagingBL();
                searchModel.SortBy = nameof(ELMAH_Error.Type);
                searchModel.SortDirection = "DESC";
                //searchModel.PageNum = pageCurrent;
                //searchModel.PageSize = pageSize;
                //searchModel.PageSkip

                //改写控件时，只需将search model传给user control
                List<ELMAH_Error> ls = bl.GetElmahErrorLog(searchModel);


                this.bindingSource1.DataSource = ls;
                this.bindingNavigator1.BindingSource = this.bindingSource1;
                this.gridControl1.DataSource = this.bindingSource1;

                this.lblCurrentPage.Text = "当前页：" + searchModel.PageNum.ToString();
                this.lblTotalPage.Text = "总页数：" + searchModel.TotalPage.ToString();
                this.lblPageSize.Text = "每页记录数：" + searchModel.PageSize.ToString();
                this.lblTotalRecordCount.Text = "总记录数：" + searchModel.RecordCount.ToString();
                this.txtJumpTo.Text = searchModel.PageNum.ToString();
            }
            
        }

        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "首页")
            {
                //pageCurrent--;
                //if (pageCurrent <= 0)
                //{
                //    MessageBox.Show("已经是首页，请点击“下一页”查看！");
                //    return;
                //}
                //else
                //{
                //    pageCurrent = 1;
                //    //dtInfo = sp.ExecuteDataTable("DZ_LoginLog", "Id", "Id desc", pageCurrent, pageSize);
                //}
                searchModel.PageNum --;
                if (searchModel.PageNum <= 0)
                {
                    MessageBox.Show("已经是首页，请点击“下一页”查看！");
                    return;
                }
                else
                {
                    searchModel.PageNum = 1;
                    //dtInfo = sp.ExecuteDataTable("DZ_LoginLog", "Id", "Id desc", pageCurrent, pageSize);
                }
            }
            if (e.ClickedItem.Text == "上一页")
            {
                searchModel.PageNum --;
                //因为searchModel.PageNum是0时会返回1，所以下边判断是<=1
                if (searchModel.PageNum <= 1)
                {
                    MessageBox.Show("已经是第一页，请点击“下一页”查看！");
                    return;
                }
                else
                {
                    //dtInfo = sp.ExecuteDataTable("DZ_LoginLog", "Id", "Id desc", pageCurrent, pageSize);
                }
            }
            if (e.ClickedItem.Text == "下一页")
            {
                searchModel.PageNum ++;
                if (searchModel.PageNum > searchModel.TotalPage)
                {
                    MessageBox.Show("已经是最后一页，请点击“上一页”查看！");
                    return;
                }
                else
                {
                    //dtInfo = sp.ExecuteDataTable("DZ_LoginLog", "Id", "Id desc", pageCurrent, pageSize);
                }
            }
            if (e.ClickedItem.Text == "尾页")
            {
                searchModel.PageNum ++;
                if (searchModel.PageNum > searchModel.TotalPage)
                {
                    MessageBox.Show("已经是尾页，请点击“上一页”查看！");
                    return;
                }
                else
                {
                    searchModel.PageNum = searchModel.TotalPage;
                    //dtInfo = sp.ExecuteDataTable("DZ_LoginLog", "Id", "Id desc", pageCount, pageSize);
                }
            }
            LoadData();

        }

        private void txtJumpTo_TextChanged(object sender, EventArgs e)
        {
            //跳到某页
            searchModel.PageNum = Int32.Parse(this.txtJumpTo.Text.Trim());
            LoadData();
        }
    }
}
