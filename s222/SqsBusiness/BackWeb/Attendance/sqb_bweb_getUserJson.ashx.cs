using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataClass;
using System.Data;

namespace SqsBusiness.BackWeb.Attendance
{
    /// <summary>
    /// sqb_bweb_getUserJson 的摘要说明
    /// </summary>
    public class sqb_bweb_getUserJson : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            DataTableToJson dt2Json = new DataTableToJson();
            SqlQuery sqlQuery = new SqlQuery();
            if (context.Request.QueryString["getUsers"] != null)
            {

                string sqlStr = "SELECT ID,UserName FROM sqb_users";
                if (context.Request.QueryString["getUsers"].ToString() != "")
                {
                    string id = context.Request.QueryString["getUsers"].ToString().TrimEnd(',');
                    sqlStr += " WHERE Group_ID IN (" + id + ")";
                }
                DataTable dtUsers = sqlQuery.GetDataTable(sqlStr);
                string result = dt2Json.Dtb2Json(dtUsers);
                context.Response.Write(result);
                context.Response.End();
            }
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