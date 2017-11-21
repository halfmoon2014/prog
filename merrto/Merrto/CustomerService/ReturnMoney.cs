using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace Merrto.CustomerService
{
    public partial class ReturnMoney : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public ReturnMoney()
        {
            InitializeComponent();
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {

            brows();
            //DGVCC(); 
        }
        private void brows()
        {
            LblNomber.Text = "";
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
            //所有数据
            if (this.TxtVIPname.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " VipID like '%" + TxtVIPname.Text.ToString() + "%'";
            }
            //所有数据
            if (this.CboUserName.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " UserName ='" + CboUserName.Text.ToString() + "'";
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
                    type_ = 2;
                }
                if (this.CboType.Text.ToString() == "已审核")
                {
                    type_ = 2;
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


            //CS_OutRuturnStorage

            string strsql1 = "select ID,CadeDate,ShopName,OrderCade,VipID,ZFBName,ReturnReason,ZfbWork,cast(ReturnMoney as decimal(16,2)) ReturnMoney,userName,NuserName,Barcode,NcadeDate," +
                "case when type=1 then '待处理' when type=2 then '已审核' else '关闭' end type " +
                " from CS_ReturnMoney " + strsql;

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("select count(distinct orderCade) nos,username from CS_ReturnMoney " + strsql + " group by UserName order by count(distinct orderCade) desc ", conn);
            
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql1, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();
            sqlDaper1.Fill(ds,"Count");
            sqlDaper.Fill(ds,"Data");
            conn.Close();

            WPHbROWDGV.DataSource = ds.Tables["Data"];
            WPHbROWDGV.Columns["ShopName"].HeaderText = "店铺";
            WPHbROWDGV.Columns["Type"].HeaderText = "状态";
            WPHbROWDGV.Columns["Type"].Width = 60;
            WPHbROWDGV.Columns["VipID"].HeaderText = "卖家ID";
            WPHbROWDGV.Columns["NcadeDate"].HeaderText = "处理时间";
            WPHbROWDGV.Columns["NuserName"].HeaderText = "审核员";
            WPHbROWDGV.Columns["BarCode"].HeaderText = "条码";
            WPHbROWDGV.Columns["ZFBName"].HeaderText = "支付宝名称";
            WPHbROWDGV.Columns["ZfbWork"].HeaderText = "支付宝帐号";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "订单";
            WPHbROWDGV.Columns["ReturnReason"].HeaderText = "退款问题";
            WPHbROWDGV.Columns["ReturnMoney"].HeaderText = "退款金额";
            WPHbROWDGV.Columns["CadeDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["CadeDate"].Width = 80;
            WPHbROWDGV.Columns["UserName"].HeaderText = "操作员";
            WPHbROWDGV.Columns["ID"].Visible = false;
            for (int i = 0; i < ds.Tables["Count"].Rows.Count; i++)
            {
                LblNomber.Text += ds.Tables["Count"].Rows[i]["UserName"].ToString().Trim() + ":" + ds.Tables["Count"].Rows[i]["nos"].ToString().Trim() + "  ";
            }
        }

        private void ReturnMoney_Load(object sender, EventArgs e)
        {
            DTPOrderDate.Text = (DateTime.Now.AddMonths(-6)).ToString("yyyy-MM-dd");
            this.DTStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataSet ds = new DataSet();
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='195' and m_user.userName='" + frmlogin.userID + "'";
            SqlConnection conn = sqlcon.getcon("");
            //DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper3.Fill(ds, "User");
            conn.Close();
            if (ds.Tables["User"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["User"].Rows.Count; i++)
                {
                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "新增")
                    {
                        BtnNew.Enabled = true;
                    }
                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "修改")
                    {
                        this.BtnEdit.Enabled = true;
                    }

                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "审核")
                    {
                        this.BtnEmploy.Enabled = true;
                    }
                   
                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "反审")
                    {
                        this.BtnReturnHandle.Enabled = true;
                    }
                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "作废")
                    {
                        this.BtnCanle.Enabled = true;
                    }
                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "导出EXCEL")
                    {
                        this.btnupEXcel.Enabled = true;
                    }
                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "日志")
                    {
                        this.BtnOperate.Enabled = true;
                    }
                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "取消作废")
                    {
                        this.BtnReturnCanle.Enabled = true;
                    }
                }
            }
            SqlDataAdapter sqlDaper2 = new SqlDataAdapter("SELECT distinct UserName from CS_ReturnMoney ", conn);
            conn.Open();
            sqlDaper2.Fill(ds, "User1");
            conn.Close();
           
            if (ds.Tables["User1"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["User1"].NewRow();
                ds.Tables["User1"].Rows.Add(row);
                this.CboUserName.DataSource = ds.Tables["User1"];
                CboUserName.DisplayMember = "UserName";
            }
            CboType.Text = "";
            CboUserName.Text = "";
            
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ReturnMoneyEdit ete = new ReturnMoneyEdit("", 1);
            ete.ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "待处理")
            {
                int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                ReturnMoneyEdit ete = new ReturnMoneyEdit(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString(), 2);
                ete.ShowDialog();
                brows();
                WPHbROWDGV.Rows[ID_].Selected = true;
            }
            else
            {
                MessageBox.Show("该状态不能修改！！");
            }
        }

        private void BtnEmploy_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "待处理")
            {
                int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                ReturnMoneyEdit ete = new ReturnMoneyEdit(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString(), 3);
                ete.ShowDialog();
                brows();
                WPHbROWDGV.Rows[ID_].Selected = true;
            }
            else
            {
                MessageBox.Show("该状态不能处理！！");
            }
        }

        private void BtnReturnHandle_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "已审核")
            {
                try
                {
                    int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                    SqlConnection conn = sqlcon.getcon("");
                    string strsql = "insert into CS_ReturnMoneyOperate (Operate,Operatedatetime,RID,username)values('反审','"
                                + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "','" + frmlogin.userID +
                                "');update CS_ReturnMoney set type='1' where ID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'";
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
        }

        private void BtnCanle_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "待处理")
            {
                try
                {

                    String PM = Interaction.InputBox("请输入原因", "输入原因","", 70, 100);
                    if (PM != string.Empty)
                    {
                        int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                        SqlConnection conn = sqlcon.getcon("");
                        string strsql = "insert into CS_ReturnMoneyOperate (Operate,Operatedatetime,RID,username)values('作废','"
                                    + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "','" + frmlogin.userID +
                                    "');update CS_ReturnMoney set type='0',ReturnReason='(" + PM + ")" +
                            WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ReturnReason"].Value.ToString() + 
                            "' where ID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'";
                        conn.Open();
                        SqlCommand sqlcom = new SqlCommand(strsql, conn);
                        sqlcom.ExecuteNonQuery();
                        conn.Close();
                        sqlcom.Dispose();
                        brows();
                        WPHbROWDGV.Rows[ID_].Selected = true;
                        MessageBox.Show("已作废！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("作废失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("该状态不能作废！！");
            }
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
                    if (dgrSingle.Cells["Type"].Value.ToString() == "已审核")
                    {
                        dgrSingle.DefaultCellStyle.BackColor = Color.Goldenrod;
                    }
                    if (dgrSingle.Cells["Type"].Value.ToString() == "关闭")
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
        }

        private void BtnOperate_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows.Count > 0)
            {
                Common.CommonForm comm = new Common.CommonForm("RID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'", "CS_ReturnMoneyOperate");
                comm.ShowDialog();
            }
        }

        private void BtnReturnCanle_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "关闭")
            {
                try
                {
                    String PM = Interaction.InputBox("请输入原因", "输入原因", "", 70, 100);
                    if (PM != string.Empty)
                    {
                        int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                        SqlConnection conn = sqlcon.getcon("");
                        string strsql = "insert into CS_ReturnMoneyOperate (Operate,Operatedatetime,RID,username)values('取消作废','"
                                    + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "','" + frmlogin.userID +
                                    "');update CS_ReturnMoney set type='1' where ID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'";
                        conn.Open();
                        SqlCommand sqlcom = new SqlCommand(strsql, conn);
                        sqlcom.ExecuteNonQuery();
                        conn.Close();
                        sqlcom.Dispose();
                        brows();
                        WPHbROWDGV.Rows[ID_].Selected = true;
                        MessageBox.Show("可以编辑！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("编辑失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("该状态不能编辑！！");
            }
        }
    }
}
