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
     * 文件名：  VirtualenvInfo
     * 版本号：  V1.0.0.0
     * 唯一标识：eef9d221-dbb1-4403-8f2a-af2182ce29cc
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 15:25:48
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 15:25:48
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Twr.Model
{
    class VirtualenvInfo
    {
        /// <summary>
        /// 标记是否被处理，常常用于表示是否是完整的模型
        /// </summary>
        public bool isDispose = false;
        /// <summary>
        /// 处理序列号
        /// </summary>
        public byte seq = 0;
        /// <summary>
        /// 模型ID
        /// </summary>
        public int id = 0;
        public int tagId = 0;
        public Vec3dInfo[] anchor;
        public double[] r;
        public Vec3dInfo tag;

        /// <summary>
        /// 实际的锚点数量
        /// </summary>
        public int trueCount = 0;

        public int GetLength()
        {
            int l1 = anchor.Length;
            int l2 = r.Length;
            if (l1 > l2)
            {
                return l2;
            }
            else
            {
                return l1;
            }
        }

        public VirtualenvInfo()
            : this(4)
        {
        }

        public VirtualenvInfo(int size)
        {
            anchor = new Vec3dInfo[size];
            r = new double[size];

            for (int i = 0; i < size; i++)
            {
                anchor[i] = new Vec3dInfo();
                r[i] = new double();
                r[i] = 0;
            }

            tag = new Vec3dInfo();
        }

        public override string ToString()
        {
            string info = "模型信息：\n";
            for (int i = 0; i < this.GetLength(); i++)
            {
                info = info + "半径" + i + "：" + r[i].ToString("0.0000") + "\n";
                info = info + "球" + i + "：(" + anchor[i].x + "," + anchor[i].y + "," + anchor[i].z + ")\n\n";
            }
            info = info + "中心点：(" + tag.x + "," + tag.y + "," + tag.z + ")\n";
            info = info + "目标点ID：" + tagId + "\n";
            info = info + "序列号：" + seq;
            return info;
        }
    }
}
