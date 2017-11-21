using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataClass;

namespace SqsBusiness.BackWeb.Document
{
    public partial class sqb_bweb_folder_manage : System.Web.UI.Page
    {
        public string _id = "";//文件夹ID
        public string _pid;//文件夹父ID
        string _folderName;//文件夹操作
        string _action;//执行操作类型 insert update delete
        string _allow;//权限
        string _uid;
        public string _type = "";
        public string _folder_Type;
        SqlQuery sqlQuery = new SqlQuery();
        SqlDML sqlDML = new SqlDML();
        DataTableToJson dt2Json = new DataTableToJson();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["SqbBwebUserID"] == null)
            {
                Response.Write("<script>window.parent.location.href='../sqb_bweb_login.aspx'</script>");
            }
            _uid = Session["SqbBwebUserID"].ToString();
            

            if (Request.Form["id"] != null)
            {
                _id = Request.Form["id"].ToString();
            }
            if (Request.QueryString["getUsers"] != null)
            {
                GetUsers();
            }

            if (Request.QueryString["type"] == "public")
            {
                _type = "public";
            }
            else
            {
                _type = "person";
            }

            if (Request.Form["type"] == "public")
            {
                _folder_Type = "0";
            }
            else
            {
                _folder_Type = "1";
            }


            if (Request.Form["pid"] != null)
            {
                _pid = Request.Form["pid"].ToString();
            }
            if (Request.Form["folderName"] != null)
            {
                _folderName = Request.Form["folderName"].ToString();
            }
            if (Request.Form["getFolder"] != null)
            {
                string sqlStr = "SELECT * FROM sqb_folder WHERE ID=" + Request.Form["id"].ToString();
                DataTable dt = sqlQuery.GetDataTable(sqlStr);

                
                string result = dt2Json.Dtb2Json(dt);

                Response.Write(result);
                Response.End();
            }


            if (Request.Form["action"] != null)
            {
                if (_id == "")
                {
                    _action = "";
                }
                else
                {
                    _action = Request.Form["action"].ToString();
                }
                if (_action != "del")
                { 
                _allow = Request.Form["allow"].ToString();
                    }
                SaveFolder();
            }
        }

        //获得用户
        public void GetUsers()
        {
            string sqlStr = "SELECT ID,UserName FROM sqb_users";
            if (Request.QueryString["getUsers"].ToString() != "")
            {
                string id=                Request.QueryString["getUsers"].ToString().TrimEnd(',');
                sqlStr += " WHERE Group_ID IN (" + id + ")";
            }
            DataTable dtUsers = sqlQuery.GetDataTable(sqlStr);
            string result = dt2Json.Dtb2Json(dtUsers);
            Response.Write(result);
            Response.End();
        }

        //保存操作
        public void SaveFolder()
        {
            string sqlStr = "";
            switch (_action)
            {
                case "": sqlStr = "INSERT INTO [sqb_folder]" +
            "([Name]" +
            ",[Pid]" +
            ",[Folder_Type_ID]" +
            ",[Allow_Content]" +
            ",[Add_User_ID]" +
            ",[Add_Time])" +
            "VALUES" +
            "('" + _folderName + "'" +
            "," + _pid +
            "," + _folder_Type + "" +
            ",'" + _allow + "'" +
            "," + _uid +
            ",Convert(DateTime,'" + System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'))";
                    break;
                case "update":
                    sqlStr = "UPDATE [sqb_folder]" +
                    "SET [Name] = '" + _folderName + "'" +
                    "  ,[Pid] =" + _pid +
                    ",[Allow_Content] = '" + _allow + "'" +
                    ",[Update_User_ID] = " + _uid +
                    ",[Update_Time] = Convert(DateTime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')" +
                    "WHERE ID=" + _id;
                    break;
                case "del":
                    sqlStr = "DELETE FROM [sqb_folder] WHERE ID=" + _id;
                    break;
            }
            if (sqlDML.DML(sqlStr) > 0)
            {
                Response.Write("true");
            }
            else
            {
                Response.Write("false");
            }
        }
    }
}