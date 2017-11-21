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
    public partial class BlGrossProfitGenerationBrow : Form
    {
        public BlGrossProfitGenerationBrow()
        {
            InitializeComponent();
        }
        baseclass.SelectDate sd = new baseclass.SelectDate();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private void BlGrossProfitGenerationBrow_Load(object sender, EventArgs e)
        {
            this.DTPStart.Text = (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd");
            this.DTPStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable dt=sd.GetShop();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);
                CmdShop.DataSource = dt;
                CmdShop.ValueMember = "ID";
                CmdShop.DisplayMember = "ShopNAME";
            }
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            string strsql = "";

            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Cade like '%" + TxtCade.Text.ToString() + "%'";
            }

            if (RBtnActual.Checked == true)
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Type=2 ";
            }
            else if (this.RBtnEstimate.Checked == true)
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Type=1 ";
            }

            if (this.CmdShop.SelectedValue.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ShopID='" + CmdShop.SelectedValue.ToString() + "'";
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
            strsql = "select STR_BlGrossProfitGeneration.Cade,CadeDATE,Shopname,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,isnull(ActualSales,0) ActualSales," +
                    "ActualCostOFSales,OutLay,GrossProfit,customerUnit,username from STR_BlGrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " order by Shopname,CadeDATE,Cade";
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row2 = ds.Tables[0].NewRow();
                decimal Sales = 0;
                decimal CostOFSales = 0;
                decimal BsumMoney = 0;
                decimal Bcost = 0;
                decimal SalesReturn = 0;
                decimal RturnCost = 0;
                decimal ActualSales = 0;
                decimal ActualCostOFSales = 0;
                decimal OutLay = 0;
                decimal GrossProfit = 0;
                

                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    Sales = Sales + decimal.Parse(ds.Tables[0].Rows[k][4].ToString());
                    CostOFSales = CostOFSales + decimal.Parse(ds.Tables[0].Rows[k][5].ToString());
                    BsumMoney = BsumMoney + decimal.Parse(ds.Tables[0].Rows[k][6].ToString());
                    Bcost = Bcost + decimal.Parse(ds.Tables[0].Rows[k][7].ToString());
                    SalesReturn = SalesReturn + decimal.Parse(ds.Tables[0].Rows[k][8].ToString());
                    RturnCost = RturnCost + decimal.Parse(ds.Tables[0].Rows[k][9].ToString());
                    ActualSales = ActualSales + decimal.Parse(ds.Tables[0].Rows[k][10].ToString());
                    ActualCostOFSales = ActualCostOFSales + decimal.Parse(ds.Tables[0].Rows[k][11].ToString());
                    OutLay = OutLay + decimal.Parse(ds.Tables[0].Rows[k][12].ToString());
                    GrossProfit = GrossProfit + decimal.Parse(ds.Tables[0].Rows[k][13].ToString());
                }
                row2[0] = "合计";
                row2[1] = "9999-12-31";
                row2[2] = " ";
                row2[3] = " ";
                row2[4] = Sales.ToString();
                row2[5] = CostOFSales.ToString();
                row2[6] = BsumMoney.ToString();
                row2[7] = Bcost.ToString();
                row2[8] = SalesReturn.ToString();
                row2[9] = RturnCost.ToString();
                row2[10] = ActualSales.ToString();
                row2[11] = ActualCostOFSales.ToString();
                row2[12] = OutLay.ToString();
                row2[13] = GrossProfit.ToString();
               
                ds.Tables[0].Rows.Add(row2);
            }
            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["Cade"].HeaderText = "单据号";
            WPHbROWDGV.Columns["CadeDATE"].HeaderText = "日期";
            WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
            WPHbROWDGV.Columns["PeriodDate"].HeaderText = "期间";
            WPHbROWDGV.Columns["Sales"].HeaderText = "销售额";
            WPHbROWDGV.Columns["CostOFSales"].HeaderText = "销售成本";
            WPHbROWDGV.Columns["SalesReturn"].HeaderText = "销售退货";
            WPHbROWDGV.Columns["BsumMoney"].HeaderText = "刷单金额";
            WPHbROWDGV.Columns["Bcost"].HeaderText = "刷单成本";
            WPHbROWDGV.Columns["RturnCost"].HeaderText = "退货成本";
            WPHbROWDGV.Columns["ActualSales"].HeaderText = "实际销售";
            WPHbROWDGV.Columns["ActualSales"].HeaderText = "实际销售";
            WPHbROWDGV.Columns["ActualCostOFSales"].HeaderText = "实际销售成本";
            WPHbROWDGV.Columns["GrossProfit"].HeaderText = "毛利润";
            WPHbROWDGV.Columns["OutLay"].HeaderText = "费用";
            WPHbROWDGV.Columns["CustomerUnit"].HeaderText = "客单价";
            WPHbROWDGV.Columns["username"].HeaderText = "操作员";
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
