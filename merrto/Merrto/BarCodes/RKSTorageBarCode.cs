using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.BarCodes
{
    public partial class RKSTorageBarCode : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.SelectDate sd = new baseclass.SelectDate();
        public RKSTorageBarCode()
        {
            InitializeComponent();
        }

        private void RKSTorageBarCode_Load(object sender, EventArgs e)
        {
            DataTable dt = sd.Factory();
            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            CboFile.DataSource = dt;
            CboFile.ValueMember = "id";
            CboFile.DisplayMember = "title";
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            string str="";
            try
            {
                if (this.CboFile.SelectedValue.ToString() != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str = str + " BR_RStorageList.FID='" + CboFile.SelectedValue.ToString() + "'";
                }
                if (this.DTPStart.Value.ToString() != "" && DTPStop.Value.ToString("yyyy-MM-dd") != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str += " CadeDATE Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "'";
                }
                if (this.TXtBill.Text.ToString() != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str = str + " BR_RStorageList.orderCade like '%" + TXtBill.Text.ToString().Trim() + "%'";
                }
                if (this.TxtItem.Text.ToString() != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str = str + " cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade like '%" + TxtItem.Text.ToString().Trim() + "%'";
                }
                if (this.TxtCade.Text.ToString() != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str = str + "BR_RStorageList.cade like '%" + TxtCade.Text.ToString().Trim() + "%'";
                }
                
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str = str + "BR_RStorageList.Listtype >0 ";
                

                if (str != "")
                {
                    str = " where " + str;
                }
                string strsql = "select BR_RStorageList.cade,BR_RStorageList.cadeDate,BR_RStorageList.OrderCade,Title,StockName,cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade barcode,item_no,m_productsub.co_code,m_productsub.s_color,m_SizeDetails.cade sdcade,m_SizeDetails.name sdname," +
                                "temp2.qty,isnull(temp.qty,0) PTSRQTY,isnull(temp1.qty,0) as PTSqtY,temp2.qty-isnull(temp.qty,0)-isnull(temp1.qty,0) syQty,price_tag,case when Listtype=1 then '编辑' when Listtype=2 then '审核' else '作废' end type " +
                                "from (select rid,pid,sdid,colourid,sum(qty) as qty from BR_RStroageDetailList  group by rid,pid,sdid,colourid)temp2 " +
                                "left join (select rid,pid,sdid,colourid,sum(qty) as qty from  BR_PassToStockReturn group by rid,pid,sdid,colourid) temp "+
                                "on temp.pid=temp2.pid and temp.SDID=temp2.SDID and temp.colourid=temp2.colourid and temp.RID=temp2.RID " +
                                "left join (select rid,pid,sdid,colourid,sum(qty) as qty from BR_PassToStock group by rid,pid,sdid,colourid) temp1 "+
                                "on temp1.pid=temp2.pid and temp1.SDID=temp2.SDID and temp1.colourid=temp2.colourid and temp1.RID=temp2.RID " +
                                "left join m_product on m_product.id=temp2.pid left join m_productsub on m_productsub.id=temp2.Colourid " +
                                "left join m_SizeDetails on m_SizeDetails.id=temp2.Sdid left join BR_RStorageList on BR_RStorageList.id=temp2.rid " +
                                "left join m_Factory on m_Factory.id=BR_RStorageList.fid left join M_Stock  on M_Stock.stockID=BR_RStorageList.stockID" + str + " order by BR_RStorageList.cade,cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade";

                SqlConnection conn = sqlcon.getcon("");
                DataSet ds = new DataSet();
                SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
                conn.Open();
                sqlDaper.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row2 = ds.Tables[0].NewRow();
                    decimal Qty = 0;
                    decimal PTSRQTY=0;
                    decimal PTSQTY=0;
                    decimal syQTY = 0;
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        Qty = Qty + decimal.Parse(ds.Tables[0].Rows[k][11].ToString());
                        PTSRQTY = PTSRQTY + decimal.Parse(ds.Tables[0].Rows[k][12].ToString());
                        PTSQTY = PTSQTY + decimal.Parse(ds.Tables[0].Rows[k][13].ToString());
                        syQTY = syQTY + decimal.Parse(ds.Tables[0].Rows[k][14].ToString());

                    }
                    row2[0] = "合计";
                    row2[11] = Qty.ToString();
                    row2[12] = PTSRQTY.ToString();
                    row2[13] = PTSQTY.ToString();
                    row2[14] = syQTY.ToString();
                    
                    ds.Tables[0].Rows.Add(row2);
                }
                WPHbROWDGV.DataSource = ds.Tables[0];
                WPHbROWDGV.Columns["BarCode"].HeaderText = "条型码";
                WPHbROWDGV.Columns["BarCode"].Width = 70;
                WPHbROWDGV.Columns["OrderCade"].Width = 60;
                WPHbROWDGV.Columns["OrderCade"].HeaderText = "单据";
                WPHbROWDGV.Columns["Cade"].HeaderText = "凭证号";
                WPHbROWDGV.Columns["Cade"].Width = 100;
                WPHbROWDGV.Columns["Cadedate"].HeaderText = "日期";
                WPHbROWDGV.Columns["Cadedate"].Width = 70;
                WPHbROWDGV.Columns["Title"].HeaderText = "供方";
                WPHbROWDGV.Columns["Title"].Width = 80;
                WPHbROWDGV.Columns["item_no"].HeaderText = "款号";
                WPHbROWDGV.Columns["item_no"].Width = 60;
                WPHbROWDGV.Columns["co_code"].HeaderText = "色号";
                WPHbROWDGV.Columns["co_code"].Width = 60;
                WPHbROWDGV.Columns["s_color"].HeaderText = "颜色";
                WPHbROWDGV.Columns["s_color"].Width = 80;
                WPHbROWDGV.Columns["sdCade"].HeaderText = "代码";
                WPHbROWDGV.Columns["sdCade"].Width = 60;
                WPHbROWDGV.Columns["sdName"].HeaderText = "尺码";
                WPHbROWDGV.Columns["sdName"].Width = 60;
                WPHbROWDGV.Columns["Qty"].HeaderText = "到货数量";
                WPHbROWDGV.Columns["Qty"].Width = 80;
                WPHbROWDGV.Columns["PTSRQTY"].HeaderText = "退货数量";
                WPHbROWDGV.Columns["PTSRQTY"].Width = 80;
                WPHbROWDGV.Columns["PTSQTY"].HeaderText = "入库数量";
                WPHbROWDGV.Columns["PTSQTY"].Width = 80;
                WPHbROWDGV.Columns["syQTY"].HeaderText = "剩余数量";
                WPHbROWDGV.Columns["syQTY"].Width = 80;
                WPHbROWDGV.Columns["StockName"].HeaderText = "仓库";
                WPHbROWDGV.Columns["StockName"].Width = 60;
                WPHbROWDGV.Columns["price_tag"].HeaderText = "吊牌价";
                WPHbROWDGV.Columns["price_tag"].Width = 70;
                WPHbROWDGV.Columns["Type"].HeaderText = "状态";
                WPHbROWDGV.Columns["Type"].Width = 60;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            if (e.RowIndex < WPHbROWDGV.Rows.Count)
            {
                DataGridViewRow dgrSingle = WPHbROWDGV.Rows[e.RowIndex];
                try
                {
                    if (dgrSingle.Cells["Cade"].Value.ToString().Contains("合计"))
                    {
                        dgrSingle.DefaultCellStyle.BackColor = Color.Goldenrod;
                    }
                    if (dgrSingle.Cells["Type"].Value.ToString().Contains("审核"))
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
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
