using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.DataBase;
using System.Collections;
public partial class test_sqlwho : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String sql = "exec sp_who;exec sp_who_lock;";
        String connectionString = "Data Source=192.168.35.11;Initial Catalog=master;User ID=ABEASD14AD;Password=+AuDkDew;";
        DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql);
        string html = "";
        string sqlwhere = "";
        List<String> listw = new List<String>();
        if (hostname.Value != "")
        {

            listw.Add("hostname='" + hostname.Value + "'");
        }
        if (blk.Checked)
        {
            listw.Add("blk<>0");
        }
        sqlwhere = string.Join(" and ", listw);
        foreach (DataRow dr in ds.Tables[0].Select(sqlwhere))
        {
            html += "<tr><td>" + dr["spid"].ToString() + "</td><td>" + dr["ecid"].ToString() + "</td><td>" + dr["status"].ToString() + "</td><td>" + dr["loginame"].ToString() + "</td><td>" + dr["hostname"].ToString() + "</td><td>" + dr["blk"].ToString() + "</td><td>" + dr["dbname"].ToString() + "</td><td>" + dr["cmd"].ToString() + "</td><td>" + dr["request_id"].ToString() + "</td></tr>";
        }
        spwho.InnerHtml = "<table class='mytable'><tr><td>spid</td><td>ecid</td><td>status</td><td>loginame</td><td>hostname</td><td>blk</td><td>dbname</td><td>cmd</td><td>request_id</td></tr>" + html + "</table>";

        string who_lock_html = "";
        for (int i = 1; i <= ds.Tables.Count - 1; i++)
        {
            string table = "";
            foreach (DataRow dr in ds.Tables[i].Rows)
            {
                string row = "";
                foreach (DataColumn dc in ds.Tables[i].Columns)
                {
                    row += "<td>" + dr[dc.ColumnName].ToString() + "</td>";
                }
                table += "<tr>" + row + "</tr>";
            }
            string th = "";
            foreach (DataColumn dc in ds.Tables[i].Columns)
            {
                th += "<td>" + dc.ColumnName.ToString() + "</td>";
            }
            th = "<tr>" + th + "</tr>";
            table = "<table class='mytable'>" + th + table + "</table>";
            who_lock_html += table;
        }
        spwholock.InnerHtml = who_lock_html;


        if (sql3.Value != "")
        {
            sql = sql3.Value.Trim();
            DataSet ds3 = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, sql);

            string html3 = "";
            for (int i = 0; i < ds3.Tables.Count ; i++)
            {
                string table = "";
                foreach (DataRow dr in ds3.Tables[i].Rows)
                {
                    string row = "";
                    foreach (DataColumn dc in ds3.Tables[i].Columns)
                    {
                        row += "<td>" + dr[dc.ColumnName].ToString() + "</td>";
                    }
                    table += "<tr>" + row + "</tr>";
                }
                string th = "";
                foreach (DataColumn dc in ds3.Tables[i].Columns)
                {
                    th += "<td>" + dc.ColumnName.ToString() + "</td>";
                }
                th = "<tr>" + th + "</tr>";
                table = "<table class='mytable'>" + th + table + "</table>";
                html3 += table;
            }
            div3.InnerHtml = html3;
        }
    }
}