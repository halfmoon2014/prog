using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.M_Data
{
    public partial class FiledType : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public FiledType()
        {
            InitializeComponent();
        }

        private void FiledType_Load(object sender, EventArgs e)
        {
            mainsql();
        }
        private void mainsql()
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "select Cade,[Name],FormName,ID from M_FiledType";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    DATADGV.DataSource = ds.Tables[0];
                }
                DATADGV.Columns["CADE"].Width = 80;
                DATADGV.Columns["CADE"].HeaderText = "编码";
                DATADGV.Columns["Name"].Width = 80;
                DATADGV.Columns["Name"].HeaderText = "名称";
                DATADGV.Columns["FormName"].Width = 80;
                DATADGV.Columns["FormName"].HeaderText = "表单名称";
                DATADGV.Columns["ID"].Width = 30;
                DATADGV.Columns["ID"].HeaderText = "ID";
                DATADGV.Columns["ID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            M_Data.FiledTypeNew wphCa = new M_Data.FiledTypeNew(0);
            wphCa.ShowDialog();
            mainsql();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (DATADGV[3, DATADGV.CurrentCell.RowIndex].Value.ToString() != "")
            {
                M_Data.FiledTypeNew wphCa = new M_Data.FiledTypeNew(Convert.ToInt32(DATADGV[3, DATADGV.CurrentCell.RowIndex].Value.ToString()));
                wphCa.ShowDialog();
                mainsql();
            }
        }
    }
}
