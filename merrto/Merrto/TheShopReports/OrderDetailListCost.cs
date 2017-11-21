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
    public partial class OrderDetailListCost : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public OrderDetailListCost()
        {
            InitializeComponent();
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

        private void OrderDetailListCost_Load(object sender, EventArgs e)
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

            string yj = "select shopname,b.Cade,'预计成本' as cadename,b.orderCade,barcode,buyNO,cost,isnull(buyNO*cost,0) CostOFSales from STR_OrderDetailList b " +
                "left join M_productCost on M_productCost.pid=b.pid "+
                "left join STR_Shop on STR_Shop.id=shoPID";
            string sz = "SELECT shopname,Cade,'刷钻成本' as cadename,orderCade,barcode,qty as buyNO,cost,isnull(qty*cost,0) CostOFSales from STR_BrushSingleData b " +
                "left join M_productCost on M_productCost.pid=b.pid ";
            string sj = "select shopname,b.Cade,'实际成本' as cadename,b.orderCade,barcode,buyNO,cost,isnull(buyNO*cost,0) CostOFSales from STR_ActualOrderDetailList b " +
                "left join M_productCost on M_productCost.pid=b.pid "+
                "left join STR_Shop on STR_Shop.id=shoPID ";


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
            
            string insert2 = " update STR_BrushSingleData set PID=M_product.id from M_product where STR_BrushSingleData.barcode=M_product.item_no";
            insert2 += " update STR_BrushSingleData set PID=M_product.id from M_product where 'MT'+STR_BrushSingleData.barcode=M_product.item_no";
            insert2 += " update STR_BrushSingleData set ShopID=STR_Shop.id from STR_Shop where STR_BrushSingleData.shopname=STR_Shop.shopname";
            insert2 += " update STR_ActualOrderDetailList set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                    "left join M_productsub on M_productsub.pid=M_product.id " +
                    "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                    "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                    "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=STR_ActualOrderDetailList.BarCode ;" +
                    "update STR_ActualOrderDetailList set PID=M_product.id from M_product where ITEM_NO=STR_ActualOrderDetailList.BarCode " +
                    "update STR_ActualOrderDetailList set PID=M_product.id from M_product where ITEM_NO='MT'+STR_ActualOrderDetailList.BarCode" +
                " update STR_ActualOrderDetailList set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                    "left join M_productsub on M_productsub.pid=M_product.id " +
                    "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                    "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                    "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='MT'+STR_ActualOrderDetailList.BarCode ;";
            insert2 += " update STR_OrderDetailList set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                   "left join M_productsub on M_productsub.pid=M_product.id " +
                   "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                   "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                   "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=STR_OrderDetailList.BarCode ;" +
                   "update STR_OrderDetailList set PID=M_product.id from M_product where ITEM_NO=STR_OrderDetailList.BarCode " +
                   "update STR_OrderDetailList set PID=M_product.id from M_product where ITEM_NO='MT'+STR_OrderDetailList.BarCode" +
                   " update STR_OrderDetailList set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                   "left join M_productsub on M_productsub.pid=M_product.id " +
                   "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                   "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                   "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='MT'+STR_OrderDetailList.BarCode;";
            insert2 += " update STR_BrushSingleData set PID=M_product.id from M_product " +
                  "left join M_productsub on M_productsub.pid=M_product.id " +
                  "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                  "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                  "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=STR_BrushSingleData.BarCode ;";
                 
            conn.Open();
            SqlCommand cmd = new SqlCommand(insert2, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            if(CboItem.Text.ToString()=="预计宝贝成本")
            {
                 strsql = yj + strsql  ;
            }else if(CboItem.Text.ToString()=="实际宝贝成本")
            {
                strsql = sj + strsql;
            }else if(CboItem.Text.ToString()=="刷钻宝贝成本")
            {
                strsql = sz + strsql1;
            }else {
                strsql = sj + strsql + " union all " + sz + strsql1 + " union all " + yj + strsql;
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
                decimal CostOFSales = 0;
                
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    buyNO = buyNO + decimal.Parse(ds.Tables[0].Rows[k][5].ToString());
                    CostOFSales = CostOFSales + decimal.Parse(ds.Tables[0].Rows[k][7].ToString());
                    
                }
                row2[1] = "合计";
                row2[5] = buyNO.ToString();
                row2[7] = CostOFSales.ToString();
                ds.Tables[0].Rows.Add(row2);
            }

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["Cade"].HeaderText = "单据号";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "网店单号";
            WPHbROWDGV.Columns["cadename"].HeaderText = "模块";
            WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
            WPHbROWDGV.Columns["barcode"].HeaderText = "条码";
            WPHbROWDGV.Columns["buyNO"].HeaderText = "数量";
            WPHbROWDGV.Columns["cost"].HeaderText = "成本";
            WPHbROWDGV.Columns["CostOFSales"].HeaderText = "销售成本";
          
        }
    }
}
