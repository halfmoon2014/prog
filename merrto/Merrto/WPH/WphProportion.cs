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
    public partial class WphProportion : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphProportion()
        {
            InitializeComponent();
        }

        private void WphProportion_Load(object sender, EventArgs e)
        {
            mainsql();
        }
        private void mainsql()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "select  wph_proportion.id,wph_proportion.pid,StorageID,m_product.item_no,m_product.M_name as pname,Wph_Storage.name as Sname,Proportion from wph_proportion" +
                             " left join m_product on m_product.id=wph_proportion.pid" +
                             " left join Wph_Storage on Wph_Storage.id=StorageID";
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
                StorageDGV.Columns["item_no"].Width = 80;
                StorageDGV.Columns["item_no"].HeaderText = "款号";
                StorageDGV.Columns["pname"].Width = 80;
                StorageDGV.Columns["Pname"].HeaderText = "品名";
                StorageDGV.Columns["Sname"].Width = 80;
                StorageDGV.Columns["Sname"].HeaderText = "仓库";
                StorageDGV.Columns["Proportion"].Width = 80;
                StorageDGV.Columns["Proportion"].HeaderText = "比率";
                StorageDGV.Columns["PID"].Width = 30;
                StorageDGV.Columns["PID"].HeaderText = "ID";
                StorageDGV.Columns["PID"].Visible = false;
                StorageDGV.Columns["StorageID"].Width = 30;
                StorageDGV.Columns["StorageID"].HeaderText = "ID";
                StorageDGV.Columns["StorageID"].Visible = false;
                StorageDGV.Columns["ID"].HeaderText = "ID";
                StorageDGV.Columns["ID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnExct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            WphProportionEdit wphCa = new WphProportionEdit(0);
            wphCa.ShowDialog();
            mainsql();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            WphProportionEdit wphCa = new WphProportionEdit(Convert.ToInt32(StorageDGV[0, StorageDGV.CurrentCell.RowIndex].Value.ToString()));
            wphCa.ShowDialog();
            mainsql();
        }
    }
}
