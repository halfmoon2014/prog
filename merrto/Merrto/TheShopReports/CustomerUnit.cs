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
    public partial class CustomerUnit : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.DATECalse dateget = new baseclass.DATECalse();
        public CustomerUnit()
        {
            InitializeComponent();
        }

        private void CustomerUnit_Load(object sender, EventArgs e)
        {
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

            exceld.CSVToDataGridView(strName, this.CustomerDGV);

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string Cade_ = "";//DTTDATE.Text.ToString().Substring(0, 4) + DTTDATE.Text.ToString().Substring(5, 2) + DTTDATE.Text.ToString().Substring(7, 2);
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_CustomerUnit where CadeDATE = '" + DTdatetime.Value.ToString("yyyy-MM-dd") + "'and shopid='" + CmdShop.SelectedValue.ToString() + "'", conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n店铺：" + CmdShop.Text.ToString() + "-日期：" + DTdatetime.Value.ToString("yyyy-MM-dd") + "数据已保存过   \n\n\n  是否从新保存  ", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_CustomerUnit where CadeDATE='" + DTdatetime.Value.ToString("yyyy-MM-dd") + "' and shopid='" +CmdShop.SelectedValue.ToString()+ "'", conn);
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
                for (int i = 0; i < CustomerDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    strsql += "insert into STR_CustomerUnit (Cade,CadeDATE,Name,CuID,BrowNO,BrowUserNo,PhotographNO,PhotographMoney,Userid,DealZNO,DealNO,DealMoney,CollectionNO,username,ShopID) values ('KD"
                        + DTdatetime.Value.ToString("yyyyMMdd") + dateget.uppacking("STR_CustomerUnit", DTdatetime.Value.ToString("yyyyMMdd")) + "','"
                        + DTdatetime.Value.ToString("yyyy-MM-dd") + "','" + CustomerDGV.Rows[i].Cells["宝贝名称"].Value.ToString() + "','" + CustomerDGV.Rows[i].Cells["宝贝ID"].Value.ToString() +
                        "','" + CustomerDGV.Rows[i].Cells["宝贝页浏览量"].Value.ToString() + "','" + CustomerDGV.Rows[i].Cells["宝贝页访客数"].Value.ToString() +
                        "','" + CustomerDGV.Rows[i].Cells["拍下件数"].Value.ToString() + "','" + CustomerDGV.Rows[i].Cells["拍下金额"].Value.ToString() + "','" +
                        CustomerDGV.Rows[i].Cells["成交用户数"].Value.ToString() + "','" +
                        CustomerDGV.Rows[i].Cells["支付宝成交笔数"].Value.ToString() + "','" +
                        CustomerDGV.Rows[i].Cells["支付宝成交件数"].Value.ToString() + "','" +
                        CustomerDGV.Rows[i].Cells["支付宝成交金额"].Value.ToString() + "','" +
                        CustomerDGV.Rows[i].Cells["宝贝页收藏量"].Value.ToString() + "','" +
                        frmlogin.userID + "','" +
                        CmdShop.SelectedValue.ToString() + "') ;";
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
                Console.WriteLine(ex.Message);
            }
        }
    }
}
