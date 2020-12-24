using System;
using System.Collections.Generic;
using UWB_SP_TO_SOCKET.src.Twr.Table;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Service
     * 文件名：  MessageServer
     * 版本号：  V1.0.0.0
     * 唯一标识：a9e3663c-61a3-470e-a0e6-2ac2732f91ec
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/22 15:39:34
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/22 15:39:34
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service
{

    class MessageServer
    {
        List<TableAnchor> tali;
        List<TableTag> ttli;
        TableRaw tr;

        private static MessageServer ms;
        private MessageServer()
        {
            tali = new List<TableAnchor>();
            ttli = new List<TableTag>();
            TableRaw tr = new TableRaw();
        }

        public static MessageServer GetMs()
        {
            if (ms == null)
            {
                ms = new MessageServer();
            }

            return ms;
        }

        public void SetTWRServer(TwrServer ts)
        {
            if (ts != null)
            {
                ts.rawBuildEvent += ts_rawBuildEvent;
                ts.tagBuildEvent += ts_tagBuildEvent;
                ts.anchorBuildEvent += ts_anchorBuildEvent;
            }
        }


        void ts_tagBuildEvent(TableTag tt)
        {
            //标签产生事件
            for (int i = 0; i < ttli.Count; i++)
            {
                if (ttli[i].tag_id == tt.tag_id)
                {
                    ttli[i] = tt;
                }

            }

            ttli.Add(tt);

        }

        void ts_rawBuildEvent(TableRaw tr)
        {
            //原始信息产生事件
            this.tr = tr;
        }

        void ts_anchorBuildEvent(TableAnchor ta)
        {
            //标签产生事件
            for (int i = 0; i < tali.Count; i++)
            {
                if (tali[i].anchor_id == ta.anchor_id)
                {
                    tali[i] = ta;
                    return;
                }
            }
            tali.Add(ta);
        }

        public TableAnchor GetTAnchor(int id)
        {
            for (int i = 0; i < tali.Count; i++)
            { 
                if (tali[i].anchor_id == id)
                {
                    return tali[i];
                }

            }

            return null;
        }

        public TableRaw GetTRaw()
        {
            return tr;
        }

        public TableTag GetTTag(int id)
        {
            for (int i = 0; i < ttli.Count; i++)
            {
                if (ttli[i].tag_id == id)
                {
                    return ttli[i];
                }

            }
            return null;
        }

    }
}
