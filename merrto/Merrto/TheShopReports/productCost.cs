using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.TheShopReports
{
    public partial class productCost : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public productCost()
        {
            InitializeComponent();
        }

        private void BtnBrow_Click(object sender, EventArgs e)
        {
            Brow();
        }

        private void Brow()
        {
            string strsql = "";
            if (TXtCade.Text.ToString() != "")
            {
                strsql = "item_no like '%" + TXtCade.Text.ToString() + "%'";
            }

            if (strsql != "")
            {
                strsql = " where " + strsql;
            }
            strsql = "select m_Product.id as pid,item_no,PRICE_TAG,Cost from m_Product" +
                " left join M_productCost on M_productCost.pid=m_Product.id " + strsql;
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            ProductDGV.Columns["item_no"].HeaderText = "款号";
            ProductDGV.Columns["item_no"].Width = 80;
            ProductDGV.Columns["Cost"].HeaderText = "成本价";
            ProductDGV.Columns["Cost"].Width = 80;
            ProductDGV.Columns["PRICE_TAG"].HeaderText = "吊牌价";
            ProductDGV.Columns["PRICE_TAG"].Width = 80;
            ProductDGV.Columns["pid"].Visible = false;
            conn.Close();
        }

        private void BTNADD_Click(object sender, EventArgs e)
        {
            TheShopReports.productCostNew wphpe = new TheShopReports.productCostNew(Convert.ToInt32(ProductDGV[0, ProductDGV.CurrentCell.RowIndex].Value.ToString()));
            wphpe.ShowDialog();
            Brow();
        }
    }
}
