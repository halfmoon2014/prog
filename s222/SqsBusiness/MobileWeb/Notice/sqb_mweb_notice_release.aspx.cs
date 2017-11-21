using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using DataClass;
namespace SqsBusiness.MobileWeb
{
    public partial class sqb_mweb_notice__release : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlQuery SqlQuery = new SqlQuery();
            DataTable MyTable = new DataTable();

            //String Data =
            

            string Date = Request.QueryString["Date"];
            string Title = Request.QueryString["Title"];
            string Notice_Content = Request.QueryString["Notice_Content"];
            string ID = Request.QueryString["ID"];
            
            string sql = "select Date,Title,Notice_Content,ID from sqb_notice"; //查询数据
            MyTable = SqlQuery.GetDataTable(sql);
            // where Date like '%" + Date + "%' and Title like '%"+Title+"%'and Notice_Content like '%"+Notice_Content+"%'


            
            var newslabel = new Label();

            newslabel.Text = "<div data-role=collapsible-set>";
            for (int i = 0; i < MyTable.Rows.Count; i++)
            {
                //newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                //  + MyTable.Rows[i][1] + "</h3><p>" + MyTable.Rows[i][0]
                //  + "</br>" + MyTable.Rows[i][1] + "</br>" + MyTable.Rows[i][2]
                //  + "</br>" + "<a href=sqb_mweb_client_info.aspx?code=" +
                //  MyTable.Rows[i][0] + " data-role=button data-icon=home>查看</a></div>";
                
                newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                + MyTable.Rows[i][1] + "</h3><p>" + MyTable.Rows[i][0]
                + "</br>" + MyTable.Rows[i][1] + "</br>" + MyTable.Rows[i][2]
                + "</br><a data-role=button data-icon=home onClick=goto1(" + MyTable.Rows[i][3] + ")>查看</a></div>";
                //&nbsp<asp:Button ID=Button1 runat=server OnClick=goto1 Text=查看 /></asp:Button></div>";
                
                //<input type=button onclick=goto1 runat=server text=查看 /></div>";
               
         
        
                //<a data-role=button data-icon=home onclick=goto1(" + MyTable.Rows[i][0] + ")>查看</a></div>";

                //String data = this.data.

            }

            newslabel.Text = newslabel.Text + "</div>";

            this.Pnlist.Controls.Add(newslabel);
        }
        public string data { get; set; }

      
    }
}