using System;
using UWB_SP_TO_SOCKET.src.Twr.Model;

/************************************************************************************
     * 版权所有(c) 2020  保留所有权利。
     * CLR版本： 4.0.30319.42000
     * 机器名称：DESKTOP-VLH6HNS
     * 公司名称：
     * 命名空间：UWB_SP_TO_SOCKET.src.Twr.Tool
     * 文件名：  FunctionTrilateration
     * 版本号：  V1.0.0.0
     * 唯一标识：7b7d7dee-ed21-437a-8be4-14be72ec529c
     * 当前的用户域：DESKTOP-VLH6HNS
     * 创建人：  Minuy
     * 电子邮箱：minuy17@163.com
     * 创建时间：2020/10/21 15:26:59
     * 描述：
     * =====================================================================
     * 修改时间：2020/10/21 15:26:59
     * 修改人  ： 
     * 版本号  ： V1.0.0.0
     * 描述    ：
    *************************************************************************************/
namespace UWB_SP_TO_SOCKET.src.Twr.Tool
{

    class FunctionTrilateration
    {
        public static bool isDebug = false;

        public const int TRILATERATION = 1;

        public const int REGRESSION_NUM = 10;
        public const double SPEED_OF_LIGHT = 299702547.0f;// 在空气中的单位是m/s
        public const int NUM_ANCHORS = 5;
        public const int REF_ANCHOR = 5;//锚点id是1、2、3、4、5等等(不要从0开始!)


        public const int TRIL_3SPHERES = 3;
        public const int TRIL_4SPHERES = 4;

        private const double MAXZERO = 0.001f;//最大的非负数仍然被认为是零

        private const int ERR_TRIL_CONCENTRIC = -1;
        private const int ERR_TRIL_COLINEAR_2SOLUTIONS = -2;
        private const int ERR_TRIL_SQRTNEGNUMB = -3;
        private const int ERR_TRIL_NOINTERSECTION_SPHERE4 = -4;
        private const int ERR_TRIL_NEEDMORESPHERE = -5;

        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="str"></param>
        public static void logout(string str, string name)
        {
            if (isDebug)
            {
                Console.WriteLine(str + ":" + name + ":" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);
            }
        }

        /// <summary>
        /// 返回两个向量的差，(vector1 - vector2)。
        /// </summary>
        /// <param name="vector1">被减数</param>
        /// <param name="vector2">减数</param>
        /// <returns>差的结果</returns>
        public static Vec3dInfo vdiff(Vec3dInfo vector1, Vec3dInfo vector2)
        {
            Vec3dInfo v = new Vec3dInfo();
            v.x = vector1.x - vector2.x;
            v.y = vector1.y - vector2.y;
            v.z = vector1.z - vector2.z;
            return v;
        }

        /// <summary>
        /// 返回两个向量的和。
        /// </summary>
        /// <param name="vector1">加数1</param>
        /// <param name="vector2">加数2</param>
        /// <returns>和的结果</returns>
        public static Vec3dInfo vsum(Vec3dInfo vector1, Vec3dInfo vector2)
        {
            Vec3dInfo v = new Vec3dInfo();
            v.x = vector1.x + vector2.x;
            v.y = vector1.y + vector2.y;
            v.z = vector1.z + vector2.z;
            return v;
        }

        /// <summary>
        /// 向量乘以一个数。
        /// </summary>
        /// <param name="vector">向量</param>
        /// <param name="n">乘数</param>
        /// <returns>乘出的结果</returns>
        public static Vec3dInfo vmul(Vec3dInfo vector, double n)
        {
            Vec3dInfo v = new Vec3dInfo();
            v.x = vector.x * n;
            v.y = vector.y * n;
            v.z = vector.z * n;
            return v;
        }

        /// <summary>
        /// 向量除以一个数。
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static Vec3dInfo vdiv(Vec3dInfo vector, double n)
        {
            Vec3dInfo v = new Vec3dInfo();
            v.x = vector.x / n;
            v.y = vector.y / n;
            v.z = vector.z / n;
            return v;
        }

