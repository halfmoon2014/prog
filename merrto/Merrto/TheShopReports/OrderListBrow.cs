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
    public partial class OrderListBrow : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public OrderListBrow()
        {
            InitializeComponent();
        }

        private void OrderListBrow_Load(object sender, EventArgs e)
        {
            this.DTPStart.Text = (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd");
            this.DTPStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "";
            string strsql1 = "";
            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " b.Cade like '%" + TxtCade.Text.ToString() + "%'";
            }

            string yjBB = "select shopname,b.Cade,OrderCade,'预计宝贝' as cadename,CadeDate,sum(buyno) BuyNo from STR_OrderDetailList b left join STR_Shop on STR_Shop.id=shoPID";
            string yjDD = "select shopname,b.Cade,OrderCade,'预计订单' as cadename,CadeDate,sum(BobyNom) buyNO from STR_OrderList b left join STR_Shop on STR_Shop.id=shoPID";
            string sz = "select shopname,b.Cade,OrderCade,'刷钻订单' as cadename,CadeDate,sum(Qty) BuyN from STR_BrushSingleData b ";
            string sjBB = "select shopname,b.Cade,OrderCade,'实际宝贝' as cadename,CadeDate,sum(buyno) BuyNo from STR_ActualOrderDetailList b left join STR_Shop on STR_Shop.id=shoPID ";
            string sjDD = "select shopname,b.Cade,OrderCade,'实际宝贝' as cadename,CadeDate,sum(BobyNom) buyNO from STR_ActualOrderList b left join STR_Shop on STR_Shop.id=shoPID ";

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

            if (this.CmdShop.Text.ToString() != "")
            {
                if (strsql1 != "")
                {
                    strsql1 += " and ";
                }
                strsql1 = strsql1 + " ShopName='" + CmdShop.Text.ToString() + "'";
            }

            if (this.DTPStart.Value.ToString() != "" && DTPStop.Value.ToString("yyyy-MM-dd") != "")
            {
                if (strsql1 != "")
                {
                    strsql1 += " and ";
                }
                strsql1 += "CadeDATE Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (strsql1 != "")
            {
                strsql1 = " where " + strsql1;
            }
            //
            //
            //刷钻宝贝数据
            //
            //
            //

            if (CboItem.Text.ToString() == "预计宝贝数据")
            {
                strsql = yjBB + strsql + " group by shopname,b.Cade,OrderCade,CadeDate";
            }
            else if (CboItem.Text.ToString() == "实际宝贝数据")
            {
                strsql = sjBB + strsql + " group by shopname,b.Cade,OrderCade,CadeDate";
            }
            else if (CboItem.Text.ToString() == "刷钻单据数据")
            {
                strsql = sz + strsql1 + " group by shopname,b.Cade,OrderCade,CadeDate";
            }
            else if (CboItem.Text.ToString() == "实际单据数据")
            {
                strsql = sjDD + strsql + " group by shopname,b.Cade,OrderCade,CadeDate";
            }
            else if (CboItem.Text.ToString() == "预计单据数据")
            {
                strsql = yjDD + strsql + " group by shopname,b.Cade,OrderCade,CadeDate";
            }
            else
            {
                strsql = sjBB + strsql + " group by shopname,b.Cade,OrderCade,CadeDate union all " + sz + strsql1 + " group by shopname,b.Cade,OrderCade,CadeDate union all " + yjBB + strsql + " group by shopname,b.Cade,OrderCade,CadeDate union all " + yjDD + strsql + " group by shopname,b.Cade,OrderCade,CadeDate union all " + sjDD + strsql + " group by shopname,b.Cade,OrderCade,CadeDate";
            }

            //strsql = "select STR_GrossProfitGeneration.Cade,CadeDATE,Shopname,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,ActualSales," +
            //"ActualCostOFSales,TaobaoFeeDeduction,TurnFeededuction,Express,Pit,Advertisement," +
            //"GrossProfit,CustomerUnit,username from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " order by Shopname,CadeDATE,Cade";

            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row2 = ds.Tables[0].NewRow();
                decimal buyNO = 0;
                
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    buyNO = buyNO + decimal.Parse(ds.Tables[0].Rows[k][5].ToString());
                    
                }
                row2[1] = "合计";
                row2[5] = buyNO.ToString();
                ds.Tables[0].Rows.Add(row2);
            }

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["Cade"].HeaderText = "单据号";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "网店单号";
            WPHbROWDGV.Columns["cadename"].HeaderText = "模块";
            WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
            WPHbROWDGV.Columns["CadeDate"].HeaderText = "条码";
            WPHbROWDGV.Columns["BuyNO"].HeaderText = "数量";
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
