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
     * 文件名：  ByteAutoSize
     * 版本号：  V1.0.0.0
     * 唯一标识：11cc5ebd-727d-4e29-8234-75d39b46859f
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/20 17:00:12
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/20 17:00:12
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Tools
{
    /// <summary>
    /// 把字节数自动转换成b、k、m、g等单位
    /// </summary>
    class ByteAutoSize
    {
        internal static string GetSize(ulong b)
        {

            if (b < 1000)
            {
                return b + "B";
            }
            else if (b < 1000000)
            {
                return ((float)b / 1000f).ToString("F2") + "K";
            }
            else if (b < 1000000000)
            {
                return ((float)b / 1000000f).ToString("F2") + "M";
            }
            else if (b < 1000000000000)
            {
                return ((float)b / 1000000000f).ToString("F2") + "G";
            }
            else if (b < 1000000000000000)
            {
                return ((float)b / 1000000000000000f).ToString("F2") + "T";
            }
            else
            {
                return b.ToString();
            }
        }
    }
}
