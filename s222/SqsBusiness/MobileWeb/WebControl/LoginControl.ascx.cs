using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SqsBusiness.MobileWeb.WebUserControl
{
    public partial class LoginControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)//当页面首次加载时
            {
                //判断用户是否登录操作
                if (Session["SqbMwebUserName"] == null)
                {
                    Response.Redirect("~/MobileWeb/sqb_mweb_login.aspx");
                }
            }
        }
    }
}