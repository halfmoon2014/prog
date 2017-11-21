using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.SingleSupplement
{
    public partial class SS_WithCade : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public SS_WithCade()
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
            ProductDGV.Columns["M_name"].Width = 120;
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
            string strsql1 = "";
            strsql = "select SS_SizeWithCade.pid,SSID,Sdid,m_Size.name as Sname,m_SizeDetails.name as SDname,Matching from SS_SizeWithCade " +
                 "left join m_Size on m_Size.ID=SS_SizeWithCade.SSid " +
                 "left join m_SizeDetails on SS_SizeWithCade.SDid=m_SizeDetails.id where SS_SizeWithCade.pid='" + RowsID + "'";

            strsql1 = "select SS_ColourWithCade.pid,colourID,Co_Code,S_color,Matching from SS_ColourWithCade " +
                "left join M_ProductSub on M_ProductSub.ID=colourID where SS_ColourWithCade.pid='" + RowsID + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter(strsql1, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds,"Size");
                sqlDaper1.Fill(ds,"Colour");
                conn.Close();
                if (ds.Tables["Size"].Rows.Count > 0)
                {
                    SizeDGV.DataSource = ds.Tables["Size"];
                    SizeDGV.Columns["Sname"].Width = 40;
                    SizeDGV.Columns["Sname"].HeaderText = "组别";
                    //ProductDGV.Columns["ok"].ReadOnly = false;
                    SizeDGV.Columns["SDname"].Width = 70;
                    SizeDGV.Columns["SDname"].HeaderText = "尺码";
                    SizeDGV.Columns["Matching"].Width = 80;
                    SizeDGV.Columns["Matching"].HeaderText = "占比";
                    //WithCodeDGV.Columns["name"].Width = 80;
                    //WithCodeDGV.Columns["name"].HeaderText = "名称";
                    SizeDGV.Columns["pid"].Width = 30;
                    SizeDGV.Columns["pid"].HeaderText = "ID";
                    SizeDGV.Columns["pid"].Visible = false;
                    SizeDGV.Columns["SSID"].Visible = false;
                    SizeDGV.Columns["Sdid"].Visible = false;
                }
                else
                {
                    SizeDGV.DataSource = "";
                }
                if (ds.Tables["Colour"].Rows.Count > 0)
                {
                    ColourDgv.DataSource = ds.Tables["Colour"];
                    ColourDgv.Columns["Co_Code"].Width = 40;
                    ColourDgv.Columns["Co_Code"].HeaderText = "代码";
                    ColourDgv.Columns["Matching"].Width = 40;
                    ColourDgv.Columns["Matching"].HeaderText = "占比";
                    ColourDgv.Columns["S_color"].Width = 100;
                    ColourDgv.Columns["S_color"].HeaderText = "颜色";
                    ColourDgv.Columns["colourID"].Visible = false;
                    ColourDgv.Columns["pid"].Visible = false;
                }
                else
                {
                    ColourDgv.DataSource = "";
                }
                
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BTNSizeADD_Click(object sender, EventArgs e)
        {
            SS_SizeWithCade size = new SS_SizeWithCade(Convert.ToInt32(ProductDGV[0, ProductDGV.CurrentCell.RowIndex].Value.ToString()));
            size.ShowDialog();
        }

        private void BtnColourAdd_Click(object sender, EventArgs e)
        {
            SS_ColourWithCade size = new SS_ColourWithCade(Convert.ToInt32(ProductDGV[0, ProductDGV.CurrentCell.RowIndex].Value.ToString()));
            size.ShowDialog();
        }
    }
}
