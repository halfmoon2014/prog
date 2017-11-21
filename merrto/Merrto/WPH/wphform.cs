using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Xml;
using grproLib;

namespace Merrto
{
    public partial class wphform : Form
    {
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private GridppReport Report = new GridppReport();
        baseclass.xmldataset xmldate = new baseclass.xmldataset();
        baseclass.getChar getC = new baseclass.getChar();
        public wphform()
        {
            InitializeComponent();
        }
        private string xhname = "";
        private void BindData()
        {

            DataTable dtData = new DataTable();
            dtData.Columns.Add("货号");
            dtData.Columns.Add("条形码");
            dtData.Columns.Add("规格");
            dtData.Columns.Add("颜色");
            dtData.Columns.Add("广州");
            dtData.Columns.Add("上海");
            dtData.Columns.Add("成都");
            dtData.Columns.Add("北京");
            DataRow drData;
            drData = dtData.NewRow();
            //drData[0] = 1; drData[1] = "张三"; drData[2] = "1"; dtData.Rows.Add(drData);
            //drData = dtData.NewRow();
            //drData[0] = 2; drData[1] = "李四"; drData[2] = "1"; dtData.Rows.Add(drData);
            //drData = dtData.NewRow();
            //drData[0] = 3; drData[1] = "王五"; drData[2] = "1"; dtData.Rows.Add(drData);
            //drData = dtData.NewRow();
            //drData[0] = 4; drData[1] = "小芳"; drData[2] = "0"; dtData.Rows.Add(drData);
            //drData = dtData.NewRow();
            //drData[0] = 5; drData[1] = "小娟"; drData[2] = "0"; dtData.Rows.Add(drData);
            //drData = dtData.NewRow();
            //drData[0] = 6; drData[1] = "赵六"; drData[2] = "1"; dtData.Rows.Add(drData);
            this.ExcelDGV.DataSource = dtData;
            ExcelDGV.Columns["北京"].Width = 60;
            ExcelDGV.Columns["成都"].Width = 60;
            ExcelDGV.Columns["广州"].Width = 60;
            ExcelDGV.Columns["上海"].Width = 60;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Filter = "Excel文件(*.xls)|*.xls";
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

            exceld.ExcelToDataGridView(strName, this.ExcelDGV); 
            //ComboBox cbx = new ComboBox();
            for (int i = 0; i < this.ExcelDGV.Columns.Count; i++)
            {
                Cbocolumnprint.Items.Add(this.ExcelDGV.Columns[i].HeaderText); 
            }
        }
        
        private void wphform_Load(object sender, EventArgs e)
        {
            BindData();
            TxtDate.Text = DateTime.Now.ToString("yyyyMMdd");
        }

