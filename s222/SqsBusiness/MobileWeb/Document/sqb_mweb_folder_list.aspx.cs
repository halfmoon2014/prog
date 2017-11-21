using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;

namespace SqsBusiness.MobileWeb.Document
{
    public partial class sqb_mweb_folder_list : System.Web.UI.Page
    {
        string _folderName;//文件夹名称
        string _pid;//父文件夹ID
        string _p_folderName;//父文件夹名称
        SqlQuery sqlQuery = new SqlQuery();
        string _uid ;//获取Session中的用户ID 
        public string _type = "";
        public string _title;
        string _publicID;//等在根目录下，为了区分是属于个人文档还是公共文档，数据库存放0为个人，-1为公共
        public string _location;//返回的URL
        string _delete;
        string _id;//文档或文件夹的ID
        SqlDML sqlDML = new SqlDML();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SqbMwebUserID"] == null)
            {
                Response.Redirect("../sqb_mweb_login.aspx");
            }
            _uid = Session["SqbMwebUserID"].ToString(); 
            //_folderName = Request.QueryString["folderName"].ToString();
            //_pid = Request.QueryString["pid"].ToString();
            _type = Request.QueryString["type"].ToString();//判断是个人文档还是公共文档
            if (Request.QueryString["pid"] != null)
            {
                _pid = Request.QueryString["pid"].ToString();
                _publicID = _pid;
                //_location = "sqb_mweb_folder_list.aspx?pid=" + _pid + "&type="+_type;
               // _location = Request.UrlReferrer.AbsoluteUri;
                _location = "sqb_mweb_folder_list.aspx?type=" + _type;
            }
            else
            {
                _pid = "0";
                if (_type == "public")
                {
                    _publicID = "-1";
                }
                else
                {
                    _publicID = "0";
                }
                _location = "sqb_mweb_document_manage.aspx";
            }
            if (Request.QueryString["folderName"] != null)
            {
                _folderName = Request.QueryString["folderName"].ToString();
            }
            else
            {
                _folderName = "个人文件夹";
            }
            if (Request.QueryString["id"] != null)
            {
                _id = Request.QueryString["id"].ToString();
                _delete = Request.QueryString["delete"].ToString();
                Delete();
            }
           // string sqlStr = "SELECT * FROM sqb_folder WHERE Add_User_ID=" + uid + " AND pid=" + _pid;
            string sqlStr = "";
            if (_pid == "0")//判断是否为主页面
            {
                if (_type == "public")
                {
                    sqlStr = "SELECT Name,ID,PID,'公共文档' AS P_Name FROM sqb_folder WHERE Add_User_ID=" + _uid + " AND pid=" + "-1" + " AND Folder_Type_ID=0 AND Allow_Content like '%,"+_uid+",%'";
                }
                else
                {
                    sqlStr = "SELECT Name,ID,PID,'个人文件夹' AS P_Name FROM sqb_folder WHERE (Add_User_ID=" + _uid + " OR  Allow_Content like '%,"+_uid+",%')"+"AND pid=" + _pid + " AND Folder_Type_ID=1";
                }
            }
            else
            {
                if (_type == "public")
                {
                    sqlStr = "SELECT Name,ID,PID,'公共文档' AS P_Name FROM sqb_folder WHERE Add_User_ID=" + _uid + " AND pid=" + _pid + " AND Folder_Type_ID=0";
                }
                else
                {
                    sqlStr = "SELECT A.Name,A.ID,A.Pid,B.Name AS P_Name FROM (SELECT Name,Pid,ID FROM sqb_folder WHERE (Add_User_ID=" + _uid + " OR  Allow_Content like '%," + _uid + ",%')" + " AND Pid=" + _pid + ") AS A CROSS JOIN (SELECT Name FROM sqb_folder WHERE ID=" + _pid + ") AS B ";
                }
            }
            DataTable dt = sqlQuery.GetDataTable(sqlStr);

            var newslabel = new Label();

