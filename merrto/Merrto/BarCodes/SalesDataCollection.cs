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
    public partial class SalesDataCollection : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        public SalesDataCollection()
        {
            InitializeComponent();
        }

        private void BtnEXCEL_Click(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //ofd.Filter = "Excel文件(*.xls)|*.xls";
            ofd.Filter = "Excel文件(*.csv)|*.csv|Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx|所有文件|*.*";


            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
           
            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
            }

            if (strName == "")
            {
                MessageBox.Show("没有选择Excel文件，无法导入");
                return;
            }
            
            DataTable dts= exceld.CSVToDataGridViews(strName, this.DataDGV);

            DataTable dtName = dts.DefaultView.ToTable(true, "商家编码");
            DataTable dtResult = dtName.Clone();
            dtResult.Columns.Add("购买数量", typeof(System.Int32));//用户编号
            
            for (int i = 0; i < dtName.Rows.Count; i++)
            {
                if (dtName.Rows[i]["商家编码"].ToString() != "")
                {
                    DataRow[] rows = dts.Select("商家编码='" + dtName.Rows[i]["商家编码"].ToString() + "'");  // temp用来存储筛选出来的数据  
                    DataTable temp = dts.Clone();
                    foreach (DataRow row in rows)
                    {
                        temp.Rows.Add(row.ItemArray);
                    }
                    DataRow dr = dtResult.NewRow();
                    dr[0] = dtName.Rows[i]["商家编码"].ToString();
                    dr[1] = temp.Compute("sum(购买数量)", "");
                    dtResult.Rows.Add(dr);
                }
            }
            
            this.DataDGV.DataSource = dtResult;

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string str = "";
            for (int i = 0; i < DataDGV.Rows.Count; i++)
            {
                if (!str.Contains(DataDGV.Rows[i].Cells["商家编码"].ToString()))
                //if (str4.IndexOf(ds.Tables[0].Rows[i]["货号"]) > -1)
                {
                    if (Convert.ToInt32(DataDGV.Rows[i].Cells["购买数量"].Value.ToString())!=0)
                    {
                        if (str != "")
                        {
                            str += " union all ";
                        }
                        str += "select item_no,S_COLOR,'规格'+cast(m_SizeDetails.sort as varchar(5)) as stor,m_SizeDetails.name as sdname,"
                            + DataDGV.Rows[i].Cells["购买数量"].Value.ToString() + " as qty,m_SizeDetails.sort as orderby from M_product " +
                                "left join M_productSize on m_ProductSize.pid=M_product.id " +
                                "left join M_productsub on M_productsub.pid=M_product.id " +
                                "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                                "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='" + DataDGV.Rows[i].Cells["商家编码"].Value.ToString() + "'";
                        if (str != "")
                        {
                            str += " union all ";
                        }
                        str += "select item_no,S_COLOR,'规格'+cast(m_SizeDetails.sort as varchar(5)) as stor,m_SizeDetails.name as sdname,"
                            + DataDGV.Rows[i].Cells["购买数量"].Value.ToString() + " as qty,m_SizeDetails.sort as orderby from M_product " +
                                "left join M_productSize on m_ProductSize.pid=M_product.id " +
                                "left join M_productsub on M_productsub.pid=M_product.id " +
                                "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                                "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='MT" + DataDGV.Rows[i].Cells["商家编码"].Value.ToString() + "'";
                    }
                }
            }
            DataTable dt=new DataTable();
            SqlDataAdapter sqlda1 = new SqlDataAdapter(str + " order by orderby ", conn);
           conn.Open();
           sqlda1.Fill(dt);
           conn.Close();
           DataTable newDataTable = dt.Clone();
           object[] objArray = new object[newDataTable.Columns.Count];
           objArray[0] = "item_no";
           //objArray[4] = "SDNAME";
           objArray[1] = "s_color";
           objArray[2] = "stor";

           for (int j = 0; j < dt.Rows.Count; j++)
           {
               dt.Rows[j]["Qty"] = dt.Rows[j]["Qty"];
               //将表的一行的值存放数组中。
               dt.Rows[j].ItemArray.CopyTo(objArray, 0);
               //将数组的值添加到新表中。
               newDataTable.Rows.Add(objArray);
           }
          
           /**************************************/
           DataTable DGVdtrcc = RCC(newDataTable);

           DGVdata.DataSource = DGVdtrcc;
           DGVdata.Columns["item_no"].HeaderText = "款号";
           DGVdata.Columns["s_color"].HeaderText = "颜色";
           DGVdata.Columns["Sum"].HeaderText = "小计";
        }

        private DataTable Getdata(DataTable newDataTable)
        {

            DataTable dtResult = newDataTable.Clone();
            DataTable dtName = newDataTable.DefaultView.ToTable(true, "item_no", "s_color", "stor", "SDNAME");
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
                dr[4] = temp.Compute("sum(Qty)", "");
                dtResult.Rows.Add(dr);
            }
            DataTable dgvdt = dtResult.Clone();
            dtName = new DataTable();
            newDataTable = new DataTable();
            newDataTable = dtResult.Clone();
            dtName = dtResult.DefaultView.ToTable(true, "item_no", "s_color", "stor", "SDNAME", "NOs");
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                DataRow dr = dgvdt.NewRow();
                dr[0] = dtResult.Rows[i][0].ToString();
                dr[1] = dtResult.Rows[i][1].ToString();
                dr[2] = dtResult.Rows[i][2].ToString();
                dr[3] = dtResult.Rows[i][3].ToString();
                if (Convert.ToDecimal(dtResult.Rows[i][4].ToString()) > 0)
                {
                    dr[4] = Math.Round(Convert.ToDecimal(dtResult.Rows[i][4].ToString()), 0);
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
                        new_dr[_dr["stor"].ToString()] = Math.Round(Convert.ToDecimal(drs[0]["Qty"]), 2);
                    }
                }
                new_DataTable.Rows.Add(new_dr);
            }

            return new_DataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DGVdata.Rows.Count > 0)
            {
                //建立Excel对象    
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                //生成字段名称    
                for (int i = 0; i < DGVdata.ColumnCount; i++)
                {
                    excel.Cells[1, i + 1] = DGVdata.Columns[i].HeaderText;
                    //if (y == 0)
                    //{
                    //    y = 1;
                    //    //toolStripStatusLabel6.Text = "数据导入中，请等待!";
                    //}
                }    //填充数据    
                for (int i = 0; i < DGVdata.RowCount; i++)
                {
                    for (int j = 0; j < DGVdata.ColumnCount; j++)
                    {
                        if (DGVdata[j, i].Value == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "" + DGVdata[i, j].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = DGVdata[j, i].Value.ToString();
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
