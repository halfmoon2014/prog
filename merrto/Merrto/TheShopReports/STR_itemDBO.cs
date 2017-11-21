using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.TheShopReports
{
    public partial class STR_itemDBO : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.DATECalse datec = new baseclass.DATECalse();
        private int Rows;
        private int save_;
        public STR_itemDBO(int rows)
        {
            InitializeComponent();
            Rows = rows;

        }

        private void STR_itemDBO_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select Cade,Name,FormName,ID from M_FiledType where FormName='其它项目输入'", conn);
            conn.Open();
            sqlDaper.Fill(ds, "DS");
            conn.Close();
            CboItem.DataSource = ds.Tables["DS"];
            CboItem.ValueMember = "ID";
            CboItem.DisplayMember = "Name";
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT ID,Cade,ShopNAME FROM STR_Shop ", conn);
            
            sqlDaper1.Fill(ds,"Shop");
            
            if (ds.Tables["Shop"].Rows.Count > 0)
            {
                CmdShop.DataSource = ds.Tables["Shop"];
                CmdShop.ValueMember = "ID";
                CmdShop.DisplayMember = "ShopNAME";
            }
            if (Rows != 0)
            {
                this.Text = "修改收款项目";
                string rolestr = "select ID,Cade,CadeDATE,itemID,SumMoney,Remarks,UserName,ShopID from STR_itemDBO where ID='" + Rows + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                conn.Open();
                sqlroleda.Fill(ds,"ItemDS");
                conn.Close();
                TxtSumMoney.Text = ds.Tables["ItemDS"].Rows[0]["SumMoney"].ToString();
                CboItem.SelectedValue = ds.Tables["ItemDS"].Rows[0]["itemID"].ToString();
                DTPdatedt.Text = ds.Tables["ItemDS"].Rows[0]["CadeDATE"].ToString();
                TXtRemarks.Text = ds.Tables["ItemDS"].Rows[0]["Remarks"].ToString();
                CmdShop.SelectedValue = ds.Tables["ItemDS"].Rows[0]["ShopID"].ToString();
                save_ = 1;
            }
            else
            {
                this.Text = "新增收款项目";
                save_ = 0;
            }
            
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string str;
                if (save_ == 1)
                {
                    str = "update STR_itemDBO set CadeDATE='" + DTPdatedt.Value.ToString("yyyy-MM-dd") +
                        "', SumMoney='" + this.TxtSumMoney.Text + 
                        "',itemID='" + this.CboItem.SelectedValue.ToString() +
                        "',Remarks='" + this.TXtRemarks.Text.ToString() +
                        "',ShopID='" + this.CmdShop.SelectedValue.ToString() +
                        "',username='" + frmlogin.userID + 
                        "' where  ID='" + Rows + "' ";
                }
                else
                {
                    str = " insert into STR_itemDBO (Cade,CadeDATE,SumMoney,itemID,ShopID,username,Remarks) values ('"
                        + "IT" + DTPdatedt.Value.ToString("yyyyMMdd") + 
                        datec.uppacking("STR_itemDBO", DTPdatedt.Value.ToString("yyyyMMdd")) + "','"
                        + this.DTPdatedt.Value.ToString("yyyy-MM-dd") + "','"
                        + this.TxtSumMoney.Text + "','"
                        + this.CboItem.SelectedValue.ToString() + "','"
                        + this.CmdShop.SelectedValue.ToString() + "','"
                        + frmlogin.userID + "','"
                        + this.TXtRemarks.Text.ToString() + "')  ";
                }
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                this.TxtSumMoney.Text = "";
                this.TXtRemarks.Text = "";
                conn.Close();
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (save_ == 1)
                {
                    BtnClose_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
