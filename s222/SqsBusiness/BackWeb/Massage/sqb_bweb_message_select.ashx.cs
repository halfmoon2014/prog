using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using DataClass;
using System.Data;
using System.Data.SqlClient;
namespace SqsBusiness.BackWeb.Massage
{
    /// <summary>
    /// sqb_bweb_message_select 的摘要说明
    /// </summary>
    public class sqb_bweb_message_select : IHttpHandler
    {
        SqlQuery SqlQuery = new SqlQuery();
        DataTable mytable = new DataTable();
        DataTableToJson dt2Json = new DataTableToJson();
        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            context.Response.ContentType = "text/plain";
            string result = "";
            string str = "select recipent,Add_User_Name from sqb_message_manage";
            mytable = SqlQuery.GetDataTable(str);
            result = dt2Json.Dtb2Json(mytable);
            context.Response.Write(result);
            context.Response.End();

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