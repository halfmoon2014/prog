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
    public partial class Soft_Menu : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public Soft_Menu()
        {
            InitializeComponent();
        }
        private int roleid = 0;
        private void btnadd_Click(object sender, EventArgs e)
        {
            roleid = 0;
            Soft_RoleEdit roleadd = new Soft_RoleEdit(roleid);
            roleadd.Show();
            Soft_Menu_Load(sender, e);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            roleid =Convert.ToInt32(RoleDG[2, RoleDG.CurrentCell.RowIndex].Value.ToString());
            if (roleid != 0)
            {
                Soft_RoleEdit roleadd = new Soft_RoleEdit(roleid);
                roleadd.Show();
                Soft_Menu_Load(sender, e);
            }
            else
            {
                MessageBox.Show("没有角色不能修改！", "系统提示：", MessageBoxButtons.OK);
            }
        }

        private void Soft_Menu_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string str = "select cade,name,roleid from Web_SOFTROLE";
            SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();

                sqldaper.Fill(ds);
                conn.Close();
                if (ds.Tables.Count > 0)
                {
                    RoleDG.DataSource = ds.Tables[0];
                }
                RoleDG.Columns["cade"].HeaderText = "编号";
                RoleDG.Columns["cade"].Width = 40;
                RoleDG.Columns["name"].HeaderText = "角色名称";
                //设置列的宽度
                RoleDG.Columns["name"].Width = 80;
                RoleDG.Columns["roleid"].Visible = false;

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            roleid = 1;
            roleload(roleid);
        }
        private void roleload(int roleid)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                conn.Open();

                SqlDataAdapter sqlda = new SqlDataAdapter();

                DataSet ds = new DataSet();//执行存储过程 
                SqlCommand cmd = new SqlCommand("ProcMenu_Buttion ", conn);
                //说明命令要执行的是存储过程     
                cmd.CommandType = CommandType.StoredProcedure;
                //向存储过程中传递参数   
                cmd.Parameters.Add(new SqlParameter("@Role", SqlDbType.VarChar, 30));
                cmd.UpdatedRowSource = UpdateRowSource.None;
                cmd.Parameters["@Role"].Value = roleid;
                //执行命令 

                sqlda.SelectCommand = cmd;
                sqlda.SelectCommand.ExecuteNonQuery();
                sqlda.Fill(ds, "roletable");
                if (ds.Tables.Count > 0)
                {
                    MenuDG.DataSource = ds.Tables["roletable"];
                }
                MenuDG.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                MenuDG.Columns["menuID"].Width = 60;
                MenuDG.Columns["menuID"].HeaderText = "代码";
                //MenuDG.Columns["formid"].Visible = false;
                MenuDG.Columns["Menuname"].HeaderText = "菜单";
                MenuDG.Columns["Menuname"].Width = 90;
                for (int i = 3; i < ds.Tables["roletable"].Rows.Count; i++)
                {
                    MenuDG.Columns[i].Width = 60;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void BtnFormButton_Click(object sender, EventArgs e)
        {
            Soft_FormBution btn = new Soft_FormBution();
            btn.ShowDialog();
            Soft_Menu_Load(sender, e);
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            roleid = Convert.ToInt32(RoleDG[2, RoleDG.CurrentCell.RowIndex].Value.ToString());
            if (roleid != 0)
            {
                Soft_UserRole UR = new Soft_UserRole(roleid);
                UR.Show();
            }
            else
            {
                MessageBox.Show("没有角色不能修改！", "系统提示：", MessageBoxButtons.OK);
            }
            Soft_Menu_Load(sender, e);
        }

        private void MenuDG_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MenuDG[MenuDG.CurrentCell.ColumnIndex, MenuDG.CurrentCell.RowIndex].Value.ToString() == "√")
            {
                MenuDG[MenuDG.CurrentCell.ColumnIndex, MenuDG.CurrentCell.RowIndex].Value = "×";
            }
            else if (MenuDG[MenuDG.CurrentCell.ColumnIndex, MenuDG.CurrentCell.RowIndex].Value.ToString() == "×")
            {
                MenuDG[MenuDG.CurrentCell.ColumnIndex, MenuDG.CurrentCell.RowIndex].Value = "√";
            }
        }

        private void RoleDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            roleid = Convert.ToInt32(RoleDG[2, RoleDG.CurrentCell.RowIndex].Value.ToString());
            roleload(roleid);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (roleid != 0)
            {
                string strsql = "";
                SqlConnection conn = sqlcon.getcon("");
                try
                {
                    for (int i = 0; i < MenuDG.Rows.Count; i++)//得到总行数并在之内循环
                    {
                        string menuID = MenuDG.Rows[i].Cells[0].Value.ToString();
                        string ok_ = MenuDG.Rows[i].Cells["查看"].Value.ToString();
                        string str = "select * from Web_SOFTMenuRole where roleid='" + roleid + "' and menuID='" + menuID + "'";
                        SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                        DataSet ds = new DataSet();

                        conn.Open();
                        sqldaper.Fill(ds);
                        if (ok_ == "√")
                        {
                            if (ds.Tables[0].Rows.Count <= 0)
                            {
                                strsql += "insert into Web_SOFTMenuRole(roleid,menuID) values (" + roleid + "," + menuID + ");";
                            }
                        }
                        if (ok_ == "×")
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                strsql += "delete from Web_SOFTMenuRole where roleid='" + roleid + "' and menuID='" + menuID + "';";
                            }
                        }
                        for (int j = 2; j < MenuDG.Rows[1].Cells.Count; j++)//得到总列数并在之内循环
                        {
                            if (MenuDG.Columns[j].HeaderText != "查看")
                            {
                                string a = MenuDG.Columns[j].HeaderCell.Value.ToString();
                                string strSQL = "select * from WEB_SoftButtionRole where roleid='" + roleid + "' and menuID='" + menuID + "' AND EXISTS(SELECT * FROM WEB_SoftButtion WHERE WEB_SoftButtion.buttionid=WEB_SoftButtionRole.BUTTiONID AND WEB_SoftButtion.NAME='" + MenuDG.Columns[j].HeaderCell.Value.ToString() + "')";
                                SqlDataAdapter sqlda = new SqlDataAdapter(strSQL, conn);
                                DataSet SQLds = new DataSet();

                                sqlda.Fill(SQLds);
                                string value_ = MenuDG.Rows[i].Cells[j].Value.ToString();
                                if (value_ == "√")
                                {
                                    if (SQLds.Tables[0].Rows.Count <= 0)
                                    {
                                        strsql += "insert into WEB_SoftButtionRole(roleid,menuID,buttionid) SELECT '" + roleid + "','" + menuID + "',buttionid FROM WEB_SoftButtion WHERE NAME='" + MenuDG.Columns[j].HeaderCell.Value.ToString() + "';";
                                    }
                                }
                                else if (value_ == "×")
                                {
                                    if (SQLds.Tables[0].Rows.Count > 0)
                                    {
                                        strsql += "delete from WEB_SoftButtionRole where roleid='" + roleid + "' and menuID='" + menuID + "' AND EXISTS(SELECT * FROM WEB_SoftButtion WHERE WEB_SoftButtion.buttionid=WEB_SoftButtionRole.buttionid AND WEB_SoftButtion.NAME='" + MenuDG.Columns[j].HeaderCell.Value.ToString() + "');";
                                    }
                                }
                            }
                        }
                        conn.Close();
                    }
                    if (strsql != "")
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(strsql, conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("没有你要更新的数据！", "系统提示：", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("没有角色不能保存！", "系统提示：", MessageBoxButtons.OK);
            }
        }


    }
}
