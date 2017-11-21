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
    public partial class QuestionOrderCadeEdit : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private string Dts = "";
        private int Brow = 0;
        public QuestionOrderCadeEdit(string dts,int brow)
        {
            Brow = brow;
            Dts = dts;
            InitializeComponent();
        }

        private void QuestionOrderCadeEdit_Load(object sender, EventArgs e)
        {
            if (Brow != 3)
            {
               
                CboExpressName.Visible = false;
                TxtExpressBarCode.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
            }
            if (Brow == 3)
            {
                TxtOrderCade.Enabled = false;
                //TxtExpressBarCode.Enabled = false;
                TXTReason.Enabled = false;
               
               // CboExpressName.Enabled = false;
                CboShopName.Enabled = false;
            }
            string strsql = "select ID,CadeDate,ShopName,OrderCade,VipID,Remarks,ExpressName,ExpressBarCode,userName,NuserName,NcadeDate," +
                "case when type=1 then '待处理' when type=2 then '处理中' when type=3 then '完结' else '关闭' end type " +
                " from CS_QuestionOrderCade where ID='" + Dts + "'";

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                CboShopName.Text = ds.Tables[0].Rows[0]["ShopName"].ToString();
                CboExpressName.Text = ds.Tables[0].Rows[0]["ExpressName"].ToString();
                TxtExpressBarCode.Text = ds.Tables[0].Rows[0]["ExpressBarCode"].ToString();
                TxtOrderCade.Text = ds.Tables[0].Rows[0]["OrderCade"].ToString();
                TXTReason.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
               
                TxtVipID.Text = ds.Tables[0].Rows[0]["VipID"].ToString();
               
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
                        strsql += "declare @I_ID int ; insert into CS_QuestionOrderCade (CadeDate,ShopName,OrderCade,VipID,Remarks,userName,type)values('" +
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','" + CboShopName.Text.ToString() + "','"
                            + TxtOrderCade.Text.ToString() + "','"
                            + TxtVipID.Text.ToString() + "','"
                            + TXTReason.Text.ToString() + "','"
                            + frmlogin.userID + "','1') set @I_ID=@@IDENTITY;insert into CS_QuestionOrderCadeOperate (Operate,Operatedatetime,RID,username)values('新增','" + DateTime.Now.ToString() + "', @I_ID,'" + frmlogin.userID + "');";
                    }
                    else
                    {
                        if (Brow == 2)
                        {
                            strsql = "insert into CS_QuestionOrderCadeOperate (Operate,Operatedatetime,RID,username)values('修改','" 
                                + DateTime.Now.ToString() + "','" + lblID.Text.ToString() + "','" + frmlogin.userID + 
                                "');update CS_QuestionOrderCade set ShopName='" + CboShopName.Text.ToString() + 
                             "',VipID='" + TxtVipID.Text.ToString() +
                            "',Remarks='" + TXTReason.Text.ToString() + 
                            "',Type='1',OrderCade='"+ TxtOrderCade.Text.ToString() + 
                            "' where ID='"+ lblID.Text.ToString() + "'";
                        }
                        else if (Brow == 3)
                        {
                            strsql = "insert into CS_QuestionOrderCadeOperate (Operate,Operatedatetime,RID,username)values('完结','" + DateTime.Now.ToString() + "','" + lblID.Text.ToString() + "','" + frmlogin.userID + "');update CS_QuestionOrderCade set ExpressName='" + CboExpressName.Text.ToString() +
                                "',NcadeDate='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "',type='3',NUserName='" + frmlogin.userID +
                            "',ExpressBarCode='" + TxtExpressBarCode.Text.ToString() +
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
                //CboRemarks.Text = "";
                CboExpressName.Text = "";
                TxtExpressBarCode.Text = "";
                TxtOrderCade.Text = "";
                TXTReason.Text = "";
                
                TxtVipID.Text = "";
                
                lblID.Text = ""; ;
            }
        }
    }
}
