using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.SingleSupplement
{
    public partial class ActivityFrm : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public ActivityFrm()
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
                strsql = strsql + " SS_ActivityList.Cade like '%" + TxtCade.Text.ToString() + "%'";
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

            strsql = "select SS_ActivityList.ID,SS_ActivityList.Cade,CadeDate,Name,Case when type=1 then '预计' else '发货'end as Type,'总数量：'++cast(Qty as varchar(20)) as QTy,UserName,listtype from SS_ActivityList " +
                     "left join (select RID,sum(QTY) as QTY from SS_ActivityDetailList group by RID) temp on temp.RID=SS_ActivityList.ID " + strsql;

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();

            sqlDaper.Fill(ds);
            conn.Close();

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["Cade"].HeaderText = "凭证号";
            WPHbROWDGV.Columns["CadeDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["Name"].HeaderText = "活动";
            WPHbROWDGV.Columns["Type"].HeaderText = "单据状态";
            WPHbROWDGV.Columns["QTy"].HeaderText = "数量";
            WPHbROWDGV.Columns["UserName"].HeaderText = "操作人员";
            WPHbROWDGV.Columns["ID"].Visible = false;
            WPHbROWDGV.Columns["listtype"].Visible = false;
        }

        private void WPHbROWDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToInt32(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["listtype"].Value.ToString()) == 0)
            {
                lblType.Text = "作废";
            }
            if (Convert.ToInt32(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["listtype"].Value.ToString()) == 2)
            {
                lblType.Text = "审核";
            }
            if (Convert.ToInt32(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["listtype"].Value.ToString()) == 1)
            {
                lblType.Text = "编辑";
            }
            if (Convert.ToInt32(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["listtype"].Value.ToString()) == 3)
            {
                lblType.Text = "活动结束";
            }
        }

        private void ActivityFrm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='193' and m_user.userName='" + frmlogin.userID + "' order by Sort";
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper3.Fill(ds, "User");
            conn.Close();
            if (ds.Tables["User"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["User"].Rows.Count; i++)
                {
                    Button BtnNumber = new Button()
                    {
                        Text = ds.Tables["User"].Rows[i]["Name"].ToString(),
                        Name = ds.Tables["User"].Rows[i]["Cade"].ToString(),
                        Location = new System.Drawing.Point(i * 85 + 5, 2),
                        Font = new System.Drawing.Font("宋体", 9F),
                        Size=new System.Drawing.Size(84,25),
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
           ActivityEditFrm Aef;
            switch (btn.Name)
            {
                case "New": //数据参数新增
                    Aef = new ActivityEditFrm(0, 1);
                    Aef.ShowDialog();
                    brows();
                    break;
                case "Edit": //数据参数新增
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["listtype"].Value.ToString()) == 1)//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            Aef = new ActivityEditFrm(Convert.ToInt32(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString()), 1);
                            Aef.ShowDialog();
                            brows();
                        }
                        else
                        {
                            MessageBox.Show("此单据不能修改！！");
                        }
                    }
                    break;
                case "Select": //数据参数新增
                    Aef = new ActivityEditFrm(Convert.ToInt32(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString()), 0);
                    Aef.ShowDialog();
                    brows();
                    break;
                case "ERPlook": //ERP审核
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "确认收货")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand("insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('ERP审核','" + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString().Trim() + "','" + frmlogin.userID + "');update CS_OutRuturnStorage set Type='6' where OrderCade='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString().Trim() + "' and type='3'", conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();

                            WPHbROWDGV.Rows[ID_].Selected = true;
                            brows();
                        }
                        else
                        {
                            MessageBox.Show("要先确认收货才可以审核！！");

                        }
                    }
                    break;
               
                case "look": //退款审核
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["listtype"].Value.ToString() == "1")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {


                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand("insert into SS_ActivityOperateList (Operate,Operatedatetime,RID,username)values('审核','"
                                + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "','" + frmlogin.userID +
                                "');update SS_ActivityList set listtype='2' where ID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'", conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            brows();
                            WPHbROWDGV.Rows[ID_].Selected = true;

                        }
                        else
                        {

                            MessageBox.Show("此单不可以审核！！");

                        }
                    }
                    break;
                case "Canle": //作废
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["listtype"].Value.ToString() == "1")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {


                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand("insert into SS_ActivityOperateList (Operate,Operatedatetime,RID,username)values('作废','"
                                + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "','" + frmlogin.userID +
                                "');update SS_ActivityList set listtype='0' where ID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'", conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            brows();
                            WPHbROWDGV.Rows[ID_].Selected = true;

                        }
                        else
                        {

                            MessageBox.Show("此单不可以作废！！");

                        }
                    }
                    break;
                case "Introduction"://取消作废
                   
                    break;

                case "ReturnLook":  //取消退款
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["listtype"].Value.ToString() == "2")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {


                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand("insert into SS_ActivityOperateList (Operate,Operatedatetime,RID,username)values('反审','"
                                + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "','" + frmlogin.userID +
                                "');update SS_ActivityList set listtype='1' where ID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'", conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            brows();
                            WPHbROWDGV.Rows[ID_].Selected = true;

                        }
                        else
                        {

                            MessageBox.Show("此单不可以作废！！");

                        }
                    }
                    break;
                case "ActivitiesEnd"://取消审核
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["listtype"].Value.ToString() == "2")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand("insert into SS_ActivityOperateList (Operate,Operatedatetime,RID,username)values('活动结束','"
                                + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "','" + frmlogin.userID +
                                "');update SS_ActivityList set listtype='3' where ID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'", conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            brows();
                            WPHbROWDGV.Rows[ID_].Selected = true;

                        }
                        else
                        {

                            MessageBox.Show("此单不可以结束！！");

                        }
                    }
                    break;
                case "Operate":
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        Common.CommonForm comm = new Common.CommonForm("RID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'", "SS_ActivityOperateList");
                        comm.ShowDialog();
                    }
                    break;
            }
        }

        
    }
}
