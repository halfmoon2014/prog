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
    public partial class BrushSingleData : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        public BrushSingleData()
        {
            InitializeComponent();
        }

        private void BrushSingleData_Load(object sender, EventArgs e)
        {
            //SqlConnection conn = sqlcon.getcon("");
            //SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT ID,Cade,ShopNAME FROM STR_Shop ", conn);
            //DataSet ds = new DataSet();
            //sqlDaper.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    CmdShop.DataSource = ds.Tables[0];
            //    CmdShop.ValueMember = "ID";
            //    CmdShop.DisplayMember = "ShopNAME";
            //}
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sqlselect = "";
            for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
            {
                if (sqlselect != "")
                {
                    sqlselect += " or ";
                }
                sqlselect += " OrderCade ='" + DataDGV.Rows[i].Cells["订单号"].Value.ToString().Replace("T200P", "") + "'";
            }
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_BrushSingleData where cadedate='" + DTdatetime.Value.ToString("yyyy-MM-dd") + "' and " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_BrushSingleData where cadedate='" + DTdatetime.Value.ToString("yyyy-MM-dd") + "' and " + sqlselect, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    return;
                }
            }

            string strsql = "";
            try
            {
                for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    if (DataDGV.Rows[i].Cells["订单号"].Value.ToString().Trim() != "")
                    {
                        strsql += "insert into STR_BrushSingleData (SHOPName,Cade,CadeDate,OrderCade,Orderdate,sumMoney,BarCode,Qty,username) values ('"
                          + DataDGV.Rows[i].Cells["铺名"].Value.ToString().Trim() + "','SD"
                          + DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("STR_BrushSingleData", DTdatetime.Value.ToString("yyyyMMdd")) + "','"
                          + DTdatetime.Value.ToString("yyyy-MM-dd") + "','"
                          + DataDGV.Rows[i].Cells["订单号"].Value.ToString().Trim() + "','"
                          + DataDGV.Rows[i].Cells["日期"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["金额"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["货号"].Value.ToString().Trim() + "','"
                          + DataDGV.Rows[i].Cells["数量"].Value.ToString() + "','"
                          + frmlogin.userID + "');";
                    }

                }

                conn.Open();
                strsql = strsql.Replace("'", "''");
                strsql = strsql.Replace("'',''", "','");
                strsql = strsql.Replace("(''", "('");
                strsql = strsql.Replace("'')", "')");
                strsql += " update STR_BrushSingleData set PID=M_product.id from M_product where STR_BrushSingleData.barcode=M_product.item_no";
                strsql += " update STR_BrushSingleData set ShopID=STR_Shop.id from STR_Shop where STR_BrushSingleData.shopname=STR_Shop.shopname";
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

        private void BtnEXCEL_Click(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Filter = "Excel文件(*.xls)|*.xls|所有文件|*.*";
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

            exceld.ExcelToDataGridView(strName, this.DataDGV);
        }
    }
}
