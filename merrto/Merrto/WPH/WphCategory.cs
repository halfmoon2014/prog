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
    public partial class WphCategory : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphCategory()
        {
            InitializeComponent();
        }

        private void btnExct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            WphCategoryAdd wphCa = new WphCategoryAdd(0);
            wphCa.ShowDialog();
            mainsql();
        }

        private void WphCategory_Load(object sender, EventArgs e)
        {
            mainsql();
        }
        private void mainsql()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT NAME,ID FROM WPh_Category";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    CategoryDGV.DataSource = ds.Tables[0];
                }
                CategoryDGV.Columns["NAME"].Width = 100;
                CategoryDGV.Columns["NAME"].HeaderText = "名称";
                CategoryDGV.Columns["ID"].Width = 30;
                CategoryDGV.Columns["ID"].HeaderText = "ID";
                CategoryDGV.Columns["ID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            WphCategoryAdd wphCa = new WphCategoryAdd(Convert.ToInt32(CategoryDGV[1, CategoryDGV.CurrentCell.RowIndex].Value.ToString()));
            wphCa.ShowDialog();
            mainsql();
        }
    }
}
