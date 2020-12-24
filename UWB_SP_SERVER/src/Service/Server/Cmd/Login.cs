using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWB_SP_TO_SOCKET.src.Service.Server.Controller;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Service.Server.Command
     * 文件名：  Login
     * 版本号：  V1.0.0.0
     * 唯一标识：b20b957b-9cfa-49c0-a069-62b1fb3850a9
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 13:08:38
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 13:08:38
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service.Server.Cmd
{

    public class Login : CommandBase<DataSession, StringRequestInfo>
    {
        public override void ExecuteCommand(DataSession session, StringRequestInfo requestInfo)
        {
            //如果参数大于两个
            if (requestInfo.Parameters.Length >= 2)
            {
                if (UserController.Login(requestInfo.Parameters[0], requestInfo.Parameters[1]) == Comstant.USER_LOGIN_SUCCESS)
                {
                    //登录成功
                    session.SetName(requestInfo.Parameters[0]);
                    session.isLogin = true;
                    session.Send("LOGIN:OK");


#if DEBUG
                        Debug.DebugLog("客户端 " + session.GetName() + " 已登录！");
#endif 
                }
                else
                {

#if DEBUG
                        Debug.DebugLog("客户端 " + session.GetName() + " 认证失败，连接关闭！");
#endif
                    //登录失败
                    session.Send("LOGIN:NO");
                    session.Close();
                }
            }
            else
            {

#if DEBUG
                    Debug.DebugLog("客户端登录参数不正确，连接关闭！");
#endif 
                //参数不正确
                session.Send("LOGIN:ERROR");
                session.Close();
            }
        }
    }
}
