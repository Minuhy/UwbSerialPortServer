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
     * 命名空间：UWB_SP_TO_SOCKET.src.Service.Server.Cmd
     * 文件名：  Heartbeat
     * 版本号：  V1.0.0.0
     * 唯一标识：4d15c00a-74ca-4e64-9030-599c68bc9266
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/24 15:21:38
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/24 15:21:38
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service.Server.Cmd
{

    public class Heartbeat: CommandBase<DataSession, StringRequestInfo>
    {
        public override void ExecuteCommand(DataSession session, StringRequestInfo requestInfo)
        {
            if (session.isLogin)
            {
                //如果参数大于一个
                if (requestInfo.Parameters.Length >= 1)
                {
                    if (requestInfo.Parameters[0] == session.GetName())
                    {
                        session.Send("HEARTBEAT:OK");
                        return;
                    }
                }
            }

            session.Send("HEARTBEAT:NO");
            return;

        }
    }
}
