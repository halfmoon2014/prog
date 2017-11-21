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
    public partial class OutReturnSoragebarcodeEdit : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private string EXBarCode;
        private int Brow;
        public OutReturnSoragebarcodeEdit(string ExBarCode,int brow)
        {
            Brow = brow;
           
            EXBarCode = ExBarCode;
            InitializeComponent();
        }

        private void OutReturnSoragebarcodeEdit_Load(object sender, EventArgs e)
        {
            string strsql = "select * from CS_OutRuturnNOinforMation where ExpressBarCode='" + EXBarCode + "'";
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            TxtExpressBarCode.Text = ds.Tables[0].Rows[0]["ExpressBarCode"].ToString();
            TxtExpressBarCode.Enabled = false;
            CboExpressName.Text = ds.Tables[0].Rows[0]["ExpressName"].ToString();
            CboExpressName.Enabled = false;
            TxtMobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
            TxtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
            CboShopName.Text = ds.Tables[0].Rows[0]["ShopName"].ToString();
            TxtVipName.Text = ds.Tables[0].Rows[0]["VipName"].ToString();
            CboNExpressName.Text = ds.Tables[0].Rows[0]["NExpressName"].ToString();
            TxtOrderCade.Text = ds.Tables[0].Rows[0]["OrderCade"].ToString();
            CboCadeType.Text = ds.Tables[0].Rows[0]["CadeType"].ToString();
            CboReason.Text = ds.Tables[0].Rows[0]["Reason"].ToString();
            if (Brow == 1)
            {
                BtnSave.Enabled = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtMobile.Text.ToString() == "" ||  CboShopName.Text.ToString() == "" || TxtVipName.Text.ToString() == "" || CboCadeType.Text.ToString() == "" || TxtOrderCade.Text.ToString() == "" )
                {
                    MessageBox.Show("信息输入不完整不能保存！！");
                    return;
                }
                SqlConnection conn = sqlcon.getcon("");
                string strwher = "select * from CS_OutRuturnStorage where orderCade='"+ TxtOrderCade.Text.ToString()+"' and (type>2)";
                string strsql = "insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('领用冲突','" +
                    DateTime.Now.ToString() + "','" + TxtOrderCade.Text.ToString() + "','" + frmlogin.userID +
                    "');insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('领用','" +
                    DateTime.Now.ToString() + "','" + TxtOrderCade.Text.ToString() + "','" + frmlogin.userID +
                    "');delete from CS_OutRuturnStorage where  orderCade='" + TxtOrderCade.Text.ToString() + 
                    "' and (type=1 or type=2) update CS_OutRuturnNOinforMation set Mobile='" + TxtMobile.Text.ToString() +
                     "',Remarks='" + TxtRemarks.Text.ToString()+
                     "',ShopName='" + CboShopName.Text.ToString()+
                     "',VipName='" + TxtVipName.Text.ToString()+
                     "',CadeType='" + CboCadeType.Text.ToString() +
                     "',Reason='" + CboReason.Text.ToString() +
                     "',NExpressName='" + CboNExpressName.Text.ToString() +
                     "',OrderCade='" + TxtOrderCade.Text.ToString() +
                     "',Type='2' where ExpressBarCode='" + TxtExpressBarCode.Text.ToString()+ "'"
                    ;

                SqlDataAdapter sda = new SqlDataAdapter(strwher, conn);
                DataSet ds = new DataSet();
                conn.Open();
                sda.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(TxtOrderCade.Text.ToString()+"已领用过不能重复领用！！");
                    return;
                }
                else
                {
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(strsql, conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();

                    MessageBox.Show("数据领用成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch            
            {
                MessageBox.Show("数据领用失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
            
        }
    }
}
