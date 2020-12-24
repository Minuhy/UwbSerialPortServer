using System;
using System.Text;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Twr.Table
     * 文件名：  TableRaw
     * 版本号：  V1.0.0.0
     * 唯一标识：7daf5531-c29c-4e61-87dd-e00b067fd115
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 17:10:35
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 17:10:35
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Twr.Table
{

    class TableRaw
    {
        public int id { set; get; }
        public long time_stamp { set; get; }
        public byte[] raw_data { set; get; }
        public string other { set; get; }

        public TableRaw()
        {
            time_stamp = Tools.TimeTool.GetTimeStamp();
            raw_data = new byte[20];
        }

        public override string ToString()
        {
            return "TableAnchor{" +
                "id=" + id +
                ", time_stamp=" + time_stamp +
                ",raw_data=" + Encoding.UTF8.GetString(raw_data) +
                ", other='" + other + '\'' +
                '}';
        }
    }
}