        /// <summary>
        /// 返回欧几里德范数。
        /// </summary>
        /// <param name="v1">向量1</param>
        /// <param name="v2">向量2</param>
        /// <returns>两向量的距离</returns>
        public static double vdist(Vec3dInfo v1, Vec3dInfo v2)
        {
            double xd = v1.x - v2.x;
            double yd = v1.y - v2.y;
            double zd = v1.z - v2.z;
            return Math.Sqrt(xd * xd + yd * yd + zd * zd);
        }

        /// <summary>
        /// 返回欧几里德范数。
        /// </summary>
        /// <param name="vector">向量</param>
        /// <returns>向量到原点的距离</returns>
        public static double vnorm(Vec3dInfo vector)
        {
            return Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }

        /// <summary>
        /// 返回两个向量的点积。
        /// </summary>
        /// <param name="vector1">向量1</param>
        /// <param name="vector2">向量2</param>
        /// <returns>点积</returns>
        public static double dot(Vec3dInfo vector1, Vec3dInfo vector2)
        {
            return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
        }

        /// <summary>
        /// 用另一个向量来替换它的外积。
        /// </summary>
        /// <param name="vector1">向量1</param>
        /// <param name="vector2">向量2</param>
        /// <returns>外积</returns>
        public static Vec3dInfo cross(Vec3dInfo vector1, Vec3dInfo vector2)
        {
            Vec3dInfo v = new Vec3dInfo();
            v.x = vector1.y * vector2.z - vector1.z * vector2.y;
            v.y = vector1.z * vector2.x - vector1.x * vector2.z;
            v.z = vector1.x * vector2.y - vector1.y * vector2.x;
            return v;
        }

        /// <summary>
        /// 返回0-1之间的GDOP(精度的几何稀释率)率。
        /// GDOP率越低，交线精度越高。
        /// </summary>
        /// <param name="tag">目标坐标</param>
        /// <param name="p1">向量1</param>
        /// <param name="p2">向量2</param>
        /// <param name="p3">向量3</param>
        /// <returns>几何因子</returns>
        public static double gdoprate(Vec3dInfo tag, Vec3dInfo p1, Vec3dInfo p2, Vec3dInfo p3)
        {
            Vec3dInfo ex = new Vec3dInfo();
            Vec3dInfo t1 = new Vec3dInfo();
            Vec3dInfo t2 = new Vec3dInfo();
            Vec3dInfo t3 = new Vec3dInfo();
            double h, gdop1, gdop2, gdop3, result;

            ex = vdiff(p1, tag);
            h = vnorm(ex);
            t1 = vdiv(ex, h);

            ex = vdiff(p2, tag);
            h = vnorm(ex);
            t2 = vdiv(ex, h);

            ex = vdiff(p3, tag);
            h = vnorm(ex);
            t3 = vdiv(ex, h);

            gdop1 = Math.Abs(dot(t1, t2));
            gdop2 = Math.Abs(dot(t2, t3));
            gdop3 = Math.Abs(dot(t3, t1));

            if (gdop1 < gdop2)
            {
                result = gdop2;
            }
            else
            {
                result = gdop1;
            }

            if (result < gdop3)
            {
                result = gdop3;
            }

            return result;
        }

        /// <summary>
        /// 与半径为r的球体sc相交，直线为p1-p2。
        /// 如果成功返回零，否则返回负错误。
        /// mu1和mu2是常数来求交点。
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="sc"></param>
        /// <param name="r"></param>
        /// <param name="mu1"></param>
        /// <param name="mu2"></param>
        /// <returns></returns>
        public static int sphereline(Vec3dInfo p1, Vec3dInfo p2, Vec3dInfo sc, double r, ref double mu1, ref double mu2)
        {
            double a, b, c;
            double bb4ac;
            Vec3dInfo dp = new Vec3dInfo();

            dp.x = p2.x - p1.x;
            dp.y = p2.y - p1.y;
            dp.z = p2.z - p1.z;

            a = dp.x * dp.x + dp.y * dp.y + dp.z * dp.z;

            b = 2 * (dp.x * (p1.x - sc.x) + dp.y * (p1.y - sc.y) + dp.z * (p1.z - sc.z));

            c = sc.x * sc.x + sc.y * sc.y + sc.z * sc.z;
            c += p1.x * p1.x + p1.y * p1.y + p1.z * p1.z;
            c -= 2 * (sc.x * p1.x + sc.y * p1.y + sc.z * p1.z);
            c -= r * r;

            bb4ac = b * b - 4 * a * c;

            if (Math.Abs(a) == 0 || bb4ac < 0)
            {
                mu1 = 0.0;
                mu2 = 0.0;
                return -1;
            }

            mu1 = (-b + Math.Sqrt(bb4ac)) / (2.0 * a);
            mu2 = (-b - Math.Sqrt(bb4ac)) / (2.0 * a);

            return 0;
        }

