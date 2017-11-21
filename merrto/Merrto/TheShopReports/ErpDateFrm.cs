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
    public partial class ErpDateFrm : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        DataTable dt = new DataTable();
        public ErpDateFrm()
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

            exceld.ExcelToDataGridView(strName,"select * from ", "导出订单明细", this.DataDGV,0,dt);
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
                sqlselect += " OrderCade ='" + DataDGV.Rows[i].Cells["网店订单号"].Value.ToString() + "'";
            }
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from Str_ErpDate where  cadedate='" + DTdatetime.Value.ToString("yyyy-MM-dd") + "' and " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Str_ErpDate where  cadedate='" + DTdatetime.Value.ToString("yyyy-MM-dd") + "' and " + sqlselect + "delete from Str_erporder where " + sqlselect, conn);
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
                    if (DataDGV.Rows[i].Cells["实收金额"].Value.ToString() == "")
                    {
                    }
                    else
                    {//网店名称
                        DateTime dt = new DateTime();
                        DateTime.TryParse(DataDGV.Rows[i].Cells["发货时间"].Value.ToString(), out dt);

                        strsql += "insert into Str_ErpDate (SHOPname,Cade,CadeDate,OrderCade,sumMoney,OrderDate,username) values ('"
                          + DataDGV.Rows[i].Cells["网店名称"].Value.ToString() + "','FH"
                          + DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("Str_ErpDate", DTdatetime.Value.ToString("yyyyMMdd")) + "','"
                          + DTdatetime.Value.ToString("yyyy-MM-dd") + "','"
                          + DataDGV.Rows[i].Cells["网店订单号"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["实收金额"].Value.ToString() + "','"
                          + dt.ToString("yyyy-MM-dd") + "','"
                          + frmlogin.userID + "');";
                        
                        string[] str = DataDGV.Rows[i].Cells["网店订单号"].Value.ToString().Split(new char[] { '|' });
                        int num = str.Length;
                        for (int s = 0; s < num; s++)
                        {
                            strsql += "insert into Str_erporder(orderCade,ordercades,orderDate)values('" + DataDGV.Rows[i].Cells["网店订单号"].Value.ToString() + "','" + str[s] + "','" + dt.ToString("yyyy-MM-dd") + "')";
                        }
                    }//
                }

                conn.Open();
                strsql = strsql.Replace("'", "''");
                strsql = strsql.Replace("'',''", "','");
                strsql = strsql.Replace("(''", "('");
                strsql = strsql.Replace("'')", "')");
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

        private void BTNDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string strsql = "";
               
                if (DTdatetime.Value.ToString("yyyyMMdd") != "")
                {
                    if (strsql != "")
                    {
                        strsql += " and ";
                    }
                    strsql += " OrderDate='" + DTdatetime.Value.ToString("yyyy-MM-dd") + "'";
                }
                if (strsql != "")
                {
                    strsql = " where " + strsql;
                }
                strsql = "delete from Str_erporder " + strsql + ";delete from Str_ErpDate " + strsql;
                conn.Open();
                SqlCommand cmd = new SqlCommand(strsql, conn);

                cmd.ExecuteNonQuery();
                conn.Close();


                MessageBox.Show("数据删除成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据删除失败！", "系统提示：", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
            }
        }

        
    }
}
