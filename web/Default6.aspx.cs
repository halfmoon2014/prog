using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write("test");
    }
    public void mypageload(object sender, EventArgs e)   //Handles MyBase.Load
    {
        Response.Write("mypageload");
        while (true)
        {
            string abc = "hello";
        }
    }
    override protected void OnInit(EventArgs e)
    {
        this.Load += new System.EventHandler(this.mypageload);
    }
}