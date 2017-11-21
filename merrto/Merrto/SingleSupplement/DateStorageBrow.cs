using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.SingleSupplement
{
    public partial class DateStorageBrow : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public DateStorageBrow()
        {
            InitializeComponent();
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

            if (this.DTPStart.Value.ToString() != "" && DTPStop.Value.ToString("yyyy-MM-dd") != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql += "CadeDATE = '" + DTPStart.Value.ToString("yyyy-MM-dd") + "'";
                //strsql += "CadeDATE Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (strsql != "")
            {
                strsql = " where " + strsql;
            }
            strsql = "select SS_DateStorage.Cade,cadeDate,BarCode,item_no,s_color,m_SizeDetails.name as SDname,Qty,Case when [Type]=1 then '金蝶库存' else 'ERP库存' end orderType from SS_DateStorage "+
                        "left join M_product on M_product.id=SS_DateStorage.pid "+
                        "left join M_productsub on M_productsub.id=colourid "+
                        "left join m_SizeDetails on m_SizeDetails.id=SS_DateStorage.Sdid " + strsql + " order by CadeDATE,Cade";
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["Cade"].HeaderText = "单据号";
            WPHbROWDGV.Columns["CadeDATE"].HeaderText = "日期";
            WPHbROWDGV.Columns["BarCode"].HeaderText = "条码";
            WPHbROWDGV.Columns["s_color"].HeaderText = "颜色";
            WPHbROWDGV.Columns["item_no"].HeaderText = "款号";
            WPHbROWDGV.Columns["SDname"].HeaderText = "尺码";
            WPHbROWDGV.Columns["Qty"].HeaderText = "数量";
            WPHbROWDGV.Columns["orderType"].HeaderText = "来自";
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DataRow row2 = ds.Tables[0].NewRow();
            //    decimal Sales = 0;
            //    decimal CostOFSales = 0;
            //    decimal BsumMoney = 0;
            //    decimal Bcost = 0;
            //    decimal SalesReturn = 0;
            //    decimal RturnCost = 0;
            //    decimal ActualSales = 0;
            //    decimal ActualCostOFSales = 0;
            //    decimal TaobaoFeeDeduction = 0;
            //    decimal TurnFeededuction = 0;
            //    decimal Express = 0;
            //    decimal Pit = 0;
            //    decimal Advertisement = 0;
            //    decimal GrossProfit = 0;
            //    decimal ArtificialCost = 0;
            //    decimal RentCost = 0;
            //    decimal OtherCost = 0;

            //    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            //    {
            //        Sales = Sales + decimal.Parse(ds.Tables[0].Rows[k][4].ToString());
            //        CostOFSales = CostOFSales + decimal.Parse(ds.Tables[0].Rows[k][5].ToString());
            //        BsumMoney = BsumMoney + decimal.Parse(ds.Tables[0].Rows[k][6].ToString());
            //        Bcost = Bcost + decimal.Parse(ds.Tables[0].Rows[k][7].ToString());
            //        SalesReturn = SalesReturn + decimal.Parse(ds.Tables[0].Rows[k][8].ToString());
            //        RturnCost = RturnCost + decimal.Parse(ds.Tables[0].Rows[k][9].ToString());
            //        ActualSales = ActualSales + decimal.Parse(ds.Tables[0].Rows[k][10].ToString());
            //        ActualCostOFSales = ActualCostOFSales + decimal.Parse(ds.Tables[0].Rows[k][11].ToString());
            //        TaobaoFeeDeduction = TaobaoFeeDeduction + decimal.Parse(ds.Tables[0].Rows[k][12].ToString());
            //        TurnFeededuction = TurnFeededuction + decimal.Parse(ds.Tables[0].Rows[k][13].ToString());
            //        Express = Express + decimal.Parse(ds.Tables[0].Rows[k][14].ToString());
            //        ArtificialCost = ArtificialCost + decimal.Parse(ds.Tables[0].Rows[k][15].ToString());
            //        RentCost = RentCost + decimal.Parse(ds.Tables[0].Rows[k][16].ToString());
            //        OtherCost = OtherCost + decimal.Parse(ds.Tables[0].Rows[k][17].ToString());
            //        Pit = Pit + decimal.Parse(ds.Tables[0].Rows[k][18].ToString());
            //        Advertisement = Advertisement + decimal.Parse(ds.Tables[0].Rows[k][19].ToString());
            //        GrossProfit = GrossProfit + decimal.Parse(ds.Tables[0].Rows[k][20].ToString());
            //    }
            //    row2[0] = "合计";
            //    row2[1] = "9999-12-31";
            //    row2[2] = " ";
            //    row2[3] = " ";
            //    row2[4] = Sales.ToString();
            //    row2[5] = CostOFSales.ToString();
            //    row2[6] = BsumMoney.ToString();
            //    row2[7] = Bcost.ToString();
            //    row2[8] = SalesReturn.ToString();
            //    row2[9] = RturnCost.ToString();
            //    row2[10] = ActualSales.ToString();
            //    row2[11] = ActualCostOFSales.ToString();
            //    row2[12] = TaobaoFeeDeduction.ToString();
            //    row2[13] = TurnFeededuction.ToString();
            //    row2[14] = Express.ToString();
            //    row2[15] = ArtificialCost.ToString();
            //    row2[16] = RentCost.ToString();
            //    row2[17] = OtherCost.ToString();
            //    row2[18] = Pit.ToString();
            //    row2[19] = Advertisement.ToString();
            //    row2[20] = GrossProfit.ToString();

            //    ds.Tables[0].Rows.Add(row2);
            //}
           
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
