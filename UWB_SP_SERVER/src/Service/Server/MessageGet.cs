using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWB_SP_TO_SOCKET.src.Twr.Table;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Service.Server
     * 文件名：  MessageGet
     * 版本号：  V1.0.0.0
     * 唯一标识：2e4895b3-5f96-41a4-991d-248ba507acf2
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/22 15:47:18
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/22 15:47:18
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service.Server
{

    class MessageGet
    {
        /// <summary>
        /// 获取最新的位置信息，格式：Local:id,x,y,z
        /// </summary>
        /// <returns></returns>
        public static string GetLocalCmd(String i)
        {
            try{
                int id = int.Parse(i);

                TableTag tt = MessageServer.GetMs().GetTTag(id);
                if (tt != null)
                {
                    return "Local:" + tt.tag_id + "," + tt.x + "," + tt.y + "," + tt.z;
                }
                else
                {
                    return "Local:n,n,n,n";
                }
            }
            catch(Exception)
            {
                return "Local:e,e,e,e";
            }
        }

        /// <summary>
        /// 获取最新的锚点信息，格式：Anchor:id,x,y,z
        /// </summary>
        /// <returns></returns>
        public static string GetAnchorCmd(string i)
        {
            try
            {
                int id = int.Parse(i);
                TableAnchor ta = MessageServer.GetMs().GetTAnchor(id);
                if (ta != null)
                {
                    return "Anchor:" + ta.anchor_id + "," + ta.x + "," + ta.y + "," + ta.z;
                }
                else
                {
                    return "Anchor:n,n,n,n";
                }
            }
            catch (Exception)
            {
                return "Anchor:e,e,e,e";
            }
        }
    }
}
