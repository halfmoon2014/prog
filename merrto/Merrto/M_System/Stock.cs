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
    public partial class Stock : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            Brow();
        }
        private void Brow()
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select StockID,Cade,StockName from M_Stock", conn);

            try
            {
                conn.Open();
                sqlDaper.Fill(ds, "Stock");
                conn.Close();
                DataDGV.DataSource = ds.Tables["Stock"];
                DataDGV.Columns["Cade"].HeaderText = " 编码";
                DataDGV.Columns["StockName"].HeaderText = "仓库名称";
                DataDGV.Columns["StockID"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            StockNew SckN = new StockNew(0);
            SckN.ShowDialog();
            Brow();
        }
    }
}
