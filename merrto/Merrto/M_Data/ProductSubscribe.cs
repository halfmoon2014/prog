using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.M_Data
{
    public partial class ProductSubscribe : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public ProductSubscribe()
        {
            InitializeComponent();
        }

        private void ProductSubscribe_Load(object sender, EventArgs e)
        {

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
                strsql = " and " + strsql;
            }
            //strsql = "select m_Product.id as pid,cid,item_no,Wph_Item,PRICE_TAG,year,WPh_Category.name as Cname,pname,sdprice,class from m_Product" +
            //    " left join Wph_Product on Wph_Product.pid=m_Product.id " +
            //    " left join WPh_Category on Wph_Product.cid=WPh_Category.id" + strsql;

            strsql = "select CAST ('True' as bit) as ok,item_no,m_name,id from M_product where exists(select * from M_DProductSubscribe where M_product.id=M_DProductSubscribe.pid and M_DProductSubscribe.UserName='"+frmlogin.userID+"')" + strsql +
                                "union all select CAST ('false' as bit) as ok,item_no,m_name,id from M_product where not exists(select * from M_DProductSubscribe where M_product.id=M_DProductSubscribe.pid and M_DProductSubscribe.UserName='" + frmlogin.userID + "')" + strsql;
            
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            ProductDGV.DataSource = ds.Tables[0];
            ProductDGV.Columns["OK"].HeaderText = "选择";
            ProductDGV.Columns["OK"].Width = 60;
            ProductDGV.Columns["item_no"].HeaderText = "款号";
            ProductDGV.Columns["item_no"].Width = 80;
            ProductDGV.Columns["M_Name"].HeaderText = "品名";
            ProductDGV.Columns["M_Name"].Width = 80;
            ProductDGV.Columns["id"].Visible = false;
            conn.Close();
        }

        private void BTNADD_Click(object sender, EventArgs e)
        {
            string strsql = "";
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                for (int i = 0; i < ProductDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    string ok_ = ProductDGV.Rows[i].Cells[0].Value.ToString();
                    string str = "select * from M_DProductSubscribe where username='" + frmlogin.userID + "' and pid='" + ProductDGV.Rows[i].Cells[3].Value.ToString() + "'";
                    SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                    DataSet ds = new DataSet();

                    conn.Open();
                    sqldaper.Fill(ds);
                    if (ok_ == "True")
                    {
                        if (ds.Tables[0].Rows.Count <= 0)
                        {
                            strsql += "insert into M_DProductSubscribe(username,pid) values ('" + frmlogin.userID + "','" + ProductDGV.Rows[i].Cells[3].Value.ToString() + "') ";
                        }
                        conn.Close();
                    }
                    if (ok_ == "False")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strsql += "delete from M_DProductSubscribe where username='" + frmlogin.userID + "' and pid='" + ProductDGV.Rows[i].Cells[3].Value.ToString() + "' ";
                        }
                        conn.Close();
                    }
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新失败！", "系统提示：", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
            }
        }

        private void ProductDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (Convert.ToString(ProductDGV.Rows[e.RowIndex].Cells[0].Value) == "True")
                    ProductDGV.Rows[e.RowIndex].Cells[0].Value = "false";
                else
                    ProductDGV.Rows[e.RowIndex].Cells[0].Value = "True";
            }
        }
    }
}
