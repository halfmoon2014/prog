using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.BarCodes
{
    public partial class ExpressReturn : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();//得来数据库连接
        public ExpressReturn()
        {
            InitializeComponent();
        }

        private void ExpressReturn_Load(object sender, EventArgs e)
        {

        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            string strsql = "";

            if (TxtOrderCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = " OrderCade like '%" + TxtOrderCade.Text.ToString() + "'";
            }


            if (TxtShopCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ShopCade like '%" + TxtShopCade.Text.ToString() + "%'";
            }
            
            if (TxtTel.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " RogTel like '%" + TxtTel.Text.ToString() + "%'";
            }

            if (TxtVidID.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " VidID like '%" + TxtVidID.Text.ToString() + "%'";
            }
            if (strsql != "")
            {
                strsql += " and ";
            }
            strsql += "not exists (select * from M_BRExpressReturn where M_BrOrderExpress.id = BRorderID and M_BrExpress.id = BrExpressID)";
            if (strsql != "")
            {
                strsql = " where " + strsql;
            }//13932360686
            strsql = "select '' ReturnExpress,OrderCade,ExpressBarCode,VipID,ShopCade,StockID,BarCode,Qty,RogName,RogAdd,RogTel,RogFax,ExpressName,M_BrOrderExpress.id as BRorderID,M_BrExpress.id as BrExpressID " +
                    "from M_BrExpress left join M_BrOrderExpress on ExpressBarcode=Expresscode " + strsql + " order by Cade";
            //CAST ('True' as bit) 
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);//取出没有退过货的订单
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            //false
            WPHbROWDGV.DataSource = ds.Tables[0];//datagridVrow绑定Dataset
            //WPHbROWDGV.Columns["OK"].HeaderText = "选择";
            //WPHbROWDGV.Columns["OK"].Width=45;
            WPHbROWDGV.Columns["ReturnExpress"].HeaderText = "退回快递单";//表头名称
            WPHbROWDGV.Columns["ReturnExpress"].ReadOnly = false;//修改状态
            WPHbROWDGV.Columns["BarCode"].HeaderText = "条型码";
            WPHbROWDGV.Columns["BarCode"].ReadOnly = true;
            //WPHbROWDGV.Columns["Cade"].HeaderText = "单号";
            //WPHbROWDGV.Columns["Cade"].ReadOnly = true;
            //WPHbROWDGV.Columns["CadeDate"].HeaderText = "日期";
            //WPHbROWDGV.Columns["CadeDate"].ReadOnly = true;
            WPHbROWDGV.Columns["ExpressBarCode"].HeaderText = "快递单号";
            WPHbROWDGV.Columns["ExpressBarCode"].ReadOnly = true;
            WPHbROWDGV.Columns["VipID"].HeaderText = "买家ID";
            WPHbROWDGV.Columns["VipID"].ReadOnly = true;
            WPHbROWDGV.Columns["ShopCade"].HeaderText = "店铺订单";
            WPHbROWDGV.Columns["ShopCade"].ReadOnly = true;
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "订单号";
            WPHbROWDGV.Columns["OrderCade"].ReadOnly = true;
            WPHbROWDGV.Columns["Qty"].HeaderText = "数量";
            WPHbROWDGV.Columns["Qty"].ReadOnly = true;
            WPHbROWDGV.Columns["RogName"].HeaderText = "收货人";
            WPHbROWDGV.Columns["RogName"].ReadOnly = true;
            WPHbROWDGV.Columns["RogAdd"].HeaderText = "地址";
            WPHbROWDGV.Columns["RogAdd"].ReadOnly = true;
            WPHbROWDGV.Columns["RogTel"].HeaderText = "手机";
            WPHbROWDGV.Columns["RogTel"].ReadOnly = true;
            WPHbROWDGV.Columns["RogFax"].HeaderText = "电话";
            WPHbROWDGV.Columns["RogFax"].ReadOnly = true;
            WPHbROWDGV.Columns["ExpressName"].HeaderText = "快递公司";
            WPHbROWDGV.Columns["ExpressName"].ReadOnly = true;
            WPHbROWDGV.Columns["BrExpressID"].Visible = false;
            WPHbROWDGV.Columns["BRorderID"].Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string str="";
                for (int i = 0; i < WPHbROWDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    if (WPHbROWDGV.Rows[i].Cells["ReturnExpress"].Value.ToString() != "")//有退货快递单的保存
                    {
                        str += "insert into M_BRExpressReturn(ReturnBarCode,BrExpressID,BRorderID) VALUES ('"
                            + WPHbROWDGV.Rows[i].Cells["ReturnExpress"].Value.ToString() +
                            "','" + WPHbROWDGV.Rows[i].Cells["BrExpressID"].Value.ToString() + 
                            "','" + WPHbROWDGV.Rows[i].Cells["BRorderID"].Value.ToString() +"');";
                    }
                }
                
                SqlCommand sqlcom = new SqlCommand(str, conn);
                conn.Open();
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                conn.Close();
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        //private void WPHbROWDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex != -1)
        //    {
        //        if (Convert.ToString(WPHbROWDGV.Rows[e.RowIndex].Cells[0].Value) == "true")
        //            WPHbROWDGV.Rows[e.RowIndex].Cells[0].Value = "false";
        //        else
        //            WPHbROWDGV.Rows[e.RowIndex].Cells[0].Value = "true";
        //    }
        //}
    }
}
