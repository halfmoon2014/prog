using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
using System.Web.Script.Serialization;

namespace SqsBusiness.BackWeb.User
{
    public partial class sqb_bweb_users_role : System.Web.UI.Page
    {
        SqlDML SqlDML = new SqlDML();
        SqlQuery SqlQuery = new SqlQuery();
        JavaScriptSerializer Jss = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["mode"] == "loadallrole")
                {
                    LoadAllRole(Convert.ToInt32(Request.Form["rows"]), Convert.ToInt32(Request.Form["page"])); //初始化组织架构树目录数据
                }

                if (Request.Form["mode"] == "loadrole")
                {
                    LoadRole(Request.Form["id"]); //根据ID读取角色信息
                }

                if (Request.Form["mode"] == "saverole")
                {
                    string savemode = Request.Form["savemode"];
                    string roleid = Request.Form["roleid"];
                    string allow_id = Request.Form["allow_id"];
                    string name = Request.Form["name"];
                    string note = Request.Form["note"];

                    if (string.IsNullOrEmpty(roleid))
                    {
                        roleid = "null";
                    }

                    if (string.IsNullOrEmpty(allow_id))
                    {
                        allow_id = "null";
                    }

                    SaveRole(savemode, roleid, allow_id, name, note); //保存角色信息
                }
            }
        }

        /// <summary>
        /// 按页读取角色信息，没有则读取所有信息
        /// </summary>
        /// <param name="rows">行数</param>
        /// <param name="page">页数</param>
        protected void LoadAllRole(int rows, int page)
        {
            List<Dictionary<string, object>> RoleJson = new List<Dictionary<string, object>>();

            string SqlString = "select * from sqb_users_role";
            DataTable RoleTable = new DataTable();
            RoleTable = SqlQuery.GetDataTable(SqlString);

            foreach (DataRow Row in RoleTable.Rows)
            {
                Dictionary<string, object> Drow = new Dictionary<string, object>();
                foreach (DataColumn Col in RoleTable.Columns)
                {
                    Drow.Add(Col.ColumnName.ToLower(), Row[Col.ColumnName].ToString());
                }

                RoleJson.Add(Drow);
            }

            Response.Write("{ \"total\":" + RoleTable.Rows.Count.ToString() + ",\"rows\":" + Jss.Serialize(RoleJson) + "}");
            Response.End();
        }

        /// <summary>
        /// 根据ID读取角色信息
        /// </summary>
        /// <param name="id"></param>
        protected void LoadRole(string id)
        {
            List<Dictionary<string, object>> RoleJson = new List<Dictionary<string, object>>();

            string SqlString = "select * from sqb_users_role where id=" + id;
            DataTable RoleTable = new DataTable();
            RoleTable = SqlQuery.GetDataTable(SqlString);

            foreach (DataRow Row in RoleTable.Rows)
            {
                Dictionary<string, object> Drow = new Dictionary<string, object>();
                foreach (DataColumn Col in RoleTable.Columns)
                {
                    Drow.Add(Col.ColumnName.ToLower(), Row[Col.ColumnName].ToString());
                }

                RoleJson.Add(Drow);
            }

            Response.Write(Jss.Serialize(RoleJson));
            Response.End();
        }

        /// <summary>
        /// 保存角色信息
        /// </summary>
        /// <param name="savemode">保存模式:"add","edit","del"</param>
        /// <param name="id">角色ID</param>
        /// <param name="order_id">角色权限级别</param>
        /// <param name="name">角色名称</param>
        /// <param name="note">备注</param>
        protected void SaveRole(string savemode, string id, string allow_id, string name, string note)
        {
            string SqlString = "";

            switch (savemode)
            {
                case "add":
                    SqlString = "insert into sqb_users_role (allow_id,name,note) values(" + allow_id + ",'" + name + "','" + note + "')";
                    break;
                case "edit":
                    SqlString = "update sqb_users_role set allow_id=" + allow_id + ",name='" + name + "',note='" + note + "' where id=" + id;
                    break;
                case "del":
                    SqlString = "delete from sqb_users_role where id=" + id;
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