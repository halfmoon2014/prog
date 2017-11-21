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

namespace Merrto.TheShopReports
{
    public partial class ActualOrderList : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        DataTable dt = new DataTable();
        public ActualOrderList()
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
            ofd.Filter = "Excel文件(*.csv)|*.csv|Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx|所有文件|*.*";

            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            string strsql = "select 订单编号 as OrderCade,买家会员名 as VIP,买家支付宝账号 as VIPAccount,买家应付货款 as PayMentForGoods,买家应付邮费  as Express,买家支付积分 as integral," +
                                 "买家实际支付金额 as sumMoney,返点积分 as GetIntegral,订单状态 as Type,收货人姓名 as VipName,收货地址  as VipADD,订单创建时间 as orderDate,'AO" +
                             DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("Str_ActualOrderList", DTdatetime.Value.ToString("yyyyMMdd")) +
                             "' as Cade,'" + DTdatetime.Value.ToString("yyyy-MM-dd") +
                             "' as CadeDate,宝贝标题 as BobyName,宝贝总数量 as BobyNom,'" + frmlogin.userID + "' as userName,'" + CmdShop.SelectedValue.ToString() + "' as SHOPid,物流公司 as ExpressName," +
                               "订单备注 as Remarks from ";

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
            DataDGV.DataSource = "";
            dt = new DataTable();
            if (strName.IndexOf((".csv")) != -1)
            {
                exceld.CSVToDataGridView(strName, strsql, this.DataDGV, dt, 1);
            }
            else
            {
                exceld.ExcelToDataGridView(strName, strsql, "", this.DataDGV, 1, dt);
            }
            DataDGV.Columns["OrderCade"].HeaderText = "网络订单";
            DataDGV.Columns["VIP"].HeaderText = "买家会员名";
            DataDGV.Columns["VIPAccount"].HeaderText = "买家支付宝账号";
            DataDGV.Columns["PayMentForGoods"].HeaderText = "买家应付货款";
            DataDGV.Columns["Express"].HeaderText = "买家应付邮费";
            DataDGV.Columns["integral"].HeaderText = "买家支付积分";
            DataDGV.Columns["sumMoney"].HeaderText = "买家实际支付金额";
            DataDGV.Columns["GetIntegral"].HeaderText = "返点积分";
            DataDGV.Columns["VipName"].HeaderText = "收货人姓名";
            DataDGV.Columns["VipADD"].HeaderText = "收货地址";

            DataDGV.Columns["orderDate"].HeaderText = "订单创建时间";
            DataDGV.Columns["Cade"].HeaderText = "单号";
            DataDGV.Columns["CadeDate"].HeaderText = "日期";
            DataDGV.Columns["BobyName"].HeaderText = "宝贝标题";

            DataDGV.Columns["BobyNom"].HeaderText = "宝贝总数量";
            DataDGV.Columns["userName"].HeaderText = "操作人员";
            DataDGV.Columns["SHOPid"].HeaderText = "店名";
            DataDGV.Columns["SHOPid"].Visible = false;
            DataDGV.Columns["ExpressName"].HeaderText = "物流公司";
            DataDGV.Columns["Remarks"].HeaderText = "订单备注";
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
                sqlselect += " OrderCade ='" + DataDGV.Rows[i].Cells["OrderCade"].Value.ToString() + "'";
            }
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from Str_ActualOrderList where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Str_ActualOrderList where " + sqlselect, conn);
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
                using (TransactionScope scope = new TransactionScope())
                {
                    conn.Open();
                    using (SqlBulkCopy sbc = new SqlBulkCopy(conn))
                    {
                        ////服务器上目标表的名称     
                        sbc.DestinationTableName = "Str_ActualOrderList";
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
        }

        private void ActualOrderList_Load(object sender, EventArgs e)
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

        private void BtnDelete_Click(object sender, EventArgs e)
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
                strsql = "delete from Str_ActualOrderList " + strsql;
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
