#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2020  NJRN 保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-NU1L2DL
 * 公司名称：
 * 命名空间：UWB_SP_TO_SOCKET.src.Service.Server.Cmd
 * 唯一标识：b03088b2-fb22-4154-84e4-18136d64cf55
 * 文件名：GetAnnouncement
 * 当前用户域：DESKTOP-NU1L2DL
 * 
 * 创建者：Minuy
 * 电子邮箱：yuminzhe2020@outlook.com
 * 创建时间：2020/12/15 21:06:22
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>

using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;


namespace UWB_SP_TO_SOCKET.src.Service.Server.Cmd
{
    /// <summary>
    /// GetAnnouncement 的摘要说明
    /// 获取公告命令
    /// GetAnnouncement:name
    /// </summary>
    public class GetAnnouncement : CommandBase<DataSession, StringRequestInfo>
    {
        public override void ExecuteCommand(DataSession session, StringRequestInfo requestInfo)
        {
            if (!session.isLogin)
            {
                session.Send("LOGIN:PLEASE");
                return;
            }

            if (requestInfo.Parameters.Length >= 1)
            {
                //如果名字对了
                if (requestInfo.Parameters[0] == session.GetName())
                {
#if DEBUG
                    Debug.DebugLog("显示端获取锚点位置！");
#endif 
                    string val = AnnouncementRes.GetAnnouncement();

                    session.Send("Announcement:"+val.Length+","+val);
                }
                else
                {
                    session.Send("ERROR:NAME");
                }
            }
        }
    }
}
