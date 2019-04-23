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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace DevExpressControlsSample1
{
    public partial class RepositoryItemMemoFrm : Form
    {
        public RepositoryItemMemoFrm()
        {
            InitializeComponent();
        }

        private void RepositoryItemMemoFrm_Load(object sender, EventArgs e)
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

                this.gridControl1.DataSource = ls;
                this.gridView1.OptionsCustomization.AllowRowSizing = true; //行可再设高

                //this.gridView1.CanResizeRow = true;
                //for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    this.repositoryItemMemoExEdit1.ShowIcon = false;
                    gridView1.Columns["Message"].ColumnEdit = this.repositoryItemMemoExEdit1;
                    this.gridControl1.RepositoryItems.Add(this.repositoryItemMemoExEdit1);

                    gridView1.Columns["Type"].ColumnEdit = this.repositoryItemMemoEdit1;
                    this.gridControl1.RepositoryItems.Add(this.repositoryItemMemoEdit1);

                    var popupContainerControl = new PopupContainerControl();
                    popupContainerControl.Controls.Add(new TextBox());
                    this.repositoryItemPopupContainerEdit1.PopupControl = popupContainerControl;
                    gridView1.Columns["Application"].ColumnEdit = this.repositoryItemPopupContainerEdit1;
                    this.gridControl1.RepositoryItems.Add(this.repositoryItemPopupContainerEdit1);

                    gridView1.Columns["Host"].ColumnEdit = this.repositoryItemRichTextEdit1;
                    this.gridControl1.RepositoryItems.Add(this.repositoryItemRichTextEdit1);

                    gridView1.Columns["Source"].ColumnEdit = this.repositoryItemTextEdit1;
                    this.gridControl1.RepositoryItems.Add(this.repositoryItemTextEdit1);
                }

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ELMAH_Error> ls = ((List<ELMAH_Error>)this.gridControl1.DataSource);
            DataPagingBL bl = new DataPagingBL();
            bl.UpdateList(ls);
            ;
            XtraMessageBox.Show("更新成功！");
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "新增行":
                    this.gridView1.AddNewRow();
                    gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["Application"], "Please enter new value");
                    break;
                case "删除行":
                    //string message = menuItem.Caption.Replace("&", "");
                    if (XtraMessageBox.Show("删除此行?", "确认操作", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return;
                    //ri.View.DeleteRow(ri.RowHandle);
                    this.gridView1.DeleteRow(this.gridView1.FocusedRowHandle);
                    break;
                case "查看注册历史":
                    XtraMessageBox.Show("点击了查看注册历史按钮！");
                    //this.PopupClientRegHistoryFrm();
                    break;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(this.gridControl1, e.Location);
            }
        }
    }
}