            newslabel.Text = "<a data-inline='true' data-role='button' onclick="+'"'+"javascript:location.href='sqb_mweb_document_design.aspx?type=person'"+'"'+">新建文件夹</a>"+
            "<a data-inline='true' data-role='button' onclick=" + '"' + "javascript:location.href='sqb_mweb_folder_design.aspx?pid=0&p_folderName=个人文件夹&type=person'" + '"' + ">文件上传</a>"+
            "<div data-role=collapsible-set>";
            if (_type == "person")//个人文档
            {
                _title = "个人文件夹";
                //枚举当前目录下的文件夹
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                      + dt.Rows[i]["Name"] + "</h3>";
                    //枚举当前目录下的文件夹的文件
                    DataTable dtCDocument = sqlQuery.GetDataTable("SELECT * FROM sqb_document WHERE Folder_ID=" + dt.Rows[i]["id"] + " AND (Add_User_ID=" + _uid+ "OR  Allow_Content like '%," + _uid + ",%')");
                    foreach (DataRow dr in dtCDocument.Rows)
                    {
                        newslabel.Text = newslabel.Text + "<div data-role=collapsible data-theme='b'><h3>" + dr["Name"] + "</h3>"+ 
                            "<a data-transition='none' data-inline='true' data-role='button' data-theme='b' onclick=" + '"' + 
                            "javascript:location.href='sqb_mweb_folder_design.aspx?p_folderName="+ dt.Rows[i]["Name"] + "&pid=" + dt.Rows[i]["ID"] + "&folderName=" + dr["Name"] + "&id=" + dr["id"] + "&type=person&action=update&dateTime=" + dr["Add_Time"] + "'" + '"' + ">编辑</a>"+ 
                            "<a data-transition='none' data-inline='true' data-role='button'data-theme='b' onclick=" + '"' +
                            "javascript:location.href='Files/" + dr["Document_Path"].ToString() + "'" + '"' + ">下载/查看</a>" +
                            "<a data-transition='none' data-inline='true' data-role='button' data-theme='b' onclick=" + '"' +
                            "if(confirm('确定删除吗？'))location.href='sqb_mweb_folder_list.aspx?flag=true&folderName=" + _folderName + "&pid=0&id=" + dr["id"] + "&type=person&delete=document'" + '"' + ">删除</a></div>";
                    }

                    newslabel.Text = newslabel.Text + 
                        "<a data-transition='none' data-inline='true' data-role='button' onclick=" + '"' + 
                        "javascript:location.href='sqb_mweb_document_design.aspx?folderName="+ dt.Rows[i]["Name"] + "&pid=" + dt.Rows[i]["PID"] + "&p_folderName=" + dt.Rows[i]["P_Name"] + "&id=" + dt.Rows[i]["id"] + "&type=person&action=update'" + '"' + ">编辑</a>" +
                        "<a data-transition='none' data-inline='true' data-role='button' onclick=" + '"' + 
                        "javascript:location.href='sqb_mweb_folder_list.aspx?folderName="+ _folderName + "&pid=" + dt.Rows[i]["id"] + "&type=person'" + '"' + ">子目录</a>"+
                        "<a data-transition='none' data-inline='true' data-role='button' onclick=" + '"' +
                        "if(confirm('确定删除吗？'))location.href='sqb_mweb_folder_list.aspx?flag=true&folderName=" + _folderName + "&pid=0&id=" + dt.Rows[i]["id"] + "&type=person&delete=folder'" + '"' + ">删除</a>"+
                        "<a data-inline='true' data-role='button' onclick=" + '"' + "javascript:location.href='sqb_mweb_folder_design.aspx?pid="+dt.Rows[i]["id"]+"&p_folderName="+dt.Rows[i]["Name"]+"&type=person'" + '"' + ">文件上传</a></div>";
                }
                //枚举当前目录下的文件
                DataTable dtPDocument = sqlQuery.GetDataTable("SELECT * FROM sqb_document WHERE Folder_ID=" + _publicID + " AND (Add_User_ID=" + _uid + " OR  Allow_Content like '%," + _uid + ",%')");
                foreach (DataRow dr in dtPDocument.Rows)
                {
                    newslabel.Text = newslabel.Text + "<div data-role=collapsible data-theme='b'><h3>" + dr["Name"] + "</h3>" + 
                        "<a data-transition='none' data-inline='true' data-role='button' data-theme='b' onclick=" + '"' + 
                        "javascript:location.href='sqb_mweb_folder_design.aspx?p_folderName="+ _folderName + "&pid=" + dr["ID"] + "&folderName=" + dr["Name"] + "&id=" + dr["id"] + "&type=person&action=update&dateTime=" + dr["Add_Time"] + "'" + '"' + ">编辑</a>"+ 
                        "<a data-transition='none' data-inline='true' data-role='button'data-theme='b' onclick=" + '"' +
                        "javascript:location.href='Files/" + dr["Document_Path"].ToString() + "'" + '"' + ">下载/查看</a>" +
                        "<a data-transition='none' data-inline='true' data-role='button' data-theme='b' onclick=" + '"' +
                        "if(confirm('确定删除吗？'))location.href='sqb_mweb_folder_list.aspx?flag=true&folderName=" + _folderName + "&pid=0&id=" + dr["id"] + "&type=person&delete=document'" + '"' + ">删除</a></div>";
                       // "javascript:return comfirm('确定删除吗')" + '"' + ">删除</a></div>";
                        //"if(confirm('are you sure')){window.location.href='../sqb_mweb_main.aspx';}" />

                }
                newslabel.Text = newslabel.Text + "</div> ";
            }
            else//公共文档
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                      + dt.Rows[i]["Name"] + "</h3>";

