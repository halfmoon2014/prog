using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.TheShopReports
{
    public partial class productCostNew : Form
    {
        private int Rows;
        private int save_ = 0;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public productCostNew(int rows)
        {
            InitializeComponent();
            Rows = rows;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");

            try
            {
                string str="";
                SqlDataAdapter sqlroleda = new SqlDataAdapter("select * from M_productCost where pid='" + lblpid.Text.ToString() + "'", conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                if (sizeds.Tables[0].Rows.Count > 0)
                {
                    str = "update M_productCost set cost='" + this.TXTCost.Text.ToString() + "' where pid='" + lblpid.Text.ToString() + "'";
                }
                else
                {
                    str=" insert into M_productCost (cost,pid) values ('" + this.TXTCost.Text.ToString() + "','"+lblpid.Text.ToString()+"') ";
                }

                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                conn.Close();
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (save_ == 1)
                {
                    btnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void productCostNew_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (Rows != 0)
            {
                this.Text = "成本价定义";
                string rolestr = "select  M_productCost.id,M_productCost.cost,item_no,M_product.id as pid from M_product" +
                             " left join M_productCost on M_product.id=M_productCost.pid where M_product.id='" + Rows + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                TxtProduect.Text = sizeds.Tables[0].Rows[0]["item_no"].ToString();
                TXTCost.Text = sizeds.Tables[0].Rows[0]["cost"].ToString();
                lblpid.Text = sizeds.Tables[0].Rows[0]["PID"].ToString();
                save_ = 1;
            }
            else
            {
                this.Text = "比率新增";
                save_ = 0;
            }
        }

    }
}
