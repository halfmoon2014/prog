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
    public partial class CashReconciliation : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public CashReconciliation()
        {
            InitializeComponent();
        }

        private void CashReconciliation_Load(object sender, EventArgs e)
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
            string strwther = "";
            string erpstr = "";
            string ZFBstr = "";
            string strwhere = "";
            string exthe = "";
            string exthe2 = "";
            //所有数据
            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Str_ErpDate.OrderCade like '%" + TxtCade.Text.ToString() + "%'";
            }
            if (this.CmdShop.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ShopName='" + CmdShop.Text.ToString() + "'";
            }

            if (this.DTPOrderDate.Value.ToString() != "")
            {
                if (strwther != "")
                {
                    strwther += " and ";
                }
                strwther += " Str_ErpDate.orderdate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + "' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + "'";

                if (strwther != "")
                {
                    strwther = " where " + strwther;
                }
            }
            if (strsql != "")
            {
                strsql += " and ";
            }
            strsql = strsql + " b.ordercade !=''";

            ////

            exthe = exthe + " B.orderdate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + "' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + "'";
            if (exthe != "")
            {
                exthe = " and " + exthe;
            }
            //exthe2 = exthe2 + " orderdate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + "  00:00:00.000' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000'";
            //if (exthe2 != "")
            //{
            //    exthe2 = " and " + exthe2;
            //}
            //and  STR_ZFBDate.Cadedate Between '2014-06-12  00:00:00.000' and '2014-06-12 23:59:59.000'
            ////

            //取ERP的条
            if (TxtCade.Text.ToString() != "")
            {
                if (erpstr != "")
                {
                    erpstr += " and ";
                }
                erpstr = erpstr + " b.OrderCade like '%" + TxtCade.Text.ToString() + "%'";
            }
            if (this.CmdShop.Text.ToString() != "")
            {
                if (erpstr != "")
                {
                    erpstr += " and ";
                }
                erpstr = erpstr + " ShopName='" + CmdShop.Text.ToString() + "'";
            }
            if (this.DTPOrderDate.Value.ToString() != "")
            {
                if (erpstr != "")
                {
                    erpstr += " and ";
                }
                erpstr += " b.orderdate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + "' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + "'"; ;

            }
            //取支付宝的条
            if (TxtCade.Text.ToString() != "")
            {
                if (ZFBstr != "")
                {
                    ZFBstr += " and ";
                }
                ZFBstr = ZFBstr + " b.OrderCade like '%" + TxtCade.Text.ToString() + "%'";
            }
            if (this.CmdShop.SelectedValue.ToString() != "")
            {
                if (ZFBstr != "")
                {
                    ZFBstr += " and ";
                }
                ZFBstr = ZFBstr + " ShopID='" + CmdShop.SelectedValue.ToString() + "'";
            }
            if (this.DTPOrderDate.Value.ToString() != "")
            {
                if (ZFBstr != "")
                {
                    ZFBstr += " and ";
                }
                ZFBstr += " b.orderdate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + "' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + "'";
            }



            ///
            if (erpstr != "")
            {
                erpstr = " and " + erpstr;
            }
            if (ZFBstr != "")
            {
                ZFBstr = " and " + ZFBstr;
            }
            if (strsql != "")
            {
                strsql = " where " + strsql;

            }

            string all_ = "select shopname,Str_ErpDate.ordercade,Str_ErpDate.orderdate,isnull(b.sumMoney,0) as bsumMoney,isnull(Str_ErpDate.summoney,0) as erpsummoney,case when isnull(b.sumMoney,0)-isnull(Str_ErpDate.summoney,0) between -50 and 0 then isnull(b.sumMoney,0)-isnull(Str_ErpDate.summoney,0) else 0 end as moneys," +
                        "isnull(returnMoney,0) returnMoney,isnull(b.sumMoney,0)-isnull(Str_ErpDate.summoney,0)-isnull(returnMoney,0)-case when isnull(b.sumMoney,0)-isnull(Str_ErpDate.summoney,0) between -50 and 0 then isnull(b.sumMoney,0)-isnull(Str_ErpDate.summoney,0) else 0 end as Rteurns,'' as Reason from (" +
                        "select isnull(Str_ErpDate.ordercade,'') ordercade,Str_ErpDate.orderDate,sum(STR_ZFBDate.sumMoney) as sumMoney,sum(STR_ZFBDate.returnMoney) returnMoney from STR_ZFBDate " +
                        "left join Str_erporder on Str_erporder.ordercades= STR_ZFBDate.orderCade and  Str_erporder.orderDAte= STR_ZFBDate.orderDate " +
                        "left join Str_ErpDate on  Str_erporder.ordercade= Str_ErpDate.orderCade and Str_erporder.orderDate= Str_ErpDate.orderDate " + strwther + " group by Str_ErpDate.ordercade,Str_ErpDate.orderDate) b " +
                        "left join Str_ErpDate on Str_ErpDate.ordercade =b.ordercade and Str_ErpDate.orderDate =b.orderDate" + strsql;
            string erp = "select distinct shopname,b.ordercade,b.orderdate,0 as bsummoney,b.summoney as erpsummoney,0-isnull(b.summoney,0) as moneys,0 as returnMoney, " +
                        "0-isnull(b.summoney,0)-0 as Rteurns,'' as Reason  from Str_ErpDate b " +
                        " where not exists(select * from STR_ZFBDate "+
                        "left join Str_erporder on Str_erporder.ordercades= STR_ZFBDate.orderCade and  Str_erporder.orderDAte= STR_ZFBDate.orderDate "+
                        "left join Str_ErpDate on Str_ErpDate.ordercade =Str_erporder.ordercade and Str_ErpDate.orderDate =Str_erporder.orderDate " +
                        "where b.ordercade= Str_ErpDate.orderCade and STR_ZFBDate.orderDate= Str_ErpDate.orderDate " + exthe + ")" + erpstr;

            string zfb = "select distinct shopname,b.ordercade,b.orderdate,summoney as bsummoney,0 as erpsummoney,isnull(b.summoney,0) as moneys,returnMoney, " +
                            "isnull(b.summoney,0)-0-isnull(returnMoney,0) as Rteurns,'' as Reason  from STR_ZFBDate b left join STR_Shop on shopID=STR_Shop.id where not exists(select * from Str_erporder where " +
                            "Str_erporder.ordercades= b.orderCade and Str_erporder.orderDate= b.orderDate " + exthe + ")" + ZFBstr;
            if (RBall.Checked == true)
            {
                strwhere = all_ +" order by shopname";
            }
            else if (RBerp.Checked == true)
            {
                strwhere =erp;
            }
            else if (this.RBzfb.Checked == true)
            {
                strwhere = zfb;
            }
            else if (this.RBALLcADE.Checked == true)
            {
                strwhere = all_+" union all "+erp+" union all " +zfb + " order by shopname";
            }
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
                    bsumMoney = bsumMoney + decimal.Parse(ds.Tables[0].Rows[k][3].ToString());
                    erpsummoney = erpsummoney + decimal.Parse(ds.Tables[0].Rows[k][4].ToString());
                    moneys = moneys + decimal.Parse(ds.Tables[0].Rows[k][5].ToString());
                    returnMoney = returnMoney + decimal.Parse(ds.Tables[0].Rows[k][6].ToString());
                    Rteurns = Rteurns + decimal.Parse(ds.Tables[0].Rows[k][7].ToString());

                }
                row2[0] = "合计";
                row2[1] = "";
                row2[2] = "2999-12-31";
                row2[3] = bsumMoney.ToString();
                row2[4] = erpsummoney.ToString();
                row2[5] = moneys.ToString();
                row2[6] = returnMoney.ToString();
                row2[7] = Rteurns.ToString();
                ds.Tables[0].Rows.Add(row2);
            }
            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["shopname"].HeaderText = "店铺";
            WPHbROWDGV.Columns["shopname"].ReadOnly = true;
            WPHbROWDGV.Columns["ordercade"].HeaderText = "单据";
            WPHbROWDGV.Columns["ordercade"].ReadOnly = true;
            WPHbROWDGV.Columns["orderDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["orderDAte"].ReadOnly = true;
            WPHbROWDGV.Columns["erpsummoney"].HeaderText = "ERP总金额";
            WPHbROWDGV.Columns["erpsummoney"].ReadOnly = true;
            WPHbROWDGV.Columns["moneys"].HeaderText = "积分";
            WPHbROWDGV.Columns["moneys"].ReadOnly = false;
            WPHbROWDGV.Columns["bsumMoney"].HeaderText = "支付宝金额";
            WPHbROWDGV.Columns["bsumMoney"].ReadOnly = true;
            WPHbROWDGV.Columns["returnMoney"].HeaderText = "退款金额";
            WPHbROWDGV.Columns["returnMoney"].ReadOnly = true;
            WPHbROWDGV.Columns["Rteurns"].HeaderText = " 异常差额";
            WPHbROWDGV.Columns["Rteurns"].ReadOnly = true;
            WPHbROWDGV.Columns["Reason"].HeaderText = "异常原因";
            WPHbROWDGV.Columns["Reason"].ReadOnly = false;
        }

        private void WPHbROWDGV_SelectionChanged(object sender, EventArgs e)
        {

            //WPHbROWDGV.Rows[1].Cells["Rteurns"].Value = Convert.ToInt32(WPHbROWDGV.Rows[1].Cells["RtbsumMoneyeurns"].Value.ToString()) - Convert.ToInt32(WPHbROWDGV.Rows[1].Cells["erpsummoney"].Value.ToString()) - Convert.ToInt32(WPHbROWDGV.Rows[1].Cells["returnMoney"].Value.ToString());
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
                if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_CashReconciliation where " + sqlselect, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    return;
                }
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
                        //strsql += "insert into STR_CashReconciliation (SHOPNAME,ORDERCade,OrderDate,BsumMoney,ErpSumMoney,Moneys,ReturnMoeny,RteurnS,Reason,username) values ('"
                        //  + WPHbROWDGV.Rows[i].Cells["shopname"].Value.ToString() + "','"
                        //  + WPHbROWDGV.Rows[i].Cells["ORDERCade"].Value.ToString() + "','"
                        //  + WPHbROWDGV.Rows[i].Cells["OrderDate"].Value.ToString() + "','"
                        //  + WPHbROWDGV.Rows[i].Cells["BsumMoney"].Value.ToString() + "','"
                        //  + WPHbROWDGV.Rows[i].Cells["ErpSumMoney"].Value.ToString() + "','"
                        //  + WPHbROWDGV.Rows[i].Cells["Moneys"].Value.ToString() + "','"
                        //  + WPHbROWDGV.Rows[i].Cells["ReturnMoeny"].Value.ToString() + "','"
                        //  + WPHbROWDGV.Rows[i].Cells["RteurnS"].Value.ToString() + "','"
                        //  + WPHbROWDGV.Rows[i].Cells["Reason"].Value.ToString() + "','"
                        //  + frmlogin.userID + "');";
                        
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

        private void WPHbROWDGV_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            //try
            //{
            //    int n = WPHbROWDGV.CurrentCell.RowIndex;
            //    int sum = int.Parse(WPHbROWDGV.Rows[n].Cells["BsumMoney"].Value.ToString());
            //    int esum = int.Parse(WPHbROWDGV.Rows[n].Cells["ErpSumMoney"].Value.ToString());
            //    int ss = int.Parse(WPHbROWDGV.Rows[n].Cells["Moneys"].Value.ToString());
            //    string s = (sum - esum-ss).ToString();
            //    WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["RteurnS"].Value = s;
            //}
            //catch
            //{
            //    int n = WPHbROWDGV.CurrentCell.RowIndex;
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
        //ProudctDGV.Rows[i].Cells["barCodeNomber"].Value = (Convert.ToInt32(ProudctDGV.Rows[i].Cells["barCodeNomber"].Value.ToString()) + 1).ToString();
    }
}
