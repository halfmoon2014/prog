using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace Merrto.CustomerService
{
    public partial class OutRuturnStorage : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
       
        public OutRuturnStorage()
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
            LblNomber.Text = "";
            //所有数据
            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " VipName like '%" + TxtCade.Text.ToString().Trim() + "%'";
            }
            if (this.CboUserName.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " userName = '" + CboUserName.Text.ToString().Trim() + "'";
            }
            if (this.CmdCadeType.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " CadeType='" + CmdCadeType.Text.ToString().Trim() + "'";
            }
            if (this.CboShopName.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ShopName='" + CboShopName.Text.ToString().Trim() + "'";
            }
            if (this.TxtOrderCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " OrderCade like '%" + TxtOrderCade.Text.ToString().Trim() + "%'";
            }

            if (this.TxtExpress.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ExpressBarCode like '%" + TxtExpress.Text.ToString().Trim() + "%'";
            }
            if (this.CboType.Text.ToString() !="")
            {
                string type="";
                if (this.CboType.Text.ToString() == "等待寄回")
                {
                   type= " Type='1'";
                }
                else if (this.CboType.Text.ToString() == "等待收货")
                {
                    type = " Type='2'";
                }
                else if (this.CboType.Text.ToString() == "确认收货")
                {
                    type = " Type='3'";
                }
                else if (this.CboType.Text.ToString() == "换货完毕")
                {
                    type = " Type='4'";
                }
                else if (this.CboType.Text.ToString() == "退款完毕")
                {
                    type = " Type='5'";
                }
                else if (this.CboType.Text.ToString() == "ERP已核")
                {
                    type = " Type='6'";
                }
                else if (this.CboType.Text.ToString() == "订单完成")
                {
                    type = " (Type='4' or Type='5')";
                }
                else if (this.CboType.Text.ToString() == "订单关闭")
                {
                    type = " Type='0'";
                }
                else
                { 
                    type ="";
                }

                if (type != "" && strsql!="")
                {
                    strsql += " and ";
                }
                strsql +=type;

            }

            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter SdaUS = new SqlDataAdapter("Select * from M_user where Username='" + frmlogin.userID + "' ", conn);
            DataSet dsus = new DataSet();
            conn.Open();
            SdaUS.Fill(dsus, "US");
            conn.Close();
            string StrUS = "";
            if (dsus.Tables["US"].Rows[0]["ShopID"].ToString() != "")
            {
                StrUS = "Select ShopName from M_softshop where ID in (" + dsus.Tables["US"].Rows[0]["ShopID"].ToString() + ") and M_softshop.shopName=CS_OutRuturnStorage.shopName";
            }
            else
            {
                StrUS = "Select ShopName from M_softshop where  M_softshop.shopName=CS_OutRuturnStorage.shopName ";
            }
           
            if (strsql != "")
            {
                strsql += " and ";
            }
            strsql += "exists (" + StrUS + ")";
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
                strsql = " where " + strsql;
            }
            string strsql1 = "select CadeDate,ShopName,CadeType,VipName,Mobile,OrderCade,BarCode,SumMoney,"+
                "case when type=1 then '等待寄回' when type=2 then '等待收货' when type=3 then '确认收货' when type=4 then '换货完毕' when type=5 then '退款完毕'  when type=6 then 'ERP已审核' else '订单关闭' end type,Reason," +
                "Remarks2,Remarks,ExpressName,ExpressBarCode,NExpressName,NExpressBarCode,barcodedate,username from CS_OutRuturnStorage " + strsql;

            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql1, conn);
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("select count(distinct orderCade) nos,username from CS_OutRuturnStorage " + strsql + " group by UserName order by count(distinct orderCade) desc ", conn);
            conn.Open();
            sqlDaper1.Fill(ds,"count");
            sqlDaper.Fill(ds,"Date");
            conn.Close();

            WPHbROWDGV.DataSource = ds.Tables["Date"];
            WPHbROWDGV.Columns["ShopName"].HeaderText = "店铺";
            WPHbROWDGV.Columns["CadeType"].HeaderText = "类型";
            WPHbROWDGV.Columns["CadeType"].Width = 58;
            WPHbROWDGV.Columns["Type"].HeaderText = "状态";
            WPHbROWDGV.Columns["Type"].Width = 60;
            WPHbROWDGV.Columns["VipName"].HeaderText = "会员";
            WPHbROWDGV.Columns["Mobile"].HeaderText = "电话";
            WPHbROWDGV.Columns["SumMoney"].HeaderText = "金额";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "订单";
            WPHbROWDGV.Columns["BarCode"].HeaderText = "条码";
            WPHbROWDGV.Columns["Reason"].HeaderText = "原因";
            WPHbROWDGV.Columns["Reason"].Width = 150;
            WPHbROWDGV.Columns["Remarks"].HeaderText = "问题处理";
            WPHbROWDGV.Columns["Remarks"].Width = 200;
            WPHbROWDGV.Columns["CadeDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["CadeDate"].Width = 80;
            WPHbROWDGV.Columns["Remarks2"].HeaderText = "收货问题";            
            WPHbROWDGV.Columns["UserName"].HeaderText = "操作员";
            WPHbROWDGV.Columns["BarCodeDate"].HeaderText = "审核日期";
            WPHbROWDGV.Columns["NExpressName"].HeaderText = "发出快递公司";
            WPHbROWDGV.Columns["NExpressBarCode"].HeaderText = "发出快递单";
            WPHbROWDGV.Columns["ExpressName"].HeaderText = "退回快递公司";
            WPHbROWDGV.Columns["ExpressBarCode"].HeaderText = "退回快递单";
            for (int i = 0; i < ds.Tables["count"].Rows.Count; i++)
            {
                LblNomber.Text += ds.Tables["count"].Rows[i]["UserName"].ToString().Trim() + ":" + ds.Tables["count"].Rows[i]["nos"].ToString().Trim() + "  ";
            }
        
        }

        private void OutRuturnStorage_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter Usersda = new SqlDataAdapter("Select * from M_user where Username='" + frmlogin.userID + "' ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            Usersda.Fill(ds, "US");
            conn.Close();
            string StrUS = "";
            if (ds.Tables["US"].Rows[0]["ShopID"].ToString() != "")
            {
                StrUS = "Select ShopName from M_softshop where ID in (" + ds.Tables["US"].Rows[0]["ShopID"].ToString() + ")";
            }
            else
            {
                StrUS = "Select ShopName from M_softshop ";
            }
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter(StrUS, conn);
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT distinct CadeType from CS_OutRuturnStorage ", conn);
            SqlDataAdapter sqlDaper2 = new SqlDataAdapter("SELECT distinct UserName from CS_OutRuturnStorage ", conn);
            DTPOrderDate.Text = (DateTime.Now.AddMonths(-6)).ToString("yyyy-MM-dd");
            this.DTStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "ShopName");
            sqlDaper.Fill(ds, "CadeType");
            sqlDaper2.Fill(ds, "User1");
            conn.Close();
            if (ds.Tables["ShopName"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["ShopName"].NewRow();
                ds.Tables["ShopName"].Rows.Add(row);
                this.CboShopName.DataSource = ds.Tables["ShopName"];
                CboShopName.DisplayMember = "ShopName";
            }
            if (ds.Tables["CadeType"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["CadeType"].NewRow();
                ds.Tables["CadeType"].Rows.Add(row);
                this.CmdCadeType.DataSource = ds.Tables["CadeType"];
                CmdCadeType.DisplayMember = "CadeType";
            }
            if (ds.Tables["User1"].Rows.Count > 0)
            {
                DataRow row = ds.Tables["User1"].NewRow();
                ds.Tables["User1"].Rows.Add(row);
                this.CboUserName.DataSource = ds.Tables["User1"];
                CboUserName.DisplayMember = "UserName";
            }
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='187' and m_user.userName='" + frmlogin.userID + "' order by Sort";
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper3.Fill(ds,"User");
            conn.Close();
            if (ds.Tables["User"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["User"].Rows.Count; i++)
                {
                    Button BtnNumber = new Button()
                    {
                        Text = ds.Tables["User"].Rows[i]["Name"].ToString(),
                        Name = ds.Tables["User"].Rows[i]["Cade"].ToString(),
                        Location = new System.Drawing.Point(i * 85+5, 2),
                        Font = new System.Drawing.Font("宋体", 9F),
                        Size = new System.Drawing.Size(84, 25),
                        UseVisualStyleBackColor = true
                    };
                    BtnNumber.Click += new System.EventHandler(this.BtnNumber_Click);
                    this.GpbBtn.Controls.Add(BtnNumber);
                }
            }
            CboShopName.Text = "";
            CboType.Text = "";
            CboUserName.Text = "";
            CmdCadeType.Text = "";
        }
        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            OutRuturnStorageEDIT ors;
            switch (btn.Name)
            {
                case "New": //数据参数新增
                    ors = new OutRuturnStorageEDIT("", 1);
                    ors.ShowDialog();
                    break;
                case "Edit": //数据参数新增
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "等待寄回" || WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "确认收货" || WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "等待收货")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlCommand sqlcom = new SqlCommand("insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('修改','" + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "','" + frmlogin.userID + "');", conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            ors = new OutRuturnStorageEDIT(WPHbROWDGV[5, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString(), 2);
                            ors.ShowDialog();
                            brows();
                            WPHbROWDGV.Rows[ID_].Selected = true;
                        }
                        else
                        {
                            MessageBox.Show("此状态不能修改单据！！");
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有你要修改的数据！！");
                    }
                    break;
                case "Select": //数据参数新增
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        ors = new OutRuturnStorageEDIT(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString(), 0);
                        ors.ShowDialog();
                        BTNbROW_Click(sender, e);
                    }
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
                case "CK": //从新发货
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["CadeType"].Value.ToString() != "退货" && WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "ERP已审核")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            OutStorageEdit orsE = new OutStorageEdit(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString(), 1);
                            orsE.ShowDialog();
                            brows();
                        }
                        else
                        {
                            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() != "ERP已审核")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                            {
                                MessageBox.Show("此单ERP未审核不能从新发货！！");
                            }
                            else
                            {
                                MessageBox.Show("此单为退货不能从新发货！！");
                            }
                        }
                    }
                    break;
                case "look": //退款审核
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["CadeType"].Value.ToString() == "退货" && WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "ERP已审核")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            String PM = Interaction.InputBox("请输入金额", "输入金额", WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["SumMoney"].Value.ToString(), 70, 100);
                            if (PM != string.Empty)
                            {
                                SqlConnection conn = sqlcon.getcon("");
                                conn.Open();

                                SqlCommand sqlcom = new SqlCommand("insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('退款审核','" + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "','" + frmlogin.userID + "'); update CS_OutRuturnStorage set Type='5',sumMoney='" + PM + "' where OrderCade='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "'and BarCode='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["BarCode"].Value.ToString() + "'", conn);
                                sqlcom.ExecuteNonQuery();
                                conn.Close();
                                sqlcom.Dispose();
                                brows();
                            }
                        }
                        else
                        {
                            if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() != "ERP已审核")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                            {
                                MessageBox.Show("此单ERP未审核不能退款！！");
                            }
                            else
                            {

                                MessageBox.Show("此单不是退货不能退款！！");
                            }
                        }
                    }
                    break;
                case "Canle": //作废
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "等待寄回" || WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "等待收货")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {

                            String PM = Interaction.InputBox("请输入原因", "输入原因", "", 70, 100);
                            if (PM != string.Empty)
                            {
                                int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                                SqlConnection conn = sqlcon.getcon("");
                                conn.Open();
                                SqlCommand sqlcom = new SqlCommand("insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('作废','"
                                    + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "','" + frmlogin.userID +
                                    "');update CS_OutRuturnStorage set Type='0',Remarks='(" + PM + ")" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Remarks"].Value.ToString() +
                                    "' where OrderCade='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "'", conn);
                                sqlcom.ExecuteNonQuery();
                                conn.Close();
                                sqlcom.Dispose();
                                
                                WPHbROWDGV.Rows[ID_].Selected = true;
                                brows();
                            }
                        }
                        else
                        {
                            MessageBox.Show("要先确认收货才可以作废！！");
                        }
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

                case "Returnlook":  //取消退款
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "退款完毕")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand("insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('取消退款','" + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "','" + frmlogin.userID + "');update CS_OutRuturnStorage set Type='6' where OrderCade='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "'", conn);
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
                case "ReturnERPlook"://取消审核
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        if (WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["Type"].Value.ToString() == "ERP已审核")//取状态为1的才能修改，0为作废，1为编辑，2为审核
                        {
                            int ID_ = WPHbROWDGV.CurrentCell.RowIndex;
                            SqlConnection conn = sqlcon.getcon("");
                            conn.Open();
                            SqlCommand sqlcom = new SqlCommand("insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('取消审核','" + DateTime.Now.ToString() + "','" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "','" + frmlogin.userID + "');update CS_OutRuturnStorage set Type='3' where OrderCade='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "'", conn);
                            sqlcom.ExecuteNonQuery();
                            conn.Close();
                            sqlcom.Dispose();
                            WPHbROWDGV.Rows[ID_].Selected = true;
                            brows();
                        }
                        else
                        {
                            MessageBox.Show("要先确认收货才可以取消审核！！");
                        }
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
                    if (dgrSingle.Cells["Remarks2"].Value.ToString() != "")
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    if (dgrSingle.Cells["Remarks"].Value.ToString().IndexOf("(领用生成)")>-1)
                    {
                        dgrSingle.DefaultCellStyle.BackColor = Color.Goldenrod;
                    }
                    if (dgrSingle.Cells["Type"].Value.ToString() == "订单关闭")
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

        private void BtnOperate_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows.Count > 0)
            {
                Common.CommonForm comm = new Common.CommonForm("OrderCade='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString() + "'", "CS_OutRuturnStorageOperate");
                comm.ShowDialog();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日&encode=utf8");
        }

  
 
    }
}
