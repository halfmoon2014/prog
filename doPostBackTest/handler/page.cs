using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace handler
{
    public class page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("handler.page");
        }
    }
}
