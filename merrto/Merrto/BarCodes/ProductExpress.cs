using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Transactions;

namespace Merrto.BarCodes
{
    public partial class ProductExpress : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        DataTable dt = new DataTable();
        DataTable MXdt = new DataTable();
        public ProductExpress()
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
            ofd.Filter = "Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx|所有文件|*.*";

            
            //if (DataDGV.Rows[i].Cells["订单号"].Value.ToString() != "")//订单号保存
            //{
            //    strsql += "insert into M_BrOrderExpress (OrderCade,ExpressBarCode,VipID,ShopCade) values('" + DataDGV.Rows[i].Cells["订单号"].Value.ToString() +
            //        "','" + DataDGV.Rows[i].Cells["快递单号"].Value.ToString() + "','" + DataDGV.Rows[i].Cells["买家ID"].Value.ToString() +
            //        "','" + DataDGV.Rows[i].Cells["网店订单号"].Value.ToString() + "'); ";
            //}

            //strsql += "insert into M_BRExpress (StockID,Cade,CadeDate,BarCode,Qty,RogName,RogAdd,RogTel,RogFax,Expresscode,ExpressName,username) values ('"
            //  + CmdShop.SelectedValue.ToString() + "','EP"
            //  + DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("M_BRExpress", DTdatetime.Value.ToString("yyyyMMdd")) + "','"
            //  + DTdatetime.Value.ToString("yyyy-MM-dd") + "','"
            //  + DataDGV.Rows[i].Cells["条码"].Value.ToString() + "','"
            //  + DataDGV.Rows[i].Cells["数量"].Value.ToString() + "','"
            //  + DataDGV.Rows[i].Cells["收件人"].Value.ToString() + "','"
            //  + DataDGV.Rows[i].Cells["地址"].Value.ToString() + "','"
            //  + DataDGV.Rows[i].Cells["手机"].Value.ToString() + "','"
            //  + DataDGV.Rows[i].Cells["电话"].Value.ToString() + "','"
            //  + DataDGV.Rows[i].Cells["快递单号"].Value.ToString() + "','"
            //  + DataDGV.Rows[i].Cells["快递公司"].Value.ToString() + "','"
            //  + frmlogin.userID + "');";//订单明细保存
            string strsql = "select 订单号 as  OrderCade,快递单号 as ExpressBarCode,买家ID as VipID,网店名称 as ShopCade  from ";
            string strsql1 = "select 条码 as BarCode,0 as pid,0 as sdid,0 as colourID,数量 as Qty,收件人 as RogName,地址 as RogAdd,手机 as RogTel,电话 as RogFax,快递单号 as Expresscode,快递公司 as ExpressName," 
                + CmdShop.SelectedValue.ToString() + " as  StockID,'"+ DTdatetime.Value.ToString("yyyy-MM-dd") + "' as CadeDate,'EP"
            + DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("M_BRExpress", DTdatetime.Value.ToString("yyyyMMdd")) + "' as Cade,'"
            + frmlogin.userID + "' as username from ";

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
            DataDGV.DataSource = "";
            ListDGV.DataSource = "";
            MXdt = new DataTable();
            dt = new DataTable();
            exceld.ExcelToDataGridView(strName, strsql, "导出订单明细$", this.DataDGV, 0,dt);
            exceld.ExcelToDataGridView(strName, strsql1, "导出订单明细$", this.ListDGV, 0, MXdt);
            DataDGV.DataSource = "";
            string[] PrimaryKeyColumns = new string[dt.Columns.Count];
            PrimaryKeyColumns[0] = "OrderCade";
            PrimaryKeyColumns[1] = "ExpressBarCode";
            PrimaryKeyColumns[2] = "VipID";
            PrimaryKeyColumns[3] = "ShopCade";
            dt= GetDistinctPrimaryKeyColumnTable(dt, PrimaryKeyColumns);
            DataDGV.DataSource =dt;
        }

        public DataTable GetDistinctPrimaryKeyColumnTable(DataTable dt, string[] PrimaryKeyColumns)
        {
            DataView dv = dt.DefaultView;
            DataTable dtDistinct = dv.ToTable(true, PrimaryKeyColumns);

            //第一个参数是关键,设置为 true，则返回的 System.Data.DataTable 将包含所有列都具有不同值的行。默认值为 false。
            return dtDistinct;
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
                sqlselect += " ExpressBarCode ='" + DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString() + "'";
            }
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from M_BrOrderExpress where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from M_BrOrderExpress where " + sqlselect, conn);
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
                        sbc.DestinationTableName = "M_BrOrderExpress";
                        sbc.WriteToServer(dt);
                        ////服务器上目标表的名称     
                        sbc.DestinationTableName = "M_BRExpress";
                        sbc.WriteToServer(MXdt);
                        scope.Complete();//有效的事务     
                    }
                    conn.Close();
                }
                //} 
                 string strsql = " update M_BRExpress set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                        "left join M_productsub on M_productsub.pid=M_product.id " +
                        "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                        "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                        "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=M_BRExpress.BarCode ;" +
                        "update M_BRExpress set PID=M_product.id from M_product where ITEM_NO=M_BRExpress.BarCode " +
                        "update M_BRExpress set PID=M_product.id from M_product where ITEM_NO='MT'+M_BRExpress.BarCode" +
                        " update M_BRExpress set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                        "left join M_productsub on M_productsub.pid=M_product.id " +
                        "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                        "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                        "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='MT'+M_BRExpress.BarCode ;";
                conn.Open();
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
            //string sqlselect = "";
            //for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
            //{
            //    if (sqlselect != "")
            //    {
            //        sqlselect += " or ";
            //    }
            //    sqlselect += " Expresscode ='" + DataDGV.Rows[i].Cells["快递单号"].Value.ToString() + "'";
            //}
            //SqlConnection conn = sqlcon.getcon("");
            //DataSet ds = new DataSet();
            //SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from M_BRExpress where " + sqlselect, conn);
            //conn.Open();
            //sqlDaper.Fill(ds);
            //conn.Close();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        conn.Open();
            //        SqlCommand cmd = new SqlCommand("delete from M_BRExpress where " + sqlselect, conn);
            //        cmd.ExecuteNonQuery();
            //        conn.Close();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}

            //string strsql = "";
            //try
            //{
            //    for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
            //    {
            //        if (DataDGV.Rows[i].Cells["订单号"].Value.ToString() != "")//订单号保存
            //        {
            //            strsql += "insert into M_BrOrderExpress (OrderCade,ExpressBarCode,VipID,ShopCade) values('" + DataDGV.Rows[i].Cells["订单号"].Value.ToString() +
            //                "','" + DataDGV.Rows[i].Cells["快递单号"].Value.ToString() + "','" + DataDGV.Rows[i].Cells["买家ID"].Value.ToString() +
            //                "','" + DataDGV.Rows[i].Cells["网店订单号"].Value.ToString() + "'); ";
            //        }
                    
            //        strsql += "insert into M_BRExpress (StockID,Cade,CadeDate,BarCode,Qty,RogName,RogAdd,RogTel,RogFax,Expresscode,ExpressName,username) values ('"
            //          + CmdShop.SelectedValue.ToString() + "','EP"
            //          + DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("M_BRExpress", DTdatetime.Value.ToString("yyyyMMdd")) + "','"
            //          + DTdatetime.Value.ToString("yyyy-MM-dd") + "','"
            //          + DataDGV.Rows[i].Cells["条码"].Value.ToString() + "','"
            //          + DataDGV.Rows[i].Cells["数量"].Value.ToString() + "','"
            //          + DataDGV.Rows[i].Cells["收件人"].Value.ToString() + "','"
            //          + DataDGV.Rows[i].Cells["地址"].Value.ToString() + "','"
            //          + DataDGV.Rows[i].Cells["手机"].Value.ToString() + "','"
            //          + DataDGV.Rows[i].Cells["电话"].Value.ToString() + "','"
            //          + DataDGV.Rows[i].Cells["快递单号"].Value.ToString() + "','"
            //          + DataDGV.Rows[i].Cells["快递公司"].Value.ToString() + "','"
            //          + frmlogin.userID + "');";//订单明细保存

            //    }

            //    conn.Open();
            //    strsql = strsql.Replace("'", "''");
            //    strsql = strsql.Replace("'',''", "','");
            //    strsql = strsql.Replace("(''", "('");
            //    strsql = strsql.Replace("'')", "')");
            //    strsql += " update M_BRExpress set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
            //       "left join M_productsub on M_productsub.pid=M_product.id " +
            //       "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
            //       "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
            //       "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=M_BRExpress.BarCode ;";//从产品表更新id
                    
            //    SqlCommand cmd = new SqlCommand(strsql, conn);
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
            //    MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("数据更新失败！", "系统提示：", MessageBoxButtons.OK);
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void ProductExpress_Load(object sender, EventArgs e)
        {
            //得到仓库的数据
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT StockID,Cade,StockName FROM M_Stock ", conn);
            DataSet ds = new DataSet();
            conn.Open();//打开连接
            sqlDaper.Fill(ds);
            conn.Close();//关关闭连接
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmdShop.DataSource = ds.Tables[0];
                CmdShop.ValueMember = "StockID";
                CmdShop.DisplayMember = "StockName";
            }
        }
    }
}
