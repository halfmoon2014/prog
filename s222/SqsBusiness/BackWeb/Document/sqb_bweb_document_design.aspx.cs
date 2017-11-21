using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using DataClass;

namespace SqsBusiness.BackWeb.Document
{
    public partial class sqb_bweb_document_design : System.Web.UI.Page
    {
        string _uid;
        public string _pid;
        string _action;
        string _documentName = string.Empty;
        string _id;
        public string _type;
        SqlQuery sqlQuery = new SqlQuery();
        SqlDML sqlDML = new SqlDML();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SqbBwebUserID"] == null)
            {
                Response.Write("<script>window.parent.location.href='../sqb_bweb_login.aspx'</script>");
            }
            _uid = Session["SqbBwebUserID"].ToString();
            
            if (Request.QueryString["id"] != null)
            {
                _id = Request.QueryString["id"].ToString();
                upfile.Visible = false;
                if (!IsPostBack)
                {
                    GetDocumentInfo();
                }
                else
                {
                    _pid = this.hfFolderName.Value;
                    }
            }
            _type = Request.QueryString["type"];
        }

        protected void save_Click(object sender, EventArgs e)
        {
            string sqlStr = "";
            _documentName = this.documentName.Value.ToString();
            if (_pid != ""&&_pid!=null)
            {
                sqlStr = "UPDATE [sqb_document]" +
                           "SET [Name] ='" + _documentName + "'" +
                            "  ,[Folder_ID] = " + _pid +
                             " ,[Document_Path] = ''" +
                             " ,[Update_User_ID] = " + _uid +
                             " ,[Update_Time] = Convert(DateTime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd") + "')" +
                            " WHERE ID=" + _id;
            }
            else
            {
                _pid = this.hfFolderName.Value;
                if (upfile.HasFile)
                {
                    string date = DateTime.Now.Date.ToString("yyyy年MM月dd日");
                    string datetime = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                    string filename = datetime + Path.GetExtension(upfile.FileName); //文件名
                    if (!Directory.Exists(Server.MapPath("~/MobileWeb/Document/Files/" + _uid + "/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/MobileWeb/Document/Files/" + _uid + "/"));
                    }
                    string path = Server.MapPath("~/MobileWeb/Document/Files/" + _uid + "/") + filename;
                    upfile.SaveAs(path);
                    sqlStr = "INSERT INTO [sqb_document]" +
                 "([Name]" +
                 ",[Folder_ID]" +
                 ",[Document_Path]" +
                 ",[Add_User_ID]" +
                 ",[Add_Time])" +
                 " VALUES" +
                 "('" + this.documentName.Value + Path.GetExtension(upfile.FileName) + "'" +
                 "," + _pid +
                 ",'" + _uid + "/" + filename + "'" +
                 "," + _uid +
                 ",Convert(DateTime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'))";
                }
                else
                {
                    Response.Write("<script>alert('请选择文件')</script>");
                    return;
                }
            }
            if (sqlDML.DML(sqlStr) > 0)
            {
                //Response.Redirect("sqb_bweb_document_manage.aspx");
                Response.Write("<script>window.parent.location.href='sqb_bweb_document_manage.aspx?pid="+_pid+"&type="+_type+"'</script>");
                //  Response.Write("<script>alert('保存成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('保存成功')</script>");
            }
        }

        protected void GetDocumentInfo()
        {
            string sqlStr = "SELECT * FROM sqb_document WHERE ID=" + _id;
            DataTable dt = sqlQuery.GetDataTable(sqlStr);
            this._pid = dt.Rows[0]["Folder_ID"].ToString();
            this.documentName.Value = dt.Rows[0]["Name"].ToString();
        }
    }
}