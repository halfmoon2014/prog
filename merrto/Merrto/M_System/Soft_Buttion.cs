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
    public partial class Soft_Buttion : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private int bttionid;
        public Soft_Buttion()
        {
            InitializeComponent();
        }

        private void Soft_Buttion_Load(object sender, EventArgs e)
        {

            SqlConnection conn = sqlcon.getcon("");
            string str = "select cade,name,buttionid,sort from WEB_SOFTButtion";
            SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();

                sqldaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    buttondg.DataSource = ds.Tables[0];
                }
                buttondg.Columns["cade"].HeaderText = "编号";
                buttondg.Columns["cade"].Width = 80;
                buttondg.Columns["name"].HeaderText = "名称";
                buttondg.Columns["Sort"].HeaderText = "序号";
                buttondg.Columns["Sort"].Width = 60;
                //设置列的宽度
                buttondg.Columns["name"].Width = 80;
                // buttondg.Columns["remark"].HeaderText = "备注";
                //设置列的宽度
                //buttondg.Columns["remark"].Width = 150;
                buttondg.Columns["buttionid"].Visible = false;

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void buttondg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            bttionid =Convert.ToInt32(buttondg[2, buttondg.CurrentCell.RowIndex].Value.ToString());
            string sqlstr = "select  * from WEB_SOFTButtion where buttionid='" + bttionid + "'";
            //save_ = 1;
            SqlDataAdapter sqldaper = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();

                sqldaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    this.txtcade.Text = ds.Tables[0].Rows[0]["cade"].ToString();
                    this.txtname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = sqlcon.getcon("");
                string str;
                if (bttionid == 0)
                {
                    str = "insert into WEB_SOFTButtion(cade,name,sort) values('" + this.txtcade.Text + "','" + this.txtname.Text + "','"+TxtSort.Text.ToString()+"')";
                }
                else
                {
                    str = "update WEB_SOFTButtion set cade='" + this.txtcade.Text + "',name='" + this.txtname.Text + "',sort='" + TxtSort.Text.ToString() + "' where buttionid='" + bttionid + "'";
                }
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                this.txtcade.Text = "";
                this.txtname.Text = "";
                this.TxtSort.Text = "0";
                bttionid = 0;
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
                Soft_Buttion_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Console.WriteLine(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }
    }
}
