using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.IO;

namespace SqsBusiness.MobileWeb.Document
{
    public partial class sqb_mweb_folder_design : System.Web.UI.Page
    {
        public string _pid; //文件夹ID
        string _folderName;//文件夹名称
        string _documentName;//文件名称
        public string _dateTime;//文件创建日期
        public string _action = "";//执行类型，更新，插入或删除
        string _uid; //用户ID
        public string _id = "";//文件ID
        SqlDML sqlDML = new SqlDML();
        public string _type = "person";//个人文件夹还是公共文档
        FileUpload upfile = new FileUpload();
        //public string _location = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SqbMwebUserID"] == null)
            {
                Response.Redirect("../sqb_mweb_login.aspx");
            }
            _uid = Session["SqbMwebUserID"].ToString(); ;
            if (Request.QueryString["pid"] != null)
            {
                _pid = Request.QueryString["pid"].ToString();
            }
            //else
            //{
            //    _location = "javascript:location.href='sqb_mweb_document_manage.aspx'";
            //}
            //_type = Request.QueryString["type"].ToString();
            if (Request.QueryString["p_folderName"] != null)
            {
                _folderName = Request.QueryString["p_folderName"].ToString();
                this.folderName.Value = _folderName;
            }
            if (Request.QueryString["folderName"] != null)
            {
                _documentName = Request.QueryString["folderName"].ToString();
                this.documentName.Value = _documentName;
            }
            if (Request.QueryString["dateTime"] != null)
            {
                _dateTime = Request.QueryString["dateTime"].ToString();
                this.date.Value = _dateTime;
            }
            if (Request.QueryString["action"] != null)
            {
                _action = Convert.ToString(Request.QueryString["action"].ToString());
                //Document();
            }
            else
            {
                pnlUpLoad.Controls.Add(upfile);
            }
            if (Request.QueryString["id"] != null)
            {
                _id = Convert.ToString(Request.QueryString["id"].ToString());
            }
            //if (Request.QueryString["ac"] != null) //如果是ajax请求，则执行login方法
            //{
            //    Document();
            //}
        }

        protected void save_Click(object sender, EventArgs e)
        {
            string sqlStr = "";
            if (this.documentName.Value.Trim()=="")
            {
                return;
            }
            switch (_action)
            {
                case "":
                    //    sqlStr = "INSERT INTO [sqb_document]" +
                    //   "([Name]" +
                    //   ",[Folder_ID]" +
                    //   ",[Document_Path]" +
                    //   ",[Add_User_ID]" +
                    //   ",[Add_Time])" +
                    //   " VALUES" +
                    //   "('" + _folderName + "'" +
                    //   "," + _pid +
                    //   ",''" +
                    //   "," + _uid +
                    //   ",Convert(DateTime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'))";
                    //string filetype = upfile.PostedFile.ContentType; //文件类型
                    //string username = Session["SqbMwebUserName"].ToString(); //用户名
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
                     ",'" + _uid+"/"+filename + "'" +
                     "," + _uid +
                     ",Convert(DateTime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'))";
                    }
                    else
                    {
                        Response.Write("<script>alert('请选择文件')</script>");
                        return;
                    }
                    break;
                case "update":
                    sqlStr = "UPDATE [sqb_document]" +
                           "SET [Name] ='" + _documentName + "'" +
                            "  ,[Folder_ID] = " + _pid +
                             " ,[Document_Path] = ''" +
                             " ,[Update_User_ID] = " + _uid +
                             " ,[Update_Time] = Convert(DateTime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:dd") + "')" +
                            " WHERE ID=" + _id;
                    break;

                case "delete":
                    sqlStr = "DELETE sqb_document WHERE ID=" + _id;
                    break;
            }
            if (sqlDML.DML(sqlStr) > 0)
            {
                Response.Write("<script>alert('保存成功')</script>");
                Response.Redirect("sqb_mweb_folder_list.aspx?type=person");
            }
            else
            {
                Response.Write("<script>alert('保存成功')</script>");
            }
        }
    }
}