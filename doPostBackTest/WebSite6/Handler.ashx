<%@ WebHandler Language="C#" Class="myHandler.Handler" %>

using System;
using System.Web;
using nrWebClass;
namespace myHandler
{
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
            string datas = @"{{
                       ""name"":""abc"",
                       ""age"":""18""
                      }}";

            System.Collections.Specialized.NameValueCollection kv = new System.Collections.Specialized.NameValueCollection();
            kv["name"] = "liqf";
            kv["age"] = "15";
            //string r=nrWebClass.clsNetExecute.HttpRequest("http://192.168.35.231/supplier/crosstest.aspx", datas,"post","gb2312",30000);
            string r = nrWebClass.clsNetExecute.ExecWebServiceUsePOST("http://192.168.35.231/supplier/crosstest.aspx", kv);
            context.Response.Write(r);
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