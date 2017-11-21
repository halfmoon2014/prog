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
    public partial class SingleSupplements : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        DataSet ds = new DataSet();
        public SingleSupplements()
        {
            InitializeComponent();
        }

        private void BtnDate_Click(object sender, EventArgs e)
        {
            if (DTPStart.Value.ToString("yyyy-MM-dd") != DTPStop.Value.ToString("yyyy-MM-dd"))
            {
                string STR = "";
                string str1="";
                string str2 = "";
                for (int i = 0; i < TXTItem.Lines.Length; i++)
                {
                    if (STR != "")
                    {
                        STR += ",";
                    }
                    STR += "'" + this.TXTItem.Lines[i] + "'";
                }

                //if (STR != "")
                //{
                //    str1 = " and CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END IN (" + STR + ")";
                //    str2 = " where CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END IN (" + STR + ")";
                //}
                TimeSpan ts = DateTime.Parse(DTPStop.Value.ToString("yyyy-MM-dd")).Subtract(DateTime.Parse(DTPStart.Value.ToString("yyyy-MM-dd")));
                ds = new DataSet();
                DataTable DT = new DataTable();
                SqlConnection objConn = sqlcon.getcon("Wei");
                SqlConnection Conn = sqlcon.getcon("");

                string table = "select cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade BarCode, item_no,M_name,Co_Code,S_color,m_SizeDetails.Name SdName " +
                    " from M_product left join M_productSub on M_productSub.pid=M_product.id "+
                    "left join M_productSize on M_product.id=M_productSize.pid left join m_SizeDetails on m_SizeDetails.sizeid=M_productSize.sizeid where item_no in(" + STR +
                    ") order by cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade";
                SqlDataAdapter myData = new SqlDataAdapter(table, Conn);
                Conn.Open();
                myData.Fill(DT);//填充数据
                Conn.Close();

                DT.Columns.Add(new DataColumn("SalesRate", typeof(System.Int32)));
                DT.Columns.Add(new DataColumn("JDFQty", typeof(System.Int32)));
                DT.Columns.Add(new DataColumn("Wqty", typeof(System.Int32)));
                DT.Columns.Add(new DataColumn("TTQty", typeof(System.Int32)));
                DT.Columns.Add(new DataColumn("hdQty", typeof(System.Int32)));
                DT.Columns.Add(new DataColumn("yjQty", typeof(System.String)));
                DT.Columns.Add(new DataColumn("BhQty", typeof(System.String)));
                DT.Columns.Add(new DataColumn("XbHQty", typeof(System.String)));
                DT.Columns.Add(new DataColumn("TTXbHQty", typeof(System.String)));

                string strjd = "select t_ICItem.fBarCode item,sum(fqty)fqty from T_CC_Inventory left join t_ICItem on t_ICItem.fitemID=T_CC_Inventory.fitemID " +
                     "where CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END IN (" + STR + ") and fstockID " +
                    "in ('226','228') group by t_ICItem.fBarCode,Fname";
                SqlDataAdapter JDData = new SqlDataAdapter(strjd, objConn);
                objConn.Open();
                JDData.Fill(ds, "JDData");//填充数据
                objConn.Close();
               
                DataTable jddt = ds.Tables["JDData"];

                foreach (DataRow newrow in DT.Rows)
                {
                    foreach (DataRow dr2 in jddt.Rows)
                    {
                        if (newrow["BarCode"].ToString() == dr2["item"].ToString())
                        {
                            newrow["JDFQty"] = dr2["fqty"];
                        }
                        if ((newrow["JDFQty"]).ToString() == "0")
                        {
                            newrow["JDFQty"] = DBNull.Value;
                        }
                    }
                }

                strjd = "select t_ICItem.fBarCode as item,sum((case when CGqty<Fqty then CGqty else CGqty-isnull(Fqty,0)end)) as Qty from (select fid,fitemID,sum(FQty) as CGqty "+
                    "from t_cg_orderentry group by fitemID,fid) tempCCG left join t_cg_order on tempCCG.fid=t_cg_order.fid "+
                     "left join (select fitemID,sum(fqty) as Fqty from T_CC_StockBillentry where exists(select * from t_cg_order where ForderBillNO=t_cg_order.FbillNO and  fstatus=1 ) group by fitemID) as temprk on tempCCG.fitemID=temprk.fitemID "+
                    "left join t_ICItem on t_ICItem.fitemID=tempCCG.fitemID  where fstatus=1 and CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END IN ("+STR+") group by t_ICItem.fBarCode,Fname";
                SqlDataAdapter WData = new SqlDataAdapter(strjd, objConn);
                objConn.Open();
                WData.Fill(ds, "WData");//填充数据
                objConn.Close();
                jddt = ds.Tables["WData"];

                foreach (DataRow newrow in DT.Rows)
                {
                    foreach (DataRow dr2 in jddt.Rows)
                    {
                        if (newrow["BarCode"].ToString() == dr2["item"].ToString())
                        {
                            newrow["Wqty"] = dr2["Qty"];
                        }
                        if ((newrow["Wqty"]).ToString() == "0")
                        {
                            newrow["Wqty"] = DBNull.Value;
                        }
                    }
                }

                strjd = "select BarCode,sum(qty) Qty from Str_TianTuStorage where CASE WHEN len(BarCode)>3 THEN SUBSTRING(BarCode,1,len(BarCode)-3) ELSE '' END in (" + STR + ")  group by BarCode";
                SqlDataAdapter TTData = new SqlDataAdapter(strjd, Conn);
                Conn.Open();
                TTData.Fill(ds, "TTData");//填充数据
                Conn.Close();
                jddt = ds.Tables["TTData"];

                foreach (DataRow newrow in DT.Rows)
                {
                    foreach (DataRow dr2 in jddt.Rows)
                    {
                        if (newrow["BarCode"].ToString() == dr2["BarCode"].ToString())
                        {
                            newrow["TTQty"] = dr2["Qty"];
                        }
                        if ((newrow["TTQty"]).ToString() == "0")
                        {
                            newrow["TTQty"] = DBNull.Value;
                        }
                    }
                }

                strjd = "select t_ICItem.fBarCode item,round(sum(T_CC_StockBillEntry.fQty),0) Qty from T_CC_StockBillEntry left join t_ICItem on t_ICItem.fitemid=T_CC_StockBillEntry.FitemID "+
                    "where exists(select * from T_CC_StockBill where T_CC_StockBillEntry.fid=T_CC_StockBill.fid and  FBillNo like 'XSD%' and Fdate Between '" 
                    + DTPStart.Value.ToString("yyyy-MM-dd") +"' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "')  and CASE WHEN len(t_ICItem.fBarCode)>3 THEN " +
                    "SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END IN (" + STR + ") group by t_ICItem.fBarCode,FName";
                SqlDataAdapter xsData = new SqlDataAdapter(strjd, objConn);
                objConn.Open();
                xsData.Fill(ds, "xsData");//填充数据
                objConn.Close();

                //jddt = ds.Tables["xsData"];
                strjd = "select cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade BarCode, " +
                    "round((sum(qty)/temp.cmatching*SS_ColourWithCade.matching)/temp1.cmatching*SS_SizeWithCade.matching,0) Qty from SS_ActivityDetailList "+
                    "left join SS_ActivityList  on SS_ActivityList.id=RID "+
                    "left join dbo.m_product on m_product.id=SS_ActivityDetailList.pid "+
                    "left join m_productSub on m_productSub.PID=m_product.id "+
                    "left join m_productSize on m_productSize.PID=m_product.id "+
                    "left join dbo.m_SizeDetails on m_SizeDetails.sizeid=m_productSize.sizeid "+
                    "left join SS_ColourWithCade on SS_ColourWithCade.pid=m_product.id and SS_ColourWithCade.colourid=m_productSub.id "+
                    "left join (select PID,sum(matching) as Cmatching from SS_ColourWithCade group by PId) as temp on temp.pid=m_product.id "+
                    "left join SS_SizeWithCade on SS_SizeWithCade.pid=m_product.id and SS_SizeWithCade.SDID=m_SizeDetails.id "+
                    "left join (select PID,sum(matching) as Cmatching from SS_SizeWithCade group by PId) as temp1 on temp1.pid=m_product.id "+
                    "where cadedate Between '"+ DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + 
                    "' and type=1 and (listtype=2 or listtype=1) and item_no in (" + STR + ") " +
                    "group by item_no,CO_CODE,m_SizeDetails.Cade,SS_ColourWithCade.matching,temp.cmatching,temp1.cmatching,SS_SizeWithCade.matching ";
                SqlDataAdapter HDData = new SqlDataAdapter(strjd, Conn);
                Conn.Open();
                HDData.Fill(ds, "HDData");//填充数据
                Conn.Close();
                jddt = ds.Tables["HDData"];

                foreach (DataRow newrow in DT.Rows)
                {
                    foreach (DataRow dr2 in jddt.Rows)
                    {
                        if (newrow["BarCode"].ToString() == dr2["BarCode"].ToString())
                        {
                            newrow["HDQty"] = dr2["Qty"];
                        }
                        if ((newrow["HDQty"]).ToString() == "0")
                        {
                            newrow["HDQty"] = DBNull.Value;
                        }
                    }
                }

                strjd = "select cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade barcode,sum(qty) Qty "+
                    "from SS_ActivityDetailList left join SS_ActivityList  on SS_ActivityList.id=RID "+
                    "left join dbo.m_product on m_product.id=SS_ActivityDetailList.pid left join m_productSub on m_productSub.ID=colourID "+
                    "left join dbo.m_SizeDetails on m_SizeDetails.id=Sdid where cadedate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") +
                    "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "' and type=2 and (listtype=2 or listtype=1) and item_no in (" + STR + ") " +
                    "group by item_no,Sdid,colourID,CO_CODE,m_SizeDetails.Cade";
                SqlDataAdapter xsData2 = new SqlDataAdapter(strjd, Conn);
                Conn.Open();
                xsData2.Fill(ds, "xsData1");//填充数据
                Conn.Close();
                jddt = ds.Tables["xsData1"];

                foreach (DataRow newrow in ds.Tables["xsData"].Rows)
                {
                    foreach (DataRow dr2 in jddt.Rows)
                    {
                        if (newrow["item"].ToString() == dr2["BarCode"].ToString())
                        {
                            newrow["Qty"] = (Convert.ToInt32(newrow["Qty"]) - Convert.ToInt32(dr2["Qty"]));
                        }
                        if ((newrow["Qty"]).ToString() == "0")
                        {
                            newrow["Qty"] = DBNull.Value;
                        }
                    }
                }
                
                jddt = ds.Tables["xsData"];
                foreach (DataRow newrow in DT.Rows)
                {
                    foreach (DataRow dr2 in jddt.Rows)
                    {
                        if (newrow["BarCode"].ToString() == dr2["item"].ToString())
                        {
                            newrow["SalesRate"] = Math.Round(Convert.ToDouble(dr2["Qty"])/ts.Days,0,MidpointRounding.AwayFromZero);
                            newrow["BhQty"] = Math.Round(Convert.ToDouble(dr2["Qty"]) / ts.Days, 0, MidpointRounding.AwayFromZero) * Convert.ToDouble(TxtZzDay.Text.ToString());
                            newrow["yjQty"] = Math.Round(Convert.ToDouble(dr2["Qty"]) / ts.Days, 0, MidpointRounding.AwayFromZero) * Convert.ToDouble(TxtyjDay.Text.ToString());
                        }
                    }
                }
                foreach (DataRow newrow in DT.Rows)
                {
                    if ((newrow["SalesRate"]).ToString() == "0")
                    {
                        newrow["SalesRate"] = DBNull.Value;
                    }
                    newrow["XbHQty"] = Convert.ToInt32(newrow["BhQty"] == DBNull.Value ? "0" : newrow["BhQty"]) + Convert.ToInt32(newrow["hdQty"] == DBNull.Value ? "0" : newrow["hdQty"]) -
                        Convert.ToInt32(newrow["JDFQty"] == DBNull.Value ? "0" : newrow["JDFQty"]) - Convert.ToInt32(newrow["Wqty"] == DBNull.Value ? "0" : newrow["Wqty"]);
                    if (newrow["XbHQty"] == DBNull.Value)
                    { }
                    else
                    {
                        if ((newrow["XbHQty"]).ToString().IndexOf("-") > -1)
                        {
                            newrow["XbHQty"] = DBNull.Value;
                        }
                        if ((newrow["XbHQty"]).ToString() == "0")
                        {
                            newrow["XbHQty"] = DBNull.Value;
                        }
                    }
                    newrow["TTXbHQty"] = Convert.ToInt32(newrow["BhQty"] == DBNull.Value ? "0" : newrow["BhQty"]) + Convert.ToInt32(newrow["hdQty"] == DBNull.Value ? "0" : newrow["hdQty"]) -
                        Convert.ToInt32(newrow["JDFQty"] == DBNull.Value ? "0" : newrow["JDFQty"]) - Convert.ToInt32(newrow["Wqty"] == DBNull.Value ? "0" : newrow["Wqty"]) - Convert.ToInt32(newrow["TTQty"] == DBNull.Value ? "0" : newrow["TTQty"]);
                    if (newrow["TTXbHQty"] == DBNull.Value)
                    { }
                    else
                    {
                        if ((newrow["TTXbHQty"]).ToString().IndexOf("-") > -1)
                        {
                            newrow["TTXbHQty"] = DBNull.Value;
                        }
                        if ((newrow["TTXbHQty"]).ToString()=="0")
                        {
                            newrow["TTXbHQty"] = DBNull.Value;
                        }
                    }
                }

                //string strsql = " select temp3.item,temp3.Fname,cast(isnull((temp.Qty-temp5.Qty),0) as decimal(10,0)) xsqty,cast(temp3.fqty as decimal(20,0)) fqty,cast(isnull(temp4.Qty,0) as  decimal(10,0)) cgrk " +
                //        ",isnull(Temp7.Qty,0) as TTQty,isnull(Temp6.Qty,0) as HDQty,Cast(isnull((temp.Qty-temp5.Qty),0)*" + TxtyjDay.Text.ToString() + " as decimal(10,0)) yjqty,Cast(isnull((temp.Qty-temp5.Qty),0)*" + TxtZzDay.Text.ToString() +
                //        " as decimal(10,0)) zzqty,cast((isnull(temp3.fqty,0)+isnull(temp4.Qty,0)+isnull(Temp7.Qty,0)-isnull(Temp6.Qty,0)-isnull((temp.Qty-temp5.Qty),0)*" + TxtyjDay.Text.ToString() + 
                //        "-isnull((temp.Qty-temp5.Qty),0)*" + TxtZzDay.Text.ToString() +
                //        ") as decimal(20,0)) syQty from (select CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END item,FName,round(sum(T_CC_StockBillEntry.fQty)/" + ts.Days + ",0) Qty from T_CC_StockBillEntry " +
                //        "left join t_ICItem on t_ICItem.fitemid=T_CC_StockBillEntry.FitemID where " +
                //        "exists(select * from T_CC_StockBill where T_CC_StockBillEntry.fid=T_CC_StockBill.fid " +
                //        "and  FBillNo like 'XSD%' and fscstockID not in ('227','231') and Fdate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") +
                //        "') " + str1 + " group by CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END,FName) temp " +
                //        "Right join (select CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END item,t_ICItem.Fname,sum(fqty)fqty from T_CC_Inventory " +
                //        "left join t_ICItem on t_ICItem.fitemID=T_CC_Inventory.fitemID " + STR +
                //        " and fstockID in ('226','228') group by CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END,Fname ) temp3 on  temp3.item=temp.item " +
                //        "left join (select CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END item,t_ICItem.Fname,sum((case when CGqty<Fqty then CGqty else CGqty-isnull(Fqty,0)end)) as Qty " +
                //        "from (select fitemID,sum(FQty) as CGqty from t_cg_orderentry group by fitemID) tempCCG " +
                //        "left join (select fitemID,sum(fqty) as Fqty from T_CC_StockBillentry where " +
                //        "exists(select * from t_cg_order where ForderBillNO=t_cg_order.FbillNO) " +
                //        "group by fitemID) as temprk on tempCCG.fitemID=temprk.fitemID " +
                //        "left join t_ICItem on t_ICItem.fitemID=tempCCG.fitemID " + STR + " group by CASE WHEN len(t_ICItem.fBarCode)>3 THEN SUBSTRING(t_ICItem.fBarCode,1,len(t_ICItem.fBarCode)-3) ELSE '' END,Fname)temp4 on temp4.item=temp.item " +
                //        "left join (select item_no,sum(qty) Qty from OPENROWSET('SQLOLEDB', 'server=192.168.0.177,1488;uid=sa;pwd=mt123','SELECT * FROM [M_sentu].dbo.SS_ActivityList " +
                //        "left join [M_sentu].dbo.SS_ActivityDetailList  on SS_ActivityList.id=RID and type=2" +
                //        "left join [M_sentu].dbo.m_product on m_product.id=pid') where cadedate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "' group by item_no) temp5 on temp5.item_no=temp.item " +
                //        "left join (select item_no,sum(qty)Qty from OPENROWSET('SQLOLEDB', 'server=192.168.0.177,1488;uid=sa;pwd=mt123','SELECT * FROM [M_sentu].dbo.SS_ActivityList " +
                //        "left join [M_sentu].dbo.SS_ActivityDetailList  on SS_ActivityList.id=RID and type=1" +
                //        "left join [M_sentu].dbo.m_product on m_product.id=pid') where cadedate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "' group by item_no) temp6 on temp6.item_no=temp.item " +
                //        "left join (select CASE WHEN len(BarCode)>3 THEN SUBSTRING(BarCode,1,len(BarCode)-3) ELSE '' END item,sum(qty) Qty from OPENROWSET('SQLOLEDB', 'server=192.168.0.177,1488;uid=sa;pwd=mt123','SELECT * FROM [M_sentu].dbo.Str_TianTuStorage') group by CASE WHEN len(BarCode)>3 THEN SUBSTRING(BarCode,1,len(BarCode)-3) ELSE '' END) temp7 on temp7.item=temp.item ";
                //Co_Code,S_color
                DataDGV2.DataSource = DT;
                DataDGV2.Columns["M_name"].HeaderText = "品名";
                DataDGV2.Columns["M_name"].ReadOnly = true;
                DataDGV2.Columns["item_no"].HeaderText = "款号";
                DataDGV2.Columns["item_no"].Width =55;
                DataDGV2.Columns["item_no"].ReadOnly = true;
                DataDGV2.Columns["Co_Code"].HeaderText = "色号";
                DataDGV2.Columns["Co_Code"].Width = 55;
                DataDGV2.Columns["Co_Code"].ReadOnly = true;
                DataDGV2.Columns["S_color"].HeaderText = "颜色";
                DataDGV2.Columns["S_color"].ReadOnly = true;
                DataDGV2.Columns["SdName"].HeaderText = "尺码";
                DataDGV2.Columns["SdName"].Width = 55;
                DataDGV2.Columns["SdName"].ReadOnly = true;
                DataDGV2.Columns["BarCode"].HeaderText = "条码";
                DataDGV2.Columns["BarCode"].Width = 60;
                DataDGV2.Columns["BarCode"].ReadOnly = true;
                DataDGV2.Columns["SalesRate"].HeaderText = "销售速度";
                DataDGV2.Columns["SalesRate"].Width = 80;
                DataDGV2.Columns["SalesRate"].ReadOnly = false;
                DataDGV2.Columns["JDFQty"].HeaderText = "金蝶库存";
                DataDGV2.Columns["JDFQty"].Width = 80;
                DataDGV2.Columns["JDFQty"].ReadOnly = true;
                DataDGV2.Columns["TTQty"].HeaderText = "天图库存";
                DataDGV2.Columns["TTQty"].Width = 80;
                DataDGV2.Columns["TTQty"].ReadOnly = true;
                DataDGV2.Columns["hdQty"].HeaderText = "活动预计";
                DataDGV2.Columns["hdQty"].Width = 80;
                DataDGV2.Columns["hdQty"].ReadOnly = true;
                DataDGV2.Columns["XbHQty"].HeaderText = "须下单量";
                DataDGV2.Columns["XbHQty"].Width = 80;
                DataDGV2.Columns["XbHQty"].ReadOnly = true;
                DataDGV2.Columns["TTXbHQty"].HeaderText = "含天图须单量";
                DataDGV2.Columns["TTXbHQty"].Width = 80;
                DataDGV2.Columns["TTXbHQty"].ReadOnly = true;
                DataDGV2.Columns["Wqty"].HeaderText = "未入库";
                DataDGV2.Columns["Wqty"].Width = 70;
                DataDGV2.Columns["Wqty"].ReadOnly = true;
                DataDGV2.Columns["yjQty"].HeaderText = "预警";
                DataDGV2.Columns["yjQty"].Width = 60;
                DataDGV2.Columns["yjQty"].ReadOnly = true;
                DataDGV2.Columns["BhQty"].HeaderText = "备货量";
                DataDGV2.Columns["BhQty"].Width = 70;
                DataDGV2.Columns["BhQty"].ReadOnly = true;
            }
            else
            {
                MessageBox.Show("起始日期与终止日期不能相等");
            }
        }

        private void BtnExcel2_Click(object sender, EventArgs e)
        {
            if (DataDGV2.Rows.Count > 0)
            {
                //建立Excel对象    
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                //生成字段名称    
                for (int i = 0; i < DataDGV2.ColumnCount; i++)
                {
                    excel.Cells[1, i + 1] = DataDGV2.Columns[i].HeaderText;

                }    //填充数据    
                for (int i = 0; i < DataDGV2.RowCount; i++)
                {
                    for (int j = 0; j < DataDGV2.ColumnCount; j++)
                    {
                        if (DataDGV2[j, i].Value == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "" + DataDGV2[i, j].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = DataDGV2[j, i].Value.ToString();
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

        private void SingleSupplements_Load(object sender, EventArgs e)
        {
            DTPStart.Text = (DateTime.Now.AddDays(-11)).ToString("yyyy-MM-dd");
            this.DTPStop.Text = (DateTime.Now.AddDays(-1)).ToString("yyyy-MM-dd");
        }

        private void DataDGV2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.DataDGV2.Rows.Count != 0)
            {
                for (int i = 1; i < this.DataDGV2.Rows.Count; )
                {
                    this.DataDGV2.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                    i += 2;
                }
            } 
        }

        private void DataDGV2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataDGV2.Rows[e.RowIndex].Cells["BhQty"].Value = Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["SalesRate"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["SalesRate"].Value.ToString()) * Convert.ToDouble(TxtZzDay.Text.ToString());
            DataDGV2.Rows[e.RowIndex].Cells["yjQty"].Value = Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["SalesRate"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["SalesRate"].Value.ToString()) * Convert.ToDouble(TxtyjDay.Text.ToString());
            DataDGV2.Rows[e.RowIndex].Cells["XbHQty"].Value = Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["SalesRate"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["SalesRate"].Value.ToString()) * Convert.ToDouble(TxtZzDay.Text.ToString()) +
                Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["hdQty"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["hdQty"].Value.ToString()) -
                Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["JDFQty"].Value.ToString() == "" ? "0" :DataDGV2.Rows[e.RowIndex].Cells["JDFQty"].Value.ToString() ) -
                Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["Wqty"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["Wqty"].Value.ToString());
            DataDGV2.Rows[e.RowIndex].Cells["TTXbHQty"].Value = Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["SalesRate"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["SalesRate"].Value.ToString()) * Convert.ToDouble(TxtZzDay.Text.ToString()) +
                Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["hdQty"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["hdQty"].Value.ToString()) -
                Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["JDFQty"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["JDFQty"].Value.ToString()) -
                Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["Wqty"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["Wqty"].Value.ToString()) -
                Convert.ToDouble(DataDGV2.Rows[e.RowIndex].Cells["TTQty"].Value.ToString() == "" ? "0" : DataDGV2.Rows[e.RowIndex].Cells["TTQty"].Value.ToString());
            DataDGV2.Rows[e.RowIndex].Cells["TTXbHQty"].Value =Convert.ToInt32(DataDGV2.Rows[e.RowIndex].Cells["TTXbHQty"].Value.ToString()) <= 0 ? "" : DataDGV2.Rows[e.RowIndex].Cells["TTXbHQty"].Value.ToString();
            DataDGV2.Rows[e.RowIndex].Cells["XbHQty"].Value = Convert.ToInt32(DataDGV2.Rows[e.RowIndex].Cells["XbHQty"].Value.ToString()) <= 0 ? "" : DataDGV2.Rows[e.RowIndex].Cells["XbHQty"].Value.ToString();
            DataDGV2.Rows[e.RowIndex].Cells["BhQty"].Value = Convert.ToInt32(DataDGV2.Rows[e.RowIndex].Cells["BhQty"].Value.ToString()) <= 0 ? "" : DataDGV2.Rows[e.RowIndex].Cells["BhQty"].Value.ToString();
            DataDGV2.Rows[e.RowIndex].Cells["yjQty"].Value = Convert.ToInt32(DataDGV2.Rows[e.RowIndex].Cells["yjQty"].Value.ToString()) <= 0 ? "" : DataDGV2.Rows[e.RowIndex].Cells["yjQty"].Value.ToString();
        }
    }
}
