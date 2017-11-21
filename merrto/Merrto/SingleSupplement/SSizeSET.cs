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
    public partial class SSizeSET : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public SSizeSET()
        {
            InitializeComponent();
        }

        private void SSET_Load(object sender, EventArgs e)
        {

            mainsql();
            //ProductDGV();

        }
        private void mainsql()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT CADE,NAME,ID FROM SS_Size";
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
                SizeDGV.Columns["CADE"].HeaderText = "配码代码";
                SizeDGV.Columns["NAME"].Width = 100;
                SizeDGV.Columns["NAME"].HeaderText = "配码名称";
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
        //private void ProductDGV()
        //{
        //    SqlConnection conn = sqlcon.getcon("");
        //    string strsql = "SELECT Item_no,M_NAME,ID FROM M_product";
        //    SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        conn.Open();
        //        sqlDaper.Fill(ds);
        //        if (ds.Tables.Count > 0)
        //        {
        //            M_ProductDGV.DataSource = ds.Tables[0];
        //        }
        //        M_ProductDGV.Columns["Item_no"].Width = 100;
        //        M_ProductDGV.Columns["Item_no"].HeaderText = "款号";
        //        M_ProductDGV.Columns["M_NAME"].Width = 100;
        //        M_ProductDGV.Columns["M_NAME"].HeaderText = "配码名称";
        //        M_ProductDGV.Columns["ID"].Width = 30;
        //        M_ProductDGV.Columns["ID"].HeaderText = "ID";
        //        M_ProductDGV.Columns["ID"].Visible = false;
        //        conn.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SSizeSETNew SSetNew = new SSizeSETNew(0);
            SSetNew.ShowDialog();
            mainsql();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SSizeSETNew sn = new SSizeSETNew(Convert.ToInt32(SizeDGV[2, SizeDGV.CurrentCell.RowIndex].Value.ToString()));
            sn.ShowDialog();
        }

        private void SizeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SizeDetails(SizeDGV[2, SizeDGV.CurrentCell.RowIndex].Value.ToString());
        }
        private void SizeDetails(string RowsID)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT Name,Proportion,SSID,SDID FROM SS_SizeDetails left join M_SizeDetails on M_SizeDetails.id =SS_SizeDetails.SDID where SSID='" + RowsID + "'";
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
                SizeDetailsDGV.Columns["Proportion"].Width = 80;
                SizeDetailsDGV.Columns["Proportion"].HeaderText = "转换率";
                SizeDetailsDGV.Columns["NAME"].Width = 70;
                SizeDetailsDGV.Columns["NAME"].HeaderText = "名称";
                SizeDetailsDGV.Columns["SSID"].HeaderText = "ID";
                SizeDetailsDGV.Columns["SSID"].Visible = false;
                SizeDetailsDGV.Columns["SDID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
