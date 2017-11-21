using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataClass;

namespace SqsBusiness.BackWeb.WebService
{
    /// <summary>
    /// sqb_bweb_users_groups 的摘要说明
    /// </summary>
    public class sqb_bweb_users_groups : IHttpHandler
    {
        UserSqlClass UserSqlClass = new UserSqlClass();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string LoadMode = context.Request.QueryString["loadmode"];

            switch (LoadMode)
            {
                case "tree":
                    context.Response.Write(UserSqlClass.GetUsersGroupsTree());
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