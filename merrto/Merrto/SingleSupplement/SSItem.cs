using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.SingleSupplement
{
    public partial class SSItem : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public SSItem()
        {
            InitializeComponent();
        }

        private void SSItem_Load(object sender, EventArgs e)
        {
            ProductDGV();
            ProductSize();
        }

        private void ProductSize()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT Item_no,M_NAME,M_product.ID,SS_Size.id as ssID,SS_Size.[name] as ssName FROM M_product left join ProductSS_Size on ProductSS_Size.pid=M_product.id left join SS_Size on SS_Size.id=ProductSS_Size.SSid";
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
                SizeDGV.Columns["Item_no"].Width = 100;
                SizeDGV.Columns["Item_no"].HeaderText = "款号";
                SizeDGV.Columns["M_NAME"].Width = 100;
                SizeDGV.Columns["M_NAME"].HeaderText = "品名";
                SizeDGV.Columns["ssName"].Width = 100;
                SizeDGV.Columns["ssName"].HeaderText = "配码";
                SizeDGV.Columns["ID"].Width = 30;
                SizeDGV.Columns["ID"].HeaderText = "ID";
                SizeDGV.Columns["ID"].Visible = false;
                SizeDGV.Columns["ssID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ProductDGV()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT Item_no,M_NAME,ID FROM M_product";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    M_ProductDGV.DataSource = ds.Tables[0];

                }
                M_ProductDGV.Columns["Item_no"].Width = 100;
                M_ProductDGV.Columns["Item_no"].HeaderText = "款号";
                M_ProductDGV.Columns["M_NAME"].Width = 100;
                M_ProductDGV.Columns["M_NAME"].HeaderText = "配码名称";
                M_ProductDGV.Columns["ID"].Width = 30;
                M_ProductDGV.Columns["ID"].HeaderText = "ID";
                M_ProductDGV.Columns["ID"].Visible = false;
                
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnEDITItem_Click(object sender, EventArgs e)
        {
            EditItemfrm eif = new EditItemfrm(Convert.ToInt32(M_ProductDGV[2, M_ProductDGV.CurrentCell.RowIndex].Value.ToString()));
            eif.ShowDialog();
        }

        private void M_ProductDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            M_Product(M_ProductDGV[2, M_ProductDGV.CurrentCell.RowIndex].Value.ToString());
        }
        private void M_Product(string RowsID)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "select SS_ProductColourSize.pid,m_Productsub.co_code,s_color,colourid,m_SizeDetails.name as SDName,sdid,Proportion from SS_ProductColourSize " +
                "left join m_Productsub on m_Productsub.id=colourid  " +
                "left join m_SizeDetails on m_SizeDetails.id=SS_ProductColourSize.sdid   " +
                " where SS_ProductColourSize.pid='" + RowsID + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    ColourSizeDGV.DataSource = ds.Tables[0];
                }
                ColourSizeDGV.Columns["co_code"].Width = 60;
                ColourSizeDGV.Columns["co_code"].HeaderText = "色号";
                ColourSizeDGV.Columns["co_code"].ReadOnly = true;
                ColourSizeDGV.Columns["s_color"].Width = 70;
                ColourSizeDGV.Columns["s_color"].HeaderText = "颜色";
                ColourSizeDGV.Columns["s_color"].ReadOnly = true;
                ColourSizeDGV.Columns["SDName"].Width = 60;
                ColourSizeDGV.Columns["SDName"].HeaderText = "尺码";
                ColourSizeDGV.Columns["SDName"].ReadOnly = true;
                ColourSizeDGV.Columns["Proportion"].Width = 60;
                ColourSizeDGV.Columns["Proportion"].HeaderText = "比率";
                ColourSizeDGV.Columns["pid"].Visible = false;
                ColourSizeDGV.Columns["colourid"].Visible = false;
                ColourSizeDGV.Columns["sdid"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SSItemSize eif = new SSItemSize(Convert.ToInt32(SizeDGV[2, SizeDGV.CurrentCell.RowIndex].Value.ToString()));
            eif.ShowDialog();
        }


    }
}
