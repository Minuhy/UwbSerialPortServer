using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UWB_SP_TO_SOCKET.form
{
    public partial class MapSettingForm : Form
    {
        UwbMapControl uwbMapControl;
        
        public MapSettingForm(UwbMapControl uwbMapControl)
        {
            InitializeComponent();

            cbA1.Checked = uwbMapControl.IsShowAnchor1;
            cbA2.Checked = uwbMapControl.IsShowAnchor2;
            cbA3.Checked = uwbMapControl.IsShowAnchor3;

            cbT1.Checked = uwbMapControl.IsShowTag1;


            cbA1.Click += Cb_Click;
            cbA2.Click += Cb_Click;
            cbA3.Click += Cb_Click;
            cbT1.Click += Cb_Click;

            this.uwbMapControl = uwbMapControl;
        }

        private void Cb_Click(object sender, EventArgs e)
        {
            cbA1.Click += Cb_Click;
            if (sender == cbA2)
            {
                uwbMapControl.IsShowAnchor2 = cbA2.Checked;

            }
            else
            if (sender == cbA3)
            {

                uwbMapControl.IsShowAnchor3 = cbA3.Checked;
            }
            else
            if (sender == cbT1)
            {
                uwbMapControl.IsShowTag1 = cbT1.Checked;
            }
            else
            if (sender == cbA1)
            {
                uwbMapControl.IsShowAnchor1 = cbA1.Checked;
            }
        }

    }
}
