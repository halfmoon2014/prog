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
    public partial class Size : Form
    {
        public Size()
        {
            InitializeComponent();
        }
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProductSize_Load(object sender, EventArgs e)
        {
            mainsql();
        }
        private void mainsql()
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            SizeNew sn = new SizeNew(0);
            sn.ShowDialog();
            mainsql();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SizeNew sn = new SizeNew(Convert.ToInt32(SizeDGV[2, SizeDGV.CurrentCell.RowIndex].Value.ToString()));
            sn.ShowDialog();
            //SizeDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
            //SizeDGV.Rows[rowindex].Cells["id"].Value.ToString();
            //SizeDGV
            //dt.DefaultView[currow]["编号"].ToString());
        }

        private void SizeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SizeDetails(SizeDGV[2, SizeDGV.CurrentCell.RowIndex].Value.ToString());
        }
        private void SizeDetails(string RowsID)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT CADE,NAME,USA,UK,CM,ID,sort FROM m_SizeDetails where sizeid='" + RowsID + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    SizeDetailsDGV.DataSource = ds.Tables[0];
                }
                SizeDetailsDGV.Columns["CADE"].Width = 60;
                SizeDetailsDGV.Columns["CADE"].HeaderText = "代码";
                SizeDetailsDGV.Columns["NAME"].Width = 70;
                SizeDetailsDGV.Columns["NAME"].HeaderText = "名称";
                SizeDetailsDGV.Columns["USA"].Width = 40;
                SizeDetailsDGV.Columns["UK"].Width = 40;
                SizeDetailsDGV.Columns["CM"].Width = 40;
                SizeDetailsDGV.Columns["ID"].Width = 30;
                SizeDetailsDGV.Columns["sort"].HeaderText = "顺序";
                SizeDetailsDGV.Columns["sort"].Width = 40;
                SizeDetailsDGV.Columns["ID"].HeaderText = "ID";
                SizeDetailsDGV.Columns["ID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
