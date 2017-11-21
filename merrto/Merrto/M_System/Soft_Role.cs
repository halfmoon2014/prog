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
    public partial class Soft_Role : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public Soft_Role()
        {
            InitializeComponent();
        }

        private void ROLEgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void Soft_Role_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string str = "select cade,name,RoleID,Remark from Web_SOFT_ROLE";
            SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqldaper.Fill(ds);
                conn.Close();
                if (ds.Tables.Count > 0)
                {
                    ROLEgv.DataSource = ds.Tables[0];
                }
                ROLEgv.Columns["cade"].HeaderText = "编码";
                ROLEgv.Columns["name"].HeaderText = "名称";
                ROLEgv.Columns["Remark"].HeaderText = "备注";
                ROLEgv.Columns["RoleID"].Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            Soft_RoleEdit roleadd = new Soft_RoleEdit(0);
            roleadd.Show();
            Soft_Role_Load(sender,e);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Soft_RoleEdit roleadd = new Soft_RoleEdit(Convert.ToInt32(ROLEgv[2, ROLEgv.CurrentCell.RowIndex].Value.ToString()));
            roleadd.Show();
            Soft_Role_Load(sender, e);
        }
    }
}
