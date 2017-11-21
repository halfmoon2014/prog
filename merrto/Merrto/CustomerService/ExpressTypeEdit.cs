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
    public partial class ExpressTypeEdit : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private int Brow;
        private string Dts;
        public ExpressTypeEdit(string dts,int brow)
        {
            Brow = brow;
            Dts = dts;
            InitializeComponent();
        }

        private void ExpressTypeEdit_Load(object sender, EventArgs e)
        {
            if (Brow != 3)
            {
                CboRemarks.Visible = false;
                ChkReturn.Visible = false;
                TxtSUMMoney.Visible = false;
                TxtExpressMoney.Visible = false;
                label6.Visible = false;
            }
            if (Brow == 3)
            {
                TxtOrderCade.Enabled = false;
                TxtExpressBarCode.Enabled = false;
                TXTReason.Enabled = false;
                TxtVipName.Enabled = false;
                CboExpressName.Enabled = false;
                CboShopName.Enabled = false;
            }
            string strsql = "select ID,CadeDate,ShopName,ExpressName,ExpressBarCode,OrderCade,VipName,Reason,UserName,ReturnType,sumMoney,expressMoney," +
               "case when type=1 then '待处理' when type=2 then '处理中' when type=3 then '已处理' else '' end type," +
               "Remarks,NuserName,NcadeDate from CS_ExpressType where ID='"+Dts+"'";

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                CboShopName.Text = ds.Tables[0].Rows[0]["ShopName"].ToString();
                CboRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                CboExpressName.Text = ds.Tables[0].Rows[0]["ExpressName"].ToString();
                TxtExpressBarCode.Text = ds.Tables[0].Rows[0]["ExpressBarCode"].ToString();
                TxtOrderCade.Text = ds.Tables[0].Rows[0]["OrderCade"].ToString();
                TXTReason.Text = ds.Tables[0].Rows[0]["Reason"].ToString();
                TxtVipName.Text = ds.Tables[0].Rows[0]["VipName"].ToString();
                TxtSUMMoney.Text = ds.Tables[0].Rows[0]["SUMMoney"].ToString();
                TxtExpressMoney.Text = ds.Tables[0].Rows[0]["ExpressMoney"].ToString();
                ChkReturn.Checked = ds.Tables[0].Rows[0]["ReturnType"].ToString()=="True"?true:false;
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

                    SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from CS_ExpressType where OrderCade='" + TxtOrderCade.Text.ToString() + "'", conn);
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
                        strsql += "insert into CS_ExpressType (CadeDate,ShopName,ExpressName,ExpressBarCode,OrderCade,VipName,Reason,UserName,Type,ReturnType)values('" +
                            DateTime.Now.ToString("yyyy-MM-dd") + "','" + CboShopName.Text.ToString() + "','"
                            + CboExpressName.Text.ToString() + "','"
                            + TxtExpressBarCode.Text.ToString() + "','"
                            + TxtOrderCade.Text.ToString() + "','"
                            + TxtVipName.Text.ToString() + "','"
                            + TXTReason.Text.ToString() + "','"
                            + frmlogin.userID + "','1','"
                            + ChkReturn.Checked + "')";
                    }
                    else
                    {
                        if (Brow == 2)
                        {
                            strsql = "update CS_ExpressType set ShopName='" + CboShopName.Text.ToString() + "',ExpressName='"
                            + CboExpressName.Text.ToString() + "',ExpressBarCode='"
                            + TxtExpressBarCode.Text.ToString() + "',VipName='"
                            + TxtVipName.Text.ToString() + "',Reason='"
                            + TXTReason.Text.ToString() + "',Type='1',OrderCade='"
                            + TxtOrderCade.Text.ToString() + "',ReturnType='"
                            + ChkReturn.Checked + "' where ID='"
                            + lblID.Text.ToString() + "'";
                        }
                        else if (Brow == 3)
                        {
                            strsql = "update CS_ExpressType set Remarks='" + CboRemarks.Text.ToString() + 
                                "',NcadeDate='" + DateTime.Now.ToString("yyyy-MM-dd") + "',type='3',ReturnType='"
                            + ChkReturn.Checked + 
                            "',NUserName='" +frmlogin.userID +
                            "',SumMoney='" + TxtSUMMoney.Text.ToString() +
                            "',ExpressMoney='" + this.TxtExpressMoney.Text.ToString() + 
                            "' where ID='"
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
                CboRemarks.Text = "";
                CboExpressName.Text = "";
                TxtExpressBarCode.Text = "";
                TxtOrderCade.Text = "";
                TXTReason.Text = "";
                TxtVipName.Text = "";
                ChkReturn.Checked = false;
                lblID.Text = ""; ;
            }
        }
    }
}
