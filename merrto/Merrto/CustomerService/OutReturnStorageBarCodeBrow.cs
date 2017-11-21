using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Merrto.CustomerService
{
    public partial class OutReturnStorageBarCodeBrow : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public OutReturnStorageBarCodeBrow()
        {
            InitializeComponent();
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            brows();
        }
        private void brows()
        {
            string strsql = "";

            //所有数据
            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ExpressBarCode like '%" + TxtCade.Text.ToString().Trim() + "%'";
            }
            if (TxtMobile.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Mobile like '%" + TxtMobile.Text.ToString().Trim() + "%'"; 
            }

            if (this.DTPOrderDate.Value.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql += " CadeDate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000'";
            }
            if (strsql != "")
            {
                strsql += " and ";
            }
            strsql += " type !='3'";
            if (strsql != "")
            {
                strsql = " where " + strsql;
            }

            //CS_OutRuturnStorage

            strsql = "select ExpressName,ExpressBarCode,Mobile,BarCode,Remarks,OrderCade," +
                    "Weat,Quality,UserName,case when Type=3 then '已审核' when Type=2 then '待审核' else '待领用' end type," +
                    "CadeDate,ShopName,CadeType,VipName,Reason,NExpressName,NExpressBarCode,Remarks2 from CS_OutRuturnNOinforMation " +
                    strsql;

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();

            sqlDaper.Fill(ds);
            conn.Close();

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["ExpressName"].HeaderText = "快递公司";
            WPHbROWDGV.Columns["ExpressBarCode"].HeaderText = "快递单号";
            WPHbROWDGV.Columns["BarCode"].HeaderText = "条码";
            WPHbROWDGV.Columns["Mobile"].HeaderText = "电话";
            WPHbROWDGV.Columns["Remarks"].HeaderText = "问题";
            WPHbROWDGV.Columns["Weat"].HeaderText = "是否穿过";
            WPHbROWDGV.Columns["Quality"].HeaderText = "质量问题";
            WPHbROWDGV.Columns["UserName"].HeaderText = "操作员";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "订单号";
            WPHbROWDGV.Columns["type"].HeaderText = "状态";
            WPHbROWDGV.Columns["Type"].Width = 60;
            WPHbROWDGV.Columns["VipName"].HeaderText = "会员";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "订单";
            WPHbROWDGV.Columns["BarCode"].HeaderText = "条码";
            WPHbROWDGV.Columns["Reason"].HeaderText = "原因";
            WPHbROWDGV.Columns["ShopName"].HeaderText = "店铺";
            WPHbROWDGV.Columns["CadeTYpe"].HeaderText = "类型";
            WPHbROWDGV.Columns["NExpressBarCode"].HeaderText = "换出快递单";
            WPHbROWDGV.Columns["NExpressName"].HeaderText = "换出快递公司";
            WPHbROWDGV.Columns["Reason"].Width = 150;
            WPHbROWDGV.Columns["Remarks"].HeaderText = "问题处理";
            WPHbROWDGV.Columns["Remarks"].Width = 200;
            WPHbROWDGV.Columns["CadeDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["CadeDate"].Width = 80;
            WPHbROWDGV.Columns["Remarks2"].HeaderText = "收货问题";
            
        }

        private void btnupEXcel_Click(object sender, EventArgs e)
        {

            if (WPHbROWDGV.Rows.Count > 0)
            {
                //建立Excel对象    
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                //生成字段名称    
                for (int i = 0; i < WPHbROWDGV.ColumnCount; i++)
                {
                    excel.Cells[1, i + 1] = WPHbROWDGV.Columns[i].HeaderText;
                    //if (y == 0)
                    //{
                    //    y = 1;
                    //    //toolStripStatusLabel6.Text = "数据导入中，请等待!";
                    //}
                }    //填充数据    
                for (int i = 0; i < WPHbROWDGV.RowCount; i++)
                {
                    for (int j = 0; j < WPHbROWDGV.ColumnCount; j++)
                    {
                        if (WPHbROWDGV[j, i].Value == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "" + WPHbROWDGV[i, j].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = WPHbROWDGV[j, i].Value.ToString();
                        }
                    }
                }
                excel.Visible = true;
            }
            else
            {
                MessageBox.Show("没有你要导的数据！！！");
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            //if (WPHbROWDGV[9, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() == "待审核" || WPHbROWDGV[9, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() == "已审核")
            //{
            //    if (WPHbROWDGV[9, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() == "待审核")
            //    {
            //        MessageBox.Show("此单已领用不能修改！！");
            //    }
            //    else
            //    {
            //        if (WPHbROWDGV[9, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() == "已审核")
            //        {
            //            MessageBox.Show("此单已审核不能修改！！");
            //        }
            //    }
            //}
            //else{
                int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                OutRuturnNOinforMation ornm = new OutRuturnNOinforMation(WPHbROWDGV[1, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString());
                ornm.ShowDialog();
                brows();
                WPHbROWDGV.Rows[ID_].Selected = true;
            //}
        }

        private void BtnEmploy_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows.Count > 0)
            {
                if (WPHbROWDGV[9, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() != "已审核")
                {
                    int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                    OutReturnSoragebarcodeEdit ose = new OutReturnSoragebarcodeEdit(WPHbROWDGV[1, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString(), 0);
                    ose.ShowDialog();
                    brows();
                    WPHbROWDGV.Rows[ID_].Selected = true;
                }
                else
                {
                    MessageBox.Show("此单已审核不能领用！！");
                }
            }
        }

        private void OutReturnStorageBarCodeBrow_Load(object sender, EventArgs e)
        {
            DTPOrderDate.Text = (DateTime.Now.AddYears(-1)).ToString("yyyy-MM-dd");
            this.DTStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='191' and m_user.userName='"+frmlogin.userID+"'";
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["Name"].ToString() == "领用")
                    {
                        BtnEmploy.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[i]["Name"].ToString() == "修改")
                    {
                        this.BtnEdit.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[i]["Name"].ToString() == "查看")
                    {
                        this.BtnSelect.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[i]["Name"].ToString() == "审核")
                    {
                        this.BtnToExamine.Enabled = true;
                    }
                }
            }
        }

        private void BtnToExamine_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows.Count > 0)
            {
                if (WPHbROWDGV[9, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() == "待审核")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                {
                    //"insert into CS_OutRuturnStorage(ShopName,CadeType,VipName,Mobile,OrderCade,BarCode,Remarks,Remarks2,Reason,SumMoney,NExpressName,ExpressName,cAdedate,username,BarCodeDate,type,ExpressBarCode)select ShopName,CadeType,VipName,Mobile,OrderCade,BarCode,Remarks,Remarks2,Reason,SumMoney,NExpressName,ExpressName,cAdedate,username,BarCodeDate,type,ExpressBarCode from CS_OutRuturnNOinforMation where EXpressBarCode='" + WPHbROWDGV[1, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'"
                    SqlConnection conn = sqlcon.getcon("");
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(" update CS_OutRuturnNOinforMation set Type='3',BarCodeDate='" + DateTime.Now.ToString("yyyy-MM-dd") +
                        "' where EXpressBarCode='" + WPHbROWDGV[1, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + 
                        "';insert into CS_OutRuturnStorage(ShopName,CadeType,VipName,Mobile,OrderCade,BarCode,Remarks,Remarks2,Reason,SumMoney,NExpressName,ExpressName,cAdedate,username,BarCodeDate,type,ExpressBarCode)select ShopName,CadeType,VipName,Mobile,OrderCade,BarCode,Remarks+'(领用生成)',Remarks2,Reason,SumMoney,NExpressName,ExpressName,cAdedate,username,BarCodeDate,type,ExpressBarCode from CS_OutRuturnNOinforMation where EXpressBarCode='" + WPHbROWDGV[1, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() +
                        "' ;insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('自动生成','" + DateTime.Now.ToString() + "','" + WPHbROWDGV[1, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "','" + frmlogin.userID + "');", conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();
                    brows();
                    //OutStorageEdit ors = new OutStorageEdit(WPHbROWDGV[5, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString(), 1);
                    //ors.ShowDialog();
                }
                else
                {
                    if (WPHbROWDGV[9, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() == "已审核")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                    {
                        MessageBox.Show("已审核不能重复审核！！");
                    }
                    else
                    {
                        MessageBox.Show("要先领用才可以审核！！");
                    }

                }
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows.Count > 0)
            {
                OutReturnSoragebarcodeEdit ose = new OutReturnSoragebarcodeEdit(WPHbROWDGV[1, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString(), 1);
                ose.ShowDialog();
            }
        }

        private void BtnModer_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows.Count > 0)
            {

                String PM = Interaction.InputBox("请输入原因", "输入原因", "", 70, 100);
                if (PM != string.Empty)
                {
                    int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                    SqlConnection conn = sqlcon.getcon("");
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand("update CS_OutRuturnNOinforMation set Remarks='" + PM  + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Remarks"].Value.ToString() +
                        "' where EXpressBarCode='" + WPHbROWDGV[1, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'", conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();
                    brows();
                    WPHbROWDGV.Rows[ID_].Selected = true;
                }
                else
                {
                    MessageBox.Show("要先确认收货才可以审核！！");
                }
            }
        }
    }
}
