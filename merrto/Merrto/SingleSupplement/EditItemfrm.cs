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
    public partial class EditItemfrm : Form
    {
        private int RowsID;
        private int save_;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        
        public EditItemfrm(int rows)
        {
            SqlConnection conn = sqlcon.getcon("");
            RowsID = rows;
            InitializeComponent();
            if (RowsID != 0)
            {
                this.Text = "修改配码";
                //int row = ;//得到总行数
                //SqlConnection conn = sqlcon.getcon("");
                string rolestr = "select * from m_product where ID='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                this.TXTCade.Text = sizeds.Tables[0].Rows[0]["Item_no"].ToString();
                save_ = 1;
            }
            else
            {
                this.Text = "新增配码";
                save_ = 0;
            }
        }

        private void EditItemfrm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "select SS_ProductColourSize.pid,m_Productsub.co_code,s_color,colourid,m_SizeDetails.name as SDName,sdid,Proportion from SS_ProductColourSize " +
                "left join m_Productsub on m_Productsub.id=colourid  " +
                "left join m_SizeDetails on m_SizeDetails.id=SS_ProductColourSize.sdid   " +
                " where SS_ProductColourSize.pid='" + RowsID + "'" +
                "union all "+
                "select m_Productsub.pid,m_Productsub.co_code,s_color,m_Productsub.id as colourid,m_SizeDetails.name as SDName,m_SizeDetails.id as sdid,0 from m_Product " +
                "left join m_Productsub on m_Product.id=m_Productsub.pid "+
                "left join m_ProductSize on m_ProductSize.pid=m_Product.id "+
                "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid where m_ProductSize.pid='" + RowsID + "' and not exists(" +
                "select * from SS_ProductColourSize where SS_ProductColourSize.pid=m_Product.id)";
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string str = "";
                //int row = ;//得到总行数
                string rolestr = "select * from SS_ProductColourSize where pid='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet roleds = new DataSet();
                conn.Open();
                sqlroleda.Fill(roleds);
                if (roleds.Tables[0].Rows.Count <= 0)
                {
                    for (int i = 0; i < ColourSizeDGV.Rows.Count; i++)//得到总行数并在之内循环
                    {
                        str += "insert into SS_ProductColourSize(pid,colourid,sdid,Proportion) VALUES ('" + RowsID + "','" + ColourSizeDGV.Rows[i].Cells["colourid"].Value.ToString() +
                            "','" + ColourSizeDGV.Rows[i].Cells["sdid"].Value.ToString() +
                            "','" + ColourSizeDGV.Rows[i].Cells["Proportion"].Value.ToString() + "')";

                    }
                }
                else if (roleds.Tables[0].Rows.Count > 0)
                {
                    str += "delete from SS_ProductColourSize where Pid='" + RowsID + "';";

                    for (int i = 0; i < ColourSizeDGV.Rows.Count; i++)//得到总行数并在之内循环
                    {
                        str += "insert into SS_ProductColourSize(colourid,SDID,Proportion,pid) VALUES ('" + ColourSizeDGV.Rows[i].Cells["colourid"].Value.ToString() +
                            "','" + ColourSizeDGV.Rows[i].Cells["SDID"].Value.ToString() +
                            "','" + ColourSizeDGV.Rows[i].Cells["Proportion"].Value.ToString() + "','" + RowsID + "')";
                    }
                }
                //conn.Close();
                //conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                conn.Close();
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnclose_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
