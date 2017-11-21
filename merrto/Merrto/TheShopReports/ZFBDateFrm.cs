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
    public partial class ZFBDateFrm : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        public ZFBDateFrm()
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
            ofd.Filter = "Excel文件(*.csv)|*.csv|所有文件|*.*";

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

            exceld.CSVToDataGridView(strName, this.DataDGV);
        }

        private void ZFBDateFrm_Load(object sender, EventArgs e)
        {
            this.DTdatetime.Text = (DateTime.Now.AddMonths(-1)).ToString("yyyy-MM-dd");
            this.DTPstop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT ID,Cade,ShopNAME FROM STR_Shop ", conn);
            DataSet ds = new DataSet();
            sqlDaper.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmdShop.DataSource = ds.Tables[0];
                CmdShop.ValueMember = "ID";
                CmdShop.DisplayMember = "ShopNAME";
            }
        }
        //
        private void BtnSave_Click(object sender, EventArgs e)
        {
            
            string sqlselect = "";
            for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
            {
                if (sqlselect != "")
                {
                    sqlselect += " or ";
                }
                sqlselect += " OrderCade ='" + DataDGV.Rows[i].Cells["商户订单号               "].Value.ToString().Replace("T200P", "") + "'";
            }
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_ZFBDate where cadedate='" + DTdatetime.Value.ToString("yyyy-MM-dd") + "' and " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_ZFBDate where cadedate='" + DTdatetime.Value.ToString("yyyy-MM-dd") + "' and " + sqlselect, conn);
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

                    if (DataDGV.Rows[i].Cells["商户订单号               "].Value.ToString() == "" || DataDGV.Rows[i].Cells["商户订单号               "].Value.ToString().Substring(0,5) == "T800P")
                    {
                    }
                    else{
                        DateTime dt = new DateTime();
                        DateTime.TryParse(DataDGV.Rows[i].Cells["最近修改时间              "].Value.ToString(), out dt);
                        //string dtf = ;
                       // DataDGV.Rows[i].Cells["商户订单号               "].Value.ToString()
                        if (dt >= DTdatetime.Value && dt <=this.DTPstop.Value)
                        {
                            strsql += "insert into STR_ZFBDate (SHOPid,Cade,CadeDate,OrderCade,Orderdate,sumMoney,ReturnMoney,username) values ('"
                              + CmdShop.SelectedValue.ToString() + "','ZF"
                              + DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("STR_OrderList", DTdatetime.Value.ToString("yyyyMMdd")) + "','"
                              + DTdatetime.Value.ToString("yyyy-MM-dd") + "','"
                              + DataDGV.Rows[i].Cells["商户订单号               "].Value.ToString().Replace("T200P", "").Trim() + "','"
                              + dt.ToString("yyyy-MM-dd") + "','"
                              + DataDGV.Rows[i].Cells["金额（元）   "].Value.ToString() + "','"
                              + DataDGV.Rows[i].Cells["成功退款（元）  "].Value.ToString() + "','"
                              + frmlogin.userID + "');";
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
                if (CmdShop.SelectedValue.ToString() != "")
                {
                    if (strsql != "")
                    {
                        strsql += " and ";
                    }
                    strsql += " shopid='" + CmdShop.SelectedValue.ToString() + "'";
                }
                if (DTdatetime.Value.ToString("yyyyMMdd") != "")
                {
                    if (strsql != "")
                    {
                        strsql += " and ";
                    }
                    strsql += " CadeDate='" + DTdatetime.Value.ToString("yyyy-MM-dd") + "'";
                }
                if (strsql != "")
                {
                    strsql = " where " + strsql;
                }
                strsql = "delete from STR_ZFBDate " + strsql;
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
