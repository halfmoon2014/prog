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
    public partial class ProductSTorage : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public ProductSTorage()
        {
            InitializeComponent();
        }

        private void ProductSTorage_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "select ITEM_NO,M_NAME,cast(ITEM_NO as varchar(20))+'|'+M_NAME as ItemName,ID from m_Product order by item_no";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataTable pdt = new DataTable();
            DataTable sdt = new DataTable();
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("select StockID,StockName from M_Stock ", conn);
            try
            {
                conn.Open();
                sqlDaper.Fill(pdt);
                sqlDaper1.Fill(sdt);
                conn.Close();


                if (sdt.Rows.Count > 0)
                {
                    cboStock.DataSource = sdt;
                    //this.cboStock.DataSource = ds.Tables["Stock"];
                    cboStock.ValueMember = "StockID";
                    cboStock.DisplayMember = "StockName";
                }
                if (pdt.Rows.Count > 0)
                {
                    cmbitem.DataSource = pdt;
                    cmbitem.ValueMember = "ID";
                    cmbitem.DisplayMember = "ItemName";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void cmbitem_SelectedValueChanged(object sender, EventArgs e)
        {
            //CboData();
        }
        private void CboData()
        {
            if (cboStock.SelectedValue.ToString() == "")
            {
                return;
            }
            if (cmbitem.SelectedValue.ToString() == "")
            {
                return;
            }
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "select co_code,s_color,m_sizeDetails.cade as sdcade,m_sizeDetails.[name] as sdname,Storage,Sdid,m_ProductStorage.pid,colorid,m_ProductStorage.id " +
                            "from m_ProductStorage left join m_sizeDetails on m_sizeDetails.id=m_ProductStorage.sdid " +
                            "left join m_ProductSub on m_ProductStorage.colorid=m_ProductSub.id  where StockID='" + cboStock.SelectedValue.ToString() + "' and  m_ProductSub.pid='" + cmbitem.SelectedValue.ToString() +
                            "' union all select co_code,s_color,m_sizeDetails.cade as sdcade," +
                            "m_sizeDetails.[name] as sdname,'',m_sizeDetails.id as sdid,m_ProductSub.pid as pid,m_ProductSub.id as colorid,'' " +
                            "from m_ProductSub left join m_productSize on m_productSize.pid=m_ProductSub.pid " +
                            "left join m_sizeDetails on m_sizeDetails.sizeid=m_productSize.sizeid where m_ProductSub.pid='" + cmbitem.SelectedValue.ToString() +
                            "' AND NOT EXISTS(SELECT * FROM m_ProductStorage WHERE  StockID='" + cboStock.SelectedValue.ToString() + "' and m_ProductStorage.SDID=m_sizeDetails.ID AND m_ProductSub.ID=m_ProductStorage.COLORID)";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    ProductStorageDGV.DataSource = ds.Tables[0];
                }
                ProductStorageDGV.Columns["co_code"].Width = 60;
                ProductStorageDGV.Columns["co_code"].HeaderText = "色号";
                ProductStorageDGV.Columns["co_code"].ReadOnly = true;
                ProductStorageDGV.Columns["s_color"].Width = 60;
                ProductStorageDGV.Columns["s_color"].HeaderText = "颜色";
                ProductStorageDGV.Columns["s_color"].ReadOnly = true;
                ProductStorageDGV.Columns["sdcade"].Width = 60;
                ProductStorageDGV.Columns["sdcade"].HeaderText = "代码";
                ProductStorageDGV.Columns["sdcade"].ReadOnly = true;
                ProductStorageDGV.Columns["sdname"].Width = 60;
                ProductStorageDGV.Columns["sdname"].HeaderText = "尺码";
                ProductStorageDGV.Columns["sdname"].ReadOnly = true;
                ProductStorageDGV.Columns["Storage"].Width = 60;
                ProductStorageDGV.Columns["Storage"].HeaderText = "库位";
                ProductStorageDGV.Columns["Storage"].ReadOnly = false;
                ProductStorageDGV.Columns["Sdid"].Visible = false;
                ProductStorageDGV.Columns["pid"].Visible = false;
                ProductStorageDGV.Columns["colorid"].Visible = false;
                ProductStorageDGV.Columns["ID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNSave_Click(object sender, EventArgs e)
        {
            string strsql = "";
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                for (int i = 0; i < ProductStorageDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    //for (int j = 0; j < cell; j++)//得到总列数并在之内循环
                    //{
                    string Product = ProductStorageDGV.Rows[i].Cells[3].Value.ToString();
                    string ok_ = ProductStorageDGV.Rows[i].Cells[0].Value.ToString();
                    //}
                    string str = "select * from m_ProductStorage where Sdid='" + ProductStorageDGV.Rows[i].Cells[5].Value.ToString() + 
                                "' and colorid='" + ProductStorageDGV.Rows[i].Cells[7].Value.ToString() +
                                "' and stockID='" + cboStock.SelectedValue.ToString() + 
                                "' and pid='" + cmbitem.SelectedValue.ToString() + "'";
                    SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                    DataSet ds = new DataSet();

                    conn.Open();
                    sqldaper.Fill(ds);
                    if (ProductStorageDGV.Rows[i].Cells[4].Value.ToString() != "")
                    {
                        if (ds.Tables[0].Rows.Count <= 0)
                        {
                            strsql += "insert into m_ProductStorage(Storage,Sdid,colorid,stockID,pid) values ('"
                                        + ProductStorageDGV.Rows[i].Cells[4].Value.ToString() + "','"
                                        + ProductStorageDGV.Rows[i].Cells[5].Value.ToString() + "','"
                                        + ProductStorageDGV.Rows[i].Cells[7].Value.ToString() + "','"
                                        + cboStock.SelectedValue.ToString() + "','"
                                        + cmbitem.SelectedValue.ToString() + "'); ";
                        }
                        else {
                            strsql += "update m_ProductStorage set Storage='"+ ProductStorageDGV.Rows[i].Cells[4].Value.ToString() +
                                "',Sdid='"+ ProductStorageDGV.Rows[i].Cells[5].Value.ToString() + 
                                "',colorid='"+ ProductStorageDGV.Rows[i].Cells[7].Value.ToString() + 
                                "',stockID='"+ cboStock.SelectedValue.ToString() +
                                "',pid='" + cmbitem.SelectedValue.ToString() + "' where ID='" + ProductStorageDGV.Rows[i].Cells[8].Value.ToString() + "'";
                        }
                        conn.Close();
                    }
                    if (ProductStorageDGV.Rows[i].Cells[4].Value.ToString() == "")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strsql += "delete from m_ProductStorage where Sdid='" + ProductStorageDGV.Rows[i].Cells[5].Value.ToString() + 
                                        "' and colorid='"+ ProductStorageDGV.Rows[i].Cells[7].Value.ToString() +
                                        "' and stockID='" + cboStock.SelectedValue.ToString() + 
                                        "' and pid='" + cmbitem.SelectedValue.ToString() + "';";
                        }
                        conn.Close();
                    }
                }
                if (strsql == "")
                {
                    MessageBox.Show("数据没有更改无须保存！！", "系统提示：", MessageBoxButtons.OK);
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(strsql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    ProductStorageDGV.DataSource = "";
                    MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新失败！", "系统提示：", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
            }
        }

        private void cboStock_SelectedValueChanged(object sender, EventArgs e)
        {
           // CboData();
        }

        private void btnread_Click(object sender, EventArgs e)
        {
            CboData();
        }
    }
}
