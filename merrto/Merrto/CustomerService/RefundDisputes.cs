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
    public partial class RefundDisputes : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public RefundDisputes()
        {
            InitializeComponent();
        }

        private void RefundDisputes_Load(object sender, EventArgs e)
        {
            DTPOrderDate.Text = (DateTime.Now.AddMonths(-6)).ToString("yyyy-MM-dd");
            this.DTStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataSet ds = new DataSet();
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='198' and m_user.userName='" + frmlogin.userID + "' order by Sort";
            SqlConnection conn = sqlcon.getcon("");
            //DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter(strsql, conn);
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT distinct ShopName from CS_RefundDisputes ", conn);
            conn.Open();
            sqlDaper3.Fill(ds, "User");
            sqlDaper1.Fill(ds, "ShopName");
            conn.Close();
            if (ds.Tables["ShopName"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["ShopName"].NewRow();
                ds.Tables["ShopName"].Rows.Add(row);
                this.CboShopName.DataSource = ds.Tables["ShopName"];
                CboShopName.DisplayMember = "ShopName";
            }
            CboShopName.Text = "";
            if (ds.Tables["User"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["User"].Rows.Count; i++)
                {
                    Button BtnNumber = new Button()
                    {
                        Text = ds.Tables["User"].Rows[i]["Name"].ToString(),
                        Name = ds.Tables["User"].Rows[i]["Cade"].ToString(),
                        Location = new System.Drawing.Point(i * 78+5, 2),
                        Font = new System.Drawing.Font("宋体", 9F),
                        UseVisualStyleBackColor = true
                    };
                    BtnNumber.Click += new System.EventHandler(this.BtnNumber_Click);
                    this.GpbBtn.Controls.Add(BtnNumber);
                }
            }
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
             RefundDisputesNew rdn;
            switch (btn.Name)
            {
                case "New": //数据参数新增
                    rdn = new RefundDisputesNew("", 1);
                    rdn.ShowDialog();
                    brows();
                    break;
                case "Edit": //数据参数新增
                    if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "处理中")
                    {
                        rdn = new RefundDisputesNew(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString(), 2);
                        rdn.ShowDialog();
                        brows();
                    }
                    break;
                case "Handle": //数据参数审核
                    if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "处理中")
                    {
                        rdn = new RefundDisputesNew(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString(), 3);
                        rdn.ShowDialog();
                        brows();
                    }
                    break;
                case "ReturnHandle": //反审核
                    if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "完结")
                    {
                        try
                        {
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            string strsql = "insert into CS_RefundDisputesOperate (Operate,Operatedatetime,RID,username)values('反审','" + DateTime.Now.ToString() + "','" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "','" + frmlogin.userID + "');update CS_RefundDisputes set type='1' where ID='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand(strsql, conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            brows();
                            WPHbROWDGV.Rows[ID_].Selected = true;
                            MessageBox.Show("反审成功！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            MessageBox.Show("反审失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该状态不能反审！！");
                    }
                    break;
                case "Delete": //作废
                    if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "处理中")
                    {
                        try
                        {
                            //int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            string strsql = "insert into CS_RefundDisputesOperate (Operate,Operatedatetime,RID,username)values('删除','"
                                + DateTime.Now.ToString() + "','" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "','" + frmlogin.userID +
                                "');delete from CS_RefundDisputes where ID='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand(strsql, conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            brows();
                            //WPHbROWDGV.Rows[ID_].Selected = true;
                            MessageBox.Show("已删除！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        catch
                        {
                            MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该状态不能删除！！");
                    }
                    break;
                case "Excel": //作废
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
                                if (WPHbROWDGV[j, i].Visible == true)
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
                        }
                        excel.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("没有你要导的数据！！！");
                    }
                    break;
                case "ReturnCanle"://取消作废
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "订单关闭")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand("insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('取消作废','" + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "','" + frmlogin.userID + "');update CS_OutRuturnStorage set Type='1' where OrderCade='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "'", conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();

                            WPHbROWDGV.Rows[ID_].Selected = true;
                            brows();
                        }
                        else
                        {
                            MessageBox.Show("该订单没有关闭不能取消关闭！！");
                        }
                    }
                    break;

                case "Operate":
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        Common.CommonForm comm = new Common.CommonForm("RID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'", "CS_RefundDisputesOperate");
                        comm.ShowDialog();
                    }
                    break;
            }
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
                strsql = strsql + " OrderCade like '%" + TxtCade.Text.ToString() + "%'";
            }
            if (this.CboShopName.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ShopName='" + CboShopName.Text.ToString().Trim() + "'";
            }
            //所有数据
            if (this.TxtVIPname.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " VipID like '%" + TxtVIPname.Text.ToString() + "%'";
            }


            if (this.CboType.Text.ToString() == " " || this.CboType.Text.ToString() == "")
            {
            }
            else
            {
                int type_ = 0;
                if (this.CboType.Text.ToString() == "待处理")
                {
                    type_ = 1;
                }
                if (this.CboType.Text.ToString() == "处理中")
                {
                    type_ = 1;
                }
                if (this.CboType.Text.ToString() == "完结")
                {
                    type_ = 3;
                }
                if (this.CboType.Text.ToString() == "关闭")
                {
                    type_ = 0;
                }

                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Type = '" + type_ + "'";

            }


            if (this.DTPOrderDate.Value.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql += " CadeDate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000'";

                if (strsql != "")
                {
                    strsql = " where " + strsql;
                }
            }


            strsql = "select ID,CadeDate,BarcodeDate,0 as days,ProcessingResults,ShopName,ListType,case when type=1 then '处理中' when type=3 then '完结' else '关闭' end type," +
                "VipID,Reason,OrderCade,Remarks,BarCode,SumMoney,CustomerService,UserName " +
                " from CS_RefundDisputes " + strsql + " order by CadeDate,BarcodeDate";

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);

            conn.Open();

            sqlDaper.Fill(ds);
            conn.Close();

            foreach (DataRow newrow in ds.Tables[0].Rows)
            {
                DateTime t1 = DateTime.Parse(newrow["BarcodeDate"] == DBNull.Value ? DateTime.Now.ToString("yyyy-MM-dd") : newrow["BarcodeDate"].ToString());
                DateTime t2 = DateTime.Parse(newrow["CadeDate"] == DBNull.Value ? DateTime.Now.ToString("yyyy-MM-dd") : newrow["CadeDate"].ToString());
                System.TimeSpan ts = t1 - t2;
                newrow["days"] = ts.Days;// Math.Round((Convert.ToDateTime(newrow["BarcodeDate"]) - Convert.ToDateTime(newrow["CadeDate"])), 0, MidpointRounding.AwayFromZero);
            }

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["ShopName"].HeaderText = "店铺";
            WPHbROWDGV.Columns["Type"].HeaderText = "状态";
            WPHbROWDGV.Columns["Days"].HeaderText = "天数";
            WPHbROWDGV.Columns["Days"].Width = 55;
            WPHbROWDGV.Columns["ListType"].HeaderText = "类型";
            WPHbROWDGV.Columns["ListType"].Width = 60;
            WPHbROWDGV.Columns["Reason"].HeaderText = "投诉原因";
            WPHbROWDGV.Columns["SumMoney"].HeaderText = "损失金额";
            WPHbROWDGV.Columns["Type"].Width = 60;
            WPHbROWDGV.Columns["VipID"].HeaderText = "卖家ID";
            WPHbROWDGV.Columns["CustomerService"].HeaderText = "责任客服";
            WPHbROWDGV.Columns["BarcodeDate"].HeaderText = "完结日期";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "订单";
            WPHbROWDGV.Columns["CadeDate"].HeaderText = "申请日期";
            WPHbROWDGV.Columns["CadeDate"].Width = 80;
            WPHbROWDGV.Columns["UserName"].HeaderText = "操作员";
            WPHbROWDGV.Columns["ProcessingResults"].HeaderText = "处理结果";
            WPHbROWDGV.Columns["BarCode"].HeaderText = "条码";
            WPHbROWDGV.Columns["Remarks"].HeaderText = "备注";
            WPHbROWDGV.Columns["ID"].Visible = false;
        }

        private void WPHbROWDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewTextBoxColumn dgv_Text = new DataGridViewTextBoxColumn();
            for (int i = 0; i < WPHbROWDGV.Rows.Count; i++)
            {
                int j = i + 1;
                WPHbROWDGV.Rows[i].HeaderCell.Value = j.ToString();
            }
        }

        private void WPHbROWDGV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < WPHbROWDGV.Rows.Count)
            {
                DataGridViewRow dgrSingle = WPHbROWDGV.Rows[e.RowIndex];
                try
                {
                    DateTime t1 = DateTime.Parse(dgrSingle.Cells["CadeDate"].Value.ToString());
                    DateTime t2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    System.TimeSpan ts = t2 - t1;
                    if (ts.Days >=29)
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
                    }
                   
                    if (dgrSingle.Cells["Type"].Value.ToString() == "完结")
                    {
                        dgrSingle.DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

      
    }
}
