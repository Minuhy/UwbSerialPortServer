using System;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Twr.Table
     * 文件名：  TableTag
     * 版本号：  V1.0.0.0
     * 唯一标识：52382dd5-606f-4d00-b940-a2afbc07987b
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 17:10:52
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 17:10:52
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Twr.Table
{

    class TableTag
    {
            public int id { set; get; }
            public long time_stamp { set; get; }
            public int tag_id { set; get; }
            public int x { set; get; }
            public int y { set; get; }
            public int z { set; get; }
            public int r95 { set; get; }
            public int anc0 { set; get; }
            public int anc1 { set; get; }
            public int anc2 { set; get; }
            public int anc3 { set; get; }
            public string other { set; get; }

            public TableTag()
            {
                time_stamp = Tools.TimeTool.GetTimeStamp();
                this.other = "null";
            }

            public override string ToString()
            {
                return "TableTag{" +
                "id=" + id +
                ", time_stamp=" + time_stamp +
                ", tag_id=" + tag_id +
                ", x=" + x +
                ", y=" + y +
                ", z=" + z +
                ", r95=" + r95 +
                ", anc0=" + anc0 +
                ", anc1=" + anc1 +
                ", anc2=" + anc2 +
                ", anc3=" + anc3 +
                ", other='" + other + '\'' +
                '}';
            }
        }
    
}
