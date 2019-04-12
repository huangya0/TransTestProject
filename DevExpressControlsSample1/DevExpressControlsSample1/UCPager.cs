using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpressControlsSample1.EF;
using Microsoft.Win32;

namespace DevExpressControlsSample1
{
    public delegate void PagerReloadDataHandler(EventArgs e);

    /// <summary>
    /// 使用方法：参考DataPagingUseUCPagerFrm
    /// </summary>
    public partial class UCPager : UserControl
    {
        public event PagerReloadDataHandler PagerReloadDataEvent;


        BaseSearchModel searchModel = new BaseSearchModel();
        public UCPager()
        {
            InitializeComponent();
        }

        public void RefreshPager<T>(DevExpress.XtraGrid.GridControl gridControl, List<T> lsList, BaseSearchModel search)
        {
            this.searchModel = search;
            this.bindingSource1.DataSource = lsList;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            gridControl.DataSource = this.bindingSource1;

            this.lblCurrentPage.Text = "当前页：" + searchModel.PageNum.ToString();
            this.lblTotalPage.Text = "总页数：" + searchModel.TotalPage.ToString();
            this.lblPageSize.Text = "每页记录数：" + searchModel.PageSize.ToString();
            this.lblTotalRecordCount.Text = "总记录数：" + searchModel.RecordCount.ToString();
            this.txtJumpTo.Text = searchModel.PageNum.ToString();
        }

        public BindingSource GetBindingSource()
        {
            return this.bindingSource1;
        }

        //标记避免在按钮点改变了txtJumpTo值导致二次触发PagerReloadDataEvent事件
        private bool isButtonClicked = false;

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
                searchModel.PageNum--;
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
                searchModel.PageNum--;
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
                searchModel.PageNum++;
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
                searchModel.PageNum++;
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

            isButtonClicked = true;

            //LoadData();
            if (this.PagerReloadDataEvent != null)
            {
                this.PagerReloadDataEvent(EventArgs.Empty);
            }

        }

        private void txtJumpTo_TextChanged(object sender, EventArgs e)
        {
            if (!isButtonClicked)
            {
                //跳到某页
                searchModel.PageNum = Int32.Parse(this.txtJumpTo.Text.Trim());
                //LoadData();
                if (this.PagerReloadDataEvent != null)
                {
                    this.PagerReloadDataEvent(EventArgs.Empty);
                }
            }
            else
            {
                isButtonClicked = false;
            }
            
        }
    }
}
