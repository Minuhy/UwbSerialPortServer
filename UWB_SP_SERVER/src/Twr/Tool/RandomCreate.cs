using System;
using UWB_SP_TO_SOCKET.src.Twr.Model;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Twr.Tool
     * 文件名：  RandomCreate
     * 版本号：  V1.0.0.0
     * 唯一标识：3433c8ab-9d3c-422a-bae4-a6709ea4f03f
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 15:27:44
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 15:27:44
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Twr.Tool
{
    class RandomCreate
    {
        public static bool isDebug = false;
        public static int min = 0;
        public static int max = 100;
        static long randseed;
        /* 实现伪随机数的支持 */
        static long Curl_rand()
        {
            long r;
            /* 返回一个无符号32位整型的伪随机数. */
            r = randseed = randseed * 1103515245 + 12345;
            return (r << 16) | ((r >> 16) & 0xFFFF);
        }

        static void Curl_srand()
        {
            /* 产生随机的伪随机数序列。 */
            randseed += DateTime.Now.Ticks;
            Curl_rand();
            Curl_rand();
            Curl_rand();
        }
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>一个随机数</returns>
        static double get_rand(int min, int max)
        {
            int temp = 0;
            if (min > max)
            {
                temp = min;
                min = max;
                max = temp;
            }
            if (min == max)
            {
                return (double)min;
            }

            double random = new System.Random().NextDouble();

            double res = (((Curl_rand() + (random * 100)) % ((max - min) * 10)) + min) / 10;

            if (isDebug)
            {
                Console.WriteLine("随机数：" + res);
            }

            if (res >= min && res <= max)
            {
                return res;
            }
            else
            {
                return get_rand(min, max);
            }
        }

        /// <summary>
        /// 获取3D坐标 
        /// </summary>
        /// <returns>返回一个3D坐标</returns>
        static Vec3dInfo get_random_3D_Coords()
        {
            Vec3dInfo local = new Vec3dInfo();
            local.x = get_rand(min, max);
            local.y = get_rand(min, max);
            local.z = get_rand(min, max);

            return local;
        }

        /// <summary>
        /// 获取一个球的随机信息 
        /// </summary>
        /// <returns>一个球的随机信息</returns>
        static VirtualenvInfo get_ball_local()
        {
            VirtualenvInfo qiu = new VirtualenvInfo(1);
            qiu.anchor[0] = get_random_3D_Coords();
            qiu.r[0] = get_rand(min, max);
            return qiu;
        }

        /// <summary>
        /// 计算两坐标的距离
        /// </summary>
        /// <param name="v1">坐标1</param>
        /// <param name="v2">坐标2</param>
        /// <returns>距离</returns>
        static double get_local_distance(Vec3dInfo v1, Vec3dInfo v2)
        {
            double dis = Math.Pow(Math.Pow(v1.x - v2.x, 2) + Math.Pow(v1.y - v2.y, 2) + Math.Pow(v1.z - v2.z, 2), 0.5);
            return dis;
        }

        /// <summary>
        /// 生成一个3锚点坐标定位模型
        /// </summary>
        /// <returns>3坐标定位模型</returns>
        public static VirtualenvInfo get_model()
        {
            Vec3dInfo tag;
            VirtualenvInfo model = new VirtualenvInfo();

            tag = get_random_3D_Coords();

            int i = 0;
            for (i = 0; i < model.GetLength(); i++)
            {
                model.anchor[i] = get_random_3D_Coords();
                model.r[i] = get_local_distance(tag, model.anchor[i]);
            }

            model.tag = tag;

            return model;
        }


    }
}
