using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataClass;


namespace SqsBusiness.MobileWeb.Attendance
{
    /// <summary>
    /// sqb_mweb_attendance_ajax 的摘要说明
    /// </summary>
    public class sqb_mweb_attendance_ajax : IHttpHandler
    {
        SqlDML sqlDML = new SqlDML();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string _strAction = context.Request.Form["action"];
            string _strType = context.Request.Form["type"];
            string _dateTime = context.Request.Form["dateTime"];
            string _userID = context.Request.Form["userID"];
            string _comment = context.Request.Form["comment"];
            DateTime signDate = Convert.ToDateTime(_dateTime);
            string sqlInsert = "INSERT INTO [sqb_attendance]" +
              "([User_ID]" +
              ",[Classes_ID]" +
              ",[Sign_Time]" +
              ",[Sign_Photo_Path]" +
              ",[Note]" +
              ",[SignType])" +
              "VALUES" +
              "(" + _userID +
              "," + "1" +//班次ID    未修改
              ",Convert(DateTime,'" + signDate + "')" +
              ",'" + "'" +//照片路劲 未修改
              ",'" + _comment + "'" +
              ",'" + _strType + "')";
            if (sqlDML.DML(sqlInsert) > 0)
            {
                context.Response.Write("true");
            }
            else
            {
                context.Response.Write("false");
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