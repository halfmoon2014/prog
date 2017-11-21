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
    public partial class CustomerUnitSet : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.DATECalse datec = new baseclass.DATECalse();
        private int Rows;
        private int save_;
        public CustomerUnitSet(int rows)
        {
            InitializeComponent();
            Rows = rows;
        }

        private void CustomerUnitSet_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (Rows != 0)
            {
                this.Text = "修改项目";
                //int row = ;//得到总行数
                
                string rolestr = " select ID,Name,Cade from STR_CustomerUnitset where ID='" + Rows + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet ds = new DataSet();
                conn.Open();
                sqlroleda.Fill(ds, "ItemDS");
                conn.Close();
                this.TXTCade.Text = ds.Tables["ItemDS"].Rows[0]["Cade"].ToString();
                this.TXTName.Text = ds.Tables["ItemDS"].Rows[0]["Name"].ToString();
                save_ = 1;
            }
            else
            {
                this.Text = "新增项目";
                save_ = 0;
            }
            
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string str;
                if (save_ == 1)
                {
                    str = "update STR_CustomerUnitset set Cade='" + TXTCade.Text.ToString() +
                        "', Name='" + this.TXTName.Text +
                        "' where  ID='" + Rows + "' ";
                }
                else
                {
                    str = " insert into STR_CustomerUnitSet (Cade,Name) values ('"
                        + TXTCade.Text.ToString() + "','"
                        + this.TXTName.Text + "')  ";
                }
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                //this.TxtName.Text = "";
                this.TXTName.Text = "";
                this.TXTCade.Text = "";
                conn.Close();
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (save_ == 1)
                {
                    BtnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

    }
}
