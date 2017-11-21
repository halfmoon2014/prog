using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class uricode_Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string a = Request.QueryString["@aff"];
        //Response.Write(a);
        if (Request.Form["mytext"] != null)
        {
            rdiv.InnerText = Request.Form["mytext"];
        }
    }
}