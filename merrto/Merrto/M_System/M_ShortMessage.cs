using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.M_System
{
    public partial class M_ShortMessage : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.SendSMS SMS = new baseclass.SendSMS();
        baseclass.utils utils = new baseclass.utils();
        public M_ShortMessage()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
               
                string rolestr = "select * from M_ShortMessage ";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet roleds = new DataSet();
                conn.Open();
                sqlroleda.Fill(roleds);
                conn.Close();
                string str = "";
                if (roleds.Tables[0].Rows.Count > 0)
                {
                    str = "delete from M_ShortMessage ;";
                }
                str += "insert into M_ShortMessage(IPAdd,UserName,PWD,type) VALUES ('" + txtserverIP.Text.ToString() +
                            "','" + txtuser.Text.ToString() + "','" + utils.StringToMD5Hash(txtpwd.Text.ToString()) + "','" +this.chktype.Checked.ToString() +
                            "');";
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                conn.Close();
                sqlcom.Dispose();
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
       
        private void M_ShortMessage_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string rolestr = "select * from M_ShortMessage ";
            SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlroleda.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtserverIP.Text = ds.Tables[0].Rows[0]["IPADD"].ToString();
                txtpwd.Text = ds.Tables[0].Rows[0]["PWD"].ToString();
                txtuser.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                chktype.Checked =  Convert.ToBoolean(ds.Tables[0].Rows[0]["Type"].ToString());
            }
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            lblname.Text=SMS.GETGetNO(txtserverIP.Text.ToString() + "?ac=gc&uid=" + txtuser.Text.ToString() + "&pwd=" + txtpwd.Text.ToString());
             
            ////http://api.cnsms.cn/?ac=gc&uid=用户账号&pwd=MD5位32密码
        }
    }
}