                    DataTable dtCDocument = sqlQuery.GetDataTable("SELECT * FROM sqb_document WHERE Folder_ID=" + dt.Rows[i]["id"] + " AND (Add_User_ID=" + _uid+" OR Allow_Content like '%,"+_uid+",%')");
                    foreach (DataRow dr in dtCDocument.Rows)
                    {
                        newslabel.Text = newslabel.Text + "<div data-role=collapsible data-theme='b'><h3>" + dr["Name"] + "</h3>"
                       + "<a data-transition='none' data-inline='true' data-role='button'data-theme='b' onclick=" + '"' + "javascript:location.href='Files/" + dr["Document_Path"].ToString() + "'" + '"' + ">下载</a></div>";
                    }
                    newslabel.Text = newslabel.Text 
                       + "<a data-transition='none' data-inline='true' data-role='button' onclick=" + '"' + "javascript:location.href='sqb_mweb_folder_list.aspx?folderName="
                       + _folderName + "&pid=" + dt.Rows[i]["id"] + "&type=public'" + '"' + ">选择子文件夹</a></div>";
                }
                DataTable dtPDocument = sqlQuery.GetDataTable("SELECT * FROM sqb_document WHERE Folder_ID=" + _publicID + " AND (Add_User_ID=" + _uid + " OR Allow_Content like '%," + _uid + ",%')");
                foreach (DataRow dr in dtPDocument.Rows)
                {
                    newslabel.Text = newslabel.Text + "<div data-role=collapsible data-theme='b'><h3>" + dr["Name"] + "</h3>" 
                   + "<a data-transition='none' data-inline='true' data-role='button'data-theme='b' onclick=" + '"' + "javascript:location.href='Files/"+dr["Document_Path"].ToString()
                   + "'" + '"' + ">下载</a></div>";
                }
                _title = "公共文档";
                newslabel.Text = newslabel.Text + "</div>";
            }

            this.pnlFolder.Controls.Add(newslabel);
        }

        protected void Delete()
        {
            string sqlStr = "";
            switch (_delete)
            {
                case "document":
                    sqlStr = "DELETE sqb_document WHERE ID=" + _id;
                    break;
                case "folder":
                    DataTable dtHasChildren = sqlQuery.GetDataTable("select ID from sqb_folder where Pid="+_id+" union all select ID from sqb_document where Folder_ID="+_id);
                    if (dtHasChildren.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('目录下存在文件或文件夹，无法删除')</script>");
                        return;
                    }
                    sqlStr = "DELETE sqb_folder WHERE ID=" + _id;
                    break;
            }
            if (sqlDML.DML(sqlStr) > 0)
            {
                Response.Write("<script>alert('删除成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('删除失败')</script>");
            }
        }
    }
}