        /// <summary>
        /// 如果用3个球来完成返回 TRIL_3SPHERES
        /// 如果用4个球来完成返回 TRIL_4SPHERES
        /// 对于 TRIL_3SPHERES,有两个解:result1和result2
        /// 对于 TRIL_4SPHERES, 只有一个结果: best_solution
        /// 其他错误返回负数 
        /// 如果只使用3个球，在p1、p2、p3或p4之间的任何位置传一个任意的球的信息 
        /// 最后一个参数是被认为为零的最大非负数;它有点类似于机器epsilon(但也包括在内)。
        /// </summary>
        /// <param name="result1"></param>
        /// <param name="result2"></param>
        /// <param name="best_solution"></param>
        /// <param name="p1"></param>
        /// <param name="r1"></param>
        /// <param name="p2"></param>
        /// <param name="r2"></param>
        /// <param name="p3"></param>
        /// <param name="r3"></param>
        /// <param name="p4"></param>
        /// <param name="r4"></param>
        /// <param name="maxzero"></param>
        /// <returns></returns>
        public static int trilateration(ref Vec3dInfo result1,
                                                ref Vec3dInfo result2,
                                                ref Vec3dInfo best_solution,
                                                Vec3dInfo p1, double r1,
                                                Vec3dInfo p2, double r2,
                                                Vec3dInfo p3, double r3,
                                                Vec3dInfo p4, double r4,
                                                double maxzero)
        {
            Vec3dInfo ex = new Vec3dInfo();
            Vec3dInfo ey = new Vec3dInfo();
            Vec3dInfo ez = new Vec3dInfo();
            Vec3dInfo t1 = new Vec3dInfo();
            Vec3dInfo t2 = new Vec3dInfo();
            Vec3dInfo t3 = new Vec3dInfo();

            double h = 0, i = 0, j = 0, x = 0, y = 0, z = 0, t = 0;
            double mu1 = 0, mu2 = 0, mu = 0;
            int result = 0;

            /*********** 从前三个球体中找出两个点 **********/

            // 如果在前3个球中至少有2个同心球，那么计算可能不会继续，以错误-1丢弃它

            /* h = |p3 - p1|, ex = (p3 - p1) / |p3 - p1| */
            ex = vdiff(p3, p1); // 矢量 p13 
            h = vnorm(ex); // 标量 p13，得到前两个球球心的距离 
            if (h <= maxzero)
            {
                /* p1和p3是同心的，不利于得到精确的交点 */
                logout("concentric13 return -1\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                logout("错误：球1和球3同心！返回 -1。\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return ERR_TRIL_CONCENTRIC;
            }

            /* h = |p3 - p2|, ex = (p3 - p2) / |p3 - p2| */
            ex = vdiff(p3, p2); // 向量 p23
            h = vnorm(ex); // 标量 p23，得到另外两个球球心的距离 
            if (h <= maxzero)
            {
                /* p2和p3是同心的，不利于得到精确的交点 */
                logout("concentric23 return -1\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                logout("错误：球2和球3同心！返回 -1。\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return ERR_TRIL_CONCENTRIC;
            }

            /* h = |p2 - p1|, ex = (p2 - p1) / |p2 - p1| */
            ex = vdiff(p2, p1); // 向量 p12
            h = vnorm(ex); // 标量 p12
            if (h <= maxzero)
            {
                /* p2和p1是同心的，不利于得到精确的交点 */
                logout("concentric12 return -1\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                logout("错误：球2和球1同心！返回 -1。\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return ERR_TRIL_CONCENTRIC;
            }

            ex = vdiv(ex, h); // 单位向量ex相对于p1(新坐标系)

            /* t1 = p3 - p1, t2 = ex (ex . (p3 - p1)) */
            t1 = vdiff(p3, p1); // 向量 p13
            i = dot(ex, t1); // 在ex方向上的标量t1
            t2 = vmul(ex, i); // 共线向量到p13的长度为i

            /* ey = (t1 - t2), t = |t1 - t2| */
            ey = vdiff(t1, t2); // 向量t21垂直于t1
            t = vnorm(ey); // 标量 t21
            if (t > maxzero)
            {
                /* ey = (t1 - t2) / |t1 - t2| */
                ey = vdiv(ey, t); // 单位向量ey相对于p1(新坐标系)

                /* j = ey . (p3 - p1) */
                j = dot(ey, t1); // 标量t1在ey方向上
            }
            else
                j = 0.0;

            /* 说明: t <= maxzero 意味着 j = 0.0. */
            if (Math.Abs(j) <= maxzero)
            {

                /* 点p1 + (沿轴r1)是交点吗? */
                t2 = vsum(p1, vmul(ex, r1));
                if (Math.Abs(vnorm(vdiff(p2, t2)) - r2) <= maxzero &&
                Math.Abs(vnorm(vdiff(p3, t2)) - r3) <= maxzero)
                {
                    /* 是的，t2是唯一的交点。 */
                    if (result1 != null)
                    {
                        result1 = t2;
                    }

                    if (result2 != null)
                    {
                        result2 = t2;
                    }

                    return TRIL_3SPHERES;
                }

                /* 点p1 + (沿轴-r1)是交点吗? */
                t2 = vsum(p1, vmul(ex, -r1));
                if (Math.Abs(vnorm(vdiff(p2, t2)) - r2) <= maxzero &&
                Math.Abs(vnorm(vdiff(p3, t2)) - r3) <= maxzero)
                {
                    /* 是的，t2是唯一的交点。 */
                    if (result1 != null)
                        result1 = t2;
                    if (result2 != null)
                        result2 = t2;
                    return TRIL_3SPHERES;
                }
                /* p1 p2 p3共线的解不止一个 */
                return ERR_TRIL_COLINEAR_2SOLUTIONS;
            }

            /* ez = ex x ey */
            ez = cross(ex, ey); // 单位向量ez相对于p1(新坐标系)

            x = (r1 * r1 - r2 * r2) / (2 * h) + h / 2;
            y = (r1 * r1 - r3 * r3 + i * i) / (2 * j) + j / 2 - x * i / j;
            z = r1 * r1 - x * x - y * y;
            if (z < -maxzero - 100)
            {
                /* 解是无效的，负数的平方根 */
                return ERR_TRIL_SQRTNEGNUMB;
            }
            else
            {
                if (z > 0.0)
                {
                    z = Math.Sqrt(z);
                }
                else
                {
                    z = 0.0;
                }
            }

            /* t2 = p1 + x ex + y ey */
            t2 = vsum(p1, vmul(ex, x));
            t2 = vsum(t2, vmul(ey, y));

            /* result1 = p1 + x ex + y ey + z ez */
            if (result1 != null)
                result1 = vsum(t2, vmul(ez, z));

            /* result1 = p1 + x ex + y ey - z ez */
            if (result2 != null)
                result2 = vsum(t2, vmul(ez, -z));

            /*********** 从前三个球找到两个点的结束 **********/
            /********* RESULT1和RESULT2为解，或者错误 *********/


            /************* 通过4球体来修正结果  ***********/

            // 检查球体4与球体1、2和3是否同心 
            // 如果它与其中一个同心，那么球面4不能用来确定最佳解决方案，返回-1

            /* h = |p4 - p1|, ex = (p4 - p1) / |p4 - p1| */
            ex = vdiff(p4, p1); // 向量 p14
            h = vnorm(ex); // 标量（距离） p14
            if (h <= maxzero)
            {
                /* p1和p4同心圆，不利于得到精确的交点 */
                logout("concentric14 return 0\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                logout("警告：球4和球1同心！返回 0。\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return TRIL_3SPHERES;
            }
            /* h = |p4 - p2|, ex = (p4 - p2) / |p4 - p2| */
            ex = vdiff(p4, p2); // 向量 p24
            h = vnorm(ex); // 标量（距离） p24
            if (h <= maxzero)
            {
                /* p2和p4同心圆，不利于得到精确的交点 */
                logout("concentric24 return 0\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                logout("警告：球4和球2同心！返回 0。\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return TRIL_3SPHERES;
            }
            /* h = |p4 - p3|, ex = (p4 - p3) / |p4 - p3| */
            ex = vdiff(p4, p3); // 向量 p34
            h = vnorm(ex); // 标量（距离） p34
            if (h <= maxzero)
            {
                /* p3和p4同心圆，不利于得到精确的交点 */
                logout("concentric34 return 0\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                logout("警告：球4和球3同心！返回 0。\n", System.Reflection.MethodBase.GetCurrentMethod().Name);
                return TRIL_3SPHERES;
            }

            // 如果球面4不与任何球面同心，则可以得到最佳解
            /* 求出i作为result1到p4的距离 */
            t3 = vdiff(result1, p4);
            i = vnorm(t3);
            /* 求出h为result2到p4的距离 */
            t3 = vdiff(result2, p4);
            h = vnorm(t3);

            /* 选择结果t1作为离球体中心最近的点4 */
            if (i > h)
            {
                best_solution = result1;
                result1 = result2;
                result2 = best_solution;
            }

            int count4 = 0;
            double rr4 = r4;
            result = 1;
            /* 向量与球体4相交 */
            while (result != 0 && count4 < 10)
            {
                result = sphereline(result1, result2, p4, rr4, ref mu1, ref  mu2);
                rr4 += 0.1;
                count4++;
            }

            if (result != 0)
            {

                /* 球面4和梯度为result1-result2的直线没有交集! */
                best_solution = result1; // 结果t1是球面4的更接近解

            }
            else
            {

                if (mu1 < 0 && mu2 < 0)
                {

                    /* 如果mu1和mu2都小于0 */
                    /* result1-result2 线段在球面4外，无交点 */
                    if (Math.Abs(mu1) <= Math.Abs(mu2)) mu = mu1; else mu = mu2;
                    /* h = |result2 - result1|, ex = (result2 - result1) / |result2 - result1| */
                    ex = vdiff(result2, result1); // 向量 result1-result2
                    h = vnorm(ex); // 标量 result1-result2
                    ex = vdiv(ex, h); // 单位向量ex相对于result1(新坐标系)
                    /* 50-50 mu纠错 */
                    mu = 0.5 * mu;
                    /* t2指向交点 */
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    /* 最佳解 = t2 */
                    best_solution = t2;

                }
                else if ((mu1 < 0 && mu2 > 1) || (mu2 < 0 && mu1 > 1))
                {

                    /* 如果mu1小于0而mu2大于1，或者反过来 */
                    /* result1-result2 线段在球体4内，无交点 */
                    if (mu1 > mu2) mu = mu1; else mu = mu2;
                    /* h = |result2 - result1|, ex = (result2 - result1) / |result2 - result1| */
                    ex = vdiff(result2, result1); // 向量 result1-result2
                    h = vnorm(ex); // 标量 result1-result2
                    ex = vdiv(ex, h); // 单位向量ex相对于result1(新坐标系)
                    /* t2指向交点 */
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    /* 向量t2-result2对t3的长度进行50-50的误差校正 */
                    t3 = vmul(vdiff(result2, t2), 0.5);
                    /* 最佳解 = t2 + t3 */
                    best_solution = vsum(t2, t3);

                }
                else if (((mu1 > 0 && mu1 < 1) && (mu2 < 0 || mu2 > 1))
              || ((mu2 > 0 && mu2 < 1) && (mu1 < 0 || mu1 > 1)))
                {

                    /* 如果一个在0到1之间，另一个不在 */
                    /* 结果t1-结果t2线段与球面4相交于一点 */
                    if (mu1 >= 0 && mu1 <= 1) mu = mu1; else mu = mu2;
                    /* 加或减0.5*mu，使误差均匀分布在每个球上 */
                    if (mu <= 0.5) mu -= 0.5 * mu; else mu -= 0.5 * (1 - mu);
                    /* h = |result2 - result1|, ex = (result2 - result1) / |result2 - result1| */
                    ex = vdiff(result2, result1); // 向量 result1-result2
                    h = vnorm(ex); // 标量 result1-result2
                    ex = vdiv(ex, h); // 单位向量ex相对于result1(新坐标系)
                    /* t2指向交点 */
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    /* 最优解 = t2 */
                    best_solution = t2;

                }
                else if (mu1 == mu2)
                {

                    // 如果mu1和mu2都在0和1之间，并且mu1 = mu2
                    // result1-result2 线段在一点与球面4相切 
                    mu = mu1;
                    // 加或减0.5*mu，使误差均匀分布在每个球上
                    if (mu <= 0.25) mu -= 0.5 * mu;
                    else if (mu <= 0.5) mu -= 0.5 * (0.5 - mu);
                    else if (mu <= 0.75) mu -= 0.5 * (mu - 0.5);
                    else mu -= 0.5 * (1 - mu);
                    ex = vdiff(result2, result1); // 向量 result1-result2
                    h = vnorm(ex); // 标量 result1-result2
                    ex = vdiv(ex, h); // 单位向量ex相对于result1(新坐标系)
                    // t2指向交点
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    // 最优解 = t2
                    best_solution = t2;

                }
                else
                {
                    // 如果mu1和mu2都在0和1之间
                    // result1-result2 线段与球面4相交于两点
                    mu = mu1 + mu2;
                    ex = vdiff(result2, result1); // 向量 result1-result2
                    h = vnorm(ex); // 标量 result1-result2
                    ex = vdiv(ex, h); // 单位向量ex相对于result1(新坐标系)
                    // 对mu进行50-50的误差校正
                    mu = 0.5 * mu;
                    // t2指向交点
                    t2 = vmul(ex, mu * h);
                    t2 = vsum(result1, t2);
                    // 最优解 = t2
                    best_solution = t2;
                }
            }
            return TRIL_4SPHERES;
            /******** 通过4球体来修正结果结束 *********/
        }

        /// <summary>
        /// 这个函数调用三边运算来得到最好的解决方案。
        /// 
        /// 如果任意三个球体不能产生有效解，则增加每个距离以确保相交发生。
        /// 通过返回 TRIL_3SPHERES 或者 TRIL_4SPHERES 来确定选择了那种三边测量算法 
        /// 对于 TRIL_3SPHERES, 有两个解 solution1和solution2 
        /// 对于 TRIL_4SPHERES, 有一个解best_solution 
        /// 
        /// </summary>
        /// <param name="solution1">解1</param>
        /// <param name="solution2">解2</param>
        /// <param name="best_solution">最优解</param>
        /// <param name="nosolution_count">通过增加球体的直径来找到相交前失败的尝试次数。</param>
        /// <param name="best_3derror"></param>
        /// <param name="best_gdoprate"></param>
        /// <param name="p1">锚点1</param>
        /// <param name="r1">锚点1到定位点的距离</param>
        /// <param name="p2">锚点2</param>
        /// <param name="r2">锚点2到定位点的距离</param>
        /// <param name="p3">锚点3</param>
        /// <param name="r3">锚点3到定位点的距离</param>
        /// <param name="p4">锚点4</param>
        /// <param name="r4">锚点4到定位点的距离</param>
        /// <param name="combination"></param>
        /// <returns></returns>
        public static int deca_3dlocate(ref Vec3dInfo solution1,
                                                ref Vec3dInfo solution2,
                                                ref Vec3dInfo best_solution,
                                                ref int nosolution_count,
                                                ref double best_3derror,
                                                ref double best_gdoprate,
                                                Vec3dInfo p1, double r1,
                                                Vec3dInfo p2, double r2,
                                                Vec3dInfo p3, double r3,
                                                Vec3dInfo p4, double r4,
                                                ref int combination)
        {
            Vec3dInfo o1, o2, solution, ptemp;
            o1 = new Vec3dInfo();
            o2 = new Vec3dInfo();
            solution = new Vec3dInfo();
            ptemp = new Vec3dInfo();

            Vec3dInfo solution_compare1, solution_compare2;
            solution_compare1 = new Vec3dInfo();
            solution_compare2 = new Vec3dInfo();

            double rtemp = 0;
            double gdoprate_compare1 = 0, gdoprate_compare2 = 0;
            double ovr_r1 = 0, ovr_r2 = 0, ovr_r3 = 0, ovr_r4 = 0;
            int overlook_count = 0, combination_counter = 0;
            int trilateration_errcounter = 0, trilateration_mode34 = 0;
            int success = 0, concentric = 0, result = 0;

            trilateration_errcounter = 0;
            trilateration_mode34 = 0;

            combination_counter = 4; // 四个领域的组合

            best_gdoprate = 1; // 初始化最坏的几何因子
            gdoprate_compare1 = 1; gdoprate_compare2 = 1;
            solution_compare1.x = 0; solution_compare1.y = 0; solution_compare1.z = 0;

            do
            {
                success = 0;
                concentric = 0;
                overlook_count = 0;
                ovr_r1 = r1; ovr_r2 = r2; ovr_r3 = r3; ovr_r4 = r4;

                do
                {

                    result = trilateration(ref o1, ref o2, ref solution, p1, ovr_r1, p2, ovr_r2, p3, ovr_r3, p4, ovr_r4, MAXZERO);

                    switch (result)
                    {
                        case TRIL_3SPHERES: // 3球是用来得到结果的
                            trilateration_mode34 = TRIL_3SPHERES;
                            success = 1;
                            break;

                        case TRIL_4SPHERES: // 4球是用来得到结果的
                            trilateration_mode34 = TRIL_4SPHERES;
                            success = 1;
                            break;

                        case ERR_TRIL_CONCENTRIC:
                            concentric = 1;
                            break;

                        default: // 其他的返回值都在这里
                            ovr_r1 += 0.10;
                            ovr_r2 += 0.10;
                            ovr_r3 += 0.10;
                            ovr_r4 += 0.10;
                            overlook_count++;
                            break;
                    }

                    logout("尝试：" + overlook_count + concentric + " 结果：" + result, System.Reflection.MethodBase.GetCurrentMethod().Name);

                } while (!(success != 0) && (overlook_count <= 5) && !(concentric != 0));


                if (success != 0)
                {
                    switch (result)
                    {
                        case TRIL_3SPHERES:

                            solution1 = o1;
                            solution2 = o2;
                            nosolution_count = overlook_count;

                            combination_counter = 0;
                            break;

                        case TRIL_4SPHERES:

                            //计算新的 gdop/
                            gdoprate_compare1 = gdoprate(solution, p1, p2, p3);

                            //比较和交换更好的结果
                            if (gdoprate_compare1 <= gdoprate_compare2)
                            {

                                solution1 = o1;
                                solution2 = o2;
                                best_solution = solution;
                                nosolution_count = overlook_count;

                                best_3derror = Math.Sqrt((vnorm(vdiff(solution, p1)) - r1) * (vnorm(vdiff(solution, p1)) - r1) +
                                (vnorm(vdiff(solution, p2)) - r2) * (vnorm(vdiff(solution, p2)) - r2) +
                                (vnorm(vdiff(solution, p3)) - r3) * (vnorm(vdiff(solution, p3)) - r3) +
                                (vnorm(vdiff(solution, p4)) - r4) * (vnorm(vdiff(solution, p4)) - r4));

                                best_gdoprate = gdoprate_compare1;

                                //保存前面的结果
                                solution_compare2 = solution_compare1;
                                gdoprate_compare2 = gdoprate_compare1;

                                combination = 5 - combination_counter;

                                ptemp = p1; p1 = p2; p2 = p3; p3 = p4; p4 = ptemp;
                                rtemp = r1; r1 = r2; r2 = r3; r3 = r4; r4 = rtemp;
                                combination_counter--;
                            }

                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    trilateration_errcounter = 4;
                    combination_counter = 0;
                }
            } while (combination_counter != 0);

            // 如果它给所有4个球组合的错误，那么没有有效的结果给出，否则返回使用的三边测量模式
            if (trilateration_errcounter >= 4)
            {
                return -1;
            }
            else
            {
                return trilateration_mode34;
            }
        }

        /// <summary>
        /// 获取目标的坐标
        /// </summary>
        /// <param name="best_solution">最优解</param>
        /// <param name="use4thAnchor">使用的锚点数量</param>
        /// <param name="anchorArray">锚点的坐标列表</param>
        /// <param name="distanceArray">目标点到锚点的距离列表</param>
        /// <returns>是否成功</returns>
        public static int GetLocation(ref Vec3dInfo best_solution,
                                        ref Vec3dInfo first_solution,
                                        ref Vec3dInfo second_solution,
                                        int use4thAnchor,
                                        ref  Vec3dInfo[] anchorArray,
                                        ref int[] distanceArray)
        {
            Vec3dInfo o1, o2, p1, p2, p3, p4;
            o1 = new Vec3dInfo();
            o2 = new Vec3dInfo();
            p1 = new Vec3dInfo();
            p2 = new Vec3dInfo();
            p3 = new Vec3dInfo();
            p4 = new Vec3dInfo();
            double r1 = 0, r2 = 0, r3 = 0, r4 = 0, best_3derror = 0, best_gdoprate = 0;
            int result = 0;
            int error = 0, combination = 0;

            Vec3dInfo t3 = new Vec3dInfo();
            double dist1 = 0, dist2 = 0;

            // 锚点坐标
            p1.x = anchorArray[0].x; p1.y = anchorArray[0].y; p1.z = anchorArray[0].z;
            p2.x = anchorArray[1].x; p2.y = anchorArray[1].y; p2.z = anchorArray[1].z;
            p3.x = anchorArray[2].x; p3.y = anchorArray[2].y; p3.z = anchorArray[2].z;
            p4.x = anchorArray[0].x; p4.y = anchorArray[0].y; p4.z = anchorArray[0].z; //4号与1号相同-只有3号用于三边测量

            r1 = (double)distanceArray[0] / 1000.0;
            r2 = (double)distanceArray[1] / 1000.0;
            r3 = (double)distanceArray[2] / 1000.0;

            r4 = (double)distanceArray[3] / 1000.0;

            logout("每个区域的半径：(" + r1.ToString("0.00") + "," + r2.ToString("0.00") + "," + r3.ToString("0.00") + "," + r4.ToString("0.00") + ")", System.Reflection.MethodBase.GetCurrentMethod().Name);

            // 使用3或4个球获得最佳位置，并将其保持为know_best_location
            result = deca_3dlocate(ref o1, ref o2, ref best_solution, ref error, ref best_3derror, ref best_gdoprate, p1, r1, p2, r2, p3, r3, p4, r1/*r4*/, ref combination);

            logout("结果：" + result.ToString() + "," + "解1：（" + o1.x.ToString("0.00") + "," + o1.y.ToString("0.00") + "," + o1.z.ToString("0.00") + "） " + "解2：" + o2.x.ToString("0.00") + "," + o2.y.ToString("0.00") + "," + o2.z.ToString("0.00") + "）", System.Reflection.MethodBase.GetCurrentMethod().Name);

            if (result >= 0)
            {
                //传值
                first_solution = o1;
                second_solution = o2;

                if (use4thAnchor == 1) //如果有4个测距结果，则使用第4个锚点选择最接近它的解
                {
                    double diff1 = 0, diff2 = 0;
                    // 找出dist1作为o1到known_best_location的距离
                    t3 = vdiff(o1, anchorArray[3]);
                    dist1 = vnorm(t3);

                    t3 = vdiff(o2, anchorArray[3]);
                    dist2 = vnorm(t3);

                    // 找出从第4锚点到接收到的距离测量值的最近距离
                    diff1 = Math.Abs(r4 - dist1);
                    diff2 = Math.Abs(r4 - dist2);

                    // 选择最接近第四锚点范围的匹配
                    if (diff1 < diff2)
                    {
                        best_solution = o1;
                    }
                    else
                    {
                        best_solution = o2;
                    }
                }
                else
                {
                    //假设标记位于锚(1、2和3)的下方
                    if (o1.z < p1.z)
                    {
                        best_solution = o1;
                    }
                    else
                    {
                        best_solution = o2;
                    }
                }

                return result;//成功
            }

            return -1;//失败
        }
    }
}
