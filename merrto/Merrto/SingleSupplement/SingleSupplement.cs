using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Merrto.SingleSupplement
{
    public partial class SingleSupplement : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData ed = new baseclass.ExcelData();
        public SingleSupplement()
        {
            InitializeComponent();
        }
        //DataTable ExcelTable;
        DataSet ds;        //Excel的连接  
      
        OleDbConnection objConn;
        //DataTable dt;
        //OleDbDataAdapter myData;
        DataTable schemaTable;
        string tableName;
        string tableName1;
        string strSql;
        private void txtpaths_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "D://";

            fileDialog.Filter = "txt files (*.xls)|*.xls|All files (*.*)|*.*";

            fileDialog.FilterIndex = 1;

            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                this.txtpaths.Text = fileDialog.FileName;

            }
        }

        private void btnzcm_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (this.txtpaths.Text == "")
            {
                MessageBox.Show("Excel路径不能为空!", "提示", MessageBoxButtons.OK);
                return;
            }
            ds = new DataSet();
            objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.txtpaths.Text + ";" + "Extended Properties=\"Excel 8.0;IMEX=1;\"");
            objConn.Open();
            schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            DataSet ods = new DataSet();
            OleDbDataAdapter myData = new OleDbDataAdapter("select * from [" + schemaTable.Rows[0][2].ToString().Trim() + "]", objConn);
                     myData.Fill(ds, schemaTable.Rows[0][2].ToString().Trim());//填充数据
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            if (ds.Tables[schemaTable.Rows[0][2].ToString().Trim()].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!str4.Contains(ds.Tables[0].Rows[i]["货号"].ToString()))
                    //if (str4.IndexOf(ds.Tables[0].Rows[i]["货号"]) > -1)
                    {
                        if (str4 != "")
                        {
                            str4 += " or ";
                        }
                        str4 += "item_no='" + ds.Tables[0].Rows[i]["货号"] + "'";
                    }
                }
                for (int i = 1; i < ds.Tables[0].Columns.Count-1; i++)
                {
                    if (str1 != "")
                    {
                        str1 += " union all ";
                    }
                    if (str2 != "")
                    {
                        str2 += " union all ";

                    }
                    if (str3 != "")
                    {
                        str3 += " union all ";

                    }

                    str1 += "select 货号 as item_no,颜色 as s_color,'规格" + i.ToString() + "'as stor,'' as SDNAME,规格" + i.ToString() + " as NOs from [预销售$] ";
                    str2 += "select 货号 as item_no,颜色 as s_color,'规格" + i.ToString() + "'as stor,'' as SDNAME,规格" + i.ToString() + " as NOs from [聚划算$] ";
                    str3 += "select 货号 as item_no,颜色 as s_color,'规格" + i.ToString() + "'as stor,'' as SDNAME,0-round(规格" + i.ToString() + "*2/3,0) as NOs from [库存$] ";
                }
                OleDbDataAdapter myData1 = new OleDbDataAdapter(str1, objConn);
                OleDbDataAdapter myData2 = new OleDbDataAdapter(str2, objConn);
                OleDbDataAdapter myData3 = new OleDbDataAdapter(str3, objConn);
                myData1.Fill(ods, "预销售");//填充数据
                myData2.Fill(ods, "聚划算");//填充数据
                myData3.Fill(ods, "库存");//填充数据
            } 
            objConn.Close();
            conn.Open();
            str5 = "select item_no,'规格'+cast(m_SizeDetails.sort as varchar(5)) as stor,m_SizeDetails.name as sdname from M_product left join M_productSize on m_ProductSize.pid=M_product.id " +
                 "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid WHERE " + str4;

            str4 = "SELECT item_no,s_color,'规格'+cast(m_SizeDetails.sort as varchar(5)) as stor,M_SizeDetails.[NAME] AS SDNAME,round(round(("
                + Convert.ToInt32(TXTNOS.Text.ToString()) + "*Proportion)/sums,0)/12,0)*12 as NOs FROM m_PRODUCT " +
                "LEFT JOIN ProductSS_Size ON ProductSS_Size.PID=m_PRODUCT.ID " +
                "LEFT JOIN SS_SizeDetails ON ProductSS_Size.ssID=SS_SizeDetails.SSID " +
                "LEFT JOIN m_PRODUCTsub ON m_PRODUCTsub.pid=m_PRODUCT.ID " +
                "LEFT JOIN (select sum(Proportion) as sums,ssid from SS_SizeDetails group by ssid) as temp ON ProductSS_Size.ssID=temp.SSID " +
                "LEFT JOIN M_SizeDetails ON M_SizeDetails.ID=SS_SizeDetails.SDID WHERE " + str4;
            SqlDataAdapter sqlda = new SqlDataAdapter(str4, conn);
            SqlDataAdapter sqlda1 = new SqlDataAdapter(str5, conn);
            sqlda.Fill(ods,"wph");
            DataTable sizename = new DataTable();
            ds = new DataSet();
            sqlda1.Fill(ds);
            sizename = ds.Tables[0];
            DataTable newDataTable = ods.Tables[0].Clone();
            object[] objArray = new object[newDataTable.Columns.Count];
            objArray[0] = "ITEM_NO";
            //objArray[4] = "SDNAME";
            objArray[1] = "s_color";
            objArray[2] = "stor";
            
            //for (int i = 0; i < ods.Tables.Count; i++)
            //{
            //    for (int j = 0; j < ods.Tables[i].Rows.Count; j++)
            //    {
            //        ods.Tables[i].Rows[j]["nos"] = ods.Tables[i].Rows[j]["nos"];
            //        //将表的一行的值存放数组中。
            //        ods.Tables[i].Rows[j].ItemArray.CopyTo(objArray, 0);
            //        //将数组的值添加到新表中。
            //        newDataTable.Rows.Add(objArray);
            //    }
            //}

            //DataTable newTable = new DataTable();

            //if (newDataTable.Rows.Count >= sizename.Rows.Count)
            //{
            //    newTable.Merge(newDataTable);
            //    foreach (DataRow newrow in newTable.Rows)
            //    {
            //        foreach (DataRow dr2 in sizename.Rows)
            //        {
            //            if (newrow["item_no"].ToString() == dr2["item_no"].ToString() && newrow["stor"].ToString() == dr2["stor"].ToString())
            //            {
            //                //newrow["stor"] = dr2["stor"];
            //                newrow["SDNAME"] = dr2["SDNAME"];
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    newTable.Merge(sizename);
            //    foreach (DataRow newrow in newTable.Rows)
            //    {
            //        foreach (DataRow dr1 in newDataTable.Rows)
            //        {
            //            if (newrow["item_no"].ToString() == dr1["item_no"].ToString() && newrow["stor"].ToString() == dr1["stor"].ToString())
            //            {
            //                newrow["SDNAME"] = dr1["SDNAME"];
            //            }
            //        }
            //    }
            //}
            ///**************************************/

            //DataTable dtResult = newTable.Clone();
            //DataTable dtName = newTable.DefaultView.ToTable(true, "item_no", "s_color", "stor", "SDNAME");  
            //for ( int i = 0 ; i < dtName.Rows.Count; i++)  
            //{
            //    DataRow[] rows = newDataTable.Select("item_no='" + dtName.Rows[i][0].ToString() + "' and s_color='" + dtName.Rows[i][1].ToString() + "' and stor='" + dtName.Rows[i][2].ToString() + "'");  // temp用来存储筛选出来的数据  
            //    DataTable temp = dtResult.Clone();
            //    foreach (DataRow row in rows)
            //    {
            //        temp.Rows.Add(row.ItemArray);
            //    }
            //    DataRow dr = dtResult.NewRow();  
            //    dr[0] = dtName.Rows[i][0].ToString();
            //    dr[1] = dtName.Rows[i][1].ToString();
            //    dr[2] = dtName.Rows[i][2].ToString();
            //    dr[3] = dtName.Rows[i][3].ToString();
            //    dr[4] = temp.Compute("sum(NOs)/12", "");
            //    dtResult.Rows.Add(dr); 
            //}
            //DataTable dgvdt = dtResult.Clone();
            ////dtName = new DataTable();
            ////newDataTable = new DataTable();
            ////newDataTable = dtResult.Clone();
            ////dtName = dtResult.DefaultView.ToTable(true, "item_no", "s_color", "stor", "SDNAME", "NOs");
            //for (int i = 0; i < dtResult.Rows.Count; i++)
            //{
            //    DataRow dr = dgvdt.NewRow();
            //    dr[0] = dtResult.Rows[i][0].ToString();
            //    dr[1] = dtResult.Rows[i][1].ToString();
            //    dr[2] = dtResult.Rows[i][2].ToString();
            //    dr[3] = dtResult.Rows[i][3].ToString();
            //    dr[4] = Math.Round(Convert.ToDecimal(dtResult.Rows[i][4].ToString()), 0) * 12;
            //    dgvdt.Rows.Add(dr);
            //}

            //DataTable DGVdtrcc = RCC(dgvdt);
            for (int i = 0; i < ods.Tables.Count; i++)
            {
                for (int j = 0; j < ods.Tables[i].Rows.Count; j++)
                {
                    ods.Tables[i].Rows[j]["nos"] = ods.Tables[i].Rows[j]["nos"];
                    //将表的一行的值存放数组中。
                    ods.Tables[i].Rows[j].ItemArray.CopyTo(objArray, 0);
                    //将数组的值添加到新表中。
                    newDataTable.Rows.Add(objArray);
                }
            }


            /**************************************/


            //(newDataTable, sizename);
            DataTable DGVdtrcc = RCC(Getdata(newDataTable, sizename));

            DataDGV.DataSource = DGVdtrcc;
            DataDGV.Columns["item_no"].HeaderText = "款号";
            DataDGV.Columns["s_color"].HeaderText = "颜色";
            DataDGV.Columns["Sum"].HeaderText = "小计";
            //DataDGV.Columns["stor"].HeaderText = "规格";
            //DataDGV.Columns["SDNAME"].HeaderText = "尺码";
            //DataDGV.Columns["NOs"].HeaderText = "数量";

        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            if (DataDGV.Rows.Count > 0)
            {
                //建立Excel对象    
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                //生成字段名称    
                for (int i = 0; i < DataDGV.ColumnCount; i++)
                {
                    excel.Cells[1, i + 1] = DataDGV.Columns[i].HeaderText;
                    //if (y == 0)
                    //{
                    //    y = 1;
                    //    //toolStripStatusLabel6.Text = "数据导入中，请等待!";
                    //}
                }    //填充数据    
                for (int i = 0; i < DataDGV.RowCount; i++)
                {
                    for (int j = 0; j < DataDGV.ColumnCount; j++)
                    {
                        if (DataDGV[j, i].Value == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "" + DataDGV[i, j].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = DataDGV[j, i].Value.ToString();
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

        private DataTable Getdata(DataTable newDataTable,DataTable sizename)
        {
            
            DataTable newTable = new DataTable();

            if (newDataTable.Rows.Count >= sizename.Rows.Count)
            {
                newTable.Merge(newDataTable);
                foreach (DataRow newrow in newTable.Rows)
                {
                    foreach (DataRow dr2 in sizename.Rows)
                    {
                        if (newrow["item_no"].ToString() == dr2["item_no"].ToString() && newrow["stor"].ToString() == dr2["stor"].ToString())
                        {
                            //newrow["stor"] = dr2["stor"];
                            newrow["SDNAME"] = dr2["SDNAME"];
                        }
                    }
                }
            }
            else
            {
                newTable.Merge(sizename);
                foreach (DataRow newrow in newTable.Rows)
                {
                    foreach (DataRow dr1 in newDataTable.Rows)
                    {
                        if (newrow["item_no"].ToString() == dr1["item_no"].ToString() && newrow["stor"].ToString() == dr1["stor"].ToString())
                        {
                            newrow["SDNAME"] = dr1["SDNAME"];
                        }
                    }
                }
            }

            DataTable dtResult = newTable.Clone();
            DataTable dtName = newTable.DefaultView.ToTable(true, "item_no", "s_color", "stor", "SDNAME");
            for (int i = 0; i < dtName.Rows.Count; i++)
            {
                DataRow[] rows = newDataTable.Select("item_no='" + dtName.Rows[i][0].ToString() + "' and s_color='" + dtName.Rows[i][1].ToString() + "' and stor='" + dtName.Rows[i][2].ToString() + "'");  // temp用来存储筛选出来的数据  
                DataTable temp = dtResult.Clone();
                foreach (DataRow row in rows)
                {
                    temp.Rows.Add(row.ItemArray);
                }
                DataRow dr = dtResult.NewRow();
                dr[0] = dtName.Rows[i][0].ToString();
                dr[1] = dtName.Rows[i][1].ToString();
                dr[2] = dtName.Rows[i][2].ToString();
                dr[3] = dtName.Rows[i][3].ToString();
                dr[4] = temp.Compute("sum(NOs)/12", "");
                dtResult.Rows.Add(dr);
            }
            DataTable dgvdt = dtResult.Clone();
            //dtName = new DataTable();
            //newDataTable = new DataTable();
            //newDataTable = dtResult.Clone();
            //dtName = dtResult.DefaultView.ToTable(true, "item_no", "s_color", "stor", "SDNAME", "NOs");
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                DataRow dr = dgvdt.NewRow();
                dr[0] = dtResult.Rows[i][0].ToString();
                dr[1] = dtResult.Rows[i][1].ToString();
                dr[2] = dtResult.Rows[i][2].ToString();
                dr[3] = dtResult.Rows[i][3].ToString();
                if (Convert.ToDecimal(dtResult.Rows[i][4].ToString()) > 0)
                {
                    dr[4] = Math.Round(Convert.ToDecimal(dtResult.Rows[i][4].ToString()), 0) * 12;
                }
                else
                {
                    dr[4] = 0;
                }
                dgvdt.Rows.Add(dr);
            }
            return dgvdt;
        }
        private DataTable RCC(DataTable _outDataSource)
        {
            //从DataTable中读取不重复的日期行，用来构造新DataTable的列
            DataTable distinct_date = _outDataSource.DefaultView.ToTable(true, "stor");

            DataTable new_DataTable = new DataTable();

            //将客户名称列添加到新表中
            DataColumn new_d_col = new DataColumn();
            new_d_col.ColumnName = "item_no";
            new_d_col.Caption = "";
            new_DataTable.Columns.Add(new_d_col);
            //将客户名称列添加到新表中
            new_d_col = new DataColumn();
            new_d_col.ColumnName = "s_color";
            new_d_col.Caption = "";
            new_DataTable.Columns.Add(new_d_col);

            StringBuilder str_sum = new StringBuilder();

            //开始在新表中构造日期列
            foreach (DataRow dr in distinct_date.Rows)
            {
                new_d_col = new DataColumn();
                new_d_col.DataType = typeof(decimal);
                new_d_col.ColumnName = dr["stor"].ToString();
                new_d_col.Caption = dr["stor"].ToString();
                new_d_col.DefaultValue = 0;
                new_DataTable.Columns.Add(new_d_col);

                //这个的目的是为合计列构造expression
                str_sum.Append("+[").Append(dr["stor"].ToString()).Append("]");
            }

            //将合计列添加到新表中
            new_d_col = new DataColumn();
            new_d_col.DataType = typeof(decimal);
            new_d_col.ColumnName = "Sum";
            new_d_col.Caption = "合计";
            new_d_col.DefaultValue = 0;
            new_d_col.Expression = str_sum.ToString().Substring(1);
            new_DataTable.Columns.Add(new_d_col);

            /*好了，到此新表已经构建完毕，下面开始为新表添加数据*/

            //从原DataTable中读出不重复的客户名称，以客户名称为关键字来构造新表的行
            DataTable distinct_object = _outDataSource.DefaultView.ToTable(true, "item_no", "s_color");
            DataRow[] drs;
            DataRow new_dr;
            foreach (DataRow dr in distinct_object.Rows)
            {
                new_dr = new_DataTable.NewRow();
                new_dr["item_no"] = dr["item_no"].ToString();
                new_dr["s_color"] = dr["s_color"].ToString();

                foreach (DataRow _dr in distinct_date.Rows)
                {
                    drs = _outDataSource.Select("item_no='" + dr["item_no"].ToString() +
                        "' and s_color='" + dr["s_color"].ToString() + "' and stor='" + _dr["stor"].ToString() + "'");
                    if (drs.Length != 0)
                    {
                        new_dr[_dr["stor"].ToString()] = Math.Round(Convert.ToDecimal(drs[0]["NOs"]), 2);
                    }
                }
                new_DataTable.Rows.Add(new_dr);
            }

            return new_DataTable;
        }

        private void TXTEXCEL_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "D://";

            fileDialog.Filter = "txt files (*.xls)|*.xls|All files (*.*)|*.*";

            fileDialog.FilterIndex = 1;

            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                this.TXTEXCEL.Text = fileDialog.FileName;

            }
        }

        private void BtnDate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (this.TXTEXCEL.Text == "")
            {
                MessageBox.Show("Excel路径不能为空!", "提示", MessageBoxButtons.OK);
                return;
            }
            ds = new DataSet();
            objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + this.TXTEXCEL.Text + ";" + "Extended Properties=\"Excel 8.0;IMEX=1;\"");
            objConn.Open();
            schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            DataSet ods = new DataSet();
            OleDbDataAdapter myData = new OleDbDataAdapter("select * from [现有库存$]", objConn);
            myData.Fill(ds, schemaTable.Rows[0][2].ToString().Trim());//填充数据
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            if (ds.Tables[schemaTable.Rows[0][2].ToString().Trim()].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!str4.Contains(ds.Tables[0].Rows[i]["货号"].ToString()))
                    //if (str4.IndexOf(ds.Tables[0].Rows[i]["货号"]) > -1)
                    {
                        if (str4 != "")
                        {
                            str4 += " or ";
                        }
                        str4 += "item_no='" + ds.Tables[0].Rows[i]["货号"] + "'";
                    }
                }
                for (int i = 1; i < ds.Tables[0].Columns.Count - 1; i++)
                {
                    if (str1 != "")
                    {
                        str1 += " union all ";
                    }
                    if (str2 != "")
                    {
                        str2 += " union all ";

                    }
                    if (str3 != "")
                    {
                        str3 += " union all ";

                    }

                    str1 += "select 货号 as item_no,颜色 as s_color,'规格" + i.ToString() + "'as stor,'' as SDNAME,0-规格" + i.ToString() + " as NOs from [现有库存$] ";
                    str2 += "select 货号 as item_no,颜色 as s_color,'规格" + i.ToString() + "'as stor,'' as SDNAME,0-规格" + i.ToString() + " as NOs from [未入库$] ";
                    //str3 += "select 货号 as item_no,颜色 as s_color,'规格" + i.ToString() + "'as stor,'' as SDNAME,0-round(规格" + i.ToString() + "*2/3,0) as NOs from [库存$] ";
                }
                OleDbDataAdapter myData1 = new OleDbDataAdapter(str1, objConn);
                OleDbDataAdapter myData2 = new OleDbDataAdapter(str2, objConn);
                //OleDbDataAdapter myData3 = new OleDbDataAdapter(str3, objConn);
                myData1.Fill(ods, "现有库存");//填充数据
                myData2.Fill(ods, "未入库");//填充数据
                //myData3.Fill(ods, "库存");//填充数据
            }
            objConn.Close();
            conn.Open();
            str5 = "select item_no,'规格'+cast(m_SizeDetails.sort as varchar(5)) as stor,m_SizeDetails.name as sdname from M_product left join M_productSize on m_ProductSize.pid=M_product.id " +
                 "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid WHERE " + str4;
            str3 = "select item_no,s_color,'规格'+cast(m_SizeDetails.sort as varchar(5)) as stor," +
                                "m_SizeDetails.[name] as SDName,round(Proportion*" + Convert.ToInt32(TxtNOs2.Text.ToString()) + "*" + Convert.ToInt32(TxtZzDay.Text.ToString()) + ",0) as NOs from SS_ProductColourSize " +
                                "left join m_Productsub on m_Productsub.id=colourid  " +
                                "left join m_SizeDetails on m_SizeDetails.id=SS_ProductColourSize.sdid " +
                                "left join m_Product on m_Product.id=SS_ProductColourSize.pid  WHERE " + str4;

            str4 = "select item_no,s_color,'规格'+cast(m_SizeDetails.sort as varchar(5)) as stor,"+
                    "m_SizeDetails.[name] as SDName,round(Proportion*" + Convert.ToInt32(TxtNOs2.Text.ToString()) + "*" + Convert.ToInt32(TxtyjDay.Text.ToString()) + ",0) as NOs from SS_ProductColourSize " +
                    "left join m_Productsub on m_Productsub.id=colourid  "+
                    "left join m_SizeDetails on m_SizeDetails.id=SS_ProductColourSize.sdid "+
	                "left join m_Product on m_Product.id=SS_ProductColourSize.pid  WHERE " + str4;
            
            SqlDataAdapter sqlda = new SqlDataAdapter(str4, conn);
            SqlDataAdapter sqlda1 = new SqlDataAdapter(str5, conn);
            SqlDataAdapter sqlda2 = new SqlDataAdapter(str3,conn);
            sqlda.Fill(ods, "yjday");
            sqlda2.Fill(ods, "zzday");

            DataTable sizename = new DataTable();
            ds = new DataSet();
            sqlda1.Fill(ds);
            sizename = ds.Tables[0];
            DataTable newDataTable = ods.Tables[0].Clone();
            object[] objArray = new object[newDataTable.Columns.Count];
            objArray[0] = "ITEM_NO";
            //objArray[4] = "SDNAME";
            objArray[1] = "s_color";
            objArray[2] = "stor";

            for (int i = 0; i < ods.Tables.Count; i++)
            {
                for (int j = 0; j < ods.Tables[i].Rows.Count; j++)
                {
                    if (ods.Tables[i].Rows[j]["nos"].ToString() != "")
                    {
                        ods.Tables[i].Rows[j]["nos"] = ods.Tables[i].Rows[j]["nos"];
                        //将表的一行的值存放数组中。
                        ods.Tables[i].Rows[j].ItemArray.CopyTo(objArray, 0);
                        //将数组的值添加到新表中。
                        newDataTable.Rows.Add(objArray);
                    }
                }
            }

            
            /**************************************/


            //(newDataTable, sizename);
            DataTable DGVdtrcc = RCC(Getdata(newDataTable, sizename));

            DataDGV2.DataSource = DGVdtrcc;
            DataDGV2.Columns["item_no"].HeaderText = "款号";
            DataDGV2.Columns["s_color"].HeaderText = "颜色";
            DataDGV2.Columns["Sum"].HeaderText = "小计";
            //DataDGV.Columns["stor"].HeaderText = "规格";
            //DataDGV.Columns["SDNAME"].HeaderText = "尺码";
            //DataDGV.Columns["NOs"].HeaderText = "数量";
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
                for (int i = 0; i < DataDGV2.RowCount ; i++)
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

    }
}
