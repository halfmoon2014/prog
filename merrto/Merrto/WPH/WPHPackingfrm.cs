using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using grproLib;

namespace Merrto.WPH
{
    public partial class WPHPackingfrm : Form
    {
        private GridppReport Report = new GridppReport();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.xmldataset xmldate = new baseclass.xmldataset();
        baseclass.getChar getC = new baseclass.getChar();
        private string xhname = "";
        public WPHPackingfrm()
        {
            InitializeComponent();
        }

        private void btnPackintBarCode_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            //if (txtSpecial.Text.ToString() != "")
            //{
            printdate();
            //for (int i = 0; i < Convert.ToInt32(TXTPrintNO.Text.ToString()); i++)
            //{
            Report.Print(true);
            //}
            conn.Open();
            SqlCommand cmdd = new SqlCommand("delete from Wph_PackingPrint", conn);
            cmdd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("数据保存成功！", "系统提示：", MessageBoxButtons.OK);

            //}
            //else
            //{
            //    MessageBox.Show("专场名称为空不能打印！！");
            //}
            if (MessageBox.Show("\n数据已打印！！   \n\n\n确认是否保存(Y/N)", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                DataSave();
            }
        }
        private void printdate()
        {
            DataSet ds = new DataSet();
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string sqlstr = "";
                for (int i = 0; i < DistriButionDGV.Rows.Count; i++)
                {
                    sqlstr += " insert into Wph_PackingPrint(Cade,BarCode,Item,Size,Colour,Nomber,[ADd],Special) values ('"
                        + DistriButionDGV.Rows[i].Cells["Cade"].Value.ToString() +"','"
                        + DistriButionDGV.Rows[i].Cells["BarCode"].Value.ToString() + "','"
                        + DistriButionDGV.Rows[i].Cells["Wph_Item"].Value.ToString() +"','" 
                                    + DistriButionDGV.Rows[i].Cells["SDName"].Value.ToString() + "','"
                                    + DistriButionDGV.Rows[i].Cells["s_color"].Value.ToString() +"','" 
                                    + DistriButionDGV.Rows[i].Cells["NO"].Value.ToString() + "','"
                                    + Cmbstorange.Text.ToString() + "','"
                                    + CmbSpecial.Text.ToString() + "');";
                }

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr, conn);
                cmd.ExecuteNonQuery();
                sqlstr = "";
                SqlDataAdapter sqlDaper = new SqlDataAdapter("select cade,[add],Special,count(1) as counts from Wph_PackingPrint group by cade,[add],Special", conn);
                sqlDaper.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    // % Convert.ToInt32(txtRows.Text.ToString())
                    for (int row = Convert.ToInt32(ds.Tables[0].Rows[i]["counts"].ToString()); row < 16; row++)
                    {
                        sqlstr += " insert into Wph_PackingPrint(Cade,[ADd],Special) values ('"
                            + ds.Tables[0].Rows[i]["cade"].ToString() + "','" + Cmbstorange.Text.ToString() + "','" + ds.Tables[0].Rows[i]["Special"].ToString() + "');";
                    }
                }
                cmd = new SqlCommand(sqlstr, conn);
                cmd.ExecuteNonQuery();


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
        }
        private void DataSave()
        {

            DataSet ds = new DataSet();
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string sqlstr = "";
                string sqlselect = "";
                for (int i = 0; i < DistriButionDGV.Rows.Count; i++)
                {
                    if (sqlselect != "")
                    {
                        sqlselect += " or ";
                    }
                    sqlselect += "cade='" + DistriButionDGV.Rows[i].Cells["Cade"].Value.ToString() + "'";
                    if (chkLast.Checked == false)
                    {
                        if (DistriButionDGV.Rows[i].Cells["Cade"].Value.ToString() != xhname)
                        {
                            sqlstr += " insert into Wph_Packing2(DBID,Date,Special,Pid,SizeID,ColourID,NO,StorageID,Cade,Verify) values ('"
                                        + DistriButionDGV.Rows[i].Cells["DBID"].Value.ToString() +"','"
                                        + DTDate.Value.ToString("yyyy-MM-dd") + "','"
                                        + DistriButionDGV.Rows[i].Cells["Special"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["Pid"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["SizeID"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["ColourID"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["NO"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["StorageID"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["Cade"].Value.ToString() + "','0');";
                        }
                    }
                    else
                    {
                        sqlstr += " insert into Wph_Packing2(DBID,Date,Special,Pid,SizeID,ColourID,NO,StorageID,Cade,Verify) values ('"
                                        + DistriButionDGV.Rows[i].Cells["DBID"].Value.ToString() + "','"
                                        + DTDate.Value.ToString("yyyy-MM-dd") + "','"
                                        + DistriButionDGV.Rows[i].Cells["Special"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["Pid"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["SizeID"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["ColourID"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["NO"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["StorageID"].Value.ToString() + "','"
                                        + DistriButionDGV.Rows[i].Cells["Cade"].Value.ToString() + "','0');";
                    }
                }

                sqlselect = "select * from Wph_Packing2 where " + sqlselect;
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

        private void WPHPackingfrm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            conn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select distinct Special from Wph_Report", conn);
            sqlda.Fill(ds, "special");
            this.CmbSpecial.DataSource = ds.Tables["special"];
            this.CmbSpecial.DisplayMember = "Special";
            SqlDataAdapter sqlda1 = new SqlDataAdapter("select * from Wph_Storage", conn);
            sqlda1.Fill(ds, "Storage");
            this.Cmbstorange.DataSource = ds.Tables["Storage"];
            this.Cmbstorange.ValueMember = "ID";
            this.Cmbstorange.DisplayMember = "Name";
            conn.Close();
            //TxtOneNo.Text = uppacking();
        }

        private string uppacking()
        {
            string Cade_ = "";
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            string sqlselect;
            sqlselect = "select max(cade) as cade from Wph_Packing2 where cade like '" + ADD() + DTDate.Value.ToString("yyyyMMdd") + "%'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            if (ds.Tables[0].Rows[0]["Cade"].ToString() == "")
            {
                Cade_ = "0001";
            }
            else
            {

                Cade_ = ("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(TxtAddre.Text.ToString().Length +
                     DTDate.Value.ToString("yyyyMMdd").Length, 4)) + 1).ToString()).Substring(("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(TxtAddre.Text.ToString().Length +
                    DTDate.Value.ToString("yyyyMMdd").Length, 4)) + 1).ToString()).Length - 4, 4);
            }
            conn.Close();
            return Cade_;
        }
        private string ADD()
        {
            string strTemp = "";
            int iLen = Cmbstorange.Text.ToString().Length;
            int i = 0;
            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += getC.GetCharSpellCode(Cmbstorange.Text.ToString().Substring(i, 1));
            }
            return strTemp;
        }

        private void Cmbstorange_SelectedValueChanged(object sender, EventArgs e)
        {
            TxtAddre.Text = ADD();
            TxtOneNo.Text = uppacking();
        }

        private void BtnBrow_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            conn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select Wph_Distribution.ID as DBid,Wph_Distribution.Cade,Wph_Distribution.Special," +
                   "isnull(Wph_Item,'')+cast(CO_CODE as varchar(5))+cast(m_SizeDetails.cade as varchar(5)) as BarCode," +
                    "Wph_Distribution.Pid,item_NO,Wph_Item,M_name,Wph_Distribution.ColourID,s_color," +
                    "Wph_Distribution.SizeID,m_SizeDetails.name as SDname,isnull(Wph_Distribution.[Qty],'0') as PHNO,isnull(temp.[no],'0') as ZXno," +
                    "Wph_Distribution.[Qty]-isnull(temp.[no],'0') as [NO],Wph_Distribution.StorageID from Wph_Distribution " +
                    "left join (select DBid,ColourID,SizeID,pid,sum([no]) as [no] from  Wph_Packing2 "+
                    "group by DBid,ColourID,SizeID,pid) as temp "+
                     "on temp.DBID=Wph_Distribution.id and temp.ColourID=Wph_Distribution.ColourID "+
                     "and temp.SizeID=Wph_Distribution.SizeID and temp.pid=Wph_Distribution.pid "+
                    "left join M_productsub  on M_productsub.id=Wph_Distribution.ColourID "+
                    "left join m_SizeDetails on m_SizeDetails.id=Wph_Distribution.SizeID "+
                    "left join M_product on M_product.id=Wph_Distribution.PID " +
                    "left join Wph_Product on Wph_Product.pid=Wph_Distribution.PID " +
                    "where Wph_Distribution.[Qty]-isnull(temp.[no],'0')>0 and Wph_Distribution.Special='"
                    + this.CmbSpecial.Text.ToString() +
                    "' and Wph_Distribution.StorageID='" + this.Cmbstorange.SelectedValue.ToString() + "'", conn);
            sqlda.Fill(ds);
            DataTable dtResult =ds.Tables[0].Clone();
            int NO = 0;
            int ns = 1;
            int paressno = Convert.ToInt32(TxtOneNo.Text.ToString());
            for (int i = 0; i <ds.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < Convert.ToInt32(ds.Tables[0].Rows[i]["NO"].ToString()); j++)
                {

                    if (NO == Convert.ToInt32(TXTPackNO.Text.ToString()) - 1)
                    {
                        DataRow dr = dtResult.NewRow();
                        dr["DBid"] = ds.Tables[0].Rows[i]["DBid"].ToString();
                        dr["Cade"] = TxtAddre.Text.ToString() + DTDate.Value.ToString("yyyyMMdd") + ("000" + paressno).Substring(("000" + paressno).Length - 4, 4);
                        dr["Special"] = ds.Tables[0].Rows[i]["Special"].ToString();
                        dr["Pid"] = ds.Tables[0].Rows[i]["Pid"].ToString();
                        dr["item_NO"] = ds.Tables[0].Rows[i]["item_NO"].ToString();
                        dr["M_name"] = ds.Tables[0].Rows[i]["M_name"].ToString();
                        dr["ColourID"] = ds.Tables[0].Rows[i]["ColourID"].ToString();
                        dr["s_color"] = ds.Tables[0].Rows[i]["s_color"].ToString();
                        dr["SizeID"] = ds.Tables[0].Rows[i]["SizeID"].ToString();
                        dr["BarCode"] = ds.Tables[0].Rows[i]["BarCode"].ToString();
                        dr["SDname"] = ds.Tables[0].Rows[i]["SDname"].ToString();
                        dr["PHNO"] = ds.Tables[0].Rows[i]["PHNO"].ToString();
                        dr["ZXno"] = ds.Tables[0].Rows[i]["ZXno"].ToString();
                        dr["Wph_Item"] = ds.Tables[0].Rows[i]["Wph_Item"].ToString();
                        dr["NO"] = ns;
                        dr["StorageID"] = ds.Tables[0].Rows[i]["StorageID"].ToString();
                        dtResult.Rows.Add(dr);
                        paressno++;
                        NO = 0;
                        ns = 1;
                    }
                    else if (j == Convert.ToInt32(ds.Tables[0].Rows[i]["NO"].ToString()) - 1)
                    {
                        DataRow dr = dtResult.NewRow();
                        dr["DBid"] = ds.Tables[0].Rows[i]["DBid"].ToString();
                        dr["Cade"] = TxtAddre.Text.ToString() + DTDate.Value.ToString("yyyyMMdd") + ("000" + paressno).Substring(("000" + paressno).Length - 4, 4);
                        dr["Special"] = ds.Tables[0].Rows[i]["Special"].ToString();
                        dr["Pid"] = ds.Tables[0].Rows[i]["Pid"].ToString();
                        dr["item_NO"] = ds.Tables[0].Rows[i]["item_NO"].ToString();
                        dr["M_name"] = ds.Tables[0].Rows[i]["M_name"].ToString();
                        dr["ColourID"] = ds.Tables[0].Rows[i]["ColourID"].ToString();
                        dr["s_color"] = ds.Tables[0].Rows[i]["s_color"].ToString();
                        dr["SizeID"] = ds.Tables[0].Rows[i]["SizeID"].ToString();
                        dr["BarCode"] = ds.Tables[0].Rows[i]["BarCode"].ToString();
                        dr["SDname"] = ds.Tables[0].Rows[i]["SDname"].ToString();
                        dr["PHNO"] = ds.Tables[0].Rows[i]["PHNO"].ToString();
                        dr["ZXno"] = ds.Tables[0].Rows[i]["ZXno"].ToString();
                        dr["Wph_Item"] = ds.Tables[0].Rows[i]["Wph_Item"].ToString();
                        dr["NO"] = ns;
                        dr["StorageID"] = ds.Tables[0].Rows[i]["StorageID"].ToString();
                        dtResult.Rows.Add(dr);
                        ns = 1;
                        NO += 1;
                    }
                    else
                    {
                        ns++;
                        NO += 1;
                    }
                }
            }
            DistriButionDGV.DataSource = dtResult;
            conn.Close();
            DistriButionDGV.Columns["Special"].HeaderText = "专场";
            DistriButionDGV.Columns["Special"].ReadOnly = true;
            DistriButionDGV.Columns["Special"].Visible = false;
            DistriButionDGV.Columns["s_color"].HeaderText = "颜色";
            DistriButionDGV.Columns["s_color"].Width = 60;
            DistriButionDGV.Columns["s_color"].ReadOnly = true;
            DistriButionDGV.Columns["BarCode"].HeaderText = "条型码";
            DistriButionDGV.Columns["BarCode"].Width = 100;
            DistriButionDGV.Columns["BarCode"].ReadOnly = true;
            DistriButionDGV.Columns["SDname"].HeaderText = "尺码";
            DistriButionDGV.Columns["SDname"].Width = 60;
            DistriButionDGV.Columns["SDname"].ReadOnly = true;
            DistriButionDGV.Columns["PHNO"].HeaderText = "配货数";
            DistriButionDGV.Columns["PHNO"].ReadOnly = true;
            DistriButionDGV.Columns["ZXno"].HeaderText = "装箱数";
            DistriButionDGV.Columns["ZXno"].ReadOnly = true;
            DistriButionDGV.Columns["ZXno"].Width = 70;
            DistriButionDGV.Columns["Cade"].HeaderText = "装箱号";
            DistriButionDGV.Columns["Cade"].Width = 100;
            DistriButionDGV.Columns["Cade"].ReadOnly = true;
            DistriButionDGV.Columns["NO"].HeaderText = "本单数";
            DistriButionDGV.Columns["NO"].Width = 70;
            DistriButionDGV.Columns["item_NO"].HeaderText = "款号";
            DistriButionDGV.Columns["item_NO"].Width = 70;
            DistriButionDGV.Columns["item_NO"].ReadOnly = true;
            DistriButionDGV.Columns["Wph_Item"].HeaderText = "新款号";
            DistriButionDGV.Columns["Wph_Item"].Width = 70;
            DistriButionDGV.Columns["Wph_Item"].ReadOnly = true;
            DistriButionDGV.Columns["M_name"].HeaderText = "品名";
            DistriButionDGV.Columns["M_name"].Width = 60;
            DistriButionDGV.Columns["M_name"].ReadOnly = true;
            DistriButionDGV.Columns["DBid"].Visible = false;
            DistriButionDGV.Columns["Pid"].Visible = false;
            DistriButionDGV.Columns["ColourID"].Visible = false;
            DistriButionDGV.Columns["SizeID"].Visible = false;
            DistriButionDGV.Columns["StorageID"].Visible = false;
            if (NO != Convert.ToInt32(this.TXTPackNO.Text.ToString()) && NO != 0)
            {
                xhname = this.TxtAddre.Text.ToString() +DTDate.Value.ToString("yyyyMMdd") + ("000" + paressno).Substring(("000" + paressno).Length - 4, 4);
                if (MessageBox.Show("\n此数据是否为最此专场的最后一批数据！!", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    chkLast.Checked = true;
                }
                else
                {
                    chkLast.Checked = false;
                }
            }
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataSave();
        }
    }
}
