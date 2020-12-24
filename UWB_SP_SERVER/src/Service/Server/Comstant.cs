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
     * 文件名：  Comstant
     * 版本号：  V1.0.0.0
     * 唯一标识：f8df0292-7dbb-41e9-b8d4-538f1181f6a9
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 13:02:30
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 13:02:30
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Service.Server
{

    class Comstant
    {

        public const int USER_LOGIN_FAIL = 0;
        public const int USER_LOGIN_SUCCESS = 1;


        int eibId;
        int bibId;
        static Comstant comstant;
        private Comstant()
        {

            eibId = 1;
            bibId = 1;

        }
        public static Comstant GetComstant()
        {
            if (comstant == null)
            {
                comstant = new Comstant();
            }

            return comstant;
        }

        public int GetBibID()
        {
            return bibId++;
        }

        public int GetEibID()
        {
            return eibId++;
        }
    }
}
