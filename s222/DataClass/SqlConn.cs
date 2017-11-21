using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataClass
{
    public class SqlConn
    {
        public SqlConn()
        {
            serverAddress = "192.168.1.222,7788";  //数据库服务器地址
            uid = "sa";  //数据库用户名
            pwd = "123";  //数据库密码
            database = "SqsBusiness";  //数据库
        }

        private string serverAddress = "";
        private string uid = "";
        private string pwd = "";
        private string database = "";

        public string Uid
        {
            get { return uid; }
            set { uid = value; }
        }

        public string ServerAddress
        {
            get { return serverAddress; }
            set { serverAddress = value; }
        }

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        public string DataBase
        {
            get { return database; }
            set { database = value; }
        }

        /// <summary>
        /// 取得连接字符串
        /// </summary>
        /// <returns>连接字符串</returns>
        public string GetConnStr()
        {
            string sqlConn = "Data Source=" + serverAddress + ";User ID=" + uid + ";Pwd=" + pwd + ";Initial Catalog=" + database + ";";
            return sqlConn;
        }

        /// <summary>
        /// 取得测试连接字符串
        /// </summary>
        /// <returns>测试连接字符串</returns>
        public string GetConnTestStr()
        {
            string sqlConn = "Data Source=" + serverAddress + ";User ID=" + uid + ";Pwd=" + pwd + ";Initial Catalog=master;";
            return sqlConn;
        }

        /// <summary>
        /// 取得测试连接字符串
        /// </summary>
        /// <param name="ServerName">服务器地址</param>
        /// <param name="UserName">用户名</param>
        /// <param name="PassWord">密码</param>
        /// <returns></returns>
        public string GetConnTestStr(string ServerName, string UserName, string PassWord)
        {
            string sqlConn = "Data Source=" + ServerName + ";User ID=" + UserName + ";Pwd=" + PassWord + ";Initial Catalog=master;";
            return sqlConn;
        }

        /// <summary>
        /// 打开连接
        /// </summary>
        public bool OpenConn(SqlConnection Conn)
        {
            bool Boo = false;

            try
            {
                if (Conn.State != ConnectionState.Open)
                {
                    Conn.Open();
                }

                Boo = true;
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Boo;
        }

        /// <summary>
        /// 关闭SqlConnection连接
        /// </summary>
        public void CloseConn(SqlConnection Conn)
        {
            if (Conn.State != ConnectionState.Closed)
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        /// <summary>
        /// 得到SqlConnection连接
        /// </summary>
        /// <returns>SqlConnection</returns>
        public SqlConnection GetConn(string ConnString)
        {
            SqlConnection Conn = new SqlConnection(ConnString);
            return Conn;
        }
    }
}
