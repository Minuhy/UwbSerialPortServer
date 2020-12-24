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
     * 文件名：  GetAnchor
     * 版本号：  V1.0.0.0
     * 唯一标识：c1c8cd16-ce11-41e0-8f99-9cf96a4c83f9
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/22 16:15:31
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/22 16:15:31
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service.Server.Cmd
{
    /// <summary>
    /// GetAnchor:name,id
    /// </summary>
    public class GetAnchor : CommandBase<DataSession, StringRequestInfo>
    {
        public override void ExecuteCommand(DataSession session, StringRequestInfo requestInfo)
        {
            if (!session.isLogin)
            {
                session.Send("LOGIN:PLEASE");
                return;
            }

            if (requestInfo.Parameters.Length >= 2)
            {
                //如果名字对了
                if (requestInfo.Parameters[0] == session.GetName())
                {

#if DEBUG
                        Debug.DebugLog("显示端获取锚点位置！");
#endif 
                    session.Send(MessageGet.GetAnchorCmd(requestInfo.Parameters[1]));
                }
                else
                {
                    session.Send("ERROR:NAME");
                }
            }
        }
    }
}
