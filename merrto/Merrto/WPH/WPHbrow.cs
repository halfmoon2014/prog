using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto
{
    public partial class WPHbrow : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.xmldataset xmldate = new baseclass.xmldataset();
        
        public WPHbrow()
        {
            InitializeComponent();
        }

        private void WPHbrow_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select Name,ID from Wph_Storage ", conn);
            conn.Open();
            sqlDaper.Fill(ds,"Storage");
            DataRow row = ds.Tables["Storage"].NewRow();
            ds.Tables["Storage"].Rows.Add(row);
            CmbAdd.DataSource = ds.Tables["Storage"];
            CmbAdd.ValueMember = "ID";
            CmbAdd.DisplayMember = "Name";
          
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("select distinct [Special] from Wph_Packing2 union all select distinct [Special] from Wph_Packing ", conn);
            sqlDaper1.Fill(ds,"Special");
            cmbSpecial.DataSource = ds.Tables["Special"];
            cmbSpecial.DisplayMember = "Special";
            conn.Close();
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            string strsql = "";
            string strsql1="";
            if (CmbAdd.SelectedValue.ToString() != "")
            {
                strsql1 = " StorageID='" + CmbAdd.SelectedValue.ToString() + "'";
            }


            if (TxtCade.Text.ToString() != "")
            {
                if (strsql1 != "")
                {
                    strsql1 += " and ";
                }
                strsql1 = strsql1 + " Wph_Packing2.Cade like '%" + TxtCade.Text.ToString() + "%'";
            }

            if (cmbSpecial.Text.ToString() != "")
            {
                if (strsql1 != "")
                {
                    strsql1 += " and ";
                }
                strsql1= strsql1 + " Special='" + cmbSpecial.Text.ToString() + "'";
            }

            if (CmbVerify.Text.ToString() != "")
            {
                if (CmbVerify.Text.ToString() != "全部")
                {
                    if (strsql1 != "")
                    {
                        strsql1 += " and ";
                    }
                    if (CmbVerify.Text.ToString() == "已校验")
                    {
                        strsql1 = strsql1 + "Verify='1'";
                    }
                    else if (CmbVerify.Text.ToString() == "未校验")
                    {
                        strsql1 = strsql1 + "Verify=''";
                    }
                }
            }
            if (strsql1 != "")
            {
                strsql1 = " where " + strsql1;
            }
            if (CmbAdd.Text.ToString() != "")
            {
                strsql = " [Add]='" + CmbAdd.Text.ToString() + "'";
            }


            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Wph_Packing.Cade like '%" + TxtCade.Text.ToString() + "%'";
            }

            if (cmbSpecial.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Special='" + cmbSpecial.Text.ToString() + "'";
            }

            if (CmbVerify.Text.ToString() != "")
            {
                if (CmbVerify.Text.ToString() != "全部")
                {
                    if (strsql != "")
                    {
                        strsql += " and ";
                    }
                    if (CmbVerify.Text.ToString() == "已校验")
                    {
                        strsql = strsql + "Verify='1'";
                    }
                    else if (CmbVerify.Text.ToString() == "未校验")
                    {
                        strsql = strsql + "Verify='0'";
                    }
                }
            }
            if (strsql != "")
            {
                strsql = " where " + strsql;
            }
            strsql = "select DBid,Wph_Packing2.Cade,Special,Wph_Item,Wph_Packing2.Pid,item_NO,M_name,Wph_Packing2.ColourID,"+
                "s_color,isnull(Wph_Item,'')+cast(CO_CODE as varchar(5))+cast(m_SizeDetails.cade as varchar(5)) as BarCode,"+
                "Wph_Packing2.SizeID,m_SizeDetails.name as SDname, [NO],Wph_Packing2.StorageID,Wph_Storage.[name] stname from Wph_Packing2 " +
                "left join Wph_Product on Wph_Product.pid=Wph_Packing2.PID "+
                "left join M_productsub  on M_productsub.id=Wph_Packing2.ColourID "+
                "left join m_SizeDetails on m_SizeDetails.id=Wph_Packing2.SizeID "+
                "left join Wph_Storage on Wph_Storage.id=StorageID " +
                "left join M_product on M_product.id=Wph_Packing2.PID "+ strsql1 + " union all "+
                "select '',Cade,Special,Item,'',Item,'','',Colour,BarCode,'',Size,Nomber,'',[ADd] from Wph_Packing" + strsql + " order by Cade";
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
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    Qty = Qty + decimal.Parse(ds.Tables[0].Rows[k]["NO"].ToString());
                }
                row2[0] = "99999";
                row2[1] = "合计";
                row2[2] = " ";
                row2[3] = "";
                row2[4] = "0";
                row2[5] = "";
                row2[6] = "";
                row2[7] = "0";
                row2[8] = "";
                row2[9] = "";
                row2[10] = "0";
                row2[11] = "";
                row2[13] = "0";
                row2[12] = Qty.ToString();
                row2[14] = "";

                ds.Tables[0].Rows.Add(row2);
            }
            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["BarCode"].HeaderText = "条型码";
            WPHbROWDGV.Columns["item_NO"].HeaderText = "款号";
            WPHbROWDGV.Columns["item_NO"].Width = 80;
            WPHbROWDGV.Columns["Wph_Item"].HeaderText = "新款号";
            WPHbROWDGV.Columns["Wph_Item"].Width = 80;
            WPHbROWDGV.Columns["SDname"].HeaderText = "尺码";
            WPHbROWDGV.Columns["SDname"].Width = 60;
            WPHbROWDGV.Columns["NO"].HeaderText = "数量";
            WPHbROWDGV.Columns["NO"].Width = 60;
            WPHbROWDGV.Columns["Cade"].HeaderText = "箱号";
            WPHbROWDGV.Columns["Cade"].Width = 120;
            WPHbROWDGV.Columns["s_color"].HeaderText = "颜色";
            WPHbROWDGV.Columns["s_color"].Width = 60;
            WPHbROWDGV.Columns["stname"].HeaderText = "目地日";
            WPHbROWDGV.Columns["stname"].Width = 80;
            WPHbROWDGV.Columns["Special"].HeaderText = "专场";
            WPHbROWDGV.Columns["Special"].Width = 120;
            WPHbROWDGV.Columns["DBid"].Visible=false;
            WPHbROWDGV.Columns["Pid"].Visible = false;
            WPHbROWDGV.Columns["M_name"].Visible = false;
            WPHbROWDGV.Columns["ColourID"].Visible = false;
            WPHbROWDGV.Columns["SizeID"].Visible = false;
            WPHbROWDGV.Columns["StorageID"].Visible = false;
            
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

        private void btnPackintBarCode_Click(object sender, EventArgs e)
        {
            try
            {
                grproLib.GridppReport Report = new grproLib.GridppReport();
                DataSet ds = new DataSet();
                SqlConnection conn = sqlcon.getcon("");
                try
                {
                    string sqlstr = "";
                    for (int i = 0; i < WPHbROWDGV.Rows.Count; i++)
                    {
                        if (WPHbROWDGV.Rows[i].Cells["Cade"].Value.ToString() != "合计")
                        {
                               sqlstr += " insert into Wph_PackingPrint(Cade,BarCode,Item,Size,Colour,Nomber,[ADd],Special) values ('" + WPHbROWDGV.Rows[i].Cells["Cade"].Value.ToString() +
                                        "','" + WPHbROWDGV.Rows[i].Cells["BarCode"].Value.ToString() + "','" + WPHbROWDGV.Rows[i].Cells["Item_no"].Value.ToString() +
                                        "','" + WPHbROWDGV.Rows[i].Cells["SDname"].Value.ToString() + "','" + WPHbROWDGV.Rows[i].Cells["s_color"].Value.ToString() +
                                        "','" + WPHbROWDGV.Rows[i].Cells["NO"].Value.ToString() + "','" + WPHbROWDGV.Rows[i].Cells["stname"].Value.ToString() + "','"
                                        + WPHbROWDGV.Rows[i].Cells["Special"].Value.ToString() + "');";
                        }
                    }

                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlstr, conn);
                    cmd.ExecuteNonQuery();
                    sqlstr = "";
                    SqlDataAdapter sqlDaper = new SqlDataAdapter("select cade,[add],Special,count(1) as counts from Wph_PackingPrint group by cade,[add],Special", conn);
                    sqlDaper.Fill(ds);
                    try
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            // % Convert.ToInt32(txtRows.Text.ToString())
                            for (int row = Convert.ToInt32(ds.Tables[0].Rows[i]["counts"].ToString()); row < 16; row++)
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

                    conn.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                if (MessageBox.Show("\n“是”直接打印，“否”打印预览！!", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Report.Print(true);

                }
                else
                {
                    Report.PrintPreview(true);
                }
                //if()
                //Report.PrintPreview(true);
                //Report.Print(true);

                conn.Open();
                SqlCommand cmdd = new SqlCommand("delete from Wph_PackingPrint", conn);
                cmdd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
