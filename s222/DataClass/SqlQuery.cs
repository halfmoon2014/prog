using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace DataClass
{
   public class SqlQuery
    {
        SqlConn Sqlconn = new SqlConn();
        SqlConnection Conn;

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="UserCode">用户名</param>
        /// <param name="PassWord">密码</param>
        /// <returns>是否验证成功</returns>
        public bool CheckUser(string UserCode, string PassWord, ref string UserID, ref string UserName)
        {
            bool Boo = false;
            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());

            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlCommand Cmd = new SqlCommand("select UserID,UserName from SysUser where UserCode='" + UserCode + "' and UserPass='" + PassWord + "'", Conn);
                    SqlDataReader Dr = Cmd.ExecuteReader();

                    if (Dr.Read())
                    {
                        UserID = Dr.GetString(0);
                        UserName = Dr.GetString(1);
                        Boo = true;
                    }
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sqlconn.CloseConn(Conn);
            }

            return Boo;
        }

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="password">密码</param>
        /// <param name="userID">用户ID</param>
        /// <param name="userName">用户名</param>
        /// <param name="posID">PosId</param>
        /// <returns>是否验证成功</returns>
        public bool CheckUser(string userCode, string password, ref string userID, ref string userName, ref string posID)
        {
            bool flag = false;
            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());
            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlCommand Cmd = new SqlCommand("SELECT P.PosID,U.UserID,P.PosName,U.UserName FROM SysUser U,SysPos P,SysUserPos UP WHERE U.UserID=UP.UserID AND P.PosID=UP.PosID AND UserCode='" + userCode + "' AND UserPass='" + password + "'", Conn);
                    SqlDataReader Dr = Cmd.ExecuteReader();
                    if (Dr.Read())
                    {
                        userID = Dr["UserID"].ToString();
                        userName = Dr["UserName"].ToString();
                        posID = Dr["PosID"].ToString();
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
                Sqlconn.CloseConn(Conn);
            }
            return flag;
        }

        /// <summary>
        /// 取得POS列表
        /// </summary>
        /// <param name="UserCode">POS编号</param>
        /// <param name="PosID">POSID</param>
        /// <returns></returns>
        public void GetUserPos(string UserCode, ref List<string> PosNameList, ref List<string> PosID)
        {
            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());

            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlCommand Cmd = new SqlCommand("Select PosID,(Select PosName From SysPos Where (PosID = SysUserPos.PosID)) AS PosName From SysUserPos Where (UserID = (Select UserID From SysUser Where (UserCode = '" + UserCode + "')))", Conn);
                    SqlDataReader Dr = Cmd.ExecuteReader();

                    while (Dr.Read())
                    {
                        PosNameList.Add(Dr.GetString(1));
                        PosID.Add(Dr.GetString(0));
                    }
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sqlconn.CloseConn(Conn);
            }
        }

        /// <summary>
        /// 销售列表
        /// </summary>
        /// <param name="ShowData">是否空表</param>
        /// <returns>DataSet</returns>
        public DataSet GetSalesds(bool ShowData)
        {
            DataSet Salesds = new DataSet();
            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());

            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    string CmdString = "Select * From SalesList";
                    SqlDataAdapter Ar = new SqlDataAdapter(CmdString, Conn);
                    Ar.Fill(Salesds, "SalesList");
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sqlconn.CloseConn(Conn);
            }

            return Salesds;
        }

        /// <summary>
        /// 取得最大凭证号
        /// </summary>
        /// <returns>最大凭证号</returns>
        public string GetMaxSalesCode()
        {
            string SalesCode = "";

            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());

            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlCommand Cmd = new SqlCommand("Select Max(SalesCode) From Sales", Conn);
                    SqlDataReader Dr = Cmd.ExecuteReader();

                    while (Dr.Read())
                    {
                        SalesCode = Dr.GetString(0);
                    }
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sqlconn.CloseConn(Conn);
            }

            return SalesCode;
        }

        /// <summary>
        /// 获取当月的销售凭证号
        /// </summary>
        /// <param name="saleDate">年月 格式yyMM</param>
        /// <param name="posID">posID</param>
        /// <returns></returns>
        public string GetMaxSalesCode(string saleDate, string posID)
        {
            string SalesCode = "";

            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());

            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlCommand Cmd = new SqlCommand("Select Max(SalesCode) From Sales WHERE SalesCode LIKE 'XS" + saleDate + "%' AND posID='" + posID + "'", Conn);
                    SqlDataReader Dr = Cmd.ExecuteReader();

                    if (Dr.Read())
                    {
                        if (Dr[0].ToString() == "")
                        {
                            SalesCode = "XS" + saleDate + "-00001";
                        }
                        else
                        {
                            SalesCode = "XS" + saleDate + "-" + (int.Parse(Dr[0].ToString().Substring(7, 5)) + 1).ToString().PadLeft(5, '0');
                        }
                    }
                    else
                    {
                        SalesCode = "XS" + saleDate + "-00001";
                    }
                    Dr.Close();
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sqlconn.CloseConn(Conn);
            }

            return SalesCode;
        }

        /// <summary>
        /// 获取盘点当月凭证号
        /// </summary>
        /// <param name="saleDate">年月 格式yyMM</param>
        /// <param name="posID">PosID</param>
        /// <returns></returns>
        public string GetMaxStockTakeCode(string saleDate, string posID)
        {
            string SalesCode = "";

            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());

            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlCommand Cmd = new SqlCommand("Select Max(StockTakeCode) From StockTake WHERE StockTakeCode LIKE 'CPYK" + saleDate + "%' AND posID='" + posID + "'", Conn);
                    SqlDataReader Dr = Cmd.ExecuteReader();

                    if (Dr.Read())
                    {
                        if (Dr[0].ToString() == "")
                        {
                            SalesCode = "CPYK" + saleDate + "-00001";
                        }
                        else
                        {
                            SalesCode = "CPYK" + saleDate + "-" + (int.Parse(Dr[0].ToString().Substring(9, 5)) + 1).ToString().PadLeft(5, '0');
                        }
                    }
                    else
                    {
                        SalesCode = "CPYK" + saleDate + "-00001";
                    }
                    Dr.Close();
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sqlconn.CloseConn(Conn);
            }

            return SalesCode;
        }

        /// <summary>
        /// 产品入库当月凭证号
        /// </summary>
        /// <param name="saleDate">年月 格式yyMM</param>
        /// <param name="posID">posID</param>
        /// <returns></returns>
        public string GetMaxStockInCode(string saleDate, string posID)
        {
            string SalesCode = "";

            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());

            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlCommand Cmd = new SqlCommand("Select Max(StockInCode) From StockIn WHERE StockInCode LIKE 'CPRK" + saleDate + "%' AND posID='" + posID + "'", Conn);
                    SqlDataReader Dr = Cmd.ExecuteReader();

                    if (Dr.Read())
                    {
                        if (Dr[0].ToString() == "")
                        {
                            SalesCode = "CPRK" + saleDate + "-00001";
                        }
                        else
                        {
                            SalesCode = "CPRK" + saleDate + "-" + (int.Parse(Dr[0].ToString().Substring(9, 5)) + 1).ToString().PadLeft(5, '0');
                        }
                    }
                    else
                    {
                        SalesCode = "CPRK" + saleDate + "-00001";
                    }
                    Dr.Close();
                }
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Sqlconn.CloseConn(Conn);
            }

            return SalesCode;
        }

        /// <summary>
        /// 数据集查询
        /// </summary>
        /// <param name="queryStr">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet GetDateSet(string queryStr)
        {
            DataSet ds = new DataSet();
            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());
            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(queryStr, Conn);
                    da.Fill(ds);
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
                Sqlconn.CloseConn(Conn);
            }
            return ds;
        }

        /// <summary>
        /// 数据集查询
        /// </summary>
        /// <param name="queryStr">查询语句</param>
        /// <param name="tableName">表名</param>
        /// <returns>DataSet</returns>
        public DataSet GetDateSet(string queryStr, string tableName)
        {
            DataSet ds = new DataSet();
            ds.Clear();
            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());
            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(queryStr, Conn);
                    da.Fill(ds, tableName);
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
                Sqlconn.CloseConn(Conn);
            }
            return ds;
        }

        /// <summary>
        /// 数据表查询
        /// </summary>
        /// <param name="QueryStr">查询语句</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string QueryStr)
        {
            DataTable Dt = new DataTable();
            DataSet Ds = new DataSet();
            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());
            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlDataAdapter Da = new SqlDataAdapter(QueryStr, Conn);
                    Da.Fill(Ds);
                    Dt = Ds.Tables[0];
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
                Sqlconn.CloseConn(Conn);
            }
            return Dt;
        }

        /// <summary>
        /// 数据表查询
        /// </summary>
        /// <param name="QueryStr">查询语句</param>
        /// <returns>DataTable</returns>
        public DataTable GetNotOpenDataTable(string QueryStr,SqlConnection conn)
        {
            DataTable Dt = new DataTable();
            DataSet Ds = new DataSet();

            try
            {
                    SqlDataAdapter Da = new SqlDataAdapter(QueryStr, conn);
                    Da.Fill(Ds);
                    Dt = Ds.Tables[0];
            }
            catch (SqlException se)
            {
                throw se;
            }
            catch (Exception ee)
            {
                throw ee;
            }
            return Dt;
        }


        public int sqlselect(string sqlstr)
        {
            int i = 0;
            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());
            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlCommand cmd = new SqlCommand(sqlstr, Conn);
                    i = cmd.ExecuteNonQuery();
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
                Sqlconn.CloseConn(Conn);
            }

            return i;


        }



        /// <summary>
        /// 数据表查询
        /// </summary>
        /// <param name="queryStr">查询语句</param>
        /// <param name="tableName">表名</param>
        /// <returns>DataTable</returns>
        public DataTable GetDataTable(string queryStr, string tableName)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());
            try
            {
                if (Sqlconn.OpenConn(Conn))
                {
                    SqlDataAdapter da = new SqlDataAdapter(queryStr, Conn);
                    da.Fill(ds, tableName);
                    dt = ds.Tables[tableName];
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
                Sqlconn.CloseConn(Conn);
            }
            return dt;
        }

        //public Dictionary<string, object > GetDataRow(string queryStr)
        //{
        //    Dictionary<string, object> dic = new Dictionary<string, object>();
        //    Conn = Sqlconn.GetConn(Sqlconn.GetConnStr());
        //    SqlCommand cmd = new SqlCommand(queryStr, Conn);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        foreach (string key in dr.)
        //        {
        //            dtb.Columns.Add(key, drow[key].GetType());
        //        }
        //    }
        //    return dic;
        //}
    }
}
