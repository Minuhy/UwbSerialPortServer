using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UWB_SP_TO_SOCKET.src.Service.Server
{
    //这边权限要public，不然在接下来的命令类那边是会报错的
    public class DataSession : AppSession<DataSession>
    {
        /// <summary>
        /// 客户端名字
        /// </summary>
        private string name = "";
        /// <summary>
        /// 是否已经登录
        /// </summary>
        public bool isLogin = false;

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        protected override void OnSessionStarted()
        {

#if DEBUG
                Debug.DebugLog("新连接！");
#endif 
            Console.WriteLine("新连接");
            //连接后发送欢迎信息
            this.Send("THIS:UWB,SERIALPORT,SOCKET");
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            //无法解析命令提示未知命令
            this.Send("UNKNOW:request");
        }

        protected override void HandleException(Exception e)
        {
            //程序异常信息
            this.Send("ERROR:{0}", e.Message);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            //连接被关闭时
            base.OnSessionClosed(reason);
        }
    }
}
