using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;

namespace SqsBusiness.BackWeb
{
    public partial class sqb_bweb_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //当页面首次加载时
            {
                Session["SqbBwebUserName"] = null; //清除用户登录
            }

            if (Request.Form["mode"] == "chkuser") //如果是ajax请求，则执行login方法
            {
                login(Request.Form["username"], Request.Form["password"]);
            }
        }

        protected void login(string UserName, string PassWord)
        {
            SqlQuery SqlQuery = new SqlQuery();
            DataTable MyTable = new DataTable();
            String selectstring = "select * from sqb_users where UserName= '" + UserName + "' and PassWord='" + PassWord + "'";
            MyTable = SqlQuery.GetDataTable(selectstring);

            if (MyTable.Rows.Count > 0)
            {
                //添加Session
                HttpContext.Current.Session["SqbBwebUserName"] = UserName;
                HttpContext.Current.Session["SqbBwebUserID"] = MyTable.Rows[0]["ID"].ToString();
                HttpContext.Current.Session.Timeout = 60; //有效时间60分钟

                //.ajax反回值
                Response.Write("true");
            }
            else
            {
                //.ajax反回值
                Response.Write("false");
            }

            Response.End();//停止其他输出
        }
    }
}