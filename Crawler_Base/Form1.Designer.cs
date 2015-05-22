namespace Crawler_Base
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbSrc = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPsw = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.tbTable = new System.Windows.Forms.TextBox();
            this.tbDb = new System.Windows.Forms.TextBox();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbSrc
            // 
            this.tbSrc.Location = new System.Drawing.Point(12, 25);
            this.tbSrc.Name = "tbSrc";
            this.tbSrc.Size = new System.Drawing.Size(88, 20);
            this.tbSrc.TabIndex = 0;
            this.tbSrc.Text = "localhost";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(126, 25);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(89, 20);
            this.tbUser.TabIndex = 0;
            this.tbUser.Text = "root";
            // 
            // tbPsw
            // 
            this.tbPsw.Location = new System.Drawing.Point(232, 25);
            this.tbPsw.Name = "tbPsw";
            this.tbPsw.Size = new System.Drawing.Size(80, 20);
            this.tbPsw.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(332, 24);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(70, 59);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "开始";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tbTable
            // 
            this.tbTable.Location = new System.Drawing.Point(139, 63);
            this.tbTable.Name = "tbTable";
            this.tbTable.Size = new System.Drawing.Size(97, 20);
            this.tbTable.TabIndex = 0;
            this.tbTable.Text = "table name";
            // 
            // tbDb
            // 
            this.tbDb.Location = new System.Drawing.Point(12, 63);
            this.tbDb.Name = "tbDb";
            this.tbDb.Size = new System.Drawing.Size(105, 20);
            this.tbDb.TabIndex = 0;
            this.tbDb.Text = "database name";
            // 
            // rtbInfo
            // 
            this.rtbInfo.Location = new System.Drawing.Point(12, 108);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(390, 240);
            this.rtbInfo.TabIndex = 2;
            this.rtbInfo.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 360);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.tbDb);
            this.Controls.Add(this.tbTable);
            this.Controls.Add(this.tbPsw);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbSrc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "小小爬虫";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSrc;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPsw;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox tbTable;
        private System.Windows.Forms.TextBox tbDb;
        private System.Windows.Forms.RichTextBox rtbInfo;
    }
}

