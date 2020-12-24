using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Tools
     * 文件名：  TimeTool
     * 版本号：  V1.0.0.0
     * 唯一标识：e21b927d-5481-41fa-9e42-c4a4122907c5
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/20 22:29:18
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/20 22:29:18
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Tools
{

    class TimeTool
    {
        /// <summary>
        /// 获取时间戳的字符串，例如1599745856900
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStampStr()
        {
            return GetTimeStamp().ToString();
        }

        /// <summary>
        /// 获取时间戳的长整型，例如1599745856900
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }
        /// <summary>
        /// 获取时间和日期格式：yyyyMMddhhmmss
        /// </summary>
        /// <returns></returns>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyyMMddhhmmss");
        }

        /// <summary>
        /// 获取时间和日期格式：yyyy-MM-dd hh：mm：ss
        /// </summary>
        /// <returns></returns>
        public static string GetDateTime(string format)
        {
            return DateTime.Now.ToString(format);
        }
    }
}
