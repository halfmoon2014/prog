using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Merrto.CustomerService
{
    public partial class OutRuturnStorageBrow : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public OutRuturnStorageBrow()
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
                strsql = strsql + " VipName like '%" + TxtCade.Text.ToString().Trim() + "%'";
            }
            //所有数据
            if (this.TxtOrderCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " OrderCade like '%" + TxtOrderCade.Text.ToString().Trim() + "%'";
            }
            //所有数据
            if (this.TxtBarCode.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " BarCode like '%" + TxtBarCode.Text.ToString().Trim() + "%'";
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
            if (this.TxtExpress.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " ExpressBarCode like '%" + TxtExpress.Text.ToString().Trim() + "%'";
            }
            if (this.CmdCadeType.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " CadeType='" + CmdCadeType.Text.ToString().Trim() + "'";
            }

            if (this.CboType.Text.ToString() != "")
            {
                string type = "";
                if (this.CboType.Text.ToString() == "等待寄回")
                {
                    type = " Type='1'";
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
                    type = "";
                }

                if (type != "" && strsql != "")
                {
                    strsql += " and ";
                }
                strsql += type;

            }
            if (CboDate.Text.ToString() == "")
            {
                MessageBox.Show("时间类型不能为空！！");
                return;
            }
            else
            {
                if (this.DTPOrderDate.Value.ToString() != "")
                {
                    if (strsql != "")
                    {
                        strsql += " and ";
                    }
                    if (CboDate.Text.ToString() == "登记时间")
                    {
                        strsql += " CadeDate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000'";
                    }
                    else
                    {
                        strsql += " BarCodeDate Between '" + DTPOrderDate.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DTStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000'";
                    }
                    
                }
            }
            if (strsql != "")
            {
                strsql = " where " + strsql;
            }

            strsql = "SELECT ID,ShopName,CadeType,case when type=1 then '等待寄回' when type=2 then '等待收货' when type=3 then '确认收货' when type=4then '换货完毕' when type=5 then '退款完毕'   when type=6 then 'ERP已审核' else '订单关闭' end type,CadeDate,BarCodeDate,VipName,Mobile,OrderCade,BarCode,Reason,Remarks,Remarks2,ExpressName,ExpressBarCode,NExpressName,NExpressBarCode," +
                "sumMoney,userName,1 as list from CS_OutRuturnStorage " + strsql;

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();

            sqlDaper.Fill(ds);
            conn.Close();
             
            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["ShopName"].HeaderText = "店铺";
            WPHbROWDGV.Columns["CadeType"].HeaderText = "类型";
            WPHbROWDGV.Columns["VipName"].HeaderText = "会员";
            WPHbROWDGV.Columns["Mobile"].HeaderText = "电话";
            WPHbROWDGV.Columns["OrderCade"].HeaderText = "订单";
            WPHbROWDGV.Columns["CadeDate"].HeaderText = "日期";
            WPHbROWDGV.Columns["BarCodeDate"].HeaderText = "审核日期";
            WPHbROWDGV.Columns["BarCode"].HeaderText = "退回条码";
            WPHbROWDGV.Columns["Remarks"].HeaderText = "备注";
            WPHbROWDGV.Columns["Reason"].HeaderText = "原因";
            WPHbROWDGV.Columns["sumMoney"].HeaderText = "金额";
            WPHbROWDGV.Columns["Reason"].Width = 100;
            WPHbROWDGV.Columns["Remarks2"].HeaderText = "收货问题";
            WPHbROWDGV.Columns["ExpressName"].HeaderText = "退回快递公司";
            WPHbROWDGV.Columns["ExpressBarCode"].HeaderText = "退回快递单";
            WPHbROWDGV.Columns["NExpressName"].HeaderText = "发出快递公司";
            WPHbROWDGV.Columns["NExpressBarCode"].HeaderText = "发出快递单";
            WPHbROWDGV.Columns["Type"].HeaderText = "状态";
            WPHbROWDGV.Columns["UserName"].HeaderText = "操作员";
            WPHbROWDGV.Columns["ID"].Visible = false;
            WPHbROWDGV.Columns["List"].Visible = false;
        }

        private void OutRuturnStorageBrow_Load(object sender, EventArgs e)
        {
            CboDate.Text = "收货时间";
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT distinct ShopName from CS_OutRuturnStorage ", conn);
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT distinct CadeType from CS_OutRuturnStorage ", conn);
            DTPOrderDate.Text = (DateTime.Now.AddMonths(-6)).ToString("yyyy-MM-dd");
            this.DTStop.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "ShopName");
            sqlDaper.Fill(ds, "CadeType");
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
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='188' and m_user.userName='" + frmlogin.userID + "' order by Sort";
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
                        Location = new System.Drawing.Point(i * 78 + 5, 2),
                        Font = new System.Drawing.Font("宋体", 9F),
                        UseVisualStyleBackColor = true
                    };
                    BtnNumber.Click += new System.EventHandler(this.BtnNumber_Click);
                    this.GpbBtn.Controls.Add(BtnNumber);
                }
            }
            CboShopName.Text = "";
            CboType.Text = "";
            CmdCadeType.Text = "";
        }
        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "Excel": //数据参数新增
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        //建立Excel对象    
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        excel.Application.Workbooks.Add(true);
                        //生成字段名称    
                        for (int i = 0; i < WPHbROWDGV.ColumnCount; i++)
                        {
                            if (WPHbROWDGV.Columns[i].Visible == true)
                            {
                                excel.Cells[1, i + 1] = WPHbROWDGV.Columns[i].HeaderText;
                            }
                        }    //填充数据    
                        for (int i = 0; i < WPHbROWDGV.RowCount; i++)
                        {
                            for (int j = 0; j < WPHbROWDGV.ColumnCount; j++)
                            {
                                if (WPHbROWDGV.Columns[j].Visible == true)
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
                case "Operate":
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        Common.CommonForm comm = new Common.CommonForm("OrderCade like '" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["OrderCade"].Value.ToString().Trim() + "'", "CS_OutRuturnStorageOperate");
                        comm.ShowDialog();
                    }
                    break;
            }
        }
        

        private void WPHbROWDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewTextBoxColumn dgv_Text = new DataGridViewTextBoxColumn(); for (int i = 0; i < WPHbROWDGV.Rows.Count; i++)
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
                    if (dgrSingle.Cells["Remarks2"].Value.ToString()!="")
                    {
                        dgrSingle.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    if (dgrSingle.Cells["Remarks"].Value.ToString().IndexOf("(领用生成)") > -1)
                    {
                        dgrSingle.DefaultCellStyle.BackColor = Color.Goldenrod;
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
