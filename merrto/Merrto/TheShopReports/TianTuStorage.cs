using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.TheShopReports
{
    public partial class TianTuStorage : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        public TianTuStorage()
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
            ofd.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx|所有文件|*.*";
            //ofd.Filter = "Excel文件(*.csv)|*.csv|所有文件|*.*";

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

            exceld.ExcelToDataGridView(strName,"Select * from", "Sheet1", this.DataDGV,0,new DataTable());
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
           
            string strsql = "";
            
            try
            {
                for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    if (DataDGV.Rows[i].Cells["条形码"].Value.ToString() == "")
                    {
                    }
                    else
                    {//网店名称
                        strsql += "insert into Str_TianTuStorage (storageID,BarCode,Qty) values ('"
                             + CmdStorage.SelectedValue.ToString() + "','"
                          + DataDGV.Rows[i].Cells["条形码"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["可分配"].Value.ToString() + "');";
                    }//
                    
                }

                conn.Open();
                strsql = strsql.Replace("'", "''");
                strsql = strsql.Replace("'',''", "','");
                strsql = strsql.Replace("(''", "('");
                strsql = strsql.Replace("'')", "')");
                strsql = "delete from Str_TianTuStorage where storageID='" + CmdStorage.SelectedValue.ToString() + "'; " + strsql;
                strsql += "update Str_TianTuStorage set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                        "left join M_productsub on M_productsub.pid=M_product.id " +
                        "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                        "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                        "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=Str_TianTuStorage.BarCode ;";
                strsql += "update Str_TianTuStorage set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                       "left join M_productsub on M_productsub.pid=M_product.id "+
                       "left join m_ProductSize on m_ProductSize.pid=M_product.id "+
                       "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid "+
						"left join wph_product on M_product.id=wph_product.Pid and M_productsub.id=Colourid "+
                       "where cast(Wph_item as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=Str_TianTuStorage.BarCode";
                 //strsql = " update STR_OrderDetailList set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                 //       "left join M_productsub on M_productsub.pid=M_product.id " +
                 //       "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                 //       "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                 //       "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=STR_OrderDetailList.BarCode ;" +
                 //       "update STR_OrderDetailList set PID=M_product.id from M_product where ITEM_NO=STR_OrderDetailList.BarCode " +
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新失败！", "系统提示：", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
            }
        
        }

        private void TianTuStorage_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select Name,ID from Wph_Storage ", conn);
            conn.Open();
            sqlDaper.Fill(ds, "Storage");
            CmdStorage.DataSource = ds.Tables["Storage"];
            CmdStorage.ValueMember = "ID";
            CmdStorage.DisplayMember = "Name";
        }
    }
}
