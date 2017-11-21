using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
using System.Data.SqlClient;
namespace SqsBusiness.MobileWeb
{
    public partial class sqb_mweb__Notice_detail : System.Web.UI.Page
    {    
       SqlQuery SqlQuery = new SqlQuery();
        //protected string code; 
        protected string Notice_Content; 
        protected string Data;
        protected int id;
        //protected string Title;
        protected void Page_Load(object sender, EventArgs e)
        {

           if (!IsPostBack)
            {   Data = Request.QueryString["Data"];
                Title = Request.QueryString["Title"];
                Notice_Content = Request.QueryString["Notice_Content"];
                //读取ID
                //loadinfo(id: Int32.Parse(Request.QueryString["id"]));
                id = Int32.Parse(Request.QueryString["id"]);
                loadinfo(id);
            }
         
         }
        protected void loadinfo(int id)
        {
            DataGrid Dg = new DataGrid();


            String sql = "select Date,Title,Notice_content from sqb_notice where ID = '" + id + "'";
            Dg.DataSource = SqlQuery.GetDataTable(sql);

            Dg.DataBind();
          
            if (Dg.Items.Count > 0)
            {

                this.text1.Value = Dg.Items[0].Cells[0].Text +"----" +Dg.Items[0].Cells[1].Text;
                this.text2.Value = Dg.Items[0].Cells[2].Text;
            }

        }
        
    }
         
}