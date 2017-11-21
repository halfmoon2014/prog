using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testpro
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sbtn_Click(object sender, EventArgs e)
        {
            Response.Write("hello");
        }

        protected void lbtn_Click(object sender, EventArgs e)
        {
            Response.Write("hello2");
        }
  

 
    }
}