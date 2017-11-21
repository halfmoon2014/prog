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
    public partial class ShopFrm : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public ShopFrm()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShopFrm_Load(object sender, EventArgs e)
        {
            mainsql();
        }
        private void mainsql()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT CADE,ShopName,ID FROM STR_Shop";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    ShopDGV.DataSource = ds.Tables[0];
                }
                ShopDGV.Columns["CADE"].Width = 80;
                ShopDGV.Columns["CADE"].HeaderText = "编码";
                ShopDGV.Columns["ShopName"].Width = 80;
                ShopDGV.Columns["ShopName"].HeaderText = "名称";
                ShopDGV.Columns["ID"].Width = 30;
                ShopDGV.Columns["ID"].HeaderText = "ID";
                ShopDGV.Columns["ID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BTNNew_Click(object sender, EventArgs e)
        {
            TheShopReports.ShopFrmNew wphCa = new TheShopReports.ShopFrmNew(0);
            wphCa.ShowDialog();
            mainsql();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TheShopReports.ShopFrmNew wphCa = new TheShopReports.ShopFrmNew(Convert.ToInt32(ShopDGV[2, ShopDGV.CurrentCell.RowIndex].Value.ToString()));
            wphCa.ShowDialog();
            mainsql();
        }
    }
}
