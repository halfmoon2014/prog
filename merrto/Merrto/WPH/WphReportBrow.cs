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
    public partial class WphReportBrow : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        DataSet ds = new DataSet();
        public WphReportBrow()
        {
            InitializeComponent();
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                conn.Open();

                SqlDataAdapter sqlda = new SqlDataAdapter();

                DataSet ds = new DataSet();//执行存储过程 
                SqlCommand cmd = new SqlCommand("ptoc_Wph_report", conn);
                //说明命令要执行的是存储过程     
                cmd.CommandType = CommandType.StoredProcedure;
                //向存储过程中传递参数   
                cmd.Parameters.Add(new SqlParameter("@Special", SqlDbType.VarChar, 30));
                cmd.Parameters.Add(new SqlParameter("@Cade", SqlDbType.VarChar, 30));
                cmd.UpdatedRowSource = UpdateRowSource.None;
                cmd.Parameters["@Special"].Value = cmbSpecial.Text.ToString();
                cmd.Parameters["@Cade"].Value =this.TxtCade.Text.ToString();
                //执行命令 

                sqlda.SelectCommand = cmd;
                sqlda.SelectCommand.ExecuteNonQuery();
                sqlda.Fill(ds, "roletable");
                if (ds.Tables.Count > 0)
                {
                    WPHbROWDGV.DataSource = ds.Tables["roletable"];
                }
                WPHbROWDGV.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                WPHbROWDGV.Columns["PP"].HeaderText = "品牌";
                WPHbROWDGV.Columns["year"].HeaderText = "年份";
                WPHbROWDGV.Columns["CName"].HeaderText = "类别";
                WPHbROWDGV.Columns["wph_item"].HeaderText = "新款号";
                //WPHbROWDGV.Columns["item_no"].HeaderText = "原货号";
                WPHbROWDGV.Columns["huohao"].HeaderText = "货号";
                WPHbROWDGV.Columns["BarCode"].HeaderText = "条码";
                WPHbROWDGV.Columns["Pname"].HeaderText = "品名";
                WPHbROWDGV.Columns["sdname"].HeaderText = "规格";
                WPHbROWDGV.Columns["m_sex"].HeaderText = "性别";
                WPHbROWDGV.Columns["s_color"].HeaderText = "颜色";
                WPHbROWDGV.Columns["price_tag"].HeaderText = "正品价";
                WPHbROWDGV.Columns["zkn"].HeaderText = "售卖折扣";
                WPHbROWDGV.Columns["SDPrice"].HeaderText = "折后标准售卖价";
                WPHbROWDGV.Columns["SPPrice"].HeaderText = "供货价";
                WPHbROWDGV.Columns["class"].HeaderText = "商品分类";
                WPHbROWDGV.Columns["SUMNO"].HeaderText = "数量小计";
                WPHbROWDGV.Columns["sumSTmoney"].HeaderText = "金额小计";
                

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void WphReportBrow_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select distinct [Special] from Wph_Report", conn);
            sqlDaper.Fill(ds, "Special");
            cmbSpecial.DataSource = ds.Tables["Special"];
            cmbSpecial.DisplayMember = "Special";
            //cmbSpecial.ValueMember = "Special";
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
