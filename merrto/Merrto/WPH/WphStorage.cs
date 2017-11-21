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
    public partial class WphStorage : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphStorage()
        {
            InitializeComponent();
        }

        private void btnExct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WphStorage_Load(object sender, EventArgs e)
        {
            mainsql();
        }
        private void mainsql()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT CADE,NAME,ID FROM Wph_Storage";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    StorageDGV.DataSource = ds.Tables[0];
                }
                StorageDGV.Columns["CADE"].Width = 80;
                StorageDGV.Columns["CADE"].HeaderText = "编码";
                StorageDGV.Columns["NAME"].Width = 80;
                StorageDGV.Columns["NAME"].HeaderText = "名称";
                StorageDGV.Columns["ID"].Width = 30;
                StorageDGV.Columns["ID"].HeaderText = "ID";
                StorageDGV.Columns["ID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            WphStroageAdd wphCa = new WphStroageAdd(0);
            wphCa.ShowDialog();
            mainsql();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            WphStroageAdd wphCa = new WphStroageAdd(Convert.ToInt32(StorageDGV[2, StorageDGV.CurrentCell.RowIndex].Value.ToString()));
            wphCa.ShowDialog();
            mainsql();
        }
    }
}
