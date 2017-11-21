using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using EntityClass;
using System.Data;
using System.Web.Script.Serialization;

namespace SqsBusiness.BackWeb.User
{
    public partial class sqb_bweb_users_groups : System.Web.UI.Page
    {
        SqlDML SqlDML = new SqlDML();
        SqlQuery SqlQuery = new SqlQuery();
        JsonClass JsonClass = new JsonClass();
        UserSqlClass UserSqlClass = new UserSqlClass();
        UsersGroups UsersGroups = new UsersGroups();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["mode"] == "loadtree")
                {
                    GetUsersGroupsTree(); //初始化组织架构树目录数据
                }

                switch (Request.Form["mode"])
                {
                    case "loadgroups":
                        LoadUsersGroups(Request.Form["id"]); //读取组织架构数据
                        break;
                    case "savegroups":
                        string savemode = Request.Form["savemode"];
                        UsersGroups.ID = Request.Form["groupsid"];
                        string id = Request.Form["groupsid"];
                        string order_id = Request.Form["order_id"];
                        string name = Request.Form["name"];
                        string phone = Request.Form["phone"];
                        string fax = Request.Form["fax"];
                        string note = Request.Form["note"];
                        string pid = Request.Form["pid"];

                        if (string.IsNullOrEmpty(id))
                        {
                            id = "null";
                        }

                        if (string.IsNullOrEmpty(pid))
                        {
                            pid = "null";
                        }

                        if (string.IsNullOrEmpty(order_id))
                        {
                            order_id = "null";
                        }

                        SaveGroups(savemode, id, order_id, name, phone, fax, note, pid); //保存组织架构
                        break;
                }
            }
        }

        // 读取组织架构数据，并返回Json格式数据
        protected void GetUsersGroupsTree()
        {
            Response.Write(UserSqlClass.GetUsersGroupsTree());
            Response.End();
        }

        /// <summary>
        /// 根据ID读取组织架构
        /// </summary>
        /// <param name="ID">组织架构ID</param>
        protected void LoadUsersGroups(string ID)
        {
            string SqlString = "select * from sqb_users_groups where id='" + ID + "'";
            Response.Write(JsonClass.GetListJson(SqlString));
            Response.End();
        }

        /// <summary>
        /// 保存组织架构
        /// </summary>
        /// <param name="savemode">保存模式:"add","edit","del"</param>
        /// <param name="id">组织架构ID</param>
        /// <param name="order_id">组织架构排序号</param>
        /// <param name="name">组织架构名称</param>
        /// <param name="phone">电话</param>
        /// <param name="fax">传真</param>
        /// <param name="note">备注</param>
        /// <param name="pid">组织架构父ID</param>
        protected void SaveGroups(string savemode, string id, string order_id, string name, string phone, string fax, string note, string pid)
        {
            string SqlString = "";

            switch (savemode)
            {
                case "add":
                    SqlString = "insert into sqb_users_groups (order_id,name,phone,fax,note,pid) values(" + order_id + ",'" + name + "','" + phone + "','" + fax + "','" + note + "'," + pid + ")";
                    break;
                case "edit":
                    SqlString = "update sqb_users_groups set order_id='" + order_id + "',name='" + name + "',phone='" + phone + "',fax='" + fax + "',note='" + note + "',pid=" + pid + " where id=" + id;
                    break;
                case "del":
                    SqlString = "delete from sqb_users_groups where id=" + id;
                    break;
            }

            if (SqlDML.DML(SqlString) != 0)
            {
                Response.Write("true");
            }
            else
            {
                Response.Write("false");
            }
            Response.End();
        }
    }
}