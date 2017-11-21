using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
namespace SqsBusiness.MobileWeb.Route
{
    public partial class sqb_mweb_client_info : System.Web.UI.Page
    {

        SqlQuery SqlQuery = new SqlQuery();
        protected String type = "";
        protected String pattern = "";
        protected String code = "";
        protected String client_id = "";
        protected String manage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                loadinfo();
            }

    
            }
        private void loadinfo() {

            manage=Request.QueryString["manage"];
             type = Request.QueryString["type"];
             pattern = Request.QueryString["pattern"];
             code = Request.QueryString["code"];

             String sql = "";
             DataTable MyTable = new DataTable();
             sql = "select id from sqb_client where code='" + code + "'";
             MyTable = SqlQuery.GetDataTable(sql);
            client_id=MyTable.Rows[0][0].ToString();

            

            sql = "select name,address,linkman,phone,mobile,email from sqb_client where code='" + code + "' and user_id=" + Session["SqbMwebUserID"];
            MyTable = SqlQuery.GetDataTable(sql);



            if (MyTable.Rows.Count > 0)
            {
                this.Name.Text = MyTable.Rows[0][0].ToString();
                this.Address.Text = MyTable.Rows[0][1].ToString();
                this.Linkman.Text = MyTable.Rows[0][2].ToString();
                this.Phone.Text = MyTable.Rows[0][3].ToString();
                this.Mobile.Text = MyTable.Rows[0][4].ToString();
                this.Email.Text = MyTable.Rows[0][5].ToString();
            }
            
        }

    }
}