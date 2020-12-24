namespace UWB_SP_TO_SOCKET
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gbSP = new System.Windows.Forms.GroupBox();
            this.pnlSPSetting = new System.Windows.Forms.Panel();
            this.cbStopBit = new System.Windows.Forms.ComboBox();
            this.cbCheckoutBit = new System.Windows.Forms.ComboBox();
            this.lbStopBit = new System.Windows.Forms.Label();
            this.tbReceviceCount = new System.Windows.Forms.TextBox();
            this.tbSendCount = new System.Windows.Forms.TextBox();
            this.lbReceiveCount = new System.Windows.Forms.Label();
            this.btnResetCount = new System.Windows.Forms.Button();
            this.lbSPSta = new System.Windows.Forms.Label();
            this.lbSendCount = new System.Windows.Forms.Label();
            this.btnOpenSP = new System.Windows.Forms.Button();
            this.lbCheckoutBit = new System.Windows.Forms.Label();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.lbBaud = new System.Windows.Forms.Label();
            this.lbSP = new System.Windows.Forms.Label();
            this.cbSP = new System.Windows.Forms.ComboBox();
            this.gbSerialPortShow = new System.Windows.Forms.GroupBox();
            this.cbSPShow = new System.Windows.Forms.CheckBox();
            this.cbChangeLine = new System.Windows.Forms.CheckBox();
            this.lbSPShowType = new System.Windows.Forms.Label();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbHex = new System.Windows.Forms.RadioButton();
            this.btnSPSend = new System.Windows.Forms.Button();
            this.tbSerialPortSend = new System.Windows.Forms.TextBox();
            this.rtbSerialPortShow = new System.Windows.Forms.RichTextBox();
            this.gbServerState = new System.Windows.Forms.GroupBox();
            this.cbViData = new System.Windows.Forms.CheckBox();
            this.btnTestWindow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.tbBasex1 = new System.Windows.Forms.TextBox();
            this.gbBaseSet = new System.Windows.Forms.GroupBox();
            this.btnBaseChange = new System.Windows.Forms.Button();
            this.btnBaseChange3 = new System.Windows.Forms.Button();
            this.btnBaseChange2 = new System.Windows.Forms.Button();
            this.btnBaseChange1 = new System.Windows.Forms.Button();
            this.lbBasez3 = new System.Windows.Forms.Label();
            this.tbBasez3 = new System.Windows.Forms.TextBox();
            this.lbBasey3 = new System.Windows.Forms.Label();
            this.tbBasey3 = new System.Windows.Forms.TextBox();
            this.lbBasex3 = new System.Windows.Forms.Label();
            this.lbBases3 = new System.Windows.Forms.Label();
            this.tbBasex3 = new System.Windows.Forms.TextBox();
            this.lbBasez2 = new System.Windows.Forms.Label();
            this.tbBasez2 = new System.Windows.Forms.TextBox();
            this.lbBasey2 = new System.Windows.Forms.Label();
            this.tbBasey2 = new System.Windows.Forms.TextBox();
            this.lbBasex2 = new System.Windows.Forms.Label();
            this.lbBases2 = new System.Windows.Forms.Label();
            this.tbBasex2 = new System.Windows.Forms.TextBox();
            this.lbBasez1 = new System.Windows.Forms.Label();
            this.tbBasez1 = new System.Windows.Forms.TextBox();
            this.lbBasey1 = new System.Windows.Forms.Label();
            this.tbBasey1 = new System.Windows.Forms.TextBox();
            this.lbBasex1 = new System.Windows.Forms.Label();
            this.lbBases1 = new System.Windows.Forms.Label();
            this.btnEditPublic = new System.Windows.Forms.Button();
            this.gbSP.SuspendLayout();
            this.pnlSPSetting.SuspendLayout();
            this.gbSerialPortShow.SuspendLayout();
            this.gbServerState.SuspendLayout();
            this.gbBaseSet.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSP
            // 
            this.gbSP.Controls.Add(this.pnlSPSetting);
            this.gbSP.Location = new System.Drawing.Point(12, 12);
            this.gbSP.Name = "gbSP";
            this.gbSP.Size = new System.Drawing.Size(260, 141);
            this.gbSP.TabIndex = 1;
            this.gbSP.TabStop = false;
            this.gbSP.Text = "串口设置";
            // 
            // pnlSPSetting
            // 
            this.pnlSPSetting.Controls.Add(this.cbStopBit);
            this.pnlSPSetting.Controls.Add(this.cbCheckoutBit);
            this.pnlSPSetting.Controls.Add(this.lbStopBit);
            this.pnlSPSetting.Controls.Add(this.tbReceviceCount);
            this.pnlSPSetting.Controls.Add(this.tbSendCount);
            this.pnlSPSetting.Controls.Add(this.lbReceiveCount);
            this.pnlSPSetting.Controls.Add(this.btnResetCount);
            this.pnlSPSetting.Controls.Add(this.lbSPSta);
            this.pnlSPSetting.Controls.Add(this.lbSendCount);
            this.pnlSPSetting.Controls.Add(this.btnOpenSP);
            this.pnlSPSetting.Controls.Add(this.lbCheckoutBit);
            this.pnlSPSetting.Controls.Add(this.cbBaud);
            this.pnlSPSetting.Controls.Add(this.lbBaud);
            this.pnlSPSetting.Controls.Add(this.lbSP);
            this.pnlSPSetting.Controls.Add(this.cbSP);
            this.pnlSPSetting.Location = new System.Drawing.Point(6, 15);
            this.pnlSPSetting.Name = "pnlSPSetting";
            this.pnlSPSetting.Size = new System.Drawing.Size(248, 119);
            this.pnlSPSetting.TabIndex = 2;
            // 
            // cbStopBit
            // 
            this.cbStopBit.DisplayMember = "0";
            this.cbStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStopBit.FormattingEnabled = true;
            this.cbStopBit.Location = new System.Drawing.Point(180, 36);
            this.cbStopBit.Name = "cbStopBit";
            this.cbStopBit.Size = new System.Drawing.Size(60, 20);
            this.cbStopBit.TabIndex = 4;
            // 
            // cbCheckoutBit
            // 
            this.cbCheckoutBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCheckoutBit.FormattingEnabled = true;
            this.cbCheckoutBit.Location = new System.Drawing.Point(180, 10);
            this.cbCheckoutBit.Name = "cbCheckoutBit";
            this.cbCheckoutBit.Size = new System.Drawing.Size(60, 20);
            this.cbCheckoutBit.TabIndex = 3;
            // 
            // lbStopBit
            // 
            this.lbStopBit.AutoSize = true;
            this.lbStopBit.Location = new System.Drawing.Point(134, 39);
            this.lbStopBit.Name = "lbStopBit";
            this.lbStopBit.Size = new System.Drawing.Size(41, 12);
            this.lbStopBit.TabIndex = 13;
            this.lbStopBit.Text = "停止位";
            // 
            // tbReceviceCount
            // 
            this.tbReceviceCount.Location = new System.Drawing.Point(190, 91);
            this.tbReceviceCount.Name = "tbReceviceCount";
            this.tbReceviceCount.ReadOnly = true;
            this.tbReceviceCount.Size = new System.Drawing.Size(50, 21);
            this.tbReceviceCount.TabIndex = 9;
            this.tbReceviceCount.TabStop = false;
            this.tbReceviceCount.Text = "0";
            // 
            // tbSendCount
            // 
            this.tbSendCount.Location = new System.Drawing.Point(8, 91);
            this.tbSendCount.Name = "tbSendCount";
            this.tbSendCount.ReadOnly = true;
            this.tbSendCount.Size = new System.Drawing.Size(50, 21);
            this.tbSendCount.TabIndex = 7;
            this.tbSendCount.Tag = " ";
            this.tbSendCount.Text = "0";
            this.tbSendCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSendCount.WordWrap = false;
            // 
            // lbReceiveCount
            // 
            this.lbReceiveCount.AutoSize = true;
            this.lbReceiveCount.Location = new System.Drawing.Point(155, 94);
            this.lbReceiveCount.Name = "lbReceiveCount";
            this.lbReceiveCount.Size = new System.Drawing.Size(29, 12);
            this.lbReceiveCount.TabIndex = 8;
            this.lbReceiveCount.Text = "接收";
            // 
            // btnResetCount
            // 
            this.btnResetCount.Location = new System.Drawing.Point(99, 89);
            this.btnResetCount.Name = "btnResetCount";
            this.btnResetCount.Size = new System.Drawing.Size(50, 23);
            this.btnResetCount.TabIndex = 10;
            this.btnResetCount.Text = "清零";
            this.btnResetCount.UseVisualStyleBackColor = true;
            // 
            // lbSPSta
            // 
            this.lbSPSta.AutoSize = true;
            this.lbSPSta.Location = new System.Drawing.Point(6, 67);
            this.lbSPSta.Name = "lbSPSta";
            this.lbSPSta.Size = new System.Drawing.Size(65, 12);
            this.lbSPSta.TabIndex = 11;
            this.lbSPSta.Text = "串口已关闭";
            // 
            // lbSendCount
            // 
            this.lbSendCount.AutoSize = true;
            this.lbSendCount.Location = new System.Drawing.Point(64, 94);
            this.lbSendCount.Name = "lbSendCount";
            this.lbSendCount.Size = new System.Drawing.Size(29, 12);
            this.lbSendCount.TabIndex = 6;
            this.lbSendCount.Text = "发送";
            // 
            // btnOpenSP
            // 
            this.btnOpenSP.Location = new System.Drawing.Point(170, 62);
            this.btnOpenSP.Name = "btnOpenSP";
            this.btnOpenSP.Size = new System.Drawing.Size(70, 23);
            this.btnOpenSP.TabIndex = 5;
            this.btnOpenSP.Text = "打开串口";
            this.btnOpenSP.UseVisualStyleBackColor = true;
            // 
            // lbCheckoutBit
            // 
            this.lbCheckoutBit.AutoSize = true;
            this.lbCheckoutBit.Location = new System.Drawing.Point(133, 13);
            this.lbCheckoutBit.Name = "lbCheckoutBit";
            this.lbCheckoutBit.Size = new System.Drawing.Size(41, 12);
            this.lbCheckoutBit.TabIndex = 12;
            this.lbCheckoutBit.Text = "校验位";
            // 
            // cbBaud
            // 
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800"});
            this.cbBaud.Location = new System.Drawing.Point(53, 36);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(60, 20);
            this.cbBaud.TabIndex = 2;
            this.cbBaud.Text = "115200";
            // 
            // lbBaud
            // 
            this.lbBaud.AutoSize = true;
            this.lbBaud.Location = new System.Drawing.Point(6, 39);
            this.lbBaud.Name = "lbBaud";
            this.lbBaud.Size = new System.Drawing.Size(41, 12);
            this.lbBaud.TabIndex = 2;
            this.lbBaud.Text = "波特率";
            // 
            // lbSP
            // 
            this.lbSP.AutoSize = true;
            this.lbSP.Location = new System.Drawing.Point(18, 13);
            this.lbSP.Name = "lbSP";
            this.lbSP.Size = new System.Drawing.Size(29, 12);
            this.lbSP.TabIndex = 0;
            this.lbSP.Text = "串口";
            // 
            // cbSP
            // 
            this.cbSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSP.FormattingEnabled = true;
            this.cbSP.Location = new System.Drawing.Point(53, 10);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(60, 20);
            this.cbSP.TabIndex = 1;
            // 
            // gbSerialPortShow
            // 
            this.gbSerialPortShow.Controls.Add(this.cbSPShow);
            this.gbSerialPortShow.Controls.Add(this.cbChangeLine);
            this.gbSerialPortShow.Controls.Add(this.lbSPShowType);
            this.gbSerialPortShow.Controls.Add(this.rbText);
            this.gbSerialPortShow.Controls.Add(this.rbHex);
            this.gbSerialPortShow.Controls.Add(this.btnSPSend);
            this.gbSerialPortShow.Controls.Add(this.tbSerialPortSend);
            this.gbSerialPortShow.Controls.Add(this.rtbSerialPortShow);
            this.gbSerialPortShow.Location = new System.Drawing.Point(278, 12);
            this.gbSerialPortShow.Name = "gbSerialPortShow";
            this.gbSerialPortShow.Size = new System.Drawing.Size(259, 141);
            this.gbSerialPortShow.TabIndex = 7;
            this.gbSerialPortShow.TabStop = false;
            this.gbSerialPortShow.Text = "串口监控";
            // 
            // cbSPShow
            // 
            this.cbSPShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSPShow.AutoSize = true;
            this.cbSPShow.Location = new System.Drawing.Point(204, 21);
            this.cbSPShow.Name = "cbSPShow";
            this.cbSPShow.Size = new System.Drawing.Size(48, 16);
            this.cbSPShow.TabIndex = 11;
            this.cbSPShow.Text = "显示";
            this.cbSPShow.UseVisualStyleBackColor = true;
            // 
            // cbChangeLine
            // 
            this.cbChangeLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbChangeLine.AutoSize = true;
            this.cbChangeLine.Location = new System.Drawing.Point(144, 116);
            this.cbChangeLine.Name = "cbChangeLine";
            this.cbChangeLine.Size = new System.Drawing.Size(48, 16);
            this.cbChangeLine.TabIndex = 0;
            this.cbChangeLine.Text = "换行";
            this.cbChangeLine.UseVisualStyleBackColor = true;
            // 
            // lbSPShowType
            // 
            this.lbSPShowType.AutoSize = true;
            this.lbSPShowType.Location = new System.Drawing.Point(6, 22);
            this.lbSPShowType.Name = "lbSPShowType";
            this.lbSPShowType.Size = new System.Drawing.Size(53, 12);
            this.lbSPShowType.TabIndex = 10;
            this.lbSPShowType.Text = "显示方式";
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(65, 20);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(47, 16);
            this.rbText.TabIndex = 0;
            this.rbText.Text = "文本";
            this.rbText.UseVisualStyleBackColor = true;
            // 
            // rbHex
            // 
            this.rbHex.AutoSize = true;
            this.rbHex.Checked = true;
            this.rbHex.Location = new System.Drawing.Point(118, 20);
            this.rbHex.Name = "rbHex";
            this.rbHex.Size = new System.Drawing.Size(71, 16);
            this.rbHex.TabIndex = 1;
            this.rbHex.TabStop = true;
            this.rbHex.Text = "十六进制";
            this.rbHex.UseVisualStyleBackColor = true;
            // 
            // btnSPSend
            // 
            this.btnSPSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSPSend.Location = new System.Drawing.Point(197, 112);
            this.btnSPSend.Name = "btnSPSend";
            this.btnSPSend.Size = new System.Drawing.Size(55, 23);
            this.btnSPSend.TabIndex = 2;
            this.btnSPSend.Text = "发送";
            this.btnSPSend.UseVisualStyleBackColor = true;
            // 
            // tbSerialPortSend
            // 
            this.tbSerialPortSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSerialPortSend.Location = new System.Drawing.Point(6, 114);
            this.tbSerialPortSend.Name = "tbSerialPortSend";
            this.tbSerialPortSend.Size = new System.Drawing.Size(132, 21);
            this.tbSerialPortSend.TabIndex = 9;
            this.tbSerialPortSend.WordWrap = false;
            // 
            // rtbSerialPortShow
            // 
            this.rtbSerialPortShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSerialPortShow.Location = new System.Drawing.Point(6, 42);
            this.rtbSerialPortShow.Name = "rtbSerialPortShow";
            this.rtbSerialPortShow.ReadOnly = true;
            this.rtbSerialPortShow.Size = new System.Drawing.Size(246, 66);
            this.rtbSerialPortShow.TabIndex = 0;
            this.rtbSerialPortShow.TabStop = false;
            this.rtbSerialPortShow.Text = "";
            this.rtbSerialPortShow.TextChanged += new System.EventHandler(this.rtbSerialPortShow_TextChanged);
            // 
            // gbServerState
            // 
            this.gbServerState.Controls.Add(this.btnEditPublic);
            this.gbServerState.Controls.Add(this.cbViData);
            this.gbServerState.Controls.Add(this.btnTestWindow);
            this.gbServerState.Controls.Add(this.label1);
            this.gbServerState.Controls.Add(this.tbServerPort);
            this.gbServerState.Controls.Add(this.btnOpenServer);
            this.gbServerState.Location = new System.Drawing.Point(13, 160);
            this.gbServerState.Name = "gbServerState";
            this.gbServerState.Size = new System.Drawing.Size(517, 47);
            this.gbServerState.TabIndex = 8;
            this.gbServerState.TabStop = false;
            this.gbServerState.Text = "服务器状态";
            // 
            // cbViData
            // 
            this.cbViData.AutoSize = true;
            this.cbViData.Location = new System.Drawing.Point(278, 22);
            this.cbViData.Name = "cbViData";
            this.cbViData.Size = new System.Drawing.Size(132, 16);
            this.cbViData.TabIndex = 5;
            this.cbViData.Text = "使用虚拟数据以测试";
            this.cbViData.UseVisualStyleBackColor = true;
            // 
            // btnTestWindow
            // 
            this.btnTestWindow.Location = new System.Drawing.Point(411, 18);
            this.btnTestWindow.Name = "btnTestWindow";
            this.btnTestWindow.Size = new System.Drawing.Size(100, 23);
            this.btnTestWindow.TabIndex = 4;
            this.btnTestWindow.Text = "服务器测试程序";
            this.btnTestWindow.UseVisualStyleBackColor = true;
            this.btnTestWindow.Click += new System.EventHandler(this.btnTestWindow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "监听端口";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(65, 20);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(45, 21);
            this.tbServerPort.TabIndex = 1;
            this.tbServerPort.Text = "17667";
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenServer.Location = new System.Drawing.Point(116, 18);
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Size = new System.Drawing.Size(75, 23);
            this.btnOpenServer.TabIndex = 0;
            this.btnOpenServer.Text = "开启服务器";
            this.btnOpenServer.UseVisualStyleBackColor = true;
            // 
            // tbBasex1
            // 
            this.tbBasex1.Location = new System.Drawing.Point(89, 20);
            this.tbBasex1.Name = "tbBasex1";
            this.tbBasex1.Size = new System.Drawing.Size(47, 21);
            this.tbBasex1.TabIndex = 3;
            this.tbBasex1.Text = "0";
            this.tbBasex1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbBaseSet
            // 
            this.gbBaseSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBaseSet.Controls.Add(this.btnBaseChange);
            this.gbBaseSet.Controls.Add(this.btnBaseChange3);
            this.gbBaseSet.Controls.Add(this.btnBaseChange2);
            this.gbBaseSet.Controls.Add(this.btnBaseChange1);
            this.gbBaseSet.Controls.Add(this.lbBasez3);
            this.gbBaseSet.Controls.Add(this.tbBasez3);
            this.gbBaseSet.Controls.Add(this.lbBasey3);
            this.gbBaseSet.Controls.Add(this.tbBasey3);
            this.gbBaseSet.Controls.Add(this.lbBasex3);
            this.gbBaseSet.Controls.Add(this.lbBases3);
            this.gbBaseSet.Controls.Add(this.tbBasex3);
            this.gbBaseSet.Controls.Add(this.lbBasez2);
            this.gbBaseSet.Controls.Add(this.tbBasez2);
            this.gbBaseSet.Controls.Add(this.lbBasey2);
            this.gbBaseSet.Controls.Add(this.tbBasey2);
            this.gbBaseSet.Controls.Add(this.lbBasex2);
            this.gbBaseSet.Controls.Add(this.lbBases2);
            this.gbBaseSet.Controls.Add(this.tbBasex2);
            this.gbBaseSet.Controls.Add(this.lbBasez1);
            this.gbBaseSet.Controls.Add(this.tbBasez1);
            this.gbBaseSet.Controls.Add(this.lbBasey1);
            this.gbBaseSet.Controls.Add(this.tbBasey1);
            this.gbBaseSet.Controls.Add(this.lbBasex1);
            this.gbBaseSet.Controls.Add(this.lbBases1);
            this.gbBaseSet.Controls.Add(this.tbBasex1);
            this.gbBaseSet.Location = new System.Drawing.Point(13, 214);
            this.gbBaseSet.Name = "gbBaseSet";
            this.gbBaseSet.Size = new System.Drawing.Size(523, 102);
            this.gbBaseSet.TabIndex = 9;
            this.gbBaseSet.TabStop = false;
            this.gbBaseSet.Text = "基站设置";
            // 
            // btnBaseChange
            // 
            this.btnBaseChange.Location = new System.Drawing.Point(490, 17);
            this.btnBaseChange.Name = "btnBaseChange";
            this.btnBaseChange.Size = new System.Drawing.Size(27, 77);
            this.btnBaseChange.TabIndex = 31;
            this.btnBaseChange.Text = "应用";
            this.btnBaseChange.UseVisualStyleBackColor = true;
            // 
            // btnBaseChange3
            // 
            this.btnBaseChange3.Location = new System.Drawing.Point(408, 71);
            this.btnBaseChange3.Name = "btnBaseChange3";
            this.btnBaseChange3.Size = new System.Drawing.Size(75, 23);
            this.btnBaseChange3.TabIndex = 30;
            this.btnBaseChange3.Text = "修改";
            this.btnBaseChange3.UseVisualStyleBackColor = true;
            // 
            // btnBaseChange2
            // 
            this.btnBaseChange2.Location = new System.Drawing.Point(408, 44);
            this.btnBaseChange2.Name = "btnBaseChange2";
            this.btnBaseChange2.Size = new System.Drawing.Size(75, 23);
            this.btnBaseChange2.TabIndex = 29;
            this.btnBaseChange2.Text = "修改";
            this.btnBaseChange2.UseVisualStyleBackColor = true;
            // 
            // btnBaseChange1
            // 
            this.btnBaseChange1.Location = new System.Drawing.Point(408, 17);
            this.btnBaseChange1.Name = "btnBaseChange1";
            this.btnBaseChange1.Size = new System.Drawing.Size(75, 23);
            this.btnBaseChange1.TabIndex = 28;
            this.btnBaseChange1.Text = "修改";
            this.btnBaseChange1.UseVisualStyleBackColor = true;
            // 
            // lbBasez3
            // 
            this.lbBasez3.AutoSize = true;
            this.lbBasez3.Location = new System.Drawing.Point(378, 77);
            this.lbBasez3.Name = "lbBasez3";
            this.lbBasez3.Size = new System.Drawing.Size(23, 12);
            this.lbBasez3.TabIndex = 27;
            this.lbBasez3.Text = "(m)";
            // 
            // tbBasez3
            // 
            this.tbBasez3.Location = new System.Drawing.Point(325, 74);
            this.tbBasez3.Name = "tbBasez3";
            this.tbBasez3.Size = new System.Drawing.Size(47, 21);
            this.tbBasez3.TabIndex = 26;
            this.tbBasez3.Text = "1";
            this.tbBasez3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbBasey3
            // 
            this.lbBasey3.AutoSize = true;
            this.lbBasey3.Location = new System.Drawing.Point(260, 77);
            this.lbBasey3.Name = "lbBasey3";
            this.lbBasey3.Size = new System.Drawing.Size(59, 12);
            this.lbBasey3.TabIndex = 25;
            this.lbBasey3.Text = "(m)    z:";
            // 
            // tbBasey3
            // 
            this.tbBasey3.Location = new System.Drawing.Point(207, 74);
            this.tbBasey3.Name = "tbBasey3";
            this.tbBasey3.Size = new System.Drawing.Size(47, 21);
            this.tbBasey3.TabIndex = 24;
            this.tbBasey3.Text = "0";
            this.tbBasey3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbBasex3
            // 
            this.lbBasex3.AutoSize = true;
            this.lbBasex3.Location = new System.Drawing.Point(142, 77);
            this.lbBasex3.Name = "lbBasex3";
            this.lbBasex3.Size = new System.Drawing.Size(59, 12);
            this.lbBasex3.TabIndex = 23;
            this.lbBasex3.Text = "(m)    y:";
            // 
            // lbBases3
            // 
            this.lbBases3.AutoSize = true;
            this.lbBases3.Location = new System.Drawing.Point(6, 77);
            this.lbBases3.Name = "lbBases3";
            this.lbBases3.Size = new System.Drawing.Size(77, 12);
            this.lbBases3.TabIndex = 22;
            this.lbBases3.Text = "基站3：   x:";
            // 
            // tbBasex3
            // 
            this.tbBasex3.Location = new System.Drawing.Point(89, 74);
            this.tbBasex3.Name = "tbBasex3";
            this.tbBasex3.Size = new System.Drawing.Size(47, 21);
            this.tbBasex3.TabIndex = 21;
            this.tbBasex3.Text = "5";
            this.tbBasex3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbBasez2
            // 
            this.lbBasez2.AutoSize = true;
            this.lbBasez2.Location = new System.Drawing.Point(378, 50);
            this.lbBasez2.Name = "lbBasez2";
            this.lbBasez2.Size = new System.Drawing.Size(23, 12);
            this.lbBasez2.TabIndex = 20;
            this.lbBasez2.Text = "(m)";
            // 
            // tbBasez2
            // 
            this.tbBasez2.Location = new System.Drawing.Point(325, 47);
            this.tbBasez2.Name = "tbBasez2";
            this.tbBasez2.Size = new System.Drawing.Size(47, 21);
            this.tbBasez2.TabIndex = 19;
            this.tbBasez2.Text = "1";
            this.tbBasez2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbBasey2
            // 
            this.lbBasey2.AutoSize = true;
            this.lbBasey2.Location = new System.Drawing.Point(260, 50);
            this.lbBasey2.Name = "lbBasey2";
            this.lbBasey2.Size = new System.Drawing.Size(59, 12);
            this.lbBasey2.TabIndex = 18;
            this.lbBasey2.Text = "(m)    z:";
            // 
            // tbBasey2
            // 
            this.tbBasey2.Location = new System.Drawing.Point(207, 47);
            this.tbBasey2.Name = "tbBasey2";
            this.tbBasey2.Size = new System.Drawing.Size(47, 21);
            this.tbBasey2.TabIndex = 17;
            this.tbBasey2.Text = "5";
            this.tbBasey2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbBasex2
            // 
            this.lbBasex2.AutoSize = true;
            this.lbBasex2.Location = new System.Drawing.Point(142, 50);
            this.lbBasex2.Name = "lbBasex2";
            this.lbBasex2.Size = new System.Drawing.Size(59, 12);
            this.lbBasex2.TabIndex = 16;
            this.lbBasex2.Text = "(m)    y:";
            // 
            // lbBases2
            // 
            this.lbBases2.AutoSize = true;
            this.lbBases2.Location = new System.Drawing.Point(6, 50);
            this.lbBases2.Name = "lbBases2";
            this.lbBases2.Size = new System.Drawing.Size(77, 12);
            this.lbBases2.TabIndex = 15;
            this.lbBases2.Text = "基站2：   x:";
            // 
            // tbBasex2
            // 
            this.tbBasex2.Location = new System.Drawing.Point(89, 47);
            this.tbBasex2.Name = "tbBasex2";
            this.tbBasex2.Size = new System.Drawing.Size(47, 21);
            this.tbBasex2.TabIndex = 14;
            this.tbBasex2.Text = "0";
            this.tbBasex2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbBasez1
            // 
            this.lbBasez1.AutoSize = true;
            this.lbBasez1.Location = new System.Drawing.Point(378, 23);
            this.lbBasez1.Name = "lbBasez1";
            this.lbBasez1.Size = new System.Drawing.Size(23, 12);
            this.lbBasez1.TabIndex = 13;
            this.lbBasez1.Text = "(m)";
            // 
            // tbBasez1
            // 
            this.tbBasez1.Location = new System.Drawing.Point(325, 20);
            this.tbBasez1.Name = "tbBasez1";
            this.tbBasez1.Size = new System.Drawing.Size(47, 21);
            this.tbBasez1.TabIndex = 12;
            this.tbBasez1.Text = "1";
            this.tbBasez1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbBasey1
            // 
            this.lbBasey1.AutoSize = true;
            this.lbBasey1.Location = new System.Drawing.Point(260, 23);
            this.lbBasey1.Name = "lbBasey1";
            this.lbBasey1.Size = new System.Drawing.Size(59, 12);
            this.lbBasey1.TabIndex = 11;
            this.lbBasey1.Text = "(m)    z:";
            // 
            // tbBasey1
            // 
            this.tbBasey1.Location = new System.Drawing.Point(207, 20);
            this.tbBasey1.Name = "tbBasey1";
            this.tbBasey1.Size = new System.Drawing.Size(47, 21);
            this.tbBasey1.TabIndex = 10;
            this.tbBasey1.Text = "0";
            this.tbBasey1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbBasex1
            // 
            this.lbBasex1.AutoSize = true;
            this.lbBasex1.Location = new System.Drawing.Point(142, 23);
            this.lbBasex1.Name = "lbBasex1";
            this.lbBasex1.Size = new System.Drawing.Size(59, 12);
            this.lbBasex1.TabIndex = 9;
            this.lbBasex1.Text = "(m)    y:";
            // 
            // lbBases1
            // 
            this.lbBases1.AutoSize = true;
            this.lbBases1.Location = new System.Drawing.Point(6, 23);
            this.lbBases1.Name = "lbBases1";
            this.lbBases1.Size = new System.Drawing.Size(77, 12);
            this.lbBases1.TabIndex = 6;
            this.lbBases1.Text = "基站1：   x:";
            // 
            // btnEditPublic
            // 
            this.btnEditPublic.Location = new System.Drawing.Point(197, 18);
            this.btnEditPublic.Name = "btnEditPublic";
            this.btnEditPublic.Size = new System.Drawing.Size(75, 23);
            this.btnEditPublic.TabIndex = 6;
            this.btnEditPublic.Text = "编辑公告";
            this.btnEditPublic.UseVisualStyleBackColor = true;
            this.btnEditPublic.Click += new System.EventHandler(this.btnEditPublic_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 318);
            this.Controls.Add(this.gbBaseSet);
            this.Controls.Add(this.gbServerState);
            this.Controls.Add(this.gbSerialPortShow);
            this.Controls.Add(this.gbSP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(564, 366);
            this.MinimumSize = new System.Drawing.Size(295, 255);
            this.Name = "MainForm";
            this.Text = "UWB串口服务器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.gbSP.ResumeLayout(false);
            this.pnlSPSetting.ResumeLayout(false);
            this.pnlSPSetting.PerformLayout();
            this.gbSerialPortShow.ResumeLayout(false);
            this.gbSerialPortShow.PerformLayout();
            this.gbServerState.ResumeLayout(false);
            this.gbServerState.PerformLayout();
            this.gbBaseSet.ResumeLayout(false);
            this.gbBaseSet.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSP;
        private System.Windows.Forms.Panel pnlSPSetting;
        private System.Windows.Forms.ComboBox cbStopBit;
        private System.Windows.Forms.ComboBox cbCheckoutBit;
        private System.Windows.Forms.Label lbStopBit;
        private System.Windows.Forms.TextBox tbReceviceCount;
        private System.Windows.Forms.TextBox tbSendCount;
        private System.Windows.Forms.Label lbReceiveCount;
        private System.Windows.Forms.Button btnResetCount;
        private System.Windows.Forms.Label lbSPSta;
        private System.Windows.Forms.Label lbSendCount;
        private System.Windows.Forms.Button btnOpenSP;
        private System.Windows.Forms.Label lbCheckoutBit;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Label lbBaud;
        private System.Windows.Forms.Label lbSP;
        private System.Windows.Forms.ComboBox cbSP;
        private System.Windows.Forms.GroupBox gbSerialPortShow;
        private System.Windows.Forms.CheckBox cbSPShow;
        private System.Windows.Forms.CheckBox cbChangeLine;
        private System.Windows.Forms.Label lbSPShowType;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbHex;
        private System.Windows.Forms.Button btnSPSend;
        private System.Windows.Forms.TextBox tbSerialPortSend;
        private System.Windows.Forms.RichTextBox rtbSerialPortShow;
        private System.Windows.Forms.GroupBox gbServerState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.TextBox tbBasex1;
        private System.Windows.Forms.GroupBox gbBaseSet;
        private System.Windows.Forms.Label lbBases1;
        private System.Windows.Forms.Button btnBaseChange3;
        private System.Windows.Forms.Button btnBaseChange2;
        private System.Windows.Forms.Button btnBaseChange1;
        private System.Windows.Forms.Label lbBasez3;
        private System.Windows.Forms.TextBox tbBasez3;
        private System.Windows.Forms.Label lbBasey3;
        private System.Windows.Forms.TextBox tbBasey3;
        private System.Windows.Forms.Label lbBasex3;
        private System.Windows.Forms.Label lbBases3;
        private System.Windows.Forms.TextBox tbBasex3;
        private System.Windows.Forms.Label lbBasez2;
        private System.Windows.Forms.TextBox tbBasez2;
        private System.Windows.Forms.Label lbBasey2;
        private System.Windows.Forms.TextBox tbBasey2;
        private System.Windows.Forms.Label lbBasex2;
        private System.Windows.Forms.Label lbBases2;
        private System.Windows.Forms.TextBox tbBasex2;
        private System.Windows.Forms.Label lbBasez1;
        private System.Windows.Forms.TextBox tbBasez1;
        private System.Windows.Forms.Label lbBasey1;
        private System.Windows.Forms.TextBox tbBasey1;
        private System.Windows.Forms.Label lbBasex1;
        private System.Windows.Forms.Button btnTestWindow;
        private System.Windows.Forms.CheckBox cbViData;
        private System.Windows.Forms.Button btnBaseChange;
        private System.Windows.Forms.Button btnEditPublic;
    }
}

