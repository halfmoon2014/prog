using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.M_System
{
    public partial class Soft_RoleEdit : Form
    {
         baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private int RID=0;
        public Soft_RoleEdit(int Rid)
        {
            RID = Rid;
            InitializeComponent();
        }

        private void Soft_RoleEdit_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (RID != 0)
            {
                string str = "select cade,name,RoleID,Remark from Web_SOFTROLE where RoleID='"+RID+"'";
                SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                DataSet ds = new DataSet();
                conn.Open();
                sqldaper.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtcade.Text = ds.Tables[0].Rows[0]["Cade"].ToString();
                    txtname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    TXTRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                if (RID == 0)
                {
                    str = "insert into Web_SOFTROLE (cade,name,Remark) values ('" + this.txtcade.Text + "','" + this.txtname.Text + "','" + this.TXTRemark.Text + "')";
                }
                else
                {
                    str = "update Web_SOFTROLE set cade='" + this.txtcade.Text + "',name='" + this.txtname.Text + "',Remark='" + this.TXTRemark.Text + "' where  roleid='" + RID + "'";
                    btnquit_Click(sender,e);
                }
                SqlConnection conn = sqlcon.getcon("");
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                conn.Close();
                sqlcom.Dispose();
                this.txtcade.Text = "";
                this.txtname.Text = "";
                this.TXTRemark.Text = "";
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
