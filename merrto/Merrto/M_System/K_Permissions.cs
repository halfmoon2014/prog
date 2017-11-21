using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Merrto.M_System
{
    public partial class K_Permissions : Form
    {
        public K_Permissions()
        {
            InitializeComponent();
        }
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private void K_Permissions_Load(object sender, EventArgs e)
        {
            sqlcon.CboUser(this.cmbuserid);
            //sqlcon.cbouser(this.cmbuserid);
            sqlcon.tv_meuns(tv_data,"Permissions");
        }

        private void tv_data_MouseClick(object sender, MouseEventArgs e)
        {
            TreeNode node = tv_data.GetNodeAt(new Point(e.X, e.Y));
            if (node != null)
            {
                ChangeChild(node, node.Checked);//影响子节点
                ChangeParent(node);//影响父节点
            }
        }

        //递归子节点跟随其全选或全不选
        private void ChangeChild(TreeNode node, bool state)
        {
            node.Checked = state;
            foreach (TreeNode tn in node.Nodes)
                ChangeChild(tn, state);
        }

        //递归父节点跟随其全选或全不选
        private void ChangeParent(TreeNode node)
        {
            if (node.Parent != null)
            {
                //兄弟节点被选中的个数
                int brotherNodeCheckedCount = 0;
                //遍历该节点的兄弟节点
                foreach (TreeNode tn in node.Parent.Nodes)
                {
                    if (tn.Checked == true)
                        brotherNodeCheckedCount++;
                }
                //兄弟节点全没选，其父节点也不选
                if (brotherNodeCheckedCount == 0)
                {
                    node.Parent.Checked = false;
                    ChangeParent(node.Parent);
                }
                //兄弟节点只要有一个被选，其父节点也被选
                if (brotherNodeCheckedCount >= 1)
                {
                    node.Parent.Checked = true;
                    ChangeParent(node.Parent);
                }
            }
        }

       private string check(TreeNode tnp)
        {
            string input = "";
            if (tnp.Checked==true)
            {
                foreach (TreeNode tn in tnp.Nodes)
                {
                    if (tn.Checked == true)
                    {
                        check(tn);
                        input += "INSERT INTO M_softmenuuser(menuid,userid)select menuID,'" + cmbuserid.SelectedValue.ToString() + "' from m_softmenu where menuName = '" + tn.Text.ToString().Trim() + "'";
                        //sqlcon.menuadd(tn.Text.ToString(), this.cmbuserid.Text.ToString());
                    }
                }
            }
            return input;
        }

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    foreach (TreeNode node in tv_data.Nodes)
        //    {
        //        if (node.Checked == false)
        //            node.Checked = true;
        //    }
        //}

        private void btnsave_Click(object sender, EventArgs e)
        {
            string insert_ = "";
            sqlcon.menudel(this.cmbuserid.Text.ToString());
            foreach (TreeNode tn in this.tv_data.Nodes)
            {
                if (tn.Checked == true)
                {

                    insert_ += check(tn);
                    insert_ += "INSERT INTO M_softmenuuser(menuid,userid)select menuID,'" + cmbuserid.SelectedValue.ToString() + "' from m_softmenu where menuName = '" + tn.Text.ToString().Trim() + "'";
                }
                
            }
            if (sqlcon.menuadd(insert_) == 100)
            {
                MessageBox.Show("您已经添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("您添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnPerm_Click(object sender, EventArgs e)
        {
            DGVDate.DataSource = "";
            btnprm();
            sqlcon.perm(this.cmbuserid,tv_data);
            sqlcon.MBDate(this.DGVDate,cmbuserid.SelectedValue.ToString());
            DGVDate.Columns["MenuName"].HeaderText = "表单";
            DGVDate.Columns["Name"].HeaderText = "按键";
            DGVDate.Columns["OK"].HeaderText = "选择";
            DGVDate.Columns["MBID"].Visible = false;
            DGVDate.Columns["MenuID"].Visible = false;
            DGVDate.Columns["Name"].ReadOnly=true;
            DGVDate.Columns["MenuName"].ReadOnly = true;
        }

       
        public void btnprm()
        {
            foreach (TreeNode row in tv_data.Nodes)
            {
                row.Checked = false;
                checks(row);
            }
        }
        private void checks(TreeNode tnp)
        {
            foreach (TreeNode tn in tnp.Nodes)
           {
               tn.Checked = false;
                checks(tn);
            }
        }

        private void tv_data_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void cmbuserid_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnSAVE1_Click(object sender, EventArgs e)
        {

            //int row = RoleDG.Rows.Count;//得到总行数
            string strsql = "";
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                for (int i = 0; i < DGVDate.Rows.Count; i++)//得到总行数并在之内循环
                {
                    
                    string ok_ = DGVDate.Rows[i].Cells[0].Value.ToString();

                    string str = "select * from m_MenuButtonUser where MBID='" + DGVDate.Rows[i].Cells["MBID"].Value.ToString() + "' and UserID='" + cmbuserid.SelectedValue.ToString() + "'";
                    SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                    DataSet ds = new DataSet();

                    conn.Open();
                    sqldaper.Fill(ds);
                    conn.Close();
                    if (ok_ == "True")
                    {
                        if (ds.Tables[0].Rows.Count <= 0)
                        {
                            strsql += "insert into m_MenuButtonUser(MBID,UserID) values (" + DGVDate.Rows[i].Cells["MBID"].Value.ToString() + "," + cmbuserid.SelectedValue.ToString() + ") ";
                        }
                    }
                    if (ok_ == "False")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strsql += "delete from m_MenuButtonUser where MBID='" + DGVDate.Rows[i].Cells["MBID"].Value.ToString() + "' and UserID='" + cmbuserid.SelectedValue.ToString() + "' ";
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
