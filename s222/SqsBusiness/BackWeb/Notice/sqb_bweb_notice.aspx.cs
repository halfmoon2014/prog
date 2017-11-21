using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
using System.Data.SqlClient;
namespace SqsBusiness.BackWeb.Notice
{
	public partial class sqb_bweb_notice : System.Web.UI.Page
	{
        SqlQuery SqlQuery = new SqlQuery();
        DataTable mtb = new DataTable();

		protected void Page_Load(object sender, EventArgs e)
		{
            string str = "select Title,Notice_Content,Notice_Type_ID,Date,Active_Time,Add_User_Name from sqb_notice";
            mtb = SqlQuery.GetDataTable(str);

            string result = "";
           // result = dt2Json.Dtb2Json(dt);
            
            Response.Write(result);
            Response.End();
		}
	}
}