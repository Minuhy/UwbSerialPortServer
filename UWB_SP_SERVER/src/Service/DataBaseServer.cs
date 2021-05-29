#region << 版 本 注 释 >>
/*----------------------------------------------------------------
 * 版权所有 (c) 2021  NJRN 保留所有权利。
 * CLR版本：4.0.30319.42000
 * 机器名称：MINC3480
 * 公司名称：
 * 命名空间：UWB_SP_TO_SOCKET.src.Service
 * 唯一标识：50247774-f113-43ce-9f67-d3bf67e37207
 * 文件名：DataBaseServer
 * 当前用户域：MINC3480
 * 
 * 创建者：Minuy
 * 电子邮箱：minuy17@163.com
 * 创建时间：2021/5/29 18:26:07
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
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UWB_SP_TO_SOCKET.src.Tools;
using UWB_SP_TO_SOCKET.src.Twr.Table;

namespace UWB_SP_TO_SOCKET.src.Service
{
    /// <summary>
    /// DataBaseServer 的摘要说明
    /// </summary>
    class DataBaseServer
    {
        #region <常量>


        /// <summary>
        /// 创建标签表的SQL语句
        /// </summary>
        const string SQL_TABLE_TAG = "CREATE TABLE `" + TAG_TABLE + "` (\r\n" +
        "	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,\r\n" +
        "	`time_stamp`	INTEGER NOT NULL,\r\n" +
        "	`tag_id`	INTEGER NOT NULL,\r\n" +
        "	`x`	INTEGER,\r\n" +
        "	`y`	INTEGER,\r\n" +
        "	`z`	INTEGER,\r\n" +
        "	`r95`	INTEGER,\r\n" +
        "	`anc0`	INTEGER,\r\n" +
        "	`anc1`	INTEGER,\r\n" +
        "	`anc2`	INTEGER,\r\n" +
        "	`anc3`	INTEGER,\r\n" +
        "	`other`	TEXT\r\n" +
        ")";
        /// <summary>
        /// 创建原始数据表的SQL语句
        /// </summary>
        const string SQL_TABLE_RAW = "CREATE TABLE `" + RAW_TABLE + "` (\r\n" +
                "	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,\r\n" +
                "	`time_stamp`	INTEGER NOT NULL,\r\n" +
                "	`raw_data`	BLOB,\r\n" +
                "	`mid`	BLOB,\r\n" +
                "	`mask`	BLOB,\r\n" +
                "	`range0`	BLOB,\r\n" +
                "	`range1`	BLOB,\r\n" +
                "	`range2`	BLOB,\r\n" +
                "	`range3`	BLOB,\r\n" +
                "	`nranges`	BLOB,\r\n" +
                "	`rseq`	BLOB,\r\n" +
                "	`debug`	BLOB,\r\n" +
                "	`at_a`	BLOB,\r\n" +
                "	`other`	TEXT\r\n" +
                ")";
        /// <summary>
        /// 创建锚点表的SQL语句
        /// </summary>
        const string SQL_TABLE_ANCHOR = "CREATE TABLE `" + ANC_TABLE + "` (\r\n" +
        "	`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,\r\n" +
        "	`time_stamp`	INTEGER NOT NULL,\r\n" +
        "	`anchor_id`	INTEGER NOT NULL,\r\n" +
        "	`is_enable`	INTEGER,\r\n" +
        "	`x`	INTEGER,\r\n" +
        "	`y`	INTEGER,\r\n" +
        "	`z`	INTEGER,\r\n" +
        "	`label`	TEXT,\r\n" +
        "	`t0`	INTEGER,\r\n" +
        "	`t1`	INTEGER,\r\n" +
        "	`t2`	INTEGER,\r\n" +
        "	`t3`	INTEGER,\r\n" +
        "	`t4`	INTEGER,\r\n" +
        "	`t5`	INTEGER,\r\n" +
        "	`t6`	INTEGER,\r\n" +
        "	`t7`	INTEGER,\r\n" +
        "	`other`	TEXT\r\n" +
        ")";

        public bool isDebug;
        string tbDataBaseName;
        bool isEnableDataBase;

        const string TAG_TABLE = "tag_table";
        const string RAW_TABLE = "raw_table";
        const string ANC_TABLE = "anchor_table";

        static object lockObj = new object();
        static DataBaseServer dataBaseServer;
        static public DataBaseServer GetInstance()
        {
            if (dataBaseServer == null)
            {
                lock (lockObj)
                {
                    if (dataBaseServer == null)
                    {
                        dataBaseServer = new DataBaseServer();
                    }
                }
            }

            return dataBaseServer;
        }
        #endregion <常量>

        #region <变量>
        /// <summary>
        /// 数据库连接
        /// </summary>
        SQLiteConnection connection;
        /// <summary>
        /// 当前数据库文件名
        /// </summary>
        string fileName;

        bool isEnableSQLDataBase;
        //插入数据 
        TwrServer twrServer;

        bool isUserTr = false;//是否启用事务
        int trCount = 0;//事务插入统计
        const int TR_MAX = 1000;//最大事务插入
        DbTransaction trans;
        bool isInit;
        #endregion <变量>

        #region <属性>
        public bool isEnable
        {
            get
            {
                return isEnableDataBase;
            }
            set
            {
                isEnableDataBase = value;
                isEnableSQLDataBase = value;

                if (!value)
                {
                    CommitDataBase();
                }
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
        }

        public bool IsInit { get { return isInit; } private set { this.isInit = value; } }
        #endregion <属性>

        #region <构造方法和析构方法>
        /// <summary>
        /// 单例模式
        /// </summary>
        private DataBaseServer()
        {
        }

        public void Init(TwrServer twrServer)
        {
            if (twrServer != null)
            {
                this.twrServer = twrServer;
                twrServer.rawBuildEvent += m_MessageManage_rawBuildEvent;
                twrServer.tagBuildEvent += m_MessageManage_tagBuildEvent;
                twrServer.anchorBuildEvent += m_MessageManage_anchorBuildEvent;
            }
        }
        #endregion <构造方法和析构方法>

        #region <方法>
        /// <summary>
        /// 提交数据
        /// </summary>
        public void CommitDataBase()
        {
            if (trans != null && connection != null)
            {
                trans.Commit();
                trCount = 0;
                isUserTr = false;
            }
        }
        void m_MessageManage_anchorBuildEvent(TableAnchor ta)
        {
            if (!isEnable)
            {
                return;
            }

            if (ta != null && connection != null)
            {
                if (!isUserTr)
                {
                    trans = connection.BeginTransaction();
                    isUserTr = true;
                }
                else
                {
                    trCount++;
                    if (trCount > TR_MAX)
                    {
                        if (trans != null && connection != null)
                        {
                            trans.Commit();
                            trCount = 0;
                            isUserTr = false;
                        }
                    }
                }

                if (isDebug)
                {
                    DebugLog("收到锚点事件！");
                }
                InsertAncData(ta);
            }
        }

        private void InsertAncData(TableAnchor ta)
        {
            string sqlCommd = "insert into " + ANC_TABLE + "(time_stamp,anchor_id,is_enable,x,y,z,label,t0,t1,t2,t3,t4,t5,t6,t7,other) values ('" + ta.time_stamp + "','" + ta.anchor_id + "','" + ta.is_enable + "','" + ta.x + "','" + ta.y + "','" + ta.z + "','" + ta.label + "','" + ta.t0 + "','" + ta.t1 + "','" + ta.t2 + "','" + ta.t3 + "','" + ta.t4 + "','" + ta.t5 + "','" + ta.t6 + "','" + ta.t7 + "','" + ta.other + "')";
            ExecuteSQLCommand(sqlCommd, connection);
        }

        void m_MessageManage_tagBuildEvent(TableTag tt)
        {
            if (!isEnable)
            {
                return;
            }

            if (tt != null && connection != null)
            {
                if (!isUserTr)
                {
                    trans = connection.BeginTransaction();
                    isUserTr = true;
                }
                else
                {
                    trCount++;
                    if (trCount > TR_MAX)
                    {
                        if (trans != null && connection != null)
                        {
                            trans.Commit();
                            trCount = 0;
                            isUserTr = false;
                        }
                    }
                }

                if (isDebug)
                {
                    DebugLog("收到目标点事件！");
                }
                InsertTagData(tt);
            }
        }

        private void InsertTagData(TableTag tt)
        {
            string sqlCommd = "insert into " + TAG_TABLE + "(time_stamp,tag_id,x,y,z,r95,anc0,anc1,anc2,anc3,other) values ('" + tt.time_stamp + "','" + tt.tag_id + "','" + tt.x + "','" + tt.y + "','" + tt.z + "','" + tt.r95 + "','" + tt.anc0 + "','" + tt.anc1 + "','" + tt.anc2 + "','" + tt.anc3 + "','" + tt.other + "')";
            ExecuteSQLCommand(sqlCommd, connection);
        }

        void m_MessageManage_rawBuildEvent(TableRaw tr)
        {
            if (!isEnable)
            {
                return;
            }

            if (tr != null && connection != null)
            {
                if (!isUserTr)
                {
                    trans = connection.BeginTransaction();
                    isUserTr = true;
                }
                else
                {
                    trCount++;
                    if (trCount > TR_MAX)
                    {
                        if (trans != null && connection != null)
                        {
                            trans.Commit();
                            trCount = 0;
                            isUserTr = false;
                        }
                    }
                }

                if (isDebug)
                {
                    DebugLog("收到生成事件！");
                }
                //InsertData(RAW_TABLE, tr, connection);
                InsertRawData(tr);
            }
        }

        private void InsertRawData(TableRaw tr)
        {
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = connection;
            cmd.CommandText = "insert into " + RAW_TABLE + "(time_stamp,raw_data,other) values (@time_stamp,@raw_data,@other)";
            cmd.Parameters.Add("time_stamp", DbType.UInt64).Value = tr.time_stamp;
            cmd.Parameters.Add("raw_data", DbType.Binary).Value = tr.raw_data;
            cmd.Parameters.Add("other", DbType.String).Value = tr.other;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// 创建一个连接到指定数据库
        /// </summary>
        SQLiteConnection connectToDatabase(string sqlFileName)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source=" + sqlFileName + ";Version=3;");
            connection.Open();

            return connection;
        }

        void CreatTagTable()
        {
            //创建标签表
            ExecuteSQLCommand(SQL_TABLE_TAG, connection);
            //创建原始表
            ExecuteSQLCommand(SQL_TABLE_RAW, connection);
            //创建锚点表
            ExecuteSQLCommand(SQL_TABLE_ANCHOR, connection);
        }
        /*
        void InsertData<T>(string table,T t,SQLiteConnection connection)
        {
                string sql =  SQLCommdTool.GetInsertCommd(table, t);
                ExecuteSQLCommand(sql, connection);
        }
        */
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="sql">命令</param>
        /// <param name="connection">SQL连接</param>
        void ExecuteSQLCommand(string sql, SQLiteConnection connection)
        {
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            //command.Parameters.Add("k", DbType.Binary).Value = bArray;
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// 初始化数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public bool InitDataBase()
        {
            IsInit = false;
            if (twrServer == null)
            {
                return IsInit;
            }

            if (isDebug)
            {
                DebugLog("数据库启用状态：" + this.isEnableSQLDataBase);
            }

            if (this.isEnableSQLDataBase)
            {
                string currPath = Application.StartupPath;
                string subPath = currPath + "\\database\\";
                if (false == System.IO.Directory.Exists(subPath))
                {
                    //创建文件夹
                    System.IO.Directory.CreateDirectory(subPath);
                }
                fileName = "DB_UWB" + TimeTool.GetDateTime() + (TimeTool.GetTimeStamp() % 1000) + ".sqlite";

                if (false == System.IO.Directory.Exists(subPath))
                {
                    fileName = currPath + "\\" + fileName;
                }
                else
                {
                    fileName = subPath + fileName;
                }

                //创建文件 
                SQLiteConnection.CreateFile(fileName);

                //连接到该文件数据库
                connection = this.connectToDatabase(fileName);

                CreatTagTable();

                InitData();
               // MessageBox.Show("luj"+fileName);

                IsInit = true;
            }
            else
            {
                fileName = "";
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }
            }


            return IsInit;
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            if (twrServer != null)
            {
                for(int id = 0; id < 10; id++)
                {
                    TableAnchor ta = twrServer.GetAnchorById(id);
                    if (ta != null)
                    {
                        m_MessageManage_anchorBuildEvent(ta);
                    }
                }
            }
        }
        /// <summary>
        /// 控制台打印数据
        /// </summary>
        /// <param name="str">要打印到控制台的字符</param>
        private void DebugLog(string str)
        {
            Console.WriteLine(str);
        }
        #endregion <方法>

        #region <事件>
        #endregion <事件>
    }
}