        private void BTNPacking_Click(object sender, EventArgs e)
        {
            DataTable dtData = new DataTable();
            DataRow drData;
            dtData.Columns.Add("箱号");
            dtData.Columns.Add("条形码");
            dtData.Columns.Add("货号");
            dtData.Columns.Add("规格");
            dtData.Columns.Add("颜色");
            dtData.Columns.Add("数量");
            dtData.Columns.Add("目地的");
            int NO = 0;
            int ns = 1;
            int paressno =Convert.ToInt32(TxtParessNO.Text.ToString());
            for (int i = 0; i < ExcelDGV.Rows.Count; i++)
            {
                //MessageBox.Show();
                for (int j = 0; j <Convert.ToInt32(ExcelDGV.Rows[i].Cells[Cbocolumnprint.Text.ToString()].Value.ToString()); j++)
                {
                    
                    if (NO == Convert.ToInt32(TXTNO.Text.ToString())-1)
                    {
                        drData = dtData.NewRow();
                        drData[0] = TxtAdd.Text.ToString() + TxtDate.Text.ToString() + ("000" + paressno).Substring(("000" + paressno).Length - 4, 4);
                        drData[1] = ExcelDGV.Rows[i].Cells["条形码"].Value.ToString();
                        drData[2] = ExcelDGV.Rows[i].Cells["货号"].Value.ToString();
                        drData[3] = ExcelDGV.Rows[i].Cells["规格"].Value.ToString();
                        drData[4] = ExcelDGV.Rows[i].Cells["颜色"].Value.ToString();
                        drData[5] = ns;
                        drData[6] = Cbocolumnprint.Text.ToString();
                        dtData.Rows.Add(drData);
                        paressno++;
                        NO = 0;
                        ns = 1;
                    }
                    else if (j == Convert.ToInt32(ExcelDGV.Rows[i].Cells[Cbocolumnprint.Text.ToString()].Value.ToString()) - 1)
                    {
                        drData = dtData.NewRow();
                        drData[0] = TxtAdd.Text.ToString() + TxtDate.Text.ToString() + ("000" + paressno).Substring(("000" + paressno).Length-4,4);
                        drData[1] = ExcelDGV.Rows[i].Cells["条形码"].Value.ToString();
                        drData[2] = ExcelDGV.Rows[i].Cells["货号"].Value.ToString();
                        drData[3] = ExcelDGV.Rows[i].Cells["规格"].Value.ToString();
                        drData[4] = ExcelDGV.Rows[i].Cells["颜色"].Value.ToString();
                        drData[5] = ns;
                        drData[6] = Cbocolumnprint.Text.ToString();
                        dtData.Rows.Add(drData);
                        ns = 1;
                        NO += 1;
                    }
                    else
                    {
                        ns++;
                        NO += 1;
                    }
                    //NO += 1;
                     this.ProudctDGV.DataSource = dtData;
                    //ProudctDGV.Rows[i].Cells[j].Value = ExcelDGV.Rows[i].Cells[j].Value;
                    ////为空行添加列值
                    //for (int s = 0; s < ExcelDGV.Rows[i].Cells.Count; s++)
                    //{
                    //    ProudctDGV.Rows[i].Cells[j].Value = ExcelDGV.Rows[i].Cells[j].Value;
                    //}
                }
            }
            if (NO != Convert.ToInt32(TXTNO.Text.ToString()) && NO !=0)
            {
                xhname = TxtAdd.Text.ToString() + TxtDate.Text.ToString() + ("000" + paressno).Substring(("000" + paressno).Length - 4, 4);
                MessageBox.Show("箱号："+TxtAdd.Text.ToString() + TxtDate.Text.ToString() + ("000" + paressno).Substring(("000" + paressno).Length - 4, 4) + " 数量："+NO+"件 不过一箱！一箱为："+TXTNO.Text.ToString()+"件。");
            }
            if (MessageBox.Show("\n此数据是否为最此专场的最后一批数据！!", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                chkLast.Checked = true;
            }
            else
            {
                chkLast.Checked = false;
            }
        }

        private void BTNSave_Click(object sender, EventArgs e)
        {
            DataSave();
        }

        private void DataSave()
        {
            if (txtSpecial.Text.ToString() != "")
            {
                DataSet ds = new DataSet();
                SqlConnection conn = sqlcon.getcon("");
                try
                {
                    string sqlstr = "";
                    string sqlselect = "";
                    for (int i = 0; i < ProudctDGV.Rows.Count; i++)
                    {
                        if (sqlselect != "")
                        {
                            sqlselect += " or ";
                        }
                        sqlselect += "cade='" + ProudctDGV.Rows[i].Cells["箱号"].Value.ToString() + "'";
                        if (chkLast.Checked == false)
                        {
                            if (ProudctDGV.Rows[i].Cells["箱号"].Value.ToString() != xhname)
                            {
                                sqlstr += " insert into Wph_Packing(Cade,BarCode,Item,Size,Colour,Nomber,[ADd],Special,Verify,type) values ('" + ProudctDGV.Rows[i].Cells["箱号"].Value.ToString() +
                                            "','" + ProudctDGV.Rows[i].Cells["条形码"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["货号"].Value.ToString() +
                                            "','" + ProudctDGV.Rows[i].Cells["规格"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["颜色"].Value.ToString() +
                                            "','" + ProudctDGV.Rows[i].Cells["数量"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["目地的"].Value.ToString() + "','" + txtSpecial.Text.ToString() + "','0','1');";
                            }
                        }
                        else
                        {
                            sqlstr += " insert into Wph_Packing(Cade,BarCode,Item,Size,Colour,Nomber,[ADd],Special,Verify,type) values ('" + ProudctDGV.Rows[i].Cells["箱号"].Value.ToString() +
                                         "','" + ProudctDGV.Rows[i].Cells["条形码"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["货号"].Value.ToString() +
                                         "','" + ProudctDGV.Rows[i].Cells["规格"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["颜色"].Value.ToString() +
                                         "','" + ProudctDGV.Rows[i].Cells["数量"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["目地的"].Value.ToString() + "','" + txtSpecial.Text.ToString() + "','0','1');";
                        }
                    }

                    sqlselect = "select * from Wph_Packing where " + sqlselect;
                    SqlDataAdapter sqlDaper = new SqlDataAdapter(sqlselect, conn);
                    conn.Open();
                    sqlDaper.Fill(ds);
                    conn.Close();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("数据已保存不能重复保存！", "系统提示：", MessageBoxButtons.OK);
                        return;
                    }
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlstr, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("数据保存成功！", "系统提示：", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("专场名称为空不能保存！！");
            }
        }

        private void TxtDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BTNPacking_Click(sender,e);
            }
        }
        private bool codeboolisExcelInstalled()
        {
            Type type = Type.GetTypeFromProgID("Excel.Application");
            return type != null;
        }
        private void btnupEXcel_Click(object sender, EventArgs e)
        {
            if (ProudctDGV.Rows.Count > 0)
            {
                //建立Excel对象    
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                //生成字段名称    
                for (int i = 0; i < ProudctDGV.ColumnCount; i++)
                {
                    excel.Cells[1, i + 1] = ProudctDGV.Columns[i].HeaderText;
                    //if (y == 0)
                    //{
                    //    y = 1;
                    //    //toolStripStatusLabel6.Text = "数据导入中，请等待!";
                    //}
                }    //填充数据    
                for (int i = 0; i < ProudctDGV.RowCount; i++)
                {
                    for (int j = 0; j < ProudctDGV.ColumnCount; j++)
                    {
                        if (ProudctDGV[j, i].Value == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "" + ProudctDGV[i, j].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = ProudctDGV[j, i].Value.ToString();
                        }
                    }
                }
                excel.Visible = true;
            }
            else
            {
                MessageBox.Show("没有你要导的数据！！！");
            }
            //if (codeboolisExcelInstalled())
            //{
            //    MessageBox.Show("本机已安装Excel文件");
            //}
            //else
            //{
            //    MessageBox.Show("当前系统没有发现可执行的Excel文件, 如需使用Excel功能请先安装office 2003", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void btnUppacking_Click(object sender, EventArgs e)
        {
           
            uppacking();
            if (Cbocolumnprint.Text.ToString() != "")
            {
                BTNPacking_Click(sender, e);
            }
        }
        private void uppacking()
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            string sqlselect;
            sqlselect = "select max(cade) as cade from Wph_Packing where cade like '" + TxtAdd.Text.ToString() + TxtDate.Text.ToString() + "%'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            if (ds.Tables[0].Rows[0]["Cade"].ToString() == "")
            {
                TxtParessNO.Text = "0001";
            }
            else
            {
                TxtParessNO.Text = ("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(TxtAdd.Text.ToString().Length +
                    TxtDate.Text.ToString().Length, 4)) + 1).ToString()).Substring(("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(TxtAdd.Text.ToString().Length +
                    TxtDate.Text.ToString().Length, 4)) + 1).ToString()).Length - 4, 4);
            }
            conn.Close();
        }

