using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.CustomerService
{
    public partial class ReturnMoneyEdit : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private int Brow;
        private string Dts;
        public ReturnMoneyEdit(string dts,int brow)
        {
            Brow = brow;
            Dts = dts;
            InitializeComponent();
        }

        private void ReturnMoneyEdit_Load(object sender, EventArgs e)
        {
            if (Brow == 3)
            {
                TxtOrderCade.Enabled = false;
                TxtBarCode.Enabled = false;
                TXTZFBName.Enabled = false;
                
                TxtVIPID.Enabled = false;
                CboReturnReason.Enabled = false;
                TxtZFBWork.ReadOnly = true;
                CboShopName.Enabled = false;
                TxtReturnMoney.ReadOnly = true;
            }
            string strsql = "select ID,CadeDate,ShopName,OrderCade,VipID,ZFBName,ZfbWork,Barcode,ReturnReason,"+
                "ReturnMoney,userName,NuserName,NcadeDate," +
                "case when type=1 then '待处理' when type=2 then '已审核' else '关闭' end type " +
                " from CS_ReturnMoney where ID='" + Dts + "'";

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                CboShopName.Text = ds.Tables[0].Rows[0]["ShopName"].ToString();
                TxtBarCode.Text = ds.Tables[0].Rows[0]["BarCode"].ToString();
                TxtOrderCade.Text = ds.Tables[0].Rows[0]["OrderCade"].ToString();
                TXTZFBName.Text = ds.Tables[0].Rows[0]["ZFBName"].ToString();
                TxtZFBWork.Text = ds.Tables[0].Rows[0]["ZfbWork"].ToString();
                TxtVIPID.Text = ds.Tables[0].Rows[0]["VIPID"].ToString();
                TxtReturnMoney.Text = ds.Tables[0].Rows[0]["ReturnMoney"].ToString();
                CboReturnReason.Text = ds.Tables[0].Rows[0]["ReturnReason"].ToString();
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

                    SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from CS_ReturnMoney where OrderCade='" + TxtOrderCade.Text.ToString().Trim() + "'", conn);
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
                        strsql += "declare @I_ID int ; insert into CS_ReturnMoney (CadeDate,ShopName,OrderCade,VipID,ZFBName,ZfbWork,Barcode,ReturnReason," +
                "ReturnMoney,userName,Type)values('" +
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','" + CboShopName.Text.ToString().Trim() + "','"
                            + this.TxtOrderCade.Text.ToString().Trim() + "','"
                            + this.TxtVIPID.Text.ToString().Trim() + "','"
                            + this.TXTZFBName.Text.ToString().Trim() + "','"
                            + this.TxtZFBWork.Text.ToString().Trim() + "','"
                            + this.TxtBarCode.Text.ToString().Trim() + "','"
                            + this.CboReturnReason.Text.ToString().Trim() + "','"
                            + this.TxtReturnMoney.Text.ToString().Trim() + "','"
                            + frmlogin.userID + "','1')set @I_ID=@@IDENTITY;insert into CS_ReturnMoneyOperate (Operate,Operatedatetime,RID,username)values('新增','" + DateTime.Now.ToString() + "', @I_ID,'" + frmlogin.userID + "');";
                    }
                    else
                    {
                        if (Brow == 2)
                        {
                            strsql = "insert into CS_ReturnMoneyOperate (Operate,Operatedatetime,RID,username)values('修改','"
                                + DateTime.Now.ToString().Trim() + "','" + lblID.Text.ToString().Trim() + "','" + frmlogin.userID +
                                "');update CS_ReturnMoney set ShopName='" + CboShopName.Text.ToString().Trim() + "',VipID='"
                            + TxtVIPID.Text.ToString().Trim() +
                            "',ZFBName='" + TXTZFBName.Text.ToString().Trim() + 
                            "',ZfbWork='"
                            + TxtZFBWork.Text.ToString().Trim() + 
                            "',Barcode='"
                            + TxtBarCode.Text.ToString().Trim() +
                            "',ReturnReason='" + CboReturnReason.Text.ToString().Trim() +
                              "',ReturnMoney='" + TxtReturnMoney.Text.ToString().Trim() +
                              "',Type='1',OrderCade='" + TxtOrderCade.Text.ToString().Trim() + 
                             "' where ID='"
                            + lblID.Text.ToString() + "'";
                        }
                        else if (Brow == 3)
                        {
                            strsql = "insert into CS_ReturnMoneyOperate (Operate,Operatedatetime,RID,username)values('审核','"
                                + DateTime.Now.ToString() + "','" + lblID.Text.ToString() + "','" + frmlogin.userID +
                                "');update CS_ReturnMoney set NcadeDate='"
                                + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "',type='2',NUserName='" +
                                frmlogin.userID + "' where ID='"
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
                TxtOrderCade.Text = "";
                TxtBarCode.Text = "";
                TXTZFBName.Text = "";
               
                TxtVIPID.Text = "";
                CboReturnReason.Text = "";
                TxtZFBWork.Text = "";
                CboShopName.Text = "";
                TxtReturnMoney.Text = "";

                lblID.Text = ""; ;
            }
        
        }

    }
}
