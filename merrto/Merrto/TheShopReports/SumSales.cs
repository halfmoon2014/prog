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
    public partial class SumSales : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();

        public SumSales()
        {
            InitializeComponent();
        }

        private void SumSales_Load(object sender, EventArgs e)
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

           
            if (this.CmdShop.SelectedValue.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " temp1.ShopID='" + CmdShop.SelectedValue.ToString() + "'";
            }

            if (this.DTPStart.Value.ToString() != "" && DTPStop.Value.ToString("yyyy-MM-dd") != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql += " temp1.CadeDATE Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (strsql != "")
            {
                strsql = " where " + strsql;
            }

            string strsql1 = "";
            if (this.CmdShop.Text.ToString() != "")
            {
                if (strsql1 != "")
                {
                    strsql1 += " and ";
                }
                strsql1 = strsql1 + " temp1.ShopName='" + CmdShop.Text.ToString() + "'";
            }

            if (this.DTPStart.Value.ToString() != "" && DTPStop.Value.ToString("yyyy-MM-dd") != "")
            {
                if (strsql1 != "")
                {
                    strsql1 += " and ";
                }
                strsql1 += " temp1.CadeDATE Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (strsql1 != "")
            {
                strsql1 = " where " + strsql1;
            }
            string order="";
            string orderdetail ="";
            string Customer="";

            string sdstr = "select temp1.CadeDate,ShopName,'刷单原数据' as item,isnull(num1,0) as num1,isnull(summoney1,0) summoney1,0 num2," +
                                "0 summoney2,isnull(num1,0)-0 as num,isnull(summoney1,0)-0 as summoney " +
                                "from (select CadeDate,ShopName,sum(Qty) as num1,Sum(SumMoney) as SumMoney1 from STR_BrushSingleData " +
                                "group by CadeDate,ShopName)temp1 " + strsql1;
            if (this.RBtnEstimate.Checked == true)
            {
                order = "select temp1.CadeDate,ShopName,'日销售订单' as item,isnull(num1,0) as num1,isnull(summoney1,0) summoney1,isnull(num2,0) num2," +
                                "isnull(summoney2,0) summoney2,isnull(num1,0)-isnull(num2,0) as num,isnull(summoney1,0)-isnull(summoney2,0) as summoney " +
                                "from (select CadeDate,shopID,sum(BobyNom) as num1,Sum(SumMoney) as SumMoney1 from STR_OrderList " +
                                "group by CadeDate,shopID)temp1 " +
                                "left join (select CadeDate,shopID,sum(BobyNom) as num2,Sum(SumMoney) as SumMoney2 from STR_OrderList " +
                                "where BobyName like '%【聚】%' or BobyName like '%.%' or BobyName like '%`%' group by CadeDate,shopID " +
                                ")temp2 on temp1.shopID=temp2.shopID and temp1.CadeDate=temp2.CadeDate " +
                                "left join Str_shop on Str_shop.id=temp1.shopID" + strsql;

                orderdetail = "select temp1.CadeDate,ShopName,'日销售宝贝' as item,isnull(num1,0) num1,isnull(cost,0) as summoney1,0 as num2, 0 as summoney2,isnull(num1,0) as num,isnull(cost,0) as summoney " +
                                        "from (select CadeDate,shopID,sum(BuyNo) as num1,sum(cost) as cost from STR_OrderDetailList " +
                                        "left join M_productCost on STR_OrderDetailList.pid=M_productCost.pid group by CadeDate,shopID "+
                                        ")temp1 left join Str_shop on Str_shop.id=temp1.shopID "+ strsql;


                Customer = "select temp1.CadeDate,ShopName,'销售客单价' as item,isnull(num1,0) as num1,isnull(summoney1,0) summoney1,isnull(num2,0) num2," +
                                "isnull(summoney2,0) summoney2,isnull(num1,0)-isnull(num2,0) as num,isnull(summoney1,0)-isnull(summoney2,0) as summoney " +
                                    "from (select CadeDate,STR_CustomerUnit.shopID,sum(PhotographNO) as num1,sum(photographMoney) summoney1 from " +
                                    "STR_CustomerUnit group by CadeDate,shopID)as temp1 " +
                                    "left join (select CadeDate,shopID,sum(PhotographNO) as num2,sum(photographMoney) summoney2 from STR_CustomerUnit where exists(" +
                                    "select * from STR_CustomerUnitSet where STR_CustomerUnit.name=STR_CustomerUnitSet.name " +
                                    ") group by CadeDate,shopID) temp2 on temp1.shopID=temp2.shopID and temp1.CadeDate=temp2.CadeDate " +
                                    "left join Str_shop on Str_shop.id=temp1.shopID" + strsql;
            }
            else if (this.RBtnActual.Checked == true)
            {
                order = "select temp1.CadeDate,ShopName,'实际日销售订单' as item,isnull(num1,0) as num1,isnull(summoney1,0) summoney1,isnull(num2,0) num2," +
                                "isnull(summoney2,0) summoney2,isnull(num1,0)-isnull(num2,0) as num,isnull(summoney1,0)-isnull(summoney2,0) as summoney " +
                                "from (select CadeDate,shopID,sum(BobyNom) as num1,Sum(SumMoney) as SumMoney1 from STR_ActualOrderList " +
                                "group by CadeDate,shopID)temp1 " +
                                "left join (select CadeDate,shopID,sum(BobyNom) as num2,Sum(SumMoney) as SumMoney2 from STR_ActualOrderList " +
                                "where BobyName like '%【聚】%' or BobyName like '%.%' or BobyName like '%`%' group by CadeDate,shopID " +
                                ")temp2 on temp1.shopID=temp2.shopID and temp1.CadeDate=temp2.CadeDate " +
                                "left join Str_shop on Str_shop.id=temp1.shopID" + strsql;
                //order = "select temp1.CadeDate,ShopName,'实际日销售订单' as item,isnull(num1,0) as num1,isnull(summoney1,0) summoney1,0 num2," +
                //                "0 summoney2,isnull(num1,0) as num,isnull(summoney1,0) as summoney " +
                //                "from (select CadeDate,shopID,sum(BobyNom) as num1,Sum(SumMoney) as SumMoney1 from STR_ActualOrderList " +
                //                "group by CadeDate,shopID)temp1 " +
                //                "left join Str_shop on Str_shop.id=temp1.shopID" + strsql;

                orderdetail = "select temp1.CadeDate,ShopName,'实际日销售宝贝' as item,isnull(num1,0) num1,isnull(cost,0) as summoney1,0 as num2, 0 as summoney2,isnull(num1,0) as num,isnull(cost,0) as summoney " +
                                        "from (select CadeDate,shopID,sum(BuyNo) as num1,sum(cost) as cost from STR_ActualOrderDetailList " +
                                        "left join M_productCost on STR_ActualOrderDetailList.pid=M_productCost.pid group by CadeDate,shopID " +
                                        ")temp1 left join Str_shop on Str_shop.id=temp1.shopID " + strsql;

                Customer = "select temp1.CadeDate,ShopName,'销售客单价' as item,isnull(num1,0) as num1,isnull(summoney1,0) summoney1,isnull(num2,0) num2," +
                                "isnull(summoney2,0) summoney2,isnull(num1,0)-isnull(num2,0) as num,isnull(summoney1,0)-isnull(summoney2,0) as summoney " +
                                    "from (select CadeDate,STR_CustomerUnit.shopID,sum(PhotographNO) as num1,sum(photographMoney) summoney1 from " +
                                    "STR_CustomerUnit group by CadeDate,shopID)as temp1 " +
                                    "left join (select CadeDate,shopID,sum(PhotographNO) as num2,sum(photographMoney) summoney2 from STR_CustomerUnit where exists(" +
                                    "select * from STR_CustomerUnitSet where STR_CustomerUnit.name=STR_CustomerUnitSet.name " +
                                    ") group by CadeDate,shopID) temp2 on temp1.shopID=temp2.shopID and temp1.CadeDate=temp2.CadeDate " +
                                    "left join Str_shop on Str_shop.id=temp1.shopID" + strsql;
            }
            if (CboItem.Text.ToString() == "日销售订单")
            {
                strsql = order;
            }else if (CboItem.Text.ToString() == "销售客单价")
            {
                strsql = Customer;
            }else if (CboItem.Text.ToString() == "日销售宝贝")
            {
                strsql = orderdetail;
            }
            else if (CboItem.Text.ToString() == "刷单原数据")
            {
                strsql = sdstr;
            }
            else {
                strsql = order + " union all " + Customer + " union all " + orderdetail + " union all " + sdstr + " order by ShopName,item,CadeDate";
            }
            
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row2 = ds.Tables[0].NewRow();
                decimal SumMoney = 0;
                decimal Num1 = 0;
                decimal Num2 = 0;
                decimal Num = 0;
                decimal SumMoney1 = 0;
                decimal SumMoney2 = 0;
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    Num1 = Num1 + decimal.Parse(ds.Tables[0].Rows[k][3].ToString());
                    SumMoney1 = SumMoney1 + decimal.Parse(ds.Tables[0].Rows[k][4].ToString());
                    Num2 = Num2 + decimal.Parse(ds.Tables[0].Rows[k][5].ToString());
                    SumMoney2 = SumMoney2 + decimal.Parse(ds.Tables[0].Rows[k][6].ToString());
                    Num = Num + decimal.Parse(ds.Tables[0].Rows[k][7].ToString());
                    SumMoney = SumMoney + decimal.Parse(ds.Tables[0].Rows[k][8].ToString());
                }
                row2[0] = "9999-12-31";
                row2[1] = "合计 ";
                row2[2] = " ";
                row2[3] = Num1.ToString();
                row2[4] = SumMoney1.ToString();
                row2[5] = Num2.ToString();
                row2[6] = SumMoney2.ToString();
                row2[7] = Num.ToString();
                row2[8] = SumMoney.ToString();
                ds.Tables[0].Rows.Add(row2);
            }

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["CadeDATE"].HeaderText = "日期";
            WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
            WPHbROWDGV.Columns["item"].HeaderText = "模块";
            WPHbROWDGV.Columns["Num1"].HeaderText = "数量";
            WPHbROWDGV.Columns["SumMoney1"].HeaderText = "总金额";
            WPHbROWDGV.Columns["Num2"].HeaderText = "另算数量";
            WPHbROWDGV.Columns["SumMoney2"].HeaderText = "另算总金额";
            WPHbROWDGV.Columns["Num"].HeaderText = "报表数量";
            WPHbROWDGV.Columns["SumMoney"].HeaderText = "报表总金额";
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
