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
    public partial class EditPassWord : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.utils Utils = new baseclass.utils();
        public EditPassWord()
        {
            InitializeComponent();
        }

        private void EditPassWord_Load(object sender, EventArgs e)
        {

        }
        private void SavePwd()
        {
            if (txtNewPassWord.Text.ToString() == txtfiredPassWord.Text.ToString())
            {
                //password salt
                string pwd;
                pwd = Utils.StringToMD5Hash(txtPassWord.Text.Trim()).ToUpper() + sqlcon.GenerateRandom(frmlogin.userID);
                pwd = Utils.StringToMD5Hash(pwd).ToUpper();
                int P_int_returnValue = sqlcon.ULogin(frmlogin.userID.Trim(), pwd);
                if (sqlcon.ULogin(frmlogin.userID.Trim(), pwd) == 100)
                {
                    SqlConnection conn = sqlcon.getcon("");
                    try
                    {
                        string salt = sqlcon.GenerateRandom(6);
                        pwd = Utils.StringToMD5Hash(txtfiredPassWord.Text.Trim()).ToUpper() + salt;
                        pwd = Utils.StringToMD5Hash(pwd).ToUpper();
                        string str = "update M_user set salt ='" + salt + "', password='" + pwd + "' where  userName='" + frmlogin.userID + "' ";

                        conn.Open();
                        SqlCommand sqlcom = new SqlCommand(str, conn);
                        sqlcom.ExecuteNonQuery();
                        sqlcom.Dispose();

                        conn.Close();
                        MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }

                else if (sqlcon.ULogin(frmlogin.userID.Trim(), pwd) == -100)
                {
                    MessageBox.Show("原密码不正确，请从新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPassWord.Text = "";
                }
            }
            else
            {
                MessageBox.Show("第一次的密码与第二次的不一致！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtfiredPassWord.Text = "";
                txtNewPassWord.Text = "";

            }

        }

        private void BtnCand_Click(object sender, EventArgs e)
        {
            txtfiredPassWord.Text = "";
            txtNewPassWord.Text = "";
            txtPassWord.Text = "";
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SavePwd();
        }
    }
}
