using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.WPH
{
    public partial class WTRBarCode : Form
    {
        baseclass.sqldatacon sqlcon=new baseclass.sqldatacon();
        public WTRBarCode()
        {
            InitializeComponent();
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            string strsql = "";

            if (CmbVerify.Text.ToString() != "")
            {
                if (CmbVerify.Text.ToString() == "全部")
                {
                    strsql = "select Wph_TRBarCode.Cade,Wph_TRBarCode.po,Wph_TRBarCode.BarCode,Wph_TheRetreat.[NO],Wph_TRBarCode.[no] as trNO,Wph_TRBarCode.Remark from Wph_TRBarCode " +
                            "left join Wph_TheRetreat on Wph_TRBarCode.cade=Wph_TheRetreat.cade and Wph_TRBarCode.BarCode=Wph_TheRetreat.BarCode  where Wph_TheRetreat.Cade like '%" + TxtCade.Text.ToString() + "%' "+
                            "union all select distinct Wph_TheRetreat.Cade,Wph_TheRetreat.po,Wph_TheRetreat.barcode,Wph_TheRetreat.[NO],0,Wph_TRBarCode.Remark from " +
                            "Wph_TheRetreat left join Wph_TRBarCode on Wph_TRBarCode.cade=Wph_TheRetreat.cade  where not exists(" +
                            "select * from Wph_TRBarCode where Wph_TRBarCode.cade=Wph_TheRetreat.cade and Wph_TRBarCode.BarCode=Wph_TheRetreat.BarCode) and Wph_TheRetreat.Cade like '%" + TxtCade.Text.ToString() + "%'  order by Cade";
                }

                if (CmbVerify.Text.ToString() == "已校验")
                {
                    strsql = "select Wph_TRBarCode.Cade,Wph_TRBarCode.po,Wph_TRBarCode.BarCode,Wph_TheRetreat.[NO],Wph_TRBarCode.[no] as trNO,Wph_TRBarCode.Remark from Wph_TRBarCode " +
                            "left join Wph_TheRetreat on Wph_TRBarCode.cade=Wph_TheRetreat.cade and Wph_TRBarCode.BarCode=Wph_TheRetreat.BarCode where Wph_TheRetreat.Cade like '%" + TxtCade.Text.ToString() + "%' " +
                            "union all select distinct Wph_TheRetreat.Cade,Wph_TheRetreat.po,Wph_TheRetreat.barcode,Wph_TheRetreat.[NO],0,Wph_TRBarCode.Remark" +
                            " from Wph_TheRetreat left join Wph_TRBarCode on Wph_TRBarCode.cade=Wph_TheRetreat.cade where exists(" +
                            "select * from Wph_TRBarCode where Wph_TRBarCode.cade=Wph_TheRetreat.cade) and not exists(select * from Wph_TRBarCode where Wph_TRBarCode.BarCode=Wph_TheRetreat.BarCode)  and Wph_TheRetreat.Cade like '%" + TxtCade.Text.ToString() + "%'  order by Cade";
                }
                else if (CmbVerify.Text.ToString() == "未校验")
                {
                    strsql = "select Cade,po,barcode,[NO],0 as trNO,'' as Remark from Wph_TheRetreat where not exists(" +
                            "select * from Wph_TRBarCode where Wph_TRBarCode.cade=Wph_TheRetreat.cade) and Wph_TheRetreat.Cade like '%" + TxtCade.Text.ToString() + "%'  order by Cade";
                }

            }
            
            
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["BarCode"].HeaderText = "条型码";
            WPHbROWDGV.Columns["NO"].HeaderText = "数量";
            WPHbROWDGV.Columns["NO"].Width = 60;
            WPHbROWDGV.Columns["Cade"].HeaderText = "箱号";
            WPHbROWDGV.Columns["Cade"].Width = 150;
            WPHbROWDGV.Columns["po"].HeaderText = "PO单据";
            WPHbROWDGV.Columns["po"].Width = 70;
            WPHbROWDGV.Columns["trNO"].HeaderText = "检验数量";
            WPHbROWDGV.Columns["trNO"].Width = 80;
            WPHbROWDGV.Columns["Remark"].HeaderText = "备注";
            WPHbROWDGV.Columns["Remark"].Width = 150;
            conn.Close();
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
