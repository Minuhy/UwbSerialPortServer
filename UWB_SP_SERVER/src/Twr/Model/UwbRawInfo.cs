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
     * 文件名：  UwbRawInfo
     * 版本号：  V1.0.0.0
     * 唯一标识：fa01442b-d955-4426-8013-99f3deff411c
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 15:23:58
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 15:23:58
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Twr.Model
{

    class UwbRawInfo
    {
        /// <summary>
        /// 原始帧数据
        /// </summary>
        public byte[] frame;
        /// <summary>
        /// 帧类型
        /// </summary>
        public byte frameType;
        /// <summary>
        /// 序列号
        /// </summary>
        public byte seq;
        /// <summary>
        /// 目标点ID
        /// </summary>
        public byte tagId;
        /// <summary>
        /// 原始半径
        /// </summary>
        public uint[] rRaw;
        /// <summary>
        /// 转换半径
        /// </summary>
        public double[] r;

        public uint lnum;

        public UwbRawInfo()
            : this(4)
        {

        }

        public UwbRawInfo(int size)
        {
            rRaw = new uint[size];
            r = new double[size];
            for (int i = 0; i < size; i++)
            {
                rRaw[i] = 0;
                r[i] = 0;
            }
        }

    }
}
