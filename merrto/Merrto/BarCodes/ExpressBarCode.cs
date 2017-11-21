using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.BarCodes
{
    public partial class ExpressBarCode : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public ExpressBarCode()
        {
            InitializeComponent();
        }

        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlConnection JDconn = sqlcon.getcon("Wei");
            DataSet ds = new DataSet();
            if (e.KeyCode == Keys.Enter)
            {
                //"select t_ICItem.FBarCode,sum(fqty)fqty,t_Stock.Fname from T_CC_Inventory left join t_ICItem on t_ICItem.fitemID=T_CC_Inventory.fitemID left join t_Stock on T_CC_Inventory.fstockID=t_Stock.fitemID where t_ICItem.FBarCode like '" + _itemno + "%' and (fstockID='226' or fstockID='228')  group by FBarCode,t_Stock.Fname";
                SqlDataAdapter sqlDaper = new SqlDataAdapter("select BarCode,Storage,STockName from M_BRExpress left join m_ProductStorage on M_BRExpress.pid=m_ProductStorage.pid and M_BRExpress.Sdid=m_ProductStorage.sdid and M_BRExpress.colourID=m_ProductStorage.colorID left join M_stock on M_stock.StockID=m_ProductStorage.StockID where ExpressCode='" + TxtBarCode.Text.ToString() + "'", conn);// and M_BRExpress.StockID=m_ProductStorage.StockID
                conn.Open();
                sqlDaper.Fill(ds, "Storage");
                conn.Close();
                if (ds.Tables["Storage"].Rows.Count > 0)
                {
                    LBLPAsking.Text = TxtBarCode.Text;
                    ProudctDGV.DataSource = ds.Tables["Storage"];
                    ProudctDGV.Columns["BarCode"].HeaderText = "条型码";
                    ProudctDGV.Columns["Storage"].HeaderText = "库位";
                    ProudctDGV.Columns["STockName"].HeaderText = "仓库";
                    ProudctDGV.Width = this.Width / 2;
                    
                    string jdstr = "";
                    for (int i = 0; i < ds.Tables["Storage"].Rows.Count; i++)
                    {
                        if (jdstr != "")
                        {
                            jdstr += ",";
                        }
                        jdstr += "'" + ds.Tables["Storage"].Rows[i]["BarCode"].ToString() + "'";
                    }
                    if (jdstr != "")
                    {
                        SqlDataAdapter JDsda = new SqlDataAdapter("select t_ICItem.FBarCode,sum(fqty)fqty,t_Stock.Fname as stockname from T_CC_Inventory left join t_ICItem on t_ICItem.fitemID=T_CC_Inventory.fitemID left join t_Stock on T_CC_Inventory.fstockID=t_Stock.fitemID " +
                                                               "where FBarCode in (" + jdstr + ") and (fstockID='226' or fstockID='228') group by FBarCode,t_Stock.Fname", JDconn);
                        conn.Open();
                        JDsda.Fill(ds, "JD");
                        conn.Close();
                        if (ds.Tables["JD"].Rows.Count > 0)
                        {
                            this.StrageDgv.DataSource = ds.Tables["JD"];
                            StrageDgv.Columns["FBarCode"].HeaderText = "条型码";
                            StrageDgv.Columns["fqty"].HeaderText = "数量";
                            StrageDgv.Columns["stockname"].HeaderText = "仓库";
                        }
                    }
                }
               
                TxtBarCode.Text = "";
               
            }
        }

        private void ExpressBarCode_Load(object sender, EventArgs e)
        {
            ProudctDGV.Width = this.Width / 2;
        }
    }
}
