using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Transactions;

namespace Merrto.TheShopReports
{
    public partial class ActualOrderDetailList : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        DataTable dt = new DataTable();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        public ActualOrderDetailList()
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
            string strsql = "select 订单编号 as  OrderCade,标题 as Title,购买数量 as BuyNO,商家编码 as BarCode,套餐信息 as AttriBute,0 as Pid,0 as ColourID,0 as SDID,'AD"
                       + DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("Str_ActualOrderDetailList", DTdatetime.Value.ToString("yyyyMMdd")) + "' as Cade,'"
                       + DTdatetime.Value.ToString("yyyy-MM-dd") + "' as CadeDate,'"
                       + frmlogin.userID + "' as UserName,"
                       + CmdShop.SelectedValue.ToString() + " as ShopID,订单状态 as type from ";

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
            DataDGV.Columns["Title"].HeaderText = "标题";
            DataDGV.Columns["BuyNO"].HeaderText = "购买数量";
            DataDGV.Columns["BarCode"].HeaderText = "商家编码";
            DataDGV.Columns["AttriBute"].HeaderText = "套餐信息";
            DataDGV.Columns["Cade"].HeaderText = "编号";
            DataDGV.Columns["CadeDate"].HeaderText = "日期";
            DataDGV.Columns["UserName"].HeaderText = "操作工号";
            DataDGV.Columns["Pid"].Visible = false;
            DataDGV.Columns["ColourID"].Visible = false;
            DataDGV.Columns["SDID"].Visible = false;
            DataDGV.Columns["ShopID"].Visible = false;
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
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from Str_ActualOrderDetailList where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (MessageBox.Show("\n有些订单数据已保存过，是否从新保存   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from Str_ActualOrderDetailList where " + sqlselect, conn);
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
            //    for (int i = 0; i < DataDGV.Rows.Count; i++)//得到总行数并在之内循环
            //    {
            //        if (DataDGV.Rows[i].Cells["订单状态"].Value.ToString() == "交易关闭" || DataDGV.Rows[i].Cells["订单状态"].Value.ToString() == "等待买家付款" || DataDGV.Rows[i].Cells["订单状态"].Value.ToString() == "未创建支付宝交易")
            //        {
            //        }
            //        else
            //        {
            //            strsql += "insert into Str_ActualOrderDetailList (" +
            //                "SHOPid,Cade,CadeDate,OrderCade,Title,buyNO,BarCode,Attribute,username) values('"
            //            + CmdShop.SelectedValue.ToString() + "','AD"
            //            + DTdatetime.Value.ToString("yyyyMMdd") + getDate.uppacking("Str_ActualOrderDetailList", DTdatetime.Value.ToString("yyyyMMdd")) + "','"
            //            + DTdatetime.Value.ToString("yyyy-MM-dd") + "','"
            //            + DataDGV.Rows[i].Cells["订单编号"].Value.ToString() + "','"
            //            + DataDGV.Rows[i].Cells["标题"].Value.ToString() + "','"
            //            + DataDGV.Rows[i].Cells["购买数量"].Value.ToString() + "','"
            //            + DataDGV.Rows[i].Cells["商家编码"].Value.ToString() + "','"
            //            + DataDGV.Rows[i].Cells["套餐信息"].Value.ToString() + "','"
            //            + frmlogin.userID + "');";
            //        }
            //    }
            //    strsql = strsql.Replace("'", "''");
            //    strsql = strsql.Replace("'',''", "','");
            //    strsql = strsql.Replace("(''", "('");
            //    strsql = strsql.Replace("'')", "')");
            //    strsql += " update Str_ActualOrderDetailList set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
            //        "left join M_productsub on M_productsub.pid=M_product.id " +
            //        "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
            //        "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
            //        "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=Str_ActualOrderDetailList.BarCode ;" +
            //        "update Str_ActualOrderDetailList set PID=M_product.id from M_product where ITEM_NO=Str_ActualOrderDetailList.BarCode " +
            //        "update Str_ActualOrderDetailList set PID=M_product.id from M_product where ITEM_NO='MT'+Str_ActualOrderDetailList.BarCode"+
            //        " update Str_ActualOrderDetailList set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
            //        "left join M_productsub on M_productsub.pid=M_product.id " +
            //        "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
            //        "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
            //        "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='MT'+Str_ActualOrderDetailList.BarCode ;";
            //    conn.Open();
            //    SqlCommand cmd = new SqlCommand(strsql, conn);
            //    cmd.ExecuteNonQuery();
            //    conn.Close();
                using (TransactionScope scope = new TransactionScope())
                {
                    conn.Open();
                    using (SqlBulkCopy sbc = new SqlBulkCopy(conn))
                    {
                        ////服务器上目标表的名称     
                        sbc.DestinationTableName = "Str_ActualOrderDetailList";
                        sbc.WriteToServer(dt);
                        scope.Complete();//有效的事务     
                    }
                    conn.Close();
                }
                //} 
                strsql = " update Str_ActualOrderDetailList set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                        "left join M_productsub on M_productsub.pid=M_product.id " +
                        "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                        "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                        "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=Str_ActualOrderDetailList.BarCode ;" +
                        "update Str_ActualOrderDetailList set PID=M_product.id from M_product where ITEM_NO=Str_ActualOrderDetailList.BarCode " +
                        "update Str_ActualOrderDetailList set PID=M_product.id from M_product where ITEM_NO='MT'+Str_ActualOrderDetailList.BarCode" +
                        " update Str_ActualOrderDetailList set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                        "left join M_productsub on M_productsub.pid=M_product.id " +
                        "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                        "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                        "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='MT'+Str_ActualOrderDetailList.BarCode ;";
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
        }

        private void ActualOrderDetailList_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT ID,Cade,ShopNAME FROM STR_Shop ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
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
                strsql = "delete from Str_ActualOrderDetailList " + strsql;
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
