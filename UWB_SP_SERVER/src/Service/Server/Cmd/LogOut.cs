using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
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
     * 命名空间：UWB_SP_TO_SOCKET.src.Service.Server.Command
     * 文件名：  LogOut
     * 版本号：  V1.0.0.0
     * 唯一标识：05b78864-ec35-401f-b3af-6ae1d72af832
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 13:06:56
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 13:06:56
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service.Server.Cmd
{
    /// <summary>
    /// 登出
    /// </summary>
    public class LogOut : CommandBase<DataSession, StringRequestInfo>
    {
        public override void ExecuteCommand(DataSession session, StringRequestInfo requestInfo)
        {
            session.Send("LOGIN:BEY");

#if DEBUG
                Debug.DebugLog("客户端 " + session.GetName() + " 已退出！");
#endif 
            session.Close();
        }
    }
}
