using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UWB_SP_TO_SOCKET.src.Tools;
using UWB_SP_TO_SOCKET.src.Twr.Model;
using UWB_SP_TO_SOCKET.src.Twr.Table;
using UWB_SP_TO_SOCKET.src.Twr.Tool;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Service
     * 文件名：  TwrServer
     * 版本号：  V1.0.0.0
     * 唯一标识：9613a76c-da70-462a-8cf8-955348e86730
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 15:34:02
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 15:34:02
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service
{

    class TwrServer
    {
        SerialPortService sps;

        static Vec3dInfo[] anchor;

        Button btnBaseChange1;
        Button btnBaseChange2;
        Button btnBaseChange3;
        Button btnBaseChange;
        TextBox tbBasex1;
        TextBox tbBasex2;
        TextBox tbBasex3;
        TextBox tbBasey1;
        TextBox tbBasey2;
        TextBox tbBasey3;
        TextBox tbBasez1;
        TextBox tbBasez2;
        TextBox tbBasez3;

        CheckBox cbViData;


        Thread updateData;
        bool isOpenVi;

        internal void InitView(Button btnBaseChange1, Button btnBaseChange2, Button btnBaseChange3, Button btnBaseChange, TextBox tbBasex1, TextBox tbBasex2, TextBox tbBasex3, TextBox tbBasey1, TextBox tbBasey2, TextBox tbBasey3, TextBox tbBasez1, TextBox tbBasez2, TextBox tbBasez3, CheckBox cbViData)
        {
            this.btnBaseChange1 = btnBaseChange1;
            this.btnBaseChange2 = btnBaseChange2;
            this.btnBaseChange3 = btnBaseChange3;
            this.btnBaseChange = btnBaseChange;
            this.tbBasex1 = tbBasex1;
            this.tbBasex2 = tbBasex2;
            this.tbBasex3 = tbBasex3;
            this.tbBasey1 = tbBasey1;
            this.tbBasey2 = tbBasey2;
            this.tbBasey3 = tbBasey3;
            this.tbBasez1 = tbBasez1;
            this.tbBasez2 = tbBasez2;
            this.tbBasez3 = tbBasez3;
            this.cbViData = cbViData;

            btnBaseChange.Click += BtnOnClick;
            btnBaseChange1.Click += BtnOnClick;
            btnBaseChange2.Click += BtnOnClick;
            btnBaseChange3.Click += BtnOnClick;

            int results = 0;
            results += UpdateAnchorByView(1);
            results += UpdateAnchorByView(2);
            results += UpdateAnchorByView(3);
            if (results != 3)
            {
                MessageBox.Show("数据格式有误！");
            }

            cbViData.CheckedChanged += cbViData_CheckedChanged;

            string val;
            for (int i = 0; i < 3; i++)
            {
                //位置X
                val = ConfigurationHelper.getSetting(ARC_LOCAL_X + (i + 1));
                if (val != null)
                {
                    float v;
                    if (float.TryParse(val, out v))
                    {
                        switch (i)
                        {
                            case 0:
                                tbBasex1.Text = val;
                                break;
                            case 1:
                                tbBasex2.Text = val;
                                break;
                            case 2:
                                tbBasex3.Text = val;
                                break;
                        }
                    }
                }

                //位置Y
                val = ConfigurationHelper.getSetting(ARC_LOCAL_Y + (i + 1));
                if (val != null)
                {
                    float v;
                    if (float.TryParse(val, out v))
                    {
                        switch (i)
                        {
                            case 0:
                                tbBasey1.Text = val;
                                break;
                            case 1:
                                tbBasey2.Text = val;
                                break;
                            case 2:
                                tbBasey3.Text = val;
                                break;
                        }
                    }
                }

                //位置Z
                val = ConfigurationHelper.getSetting(ARC_LOCAL_Z + (i + 1));
                if (val != null)
                {
                    float v;
                    if (float.TryParse(val, out v))
                    {
                        switch (i)
                        {
                            case 0:
                                tbBasez1.Text = val;
                                break;
                            case 1:
                                tbBasez2.Text = val;
                                break;
                            case 2:
                                tbBasez3.Text = val;
                                break;
                        }
                    }
                }
            }

        }

        const string ARC_LOCAL_X = "ARC_LOCAL_X";
        const string ARC_LOCAL_Y = "ARC_LOCAL_Y";
        const string ARC_LOCAL_Z = "ARC_LOCAL_Z";

        void cbViData_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                updateData = new Thread(TWRUpdate);
                updateData.Start();
                MessageBox.Show("虚拟数据已开启，可不必连接串口！");
            }
            else
            {
                isOpenVi = false;
                updateData.Abort();
                MessageBox.Show("虚拟数据已关闭，请连接串口以更新数据！");
            }
        }

        private void BtnOnClick(object sender, EventArgs e)
        {
            int results = 0;
            if (sender == btnBaseChange)
            {
                results += UpdateAnchorByView(1);
                results += UpdateAnchorByView(2);
                results += UpdateAnchorByView(3);
                if (results == 3)
                {
                    MessageBox.Show("已应用！");
                }
                else
                {
                    MessageBox.Show("数据格式有误！");
                }
            }
            else if (sender == btnBaseChange1)
            {
                if (UpdateAnchorByView(1) == 1)
                {
                    MessageBox.Show("锚点1：(" + anchor[0].x + "," + anchor[0].y + "," + anchor[0].z + ")");
                }
                else
                {
                    MessageBox.Show("基站一数据格式错误！");
                }
            }
            else if (sender == btnBaseChange2)
            {
                if (UpdateAnchorByView(2) == 1)
                {
                    MessageBox.Show("锚点2：(" + anchor[1].x + "," + anchor[1].y + "," + anchor[1].z + ")");
                }
                else
                {
                    MessageBox.Show("基站二数据格式错误！");
                }
            }
            else if (sender == btnBaseChange3)
            {
                if (UpdateAnchorByView(3) == 1)
                {
                    MessageBox.Show("锚点3：(" + anchor[2].x + "," + anchor[2].y + "," + anchor[2].z + ")");
                }
                else
                {
                    MessageBox.Show("基站三数据格式错误！");
                }
            }
        }
        /// <summary>
        /// 获取锚点信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TableAnchor GetAnchorById(int id)
        {
            if (id < anchor.Length)
            {
                TableAnchor ta = new TableAnchor();

                ta.anchor_id = id+1;
                ta.x = anchor[id].x;
                ta.y = anchor[id].y;
                ta.z = anchor[id].z;
                return ta;
            }
            return null;
        }
        /// <summary>
        /// 通过视图更新锚点信息
        /// </summary>
        /// <param name="id">锚点ID</param>
        int UpdateAnchorByView(int id)
        {
            double x = -1, y = -1, z = -1;
            int res = 0;
            switch (id)
            {
                case 1:
                    res += GetDoubleByString(ref x, this.tbBasex1.Text);
                    res += GetDoubleByString(ref y, this.tbBasey1.Text);
                    res += GetDoubleByString(ref z, this.tbBasez1.Text);
                    if (res < 3)
                    {
                        return 0;
                    }
                    anchor[0].x = x;
                    anchor[0].y = y;
                    anchor[0].z = z;
                    break;
                case 2:
                    res += GetDoubleByString(ref x, this.tbBasex2.Text);
                    res += GetDoubleByString(ref y, this.tbBasey2.Text);
                    res += GetDoubleByString(ref z, this.tbBasez2.Text);
                    if (res < 3)
                    {
                        return 0;
                    }
                    anchor[1].x = x;
                    anchor[1].y = y;
                    anchor[1].z = z;
                    break;
                case 3:
                    res += GetDoubleByString(ref x, this.tbBasex3.Text);
                    res += GetDoubleByString(ref y, this.tbBasey3.Text);
                    res += GetDoubleByString(ref z, this.tbBasez3.Text);
                    if (res < 3)
                    {
                        return 0;
                    }
                    anchor[2].x = x;
                    anchor[2].y = y;
                    anchor[2].z = z;
                    break;
            }

            TableAnchor ta = new TableAnchor();

            ta.anchor_id = id;
            ta.x = x;
            ta.y = y;
            ta.z = z;

            if (anchorBuildEvent != null)
            {

#if DEBUG
                Console.WriteLine("产生锚点：" + ta.ToString());
#endif 
                //锚点信息产生事件
                anchorBuildEvent(ta);
            }

            //更新配置
            ConfigurationHelper.updateSetting(ARC_LOCAL_X + (id), x.ToString());
            ConfigurationHelper.updateSetting(ARC_LOCAL_Y + (id), y.ToString());
            ConfigurationHelper.updateSetting(ARC_LOCAL_Z + (id), z.ToString());


            return 1;
        }

        /// <summary>
        /// 字符串转浮点
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>结果，出错返回-1</returns>
        int GetDoubleByString(ref double f, string str)
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
                f = double.Parse(str);
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }

        }

        public TwrServer(SerialPortService sps)
        {
            this.sps = sps;

            anchor = new Vec3dInfo[3];
            for (int i = 0; i < anchor.Length; i++)
            {
                anchor[i] = new Vec3dInfo(0, 0, 0);
            }

            sps.SerialPortEventMsg += Sps_SerialPortEventMsg;

        }



        private void TWRUpdate()
        {
            isOpenVi = true;
            RealitySerialPortData rspd = new RealitySerialPortData();
            while (isOpenVi)
            {
                Thread.Sleep(100);
                VirtualenvInfo vi = rspd.DataSimulate();

                TableTag tt = new TableTag();

                tt.tag_id = vi.tagId;
                tt.x = (int)(vi.tag.x * 100);
                tt.y = (int)(vi.tag.y * 100);
                tt.z = (int)(vi.tag.z * 100);

                if (tagBuildEvent != null)
                {
                    tagBuildEvent(tt);
                }

            }
        }

        void Sps_SerialPortEventMsg(byte[] readByte, System.IO.Ports.SerialPort m_SP)
        {
            newData(readByte);
        }

        /// <summary>
        /// 模型构建完成的时候
        /// 在这里拿到计算结果
        /// </summary>
        /// <param name="vi">已经处理的模型信息</param>
        internal void ModelInfoBuild(VirtualenvInfo vi)
        {
            TableTag tt = new TableTag();
            if (vi.isDispose)
            {
                //写入ID
                tt.tag_id = vi.tagId;
                //写入坐标(cm)
                tt.x = (int)(vi.tag.x * 100);
                tt.y = (int)(vi.tag.y * 100);
                tt.z = (int)(vi.tag.z * 100);
                //半径写入(cm)
                tt.anc0 = (int)(vi.r[0] / 10.0);
                tt.anc1 = (int)(vi.r[1] / 10.0);
                tt.anc2 = (int)(vi.r[2] / 10.0);
                tt.anc3 = (int)(vi.r[3] / 10.0);
                if (tagBuildEvent != null)
                {

#if DEBUG
                    Console.WriteLine("产生标签：" + tt.ToString());
#endif 
                    //标签产生事件
                    tagBuildEvent(tt);
                }


                //AddToTTagList(tt);
            }
        }
        /// <summary>
        /// 原始帧生成的时候
        /// 这里更新各个锚点到目标点的距离
        /// </summary>
        /// <param name="uri">原始信息</param>        
        internal void RawFrameBuild(byte[] frame, UwbRawInfo uri)
        {
            //转换
            this.TransitionInfo(uri);

            TableRaw tr = new TableRaw();
            frame.CopyTo(tr.raw_data, 0);
            if (rawBuildEvent != null)
            {

#if DEBUG
                Console.WriteLine("产生原始信息：" + tr.ToString());
#endif 
                //原始消息产生事件
                rawBuildEvent(tr);
            }
        }

        public delegate void RawBuildHandler(TableRaw tr);
        public event RawBuildHandler rawBuildEvent;
        public delegate void TagBuildHandler(TableTag tt);
        public event TagBuildHandler tagBuildEvent;
        public delegate void AnchorBuildHandler(TableAnchor ta);
        public event AnchorBuildHandler anchorBuildEvent;

        /****************下面是之前的串口缓存部分********************/
        /// <summary>
        /// 当前信息
        /// </summary>
        public VirtualenvInfo vi;

        /// <summary>
        /// 缓存长度
        /// </summary>
        static int cacheLength = 1024;
        /// <summary>
        /// 有效帧长度
        /// </summary>
        static int frameLength = 14;

        public Vec3dInfo resultBest;
        public Vec3dInfo result1;
        public Vec3dInfo result2;

        public ulong calculateTimes = 0;
        public ulong failedTimes = 0;


        /// <summary>
        /// 读取标记
        /// </summary>
        uint storePos = 0, readPos = 0, dataPos, usartState = 0;
        /// <summary>
        /// 串口接收缓存
        /// </summary>
        byte[] cache = new byte[cacheLength];
        /// <summary>
        /// 串口接收到的数据帧
        /// </summary>
        byte[] frame = new byte[frameLength];
        /// <summary>
        /// 新数据上传到电脑时调用，串口收到的数据传这里
        /// </summary>
        /// <param name="data">数据</param>
        public void newData(byte[] data)
        {
            if (data == null)
            {
                return;
            }

            byte tmp;

            //缓存数据
            for (int i = 0; i < data.Length; i++)
            {
                cache[storePos++] = data[i];
                if (storePos >= cacheLength)
                {
                    storePos = 0;
                }
            }

            //处理数据
            while (storePos != readPos)
            {
                //读出一个数据
                tmp = cache[readPos++];
                if (readPos >= cacheLength)
                {
                    readPos = 0;
                }

                switch (usartState)
                {
                    case 0:
                        if (tmp == 'm')
                        {
                            usartState = 1;
                        }
                        break;

                    case 1:
                        if (tmp == 'r')
                        {
                            usartState = 2;
                            dataPos = 0;
                        }
                        break;

                    case 2:
                        frame[dataPos++] = tmp;
                        if (dataPos > 11)
                        {
                            usartState = 0;
                            //处理速度
                            StructureData(frame);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        void CalculateTagLocation(VirtualenvInfo vi)
        {
            //目标点
            Vec3dInfo tag = new Vec3dInfo();
            //锚点
            Vec3dInfo[] anchorArray = new Vec3dInfo[4];
            //锚点到目标点的距离
            int[] radius = new int[4];
            //计算出来的解
            result1 = new Vec3dInfo();
            result2 = new Vec3dInfo();
            resultBest = new Vec3dInfo();

            for (int i = 0; i < 4; i++)
            {
                if (i < vi.anchor.Length)
                {
                    //锚点位置
                    anchorArray[i] = new Vec3dInfo();
                    anchorArray[i].x = vi.anchor[i].x;
                    anchorArray[i].y = vi.anchor[i].y;
                    anchorArray[i].z = vi.anchor[i].z;
                }
                else
                {
                    anchorArray[i] = new Vec3dInfo();
                    anchorArray[i].x = vi.anchor[0].x;
                    anchorArray[i].y = vi.anchor[0].y;
                    anchorArray[i].z = vi.anchor[0].z;
                }

                //半径
                radius[i] = (int)vi.r[i];
            }

            /*-----------------根据数据计算结果-----------------*/

            calculateTimes++;
            int rCode = FunctionTrilateration.GetLocation(ref resultBest, ref result1, ref result2, vi.trueCount, ref anchorArray, ref radius);
            if (rCode == FunctionTrilateration.TRIL_3SPHERES)
            {

#if DEBUG
                //解算成功
                LogOut("解1：(" + result1.x.ToString("0.00") + "," + result1.y.ToString("0.00") + "," + result1.z.ToString("0.00") + ")");
                LogOut("解2：(" + result2.x.ToString("0.00") + "," + result2.y.ToString("0.00") + "," + result2.z.ToString("0.00") + ")");
                LogOut("目标位置：(" + resultBest.x.ToString("0.00") + "," + resultBest.y.ToString("0.00") + "," + resultBest.z.ToString("0.00") + ")");
#endif 
                vi.tag = resultBest;
                vi.isDispose = true;

                //交给消息管理器
                this.ModelInfoBuild(vi);

                this.vi = vi;
            }
            else
            {
                //解算失败
                failedTimes++;

#if DEBUG
                LogOut("第" + failedTimes + "次解算失败！");
#endif 
            }

#if DEBUG
            LogOut("\n" + vi.ToString());
            /*-----------------计算结果完成-----------------*/
            LogOut("\n统计：\t计算次数：" + calculateTimes + "  \t失败次数：" + failedTimes);
            LogOut("--------------------------------------------------------------------------\n\n\n");
#endif 
        }

        private void LogOut(string p)
        {
            Console.WriteLine(p);
        }
        /// <summary>
        /// 处理数据，构建原始数据
        /// </summary>
        private void StructureData(byte[] frame)
        {
            UwbRawInfo uInfo = new UwbRawInfo();

            //传入原始帧
            uInfo.frame = frame;

            //获取帧类型
            uInfo.frameType = frame[0];
            //获取目标点ID
            uInfo.tagId = frame[1];
            //获取数量
            uInfo.lnum = (uint)((uint)frame[2] | ((uint)frame[3] << 8));
            //获取序列号
            uInfo.seq = (byte)(((byte)uInfo.lnum) & 0xff);

            if (uInfo.frameType == 1)//如果是锚点帧
            {
                uInfo.rRaw[0] = (uint)((uint)frame[6] | ((uint)frame[7] << 8));
                uInfo.rRaw[1] = (uint)((uint)frame[8] | ((uint)frame[9] << 8));
                uInfo.rRaw[2] = (uint)((uint)frame[10] | ((uint)frame[11] << 8));
                uInfo.rRaw[0] = uInfo.rRaw[0] * 10;
                uInfo.rRaw[1] = uInfo.rRaw[1] * 10;
                uInfo.rRaw[2] = uInfo.rRaw[2] * 10;
            }
            else if (uInfo.frameType == 2)//如果是目标帧
            {
                uInfo.rRaw[0] = (uint)((uint)frame[4] | ((uint)frame[5] << 8));
                uInfo.rRaw[1] = (uint)((uint)frame[6] | ((uint)frame[7] << 8));
                uInfo.rRaw[2] = (uint)((uint)frame[8] | ((uint)frame[9] << 8));
                uInfo.rRaw[3] = (uint)((uint)frame[10] | ((uint)frame[11] << 8));
                uInfo.r[0] = uInfo.rRaw[0] * 10;
                uInfo.r[1] = uInfo.rRaw[1] * 10;
                uInfo.r[2] = uInfo.rRaw[2] * 10;
                uInfo.r[3] = uInfo.rRaw[3] * 10;
                //交给消息管理器
                this.RawFrameBuild(frame, uInfo);
            }
        }

        /// <summary>
        /// 转换信息，构建处理模型
        /// </summary>
        /// <param name="ui">原始数据</param>
        public void TransitionInfo(UwbRawInfo ui)
        {
            //构建模型
            VirtualenvInfo vi = new VirtualenvInfo();

            vi.isDispose = false;//标记没有被处理
            vi.seq = ui.seq;//标记序列号
            vi.tagId = ui.tagId;//转储ID

            //转存ID
            for (int i = 0; i < ui.r.Length; i++)
            {
                vi.r[i] = ui.r[i];
            }

            //判断锚点的数量
            if (vi.r[3] != 0)
            {
                vi.trueCount = 4;
            }
            else
            {
                vi.trueCount = 3;
            }

            //获取锚点位置
            vi.anchor = GetAnchorsInfo();

            //处理数据
            CalculateTagLocation(vi);
        }

        private static Vec3dInfo[] GetAnchorsInfo()
        {
            return anchor;
        }

        private static void processTagRangeReport(int id, byte TAG_ID, uint p2, uint lnum, byte seq)
        {
            //处理目标点界面
        }

#if DEBUG
        public bool isDebug = MainForm.debug;
#endif
        internal void Close()
        {

        }
    }
    /// <summary>
    /// 原始事件携带信息
    /// </summary>
    class RawEventArgs : EventArgs
    {
        TableRaw tr;
        public RawEventArgs(TableRaw tr)
        {
            this.tr = tr;
        }
    }
    /// <summary>
    /// 标签事件携带信息
    /// </summary>
    class TagEventArgs : EventArgs
    {
        TableTag ta;
        public TagEventArgs(TableTag ta)
        {
            this.ta = ta;
        }
    }
    /// <summary>
    /// 锚定事件携带信息
    /// </summary>
    class AncEventArgs : EventArgs
    {
        TableAnchor ta;
        public AncEventArgs(TableAnchor ta)
        {
            this.ta = ta;
        }
    }
}


