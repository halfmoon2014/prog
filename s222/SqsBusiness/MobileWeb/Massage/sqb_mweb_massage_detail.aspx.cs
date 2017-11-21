using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
using System.Data.SqlClient;
namespace SqsBusiness.MobileWeb.Massage
{
    public partial class sqb_mweb_massage_detail : System.Web.UI.Page
    {
        protected string Notice_Content;
        protected string Data;
        //protected string Title;
        protected string Readuser;
        protected string username;
        protected String userid;
        protected int id;
        DataGrid Dg = new DataGrid();
        SqlQuery SqlQuery = new SqlQuery();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Data = Request.QueryString["Data"];
                Title = Request.QueryString["Title"];
                Notice_Content = Request.QueryString["Content"];
                username = Session["SqbMwebUserName"].ToString();
                userid = Session["SqbMwebUserID"].ToString();
                //读取ID
                id = Int32.Parse(Request.QueryString["ID"]);
                loadinfo(id);

                //string sqlReadUser = "select ReadUser,Date from sqb_message where ID = " + id + "and Date = '" + Dg.Items[0].Cells[0].Text + "' ";
                //Dg.DataSource = SqlQuery.GetDataTable(sqlReadUser);
                //string str = "update  sqb_message set ReadUser = '" + Dg.Items[0].Cells[0].Text + "' +'" + username + "'+';' where Add_User_ID=" + userid + " and Date = " + Dg.Items[0].Cells[1].Text + "";
                //Dg.DataSource = SqlQuery.GetDataTable(str);
                //Dg.DataBind();

            }
            
            string select = "select ReadUser from sqb_message where ID="+id+"";
            DataTable mytable = new DataTable();
            mytable = SqlQuery.GetDataTable(select);
            int a = mytable.Rows.Count;int i = 0;
            String insert = "update sqb_message set ReadUser = ReadUser + '" + username + ";'  where ID = " + id + "";
            if (mytable.Rows[0][0].ToString() =="")
            {

                i += SqlQuery.sqlselect(insert);
            }
            else
            {
                if (mytable.Rows[0][0].ToString().IndexOf(username+";") >= 0)
                { 
                    
                }
                else
                {
                   i += SqlQuery.sqlselect(insert);
                }
            }
        }
        protected void loadinfo(int id)
        {


            

            String sql = "select Date,Title,Content from sqb_message where ID = '" + id + "'";
            Dg.DataSource = SqlQuery.GetDataTable(sql);

            Dg.DataBind();

            if (Dg.Items.Count > 0)
            {

                this.text1.Value = Dg.Items[0].Cells[0].Text + "----" + Dg.Items[0].Cells[1].Text;
                this.text2.Value = Dg.Items[0].Cells[2].Text;
                
            }


        }
    }
}