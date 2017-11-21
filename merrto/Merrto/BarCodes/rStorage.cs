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
    public partial class rStorage : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.SendSMS SMS = new baseclass.SendSMS();
        public rStorage()
        {
            InitializeComponent();
        }

        private void rStorage_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT StockID,StockName from M_Stock ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "Stock");
            conn.Close();
            if (ds.Tables["Stock"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["Stock"].NewRow();
                ds.Tables["Stock"].Rows.Add(row);
                CmdShop.DataSource = ds.Tables["Stock"];
                CmdShop.ValueMember = "StockID";
                CmdShop.DisplayMember = "StockName";
            }
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='168' and m_user.userName='" + frmlogin.userID + "' order by Sort";
            //SqlConnection conn = sqlcon.getcon("");
            //DataSet ds = new DataSet();
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
                        Location = new System.Drawing.Point(i * 78+5, 2),
                        Font = new System.Drawing.Font("宋体", 9F),
                        Size = new System.Drawing.Size(84, 25),
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
            rStorageNew ors;
            switch (btn.Name)
            {
                case "New": //数据参数新增
                    ors = new rStorageNew(0, 1);
                    ors.ShowDialog();
                    brows();
                    break;
                case "Select": //数据参数查看
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        rStorageNew rsn = new rStorageNew(Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()), 0);
                        rsn.ShowDialog();
                        brows();
                    }
                    break;
                case "Edit": //数据参数修改
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(WPHbROWDGV[10, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 1)//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            ors = new rStorageNew(Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()), 1);
                            ors.ShowDialog();
                            brows();
                        }
                        else
                        {
                            MessageBox.Show("此单据不能修改！！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有你要修改的数据！！");
                    }
                    break;
                case "ToVoid": //作废
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(WPHbROWDGV[10, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 1)
                        {
                            SqlConnection conn = sqlcon.getcon("");
                            string sql = "SELECT RID from BR_PassToStockReturn where Rid='" + Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) +
                                "' union all SELECT RID from BR_PassToStock where Rid='" + Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) + "'";
                            SqlDataAdapter sqlDaper = new SqlDataAdapter(sql, conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            sqlDaper.Fill(ds, "RID");
                            conn.Close();
                            if (ds.Tables["RID"].Rows.Count > 0)
                            {
                                MessageBox.Show("此单于生成入库（退货）不能作废！！");
                                return;
                            }

                            //SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            string str = "insert into BR_RstorageOperateList (Operate,Operatedatetime,RID,username)values('作废','" + DateTime.Now.ToString() + "','" + Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) + "','" + frmlogin.userID + "')" +
                                "update BR_RStorageList set listtype=0 where id='" + Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) + "'";
                            SqlCommand sqlcom = new SqlCommand(str, conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            BTNbROW_Click(sender, e);
                            MessageBox.Show("此单作废！！");
                        }
                        else
                        {
                            MessageBox.Show("此单已审核或已作废不能作废！！");
                        }
                    }
                    break;
                case "look": //审核
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(WPHbROWDGV[10, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 1)
                        {
                            SqlConnection conn = sqlcon.getcon("");
                            string str = "insert into BR_RstorageOperateList (Operate,Operatedatetime,RID,username)values('审核','" + DateTime.Now.ToString() + "','" + Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) + "','" + frmlogin.userID + "')" +
                                "update BR_RStorageList set listtype=2 where id='" + Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) + "'";
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand(str, conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            MessageBox.Show("审核成功！！");

                            string sql = "SELECT * from M_user  where mobile !=''";
                            string sqlstr = "select item_no,s_color,mobile,sum(qty)qty from BR_PassToStock " +
                                            "left join  M_DProductSubscribe on M_DProductSubscribe.pid=BR_PassToStock.pid " +
                                            "left join m_user on M_DProductSubscribe.username=m_user.username " +
                                            "left join M_product on M_product.id=BR_PassToStock.pid " +
                                            "left join M_productsub on M_productsub.id=BR_PassToStock.ColourID " +
                                            "where BR_PassToStock.rid='" + Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) + "' group by item_no,s_color,mobile";
                            SqlDataAdapter sqldaper2 = new SqlDataAdapter("select * from M_ShortMessage", conn);
                            SqlDataAdapter sqlDaper = new SqlDataAdapter(sql, conn);
                            SqlDataAdapter sqlDaper1 = new SqlDataAdapter(sqlstr, conn);
                            DataSet ds = new DataSet();
                            conn.Open();
                            sqlDaper1.Fill(ds, "Data");
                            sqldaper2.Fill(ds, "MSM");
                            sqlDaper.Fill(ds, "RID");
                            conn.Close();
                            if (ds.Tables["MSM"].Rows[0]["Type"].ToString() == "True")
                            {
                                for (int i = 0; i < ds.Tables["RID"].Rows.Count; i++)
                                {
                                    string strs = "";
                                    for (int j = 0; j < ds.Tables["Data"].Rows.Count; j++)
                                    {
                                        if (ds.Tables["RID"].Rows[i]["mobile"].ToString() == ds.Tables["Data"].Rows[j]["mobile"].ToString())
                                        {
                                            strs += ds.Tables["Data"].Rows[j]["item_no"].ToString() + "." + ds.Tables["Data"].Rows[j]["s_color"].ToString() + "." + ds.Tables["Data"].Rows[j]["qty"].ToString() + "|";
                                        }
                                    }
                                    if (strs != "" && ds.Tables["RID"].Rows[i]["mobile"].ToString() != "")
                                    {
                                        SMS.GETpost("ac=send&uid=" + ds.Tables["MSM"].Rows[0]["UserName"].ToString() +
                                            "&pwd=" + ds.Tables["MSM"].Rows[0]["PWD"].ToString() + "&mobile=" + ds.Tables["RID"].Rows[i]["mobile"].ToString() +
                                            "&content=", ds.Tables["MSM"].Rows[0]["IPAdd"].ToString(), strs + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Cade"].Value.ToString() + "&encode=utf8");
                                        ///http://api.cnsms.cn/?ac=send&uid=100860&pwd=fa246d0262c3925617b0c72bb20eeb1d&mobile=15102110086,18297974783&content=%D6%D0%B9%FA%B6%CC%D0%C5%CD%F8%B7%A2%CB%CD%B2%E2%CA%D4
                                    }
                                }
                            }
                            BTNbROW_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("此单已审核或已作废不能作废！！");
                        }
                    }
                    break;
                case "Returnlook": //反审核
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(WPHbROWDGV[10, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 2)
                        {
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            string str = "insert into BR_RstorageOperateList (Operate,Operatedatetime,RID,username)values('反审','" + DateTime.Now.ToString() + "','" + Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) + "','" + frmlogin.userID + "')" +
                                "update BR_RStorageList set listtype=1 where id='" + Convert.ToInt32(WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) + "'";
                            SqlCommand sqlcom = new SqlCommand(str, conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            BTNbROW_Click(sender, e);
                            MessageBox.Show("此单可以修改！！");
                        }
                        else
                        {
                            MessageBox.Show("此单没有审核不能反审！！");
                        }
                    }
                    break;
                case "Operate": //日志
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        Common.CommonForm comm = new Common.CommonForm("RID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'", "BR_RstorageOperateList");
                        comm.ShowDialog();
                    }
                    break;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            rStorageNew rsn = new rStorageNew(0,1);
            rsn.ShowDialog();
            brows();
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            brows();
            if (WPHbROWDGV.Rows.Count > 0)
            {
                WPHbROWDGV.Rows[0].Selected = true;
                WPHbROWDGV.CurrentCell = WPHbROWDGV.Rows[0].Cells[1];
            }
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
                strsql = strsql + " BR_RStorageList.Cade like '%" + TxtCade.Text.ToString().Trim() + "%'";
            }
            if (this.CmdShop.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " BR_RStorageList.StockID='" + CmdShop.SelectedValue.ToString() + "'";
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
            strsql = "select BR_RStorageList.ID,BR_RStorageList.Cade,CadeDate,OrderCade,title,Fid,M_Stock.StockName,BR_RStorageList.StockID,'总数量：'++cast(Qty as varchar(20)) as QTy,UserName,listtype from BR_RStorageList " +
               "left join m_Factory on m_Factory.id=Fid " +
               "left join M_Stock on M_Stock.StockID=BR_RStorageList.StockID " +
               "left join (select RID,sum(QTY) as QTY from BR_RStroageDetailList group by RID) temp on temp.RID=BR_RStorageList.ID " + strsql;

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
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "单据号";
            WPHbROWDGV.Columns["title"].HeaderText = "供货商";
            WPHbROWDGV.Columns["StockName"].HeaderText = "仓库名称";
            WPHbROWDGV.Columns["QTy"].HeaderText = "数量";
            WPHbROWDGV.Columns["UserName"].HeaderText = "操作人员";
            WPHbROWDGV.Columns["ID"].Visible = false;
            WPHbROWDGV.Columns["Fid"].Visible = false;
            WPHbROWDGV.Columns["StockID"].Visible = false;
            WPHbROWDGV.Columns["listtype"].Visible = false;
        }

        
        private void WPHbROWDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToInt32(WPHbROWDGV.Rows[e.RowIndex].Cells["listtype"].Value.ToString()) == 0)
            {
                lblType.Text = "作废";
            }
            if (Convert.ToInt32(WPHbROWDGV.Rows[e.RowIndex].Cells["listtype"].Value.ToString()) == 2)
            {
                lblType.Text = "审核";
            }
            if (Convert.ToInt32(WPHbROWDGV.Rows[e.RowIndex].Cells["listtype"].Value.ToString()) == 1)
            {
                lblType.Text = "编辑";
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
                    if (dgrSingle.Cells["listtype"].Value.ToString().Contains("2"))
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
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
