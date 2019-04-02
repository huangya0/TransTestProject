namespace RemotingClient
{
    partial class RemotingClientFrm
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
            this.btnGetSimpleData = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGetListData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetSimpleData
            // 
            this.btnGetSimpleData.Location = new System.Drawing.Point(12, 41);
            this.btnGetSimpleData.Name = "btnGetSimpleData";
            this.btnGetSimpleData.Size = new System.Drawing.Size(154, 23);
            this.btnGetSimpleData.TabIndex = 0;
            this.btnGetSimpleData.Text = "btnGetSimpleData";
            this.btnGetSimpleData.UseVisualStyleBackColor = true;
            this.btnGetSimpleData.Click += new System.EventHandler(this.btnGetSimpleData_Click_1);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(12, 70);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(100, 21);
            this.txtValue.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(252, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(506, 370);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnGetListData
            // 
            this.btnGetListData.Location = new System.Drawing.Point(252, 12);
            this.btnGetListData.Name = "btnGetListData";
            this.btnGetListData.Size = new System.Drawing.Size(191, 23);
            this.btnGetListData.TabIndex = 3;
            this.btnGetListData.Text = "btnGetListData";
            this.btnGetListData.UseVisualStyleBackColor = true;
            this.btnGetListData.Click += new System.EventHandler(this.btnGetListData_Click);
            // 
            // RemotingClientFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetListData);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnGetSimpleData);
            this.Name = "RemotingClientFrm";
            this.Text = "Remoting Client Form";
            this.Load += new System.EventHandler(this.RemotingClientFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetSimpleData;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGetListData;
    }
}

