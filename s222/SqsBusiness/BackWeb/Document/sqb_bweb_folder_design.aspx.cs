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
    public partial class sqb_bweb_folder_design : System.Web.UI.Page
    {
        public string _id="";//文件夹ID
        public string _pid;//文件夹父ID
        string _folderName;//文件夹操作
        string _action;//执行操作类型 insert update delete
        string _uid;
        SqlQuery sqlQuery = new SqlQuery();
        SqlDML sqlDML = new SqlDML();
        DataTable dt;
        DataTableToJson dt2Json = new DataTableToJson();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SqbBwebUserID"] == null)
            {
                Response.Write("<script>window.parent.location.href='../sqb_bweb_login.aspx'</script>");
            }
            _uid = Session["SqbBwebUserID"].ToString();
           
            if (Request.QueryString["id"] != null)
            {
                _id = Request.QueryString["id"];
                GetFolderInfo();
            }

            if (Request.Form["id"] != null)
            {
                _id = Request.Form["id"].ToString();
            }

            if (Request.QueryString["mode"] != null)
            {
                if (Request.QueryString["mode"].ToString() == "getUsers")
                {
                    GetUsers();
                }
                //GetDocumentJson();
            }
            if (Request.Form["pid"] != null)
            {
                _pid = Request.Form["pid"].ToString();
            }
            if (Request.Form["folderName"] != null)
            {
                _folderName = Request.Form["folderName"].ToString();
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
                SaveFolder();
            }
        }

        //获得文件夹信息转json
        public void GetDocumentJson()
        {
            string sqlStr = "SELECT D.*,U.UserName FROM sqb_document D inner join sqb_users U on D.Add_User_ID=U.ID ";//WHERE D.Folder_ID=" + _pid;
            dt = sqlQuery.GetDataTable(sqlStr);

            string result = "";
            result = dt2Json.Dtb2Json(dt);

            Response.Write(result);
            Response.End();
        }

        //获得用户
        public void GetUsers()
        {
            string sqlStr = "SELECT UserName FROM sqb_users";
            DataTable dtUsers = sqlQuery.GetDataTable(sqlStr);
            string result = dt2Json.Dtb2Json(dtUsers);
            Response.Write(result);
            Response.End();
        }

        //获得文件夹信息
        public void GetFolderInfo()
        {
            string sqlStr = "SELECT * FROM sqb_folder WHERE ID=" + _id;
            DataTable dt = sqlQuery.GetDataTable(sqlStr);
            if (dt.Rows.Count > 0)
            {
                this.folderName.Value = dt.Rows[0]["Name"].ToString();
                _pid = dt.Rows[0]["Pid"].ToString();
            }
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
            ",1" +//公共文档还是个人文档，尚未修改
            ",'1'" +//权限管理，未做
            "," + _uid +
            ",Convert(DateTime,'"+System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"'))";
                    break;
                case "update":
                    sqlStr = "UPDATE [sqb_folder]" +
                    "SET [Name] = '" +_folderName+"'"+
                    "  ,[Pid] =" +_pid+
                    ",[Allow_Content] = '1'" +
                    ",[Update_User_ID] = " +_uid+
                    ",[Update_Time] = Convert(DateTime,'" +DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"')"+
                    "WHERE ID="+_id;
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