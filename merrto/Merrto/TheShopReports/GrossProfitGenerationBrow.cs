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
    public partial class GrossProfitGenerationBrow : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public GrossProfitGenerationBrow()
        {
            InitializeComponent();
        }

        private void GrossProfitGenerationBrow_Load(object sender, EventArgs e)
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
            string strsql = "";

            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Wph_Packing.Cade like '%" + TxtCade.Text.ToString() + "%'";
            }

            if (RBtnActual.Checked == true)
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " STR_GrossProfitGeneration.Type=2 ";
            }else if (this.RBtnEstimate.Checked == true)
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " STR_GrossProfitGeneration.Type=1 ";
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
            strsql = "select STR_GrossProfitGeneration.Cade,CadeDATE,Shopname,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,isnull(ActualSales,0) ActualSales," +
                    "ActualCostOFSales,TaobaoFeeDeduction,TurnFeededuction,Express,isnull(ArtificialCost,0) as ArtificialCost,isnull(RentCost,0)RentCost,isnull(OtherCost,0) OtherCost,Pit,Advertisement," +
                    "GrossProfit,CustomerUnit,username from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " order by Shopname,CadeDATE,Cade";
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
                decimal TaobaoFeeDeduction = 0;
                decimal TurnFeededuction = 0;
                decimal Express = 0;
                decimal Pit = 0;
                decimal Advertisement = 0;
                decimal GrossProfit = 0;
                decimal ArtificialCost = 0;
                decimal RentCost = 0;
                decimal OtherCost = 0;

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
                    TaobaoFeeDeduction = TaobaoFeeDeduction + decimal.Parse(ds.Tables[0].Rows[k][12].ToString());
                    TurnFeededuction = TurnFeededuction + decimal.Parse(ds.Tables[0].Rows[k][13].ToString());
                    Express = Express + decimal.Parse(ds.Tables[0].Rows[k][14].ToString());
                    ArtificialCost = ArtificialCost + decimal.Parse(ds.Tables[0].Rows[k][15].ToString());
                    RentCost = RentCost + decimal.Parse(ds.Tables[0].Rows[k][16].ToString());
                    OtherCost = OtherCost + decimal.Parse(ds.Tables[0].Rows[k][17].ToString());
                    Pit = Pit + decimal.Parse(ds.Tables[0].Rows[k][18].ToString());
                    Advertisement = Advertisement + decimal.Parse(ds.Tables[0].Rows[k][19].ToString());
                    GrossProfit = GrossProfit + decimal.Parse(ds.Tables[0].Rows[k][20].ToString());
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
                row2[12] = TaobaoFeeDeduction.ToString();
                row2[13] = TurnFeededuction.ToString();
                row2[14] = Express.ToString();
                row2[15] = ArtificialCost.ToString();
                row2[16] = RentCost.ToString();
                row2[17] = OtherCost.ToString();
                row2[18] = Pit.ToString();
                row2[19] = Advertisement.ToString();
                row2[20] = GrossProfit.ToString();
               
                ds.Tables[0].Rows.Add(row2);
            }
            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["Cade"].HeaderText = "单据号";
            WPHbROWDGV.Columns["CadeDATE"].HeaderText = "日期";
            //WPHbROWDGV.Columns["CadeDATE"].Width = 80;
            WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
            //WPHbROWDGV.Columns["Shopname"].Width = 80;
            WPHbROWDGV.Columns["PeriodDate"].HeaderText = "期间";
            //WPHbROWDGV.Columns["PeriodDate"].Width = 60;
            WPHbROWDGV.Columns["Sales"].HeaderText = "销售额";
            //WPHbROWDGV.Columns["Sales"].Width = 60;
            WPHbROWDGV.Columns["CostOFSales"].HeaderText = "销售成本";
            // WPHbROWDGV.Columns["CostOFSales"].Width = 80;
            WPHbROWDGV.Columns["SalesReturn"].HeaderText = "销售退货";
            //WPHbROWDGV.Columns["SalesReturn"].Width = 60;
            WPHbROWDGV.Columns["RturnCost"].HeaderText = "退货成本";
            //WPHbROWDGV.Columns["RturnCost"].Width = 80;
            WPHbROWDGV.Columns["ActualSales"].HeaderText = "实际销售";
            //WPHbROWDGV.Columns["ActualSales"].Width = 80;
            WPHbROWDGV.Columns["ActualSales"].HeaderText = "实际销售";
            //WPHbROWDGV.Columns["ActualSales"].Width = 80;
            WPHbROWDGV.Columns["ActualCostOFSales"].HeaderText = "实际销售成本";
            // WPHbROWDGV.Columns["ActualCostOFSales"].Width = 80;
            WPHbROWDGV.Columns["TaobaoFeeDeduction"].HeaderText = "淘宝扣费";
            //WPHbROWDGV.Columns["TaobaoFeeDeduction"].Width = 80;
            WPHbROWDGV.Columns["TurnFeededuction"].HeaderText = "聚/团扣费";
            //WPHbROWDGV.Columns["TurnFeededuction"].Width = 60;
            WPHbROWDGV.Columns["Express"].HeaderText = "快递费";
            //WPHbROWDGV.Columns["Express"].Width = 60;
            WPHbROWDGV.Columns["Pit"].HeaderText = "坑位费";
            //WPHbROWDGV.Columns["Pit"].Width = 80;
            WPHbROWDGV.Columns["BsumMoney"].HeaderText = "刷单金额";
            WPHbROWDGV.Columns["Bcost"].HeaderText = "刷单成本";
            //WPHbROWDGV.Columns["Other"].Width = 60;
            WPHbROWDGV.Columns["Advertisement"].HeaderText = "广告费";
            //WPHbROWDGV.Columns["Advertisement"].Width = 80;
            WPHbROWDGV.Columns["GrossProfit"].HeaderText = "毛利润";
            //WPHbROWDGV.Columns["GrossProfit"].Width = 80;
            WPHbROWDGV.Columns["CustomerUnit"].HeaderText = "客单价";
            // WPHbROWDGV.Columns["CustomerUnit"].Width = 80;
            WPHbROWDGV.Columns["username"].HeaderText = "操作员";
            WPHbROWDGV.Columns["ArtificialCost"].HeaderText = "人工成本";
            WPHbROWDGV.Columns["RentCost"].HeaderText = "租房";
            WPHbROWDGV.Columns["OtherCost"].HeaderText = "其它成本";
           
            //WPHbROWDGV.Columns["username"].Width = 80;

            
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private DataSet DStable()
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

            if (RBtnActual.Checked == true)
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " STR_GrossProfitGeneration.Type=2 ";
            }
            else if (this.RBtnEstimate.Checked == true)
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " STR_GrossProfitGeneration.Type=1 ";
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

            if (CboType.Text.ToString() != "")
            {
                if (CboType.Text.ToString() == "日期")
                {
                    strsql = "select Convert(varchar (2),CadeDate,109) +(case when cast(Convert(varchar (2),CadeDate,105) as int)>0 and cast(Convert(varchar (2),CadeDate,105) as int)<11 then '上旬' " +
                            "when cast(Convert(varchar (2),CadeDate,105) as int)>10 and cast(Convert(varchar (2),CadeDate,105) as int)<21 then '中旬' " +
                            "else '下旬' end) as type,round(sum(GrossProfit)/10000,2) as GrossProfit from STR_GrossProfitGeneration" + strsql + "group by CadeDate";
                }
                else if (CboType.Text.ToString() == "店铺")
                {
                    strsql = "select Shopname as type,round(sum(GrossProfit)/10000,2) as GrossProfit from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + "group by Shopname";
                }

            }
            else
            {
                strsql = "select CadeDate as type,round(sum(GrossProfit)/10000,2) as GrossProfit from STR_GrossProfitGeneration where 1=2 group by CadeDate";
            }
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            return ds;
            
            
        }

        private void BtnZheXian_Click(object sender, EventArgs e)
        {
            DataSet ds = DStable();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Bitmap bMap = new Bitmap(PbGDIImage.Width, PbGDIImage.Height);
                Graphics gph = Graphics.FromImage(bMap);
                gph.Clear(Color.White);
                PointF cpt = new PointF(40, 400);//中心点
                PointF[] xpt = new PointF[3] { new PointF(cpt.Y + 15, cpt.Y), new PointF(cpt.Y, cpt.Y - 8), new PointF(cpt.Y, cpt.Y + 8) };
                PointF[] ypt = new PointF[3] { new PointF(cpt.X, cpt.X - 15), new PointF(cpt.X - 8, cpt.X), new PointF(cpt.X + 8, cpt.X) };
                //画X轴
                gph.DrawString("利润报表图表分析", new Font("宋体", 14), Brushes.Black, new PointF(cpt.X + 60, cpt.X));
                gph.DrawLine(Pens.Black, cpt.X, cpt.Y, cpt.Y, cpt.Y);
                gph.DrawPolygon(Pens.Black, xpt);
                gph.FillPolygon(new SolidBrush(Color.Black), xpt);

                if (CboType.Text.ToString() != "")
                {
                    if (CboType.Text.ToString() == "日期")
                    {
                        gph.DrawString("月份", new Font("宋体", 12), Brushes.Green, new PointF(cpt.Y + 10, cpt.Y + 10));
                    }
                    else if (CboType.Text.ToString() == "店铺")
                    {
                        gph.DrawString("店铺", new Font("宋体", 12), Brushes.Green, new PointF(cpt.Y + 10, cpt.Y + 10));
                    }
                }
                //画Y轴
                gph.DrawLine(Pens.Black, cpt.X, cpt.Y, cpt.X, cpt.X);
                gph.DrawPolygon(Pens.Black, ypt);
                gph.FillPolygon(new SolidBrush(Color.Black), ypt);

                gph.DrawString("单位（万）", new Font("宋体", 12), Brushes.Green, new PointF(0, 7));
                float gross = float.Parse("0.0");
                //画Y刻度
                for (int j = 0; j <= 10; j++)
                {
                    gph.DrawString((j * 10).ToString(), new Font("宋体", 11), Brushes.Green, new PointF(cpt.X - 30, cpt.Y - j * 30 - 6));
                    gph.DrawLine(Pens.Black, cpt.X - 3, cpt.Y - j * 30, cpt.X, cpt.Y - j * 30);
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ////画X项目
                    for (int s = 0; s < ds.Tables[0].Rows[i]["type"].ToString().Length; s++)
                    {
                        gph.DrawString(ds.Tables[0].Rows[i]["type"].ToString().Substring(s, 1), new Font("宋体", 11), Brushes.Green, new PointF(cpt.X + (i + 1) * 30 - 5, cpt.Y + 5 + s * 15));
                    }
                    //画点
                    gph.DrawEllipse(Pens.Black, cpt.X + (i + 1) * 30 - 1.5F, cpt.Y - float.Parse(ds.Tables[0].Rows[i]["GrossProfit"].ToString()) * 3 - 1.5F, 3, 3);
                    gph.FillEllipse(new SolidBrush(Color.Black), cpt.X + (i + 1) * 30 - 1.5F, cpt.Y - float.Parse(ds.Tables[0].Rows[i]["GrossProfit"].ToString()) * 3 - 1.5F, 3, 3);
                    //画数值
                    gph.DrawString(float.Parse(ds.Tables[0].Rows[i]["GrossProfit"].ToString()).ToString(), new Font("宋体", 11), Brushes.Black, new PointF(cpt.X + (i + 1) * 30,
                        cpt.Y - float.Parse(ds.Tables[0].Rows[i]["GrossProfit"].ToString()) * 3));
                    //画折线
                    if (i >= 1)
                        gph.DrawLine(Pens.Black, cpt.X + (i) * 30, cpt.Y - gross * 3, cpt.X + (i + 1) * 30,
                            cpt.Y - float.Parse(ds.Tables[0].Rows[i]["GrossProfit"].ToString()) * 3);
                    gross = float.Parse(ds.Tables[0].Rows[i]["GrossProfit"].ToString());
                }
                PbGDIImage.Image = bMap;
            }
            else
            {
                MessageBox.Show("没有你要分析的数据!!");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
