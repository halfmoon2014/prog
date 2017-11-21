using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataClass
{
    public class SqlDML
    {
        SqlConn sqlConn = new SqlConn();
        SqlConnection conn;

        /// <summary>
        /// 执行语句 多条语句，每条语句后面加|
        /// </summary>
        /// <param name="sqlStr">sql 语句</param>
        /// <returns>返回影响条数</returns>
        public int DML(string sqlStr)
        {
            int executeNum = 0;
            //List<string> sqlSplit = new List<string>();
            string[] sqlSplit=sqlStr.Split('|');
            sqlStr = "";
            foreach (string i in sqlSplit)
            {
                sqlStr += i + "SET @error=@error+@@ERROR ";
            }
            try
            {
                conn = sqlConn.GetConn(sqlConn.GetConnStr());
                if (sqlConn.OpenConn(conn))
                {
                    SqlCommand cmd = new SqlCommand("BEGIN TRANSACTION DECLARE @error INT SET @error=0 SET NOCOUNT OFF "+sqlStr+" IF @error<>0 BEGIN ROLLBACK TRANSACTION END ELSE BEGIN COMMIT TRANSACTION END", conn);
                    executeNum = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                sqlConn.CloseConn(conn);
            }
            return executeNum;
        }

        /// <summary>
        /// 执行语句 多条语句，每条语句后面加|
        /// </summary>
        /// <param name="sqlStr">sql 语句</param>
        /// <param name="rowCount">影响行数,未达到影响行数则回滚</param>
        /// <returns>返回true  或  false</returns>
        public bool DML(string sqlStr,int rowCount)
        {
            bool flag = false;
            //List<string> sqlSplit = new List<string>();
            string[] sqlSplit = sqlStr.Split('|');
            sqlStr = "";
            foreach (string i in sqlSplit)
            {
                sqlStr += i + "SET @error=@error+@@ERROR SET @rowCount=@rowCount+@@ROWCOUNT  ";
            }
            try
            {
                conn = sqlConn.GetConn(sqlConn.GetConnStr());
                if (sqlConn.OpenConn(conn))
                {
                    SqlCommand cmd = new SqlCommand("BEGIN TRANSACTION DECLARE @error INT DECLARE @rowCount INT SET @error=0 SET @rowCount=0 SET NOCOUNT OFF " + sqlStr + " IF (@rowCount<>"+rowCount+" OR @error<>0  ) BEGIN ROLLBACK TRANSACTION END ELSE BEGIN COMMIT TRANSACTION END", conn);
                    if (cmd.ExecuteNonQuery() == rowCount)
                    {
                        flag = true;
                    }
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                sqlConn.CloseConn(conn);
            }
            return flag;
        }
    }
}
