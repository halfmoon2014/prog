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
    public partial class sqb_mweb_massage_manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlQuery sqlquery = new SqlQuery();
            DataTable MyTable = new DataTable();

            string Date = Request.QueryString["Date"];
            string Title = Request.QueryString["Title"];
            string content = Request.QueryString["Content"];
            string username = Session["SqbMwebUserName"].ToString();
            String userid = Session["SqbMwebUserID"].ToString();
            //string[] Recipientarr = Readuser.Split(';');

            string sql = "select Date,Title,Recipient,Readuser,ID from sqb_message"; //查询数据
            MyTable = sqlquery.GetDataTable(sql);

            var newslabel = new Label();
            string label = "<asp:Label ID=Label1 runat=server Text=Label>*</asp:Label>";
            newslabel.Text = "<div data-role=collapsible-set>";
            for (int i = 0; i < MyTable.Rows.Count; i++)
            {
                if (MyTable.Rows[i][3].ToString().IndexOf(username) >= 0)
                {
                    newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                    + MyTable.Rows[i][1] + "</h3><p>" + MyTable.Rows[i][0]
                    + "</br>" + MyTable.Rows[i][1] + "</br>" + MyTable.Rows[i][2]
                    + "</br><a data-role=button data-icon=home onclick=goto1(" + MyTable.Rows[i][4] + ")>查看</a></div>";
                }
                else
                {
                    newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                    + MyTable.Rows[i][1] + label + "</h3><p>" + MyTable.Rows[i][0]
                    + "</br>" + MyTable.Rows[i][1] + "</br>" + MyTable.Rows[i][2]
                    + "</br><a data-role=button data-icon=home onclick=goto1(" + MyTable.Rows[i][4] + ")>查看</a></div>";
                }
                //if (MyTable.Rows[i][3].ToString() == Readuser+";")//判断登入名是否存在
                //{
                //    newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                //    + MyTable.Rows[i][1] + "</h3><p>" + MyTable.Rows[i][0]
                //    + "</br>" + MyTable.Rows[i][1] + "</br>" + MyTable.Rows[i][2]
                //    + "</br><a data-role=button data-icon=home onclick=goto1(" + MyTable.Rows[i][4] + ")>查看</a></div>";
                //}
                //else
                //{
                //    newslabel.Text = newslabel.Text + "<div data-role=collapsible><h3>"
                //    + MyTable.Rows[i][1] +"(未读)"+ "</h3><p>" + MyTable.Rows[i][0]
                //    + "</br>" + MyTable.Rows[i][1] + "</br>" + MyTable.Rows[i][2]
                //    + "</br><a data-role=button data-icon=home onclick=goto1(" + MyTable.Rows[i][4] + ")>查看</a></div>";

                //    string str = "update Readuser=" + MyTable.Rows[i][3].ToString() + Readuser + "from sqb_message where Add_User_ID = " + userid + " ";
                //}
            }

            newslabel.Text = newslabel.Text + "</div>";

            this.Pnlist.Controls.Add(newslabel);
        }
    }
}