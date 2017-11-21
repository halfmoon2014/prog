using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.OtherSoft
{
    public partial class Form1 : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("Wei");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from t_ICItem", conn);
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("select * from T_CC_StockBill", conn);
            SqlDataAdapter sqlDaper2 = new SqlDataAdapter("select * from T_CC_StockBillEntry where exists(select * from T_CC_StockBill where T_CC_StockBillEntry.fid=T_CC_StockBill.fid and fbillno='GHD20140500004')", conn);
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter("select * from T_stock ", conn);
            SqlDataAdapter sqlDaper4 = new SqlDataAdapter("select * from t_XS_Orderentry ", conn);//where exists(select * from T_CC_StockBill where T_CC_StockBillEntry.fid=T_CC_StockBill.fid and (fbillno='CGD20140500006' or fbillno='CGD20140500022'))
            SqlDataAdapter sqlDaper5 = new SqlDataAdapter("select * from t_XS_Order ", conn);
            SqlDataAdapter sqlDaper6 = new SqlDataAdapter("select * from t_cg_orderentry where exists(select * from t_cg_order where t_cg_orderentry.fid=t_cg_order.fid and (fbillno='CGDD20140500006' or fbillno='CGDD20140500022'))", conn);
            SqlDataAdapter sqlDaper7 = new SqlDataAdapter("select * from t_cg_order where fbillno='CGDD20140500006' or fbillno='CGDD20140500022' or fbillno='CGDD20140500023'", conn);
            SqlDataAdapter sqlDaper8 = new SqlDataAdapter("select * from t_cg_order", conn);
            
            conn.Open();
            sqlDaper.Fill(ds, "ICItem");
            sqlDaper1.Fill(ds, "StockBill");
            sqlDaper2.Fill(ds, "StockBillEntry");
            sqlDaper3.Fill(ds, "stock");
            sqlDaper4.Fill(ds, "XS");
            sqlDaper5.Fill(ds, "XS_Order");
            sqlDaper6.Fill(ds, "cg_orderentry");
            sqlDaper7.Fill(ds, "cg_order");
            sqlDaper8.Fill(ds, "cg_order2");
            conn.Close();
            string ABC = "";
        }
    }
}