        private void printdate()
        {
                DataSet ds = new DataSet();
                SqlConnection conn = sqlcon.getcon("");
                try
                {
                    string sqlstr = "";
                    for (int i = 0; i < ProudctDGV.Rows.Count; i++)
                    {
                        sqlstr += " insert into Wph_PackingPrint(Cade,BarCode,Item,Size,Colour,Nomber,[ADd],Special) values ('" + ProudctDGV.Rows[i].Cells["箱号"].Value.ToString() +
                                        "','" + ProudctDGV.Rows[i].Cells["条形码"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["货号"].Value.ToString() +
                                        "','" + ProudctDGV.Rows[i].Cells["规格"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["颜色"].Value.ToString() +
                                        "','" + ProudctDGV.Rows[i].Cells["数量"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["目地的"].Value.ToString() + "','"+txtSpecial.Text.ToString()+"');";
                    }

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlstr, conn);
                    cmd.ExecuteNonQuery();
                    try
                    {
                        sqlstr = "";
                        SqlDataAdapter sqlDaper = new SqlDataAdapter("select cade,[add],Special,count(1) as counts from Wph_PackingPrint group by cade,[add],Special", conn);
                        sqlDaper.Fill(ds);

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            // % Convert.ToInt32(txtRows.Text.ToString())
                            for (int row = Convert.ToInt32(ds.Tables[0].Rows[i]["counts"].ToString()); row < Convert.ToInt32(txtRows.Text.ToString()); row++)
                            {
                                sqlstr += " insert into Wph_PackingPrint(Cade,[ADd],Special) values ('" + ds.Tables[0].Rows[i]["cade"].ToString() + "','" + ds.Tables[0].Rows[i]["ADd"].ToString() + "','" + ds.Tables[0].Rows[i]["Special"].ToString() + "');";
                            }
                        }
                        cmd = new SqlCommand(sqlstr, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    //唯品汇条码打印
                    DataTable dt = new DataTable();
                    string Rouet = Application.StartupPath + "\\PrintRoute.xml";
                    string printR = "";
                    dt = xmldate.CXmlToDataTable(Rouet);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["FormID"].ToString() == "唯品汇条码打印")
                        {
                            printR = dt.Rows[i]["Route"].ToString();
                        }
                    }
                    Report.LoadFromFile(@printR);
                    Report.ConnectionString = sqlcon.XMLIP();

                    Report.QuerySQL = "select * from Wph_PackingPrint";
                    ProudctDGV.DataSource = "";
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }

        private void btnPackintBarCode_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (txtSpecial.Text.ToString() != "")
            {
                printdate();
                //for (int i = 0; i < Convert.ToInt32(TXTPrintNO.Text.ToString()); i++)
                //{
                Report.Print(true);
                //}
                conn.Open();
                SqlCommand cmdd = new SqlCommand("delete from Wph_PackingPrint", conn);
                cmdd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("数据保存成功！", "系统提示：", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("专场名称为空不能打印！！");
            }
            if (MessageBox.Show("\n数据已打印！！   \n\n\n确认是否保存(Y/N)", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                DataSave();
            }
        }

        private void btnbrow_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (txtSpecial.Text.ToString() != "")
            {
                printdate();
                Report.PrintPreview(true);
                conn.Open();
                SqlCommand cmdd = new SqlCommand("delete from Wph_PackingPrint", conn);
                cmdd.ExecuteNonQuery();
                conn.Close();
                //MessageBox.Show("数据保存成功！", "系统提示：", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("专场名称为空不能打印！！");
            }
            if (MessageBox.Show("\n数据已打印！！   \n\n\n确认是否保存(Y/N)", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                DataSave();
            }
        }

        private void Cbocolumnprint_SelectedValueChanged(object sender, EventArgs e)
        {
            string strTemp="";  
            int iLen=Cbocolumnprint.Text.ToString().Length;  
            int i=0; 
            for (i=0;i<=iLen-1;i++)
            {
                strTemp += getC.GetCharSpellCode(Cbocolumnprint.Text.ToString().Substring(i, 1)); 
            }
            TxtAdd.Text = strTemp;
            //return strTemp;  
            //getC.GetHashCode
        }

        private void wphform_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ProudctDGV.Rows.Count > 0)
            {
                if (MessageBox.Show("\n数据没有保存   \n\n\n确认是否保存(Y/N)", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    DataSave();
                }
                this.Dispose();
                e.Cancel = false;
                this.Close();
            }

        }

        private void BTNReturnSave_Click(object sender, EventArgs e)
        {
            if (txtSpecial.Text.ToString() != "")
            {
                DataSet ds = new DataSet();
                SqlConnection conn = sqlcon.getcon("");
                string sqlselect = "";
                for (int i = 0; i < ProudctDGV.Rows.Count; i++)
                {
                    if (sqlselect != "")
                    {
                        sqlselect += " or ";
                    }
                    sqlselect += "cade='" + ProudctDGV.Rows[i].Cells["箱号"].Value.ToString() + "'";

                }
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from Wph_Packing where " + sqlselect, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            DataSave();
        }

   }
}
