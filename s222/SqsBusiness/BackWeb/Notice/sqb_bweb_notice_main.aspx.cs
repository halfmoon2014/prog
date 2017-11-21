using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataClass;
namespace SqsBusiness.BackWeb.Notice
{
	public partial class sqb_bweb_notice_main : System.Web.UI.Page
	{
        public string _ID;
        SqlQuery SqlQuery = new SqlQuery();
        DataTable mytable = new DataTable();
        DataTableToJson dt2Json = new DataTableToJson();
        SqlDML sqlDML = new SqlDML();
        string result = "";
        public string _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] != null)
            {
                GetTJson();

                Label1.Text = "1 is OK";
            }

            //string i= Request.Form["id"];
                if (Request.Form["ID"] != null)
                {
                    _id = Request.Form["ID"].ToString();
                    Delete();
                }

        }
        public void Delete()
        {
            string sqlStr = "DELETE sqb_notice WHERE ID=" + _id;
            if (sqlDML.DML(sqlStr) > 0)
            {
                Response.Write(GetDJson());
                Response.End();
            }
            else
            {
            }
        }

        //public string GetJson()
        //{
        //    string sqlStr = "select * from sqb_notice";
        //    mytable = SqlQuery.GetDataTable(sqlStr);
        //    return dt2Json.Dtb2Json(mytable);
        //}
        public void GetTJson()
        {
            string str = "select ID,Title,Notice_Content,Notice_Type_ID,Date,Active_Time,Add_User_Name from sqb_notice";
            mytable = SqlQuery.GetDataTable(str);
            result = dt2Json.Dtb2Json(mytable);
            
            Response.Write(result);
            Response.End();
            
        }
        public string GetDJson()
        {
            string sqlStr = "select * from sqb_notice  WHERE ID=" + _id;
            mytable = SqlQuery.GetDataTable(sqlStr);


            return dt2Json.Dtb2Json(mytable);            
            Response.Write(result);
            Response.End();
        }
	}
}