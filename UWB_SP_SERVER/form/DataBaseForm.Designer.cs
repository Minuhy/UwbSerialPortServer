
namespace UWB_SP_TO_SOCKET.form
{
    partial class DataBaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBaseForm));
            this.lbSaveLocal = new System.Windows.Forms.Label();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.btnChooseFilePath = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.gbHelp = new System.Windows.Forms.GroupBox();
            this.tbTip = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInitDataBase = new System.Windows.Forms.Button();
            this.gbHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSaveLocal
            // 
            this.lbSaveLocal.AutoSize = true;
            this.lbSaveLocal.Location = new System.Drawing.Point(9, 17);
            this.lbSaveLocal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSaveLocal.Name = "lbSaveLocal";
            this.lbSaveLocal.Size = new System.Drawing.Size(88, 16);
            this.lbSaveLocal.TabIndex = 0;
            this.lbSaveLocal.Text = "保存位置：";
            // 
            // tbFilePath
            // 
            this.tbFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFilePath.Location = new System.Drawing.Point(108, 12);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.Size = new System.Drawing.Size(283, 26);
            this.tbFilePath.TabIndex = 1;
            // 
            // btnChooseFilePath
            // 
            this.btnChooseFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseFilePath.Location = new System.Drawing.Point(397, 12);
            this.btnChooseFilePath.Name = "btnChooseFilePath";
            this.btnChooseFilePath.Size = new System.Drawing.Size(75, 26);
            this.btnChooseFilePath.TabIndex = 2;
            this.btnChooseFilePath.Text = "选择";
            this.btnChooseFilePath.UseVisualStyleBackColor = true;
            this.btnChooseFilePath.Click += new System.EventHandler(this.btnChooseFilePath_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(316, 223);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // gbHelp
            // 
            this.gbHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHelp.Controls.Add(this.tbTip);
            this.gbHelp.Location = new System.Drawing.Point(12, 76);
            this.gbHelp.Name = "gbHelp";
            this.gbHelp.Size = new System.Drawing.Size(460, 141);
            this.gbHelp.TabIndex = 4;
            this.gbHelp.TabStop = false;
            this.gbHelp.Text = "说明";
            // 
            // tbTip
            // 
            this.tbTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTip.Font = new System.Drawing.Font("黑体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbTip.Location = new System.Drawing.Point(3, 22);
            this.tbTip.Multiline = true;
            this.tbTip.Name = "tbTip";
            this.tbTip.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTip.Size = new System.Drawing.Size(454, 116);
            this.tbTip.TabIndex = 0;
            this.tbTip.Text = resources.GetString("tbTip.Text");
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(397, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInitDataBase
            // 
            this.btnInitDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInitDataBase.Location = new System.Drawing.Point(12, 44);
            this.btnInitDataBase.Name = "btnInitDataBase";
            this.btnInitDataBase.Size = new System.Drawing.Size(460, 26);
            this.btnInitDataBase.TabIndex = 6;
            this.btnInitDataBase.Text = "重新初始化数据库（另存文件）";
            this.btnInitDataBase.UseVisualStyleBackColor = true;
            this.btnInitDataBase.Click += new System.EventHandler(this.btnInitDataBase_Click);
            // 
            // DataBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.btnInitDataBase);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbHelp);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnChooseFilePath);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.lbSaveLocal);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "DataBaseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库设置";
            this.gbHelp.ResumeLayout(false);
            this.gbHelp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSaveLocal;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Button btnChooseFilePath;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox gbHelp;
        private System.Windows.Forms.TextBox tbTip;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInitDataBase;
    }
}