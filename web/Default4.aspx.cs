using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.DataBase;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string commandText = "INSERT tltest(a,b) VALUES(1,2);INSERT [test].test.dbo.tesaa(aa,[VAR]) VALUES(1,'a'); ";

       //object my=  SqlHelper.ExecuteScalar("Data Source=192.168.35.23;Initial Catalog=tlsoft;User ID=lllogin;Password=rw1894tla;", CommandType.Text, commandText);

       commandText = "INSERT tltest(a,b)values('a','b');INSERT [192.168.35.11].fxdb.dbo.test12(a,b)values('a','b')";
        
       object my = SqlHelper.ExecuteScalar("Data Source=192.168.35.10;Initial Catalog=tlsoft;User ID=ABEASD14AD;Password=+AuDkDew;", CommandType.Text, commandText);
    }
}