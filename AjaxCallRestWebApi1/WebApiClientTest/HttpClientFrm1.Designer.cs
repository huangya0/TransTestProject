namespace WebApiClientTest
{
    partial class HttpClientFrm1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnectWebAPI_SiteList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnectWebAPI_SiteList
            // 
            this.btnConnectWebAPI_SiteList.Location = new System.Drawing.Point(44, 33);
            this.btnConnectWebAPI_SiteList.Name = "btnConnectWebAPI_SiteList";
            this.btnConnectWebAPI_SiteList.Size = new System.Drawing.Size(172, 23);
            this.btnConnectWebAPI_SiteList.TabIndex = 0;
            this.btnConnectWebAPI_SiteList.Text = "连接WebAPI方法SiteList";
            this.btnConnectWebAPI_SiteList.UseVisualStyleBackColor = true;
            this.btnConnectWebAPI_SiteList.Click += new System.EventHandler(this.btnConnectWebAPI_SiteList_Click);
            // 
            // HttpClientFrm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConnectWebAPI_SiteList);
            this.Name = "HttpClientFrm1";
            this.Text = "HttpClientFrm1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnectWebAPI_SiteList;
    }
}

