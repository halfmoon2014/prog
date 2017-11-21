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
    public partial class OrderList : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        private SqlDataAdapter SDA = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public OrderList()
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
                      "买家实际支付金额 as sumMoney,返点积分 as GetIntegral,订单状态 as Type,收货人姓名 as VipName,收货地址  as VipADD,订单创建时间 as orderDate,'OL" +
                  DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("STR_OrderList", DTdatetime.Value.ToString("yyyyMMdd")) +
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
            if (strName.IndexOf((".csv"))!=-1)
            {
                exceld.CSVToDataGridView(strName,strsql, this.DataDGV,dt,1);
            }
            else
            {
                exceld.ExcelToDataGridView(strName,strsql,"", this.DataDGV,1,dt);
            }

        }

        private void OrderList_Load(object sender, EventArgs e)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
            string sqlselect="";
            for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
            {
                if (sqlselect != "")
                {
                    sqlselect += " or ";
                }
                sqlselect += " OrderCade ='" + DataDGV.Rows[i].Cells["订单编号"].Value.ToString() + "'";
            }
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_OrderList where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_OrderList where " + sqlselect, conn);
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
                SqlCommandBuilder scb = new SqlCommandBuilder(SDA);
                SDA.Update(dt);
                for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    if (DataDGV.Rows[i].Cells["订单状态"].Value.ToString() == "交易关闭" || DataDGV.Rows[i].Cells["订单状态"].Value.ToString() == "等待买家付款" || DataDGV.Rows[i].Cells["订单状态"].Value.ToString() == "未创建支付宝交易")
                    {
                    }
                    else
                    {
                        strsql += "insert into STR_OrderList (SHOPid,Cade,CadeDate,OrderCade,VIP,VIPAccount,PayMentForGoods,Express,ExpressName,integral,sumMoney,GetIntegral,Type,VipName,VipADD,orderDate,BobyName,BobyNom,Remarks,username) values ('"
                          + CmdShop.SelectedValue.ToString() + "','OL"
                          + DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("STR_OrderList", DTdatetime.Value.ToString("yyyyMMdd")) + "','"
                          + DTdatetime.Value.ToString("yyyy-MM-dd") + "','"
                          + DataDGV.Rows[i].Cells["订单编号"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["买家会员名"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["买家支付宝账号"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["买家应付货款"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["买家应付邮费"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["物流公司"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["买家支付积分"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["买家实际支付金额"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["返点积分"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["订单状态"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["收货人姓名"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["收货地址 "].Value.ToString().Trim() + "','"
                          + DataDGV.Rows[i].Cells["订单创建时间"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["宝贝标题 "].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["宝贝总数量"].Value.ToString() + "','"
                          + DataDGV.Rows[i].Cells["订单备注"].Value.ToString() + "','"
                          + frmlogin.userID + "');";
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
                //// using (SqlConnection cn = new SqlConnection(connectionString))
                ////{
                //     using (TransactionScope scope = new TransactionScope())
                //    {
                //         conn.Open();
                //         using (SqlBulkCopy sbc = new SqlBulkCopy(conn))
                //        {
                //            ////服务器上目标表的名称     
                //            sbc.DestinationTableName = "STR_OrderList";
                //            sbc.WriteToServer(ds.Tables[0]);
                //            scope.Complete();//有效的事务     
                //        }
                //         conn.Close();
                //    }
                ////}  
              
            
                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新失败！", "系统提示：", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
                      "买家实际支付金额 as sumMoney,返点积分 as GetIntegral,订单状态 as Type,收货人姓名 as VipName,收货地址  as VipADD,订单创建时间 as orderDate,'OL" +
                  DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("STR_OrderList", DTdatetime.Value.ToString("yyyyMMdd")) +
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
                exceld.ExcelToDataGridView(strName, strsql, "", this.DataDGV,1,dt);
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

        private void button1_Click(object sender, EventArgs e)
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
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_OrderList where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_OrderList where " + sqlselect, conn);
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
                        sbc.DestinationTableName = "STR_OrderList";
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
            //}
        }
        public void TransferData(string excelFile, string sheetName, string connectionString)
        {
            DataSet ds = new DataSet();
            try
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
                    "买家实际支付金额 as sumMoney,返点积分 as GetIntegral,订单状态 as Type,收货人姓名 as VipName,收货地址  as VipADD,订单创建时间 as orderDate,'OL"+
                DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("STR_OrderList", DTdatetime.Value.ToString("yyyyMMdd")) + 
                "' as Cade,'" + DTdatetime.Value.ToString("yyyy-MM-dd") +
                "' as CadeDate,宝贝标题 as BobyName,宝贝总数量 as BobyNom,'" + frmlogin.userID + "' as userName,'" + CmdShop.SelectedValue.ToString() + "' as SHOPid,物流公司 as ExpressName," +
                  "订单备注 as Remarks from ";
                //"(SHOPid,Cade,CadeDate,OrderCade,VIP,VIPAccount,PayMentForGoods,Express,ExpressName,integral,sumMoney,GetIntegral,Type,VipName,VipADD,orderDate,BobyName,BobyNom,Remarks,username) values ('"
                //+ CmdShop.SelectedValue.ToString() + "','OL"
                //+ DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("STR_OrderList", DTdatetime.Value.ToString("yyyyMMdd")) + "','"
                //+ DTdatetime.Value.ToString("yyyy-MM-dd") + "','"
                //+ DataDGV.Rows[i].Cells["订单编号"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["买家会员名"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["买家支付宝账号"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["买家应付货款"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["买家应付邮费"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["物流公司"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["买家支付积分"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["买家实际支付金额"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["返点积分"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["订单状态"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["收货人姓名"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["收货地址 "].Value.ToString().Trim() + "','"
                //+ DataDGV.Rows[i].Cells["订单创建时间"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["宝贝标题 "].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["宝贝总数量"].Value.ToString() + "','"
                //+ DataDGV.Rows[i].Cells["订单备注"].Value.ToString() + "','"
                //+ frmlogin.userID + "');";

                string strName = string.Empty;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    strName = ofd.FileName;
                }

                char[] chr = new char[1] { '\\' };
                string[] strs = strName.Split(chr, StringSplitOptions.RemoveEmptyEntries);
                //string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strName.Substring(0, strName.Length - strs[strs.Length - 1].Length) + "\\;Extended Properties=\"text;HDR=yes;FMT=Delimited\"";
                //System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);

                //con.Open();
                //System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strsql+" [" + strs[strs.Length - 1] + "]", con);
                //OleDbCommand SCD = new OleDbCommand(strsql + " [" + strs[strs.Length - 1] + "]", con);
                ////SCD OleDbCommand SCD = new OleDbCommand();
                ////SqlCommand SCD = new SqlCommand("select * from tables", conn);
                ////SDA.SelectCommand = SCD;
                ////SDA.Fill(dt);  
                ////adapter.Fill(dt);
                //SDA.SelectCommand = SCD;
                //SDA.Fill(dt);  
                //con.Close();
                //DataDGV.DataSource = dt;
                //获取全部数据
                //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + excelFile + ";" + "Extended Properties=Excel 8.0;";
                string strConn="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strName.Substring(0, strName.Length - strs[strs.Length - 1].Length) + "\\;Extended Properties=\"text;HDR=yes;FMT=Delimited\"";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                strExcel = string.Format(strsql + " [" + strs[strs.Length - 1] + "]", sheetName);
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                myCommand.Fill(ds, sheetName);

              
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                     using (TransactionScope scope = new TransactionScope())
                    {
                        cn.Open();
                        using (SqlBulkCopy sbc = new SqlBulkCopy(cn))
                        {
                            ////服务器上目标表的名称     
                            sbc.DestinationTableName = sheetName;
                            sbc.WriteToServer(ds.Tables[0]);
                            scope.Complete();//有效的事务     
                        }
                    }
                }  
              
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        //进度显示
        private void bcp_SqlRowsCopied(object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e)
        {
            this.Text = e.RowsCopied.ToString();
            this.Update();
        }

        private void Btndelete_Click(object sender, EventArgs e)
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
                strsql = "delete from STR_OrderList " + strsql;
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
