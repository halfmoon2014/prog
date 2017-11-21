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
    public partial class Soft_UserRole : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private int RID=0;
        public Soft_UserRole(int Rid)
        {
            RID = Rid;
            InitializeComponent();
        }

        private void Soft_UserRole_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string Usstr = "select CAST ('True' as bit)ok, username,id from M_user where exists(select * from Web_SOFTUserRole where Web_SOFTUserRole.userid=M_user.id and Web_SOFTUserRole.roleid='" + RID + "')" +
                "union all select CAST ('False' as bit)ok, username,id from M_user where not exists(select * from Web_SOFTUserRole where Web_SOFTUserRole.userid=M_user.id and Web_SOFTUserRole.roleid='" + RID + "')";
            SqlDataAdapter unda = new SqlDataAdapter(Usstr, conn);
            DataSet unds = new DataSet();
            DataSet formbuttionds = new DataSet();

            conn.Open();
            unda.Fill(unds);
            conn.Close();
            if (unds.Tables[0].Rows.Count > 0)
            {
                RoleDG.DataSource = unds.Tables[0];
                RoleDG.Columns["OK"].HeaderText = "选择";
                RoleDG.Columns["OK"].Width = 50;
                RoleDG.Columns["username"].HeaderText = "名称";
                RoleDG.Columns["username"].ReadOnly = true;
                RoleDG.Columns["ID"].Visible = false;
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            //int row = RoleDG.Rows.Count;//得到总行数
            string strsql = "";
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                for (int i = 0; i < RoleDG.Rows.Count; i++)//得到总行数并在之内循环
                {
                    //for (int j = 0; j < cell; j++)//得到总列数并在之内循环
                    //{
                    string UserID_ = RoleDG.Rows[i].Cells[2].Value.ToString();
                    string ok_ = RoleDG.Rows[i].Cells[0].Value.ToString();
                    //}
                    string str = "select * from Web_SOFTUserRole where Roleid='" + RID + "' and UserID='" + UserID_ + "'";
                    SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                    DataSet ds = new DataSet();

                    conn.Open();
                    sqldaper.Fill(ds);
                    conn.Close();
                    if (ok_ == "True")
                    {
                        if (ds.Tables[0].Rows.Count <= 0)
                        {
                            strsql += "insert into Web_SOFTUserRole(Roleid,UserID) values (" + RID + "," + UserID_ + ") ";
                        }
                    }
                    if (ok_ == "False")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strsql += "delete from Web_SOFTUserRole where Roleid='" + RID + "' and UserID='" + UserID_ + "' ";
                        }
                    }
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
