using System;
using System.Drawing;
using System.Windows.Forms;
using UWB_SP_TO_SOCKET.form;
using UWB_SP_TO_SOCKET.src.Service;
using UWB_SP_TO_SOCKET.src.Tools;
#if DEBUG
using System.Runtime.InteropServices;
#endif

namespace UWB_SP_TO_SOCKET
{
    public partial class MainForm : Form
    {

#if DEBUG
        /// <summary>
        /// 是否启用调试
        /// </summary>
        static public bool debug = false;
        /// <summary>
        /// 调试警告信息
        /// </summary>
        public const int DEBUG_W = 1;
        /// <summary>
        /// 调试信息
        /// </summary>
        public const int DEBUG_I = 2;
        /// <summary>
        /// 调试错误信息
        /// </summary>
        public const int DEBUG_E = 3;
        /// <summary>
        /// 调试统计信息
        /// </summary>
        public const int DEBUG_S = 4;
        [DllImport("kernel32.dll")]
        public static extern Boolean AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeConsole();
#endif
        /// <summary>
        /// 对控制台写调试信息
        /// </summary>
        /// <param name="p">输出的字符串</param>
        /// <param name="type">消息类型</param>
        public static void DebugWriteLine(string p, int type)
        {
#if DEBUG
            Console.BackgroundColor = ConsoleColor.Black;
                switch (type)
                {
                    case DEBUG_E://错误
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case DEBUG_W://警告
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case DEBUG_S://统计
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case DEBUG_I://信息
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine(p);
                Console.ForegroundColor = ConsoleColor.White;
#endif
        }

        /// <summary>
        /// 对本类的引用
        /// </summary>
        static MainForm mainForm;
        /// <summary>
        /// 串口服务
        /// </summary>
       SerialPortService m_SerialPortService;
        /// <summary>
        /// TCP服务器
        /// </summary>
        SocketServer m_SocketServer;
        /// <summary>
        /// TWR服务器
        /// </summary>
        TwrServer m_TwrServer;

        public MainForm()
        {
            InitializeComponent();

            mainForm = this;


#if DEBUG
                AllocConsole();
                DebugWriteLine("控制台已打开！\n时间：" + DateTime.Now.ToString(
                        "[yyyy-MM-dd HH:mm:ss.fff] "), DEBUG_I);
#endif

            m_SerialPortService = new SerialPortService();
            m_TwrServer = new TwrServer(m_SerialPortService);
            m_SocketServer = new SocketServer(m_TwrServer);
          
            MessageServer.GetMs().SetTWRServer(m_TwrServer);

            m_SerialPortService.InitView(cbSP, cbBaud, cbCheckoutBit, cbStopBit, tbSendCount, tbReceviceCount, lbSPSta, btnOpenSP, btnSPSend, rbHex, cbChangeLine, cbSPShow, tbSerialPortSend, rtbSerialPortShow, btnResetCount,rbText);
            m_SocketServer.InitView(btnOpenServer, tbServerPort);
            m_TwrServer.InitView(btnBaseChange1, btnBaseChange2, btnBaseChange3, btnBaseChange, tbBasex1, tbBasex2, tbBasex3, tbBasey1, tbBasey2, tbBasey3, tbBasez1, tbBasez2, tbBasez3, cbViData);

        }

        internal static MainForm GetMainWindow()
        {
            return mainForm;
        }

        delegate void RefreshSPViewCallback(ulong txCount, ulong rxCount, string message, bool isSend, bool isHaveMsg);//安全调用
        /// <summary>
        /// 刷新字数统计控件
        /// </summary>
        /// <param name="txCount">发送的字节数</param>
        /// <param name="rxCount">接收的字节数</param>
        internal void RefreshSPView(ulong txCount, ulong rxCount, string message, bool isSend, bool isHaveMsg)
        {
            //处理InvokeRequired，安全调用
            if (this.tbSendCount.InvokeRequired && tbReceviceCount.InvokeRequired && rtbSerialPortShow.InvokeRequired)
            {
                RefreshSPViewCallback d = new RefreshSPViewCallback(RefreshSPView);
                this.BeginInvoke(d, new object[] { txCount, rxCount, message, isSend, isHaveMsg });
            }
            else
            {
                tbSendCount.Text = ByteAutoSize.GetSize(txCount);
                tbReceviceCount.Text = ByteAutoSize.GetSize(rxCount);

                if (isHaveMsg)
                {
                    if (rtbSerialPortShow.IsDisposed)
                    {
                        return;
                    }

                    if (rtbSerialPortShow != null)
                    {
                        if (isSend)
                        {
                            this.rtbSerialPortShow.SelectionColor = Color.Black;
                            this.rtbSerialPortShow.AppendText(message);
                        }
                        else
                        {
                            this.rtbSerialPortShow.SelectionColor = Color.Red;
                            this.rtbSerialPortShow.AppendText(message);
                        }
                    }
                }
            }
        }

        private void btnTestWindow_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_SerialPortService.Close();
            m_TwrServer.Close();
            m_SocketServer.Close();
#if DEBUG
            FreeConsole();
#endif
            Application.Exit();
            Application.ExitThread();
            System.Environment.Exit(0);
        }

        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == 0x219)
                {
                    m_SerialPortService.RefreshUsableSP();
                    Console.WriteLine("硬件改动！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// 实现自动下拉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rtbSerialPortShow_TextChanged(object sender, EventArgs e)
        {
            rtbSerialPortShow.SelectionStart = rtbSerialPortShow.Text.Length;
            rtbSerialPortShow.ScrollToCaret();
        }

        private void btnEditPublic_Click(object sender, EventArgs e)
        {
            Form epForm = new EditPublic(AnnouncementRes.GetAnnouncement());
            epForm.ShowDialog();
        }
    }
}
