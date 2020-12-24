using System;
using System.Windows.Forms;
using WinHtmlEditor;

namespace UWB_SP_TO_SOCKET.form
{
    public partial class EditPublic : Form
    {
        public EditPublic(string text)
        {
            InitializeComponent();

            if (text != null)
            {
                heMain.BodyInnerHTML = text;
            }
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            var value = heMain.BodyInnerHTML;
            AnnouncementRes.SetAnnouncement((!value.IsNull()) ? value.Trim() : string.Empty);

#if DEBUG
            Console.WriteLine(heMain.BodyHtml);
#endif
        }

        private void EditPublic_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("数据要保存吗？","退出",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnSaveAll_Click(null,null);
            }
        }
    }
}
