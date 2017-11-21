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
	public partial class sqb_bweb_document_manage : System.Web.UI.Page
	{
        string _uid;
        string _pid;
        string _action;
        string _documentName=string.Empty;
        string _id;
        public string _type;
        public string _title="个人文档";
        SqlQuery sqlQuery = new SqlQuery();
        SqlDML sqlDML = new SqlDML();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["SqbBwebUserID"] == null)
            {
                //Response.Redirect("../sqb_bweb_login.aspx");
               // Response.Write("<script>window.parent.location.open='../sqb_bweb_login.aspx'</script>");
                Response.Write("<script>window.parent.location.href='../sqb_bweb_login.aspx'</script>");
            }
            _type=Request.QueryString["type"].ToString();
            if (_type == "public")
            {
                _title = "公共文档";
            }
		}

    }
}