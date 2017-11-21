using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
namespace SqsBusiness.MobileWeb.Document
{
    public partial class sqb_mweb_document_design : System.Web.UI.Page
    {
        string _folderName;
        string _p_folderName;
        public string _pid;
        string _uid;
        public string _id="";
        public string _action = "";
        public string _type;

        SqlDML sqlDML = new SqlDML();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SqbMwebUserID"] == null)
            {
                Response.Redirect("../sqb_mweb_login.aspx");
            }
            _uid = Session["SqbMwebUserID"].ToString(); ;
            if (Request.QueryString["folderName"] != null)
            {
                _folderName = Convert.ToString(Request.QueryString["folderName"].ToString());
                this.folderName.Value = _folderName;
            }
            if (Request.QueryString["p_folderName"] != null)
            {
                _p_folderName = Convert.ToString(Request.QueryString["p_folderName"].ToString());
                this.p_folderName.Value = _p_folderName;
            }
            else
            {
                this.p_folderName.Value = "个人文件夹";
            }
            if (Request.QueryString["pid"] != null)
            {
                _pid = Convert.ToString(Request.QueryString["pid"].ToString());
            }
            else
            {
                _pid = "0";
            }
            if (Request.QueryString["id"] != null)
            {
                _id = Convert.ToString(Request.QueryString["id"].ToString());
            }
            if (Request.QueryString["action"] != null)
            {
                _action = Convert.ToString(Request.QueryString["action"].ToString());
            }
            _type = Convert.ToString(Request.QueryString["type"].ToString());
            if (Request.QueryString["flag"] != null) //如果是ajax请求，则执行login方法
            {
                Folder();
            }
        }

        protected void Folder()
        {
            string sqlStr = "";
            switch (_action)
            { 
                case "":
                    sqlStr = "INSERT INTO [sqb_folder]" +
                       "([Name]" +
                       ",[Pid]" +
                       ",[Folder_Type_ID]" +
                       ",[Add_User_ID]" +
                       ",[Add_Time])" +
                       "VALUES" +
                       "('" + _folderName + "'" +
                       "," + _pid +
                       ",1" +
                       ","+_uid +//uid 从Session中获得，目前用1代替
                       ",Convert(DateTime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd") + "'))";
                break;
                case "update":
                sqlStr = "UPDATE [sqb_folder]"
                          +"SET [Name] = '"+_folderName+"'"
                          +",[Pid] ="+_pid
                          +",[Update_User_ID] = "+_uid
                          + ",[Update_Time] = Convert(DateTime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd")+"')"
                          +"WHERE ID="+_id;
                break;
                case "delete":
                sqlStr = "DELETE sqb_folder WHERE ID="+_id;
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