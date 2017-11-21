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
    public partial class TSRDifferenctRatio : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();//连接数据库
        public TSRDifferenctRatio()
        {
            InitializeComponent();
        }

        private void TSRDifferenctRatio_Load(object sender, EventArgs e)
        {
            this.DTPStart.Text = (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd");
            this.DTPStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //店铺combobox绑定数据
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT ID,Cade,ShopNAME FROM STR_Shop ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "Shop");
            conn.Close();
            if (ds.Tables["Shop"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["Shop"].NewRow();//添加空的记录
                ds.Tables["Shop"].Rows.Add(row);//添加空行
                CmdShop.DataSource = ds.Tables["Shop"];
                CmdShop.ValueMember = "ID";
                CmdShop.DisplayMember = "ShopNAME";
            }
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            
            //条件拼接
            string strsql = "";
            if (this.CmdShop.SelectedValue.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ShopID='" + CmdShop.SelectedValue.ToString() + "'";
            }
            //if (this.DTPCadeDate.Value.ToString() != "")
            //{
            //    if (strsql != "")
            //    {
            //        strsql += " and ";
            //    }
            //    strsql += "CadeDATE Between '" + DTPCadeDate.Value.ToString("yyyy-MM") + "-01' and '" + DTPCadeDate.Value.ToString("yyyy-MM") + 
            //        "-" + DateTime.DaysInMonth(DTPCadeDate.Value.Year, DTPCadeDate.Value.Month).ToString() + "'";
            //}
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
            if (RbtnDetailOtlay.Checked == true)
            {
                WPHbROWDGV.DataSource = "";
                //sql语名查找报表的数据
                strsql = "select CadeDATE,Shopname,'A预计报表' AS CadenAME,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,ActualSales,ActualCostOFSales,TaobaoFeeDeduction,TurnFeededuction,Express,ArtificialCost,RentCost,OtherCost,Pit,Advertisement,GrossProfit,CustomerUnit from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID  " +
                        strsql + " and type='1' union all " +
                        "select '9999-12-31',Shopname,'A预计报表合计','',sum(Sales) as Sales,sum(CostOFSales) as CostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost,sum(SalesReturn) SalesReturn,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales),sum(TaobaoFeeDeduction),sum(TurnFeededuction),sum(Express),sum(ArtificialCost),sum(RentCost),sum(OtherCost),sum(Pit),sum(Advertisement),sum(GrossProfit),sum(CustomerUnit) from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " +
                        strsql + " and type='1' GROUP BY Shopname " +
                        "union all select CadeDATE,Shopname,'B实际报表' AS CadenAME,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,ActualSales,ActualCostOFSales,TaobaoFeeDeduction,TurnFeededuction,Express,ArtificialCost,RentCost,OtherCost,Pit,Advertisement,GrossProfit,CustomerUnit from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " +
                         strsql + " and type='2' " +
                        "union all select '9999-12-31',Shopname,'B实际报表合计','',sum(Sales) as Sales,sum(CostOFSales) as CostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost,sum(SalesReturn) SalesReturn,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales),sum(TaobaoFeeDeduction),sum(TurnFeededuction),sum(Express),sum(ArtificialCost),sum(RentCost),sum(OtherCost),sum(Pit),sum(Advertisement),sum(GrossProfit),sum(CustomerUnit) from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " +
                         strsql + " and type='2' GROUP BY Shopname " +
                         "union all " +
                         "select '9999-12-31',temp.Shopname,'C差额',''," +
                        "case when temp.Sales=0 then 0 else temp.Sales-temps.Sales end " +
                        ",case when temp.CostOFSales=0 then 0 else temp.CostOFSales-temps.CostOFSales end" +
                        ",case when temp.BsumMoney=0 then 0 else temp.BsumMoney-temps.BsumMoney end" +
                        ",case when temp.Bcost=0 then 0 else temp.Bcost-temps.Bcost end,'',''" +
                        ",case when temp.ActualSales=0 then 0 else temp.ActualSales-temps.ActualSales end" +
                        ",case when temp.ActualCostOFSales=0 then 0 else temp.ActualCostOFSales-temps.ActualCostOFSales end" +
                        ",case when temp.TaobaoFeeDeduction=0 then 0 else temp.TaobaoFeeDeduction-temps.TaobaoFeeDeduction end" +
                        ",case when temp.TurnFeededuction=0 then 0 else temp.TurnFeededuction-temps.TurnFeededuction end" +
                        ",case when temp.Express=0 then 0 else temp.Express-temps.Express end" +      //ArtificialCost,RentCost,OtherCost,
                        ",case when temp.ArtificialCost=0 then 0 else temp.ArtificialCost-temps.ArtificialCost end" +
                        ",case when temp.RentCost=0 then 0 else temp.RentCost-temps.RentCost end" +
                        ",case when temp.OtherCost=0 then 0 else temp.OtherCost-temps.OtherCost end" +
                        ",case when temp.Pit=0 then 0 else temp.Pit-temps.Pit end" +
                        ",case when temp.Advertisement=0 then 0 else isnull(temp.Advertisement,0)-isnull(temps.Advertisement,0) end" +
                        ",case when temp.GrossProfit=0 then 0 else isnull(temp.GrossProfit,0)-isnull(temps.GrossProfit,0) end" +
                        ",case when temp.CustomerUnit=0 then 0 else isnull(temp.CustomerUnit,0)-isnull(temps.CustomerUnit,0) end " +
                        "from (select Shopname,sum(Sales) as Sales,sum(CostOFSales) as CostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost," +
                        "sum(SalesReturn) SalesReturn1,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales)ActualCostOFSales," +
                        "sum(TaobaoFeeDeduction)TaobaoFeeDeduction,sum(TurnFeededuction)TurnFeededuction,sum(Express)Express,sum(ArtificialCost) as ArtificialCost,sum(RentCost) as RentCost,sum(OtherCost) as OtherCost,sum(Pit)Pit," +
                        "sum(Other)Other,sum(Advertisement)Advertisement,sum(GrossProfit)GrossProfit," +
                        "sum(CustomerUnit) CustomerUnit from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " and type='1' GROUP BY Shopname )temp left join (select Shopname,sum(Sales) as Sales,sum(CostOFSales) as CostOFSales," +
                        "sum(SalesReturn) SalesReturn,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales)ActualCostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost," +
                        "sum(TaobaoFeeDeduction)TaobaoFeeDeduction,sum(TurnFeededuction)TurnFeededuction,sum(Express)Express,sum(ArtificialCost) as ArtificialCost,sum(RentCost) as RentCost,sum(OtherCost) as OtherCost,sum(Pit)Pit,sum(Advertisement)Advertisement,sum(GrossProfit)GrossProfit," +
                        "sum(CustomerUnit)CustomerUnit from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " and type='2' GROUP BY Shopname)temps " +
                        "on  temps.Shopname=temp.shopname " +
                        "union all " +
                        "select '9999-12-31',temp.Shopname,'D占比',''," +
                        "case when temps.Sales=0 then 0 else (temp.Sales-temps.Sales)/temps.Sales end " +
                        ",case when temps.CostOFSales=0 then 0 else (temp.CostOFSales-temps.CostOFSales)/temps.CostOFSales end" +
                        ",case when temps.BsumMoney=0 then 0 else temp.BsumMoney-temps.BsumMoney end" +
                        ",case when temps.Bcost=0 then 0 else temp.Bcost-temps.Bcost end,'',''" +
                        ",case when temps.ActualSales=0 then 0 else (temp.ActualSales-temps.ActualSales)/temps.ActualSales end" +
                        ",case when temps.ActualCostOFSales=0 then 0 else (temp.ActualCostOFSales-temps.ActualCostOFSales)/temps.ActualCostOFSales end" +
                        ",case when temps.TaobaoFeeDeduction=0 then 0 else (temp.TaobaoFeeDeduction-temps.TaobaoFeeDeduction)/temps.TaobaoFeeDeduction end" +
                        ",case when temps.TurnFeededuction=0 then 0 else (temp.TurnFeededuction-temps.TurnFeededuction)/temps.TurnFeededuction end" +
                        ",case when temps.Express=0 then 0 else (temp.Express-temps.Express)/temps.Express end" +
                        ",case when temp.ArtificialCost=0 then 0 else temp.ArtificialCost-temps.ArtificialCost end" +
                        ",case when temp.RentCost=0 then 0 else temp.RentCost-temps.RentCost end" +
                        ",case when temp.OtherCost=0 then 0 else temp.OtherCost-temps.OtherCost end" +
                        ",case when temps.Pit=0 then 0 else (temp.Pit-temps.Pit)/temps.Pit end" +
                        ",case when temps.Advertisement=0 then 0 else (temp.Advertisement-temps.Advertisement)/temps.Advertisement end" +
                        ",case when temps.GrossProfit=0 then 0 else (temp.GrossProfit-temps.GrossProfit)/temps.GrossProfit end" +
                        ",case when temps.CustomerUnit=0 then 0 else (temp.CustomerUnit-temps.CustomerUnit)/temps.CustomerUnit end " +
                        "from (select Shopname,sum(Sales) as Sales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost,sum(CostOFSales) as CostOFSales," +
                        "sum(SalesReturn) SalesReturn1,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales)ActualCostOFSales," +
                        "sum(TaobaoFeeDeduction)TaobaoFeeDeduction,sum(TurnFeededuction)TurnFeededuction,sum(Express)Express,sum(ArtificialCost) as ArtificialCost,sum(RentCost) as RentCost,sum(OtherCost) as OtherCost,sum(Pit)Pit," +
                        "sum(Other)Other,sum(Advertisement)Advertisement,sum(GrossProfit)GrossProfit," +
                        "sum(CustomerUnit) CustomerUnit from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " and type='1' GROUP BY Shopname )temp left join (select Shopname,sum(Sales) as Sales,sum(CostOFSales) as CostOFSales," +
                        "sum(SalesReturn) SalesReturn,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales)ActualCostOFSales," +
                        "sum(TaobaoFeeDeduction)TaobaoFeeDeduction,sum(TurnFeededuction)TurnFeededuction,sum(Express)Express,sum(ArtificialCost) as ArtificialCost,sum(RentCost) as RentCost,sum(OtherCost) as OtherCost,sum(Pit)Pit,sum(Other)Other,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost,sum(Advertisement)Advertisement,sum(GrossProfit)GrossProfit," +
                        "sum(CustomerUnit)CustomerUnit from STR_GrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " and type='2' GROUP BY Shopname)temps " +
                        "on  temps.Shopname=temp.shopname " +
                        "order by Shopname,cadename,CadeDATE";
                SqlConnection conn = sqlcon.getcon("");
                DataSet ds = new DataSet();
                SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
                conn.Open();
                sqlDaper.Fill(ds);
                conn.Close();

                WPHbROWDGV.DataSource = ds.Tables[0];
                WPHbROWDGV.Columns["CadeDATE"].HeaderText = "日期";
                //WPHbROWDGV.Columns["CadeDATE"].Width = 80;
                WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
                WPHbROWDGV.Columns["CadenAME"].HeaderText = "类型名称";
                WPHbROWDGV.Columns["BsumMoney"].HeaderText = "刷单金额";
                WPHbROWDGV.Columns["Bcost"].HeaderText = "刷单成本";
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
                //WPHbROWDGV.Columns["Other"].HeaderText = "其他杂费";
                WPHbROWDGV.Columns["Advertisement"].HeaderText = "广告费";
                WPHbROWDGV.Columns["GrossProfit"].HeaderText = "毛利润";
                WPHbROWDGV.Columns["CustomerUnit"].HeaderText = "客单价";
                WPHbROWDGV.Columns["ArtificialCost"].HeaderText = "人工成本";
                WPHbROWDGV.Columns["RentCost"].HeaderText = "租房";
                WPHbROWDGV.Columns["OtherCost"].HeaderText = "其它成本";
            }
            else if (RbtnOtlay.Checked == true)
            {
                WPHbROWDGV.DataSource = "";
                strsql = "select CadeDATE,Shopname,'A预计报表' AS CadenAME,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,ActualSales,ActualCostOFSales,OutLay,GrossProfit,CustomerUnit from STR_BLGrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID  " +
                       strsql + " and type='1' union all " +
                       "select '9999-12-31',Shopname,'A预计报表合计','',sum(Sales) as Sales,sum(CostOFSales) as CostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost,sum(SalesReturn) SalesReturn,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales),sum(OutLay) OutLay,sum(GrossProfit),sum(CustomerUnit) from STR_BLGrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " +
                       strsql + " and type='1' GROUP BY Shopname " +
                       "union all select CadeDATE,Shopname,'B实际报表' AS CadenAME,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,ActualSales,ActualCostOFSales,OutLay,GrossProfit,CustomerUnit from STR_BlGrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " +
                        strsql + " and type='2' " +
                       "union all select '9999-12-31',Shopname,'B实际报表合计','',sum(Sales) as Sales,sum(CostOFSales) as CostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost,sum(SalesReturn) SalesReturn,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales),sum(OutLay) OutLay,sum(GrossProfit),sum(CustomerUnit) from STR_BLGrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " +
                        strsql + " and type='2' GROUP BY Shopname " +
                        "union all " +
                        "select '9999-12-31',temp.Shopname,'C差额',''," +
                       "case when temp.Sales=0 then 0 else temp.Sales-temps.Sales end " +
                       ",case when temp.CostOFSales=0 then 0 else temp.CostOFSales-temps.CostOFSales end" +
                       ",case when temp.BsumMoney=0 then 0 else temp.BsumMoney-temps.BsumMoney end" +
                       ",case when temp.Bcost=0 then 0 else temp.Bcost-temps.Bcost end,'',''" +
                       ",case when temp.ActualSales=0 then 0 else temp.ActualSales-temps.ActualSales end" +
                       ",case when temp.ActualCostOFSales=0 then 0 else temp.ActualCostOFSales-temps.ActualCostOFSales end" +
                       ",case when temp.OutLay=0 then 0 else temp.OutLay-temps.OutLay end" +
                       ",case when temp.GrossProfit=0 then 0 else isnull(temp.GrossProfit,0)-isnull(temps.GrossProfit,0) end" +
                       ",case when temp.CustomerUnit=0 then 0 else isnull(temp.CustomerUnit,0)-isnull(temps.CustomerUnit,0) end " +
                       "from (select Shopname,sum(Sales) as Sales,sum(CostOFSales) as CostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost," +
                       "sum(SalesReturn) SalesReturn1,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales)ActualCostOFSales,sum(OutLay) OutLay,sum(GrossProfit)GrossProfit," +
                       "sum(CustomerUnit) CustomerUnit from STR_BlGrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " and type='1' GROUP BY Shopname )temp "+
                       "left join (select Shopname,sum(Sales) as Sales,sum(CostOFSales) as CostOFSales,sum(SalesReturn) SalesReturn,sum(RturnCost) as RturnCost,"+
                       "sum(ActualSales) ActualSales,sum(ActualCostOFSales)ActualCostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost,sum(OutLay) OutLay,sum(GrossProfit)GrossProfit," +
                       "sum(CustomerUnit)CustomerUnit from STR_BlGrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " and type='2' GROUP BY Shopname)temps " +
                       "on  temps.Shopname=temp.shopname " +
                       "union all " +
                       "select '9999-12-31',temp.Shopname,'D占比',''," +
                       "case when temps.Sales=0 then 0 else (temp.Sales-temps.Sales)/temps.Sales end " +
                       ",case when temps.CostOFSales=0 then 0 else (temp.CostOFSales-temps.CostOFSales)/temps.CostOFSales end" +
                       ",case when temps.BsumMoney=0 then 0 else temp.BsumMoney-temps.BsumMoney end" +
                       ",case when temps.Bcost=0 then 0 else temp.Bcost-temps.Bcost end,'',''" +
                       ",case when temps.ActualSales=0 then 0 else (temp.ActualSales-temps.ActualSales)/temps.ActualSales end" +
                       ",case when temps.ActualCostOFSales=0 then 0 else (temp.ActualCostOFSales-temps.ActualCostOFSales)/temps.ActualCostOFSales end" +
                       ",case when temps.OutLay=0 then 0 else (temp.OutLay-temps.OutLay)/temps.OutLay end" +
                       ",case when temps.GrossProfit=0 then 0 else (temp.GrossProfit-temps.GrossProfit)/temps.GrossProfit end" +
                       ",case when temps.CustomerUnit=0 then 0 else (temp.CustomerUnit-temps.CustomerUnit)/temps.CustomerUnit end " +
                       "from (select Shopname,sum(Sales) as Sales,sum(CostOFSales) as CostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost," +
                       "sum(SalesReturn) SalesReturn1,sum(RturnCost) as RturnCost,sum(ActualSales) ActualSales,sum(ActualCostOFSales)ActualCostOFSales,sum(OutLay) OutLay,sum(GrossProfit)GrossProfit," +
                       "sum(CustomerUnit) CustomerUnit from STR_BlGrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " and type='1' GROUP BY Shopname )temp " +
                       "left join (select Shopname,sum(Sales) as Sales,sum(CostOFSales) as CostOFSales,sum(SalesReturn) SalesReturn,sum(RturnCost) as RturnCost," +
                       "sum(ActualSales) ActualSales,sum(ActualCostOFSales)ActualCostOFSales,sum(BsumMoney) BsumMoney,sum(Bcost) Bcost,sum(OutLay) OutLay,sum(GrossProfit)GrossProfit," +
                       "sum(CustomerUnit)CustomerUnit from STR_BlGrossProfitGeneration left join STR_Shop on STR_Shop.id=shopID " + strsql + " and type='2' GROUP BY Shopname)temps " +
                       "on  temps.Shopname=temp.shopname " +
                       "order by Shopname,cadename,CadeDATE";
                SqlConnection conn = sqlcon.getcon("");
                DataSet ds = new DataSet();
                SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
                conn.Open();
                sqlDaper.Fill(ds);
                conn.Close();

                WPHbROWDGV.DataSource = ds.Tables[0];
                WPHbROWDGV.Columns["CadeDATE"].HeaderText = "日期";
                WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
                WPHbROWDGV.Columns["CadenAME"].HeaderText = "类型名称";
                WPHbROWDGV.Columns["BsumMoney"].HeaderText = "刷单金额";
                WPHbROWDGV.Columns["Bcost"].HeaderText = "刷单成本";
                WPHbROWDGV.Columns["PeriodDate"].HeaderText = "期间";
                WPHbROWDGV.Columns["Sales"].HeaderText = "销售额";
                WPHbROWDGV.Columns["CostOFSales"].HeaderText = "销售成本";
                WPHbROWDGV.Columns["SalesReturn"].HeaderText = "销售退货";
                WPHbROWDGV.Columns["RturnCost"].HeaderText = "退货成本";
                WPHbROWDGV.Columns["ActualSales"].HeaderText = "实际销售";
                WPHbROWDGV.Columns["ActualSales"].HeaderText = "实际销售";
                WPHbROWDGV.Columns["ActualCostOFSales"].HeaderText = "实际销售成本";
                WPHbROWDGV.Columns["GrossProfit"].HeaderText = "毛利润";
                WPHbROWDGV.Columns["CustomerUnit"].HeaderText = "客单价";
                WPHbROWDGV.Columns["OutLay"].HeaderText = "费用";
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

        private void WPHbROWDGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //WPHbROWDGV.Columns["username"].Width = 80;
            //this.WPHbROWDGV.RowsDefaultCellStyle.ForeColor = Color.Black;     //所有行字体颜色
            ////this.WPHbROWDGV.Rows[0].DefaultCellStyle.BackColor = Color.Red;     //单行背景颜色（Row[行号]）
            ////this.WPHbROWDGV.RowsDefaultCellStyle.BackColor = Color.Red;     //所有行背景颜色
            ////this.WPHbROWDGV.Rows[0].DefaultCellStyle.ForeColor = Color.Red;     //单行字体颜色
            ////this.WPHbROWDGV.RowsDefaultCellStyle.ForeColor = Color.Red;     //所有行字体颜色
            if (e.RowIndex < WPHbROWDGV.Rows.Count)
            {
                DataGridViewRow dgrSingle = WPHbROWDGV.Rows[e.RowIndex];
                try
                {
                    if (dgrSingle.Cells["CadenAME"].Value.ToString().Contains("合计"))
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    if (dgrSingle.Cells["CadenAME"].Value.ToString().Contains("C差额"))
                    {
                        dgrSingle.DefaultCellStyle.BackColor = Color.Goldenrod;
                    }
                    if (dgrSingle.Cells["CadenAME"].Value.ToString().Contains("D占比"))
                    {
                        dgrSingle.DefaultCellStyle.BackColor = Color.Pink;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
    }
}
