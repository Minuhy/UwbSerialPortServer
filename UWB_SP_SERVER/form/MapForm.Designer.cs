
namespace UWB_SP_TO_SOCKET.form
{
    partial class MapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.ehMain = new System.Windows.Forms.Integration.ElementHost();
            this.uwbMapControl = new UWB_SP_TO_SOCKET.form.UwbMapControl();
            this.SuspendLayout();
            // 
            // ehMain
            // 
            this.ehMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ehMain.Location = new System.Drawing.Point(0, 0);
            this.ehMain.Name = "ehMain";
            this.ehMain.Size = new System.Drawing.Size(800, 450);
            this.ehMain.TabIndex = 0;
            this.ehMain.Child = this.uwbMapControl;
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ehMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地图";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost ehMain;
        private UwbMapControl uwbMapControl;
    }
}