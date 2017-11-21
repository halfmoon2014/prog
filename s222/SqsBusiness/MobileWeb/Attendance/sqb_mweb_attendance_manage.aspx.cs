using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SqsBusiness.MobileWeb.Attendance
{
    public partial class sqb_mweb_attendance_manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SqbMwebUserID"] == null)
            {
                Response.Redirect("../sqb_mweb_login.aspx");
            }
        }
    }
}