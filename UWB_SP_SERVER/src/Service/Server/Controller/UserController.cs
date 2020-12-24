using System;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Service.Server.UserGateway
     * 文件名：  UserController
     * 版本号：  V1.0.0.0
     * 唯一标识：132aa413-d620-4b6f-ab81-660ea4f7ea1a
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 13:13:20
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 13:13:20
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service.Server.Controller
{

    class UserController
    {
        public static int Login(String name, String pwd)
        {
            Console.WriteLine("登录：" + name + ":" + pwd);

            if (name == "admin" && pwd == "202020")
            {
                Console.WriteLine("成功！");
                return Comstant.USER_LOGIN_SUCCESS;
            }
            else if (name == "unity" && pwd == "20201025")
            {
                Console.WriteLine("成功！");
                return Comstant.USER_LOGIN_SUCCESS;
            }

            return Comstant.USER_LOGIN_FAIL;
        }
    }
}
