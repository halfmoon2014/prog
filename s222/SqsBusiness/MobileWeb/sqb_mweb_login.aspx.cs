using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.SessionState;
using System.Data;
using System.Data.OleDb;
using DataClass;
using System.Web.Services;
namespace SqsBusiness.MobileWeb
{
    public partial class sqb_mweb_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //当页面首次加载时
            {
                Session["SqbMwebUserName"] = null; //清除用户登录
            }

            if (Request.Form["mode"] == "chkuser") //如果是ajax请求，则执行login方法
            {
                login(Server.UrlDecode(Request.Form["username"]), Server.UrlDecode(Request.Form["password"]));
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
                HttpContext.Current.Session["SqbMwebUserName"] = UserName;
                HttpContext.Current.Session["SqbMwebUserID"] = MyTable.Rows[0]["ID"].ToString();
                HttpContext.Current.Session.Timeout = 60; //有效时间60分钟

                //添加Cookie
                HttpCookie Cookie = new HttpCookie("SqbWeb"); //定义cookie对象及项的名称
                DateTime Date = DateTime.Now; //定义时间对象
                TimeSpan Days = new TimeSpan(7, 0, 0, 0); //cookie有效作用时间，这边设置为7天
                Cookie.Expires = Date.Add(Days); //添加作用时间
                Cookie.Values.Add("SqbMwebUserName", UserName);//增加属性
                Response.AppendCookie(Cookie); //确定写入

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


