using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataClass;
using System.Data;

namespace SqsBusiness.BackWeb.Route
{
    /// <summary>
    /// sqb_bweb_rount_dayline_tree 的摘要说明
    /// </summary>
    public class sqb_bweb_rount_dayline_tree : IHttpHandler
    {
        string result = "";
        DataTable dt;
        SqlQuery sqlQuery = new SqlQuery();

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            string sqlStr = "SELECT Name,ID,PID FROM sqb_users_groups WHERE pid is null";
            dt = sqlQuery.GetDataTable(sqlStr);
            result = "[";

            foreach (DataRow dr in dt.Rows)
            {

                result += "{\"id\":\"" + dr["id"] + "\",\"text\":\"" + dr["Name"] + "\",\"children\":";
                GetChildren(dr["id"].ToString());

                result += "},";
            }
            result = result.TrimEnd(',');
            result += "]";
            context.Response.Write(result);
        }

        public void GetChildren(string pid)
        {
            string sqlStr = "SELECT Name,ID,PID,'地区' AS P_Name FROM sqb_users_groups WHERE pid='" + pid + "'";
            DataTable dtChildren = sqlQuery.GetDataTable(sqlStr);
            result += "[";
            foreach (DataRow dr in dtChildren.Rows)
            {

                result += "{\"id\":\"" + dr["id"] + "\",\"text\":\"" + dr["Name"] + "\",\"children\":";
                GetChildren(dr["id"].ToString());

                result += "},";
            }
            if (result[result.Length - 1] == ',')
            {
                result = result.TrimEnd(',');
            }
            result += "]";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}