using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Service
     * 文件名：  SerialPortServer
     * 版本号：  V1.0.0.0
     * 唯一标识：0648c946-1eba-4861-a3d9-23f504361a35
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/20 11:31:31
     * 描述    :
     * =====================================================================
     * 修改时间：2020/10/20 11:31:31
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service
{

    /// <summary>
    /// 串口异常
    /// </summary>
    class SerialPortException : Exception
    {
        public SerialPortException(string message)
            : base(message)
        {
        }
    }

    class SerialPortService
    {

        enum ShowWay
        {
            /// <summary>
            /// 十六进制显示
            /// </summary>
            Hex,
            /// <summary>
            /// 文本显示
            /// </summary>
            Text
        }
        /// <summary>
        /// 串口名键
        /// </summary>
        const string SP_NAME_SETTING = "SP_NAME";
        /// <summary>
        /// 校验位选择键
        /// </summary>
        const string SP_PARITY_SETTING = "SP_PARITY";
        /// <summary>
        /// 波特率选择键
        /// </summary>
        const string SP_BAUD_SETTING = "SP_BAUD";
        /// <summary>
        /// 停止位选择键
        /// </summary>
        const string SP_STOP_BIT_SETTING = "SP_STOP_BIT";
        /// <summary>
        /// 显示方式键
        /// </summary>
        const string SP_SHOW_WAY_SETTING = "SP_SHOW_WAY";
        /// <summary>
        /// 是否显示键
        /// </summary>
        const string SP_SHOW_SETTING = "SP_SHOW";
        /// <summary>
        /// 是否换行键
        /// </summary>
        const string SP_CR_SETTING = "SP_CR";
        /// <summary>
        /// 输入框文本键
        /// </summary>
        const string SP_TEXT_SETTING = "SP_TEXT";
#if DEBUG
        bool isDebug = MainForm.debug;
#endif
        ///串口对象
        private System.IO.Ports.SerialPort m_SP;
        //当前连接的串口名
        private string currentSPName = null;
        //校验位选项
        private string[] strOptionCheckoutBit = { "无校验", "奇校验", "偶校验", "1 校验", "0 校验" };
        //停止位选项
        private string[] strOptionStopBit = { "1位", "1.5位", "2位" };
        //串口选项
        private string[] strOptionSerialPortName;

        //一些下拉列表
        private ComboBox cbSP, cbBaud, cbCheckoutBit, cbStopBit;
        //统计框
        private TextBox tbRxCount, tbTxCount;
        //状态标签
        private Label lbSta;
        //打开按钮，发送按钮
        private Button btnOpen, btnSend;
        //统计
        private ulong rxCount = 0, txCount = 0;
        //显示方式
        private RadioButton rbHex;

        private bool isShowHex = true;
        private bool isOpenSerial = false;
        //换行
        private CheckBox cbChangeLine;
        /// <summary>
        /// 是否显示串口信息
        /// </summary>
        CheckBox cbSPShow;

        TextBox tbSerialPortSend;
        RichTextBox rtbSerialPortShow;

        Button btnResetCount;

        RadioButton rbText;

        //可用串口名
        string[] eableSerialPort;

        /// <summary>
        /// 构造函数，新建串口
        /// </summary>
        internal SerialPortService()
        {
            m_SP = new System.IO.Ports.SerialPort();
        }

        /// <summary>
        /// 初始化串口界面
        /// </summary>
        /// <param name="cbSP">串口选择下拉框</param>
        /// <param name="cbBaud">波特率选择下拉框</param>
        /// <param name="cbCheckoutBit">检验位选择下拉框</param>
        /// <param name="cbStopBit">停止位选择下拉框</param>
        /// <param name="tbSendCount">发送统计输入框</param>
        /// <param name="tbReceviceCount">接收统计输入框</param>
        /// <param name="lbSta">串口状态信息文本</param>
        /// <param name="btnOpen">串口打开、关闭按钮</param>
        /// <param name="btnSend">串口发送按钮</param>
        /// <param name="rbHex">串口数据十六进制选择单选框</param>
        /// <param name="cbChangeLine">串口发送数据是否加换行</param>
        /// <param name="cbSPShow">串口消息是否显示</param>
        /// <param name="tbSerialPortSend">串口发送信息文本框</param>
        /// <param name="rtbSerialPortShow">串口显示数据的地方</param>
        /// <param name="btnResetCount">清零按钮</param>
        internal void InitView(ComboBox cbSP, ComboBox cbBaud, ComboBox cbCheckoutBit, ComboBox cbStopBit, TextBox tbSendCount, TextBox tbReceviceCount, Label lbSta, Button btnOpen, Button btnSend, RadioButton rbHex, CheckBox cbChangeLine, CheckBox cbSPShow, TextBox tbSerialPortSend, RichTextBox rtbSerialPortShow, Button btnResetCount, RadioButton rbText)
        {
            //获取相关组件
            this.cbSP = cbSP;
            this.cbBaud = cbBaud;
            this.cbCheckoutBit = cbCheckoutBit;
            this.cbStopBit = cbStopBit;

            this.tbRxCount = tbReceviceCount;
            this.tbTxCount = tbSendCount;

            this.lbSta = lbSta;

            this.btnOpen = btnOpen;
            this.btnSend = btnSend;
            this.btnResetCount = btnResetCount;
            this.rbHex = rbHex;
            this.cbChangeLine = cbChangeLine;
            this.cbSPShow = cbSPShow;

            this.tbSerialPortSend = tbSerialPortSend;
            this.rtbSerialPortShow = rtbSerialPortShow;
            this.rbText = rbText;

            //默认关闭发送按钮
            btnSend.Enabled = false;

            //获取可用端口列表
            RefreshUsableSP();

            //初始化检验位选择
            cbCheckoutBit.Items.AddRange(strOptionCheckoutBit);
            cbCheckoutBit.SelectedIndex = 0;

            //初始化停止位选择
            cbStopBit.Items.AddRange(strOptionStopBit);
            cbStopBit.SelectedIndex = 0;

            //这里可以直接改动文本是因为这个函数是由UI主程序调用的
            cbBaud.Text = "115200";


            UpdateConfig();


            this.rbHex.CheckedChanged += new System.EventHandler(this.rbHex_CheckedChanged);
            cbSP.TextChanged += new System.EventHandler(this.Text_Changed);
            cbBaud.TextChanged += new System.EventHandler(this.Text_Changed);
            cbStopBit.TextChanged += new System.EventHandler(this.Text_Changed);
            cbCheckoutBit.TextChanged += new System.EventHandler(this.Text_Changed);

            this.btnOpen.Click += Btn_Click;
            this.btnSend.Click += Btn_Click;
            this.btnResetCount.Click += Btn_Click;

            rtbSerialPortShow.TextChanged += TextBox_TextChanged;
            tbSerialPortSend.TextChanged += TextBox_TextChanged;


            cbSPShow.Click += Choose_Click;
            rbHex.Click += Choose_Click;
            rbText.Click += Choose_Click;
            cbChangeLine.Click += Choose_Click;

        }

        private void Choose_Click(object sender, EventArgs e)
        {
            if(sender == cbSPShow)
            {
                ConfigurationHelper.updateSetting(SP_SHOW_SETTING, cbSPShow.Checked.ToString());
            }
            else if(sender == rbText)
            {
                ConfigurationHelper.updateSetting(SP_SHOW_WAY_SETTING, ShowWay.Text.ToString());
            }
            else if (sender == rbHex)
            {
                ConfigurationHelper.updateSetting(SP_SHOW_WAY_SETTING, ShowWay.Hex.ToString());
            }
            else if (sender == cbChangeLine)
            {
                ConfigurationHelper.updateSetting(SP_CR_SETTING, cbChangeLine.Checked.ToString());
            }
        }




        /// <summary>
        /// 文本改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender == tbSerialPortSend)
            {
                ConfigurationHelper.updateSetting(SP_TEXT_SETTING, tbSerialPortSend.Text);
            }
            else if (sender == rtbSerialPortShow)
            {
                // 实现自动下拉
                rtbSerialPortShow.SelectionStart = rtbSerialPortShow.Text.Length;
                rtbSerialPortShow.ScrollToCaret();
            }
        }

        void Btn_Click(object sender, EventArgs e)
        {
            if (sender == this.btnOpen)//打开、关闭串口
            {
                SwitchSPProt();
            }
            else if (sender == this.btnSend)//发送信息到串口
            {
                SendDataToSP();
            }
            else if (sender == this.btnResetCount)//串口清零
            {
                ResetByteCount();
            }
        }
        /// <summary>
        /// 切换串口打开、关闭的状态
        /// </summary>
        void SwitchSPProt()
        {
            if (IsSpOpen())
            {
                CloseCurrentPort();
            }
            else
            {
                try
                {
                    OpenCurrentPort();
                }
                catch (Exception ex)
                {
                    btnOpen.Text = "打开串口";
                    MessageBox.Show("打开串口过程中出现错误！请检查设置！\n" + ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// 刷新可用串口，一般在硬件改动时执行，被窗口类在监听到硬件改动时调用
        /// </summary>
        internal void RefreshUsableSP()
        {
            //清除原有选项并且设置不可用以避免误操作
            cbSP.Enabled = false;
            cbSP.Items.Clear();
            cbSP.DropDownStyle = ComboBoxStyle.DropDownList;
            //获取可用端口列表
            eableSerialPort = DetectionSerialPort();

            if(eableSerialPort == null||eableSerialPort.Count() == 0)
            {
                currentSPName = "";
                cbSP.Enabled = false;
                cbSP.DropDownStyle = ComboBoxStyle.DropDown;
                cbSP.Text = "不可用";
                return;
            }

            //如果已经选择了串口
            if (currentSPName != null)
            {
                for (int i = 0; i < eableSerialPort.Length; i++)
                {
                    //如果选择的串口没有拔出
                    if (currentSPName.Equals(eableSerialPort[i]))
                    {
                        cbSP.Items.AddRange(eableSerialPort);
                        strOptionSerialPortName = eableSerialPort;
                        cbSP.SelectedIndex = i;
                        cbSP.Enabled = true;
                        currentSPName = eableSerialPort[i];
                        return;
                    }
                }
            }

            //如果串口被拔出或者没有选择串口

#if DEBUG
                DebugLog("串口被拔出！");
#endif 
            cbSP.Items.AddRange(eableSerialPort);
            strOptionSerialPortName = eableSerialPort;
            cbSP.SelectedIndex = 0;
            currentSPName = eableSerialPort[0];
            cbSP.Enabled = true;

            //关闭串口
            CloseCurrentPort();
        }
        /// <summary>
        /// 扫描可用串口
        /// </summary>
        /// <returns>可用串口名</returns>
        private string[] DetectionSerialPort()
        {
            string[] serialPortList = System.IO.Ports.SerialPort.GetPortNames();


#if DEBUG
                DebugLog("当前可用串口：");
                foreach (string str in serialPortList)
                {
                    DebugLog(str);
                }
#endif 

            return serialPortList;
        }
        /// <summary>
        /// 打开串口调用程序
        /// </summary>
        internal void OpenCurrentPort()
        {
            try
            {
                lbSta.Text = "正在打开串口";

#if DEBUG
                    DebugLog("正在打开串口！");
#endif 
                m_SP = new System.IO.Ports.SerialPort();
                if (!SetSerialPortName(m_SP))
                {
                    lbSta.Text = "串口名错误";
                    throw new SerialPortException("串口名称异常！");
                }
                if (!SetSerialPortBaud(m_SP))
                {
                    lbSta.Text = "波特率错误";
                    throw new SerialPortException("串口波特率异常！");
                }
                if (!SetCheckoutBit(m_SP))
                {
                    lbSta.Text = "校验位错误";
                    throw new SerialPortException("串口校验位异常！");
                }
                if (!SetStopBit(m_SP))
                {
                    lbSta.Text = "停止位错误";
                    throw new SerialPortException("串口停止位异常！");
                }
                if (!SetDataBit(m_SP))
                {
                    lbSta.Text = "数据位错误";
                    throw new SerialPortException("串口数据位异常！");
                }

                //打开串口
                m_SP.Open();

                if (m_SP.IsOpen)
                {
                    isOpenSerial = true;
                    //添加消息函数
                    m_SP.DataReceived += new SerialDataReceivedEventHandler(ReceviceDataSP);
                    lbSta.Text = "串口已打开";
                    //禁止变更串口
                    cbSP.Enabled = false;
                    btnSend.Enabled = true;

#if DEBUG
                        DebugLog("->串口已打开");
#endif 
                    btnOpen.Text = "关闭串口";
                }
            }
            catch (Exception e)
            {
                lbSta.Text = "打开串口失败";

#if DEBUG
                    DebugLog("->串口打开失败！");
#endif 
                btnOpen.Text = "打开串口";
                isOpenSerial = false;
                throw e;
            }
        }

        public delegate void SerialPortMsgHandler(Byte[] readByte, System.IO.Ports.SerialPort m_SP);
        public event SerialPortMsgHandler SerialPortEventMsg;

        /// <summary>
        /// 接收串口消息处理
        /// </summary>
        /// <param name="sender">消息产生者</param>
        /// <param name="e">事件</param>
        private void ReceviceDataSP(object sender, EventArgs e)
        {

#if DEBUG
                DebugLog("消息：");
#endif 
            if (e is SerialDataReceivedEventArgs)
            {
                if (isOpenSerial)
                {
                    //建立缓冲区
                    Byte[] readByte = new Byte[m_SP.BytesToRead];

                    //写入数据
                    if (isOpenSerial)
                        m_SP.Read(readByte, 0, readByte.Length);

                    //开始处理



#if DEBUG
                        DebugLog("串口收到：" + ToHexStrFromByte(readByte));
#endif 

                    rxCount += (ulong)readByte.Length;

                    if (SerialPortEventMsg != null)
                    {
                        SerialPortEventMsg(readByte, m_SP);
                    }
                    //传递消息
                    //MessageManage.GetMessageManage().SerialPortReceviceData(readByte, m_SP);

                    if (cbSPShow.Checked)
                    {
                        RefreshSPView(readByte, false);//显示到对话框
                    }
                    else
                    {
                        RefreshSPView(null, false);
                    }
                }
            }
        }
        /// <summary>
        /// 修改显示方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbHex_CheckedChanged(object sender, EventArgs e)
        {
            this.isShowHex = this.rbHex.Checked;
        }
        /// <summary>
        /// 字节数组转16进制字符串：空格分隔
        /// </summary>
        /// <param name="byteDatas"></param>
        /// <returns></returns>
        public string ToHexStrFromByte(byte[] byteDatas)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < byteDatas.Length; i++)
            {
                builder.Append(byteDatas[i].ToString("X2"));
                builder.Append(" ");
            }
            return builder.ToString();
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        internal void CloseCurrentPort()
        {
            isOpenSerial = false;
            lbSta.Text = "正在关闭串口";

#if DEBUG
                DebugLog("正在关闭串口！");
#endif 
            //关闭串口
            m_SP.Close();
            if (m_SP.IsOpen == false)
            {
                //启用串口更改
                cbSP.Enabled = true;
                btnSend.Enabled = false;

#if DEBUG
                    DebugLog("->串口已关闭！");
#endif 
                lbSta.Text = "串口已关闭";
                btnOpen.Text = "打开串口";
            }
            else
            {

#if DEBUG
                    DebugLog("->串口关闭失败！");
#endif 
                lbSta.Text = "串口已打开";
                isOpenSerial = true;
            }
        }
        /// <summary>
        /// 查询串口是否打开
        /// </summary>
        /// <returns>是否打开串口</returns>
        public bool IsSpOpen()
        {
            if (m_SP != null)
            {
                if (isOpenSerial)
                {
                    return m_SP.IsOpen;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 下拉列表变动监听事件
        /// </summary>
        /// <param name="sender">下拉事件产生者</param>
        /// <param name="e">事件</param>
        private void Text_Changed(object sender, EventArgs e)
        {
            //监听事件应该是由UI主线程调用的
            if (sender == cbSP)
            {
                SetSerialPortName(m_SP);
            }
            else if (sender == cbBaud)
            {
                SetSerialPortBaud(m_SP);
            }
            else if (sender == cbCheckoutBit)
            {
                SetCheckoutBit(m_SP);
            }
            else if (sender == cbStopBit)
            {
                SetStopBit(m_SP);
            }
        }
        /// <summary>
        /// 发送字符串到串口，不会修改
        /// </summary>
        /// <param name="str">要发送的字符串</param>
        /// <returns>是否成功</returns>
        internal bool SendDataSP(string str)
        {
            return SendDataSP(System.Text.Encoding.UTF8.GetBytes(str));
        }
        /// <summary>
        /// 通过字节数组来发送数据到串口
        /// </summary>
        /// <param name="sendData">发送到串口的字节数组</param>
        /// <returns>发送是否成功</returns>
        internal bool SendDataSP(byte[] sendData)
        {
            if (m_SP != null)
            {
                if (isOpenSerial)
                {
                    if (m_SP.IsOpen)
                    {
                        //向串口写数据
                        m_SP.Write(sendData, 0, sendData.Length);

#if DEBUG
                            DebugLog("串口发送：" + System.Text.Encoding.UTF8.GetString(sendData));
#endif 
                        //统计
                        txCount += (ulong)sendData.Length;
                        RefreshSPView(sendData, true);

                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 发送一个字符串行到串口
        /// </summary>
        /// <param name="str">要发送的字符串</param>
        /// <returns>成功或者失败</returns>
        internal bool SendLineToSp(string str)
        {
            Byte[] lineByte = System.Text.Encoding.UTF8.GetBytes(str);
            //如果直接有结尾了
            if ((lineByte[lineByte.Length - 1] == 0x0A) && (lineByte[lineByte.Length - 2] == 0x0D))
            {
                //直接发送
                return SendDataSP(lineByte);
            }

            //转换成列表
            List<Byte> line = lineByte.ToList();

            //添加换行回车
            line.Add(0x0A);
            line.Add(0x0D);

            //发送
            return SendDataSP(line.ToArray());
        }
        /// <summary>
        /// 更新统计、接收、发送等串口信息
        /// </summary>
        /// <param name="msg">接收/发送的消息</param>
        /// <param name="isSend">类型是否为发送</param>
        private void RefreshSPView(byte[] msgs, bool isSend)
        {
            string str = "";

            if (msgs != null)
            {
                //打印和统计
                if (!this.isShowHex)
                {
                    str = System.Text.Encoding.UTF8.GetString(msgs);
                }
                else
                {
                    str = ToHexStrFromByte(msgs);
                }
            }

            if (cbSPShow.Checked)
            {

#if DEBUG
                    DebugLog("刷新计数和文本");
#endif 
                MainForm.GetMainWindow().RefreshSPView(txCount, rxCount, str, isSend, true);
            }
            else
            {

#if DEBUG
                    DebugLog("刷新计数");
#endif 
                RefreshByteCount();
            }
        }
        /// <summary>
        /// 根据计数刷新统计控件
        /// </summary>
        private void RefreshByteCount()
        {
            MainForm.GetMainWindow().RefreshSPView(txCount, rxCount, null, false, false);
        }
        /// <summary>
        /// 根据下拉框选择校验位
        /// </summary>
        /// <param name="sp">要设置的串口对象</param>
        /// <returns>是否成功</returns>
        private bool SetCheckoutBit(System.IO.Ports.SerialPort sp)
        {
            if (sp == null) return false;

#if DEBUG
                DebugLog("校验位：");
#endif 
            /*获取选项*/
            string option = cbCheckoutBit.Text;
            bool isOk = false;

            int sel = 0;

            /*匹配选项*/
            for (int i = 0; i < strOptionCheckoutBit.Length; i++)
            {
                /*如果匹配到选项*/
                if (option.Equals(strOptionCheckoutBit[i]))
                {
                    /*设置串口*/
                    switch (i)
                    {
                        /*无校验*/
                        case 0:

#if DEBUG
                                DebugLog("->" + strOptionCheckoutBit[0]);
#endif 
                            sp.Parity = Parity.None;
                            isOk = true;
                            sel = i;
                            break;

                        /*奇校验*/
                        case 1:

#if DEBUG
                                DebugLog("->" + strOptionCheckoutBit[1]);
#endif 
                            sp.Parity = Parity.Odd;
                            isOk = true;
                            sel = i;
                            break;

                        /*偶校验*/
                        case 2:

#if DEBUG
                                DebugLog("->" + strOptionCheckoutBit[2]);
#endif 
                            sp.Parity = Parity.Even;
                            isOk = true;
                            sel = i;
                            break;

                        /*1校验*/
                        case 3:

#if DEBUG
                                DebugLog("->" + strOptionCheckoutBit[3]);
#endif 
                            sp.Parity = Parity.Mark;
                            isOk = true;
                            sel = i;
                            break;

                        /*0校验*/
                        case 4:

#if DEBUG
                                DebugLog("->" + strOptionCheckoutBit[4]);
#endif 
                            sp.Parity = Parity.Space;
                            isOk = true;
                            sel = i;
                            break;
                    }
                }
            }

            //更新配置
            ConfigurationHelper.updateSetting(SP_PARITY_SETTING, strOptionCheckoutBit[sel]);

#if DEBUG
                DebugLog("->" + "出现错误，检验位默认！");
#endif 
            return isOk;
        }
        /// <summary>
        /// 根据下拉框选择停止位
        /// </summary>
        /// <param name="sp">要设置的串口</param>
        /// <returns>是否成功</returns>
        private bool SetStopBit(System.IO.Ports.SerialPort sp)
        {
            if (sp == null) return false;


#if DEBUG
                DebugLog("停止位：");
#endif 
            /*获取选项*/
            string option = cbStopBit.Text;
            bool isOk = false;
            int sel = 0;

            /*匹配选项*/
            for (int i= 0; i < strOptionStopBit.Length; i++)
            {
                /*如果匹配到选项*/
                if (option.Equals(strOptionStopBit[i]))
                {
                    /*设置串口*/
                    switch (i)
                    {
                        /*1停止位*/
                        case 0:

#if DEBUG
                                DebugLog("->" + strOptionStopBit[0]);
#endif 
                            sp.StopBits = StopBits.One;
                            isOk = true;
                            sel = i;
                            break;

                        /*1.5停止位*/
                        case 1:

#if DEBUG
                                DebugLog("->" + strOptionStopBit[1]);
#endif 
                            sp.StopBits = StopBits.OnePointFive;
                            isOk = true;
                            sel = i;
                            break;

                        /*2停止位*/
                        case 2:

#if DEBUG
                                DebugLog("->" + strOptionStopBit[2]);
#endif
                            sp.StopBits = StopBits.Two;
                            isOk = true;
                            sel = i;
                            break;
                    }
                }
            }

            //更新配置
            ConfigurationHelper.updateSetting(SP_STOP_BIT_SETTING, strOptionStopBit[sel]);
#if DEBUG
                DebugLog("->" + "出现错误，停止位默认！");
#endif
            return isOk;
        }
        /// <summary>
        /// 根据下拉列表选择串口
        /// </summary>
        /// <param name="sp">要设置的串口</param>
        private bool SetSerialPortName(System.IO.Ports.SerialPort sp)
        {
            if (sp == null) return false;

#if DEBUG
                DebugLog("串口名：");
#endif 
            if (!sp.IsOpen)
            {
                //端口打开时无法设置串口
                sp.PortName = strOptionSerialPortName[cbSP.SelectedIndex];
            }
            currentSPName = sp.PortName;

#if DEBUG
                DebugLog("->" + strOptionSerialPortName[cbSP.SelectedIndex]);
#endif

            //更新配置
            ConfigurationHelper.updateSetting(SP_NAME_SETTING, currentSPName);

            return true;
        }
        /// <summary>
        /// 根据下拉列表设置波特率
        /// </summary>
        /// <param name="sp">要设置的串口对象</param>
        /// <returns>是否成功</returns>
        private bool SetSerialPortBaud(System.IO.Ports.SerialPort sp)
        {
            bool isOk = false;
            if (sp == null) return isOk;

#if DEBUG
                DebugLog("波特率：");
#endif 
            int baud = 0;
            try
            {
                baud = int.Parse(cbBaud.Text);
            }
            catch (SystemException e)
            {
                isOk = false;
                throw e;
            }


#if DEBUG
                DebugLog("->" + baud.ToString());
#endif 
            sp.BaudRate = baud;
            isOk = true;

            //更新配置
            ConfigurationHelper.updateSetting(SP_BAUD_SETTING, cbBaud.Text);

            return isOk;
        }
        /// <summary>
        /// 设置串口数据位
        /// </summary>
        /// <param name="sp">要设置的串口</param>
        private bool SetDataBit(System.IO.Ports.SerialPort sp)
        {
            if (sp == null) return false;

#if DEBUG
                DebugLog("数据位：");
#endif 
            int dataBit = 8;
            sp.DataBits = dataBit;

#if DEBUG
                DebugLog("->" + dataBit.ToString());
#endif 
            return true;
        }
        /// <summary>
        /// 重置接收/发送计数并刷新控件
        /// </summary>
        internal void ResetByteCount()
        {

#if DEBUG
                DebugLog("重置计数控件！");
#endif 
            txCount = 0;
            rxCount = 0;
            RefreshByteCount();
        }
        /// <summary>
        /// 控制台打印数据
        /// </summary>
        /// <param name="str">要打印到控制台的字符</param>
        private void DebugLog(string str)
        {
            Console.WriteLine(str);
        }

        /// <summary>
        /// 串口“发送“按钮点击事件
        /// </summary>
        private void SendDataToSP()
        {
            //如果串口打开
            if (IsSpOpen())
            {
                //获取文本
                string sendText = tbSerialPortSend.Text;

                //如果文本不为空
                if (!sendText.Equals(""))
                {
                    if (cbChangeLine.Checked)
                    {
                        //添加换行回车发送到串口
                        SendDataSP(sendText + "\r\n");
                    }
                    else
                    {
                        SendDataSP(sendText);
                    }
                }
            }
        }


        internal void Close()
        {
            isOpenSerial = false;
            m_SP.Close();
        }

        /// <summary>
        /// 更新配置
        /// </summary>
        private void UpdateConfig()
        {
            string val;

            //输入框
            val = ConfigurationHelper.getSetting(SP_TEXT_SETTING);
            if (val != null)
            {
                tbSerialPortSend.Text = val;
            }

            //串口名
            val = ConfigurationHelper.getSetting(SP_NAME_SETTING);
            if (eableSerialPort != null && val != null)
            {
                foreach (string v in eableSerialPort)
                {
                    if (v.Equals(val))
                    {
                        cbSP.Text = v;
                    }
                }
            }

            //校验位
            val = ConfigurationHelper.getSetting(SP_PARITY_SETTING);
            if (strOptionCheckoutBit != null && val != null)
            {
                foreach (string v in strOptionCheckoutBit)
                {
                    if (v.Equals(val))
                    {
                        cbCheckoutBit.Text = v;
                    }
                }
            }

            //波特率
            val = ConfigurationHelper.getSetting(SP_BAUD_SETTING);
            if (val != null)
            {
                int b;
                if (int.TryParse(val, out b))
                {
                    if (b > 0)
                    {
                        cbBaud.Text = val;
                    }
                }
            }

            //停止位
            val = ConfigurationHelper.getSetting(SP_STOP_BIT_SETTING);
            if (strOptionStopBit != null && val != null)
            {
                foreach (string v in strOptionStopBit)
                {
                    if (v.Equals(val))
                    {
                        cbStopBit.Text = v;
                    }
                }
            }

            //显示方式
            val = ConfigurationHelper.getSetting(SP_SHOW_WAY_SETTING);
            if (val != null)
            {
                if (val.Equals(ShowWay.Hex.ToString()))
                {
                    rbHex.Checked = true;
                    rbText.Checked = false;
                }
                else if (val.Equals(ShowWay.Text.ToString()))
                {
                    rbHex.Checked = false;
                    rbText.Checked = true;
                }
            }

            //显示方式
            val = ConfigurationHelper.getSetting(SP_SHOW_SETTING);
            if (val != null)
            {
                if (val.Equals(true.ToString()))
                {
                    cbSPShow.Checked = true;
                }
                else
                {
                    cbSPShow.Checked = false;
                }
            }

            //是否换行
            val = ConfigurationHelper.getSetting(SP_CR_SETTING);
            if (val != null)
            {
                if (val.Equals(true.ToString()))
                {
                    cbChangeLine.Checked = true;
                }
                else
                {
                    cbChangeLine.Checked = false;
                }
            }
        }

    }
}
