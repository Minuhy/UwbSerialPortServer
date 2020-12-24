using System;
using System.Windows.Forms;
using UWB_SP_TO_SOCKET.src.Service.Server;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Service
     * 文件名：  SocketServer
     * 版本号：  V1.0.0.0
     * 唯一标识：9828cfab-9f6e-4260-8a1c-efbcccd6a9f4
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/20 21:50:43
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/20 21:50:43
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service
{
    /// <summary>
    /// 数据服务器
    /// </summary>
    class SocketServer
    {

#if DEBUG
        public static bool isDebug = MainForm.debug;
#endif
        /// <summary>
        /// TCP端口
        /// </summary>
        public int tcpPort = 0;
        //打开服务器按钮
        private Button btnOpenServer;
        //服务器端口文本编辑框
        private TextBox tbServerPort;


        private TwrServer m_TwrServer;
        /// <summary>
        /// SuperSocket对象
        /// </summary>
        private DataServer dataServer;

        bool isRun = false;
        /// <summary>
        /// 端口键
        /// </summary>
        const string SERVER_PORT = "SERVER_PORT";

        public SocketServer(TwrServer m_TwrServer)
        {
            this.m_TwrServer = m_TwrServer;
        }

        /// <summary>
        /// 初始化服务器界面
        /// </summary>
        /// <param name="cbIPAddress">IP地址下拉列表</param>
        /// <param name="btnOpenServer">打开服务器按钮</param>
        /// <param name="tbServerPort">服务器端口编辑框</param>
        /// <param name="lbServerSta">服务器状态标签</param>
        /// <param name="dgvClientManage">管理列表</param>
        internal void InitView(Button btnOpenServer, TextBox tbServerPort)
        {
            this.btnOpenServer = btnOpenServer;
            this.tbServerPort = tbServerPort;

            btnOpenServer.Click += btnOpenServer_Click;

            //波特率
            string val = ConfigurationHelper.getSetting(SERVER_PORT);
            if (val != null)
            {
                int b;
                if (int.TryParse(val, out b))
                {
                    if (b > 0&&b<65535)
                    {
                        tbServerPort.Text = val;
                    }
                }
            }


        }

        void btnOpenServer_Click(object sender, EventArgs e)
        {
            btnOpenServer.Enabled = false;

            if (isRun)
            {
                if (CloseServer())
                {
                    btnOpenServer.Text = "打开服务器";
                    isRun = false;
                }
            }
            else
            {
                if (OpenServer())
                {
                    btnOpenServer.Text = "关闭服务器";
                    isRun = true;
                }
            }

            btnOpenServer.Enabled = true;
        }

        private bool CloseServer()
        {
            if (dataServer == null)
            {
                return true;
            }

            dataServer.Stop();
            return true;
        }

        private bool OpenServer()
        {
            tbServerPort.ReadOnly = true;

            dataServer = new DataServer();
            tcpPort = GetIntByString(tbServerPort.Text);

            if (tcpPort < 0 || tcpPort > 65535)
            {

#if DEBUG
                    Console.WriteLine("端口不对，端口："+tcpPort);
#endif 
                MessageBox.Show("端口号格式错误！");
                return false;
            }

            //更新端口配置
            ConfigurationHelper.updateSetting(SERVER_PORT, tcpPort.ToString());

            if (!dataServer.Setup(tcpPort))
            {

#if DEBUG
                    Console.WriteLine("初始化失败");
#endif 
                MessageBox.Show("服务器初始化失败，请检查监听端口！");
                return false;
            }

            if (!dataServer.Start())
            {

#if DEBUG
                    Console.WriteLine("服务器打开失败");
#endif 
                MessageBox.Show("服务器打开失败！");
                return false;
            }

            tbServerPort.ReadOnly = false;

            return true;
        }

        private int GetIntByString(string str)
        {
            if (str == null)
            {
                return -1;
            }

            if (str == "")
            {
                return -1;
            }

            try
            {
                return int.Parse(str);
            }
            catch (Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 打印控制台
        /// </summary>
        /// <param name="str">打印到控制台的信息</param>
        private void Debug(string str)
        {
            Console.WriteLine(str);
        }

        internal void Close()
        {
            CloseServer();
        }
    }
}
