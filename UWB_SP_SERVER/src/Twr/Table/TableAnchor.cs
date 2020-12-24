using System;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Twr.Table
     * 文件名：  TableAnchor
     * 版本号：  V1.0.0.0
     * 唯一标识：aa0da708-fe5a-4e88-8669-f4d581ef04f9
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 17:10:17
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 17:10:17
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Twr.Table
{

    class TableAnchor
    {
        public int id { set; get; }
        public long time_stamp { set; get; }
        public int anchor_id { set; get; }
        public int is_enable { set; get; }
        public double x { set; get; }
        public double y { set; get; }
        public double z { set; get; }
        public string label { set; get; }
        public int t0 { set; get; }
        public int t1 { set; get; }
        public int t2 { set; get; }
        public int t3 { set; get; }
        public int t4 { set; get; }
        public int t5 { set; get; }
        public int t6 { set; get; }
        public int t7 { set; get; }
        public string other { set; get; }

        public TableAnchor()
        {
            time_stamp = Tools.TimeTool.GetTimeStamp();
            this.label = "null";
            this.other = "null";
        }

        public override string ToString()
        {
            return "TableAnchor{" +
                "id=" + id +
                ", time_stamp=" + time_stamp +
                ", anchor_id=" + anchor_id +
                ", is_enable=" + is_enable +
                ", x=" + x +
                ", y=" + y +
                ", z=" + z +
                ", label='" + label + '\'' +
                ", t0=" + t0 +
                ", t1=" + t1 +
                ", t2=" + t2 +
                ", t3=" + t3 +
                ", t4=" + t4 +
                ", t5=" + t5 +
                ", t6=" + t6 +
                ", t7=" + t7 +
                ", other='" + other + '\'' +
                '}';
        }

    }
}
