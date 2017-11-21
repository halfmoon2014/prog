using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.CustomerService
{
    public partial class RefundDisputesNew : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
         private int Brow;
        private string Dts;
        public RefundDisputesNew(string dts, int brow)
        {
            Dts = dts;
            Brow = brow;
            InitializeComponent();
        }

        private void RefundDisputesNew_Load(object sender, EventArgs e)
        {
            if (Brow == 3)
            {
                TxtOrderCade.Enabled = false;
                TxtBarCode.Enabled = false;
                CboListType.Enabled = false;
                //TxtSumMoney.Enabled = false;
                CboReason.Enabled = false;
                //TxtCustomerService.Enabled = false;
                TxtVIPID.Enabled = false;
                TxtRemarks.Enabled = false;
                CboShopName.Enabled = false;
                DtpCadeDate.Enabled = false;
            }
            if (Brow != 3)
            {
                CboProcessingResults.Visible = false;
                TxtCustomerService.Visible = false;
                TxtSumMoney.Visible = false;
                DtpBarCodeDate.Visible = false;
            }
            string strsql = "select ID,ShopName,CadeDate,ListType,ProcessingResults,Reason,BarcodeDate,VipID,OrderCade,BarCode,SumMoney,CustomerService,Remarks,UserName," +
                "case when type=1 then '待处理' when type=2 then '处理中' when type=3 then '完结' else '关闭' end type " +
                " from CS_RefundDisputes where ID='" + Dts + "'";

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                CboShopName.Text = ds.Tables[0].Rows[0]["ShopName"].ToString();
                DtpCadeDate.Value = Convert.ToDateTime((ds.Tables[0].Rows[0]["CadeDate"].ToString() == "" ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : ds.Tables[0].Rows[0]["CadeDate"].ToString()));
                DtpBarCodeDate.Value = Convert.ToDateTime((ds.Tables[0].Rows[0]["BarcodeDate"].ToString() == "" ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") :ds.Tables[0].Rows[0]["BarcodeDate"].ToString()));
                TxtBarCode.Text = ds.Tables[0].Rows[0]["BarCode"].ToString();
                TxtOrderCade.Text = ds.Tables[0].Rows[0]["OrderCade"].ToString();
                CboListType.Text = ds.Tables[0].Rows[0]["ListType"].ToString();
                TxtCustomerService.Text = ds.Tables[0].Rows[0]["CustomerService"].ToString();
                TxtSumMoney.Text = ds.Tables[0].Rows[0]["SumMoney"].ToString();
                TxtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                CboProcessingResults.Text = ds.Tables[0].Rows[0]["ProcessingResults"].ToString();
                CboReason.Text = ds.Tables[0].Rows[0]["Reason"].ToString();
                TxtVIPID.Text = ds.Tables[0].Rows[0]["VIPID"].ToString();
                lblID.Text = ds.Tables[0].Rows[0]["ID"].ToString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (TxtOrderCade.Text.ToString() != "")
            {
                if (Brow == 1)
                {

                    DataSet ds = new DataSet();

                    SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from CS_RefundDisputes where OrderCade='" + TxtOrderCade.Text.ToString() + "'", conn);
                    conn.Open();
                    sqlDaper.Fill(ds);
                    conn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(TxtOrderCade.Text.ToString() + "已存不不能保存");
                        return;
                    }
                }
                try
                {
                    string strsql = "";

                    if (Dts == "")
                    {
                        strsql += "declare @I_ID int ; insert into CS_RefundDisputes (ShopName,CadeDate,ListType,Reason,VipID,"+
                            "OrderCade,BarCode,Remarks,userName,Type)values('" + CboShopName.Text.ToString() + "','"
                            +DtpCadeDate.Value.ToString("yyyy-MM-dd HH:mm") + "','"
                            + this.CboListType.Text.ToString() + "','"
                            + this.CboReason.Text.ToString() + "','"
                            + this.TxtVIPID.Text.ToString() + "','"
                            + this.TxtOrderCade.Text.ToString() + "','"
                            + this.TxtBarCode.Text.ToString() + "','"
                            + this.TxtRemarks.Text.ToString() + "','"
                            + frmlogin.userID + "','1')set @I_ID=@@IDENTITY;insert into CS_RefundDisputesOperate (Operate,Operatedatetime,RID,username)values('新增','" + DateTime.Now.ToString() + "', @I_ID,'" + frmlogin.userID + "');";
                    }
                    else
                    {
                        if (Brow == 2)
                        {
                            strsql = "insert into CS_RefundDisputesOperate (Operate,Operatedatetime,RID,username)values('修改','"
                                + DateTime.Now.ToString() + "','" + lblID.Text.ToString() + "','" + frmlogin.userID +
                                "');update CS_RefundDisputes set ShopName='" + CboShopName.Text.ToString() + "',VipID='"
                            + TxtVIPID.Text.ToString() +
                            "',ListType='" + CboListType.Text.ToString() +
                             "',CadeDate='" + DtpCadeDate.Value.ToString("yyyy-MM-dd HH:mm") +
                            "',Reason='" + CboReason.Text.ToString() +
                            "',Barcode='"  + TxtBarCode.Text.ToString() +
                            "',Remarks='" + TxtRemarks.Text.ToString() +
                              "',Type='1',OrderCade='" + TxtOrderCade.Text.ToString() +
                             "' where ID='"
                            + lblID.Text.ToString() + "'";
                        }
                        else if (Brow == 3)
                        {
                            strsql = "insert into CS_RefundDisputesOperate (Operate,Operatedatetime,RID,username)values('审核','"
                                + DateTime.Now.ToString() + "','" + lblID.Text.ToString() + "','" + frmlogin.userID +
                                "');update CS_RefundDisputes set BarCodeDate='"
                                + DtpBarCodeDate.Value.ToString("yyyy-MM-dd HH:mm") + 
                                "',SumMoney='" + TxtSumMoney.Text +
                                "',ProcessingResults='" + CboProcessingResults.Text +
                                "',CustomerService='" + TxtCustomerService.Text + 
                                "',type='3' where ID='"
                            + lblID.Text.ToString() + "'";
                        }
                    }


                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(strsql, conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();

                    MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("没有你要保存的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (Brow != 1)
            {
                this.Close();
            }
            else
            {
                CboShopName.Text = "";
                TxtBarCode.Text = "";
                TxtOrderCade.Text = "";
                CboListType.Text = "";
                TxtCustomerService.Text = "";
                TxtSumMoney.Text = "";
                TxtRemarks.Text = "";
                CboProcessingResults.Text = "";
                CboReason.Text = "";
                TxtVIPID.Text = "";
                lblID.Text = "";
            }
        }
    }
}
