using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.BarCodes
{
    public partial class PassToStockEdit : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private string Rid, Dbo;
        public PassToStockEdit(string RID,string dbo_)
        {
            Rid = RID;
            Dbo = dbo_;
            InitializeComponent();
        }

        private void PassToStockEdit_Load(object sender, EventArgs e)
        {
            
            string strsql = "select b.ID,b.cade,Cadedate,m_Factory.title,Ordercade,BarCode,item_no,co_code,s_color," +
                               "m_SizeDetails.cade as sdCade,m_SizeDetails.[Name] as sdName,Qty,username,b.fid " +
                               "from "  +Dbo+  " as b left join m_Factory on m_Factory.id=b.FID " +
                               "left join m_product on m_product.id=b.pid " +
                               "left join m_ProductSub on m_ProductSub.id=b.colourid " +
                               "left join m_SizeDetails on m_SizeDetails.id=b.sdid  where b.ID='"+Rid+"'";
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("select ID,Title from m_Factory ", conn);
          
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds,"Data");
            sqlDaper1.Fill(ds, "Factory");
            conn.Close();
            if (ds.Tables["Factory"].Rows.Count > 0)
            {
                CboFID.DataSource = ds.Tables["Factory"];
                CboFID.ValueMember = "ID";
                CboFID.DisplayMember = "Title";
            }
            if (ds.Tables["Data"].Rows.Count > 0)
            {
                DtpCadeDate.Value = Convert.ToDateTime((ds.Tables["Data"].Rows[0]["CadeDate"].ToString() == "" ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : ds.Tables["Data"].Rows[0]["CadeDate"].ToString()));
                TxtBarCode.Text = ds.Tables["Data"].Rows[0]["BarCode"].ToString();
                TxtOrderCade.Text = ds.Tables["Data"].Rows[0]["OrderCade"].ToString();
                TxtCade.Text = ds.Tables["Data"].Rows[0]["cade"].ToString();
                TxtItem_no.Text = ds.Tables["Data"].Rows[0]["item_no"].ToString();
                TxtNo.Text = ds.Tables["Data"].Rows[0]["Qty"].ToString();
                Txtcolour.Text = ds.Tables["Data"].Rows[0]["s_color"].ToString();
                TxtSize.Text = ds.Tables["Data"].Rows[0]["sdName"].ToString();
                lblID.Text = ds.Tables["Data"].Rows[0]["ID"].ToString();
                CboFID.SelectedValue = ds.Tables["Data"].Rows[0]["Fid"].ToString();
            }
            TxtCade.Enabled = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = sqlcon.getcon("");
                string rolestr = "update " + Dbo + " set CadeDate='" + DtpCadeDate.Value +
                    "',BarCode='" + TxtBarCode.Text.ToString().Trim() +
                    "',Qty='" + TxtNo.Text.ToString().Trim() +
                     "',FID='" + CboFID.SelectedValue.ToString().Trim() +
                     "',PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id  from M_product " +
                            "left join M_productsub on M_productsub.pid=M_product.id " +
                            "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                            "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                            "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=" + Dbo + ".BarCode AND " + Dbo + ".ID='" + Rid + "'";
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(rolestr, conn);
                sqlcom.ExecuteNonQuery();
                conn.Close();
                sqlcom.Dispose();
                MessageBox.Show("数据修改成功！！");
            }
            catch
            {
                MessageBox.Show("数据修改失败！！");
            }
        }

        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Brow();
            }
        }
        private void Brow()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strwhere = "select item_no,M_name,khdw,co_code,s_color,m_SizeDetails.NAME as SDName,m_product.id as pid,m_ProductSub.id as colourID,m_SizeDetails.id as sdid from m_product " +
                  "left join m_productsize on m_product.id=m_productsize.pid " +
                  "left join m_ProductSub on m_product.id=m_ProductSub.pid " +
                  "left join m_SizeDetails on m_SizeDetails.sizeid=m_productsize.sizeid where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='" + this.TxtBarCode.Text.ToString() + "' ";

            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strwhere, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();
            sqlDaper.Fill(ds, "Rks");
            conn.Close();
            if (ds.Tables["Rks"].Rows.Count > 0)
            {
                TxtItem_no.Text = ds.Tables["Rks"].Rows[0]["item_no"].ToString();
                TxtSize.Text = ds.Tables["Rks"].Rows[0]["SDName"].ToString();
                Txtcolour.Text = ds.Tables["Rks"].Rows[0]["s_color"].ToString();
            }
            else
            {
                MessageBox.Show("产品档案查无此条码！！");
            }
        }
    }
}
