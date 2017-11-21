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
    public partial class SSItemSize : Form
    {
        private int RowsID;
        private int save_;
        baseclass.sqldatacon sqlcon=new baseclass.sqldatacon();
        public SSItemSize(int rows)
        {
            RowsID = rows;
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string str = "";
                //int row = ;//得到总行数
                string rolestr = "select * from ProductSS_Size where pid='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet roleds = new DataSet();
                conn.Open();
                sqlroleda.Fill(roleds);
                if (roleds.Tables[0].Rows.Count <= 0)
                {
                    str = "insert into ProductSS_Size (Pid,SSid) values('"+RowsID+"','"+cmbSize.SelectedValue.ToString()+"')";
                }
                else if (roleds.Tables[0].Rows.Count > 0)
                {
                    str += "delete from ProductSS_Size where Pid='" + RowsID + "';";

                    str += "insert into ProductSS_Size (Pid,SSid) values('" + RowsID + "','" + cmbSize.SelectedValue.ToString() + "')";
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

        private void SSItemSize_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from SS_Size where exists(select * from M_productSize  where SS_Size.sizeid=M_productSize.sizeid and pid='"+RowsID+"')", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            { 
                cmbSize.DataSource=ds.Tables[0];
                cmbSize.ValueMember = "ID";
                cmbSize.DisplayMember = "Name";
            }
            conn.Close();
            if (RowsID != 0)
            {
                this.Text = "关联配码";
                //int row = ;//得到总行数
                //SqlConnection conn = sqlcon.getcon("");
                string rolestr = "select Item_no,m_product.id as pid,SSid from m_product left join  ProductSS_Size on ProductSS_Size.pid=m_product.id where m_product.ID='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                this.TXTCade.Text = sizeds.Tables[0].Rows[0]["Item_no"].ToString();
                if (sizeds.Tables[0].Rows[0]["SSid"].ToString() != "")
                {
                    cmbSize.SelectedValue = sizeds.Tables[0].Rows[0]["SSid"].ToString();
                }
                save_ = 1;
            }
            else
            {
                this.Text = "新增配码";
                save_ = 0;
            }

        }
    }
}
