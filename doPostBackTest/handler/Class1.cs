using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace handler
{
    public class Class1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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
