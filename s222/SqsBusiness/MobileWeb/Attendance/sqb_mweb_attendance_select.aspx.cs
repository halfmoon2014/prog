using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;

namespace SqsBusiness.MobileWeb.Attendance
{
    public partial class sqb_mweb_attendance_select : System.Web.UI.Page
    {
        SqlQuery sqlQuery = new SqlQuery();
        string _uid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SqbMwebUserID"] == null)
            {
                Response.Redirect("../sqb_mweb_login.aspx");
            }
            string dateStart = Request.QueryString["dateStart"];
            string dateEnd = Request.QueryString["dateEnd"];
            string type = Request.QueryString["type"];
            _uid = Session["SqbMwebUserID"].ToString();

            string sqlStr = "SELECT * FROM sqb_attendance WHERE Sign_Time>=Convert(DateTime,'" + dateStart + " 00:00:00') and Sign_Time<=Convert(DateTime,'" + dateEnd + " 23:59:59') AND User_ID="+_uid;//用户ID从session中获得，暂时还没写
            if (type != "全部")
            {
                sqlStr += "AND SignType='"+type+"'";
            }
            sqlStr += " ORDER BY Sign_Time";
            DataTable dt = sqlQuery.GetDataTable(sqlStr);

            var newslabel = new Label();

            newslabel.Text = "<div data-role=collapsible-set>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                  + dt.Rows[i]["Sign_Time"] +"  "
                  + dt.Rows[i]["SignType"] + "</h3><h4>备注</h4>" 
                  + dt.Rows[i]["Note"] + "</br></div>";
            }


            newslabel.Text = newslabel.Text + "</div>";

            this.pnlSelect.Controls.Add(newslabel);
        }
    }
}