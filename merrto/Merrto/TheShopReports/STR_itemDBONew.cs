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
    public partial class STR_itemDBONew : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public STR_itemDBONew()
        {
            InitializeComponent();
        }

        private void STR_itemDBONew_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT ID,Cade,ShopNAME FROM STR_Shop ", conn);
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT ID,Cade,NAME FROM M_FiledType ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "Shop");
            sqlDaper.Fill(ds, "FiledType");
            conn.Close();
            if (ds.Tables["Shop"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["Shop"].NewRow();
                ds.Tables["Shop"].Rows.Add(row);
                CmdShop.DataSource = ds.Tables["Shop"];
                CmdShop.ValueMember = "ID";
                CmdShop.DisplayMember = "ShopNAME";
            }
            if (ds.Tables["FiledType"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["FiledType"].NewRow();
                ds.Tables["FiledType"].Rows.Add(row);
                cboitem.DataSource = ds.Tables["FiledType"];
                cboitem.ValueMember = "ID";
                cboitem.DisplayMember = "NAME";
            }
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            Brow();
        }
        private void Brow()
        {
            string strsql = "";

            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Wph_Packing.Cade like '%" + TxtCade.Text.ToString() + "%'";
            }

            if (this.CmdShop.SelectedValue.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ShopID='" + CmdShop.SelectedValue.ToString() + "'";
            }
            if (this.cboitem.SelectedValue.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " itemid='" + cboitem.SelectedValue.ToString() + "'";
            }
            if (this.DTPStart.Value.ToString() != "" && DTPStop.Value.ToString("yyyy-MM-dd") != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql += "CadeDATE Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (strsql != "")
            {
                strsql = " where " + strsql;
            }
            strsql = "select STR_itemDBO.id,STR_itemDBO.Cade,CadeDate,shopname,M_FiledType.name as FTname,SumMoney,Remarks,Username from STR_itemDBO " +
                    "left join STR_Shop on STR_Shop.id=shopID " +
                    "left join M_FiledType on M_FiledType.id=itemid " + strsql + 
                    "union all select '','合计','','','',sum(SumMoney),'','' from STR_itemDBO" + strsql+" order by STR_itemDBO.Cade ";
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            WPHbROWDGV.DataSource = ds.Tables[0];
            conn.Close();
            WPHbROWDGV.Columns["Cade"].HeaderText = "单据号";
            WPHbROWDGV.Columns["CadeDATE"].HeaderText = "日期";
            //WPHbROWDGV.Columns["CadeDATE"].Width = 80;
            WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
            WPHbROWDGV.Columns["FTname"].HeaderText = "项目名称";
            WPHbROWDGV.Columns["SumMoney"].HeaderText = "项目金额";
            WPHbROWDGV.Columns["Remarks"].HeaderText = "备注";
            WPHbROWDGV.Columns["Username"].HeaderText = "操作人员";
            WPHbROWDGV.Columns["ID"].Visible = false;
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            STR_itemDBO wphpe = new STR_itemDBO(Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()));
            wphpe.ShowDialog();
            Brow();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            STR_itemDBO wphpe = new STR_itemDBO(0);
            wphpe.ShowDialog();
            Brow();
        }
    }
}
