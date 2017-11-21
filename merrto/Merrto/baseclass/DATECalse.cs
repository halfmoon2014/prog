using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Merrto.baseclass
{
     public class DATECalse
    {
         baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();

         public string uppacking(string dboname, string datefiled)
         {
             string Cade_ = "";
             SqlConnection conn = sqlcon.getcon("");
             DataSet ds = new DataSet();
             string sqlselect;
             sqlselect = "select max(cade) as cade from " + dboname + " where cade like '%" + datefiled + "%'";
             SqlDataAdapter sqlDaper = new SqlDataAdapter(sqlselect, conn);
             conn.Open();
             sqlDaper.Fill(ds);
             if (ds.Tables[0].Rows[0]["Cade"].ToString() == "")
             {
                 Cade_ = "0001";
             }
             else
             {

                 Cade_ = ("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(2 +
                      datefiled.Length, 4)) + 1).ToString()).Substring(("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(2 +
                     datefiled.Length, 4)) + 1).ToString()).Length - 4, 4);
             }
             conn.Close();
             return Cade_;
         }
         public string uppacking(string dboname,string datefiled,string formID)
         {
             string Cade_ = "";
             SqlConnection conn = sqlcon.getcon("");
             DataSet ds = new DataSet();
             string sqlselect;
             sqlselect = "select max(cade) as cade from " + dboname + " where cade like '" + formID+datefiled + "%'";
             SqlDataAdapter sqlDaper = new SqlDataAdapter(sqlselect, conn);
             conn.Open();
             sqlDaper.Fill(ds);
             if (ds.Tables[0].Rows[0]["Cade"].ToString() == "")
             {
                 Cade_ = "00001";
             }
             else
             {
                Cade_ = ("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(formID.Length +datefiled.Length, 5)) + 1).ToString()).Substring(("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(formID.Length +
                     datefiled.Length, 5)) + 1).ToString()).Length - 5, 5);
             }
             conn.Close();
             return formID + datefiled+Cade_;
         }
    }
}
