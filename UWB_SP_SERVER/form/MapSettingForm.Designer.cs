
namespace UWB_SP_TO_SOCKET.form
{
    partial class MapSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapSettingForm));
            this.cbA1 = new System.Windows.Forms.CheckBox();
            this.cbA2 = new System.Windows.Forms.CheckBox();
            this.cbA3 = new System.Windows.Forms.CheckBox();
            this.cbT1 = new System.Windows.Forms.CheckBox();
            this.lbTip1 = new System.Windows.Forms.Label();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.lbTip2 = new System.Windows.Forms.Label();
            this.gbSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbA1
            // 
            this.cbA1.AutoSize = true;
            this.cbA1.Location = new System.Drawing.Point(12, 40);
            this.cbA1.Margin = new System.Windows.Forms.Padding(6);
            this.cbA1.Name = "cbA1";
            this.cbA1.Size = new System.Drawing.Size(89, 28);
            this.cbA1.TabIndex = 0;
            this.cbA1.Text = "锚点1";
            this.cbA1.UseVisualStyleBackColor = true;
            // 
            // cbA2
            // 
            this.cbA2.AutoSize = true;
            this.cbA2.Location = new System.Drawing.Point(12, 80);
            this.cbA2.Margin = new System.Windows.Forms.Padding(6);
            this.cbA2.Name = "cbA2";
            this.cbA2.Size = new System.Drawing.Size(89, 28);
            this.cbA2.TabIndex = 1;
            this.cbA2.Text = "锚点2";
            this.cbA2.UseVisualStyleBackColor = true;
            // 
            // cbA3
            // 
            this.cbA3.AutoSize = true;
            this.cbA3.Location = new System.Drawing.Point(12, 120);
            this.cbA3.Margin = new System.Windows.Forms.Padding(6);
            this.cbA3.Name = "cbA3";
            this.cbA3.Size = new System.Drawing.Size(89, 28);
            this.cbA3.TabIndex = 2;
            this.cbA3.Text = "锚点3";
            this.cbA3.UseVisualStyleBackColor = true;
            // 
            // cbT1
            // 
            this.cbT1.AutoSize = true;
            this.cbT1.Location = new System.Drawing.Point(12, 160);
            this.cbT1.Margin = new System.Windows.Forms.Padding(6);
            this.cbT1.Name = "cbT1";
            this.cbT1.Size = new System.Drawing.Size(101, 28);
            this.cbT1.TabIndex = 3;
            this.cbT1.Text = "目标点";
            this.cbT1.UseVisualStyleBackColor = true;
            // 
            // lbTip1
            // 
            this.lbTip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTip1.AutoSize = true;
            this.lbTip1.Location = new System.Drawing.Point(20, 256);
            this.lbTip1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTip1.Name = "lbTip1";
            this.lbTip1.Size = new System.Drawing.Size(154, 24);
            this.lbTip1.TabIndex = 4;
            this.lbTip1.Text = "显示单位为cm";
            // 
            // gbSetting
            // 
            this.gbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSetting.Controls.Add(this.cbA1);
            this.gbSetting.Controls.Add(this.cbA2);
            this.gbSetting.Controls.Add(this.cbT1);
            this.gbSetting.Controls.Add(this.cbA3);
            this.gbSetting.Location = new System.Drawing.Point(24, 24);
            this.gbSetting.Margin = new System.Windows.Forms.Padding(6);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Padding = new System.Windows.Forms.Padding(6);
            this.gbSetting.Size = new System.Drawing.Size(325, 224);
            this.gbSetting.TabIndex = 5;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "显示设置";
            // 
            // lbTip2
            // 
            this.lbTip2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTip2.AutoSize = true;
            this.lbTip2.Location = new System.Drawing.Point(186, 256);
            this.lbTip2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbTip2.Name = "lbTip2";
            this.lbTip2.Size = new System.Drawing.Size(154, 24);
            this.lbTip2.TabIndex = 6;
            this.lbTip2.Text = "一个格子是1m";
            // 
            // MapSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 296);
            this.Controls.Add(this.lbTip2);
            this.Controls.Add(this.gbSetting);
            this.Controls.Add(this.lbTip1);
            this.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 335);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 335);
            this.Name = "MapSettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地图设置";
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbA1;
        private System.Windows.Forms.CheckBox cbA2;
        private System.Windows.Forms.CheckBox cbA3;
        private System.Windows.Forms.CheckBox cbT1;
        private System.Windows.Forms.Label lbTip1;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.Label lbTip2;
    }
}