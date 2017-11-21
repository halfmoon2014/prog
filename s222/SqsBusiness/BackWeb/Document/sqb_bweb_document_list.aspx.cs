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
    public partial class sqb_bweb_document_list : System.Web.UI.Page
    {
        public string _pid;
        SqlQuery sqlQuery = new SqlQuery();
        DataTable dt = new DataTable();
        DataTableToJson dt2Json = new DataTableToJson();
        SqlDML sqlDML = new SqlDML();
        public string _id;
        public string _action;
        public string _type;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pid"] != null)
            {
                _pid = Request.QueryString["pid"];
                if (_pid == "")
                {
                    if (Request.QueryString["type"] == "public")
                    {
                        _pid = "-1";
                        _type = "public";
                    }
                    else
                    {
                        _pid = "0";
                        _type = "person";
                    }
                }

            }
            else
            {
                if (Request.QueryString["type"] == "public")
                {
                    _pid = "-1";
                    _type = "public";
                }
                else
                {
                    _pid = "0";
                    _type = "person";
                }
            }
            if (Request.QueryString["type"] != null)
            {
                _type = Request.QueryString["type"].ToString();
            }
            //if (Request.QueryString["type"] == "public")
            //{
            //    _pid = "-1";
            //    _type = "public";
            //}
            //else
            //{
            //    _pid = "0";
            //    _type = "person";
            //}

            if (Request.QueryString["mode"] != null)
            {
                GetDocumentJson();
            }

            if (Request.Form["id"] != null)
            {
                _id = Request.Form["id"].ToString();
                Delete();
            }
        }

        //获得文档列表
        public void GetDocumentJson()
        {
            Response.Write(dt2Json.Dtb2Json("SELECT TOP " + Convert.ToInt32(Request["rows"].ToString()) + " *  FROM sqb_document  D inner join sqb_users U on D.Add_User_ID=U.ID WHERE D.id >= (  	SELECT ISNULL(MAX(id),0)   	FROM   (  SELECT TOP (" + Convert.ToInt32(Request["rows"].ToString()) + "*(" + Convert.ToInt32(Request["page"].ToString()) + "-1)+1) id FROM sqb_document 	WHERE Folder_ID=" + _pid + " ORDER BY id ) A )AND Folder_ID="+_pid+" ORDER BY D.id", "SELECT COUNT(*) FROM sqb_document D inner join sqb_users U on D.Add_User_ID=U.ID WHERE D.Folder_ID=" + _pid));
            Response.End();
        }

        public void Delete()
        {
            string sqlStr = "DELETE sqb_document WHERE ID="+_id;
            if (sqlDML.DML(sqlStr) > 0)
            {
                Response.Write(GetJson());
                Response.End();
            }
            else
            {
 
            }
        }

        public string GetJson()
        {
            string sqlStr = "SELECT D.*,U.UserName FROM sqb_document D inner join sqb_users U on D.Add_User_ID=U.ID WHERE D.Folder_ID=" + _pid;
            dt = sqlQuery.GetDataTable(sqlStr);
            return dt2Json.Dtb2Json(dt);
        }
    }
}