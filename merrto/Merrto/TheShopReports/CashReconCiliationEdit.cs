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
    public partial class CashReconCiliationEdit : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public CashReconCiliationEdit()
        {
            InitializeComponent();
        }

        private void CashReconCiliationEdit_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT ID,Cade,ShopNAME FROM STR_Shop ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "Shop");
            conn.Close();
            if (ds.Tables["Shop"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["Shop"].NewRow();
                ds.Tables["Shop"].Rows.Add(row);
                CmdShop.DataSource = ds.Tables["Shop"];
                CmdShop.ValueMember = "ID";
                CmdShop.DisplayMember = "ShopNAME";
            }
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            string strsql = "";
            string strwhere = "";
            //所有数据
            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " OrderCade like '%" + TxtCade.Text.ToString() + "%'";
            }
            if (this.DTPOrderDate.Value.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql += " orderdate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + "  00:00:00.000' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000'";

            }
            if (this.CmdShop.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ShopName='" + CmdShop.Text.ToString() + "'";
            }

            if (strsql != "")
            {
                strsql = " where " + strsql;

            }
            strwhere = "select * from STR_CashReconciliation " + strsql;
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strwhere, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();

            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row2 = ds.Tables[0].NewRow();
                decimal erpsummoney = 0;
                decimal bsumMoney = 0;
                decimal moneys = 0;
                decimal returnMoney = 0;
                decimal Rteurns = 0;


                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    erpsummoney = erpsummoney + decimal.Parse(ds.Tables[0].Rows[k][4].ToString());
                    bsumMoney = bsumMoney + decimal.Parse(ds.Tables[0].Rows[k][3].ToString());
                    moneys = moneys + decimal.Parse(ds.Tables[0].Rows[k][5].ToString());
                    returnMoney = returnMoney + decimal.Parse(ds.Tables[0].Rows[k][6].ToString());
                    Rteurns = Rteurns + decimal.Parse(ds.Tables[0].Rows[k][7].ToString());

                }
                row2[1] = "合计";
                //row2[1] = "";
                row2[3] = bsumMoney.ToString();
                row2[4] = erpsummoney.ToString();
                row2[5] = moneys.ToString();
                row2[6] = returnMoney.ToString();
                row2[7] = Rteurns.ToString();
                ds.Tables[0].Rows.Add(row2);
            }
            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["shopname"].HeaderText = "店铺";
            WPHbROWDGV.Columns["ordercade"].HeaderText = "单据";
            WPHbROWDGV.Columns["erpsummoney"].HeaderText = "ERP总金额";
            WPHbROWDGV.Columns["moneys"].HeaderText = "积分";
            WPHbROWDGV.Columns["bsumMoney"].HeaderText = "支付宝金额";
            WPHbROWDGV.Columns["returnMoney"].HeaderText = "退款金额";
            WPHbROWDGV.Columns["Rteurns"].HeaderText = " 异常差额";
            WPHbROWDGV.Columns["Reason"].HeaderText = "异常原因";
            WPHbROWDGV.Columns["ID"].Visible = false;
            WPHbROWDGV.Columns["OrderDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["username"].HeaderText = "制单人";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            string sqlselect = "";
            for (int i = 0; i < WPHbROWDGV.Rows.Count; i++)//得到总行数并在之内循环
            {
                if (sqlselect != "")
                {
                    sqlselect += " or ";
                }
                sqlselect += "(OrderCade ='" + WPHbROWDGV.Rows[i].Cells["ordercade"].Value.ToString() + "' and orderDate='" + WPHbROWDGV.Rows[i].Cells["orderDate"].Value.ToString() + "')";
            }
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_CashReconciliation where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                //{
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_CashReconciliation where " + sqlselect, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                //}
                //else
                //{
                //    return;
                //}
            }

            string strsql = "";
            try
            {
                for (int i = 0; i < WPHbROWDGV.Rows.Count; i++)//得到总行数并在之内循环
                {

                    if (WPHbROWDGV.Rows[i].Cells["ordercade"].Value.ToString() != "")
                    {
                        strsql += "insert into STR_CashReconciliation (SHOPNAME,ORDERCade,OrderDate,BsumMoney,ErpSumMoney,Moneys,ReturnMoney,RteurnS,Reason,username) values ('"
                            + WPHbROWDGV.Rows[i].Cells["shopname"].Value.ToString() + "','"
                            + WPHbROWDGV.Rows[i].Cells["ORDERCade"].Value.ToString() + "','"
                            + WPHbROWDGV.Rows[i].Cells["OrderDate"].Value.ToString() + "','"
                            + WPHbROWDGV.Rows[i].Cells["BsumMoney"].Value.ToString() + "','"
                            + WPHbROWDGV.Rows[i].Cells["ErpSumMoney"].Value.ToString() + "','"
                            + WPHbROWDGV.Rows[i].Cells["Moneys"].Value.ToString() + "','"
                            + WPHbROWDGV.Rows[i].Cells["returnMoney"].Value.ToString() + "','"
                            + WPHbROWDGV.Rows[i].Cells["RteurnS"].Value.ToString() + "','"
                            + WPHbROWDGV.Rows[i].Cells["Reason"].Value.ToString() + "','"
                            + frmlogin.userID + "');";
                    }//
                }

                conn.Open();
                strsql = strsql.Replace("'", "''");
                strsql = strsql.Replace("'',''", "','");
                strsql = strsql.Replace("(''", "('");
                strsql = strsql.Replace("'')", "')");
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新失败！", "系统提示：", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtCade_TextChanged(object sender, EventArgs e)
        {

        }

        private void DTPOrderDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
}
