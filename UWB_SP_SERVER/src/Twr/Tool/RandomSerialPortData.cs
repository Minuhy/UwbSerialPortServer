using System;
using System.Collections.Generic;
using UWB_SP_TO_SOCKET.src.Twr.Model;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Twr.Tool
     * 文件名：  RandomSerialPortData
     * 版本号：  V1.0.0.0
     * 唯一标识：dbfe8420-84ef-43f8-89a8-501c9ab95c8f
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 15:28:25
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 15:28:25
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Twr.Tool
{

    class RandomSerialPortData
    {

        /// <summary>
        /// 解1
        /// </summary>
        Vec3dInfo result1;
        /// <summary>
        /// 解2
        /// </summary>
        Vec3dInfo result2;
        /// <summary>
        /// 最佳解
        /// </summary>
        Vec3dInfo resultBest;
        /// <summary>
        /// 模型
        /// </summary>
        VirtualenvInfo model;
        /// <summary>
        /// 失败次数
        /// </summary>
        long failedTimes;
        /// <summary>
        /// 模拟的次数
        /// </summary>
        long simulateTimes;
        /// <summary>
        /// 误差的次数
        /// </summary>
        long errorTimes;
        /// <summary>
        /// 最相近的解
        /// </summary>
        Vec3dInfo resultTag;

        public VirtualenvInfo DataSimulate()
        {
            return DataSimulate(1)[0];
        }
        /// <summary>
        /// 随机模拟
        /// </summary>
        public List<VirtualenvInfo> DataSimulate(int number)
        {
            List<VirtualenvInfo> vis = new List<VirtualenvInfo>();
            for (int ti = 0; ti < number; ti++)
            {
                VirtualenvInfo vi = new VirtualenvInfo();
                //目标点
                Vec3dInfo tag = new Vec3dInfo();
                //锚点
                Vec3dInfo[] anchor = new Vec3dInfo[4];
                //锚点到目标点的距离
                int[] radius = new int[4];
                //计算出来的解
                result1 = new Vec3dInfo();
                result2 = new Vec3dInfo();
                resultBest = new Vec3dInfo();

                simulateTimes++;
                LogOut("------------------------------>>>>>>" + simulateTimes + "<<<<<<------------------------------");

                /*-----------------生成随机数据-----------------*/

                //获取一个模型数据
                model = RandomCreate.get_model();
                LogOut(model.ToString());

                for (int i = 0; i < 3; i++)
                {
                    //写入半径
                    radius[i] = (int)(model.r[i] * 1000);
                    //写入坐标
                    anchor[i] = model.anchor[i];
                }
                //设置目标点坐标
                tag = model.tag;
                /*-----------------生成随机数据结束-----------------*/


                /*-----------------根据数据计算结果-----------------*/

                int rCode = FunctionTrilateration.GetLocation(ref resultBest, ref result1, ref result2, 3, ref anchor, ref radius);
                if (rCode == FunctionTrilateration.TRIL_3SPHERES)
                {
                    resultTag = new Vec3dInfo();

                    bool isHaveTag = false;

                    if (GetDistance(result1, model.tag) < 0.5)
                    {
                        //匹配解为1
                        resultTag = result1;
                        isHaveTag = true;
                    }

                    if (GetDistance(result2, model.tag) < 0.5)
                    {
                        //匹配解为2
                        resultTag = result2;
                        isHaveTag = true;
                    }
                    if (isHaveTag)
                    {
                        LogOut("匹配解：(" + resultTag.x.ToString("0.00") + "," + resultTag.y.ToString("0.00") + "," + resultTag.z.ToString("0.00") + ")");
                    }
                    else
                    {
                        LogOut("无匹配解！");
                        errorTimes++;
                    }
                    //解算成功
                    LogOut("X差：" + (result1.x - model.tag.x).ToString("0.00") + "，\tY差：" + (result1.y - model.tag.y).ToString("0.00") + "，\tZ差：" + (result1.z - model.tag.z).ToString("0.00") + "，\t总差：" + Math.Pow(Math.Pow(result1.x - model.tag.x, 2) + Math.Pow(result1.y - model.tag.y, 2) + Math.Pow(result1.z - model.tag.z, 2), 0.5).ToString("0.00"));
                    LogOut("X差：" + (result2.x - model.tag.x).ToString("0.00") + "，\tY差：" + (result2.y - model.tag.y).ToString("0.00") + "，\tZ差：" + (result2.z - model.tag.z).ToString("0.00") + "，\t总差：" + Math.Pow(Math.Pow(result2.x - model.tag.x, 2) + Math.Pow(result2.y - model.tag.y, 2) + Math.Pow(result2.z - model.tag.z, 2), 0.5).ToString("0.00"));

                    LogOut("解1：(" + result1.x.ToString("0.00") + "," + result1.y.ToString("0.00") + "," + result1.z.ToString("0.00") + ")");
                    LogOut("解2：(" + result2.x.ToString("0.00") + "," + result2.y.ToString("0.00") + "," + result2.z.ToString("0.00") + ")");
                }
                else
                {
                    //解算失败
                    failedTimes++;
                    LogOut("第" + failedTimes + "次解算失败！");
                }

                model.isDispose = true;
                model.tagId = 5;
                model.trueCount = 3;
                model.seq = 247;

                /*-----------------计算结果完成-----------------*/
                LogOut("\n统计：\t模拟次数：" + simulateTimes + "  \t误差次数：" + errorTimes + "  \t失败次数：" + failedTimes);
                LogOut("--------------------------------------------------------------------------\n\n\n");
            }

            return vis;
        }

        void LogOut(string str)
        {
            Console.WriteLine(str);
        }

        static double GetDistance(Vec3dInfo v1, Vec3dInfo v2)
        {
            double dis = Math.Pow(Math.Pow(v1.x - v2.x, 2) + Math.Pow(v1.y - v2.y, 2) + Math.Pow(v1.z - v2.z, 2), 0.5);
            return dis;
        }


    }
}
