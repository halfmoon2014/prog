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
    public partial class CustomerUnitSetBrow : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public CustomerUnitSetBrow()
        {
            InitializeComponent();
        }

        private void CustomerUnitSetBrow_Load(object sender, EventArgs e)
        {
            Brow();
        }
        private void Brow()
        {
            string strsql = "";
            strsql = "select * from STR_CustomerUnitSet ";
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            WPHbROWDGV.DataSource = ds.Tables[0];
            conn.Close();
            WPHbROWDGV.Columns["Cade"].HeaderText = "编号";
            WPHbROWDGV.Columns["Name"].HeaderText = "名称";
            WPHbROWDGV.Columns["Name"].Width = 600;
            //WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
            //WPHbROWDGV.Columns["FTname"].HeaderText = "项目名称";
            //WPHbROWDGV.Columns["SumMoney"].HeaderText = "项目金额";
            //WPHbROWDGV.Columns["Remarks"].HeaderText = "备注";
            //WPHbROWDGV.Columns["Username"].HeaderText = "操作人员";
            WPHbROWDGV.Columns["ID"].Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            TheShopReports.CustomerUnitSet cus = new TheShopReports.CustomerUnitSet(0);
            cus.ShowDialog();
            Brow();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            TheShopReports.CustomerUnitSet cus = new TheShopReports.CustomerUnitSet(Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()));
            //STR_itemDBO wphpe = new STR_itemDBO(Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()));
            cus.ShowDialog();
            Brow();
        }
    }
}
