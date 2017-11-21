using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pagediv : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string html = "";
        for (int i = 0; i < 200; i++)
        {
            html += "<tr><td>" + i.ToString() + "</td></tr>";
        }
        mytable.InnerHtml = "<table>" + html + "</table>";
    }
}