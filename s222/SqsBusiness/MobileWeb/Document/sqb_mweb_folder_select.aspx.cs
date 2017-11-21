using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataClass;

namespace SqsBusiness.MobileWeb.Document
{
    public partial class sqb_mweb_folder_select : System.Web.UI.Page
    {
        string _folderName;//文件夹名称
        string _pid;//父文件夹ID
        string _p_folderName;//父文件夹名称
        SqlQuery sqlQuery = new SqlQuery();
        string _uid ;//获取Session中的用户ID  目前用1
        public string _url;
        string url;
        string _type;
        string _folderID;//判断回传的值，1代表人文文档，0代表公共文档
        public string _location;
        string _id;
        string _dateTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SqbMwebUserID"] == null)
            {
                Response.Redirect("../sqb_mweb_login.aspx");
            }
            _uid = Session["SqbMwebUserID"].ToString();
            _folderName= Request.QueryString["folderName"].ToString();
            _pid = Request.QueryString["pid"].ToString();
            _type = Request.QueryString["type"].ToString();
            if (Request.QueryString["dateTime"] != null)
            {
                _dateTime = Request.QueryString["dateTime"].ToString();
            }
            if (Request.QueryString["type"].ToString() == "person")
            {
                _folderID = "1";
            }
            else
            {
                _folderID = "0";
            }
            if (Request.QueryString["id"]!=null)
            {
                _id = Request.QueryString["id"].ToString();
            }
            string sqlStr = "SELECT * FROM sqb_folder WHERE Add_User_ID="+_uid+" AND pid="+_pid+" AND Folder_Type_ID="+_folderID;
            DataTable dt = sqlQuery.GetDataTable(sqlStr);

            var newslabel = new Label();

            if (Request.QueryString["url"] == "document")
            {
                _url = "sqb_mweb_folder_design.aspx?type=person&folderName=" + _folderName+"&dateTime="+_dateTime;
                _location = "sqb_mweb_folder_design.aspx?pid=0&p_folderName=个人文件夹&type=person&dateTime="+_dateTime;
                url = "document";
            }
            else
            {
                _url = "sqb_mweb_document_design.aspx?type=person&folderName=" + _folderName;
                _location = "sqb_mweb_document_design.aspx?pid=0&p_folderName=个人文件夹&type=person";
                url = "folder";
            }

            newslabel.Text = "<div data-role=collapsible-set>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                  + dt.Rows[i]["Name"] + "</h3><a data-transition='none' data-inline='true' data-role='button' onclick=" + '"' + "javascript:location.href='" + _url + "&pid=" + dt.Rows[i]["id"] + "&p_folderName=" + dt.Rows[i]["Name"] + "&id="+_id+"'" + '"' + ">确定</a>"
                  + "<a data-transition='none' data-inline='true' data-role='button' onclick=" + '"' + "javascript:location.href='sqb_mweb_folder_select.aspx?folderName="
                  + _folderName + "&pid=" + dt.Rows[i]["id"] + "&url="+url+"&type="+_type+"&id="+_id+"'" + '"' + ">选择子文件夹</a></div>";
            }

            newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>个人文件夹"
                  +"</h3><a data-transition='none' data-inline='true' data-role='button' onclick="+'"'+"javascript:location.href='"+_url+"&pid=0"  + "&p_folderName=个人文件夹&id="+_id+"'" + '"' + ">确定</a>"+"</div>";

            this.pnlFolder.Controls.Add(newslabel);
        }

        protected void GetBack(object sender, EventArgs e)
        {
            Response.Redirect("sqb_mweb_document_design.aspx?folderName=" + _folderName);
        }
    }
}