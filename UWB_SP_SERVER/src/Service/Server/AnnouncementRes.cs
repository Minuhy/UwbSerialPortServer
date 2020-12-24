#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2020  NJRN 保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-NU1L2DL
 * 公司名称：
 * 命名空间：UWB_SP_TO_SOCKET.src.Service.Server
 * 唯一标识：6642d716-c2dc-485c-ba73-46c3339fb6f3
 * 文件名：AnnouncementRes
 * 当前用户域：DESKTOP-NU1L2DL
 * 
 * 创建者：Minuy
 * 电子邮箱：yuminzhe2020@outlook.com
 * 创建时间：2020/12/14 15:08:06
 * 版本：V1.0.0
 * 描述：
 *
 * ----------------------------------------------------------------
 * 修改人：
 * 时间：
 * 修改说明：
 *
 * 版本：V1.0.1
 *----------------------------------------------------------------*/
#endregion << 版 本 注 释 >>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// AnnouncementRes 的摘要说明
/// 用来存公告的
/// </summary>
public class AnnouncementRes
{
    #region <常量>
    #endregion <常量>

    #region <变量>
    private string strAnnouncement;
    private static AnnouncementRes announcementRes;
    #endregion <变量>

    #region <属性>
    #endregion <属性>

    #region <构造方法和析构方法>
    #endregion <构造方法和析构方法>

    #region <方法>
    private AnnouncementRes()
    {
        strAnnouncement = ConfigurationHelper.getSetting(ANNOUNCEMENT_PUBLIC);
        if(strAnnouncement == null)
        {
            strAnnouncement = "";
        }
    }

    public static string GetAnnouncement()
    {
        if(announcementRes == null)
        {
            announcementRes = new AnnouncementRes();
        }

        if (announcementRes.strAnnouncement == null|| announcementRes.strAnnouncement.Equals(""))
        {
            announcementRes.strAnnouncement = "无";
        }

        return announcementRes.strAnnouncement;
    }

    public static void SetAnnouncement(string str)
    {
        if (announcementRes == null)
        {
            announcementRes = new AnnouncementRes();
        }

        //更新配置
        ConfigurationHelper.updateSetting(ANNOUNCEMENT_PUBLIC, str);

        announcementRes.strAnnouncement = str;
    }

    const string ANNOUNCEMENT_PUBLIC = "ANNOUNCEMENT_PUBLIC";
    #endregion <方法>

    #region <事件>
    #endregion <事件>
}
