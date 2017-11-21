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
    public partial class Product : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public Product()
        {
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            product("",0);
        }
        private void product(string where_,int check)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT ITEM_NO,M_name,S_COLOR,CO_CODE,[name] as SizeName FROM m_product "+
                            "LEFT JOIN m_ProductSub ON m_ProductSub.PID=m_product.ID " +
                            "left join m_ProductSize on m_ProductSize.PID=m_product.ID "+
                            "left join m_Size on m_ProductSize.sizeid=m_Size.ID where ITEM_NO like '%" + where_ + "%'";
            if (check == 1)
            {
                strsql = strsql + " and not exists(select * from m_ProductSub where m_ProductSub.PID=m_product.ID)";
            }
            if(check==2)
            {
                strsql = strsql + " and not exists(select * from m_ProductSize where m_ProductSize.PID=m_product.ID)";
            }
            if (check == 3)
            {
                strsql = strsql + " and not exists(select * from m_ProductSize where m_ProductSize.PID=m_product.ID) and not exists(select * from m_ProductSub where m_ProductSub.PID=m_product.ID)";
            }
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    ProductDG.DataSource = ds.Tables[0];
                }
                ProductDG.Columns["ITEM_NO"].Width = 80;
                ProductDG.Columns["ITEM_NO"].HeaderText = "货号";
                ProductDG.Columns["M_name"].Width = 120;
                ProductDG.Columns["M_name"].HeaderText = "品名";
                ProductDG.Columns["CO_CODE"].Width = 80;
                ProductDG.Columns["CO_CODE"].HeaderText = "颜色";
                ProductDG.Columns["S_COLOR"].Width = 80;
                ProductDG.Columns["S_COLOR"].HeaderText = "色号";
                ProductDG.Columns["SizeName"].Width = 80;
                ProductDG.Columns["SizeName"].HeaderText = "尺码";
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int check=0;
            if (chkcolour.Checked == true && chkSize.Checked == false)
            {
                check = 1;
            }
            //chkSize
            if (chkSize.Checked == true && chkcolour.Checked == false)
            {
                check = 2;
            }
            if (chkSize.Checked == true && chkcolour.Checked == true)
            {
                check = 3;
            }
            product(TXTItem.Text.ToString(),check);
        }
    }
}
