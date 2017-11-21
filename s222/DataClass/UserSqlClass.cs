using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Data;

namespace DataClass
{
    public class UserSqlClass
    {
        SqlQuery SqlQuery = new SqlQuery();                    //SQL查询类
        JsonClass JsonClass = new JsonClass();                 //Json处理类
        JavaScriptSerializer Jss = new JavaScriptSerializer(); //实例化字符串

        /// <summary>
        /// 读取组织架构数据，并返回树目录Json格式数据
        /// </summary>
        /// <returns>树目录Json格式数据</returns>
        public string GetUsersGroupsTree()
        {
            List<Dictionary<string, object>> UsersGroupsTreeJson = new List<Dictionary<string, object>>();
            string SqlString = "select * from sqb_users_groups where pid is null or pid='' order by order_id";

            //获取组织架构表
            DataTable UsersGroupsTable = SqlQuery.GetDataTable(SqlString);

            //组织Json数据
            foreach (DataRow Dr in UsersGroupsTable.Rows)
            {
                Dictionary<string, object> JsonDrow = new Dictionary<string, object>();

                JsonDrow.Add("id", Dr["id"].ToString());
                JsonDrow.Add("text", Dr["name"].ToString());
                JsonDrow.Add("iconCls", "icon-save");
                JsonDrow.Add("attributes", "{\"pid\":\"\"}");
                JsonDrow.Add("children", GetUsersGroupsTreeChildren(Dr["id"].ToString()));

                UsersGroupsTreeJson.Add(JsonDrow);
            }

            return Jss.Serialize(UsersGroupsTreeJson);
        }

        /// <summary>
        /// 根据组织架构父ID读取组织架构
        /// </summary>
        /// <param name="Pid">组织架构父ID</param>
        /// <returns>组织架构列表</returns>
        public List<Dictionary<string, object>> GetUsersGroupsTreeChildren(string Pid)
        {
            List<Dictionary<string, object>> UsersGroupsTreeJson = new List<Dictionary<string, object>>();
            string SqlString = "select * from sqb_users_groups where pid='" + Pid + "'";

            //获取组织架构表
            DataTable UsersGroupsTable = SqlQuery.GetDataTable(SqlString);

            //组织Json数据
            foreach (DataRow Dr in UsersGroupsTable.Rows)
            {
                Dictionary<string, object> JsonDrow = new Dictionary<string, object>();

                JsonDrow.Add("id", Dr["id"].ToString());
                JsonDrow.Add("text", Dr["name"].ToString());
                JsonDrow.Add("iconCls", "icon-save");
                JsonDrow.Add("attributes", "{\"pid\":\"" + Dr["pid"].ToString() + "\"}");
                JsonDrow.Add("children", GetUsersGroupsTreeChildren(Dr["id"].ToString()));

                UsersGroupsTreeJson.Add(JsonDrow);
            }

            return UsersGroupsTreeJson;
        }

        /// <summary>
        /// 按页读取角色信息，没有则读取所有信息
        /// </summary>
        /// <param name="rows">行数</param>
        /// <param name="page">页数</param>
        public string GetUsersRole(int Rows, int Page)
        {
            //当前页数据
            string SqlString = "select top " + Rows.ToString() + " * from sqb_users_role where id not in (select top (" + Rows.ToString() + "*(" + Page.ToString() + "-1)) id from sqb_users_role order by id) order by id";
            //总记录数
            string SqlCountString = "select count(*) from sqb_users_role";

            return JsonClass.GetDataGridJson(SqlString, SqlCountString);
        }

        /// <summary>
        /// 按组织架构读取用户信息
        /// </summary>
        /// <param name="GroupId">组织架构ID(1,2,3,4)</param>
        /// <returns>Json格式的用户信息</returns>
        public string GetUsers(string GroupId)
        {
            string SqlString = "";
            if (!string.IsNullOrEmpty(GroupId))
            {
                GroupId = GroupId.Substring(0, GroupId.Length - 1);
                SqlString = "select * from sqb_users where group_id in(" + GroupId + ")";
            }
            else
            {
                SqlString = "select * from sqb_users";
            }

            return JsonClass.GetListJson(SqlString); ;
        }
    }
}
