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
        }

        private void UcPager1_PagerReloadDataEvent(EventArgs e)
        {
            this.LoadData();
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
    }
}
