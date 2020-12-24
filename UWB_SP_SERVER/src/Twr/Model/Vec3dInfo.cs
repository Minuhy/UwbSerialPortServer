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
     * 命名空间：UWB_SP_TO_SOCKET.src.Twr.Model
     * 文件名：  Vector3
     * 版本号：  V1.0.0.0
     * 唯一标识：295be723-1297-4563-8eba-bc9518356b5e
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 13:51:25
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 13:51:25
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Twr.Model
{

    class Vec3dInfo
    {
                /// <summary>
                /// ID，坐标的ID
                /// </summary>
                //public int id;
                /// <summary>
                /// 坐标的值
                /// </summary>
                public double x, y, z;
                public Vec3dInfo()
                {
                        x = 0;
                        y = 0;
                        z = 0;
                }

                public Vec3dInfo(double x, double y, double z)
                {
                        this.x = x;
                        this.y = y;
                        this.z = z;
                }

                public override string ToString()
                {
                        return "(" + x.ToString("0.00") + "," + y.ToString("0.00") + "," + z.ToString("0.00") + ")";
                }
    }
}
