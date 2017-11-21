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
    public partial class DeletePassToStock : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public DeletePassToStock()
        {
            InitializeComponent();
        }

        private void DeletePassToStock_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataTable dtfield = new DataTable();
            SqlDataAdapter sqlds = new SqlDataAdapter("select Cade,cade+'   ||   '+cast(sum(nom) as varchar(20)) as name from M_PassToStock where username='" + frmlogin.userID + "' group by Cade", conn);
            conn.Open();
            sqlds.Fill(dtfield);
            conn.Close();
            CboBatch.DataSource = dtfield;
            CboBatch.ValueMember = "Cade";
            CboBatch.DisplayMember = "Name";
            SqlConnection conn1 = sqlcon.getcon("");
            DataTable dtfield1 = new DataTable();
            SqlDataAdapter sqlds1 = new SqlDataAdapter("select Cade,cade+'   ||   '+special as name from Wph_Packing group by Cade,special", conn);
            conn.Open();
            sqlds1.Fill(dtfield1);
            conn.Close();
            CboCade.DataSource= dtfield1;
            CboCade.ValueMember = "Cade";
            CboCade.DisplayMember = "Name";
            
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("\n你确定要重置" + CboBatch.SelectedValue.ToString() + " 批次的数据吗？   \n\n\n    确认是否退出(Y/N)", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                DataSet ds = new DataSet();
                SqlConnection conn = sqlcon.getcon("");
                try
                {
                    string sqlstr = "";

                    sqlstr += " delete from M_PassToStock where Cade='" + CboBatch.SelectedValue.ToString() + "';";


                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlstr, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("数据重置成功！", "系统提示：", MessageBoxButtons.OK);
                    DeletePassToStock_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据重置失败！", "系统提示：", MessageBoxButtons.OK);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void BtnCade_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("\n你确定要重置" + CboCade.SelectedValue.ToString() + " 批次的数据吗？   \n\n\n    确认是否退出(Y/N)", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                DataSet ds = new DataSet();
                SqlConnection conn = sqlcon.getcon("");
                try
                {
                    string sqlstr = "";

                    sqlstr += " delete from Wph_Packing where Cade='" + CboCade.SelectedValue.ToString() + "';";


                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlstr, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("数据重置成功！", "系统提示：", MessageBoxButtons.OK);
                    DeletePassToStock_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据重置失败！", "系统提示：", MessageBoxButtons.OK);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
