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
    public partial class ProductSize : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private string sizeid;
        public ProductSize()
        {
            InitializeComponent();
        }

        private void ProductSize_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT CADE,NAME,ID FROM m_Size";
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
                SizeDGV.Columns["CADE"].Width = 100;
                SizeDGV.Columns["CADE"].HeaderText = "尺码代码";
                SizeDGV.Columns["NAME"].Width = 100;
                SizeDGV.Columns["NAME"].HeaderText = "尺码名称";
                SizeDGV.Columns["ID"].Width = 30;
                SizeDGV.Columns["ID"].HeaderText = "ID";
                SizeDGV.Columns["ID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SizeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sizeid = SizeDGV[2, SizeDGV.CurrentCell.RowIndex].Value.ToString();
            Product(sizeid);
        }
        private void Product(string RowsID)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql="";
            if (this.chkSize.Checked == true &&this.chkproduct.Checked==false)
            {
                strsql = "select CAST ('false' as bit) as ok,item_no,m_name,id from M_product where not exists(select * from m_productSize where M_product.id=m_productSize.pid)";
            }
            else if (this.chkSize.Checked == false && this.chkproduct.Checked == true)
            {
                strsql = "select CAST ('True' as bit) as ok,item_no,m_name,id from M_product where exists(select * from m_productSize where M_product.id=m_productSize.pid and m_productSize.Sizeid='" + RowsID + "')";
            }
            else
            {
                strsql = "select CAST ('True' as bit) as ok,item_no,m_name,id from M_product where exists(select * from m_productSize where M_product.id=m_productSize.pid and m_productSize.Sizeid='" + RowsID + "')" +
                                "union all select CAST ('false' as bit) as ok,item_no,m_name,id from M_product where not exists(select * from m_productSize where M_product.id=m_productSize.pid)";
            }
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    ProductDGV.DataSource = ds.Tables[0];
                }
                ProductDGV.Columns["ok"].Width = 40;
                ProductDGV.Columns["ok"].HeaderText = "选择";
                ProductDGV.Columns["ok"].ReadOnly = false;
                ProductDGV.Columns["item_no"].Width = 70;
                ProductDGV.Columns["item_no"].HeaderText = "款号";
                ProductDGV.Columns["m_name"].Width = 120;
                ProductDGV.Columns["m_name"].HeaderText = "品名";
                ProductDGV.Columns["ID"].Width = 30;
                ProductDGV.Columns["ID"].HeaderText = "ID";
                ProductDGV.Columns["ID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (Convert.ToString(ProductDGV.Rows[e.RowIndex].Cells[0].Value) == "True")
                    ProductDGV.Rows[e.RowIndex].Cells[0].Value = "false";
                else
                    ProductDGV.Rows[e.RowIndex].Cells[0].Value = "True";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strsql = "";
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                for (int i = 0; i < ProductDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    //for (int j = 0; j < cell; j++)//得到总列数并在之内循环
                    //{
                    string Product = ProductDGV.Rows[i].Cells[3].Value.ToString();
                    string ok_ = ProductDGV.Rows[i].Cells[0].Value.ToString();
                    //}
                    string str = "select * from m_ProductSize where sizeid='" + sizeid + "' and pid='" + Product + "'";
                    SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                    DataSet ds = new DataSet();

                    conn.Open();
                    sqldaper.Fill(ds);
                    if (ok_ == "True")
                    {
                        if (ds.Tables[0].Rows.Count <= 0)
                        {
                            strsql += "insert into m_ProductSize(sizeid,pid) values (" + sizeid + "," + Product + ") ";
                        }
                        conn.Close();
                    }
                    if (ok_ == "False")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strsql += "delete from m_ProductSize where sizeid='" + sizeid + "' and pid='" + Product + "' ";
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
                Console.WriteLine(ex.Message);
            }
        }
    }
}
