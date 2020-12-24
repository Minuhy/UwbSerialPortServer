
namespace UWB_SP_TO_SOCKET.form
{
    partial class EditPublic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPublic));
            this.heMain = new WinHtmlEditor.HtmlEditor();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // heMain
            // 
            this.heMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.heMain.BodyInnerHTML = null;
            this.heMain.BodyInnerText = null;
            this.heMain.EnterToBR = false;
            this.heMain.FontSize = WinHtmlEditor.FontSize.Three;
            this.heMain.Location = new System.Drawing.Point(13, 12);
            this.heMain.Name = "heMain";
            this.heMain.ShowStatusBar = true;
            this.heMain.ShowToolBar = true;
            this.heMain.ShowWb = true;
            this.heMain.Size = new System.Drawing.Size(1239, 708);
            this.heMain.TabIndex = 0;
            this.heMain.WebBrowserShortcutsEnabled = true;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAll.Location = new System.Drawing.Point(13, 726);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(1239, 23);
            this.btnSaveAll.TabIndex = 1;
            this.btnSaveAll.Text = "保存";
            this.btnSaveAll.UseVisualStyleBackColor = true;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // EditPublic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.heMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditPublic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑公告";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditPublic_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private WinHtmlEditor.HtmlEditor heMain;
        private System.Windows.Forms.Button btnSaveAll;
    }
}