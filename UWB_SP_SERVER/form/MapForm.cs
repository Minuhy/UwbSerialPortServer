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
    public partial class MapForm : Form
    {
        public MapForm(MainForm mainForm)
        {
            InitializeComponent();

            mainForm.MapDataChangeEvent += MainForm_MapDataChangeEvent;
        }

        private void MainForm_MapDataChangeEvent(src.Model.MapModel mm)
        {

            //MessageBox.Show("ok，id:" + mm.id + ",x:" + mm.x + ",y:" + mm.y + ",tag:" + mm.isTag); ;
            uwbMapControl.Dispatcher.BeginInvoke((Action)delegate {
                if (mm.isTag)
                {
                    if (mm.id == 5)
                    {
                        uwbMapControl.SetTag1(mm.x, mm.y);
                    }
                }
                else
                {
                    if (mm.id == 1)
                    {
                        uwbMapControl.SetAnchor1(mm.x * 100, mm.y * 100);
                    }
                    else if (mm.id == 2)
                    {
                        uwbMapControl.SetAnchor2(mm.x * 100, mm.y * 100);
                    }
                    else if (mm.id == 3)
                    {
                        uwbMapControl.SetAnchor3(mm.x * 100, mm.y * 100);
                    }
                }
            });
        }

        public bool IsClose { get; internal set; }

        private void MapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            IsClose = true;
        }
    }
}
