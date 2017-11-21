using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto
{
    public partial class WphProduct : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphProduct()
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
            strsql = "select m_Product.id as pid,cid,item_no,Wph_Item,co_code,s_color,PRICE_TAG,year,WPh_Category.name as Cname,pname,sdprice,class from m_Productsub" +
                " left join m_Product on m_Productsub.pid=m_Product.id " +
                " left join Wph_Product on Wph_Product.pid=m_Product.id and m_Productsub.id=Wph_Product.colourid" +
                " left join WPh_Category on Wph_Product.cid=WPh_Category.id" + strsql;
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            ProductDGV.Columns["item_no"].HeaderText = "款号";
            ProductDGV.Columns["item_no"].Width = 80;
            ProductDGV.Columns["Wph_Item"].HeaderText = "新款号";
            ProductDGV.Columns["Wph_Item"].Width = 80;
            ProductDGV.Columns["co_code"].HeaderText = "色号";
            ProductDGV.Columns["co_code"].Width = 80;
            ProductDGV.Columns["s_color"].HeaderText = "颜色";
            ProductDGV.Columns["s_color"].Width = 80;
            ProductDGV.Columns["PRICE_TAG"].HeaderText = "吊牌价";
            ProductDGV.Columns["PRICE_TAG"].Width = 80;
            ProductDGV.Columns["year"].HeaderText = "年份";
            ProductDGV.Columns["year"].Width = 60;
            ProductDGV.Columns["Cname"].HeaderText = "类别";
            ProductDGV.Columns["Cname"].Width = 80;
            ProductDGV.Columns["pname"].HeaderText = "品名";
            ProductDGV.Columns["pname"].Width = 60;
            ProductDGV.Columns["sdprice"].HeaderText = "标准价";
            ProductDGV.Columns["sdprice"].Width = 80;
            ProductDGV.Columns["class"].HeaderText = "商品分类";
            ProductDGV.Columns["class"].Width = 80;
            ProductDGV.Columns["pid"].Visible = false;
            ProductDGV.Columns["cid"].Visible = false;

            conn.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNADD_Click(object sender, EventArgs e)
        {
            WPhProductEdit wphpe = new WPhProductEdit(Convert.ToInt32(ProductDGV.Rows[ProductDGV.CurrentCell.RowIndex].Cells["PID"].Value.ToString()), ProductDGV.Rows[ProductDGV.CurrentCell.RowIndex].Cells["co_code"].Value.ToString());
            wphpe.ShowDialog();
            Brow();
        }
    }
}
