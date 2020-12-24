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
     * 命名空间：UWB_SP_TO_SOCKET.src.Service.Server
     * 文件名：  Debug
     * 版本号：  V1.0.0.0
     * 唯一标识：8d96293d-3772-4b6d-9833-9999b3d04e05
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 13:03:56
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 13:03:56
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service.Server
{

    class Debug
    {

#if DEBUG
        static public bool isDebug = SocketServer.isDebug;
#endif
        static public void DebugLog(string str)
        {
            Console.WriteLine(str);
        }
    }
}
