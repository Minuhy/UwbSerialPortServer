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
     * 文件名：  GetLocal
     * 版本号：  V1.0.0.0
     * 唯一标识：ed12a91b-c8bd-474c-868a-79c301863942
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 13:38:35
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 13:38:35
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service.Server.Cmd
{
    /// <summary>
    /// GetLocal:name,id
    /// </summary>
    public class GetLocal : CommandBase<DataSession, StringRequestInfo>
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
                        Debug.DebugLog("显示端获取标签位置！");
#endif 


                    session.Send(MessageGet.GetLocalCmd(requestInfo.Parameters[1]));
                }
                else
                {
                    session.Send("ERROR:NAME");
                }
            }
        }
    }
}
