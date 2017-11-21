using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataClass;

namespace SqsBusiness.BackWeb.WebService
{
    /// <summary>
    /// sqb_bweb_users 的摘要说明
    /// </summary>
    public class sqb_bweb_users : IHttpHandler
    {
        UserSqlClass UserSqlClass = new UserSqlClass();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string Load_Mode = context.Request.QueryString["loadmode"];
            string User_Groups = context.Request.QueryString["user_groups"].ToString().Replace("'", "’");

            switch (Load_Mode)
            {
                case "combo":
                    context.Response.Write(UserSqlClass.GetUsers(User_Groups));
                    break;
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