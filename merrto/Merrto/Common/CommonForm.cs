using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.Common
{
    public partial class CommonForm : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private string Where, Dbo;
        public CommonForm(string where,string dbo)
        {
            Where = where;
            Dbo = dbo;
            InitializeComponent();
        }

        private void CommonForm_Load(object sender, EventArgs e)
        {
            string strsql = "select UserName,OperateDateTime,Operate from " + Dbo + " where " + Where;
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper3.Fill(ds, "Operate");
            conn.Close();
            DateDgv.DataSource = ds.Tables["Operate"];
            DateDgv.Columns["UserName"].HeaderText = "操作员";
            DateDgv.Columns["OperateDateTime"].HeaderText = "操作时间";
            DateDgv.Columns["Operate"].HeaderText = "操作状态";
        }
    }
}
