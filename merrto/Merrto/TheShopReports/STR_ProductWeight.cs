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
    public partial class STR_ProductWeight : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public STR_ProductWeight()
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
            strsql = "select m_Product.id as pid,item_no,M_name from m_Product" + strsql;
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            ProductDGV.Columns["item_no"].HeaderText = "款号";
            ProductDGV.Columns["item_no"].Width = 80;
           
            ProductDGV.Columns["M_name"].HeaderText = "品名";
            ProductDGV.Columns["M_name"].Width = 80;

            ProductDGV.Columns["pid"].Visible = false;


            conn.Close();
        }

        private void ProductDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Product(ProductDGV[0, ProductDGV.CurrentCell.RowIndex].Value.ToString());
        }
        private void Product(string RowsID)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "";
              strsql = "select STR_ProductWeight.pid,Sdid,m_SizeDetails.name as SDname,Weight from STR_ProductWeight " +
                 "left join m_SizeDetails on STR_ProductWeight.SDid=m_SizeDetails.id where STR_ProductWeight.pid='" + RowsID + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    SizeDGV.DataSource = ds.Tables[0];
                }
                //SizeDGV.Columns["Sname"].Width = 40;
                //SizeDGV.Columns["Sname"].HeaderText = "组别";
                SizeDGV.Columns["SDname"].Width = 70;
                SizeDGV.Columns["SDname"].HeaderText = "尺码";
                SizeDGV.Columns["Weight"].Width = 80;
                SizeDGV.Columns["Weight"].HeaderText = "重量";
                SizeDGV.Columns["pid"].Width = 30;
                SizeDGV.Columns["pid"].HeaderText = "ID";
                SizeDGV.Columns["pid"].Visible = false;
                SizeDGV.Columns["Sdid"].Visible = false;
                conn.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void STR_ProductWeight_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TheShopReports.ProductWeightEdit PWD = new TheShopReports.ProductWeightEdit(Convert.ToInt32(ProductDGV[0, ProductDGV.CurrentCell.RowIndex].Value.ToString()));
            PWD.ShowDialog();
            Brow();
        }
    }
}
