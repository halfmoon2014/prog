using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace Merrto.CustomerService
{
    public partial class QuestionOrderCade : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public QuestionOrderCade()
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


            strsql = "select ID,CadeDate,ShopName,OrderCade,VipID,Remarks,ExpressName,ExpressBarCode,userName,NuserName,NcadeDate," +
                "case when type=1 then '待处理' when type=2 then '处理中' when type=3 then '完结' else '关闭' end type " +
                " from CS_QuestionOrderCade " + strsql;

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            
            conn.Open();

            sqlDaper.Fill(ds);
            conn.Close();

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["ShopName"].HeaderText = "店铺";
            WPHbROWDGV.Columns["Type"].HeaderText = "状态";
            WPHbROWDGV.Columns["Type"].Width = 60;
            WPHbROWDGV.Columns["VipID"].HeaderText = "卖家ID";
            WPHbROWDGV.Columns["NcadeDate"].HeaderText = "处理时间";
            WPHbROWDGV.Columns["NuserName"].HeaderText = "处理员";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "订单";
            WPHbROWDGV.Columns["CadeDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["CadeDate"].Width = 80;
            WPHbROWDGV.Columns["UserName"].HeaderText = "操作员";
            WPHbROWDGV.Columns["ExpressName"].HeaderText = "快递公司";
            WPHbROWDGV.Columns["ExpressBarCode"].HeaderText = "快递单";
            WPHbROWDGV.Columns["Remarks"].HeaderText = "问题";
            WPHbROWDGV.Columns["ID"].Visible = false;
        }

        private void QuestionOrderCade_Load(object sender, EventArgs e)
        {
            DTPOrderDate.Text = (DateTime.Now.AddMonths(-6)).ToString("yyyy-MM-dd");
            this.DTStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataSet ds = new DataSet();
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='196' and m_user.userName='" + frmlogin.userID + "'";
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

                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "处理")
                    {
                        this.BtnEmploy.Enabled = true;
                    }
                    if (ds.Tables["User"].Rows[i]["Name"].ToString() == "完结")
                    {
                        this.BtnHandle.Enabled = true;
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
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            QuestionOrderCadeEdit qot = new QuestionOrderCadeEdit("",1);
            qot.ShowDialog();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {

            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "待处理")
            {
                int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                QuestionOrderCadeEdit ete = new QuestionOrderCadeEdit(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString(), 2);
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
                try
                {
                    int ID_=WPHbROWDGV.CurrentCell.RowIndex;
                    SqlConnection conn = sqlcon.getcon("");
                    string strsql = "insert into CS_QuestionOrderCadeOperate (Operate,Operatedatetime,RID,username)values('处理','" + DateTime.Now.ToString() + "','" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "','" + frmlogin.userID + "');update CS_QuestionOrderCade set type='2' where ID='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(strsql, conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();
                    brows();
                    WPHbROWDGV.Rows[ID_].Selected = true;
                    MessageBox.Show("领用成功！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("领用失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("该状态不能领用！！");
            }
        }

        private void BtnHandle_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "处理中")
            {
                int ID_=WPHbROWDGV.CurrentCell.RowIndex;
                QuestionOrderCadeEdit ete = new QuestionOrderCadeEdit(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString(), 3);
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
            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "完结")
            {
                try
                {
                    int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                    SqlConnection conn = sqlcon.getcon("");
                    string strsql = "insert into CS_QuestionOrderCadeOperate (Operate,Operatedatetime,RID,username)values('反审','" + DateTime.Now.ToString() + "','" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "','" + frmlogin.userID + "');update CS_QuestionOrderCade set type='2' where ID='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
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
                        string strsql = "insert into CS_QuestionOrderCadeOperate (Operate,Operatedatetime,RID,username)values('作废','" 
                            + DateTime.Now.ToString() + "','" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "','" + frmlogin.userID +
                            "');update CS_QuestionOrderCade set type='0',Remarks='(" + PM + ")" + 
                            WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Remarks"].Value.ToString() + "' where ID='" 
                            + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
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
                    if (dgrSingle.Cells["Type"].Value.ToString() == "完结")
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
                Common.CommonForm comm = new Common.CommonForm("RID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'", "CS_QuestionOrderCadeOperate");
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
                        string strsql = "insert into CS_QuestionOrderCadeOperate (Operate,Operatedatetime,RID,username)values('消取作废','"
                            + DateTime.Now.ToString() + "','" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "','" + frmlogin.userID +
                            "');update CS_QuestionOrderCade set type='1' where ID='"
                            + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
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
                MessageBox.Show("该状态不能作废！！");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
