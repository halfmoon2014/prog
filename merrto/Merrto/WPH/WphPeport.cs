using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Transactions;

namespace Merrto
{
    public partial class WphPeport : Form
    {
        public WphPeport()
        {
            InitializeComponent();
        }
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.sqldatacon sqlcon =new baseclass.sqldatacon();
        baseclass.DATECalse Dc = new baseclass.DATECalse();
        DataTable dt = new DataTable();
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
            //for (int i = 0; i < this.ExcelDGV.Columns.Count; i++)
            //{
            //    Cbocolumnprint.Items.Add(this.ExcelDGV.Columns[i].HeaderText);
            //}
        }

        private void BindData()
        {

            DataTable dtData = new DataTable();
            dtData.Columns.Add("货号");
            dtData.Columns.Add("数量");
            DataRow drData;
            drData = dtData.NewRow();
            this.ExcelDGV.DataSource = dtData;
            ExcelDGV.Columns["货号"].Width = 90;
            ExcelDGV.Columns["数量"].Width = 60;
          }

        

        private void WphPeport_Load(object sender, EventArgs e)
        {
            DTTDATE.Text = DateTime.Now.ToShortDateString();
            BindData();
        }

        private void BTNPacking_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = sqlcon.getcon("");
            conn.Open();
            SqlDataAdapter da1 = new SqlDataAdapter("select Max(ID) as ID from Wph_Report", conn);
            da1.Fill(ds);
            conn.Close();
            int ID_=0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                ID_ = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString()==""?"0":ds.Tables[0].Rows[0]["ID"].ToString());
            }
            ds = new DataSet();
            if (txtSpecial.Text.ToString() != "")
            {
                string strsql = "";
                string strid = "";
                for (int i = 0; i < ExcelDGV.Rows.Count; i++)
                {
                    if (strsql != "")
                    {
                        strsql += " union all ";
                        ID_ = ID_ + 1 * 100;
                    }
                    
                    if (ExcelDGV.Rows[i].Cells[1].Value.ToString() != "0")
                    {
                        strsql += "select " + ID_ + "+(RANK() OVER (ORDER BY m_product.id,m_productSub.ID,m_SizeDetails.id,StorageID DESC)) AS id,'" 
                            + Dc.uppacking("Wph_Report", DateTime.Now.ToString("yyyyMMdd"), "WB") + "' as Cade,'"+ DTTDATE.Value.ToString("yyyy-MM-dd") + "' as Date,'" 
                            + txtSpecial.Text.ToString() +"' as Special,m_product.id as PID,m_productSub.ID AS ColourID,m_SizeDetails.id as SizeID,StorageID,item_no,price_tag,SDPrice," +
                            "round(SDPrice*0.7,1) as SPPrice,s_color,m_SizeDetails.Name as SDname,case when round(" + ExcelDGV.Rows[i].Cells[1].Value.ToString() + "*S_WithCade.Matching/sums*Proportion,0)-isnull(temptt.Qty,0)<=0 then 0 else (round( "
                            + ExcelDGV.Rows[i].Cells[1].Value.ToString() + "*S_WithCade.Matching/sums*Proportion,0)-isnull(temptt.Qty,0))end as Qty,Wph_Storage.name as STname, " +
                            "case when round(" + ExcelDGV.Rows[i].Cells[1].Value.ToString() + "*S_WithCade.Matching/sums*Proportion,0)-isnull(temptt.Qty,0)<=0 then 0 else SDPrice*(round(" + ExcelDGV.Rows[i].Cells[1].Value.ToString() + "*S_WithCade.Matching/sums*Proportion,0)-isnull(temptt.Qty,0))end as stmoney from m_product " +
                            "left join wph_product on m_product.id=wph_product.pid " +
                            "left join m_productSub on wph_product.Colourid=m_productSub.id " +
                            "left join WPh_Category on WPh_Category.id=wph_product.cid " +
                            "left join m_ProductSize on m_ProductSize.pid=m_product.id " +
                            "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                            "left join Wph_Proportion on Wph_Proportion.pid=m_product.id  " +
                            "left join Wph_Storage on StorageID=Wph_Storage.id " +
                            "left join S_WithCade on S_WithCade.SDid=m_SizeDetails.ID and S_WithCade.pid=m_product.id " +
                            "left join (select sum (Matching) as sums,pid from S_WithCade group by pid) as temp on temp.pid=m_product.id " +
                            "left join (select Pid,colourID,storageID as STID,SdID,sum(Qty) Qty from Str_TianTuStorage group by PID,SdID,storageID,colourID)temptt on temptt.pid=m_product.id and temptt.StID=storageID and temptt.colourID=m_productSub.id  and temptt.SdID=m_SizeDetails.id " +
                            "where item_no+cast(CO_CODE as varchar(5))='" + ExcelDGV.Rows[i].Cells[0].Value.ToString() + "' and S_WithCade.Matching!=0 ";
                        //and " +"exists(select * from m_ProductCategory where m_product.Fid=m_ProductCategory.ID and m_ProductCategory.title like '%鞋%') 
                    }
                }
                
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(strsql, conn);
                da.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];
                this.ProudctDGV.DataSource = ds.Tables[0];
                this.ProudctDGV.Columns["pid"].Visible = false;
                this.ProudctDGV.Columns["ColourID"].Visible = false;
                this.ProudctDGV.Columns["sizeid"].Visible = false;
                this.ProudctDGV.Columns["ID"].Visible = false;
                this.ProudctDGV.Columns["StorageID"].Visible = false;
                this.ProudctDGV.Columns["Special"].Visible = false;
                this.ProudctDGV.Columns["Date"].Visible = false;
                this.ProudctDGV.Columns["cade"].Visible = false;
                this.ProudctDGV.Columns["item_no"].HeaderText = "款号";
                this.ProudctDGV.Columns["item_no"].Width = 60;
                this.ProudctDGV.Columns["SDname"].HeaderText = "商品规格";
                this.ProudctDGV.Columns["SDname"].Width = 80;
                this.ProudctDGV.Columns["STname"].HeaderText = "仓库";
                this.ProudctDGV.Columns["STname"].Width = 80;
                this.ProudctDGV.Columns["s_color"].HeaderText = "颜色";
                this.ProudctDGV.Columns["s_color"].Width = 60;
                this.ProudctDGV.Columns["price_tag"].HeaderText = "正品价";
                this.ProudctDGV.Columns["price_tag"].Width = 70;
                this.ProudctDGV.Columns["Qty"].HeaderText = "数量";
                this.ProudctDGV.Columns["Qty"].Width = 80;
                this.ProudctDGV.Columns["SDPrice"].HeaderText = "折后标准售卖价";
                this.ProudctDGV.Columns["SDPrice"].Width = 120;
                this.ProudctDGV.Columns["spprice"].HeaderText = "供货价";
                this.ProudctDGV.Columns["spprice"].Width = 70;
                this.ProudctDGV.Columns["stmoney"].HeaderText = "金额";
                this.ProudctDGV.Columns["stmoney"].Width = 70;
            }
            else
            {
                MessageBox.Show("专场名称不能为空！");
            }
            
        }

        private void BtnOPExcel_Click(object sender, EventArgs e)
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
                        if (ProudctDGV[j, i].Visible == true)
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
                }
                excel.Visible = true;
            }
            else
            {
                MessageBox.Show("没有你要导的数据！！！");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //string Cade_="";//DTTDATE.Text.ToString().Substring(0, 4) + DTTDATE.Text.ToString().Substring(5, 2) + DTTDATE.Text.ToString().Substring(7, 2);
            //SqlConnection conn = sqlcon.getcon("");
            //DataSet ds = new DataSet();
            //string sqlselect;
            //sqlselect = "select max(cade) as cade from Wph_Report where cade like '%" + DTTDATE.Value.ToString("yyyyMMdd") + "%'";
            //SqlDataAdapter sqlDaper = new SqlDataAdapter(sqlselect, conn);
            //conn.Open();
            //sqlDaper.Fill(ds);
            //if (ds.Tables[0].Rows[0]["Cade"].ToString() == "")
            //{
            //    Cade_ = "0001";
            //}
            //else
            //{
            //    Cade_ = ("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(ds.Tables[0].Rows[0]["Cade"].ToString().Length - 4, 4)) + 1).ToString())
            //        .Substring(("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(ds.Tables[0].Rows[0]["Cade"].ToString().Length - 4, 4)) + 1).ToString()).Length-4,4);
            //}
            //conn.Close();

            //string strsql = "";
            //try
            //{
            //    for (int i = 0; i < ProudctDGV.Rows.Count; i++)//得到总行数并在之内循环
            //    {
            //        strsql += "insert into Wph_Report (Cade,Date,Special,pid,SPPrice,ColourID,SizeID,NO,StorageID) values ('WB" + DTTDATE.Value.ToString("yyyyMMdd") + Cade_ + "','"
            //            + DTTDATE.Value.ToString("yyyy-MM-dd") + "','" + txtSpecial.Text.ToString() + "','" + ProudctDGV.Rows[i].Cells["Pid"].Value.ToString() +
            //            "','" + ProudctDGV.Rows[i].Cells["SPPrice"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["ColourID"].Value.ToString() +
            //            "','" + ProudctDGV.Rows[i].Cells["SizeID"].Value.ToString() + "','" + ProudctDGV.Rows[i].Cells["NOs"].Value.ToString() + "','" +
            //            ProudctDGV.Rows[i].Cells["StorageID"].Value.ToString() + "') ;";
            //    }
            //    //    //for (int j = 0; j < cell; j++)//得到总列数并在之内循环
            //    //    //{
            //    //    string Product = ProudctDGV.Rows[i].Cells[3].Value.ToString();
            //    //    string ok_ = ProudctDGV.Rows[i].Cells[0].Value.ToString();
            //    //    //}
            //    //    string str = "select * from Wph_Report where sizeid='" + sizeid + "' and pid='" + Product + "'";
            //    //    SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
            //    //    DataSet ds = new DataSet();

            //    //    conn.Open();
            //    //    sqldaper.Fill(ds);
            //    //    if (ok_ == "True")
            //    //    {
            //    //        if (ds.Tables[0].Rows.Count <= 0)
            //    //        {
            //    //            strsql += "insert into m_ProductSize(sizeid,pid) values (" + sizeid + "," + Product + ") ";
            //    //        }
            //    //        conn.Close();
            //    //    }
            //    //    if (ok_ == "False")
            //    //    {
            //    //        if (ds.Tables[0].Rows.Count > 0)
            //    //        {
            //    //            strsql += "delete from m_ProductSize where sizeid='" + sizeid + "' and pid='" + Product + "' ";
            //    //        }
            //    //        conn.Close();
            //    //    }
            //    //}
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand(strsql, conn);
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //    MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            string sqlselect = "";
            //for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
            //{
            //    if (sqlselect != "")
            //    {
            //        sqlselect += " or ";
            //    }
            //    sqlselect += " OrderCade ='" + DataDGV.Rows[i].Cells["OrderCade"].Value.ToString() + "'";
            //}
            dt.Columns.Remove("item_no");

            dt.Columns.Remove("SDname");
         
            dt.Columns.Remove("STname");
          
            dt.Columns.Remove("s_color");
           
            dt.Columns.Remove("price_tag");
           
            dt.Columns.Remove("SDPrice");
           
            dt.Columns.Remove("stmoney");

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from Wph_Report where Special='" + txtSpecial.Text.ToString() + "'", conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n该专场已存在，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Wph_Report where Special='" + txtSpecial.Text.ToString() + "'", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    return;
                }
            }
            
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    conn.Open();
                    using (SqlBulkCopy sbc = new SqlBulkCopy(conn))
                    {
                        ////服务器上目标表的名称     
                        sbc.DestinationTableName = "Wph_Report";
                        sbc.WriteToServer(dt);
                        scope.Complete();//有效的事务     
                    }
                    conn.Close();
                }
                ////} 
                             
                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新失败！", "系统提示：", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
            }
            ProudctDGV.DataSource = "";   
        }
    }
}
