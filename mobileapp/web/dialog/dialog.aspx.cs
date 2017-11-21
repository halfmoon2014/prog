using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dialog_dialog : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string info = "";
        if (Request.QueryString["info"] != null)
        {
            info = Request.QueryString["info"].ToString();
        }
        else if (Request.Form["info"] != null)
        {
            info = Request.Form["info"].ToString();
        }
        dialog_dialog_info.InnerHtml = info;      
    }
}