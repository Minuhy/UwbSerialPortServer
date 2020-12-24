#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2020  NJRN 保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：DESKTOP-NU1L2DL
 * 公司名称：
 * 命名空间：UWB_SP_TO_SOCKET.src.Tools
 * 唯一标识：8005f1ef-e10e-41d9-bc51-44072d73a9f5
 * 文件名：Configuration
 * 当前用户域：DESKTOP-NU1L2DL
 * 
 * 创建者：Minuy
 * 电子邮箱：yuminzhe2020@outlook.com
 * 创建时间：2020/12/11 22:28:35
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
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Configuration 的摘要说明
/// </summary>
public class ConfigurationHelper
{

    public static string fileName = System.IO.Path.GetFileName(Application.ExecutablePath);
    public static bool addSetting(string key, string value)
    {
        Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(fileName);
        config.AppSettings.Settings.Add(key, value);
        config.Save();
        return true;
    }

    /// <summary>
    /// 通过一个键获取一个值，键不存在时自动新建并默认为string.Empty
    /// </summary>
    /// <param name="key">键值</param>
    /// <returns>值</returns>
    public static string getSetting(string key)
    {
        Console.WriteLine("文件路径：" + fileName);

        Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(fileName);

        string value = string.Empty;

        try
        {
            value = config.AppSettings.Settings[key].Value;
        }
        catch(Exception e)
        {
            addSetting(key, value);
#if DEBUG
            Console.WriteLine("新值！" + key+" 错误："+e.Message);
#endif
        }

        return value;
    }
    /// <summary>
    /// 更新设置，不存在时自动新建并返回string.Empty
    /// </summary>
    /// <param name="key"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public static bool updateSetting(string key, string newValue)
    {
        Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(fileName);
        string value = string.Empty;

        try
        {
            config.AppSettings.Settings[key].Value = newValue;
            config.Save();
        }
        catch(Exception e)
        {
            addSetting(key, newValue);
#if DEBUG
            Console.WriteLine("新值！" + key+" 错误："+e.Message);
#endif
        }

        return true;
    }
}
