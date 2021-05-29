using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UWB_SP_TO_SOCKET.src.Service;

namespace UWB_SP_TO_SOCKET.form
{
    public partial class DataBaseForm : Form
    {
        DataBaseServer server;
        public DataBaseForm()
        {
            InitializeComponent();
            server = DataBaseServer.GetInstance();

            if (!server.IsInit)
            {
                if (!server.InitDataBase())
                {
                    MessageBox.Show("数据库未初始化", "错误");
                    // this.Close();
                }
            }

            if (server.IsInit)
            { this.tbFilePath.Text = server.FileName; }
        }

        private void btnChooseFilePath_Click(object sender, EventArgs e)
        {
            if (server.FileName == null || server.FileName.Equals(""))
            {
                MessageBox.Show("数据库文件不存在！\n可能是未初始化。","提示");
            }
            else { System.Diagnostics.Process.Start("explorer.exe", "/select," + server.FileName); }
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInitDataBase_Click(object sender, EventArgs e)
        {
            if (server.InitDataBase())
            {
                MessageBox.Show("重新初始化数据库成功！","提示");
            }
            else
            {
                MessageBox.Show("重新初始化数据库失败！", "提示");
            }

            this.tbFilePath.Text = server.FileName;
        }
    }
}
