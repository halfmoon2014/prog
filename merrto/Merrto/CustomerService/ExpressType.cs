using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Merrto.CustomerService
{
    public partial class ExpressType : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public ExpressType()
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
            string strsql = "";

            //所有数据
            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " expressBarcode like '%" + TxtCade.Text.ToString() + "%'";
            }
            //所有数据
            if (this.TxtVIPname.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " VipName like '%" + TxtVIPname.Text.ToString() + "%'";
            }

            if (this.CboRemarks.Text.ToString() == " " || this.CboRemarks.Text.ToString() == "")
            {
            }
            else
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Remarks like '%" + CboRemarks.Text.ToString() + "%'";

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


            //CS_OutRuturnStorage

            strsql = "select ID,CadeDate,ShopName,ExpressName,ExpressBarCode,OrderCade,VipName,Reason,Feedback,UserName,ReturnType,SumMoney,ExpressMoney," +
                "case when type=1 then '待处理' when type=2 then '处理中' when type=3 then '完结' else '关闭' end type," +
                "Remarks,NuserName,NcadeDate from CS_ExpressType " + strsql;

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();

            sqlDaper.Fill(ds);
            conn.Close();

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["Feedback"].HeaderText = "反馈";
            WPHbROWDGV.Columns["ShopName"].HeaderText = "店铺";
            WPHbROWDGV.Columns["Type"].HeaderText = "状态";
            WPHbROWDGV.Columns["Type"].Width = 60;
            WPHbROWDGV.Columns["ReturnType"].HeaderText = "退款";
            WPHbROWDGV.Columns["ReturnType"].Width = 60;
            WPHbROWDGV.Columns["VipName"].HeaderText = "会员";
            WPHbROWDGV.Columns["NcadeDate"].HeaderText = "处理时间";
            WPHbROWDGV.Columns["NuserName"].HeaderText = "操作处理";
            WPHbROWDGV.Columns["ExpressName"].HeaderText = "快递公司";
            WPHbROWDGV.Columns["ExpressBarCode"].HeaderText = "快递单";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "订单";
            WPHbROWDGV.Columns["Reason"].HeaderText = "问题";
            WPHbROWDGV.Columns["SumMoney"].HeaderText = "金额";
            WPHbROWDGV.Columns["ExpressMoney"].HeaderText = "快递费";
            WPHbROWDGV.Columns["Reason"].Width = 150;
            WPHbROWDGV.Columns["Remarks"].HeaderText = "处理结果";
            WPHbROWDGV.Columns["Remarks"].Width = 200;
            WPHbROWDGV.Columns["CadeDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["CadeDate"].Width = 80;
            WPHbROWDGV.Columns["UserName"].HeaderText = "操作员";
            WPHbROWDGV.Columns["ID"].Visible = false;
        }


        private void ExpressType_Load(object sender, EventArgs e)
        {
            DTPOrderDate.Text = (DateTime.Now.AddMonths(-6)).ToString("yyyy-MM-dd");
            this.DTStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataSet ds = new DataSet();
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='194' and m_user.userName='" + frmlogin.userID + "' order by Sort";
            SqlConnection conn = sqlcon.getcon("");
            //DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper3.Fill(ds, "User");
            conn.Close();
            if (ds.Tables["User"].Rows.Count > 0)
            {
                if (ds.Tables["User"].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables["User"].Rows.Count; i++)
                    {
                        Button BtnNumber = new Button()
                        {
                            Text = ds.Tables["User"].Rows[i]["Name"].ToString(),
                            Name = ds.Tables["User"].Rows[i]["Cade"].ToString(),
                            Location = new System.Drawing.Point(i * 80+5, 2),
                            Font = new System.Drawing.Font("宋体", 9F),
                            Size =new System.Drawing.Size(75,30),
                            UseVisualStyleBackColor = true
                        };
                        BtnNumber.Click += new System.EventHandler(this.BtnNumber_Click);
                        this.GpbBtn.Controls.Add(BtnNumber);
                    }
                }
            }
        }

        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ExpressTypeEdit ete;
            switch (btn.Name)
            {
                case "New":
                    ete = new ExpressTypeEdit("", 1);
                    ete.ShowDialog();
                    brows();
                    break;
                case "Edit":
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "待处理")
                        {
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            ete = new ExpressTypeEdit(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString(), 2);
                            ete.ShowDialog();
                            brows();
                            WPHbROWDGV.Rows[ID_].Selected = true;
                        }
                        else
                        {
                            MessageBox.Show("该状态不能修改！！");
                        }
                    }
                    break;
                case "Feedback":
                    if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "待处理" || WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "处理中")
                    {
                        try
                        {
                            String PM = Interaction.InputBox("请输入问题", "输入问题", WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Feedback"].Value.ToString(), 70, 100);
                            if (PM != string.Empty)
                            {
                                int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                                SqlConnection conn = sqlcon.getcon("");
                                string strsql = "update CS_ExpressType set Feedback='" + PM + "',type='2' where ID='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
                                conn.Open();
                                SqlCommand sqlcom = new SqlCommand(strsql, conn);
                                sqlcom.ExecuteNonQuery();
                                conn.Close();
                                sqlcom.Dispose();
                                brows();
                                WPHbROWDGV.Rows[ID_].Selected = true;
                                MessageBox.Show("反馈成功！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("反馈失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该状态不能反馈！！");
                    }
                    break;
                case "Handle":
                    if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "处理中")
                    {
                        int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                        ete = new ExpressTypeEdit(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString(), 3);
                        ete.ShowDialog();
                        brows();
                        WPHbROWDGV.Rows[ID_].Selected = true;
                    }
                    else
                    {
                        MessageBox.Show("该状态不能处理！！");
                    }
                    break;
                case "ReturnHandle":
                    if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "完结")
                    {
                        try
                        {
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            string strsql = "update CS_ExpressType set type='2' where ID='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
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
                case "Excel":
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
                case "Canle":
                    if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "待处理")
                    {
                        try
                        {
                            String PM = Interaction.InputBox("请输入原因", "输入原因", "", 70, 100);
                            if (PM != string.Empty)
                            {
                                int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                                SqlConnection conn = sqlcon.getcon("");
                                string strsql = "update CS_ExpressType set type='0',Remarks='(" + PM + ")" +
                                    WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Remarks"].Value.ToString() +
                                    "' where ID='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
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
                    break;
                case "ReturnCanle":
                    if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "关闭")
                    {
                        try
                        {
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            string strsql = "update CS_ExpressType set type='1' where ID='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand(strsql, conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            brows();
                            WPHbROWDGV.Rows[ID_].Selected = true;
                            MessageBox.Show("可以编辑！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    break;
                    case "Operate":
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        Common.CommonForm comm = new Common.CommonForm("OrderCade='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "'", "CS_OutRuturnStorageOperate");
                        comm.ShowDialog();
                    }
                    break;
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
                        dgrSingle.DefaultCellStyle.BackColor = System.Drawing.Color.Goldenrod;
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

        private void WPHbROWDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewTextBoxColumn dgv_Text = new DataGridViewTextBoxColumn();
            for (int i = 0; i < WPHbROWDGV.Rows.Count; i++)
            {
                int j = i + 1;
                WPHbROWDGV.Rows[i].HeaderCell.Value = j.ToString();
            }
        }
    }
}
