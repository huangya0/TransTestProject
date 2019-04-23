using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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
using DevExpress.XtraGrid.Views.Grid;

namespace DevExpressControlsSample1
{
    public partial class DataPagingUseUCPagerFrm : Form
    {
        public DataPagingUseUCPagerFrm()
        {
            InitializeComponent();
        }

        private void DataPagingUseUCPagerFrm_Load(object sender, EventArgs e)
        {
            this.LoadData();
            this.ucPager1.PagerReloadDataEvent += UcPager1_PagerReloadDataEvent;

            //this.gridView1.InitNewRow += (sender, args) => GridViewInitialNewRow();
            this.gridView1.InitNewRow += new InitNewRowEventHandler(GridViewInitialNewRow);
        }

        private void UcPager1_PagerReloadDataEvent(EventArgs e)
        {
            this.LoadData();
        }

        private void GridViewInitialNewRow(object sender, EventArgs args)
        {
            this.gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["ErrorId"], Guid.NewGuid());
            gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["Application"], "Please enter new value");
            gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["TimeUtc"], DateTime.Now);
        }

        //只能定义在LoadData外，不能定义在里边，定义在里边会被ucPager事件调用此方法时冲掉
        ELMAH_Error_SearchModel searchModel = new ELMAH_Error_SearchModel();

        private void LoadData()
        {
            
            DataPagingBL bl = new DataPagingBL();
            searchModel.SortBy = nameof(ELMAH_Error.Type);
            searchModel.SortDirection = "DESC";

            //searchModel.PageNum = pageCurrent;
            //searchModel.PageSize = pageSize;
            //searchModel.PageSkip

            //改写控件时，只需将search model传给user control
            //此方法现在用的是EF,也可以改成用存储过程，参考https://blog.csdn.net/david_520042/article/details/50675645
            List<ELMAH_Error> ls = bl.GetElmahErrorLog(searchModel); 

            this.ucPager1.RefreshPager<ELMAH_Error>(this.gridControl1, ls, searchModel);

            //this.gridControl1.DataSource = this.ucPager1.GetBindingSource();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this.gridControl1, e.Location);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "新增行":
                    //方法1
                    //this.gridView1.AddNewRow();
                    //gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["Application"], "Please enter new value");
                    //gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["ErrorId"], Guid.NewGuid());
                    //gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["TimeUtc"], DateTime.Now);
                    //方法2
                    List<ELMAH_Error> list = ((BindingSource)this.gridControl1.DataSource).List as List<ELMAH_Error>;
                    var newItem = new ELMAH_Error();
                    newItem.ErrorId = Guid.NewGuid();
                    newItem.TimeUtc = System.DateTime.Now;
                    list.Add(newItem);
                    this.ucPager1.GetBindingSource().DataSource = list;
                    this.gridControl1.RefreshDataSource();

                    break;
                case "删除行":
                    //string message = menuItem.Caption.Replace("&", "");
                    if (XtraMessageBox.Show("删除此行?", "确认操作", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    //ri.View.DeleteRow(ri.RowHandle);
                    this.gridView1.DeleteRow(this.gridView1.FocusedRowHandle);
                    //没实现真正删除，只是在界面删除了

                    break;
                case "查看注册历史":
                    XtraMessageBox.Show("点击了查看注册历史按钮！");
                    //this.PopupClientRegHistoryFrm();
                    break;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //List直接绑定到GridControl时可这样转换，但通过BindingSource控件的时侯不能这样转换
            //List<ELMAH_Error> ls = ((List<ELMAH_Error>)this.gridControl1.DataSource); 

            List<ELMAH_Error> ls = ((BindingSource) this.gridControl1.DataSource).List as List<ELMAH_Error>;
            DataPagingBL bl = new DataPagingBL();
            bl.UpdateList(ls);
            ;
            XtraMessageBox.Show("更新成功！");
        }
    }
}
