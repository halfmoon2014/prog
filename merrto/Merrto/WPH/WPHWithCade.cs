using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.WPH
{
    public partial class WPHWithCade : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WPHWithCade()
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
            strsql = "select m_Product.id as pid,item_no,M_name from m_Product"+ strsql;
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            ProductDGV.Columns["item_no"].HeaderText = "款号";
            ProductDGV.Columns["item_no"].Width = 80;
            ProductDGV.Columns["M_name"].HeaderText = "品名";
            ProductDGV.Columns["M_name"].Width = 120;
            ProductDGV.Columns["pid"].Visible = false;
            conn.Close();
        }


        private void BTNADD_Click(object sender, EventArgs e)
        {
            WPH.WPHWithCadeNew wphpe = new WPH.WPHWithCadeNew(Convert.ToInt32(ProductDGV[0, ProductDGV.CurrentCell.RowIndex].Value.ToString()));
            wphpe.ShowDialog();
            Brow();
        }

        private void WPHWithCade_Load(object sender, EventArgs e)
        {

        }

        private void ProductDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //ProductDGV = ProductDGV[0, ProductDGV.CurrentCell.RowIndex].Value.ToString();
            Product(ProductDGV[0, ProductDGV.CurrentCell.RowIndex].Value.ToString());
        }
        private void Product(string RowsID)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "";

            strsql = "select S_WithCade.pid,SSID,Sdid,S_WithCade.name,m_Size.name as Sname,m_SizeDetails.name as SDname,Matching from S_WithCade " +
                 "left join m_Size on m_Size.ID=S_WithCade.SSid "+
                 "left join m_SizeDetails on S_WithCade.SDid=m_SizeDetails.id where S_WithCade.pid='" + RowsID + "'";
            
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    WithCodeDGV.DataSource = ds.Tables[0];
                }
                else
                {
                    WithCodeDGV.DataSource = "";
                }
                WithCodeDGV.Columns["Sname"].Width = 40;
                WithCodeDGV.Columns["Sname"].HeaderText = "组别";
                //ProductDGV.Columns["ok"].ReadOnly = false;
                WithCodeDGV.Columns["SDname"].Width = 70;
                WithCodeDGV.Columns["SDname"].HeaderText = "尺码";
                WithCodeDGV.Columns["Matching"].Width = 80;
                WithCodeDGV.Columns["Matching"].HeaderText = "占比";
                WithCodeDGV.Columns["name"].Width = 80;
                WithCodeDGV.Columns["name"].HeaderText = "名称";
                WithCodeDGV.Columns["pid"].Width = 30;
                WithCodeDGV.Columns["pid"].HeaderText = "ID";
                WithCodeDGV.Columns["pid"].Visible = false;
                WithCodeDGV.Columns["SSID"].Visible = false;
                WithCodeDGV.Columns["Sdid"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
