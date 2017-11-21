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
    public partial class zfbERPdate : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public zfbERPdate()
        {
            InitializeComponent();
        }

        private void zfbERPdate_Load(object sender, EventArgs e)
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

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            string strsql = "";


            if (this.CmdShop.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " shopname='" + CmdShop.Text.ToString() + "'";
            }

            if (this.DTPStart.Value.ToString() != "" && DTPStop.Value.ToString("yyyy-MM-dd") != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql += " OrderDate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "'";
            }

            if (strsql != "")
            {
                strsql = " where " + strsql;
            }
            string zfb_ = "select shopName,STR_ZFBDate.cade,cadedate,orderCade,orderDate,sumMoney,ReturnMoney,userName from STR_ZFBDate left join STR_Shop on STR_Shop.id=STR_ZFBDate.shopID " + strsql;
            string erp_ = "select shopName,cade,cadedate,orderCade,orderDate,sumMoney,0 as ReturnMoney,userName from Str_ErpDate " + strsql;
            if (CboItem.Text.ToString() == "支付宝")
            {
                strsql = zfb_;
            }
            else if (CboItem.Text.ToString() == "ERP")
            {
                strsql = erp_;
            }
           
            else
            {
                strsql = zfb_ + " union all " + erp_ +  " order by ShopName,CadeDate";
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
                decimal ReturnMoney = 0;
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {

                    SumMoney = SumMoney + decimal.Parse(ds.Tables[0].Rows[k][5].ToString());
                    ReturnMoney = ReturnMoney + decimal.Parse(ds.Tables[0].Rows[k][6].ToString());
                    
                }
                
                row2[1] = "合计 ";
                row2[5] = SumMoney.ToString();
                row2[6] = ReturnMoney.ToString();
                ds.Tables[0].Rows.Add(row2);
            }

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["shopName"].HeaderText = "店名";
            WPHbROWDGV.Columns["Cade"].HeaderText = "单据号";
            WPHbROWDGV.Columns["CadeDATE"].HeaderText = "日期";
            WPHbROWDGV.Columns["Shopname"].HeaderText = "店铺";
             WPHbROWDGV.Columns["orderCade"].HeaderText = "网络单号";
             WPHbROWDGV.Columns["orderDate"].HeaderText = "修改时间";
            WPHbROWDGV.Columns["ReturnMoney"].HeaderText = "退货";
            WPHbROWDGV.Columns["SumMoney"].HeaderText = "总金额";
           
        }
    }
}
