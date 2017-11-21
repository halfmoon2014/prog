using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SqsBusiness.MobileWeb.Dialog
{
    public partial class dialog_message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dialog_error_msg.InnerText = Server.UrlDecode(Request.QueryString["errormsg"]);
        }
    }
}