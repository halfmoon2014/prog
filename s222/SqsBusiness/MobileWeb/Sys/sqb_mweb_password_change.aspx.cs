using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
using System.Data.SqlClient;
namespace SqsBusiness.MobileWeb.Sys
{
    public partial class sqb_mweb_password_change : System.Web.UI.Page
    {
        SqlQuery SqlQuery = new SqlQuery();
        SqlDML SqlDML = new SqlDML();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["mode"] == "PasswordChange") //如果是修改密码请求，则执行PasswordChange方法
            {
                PasswordChange(Server.UrlDecode(Request.Form["oldpass"]), Server.UrlDecode(Request.Form["newpass"]));
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="oldpass">新密码</param>
        /// <param name="newpass">旧密码</param>
        protected void PasswordChange(string oldpass,string newpass)
        {
            string UserID = Session["SqbMwebUserID"].ToString();

            DataTable MyTable = new DataTable();
            string selectstring = "select * from sqb_users where ID= '" + UserID + "' and PassWord='" + oldpass + "'";
            MyTable = SqlQuery.GetDataTable(selectstring);

            if (MyTable.Rows.Count > 0)
            {
                string UpdateString = "update sqb_users set PassWord='" + newpass + "' where ID= '" + UserID + "'";

                if (SqlDML.DML(UpdateString) > 0)
                {
                    //.ajax反回值
                    Response.Write("true");
                }
                else {
                    //.ajax反回值
                    Response.Write("false");
                }
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