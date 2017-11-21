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
    public partial class CashReconciliationBrow : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public CashReconciliationBrow()
        {
            InitializeComponent();
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
            //WPHbROWDGV.Columns["CadeDATE"].Width = 80;
            WPHbROWDGV.Columns["erpsummoney"].HeaderText = "ERP总金额";
            //WPHbROWDGV.Columns["Shopname"].Width = 80;
            WPHbROWDGV.Columns["moneys"].HeaderText = "积分";
            //WPHbROWDGV.Columns["PeriodDate"].Width = 60;
            WPHbROWDGV.Columns["bsumMoney"].HeaderText = "支付宝金额";
            //WPHbROWDGV.Columns["Sales"].Width = 60;
            WPHbROWDGV.Columns["returnMoney"].HeaderText = "退款金额";
            // WPHbROWDGV.Columns["CostOFSales"].Width = 80;
            WPHbROWDGV.Columns["Rteurns"].HeaderText = " 异常差额";
            WPHbROWDGV.Columns["Reason"].HeaderText = "异常原因";
            WPHbROWDGV.Columns["ID"].Visible = false;
            WPHbROWDGV.Columns["OrderDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["username"].HeaderText = "制单人";
           
        }

        private void CashReconciliationBrow_Load(object sender, EventArgs e)
        {
            DTPOrderDate.Text = (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd");
            this.DTStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
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

        private void btnupEXcel_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows.Count > 0)
            {
                //建立Excel对象    
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                //生成字段名称    
                for (int i = 0; i < WPHbROWDGV.ColumnCount; i++)
                {
                    excel.Cells[1, i + 1] = WPHbROWDGV.Columns[i].HeaderText;
                    //if (y == 0)
                    //{
                    //    y = 1;
                    //    //toolStripStatusLabel6.Text = "数据导入中，请等待!";
                    //}
                }    //填充数据    
                for (int i = 0; i < WPHbROWDGV.RowCount; i++)
                {
                    for (int j = 0; j < WPHbROWDGV.ColumnCount; j++)
                    {
                        if (WPHbROWDGV[j, i].Value == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "" + WPHbROWDGV[i, j].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = WPHbROWDGV[j, i].Value.ToString();
                        }
                    }
                }
                excel.Visible = true;
            }
            else
            {
                MessageBox.Show("没有你要导的数据！！！");
            }
        
        }
    }
}
