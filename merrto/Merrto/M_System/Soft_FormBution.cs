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
    public partial class Soft_FormBution : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public Soft_FormBution()
        {
            InitializeComponent();
        }
        string formid;
        private void Soft_FormBution_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string buttionstr = "select CAST ('False' as bit) as ok,cade,name,buttionid from web_SOFTButtion";
            string formbuttionstr = "select MenuName,MenuID from Web_SoftMenu WHERE MenuParentID!=0";
            SqlDataAdapter buttion = new SqlDataAdapter(buttionstr, conn);
            SqlDataAdapter formbuttion = new SqlDataAdapter(formbuttionstr, conn);
            DataSet buttionds = new DataSet();
            DataSet formbuttionds = new DataSet();
            try
            {
                conn.Open();
                buttion.Fill(buttionds);
                formbuttion.Fill(formbuttionds);
                conn.Close();
                if (buttionds.Tables.Count > 0)
                {
                    buttiondg.DataSource = buttionds.Tables[0];
                }
                buttiondg.Columns["ok"].HeaderText = "选择";
                buttiondg.Columns["ok"].Width = 40;
                buttiondg.Columns["cade"].HeaderText = "编号";
                buttiondg.Columns["cade"].ReadOnly = true;
                buttiondg.Columns["cade"].Width = 80;
                buttiondg.Columns["name"].HeaderText = "名称";
                buttiondg.Columns["name"].ReadOnly = true;
                //设置列的宽度
                buttiondg.Columns["name"].Width = 80;
                // buttondg.Columns["remark"].HeaderText = "备注";
                //设置列的宽度
                //buttondg.Columns["remark"].Width = 150;
                buttiondg.Columns["buttionid"].Visible = false;

                if (formbuttionds.Tables.Count > 0)
                {
                    formdg.DataSource = formbuttionds.Tables[0];
                }
                formdg.Columns["MenuName"].HeaderText = "表单名";
                formdg.Columns["MenuName"].Width = 80;

                //formdg.Columns["dboname"].HeaderText = "库存名";
                ////设置列的宽度
                //formdg.Columns["dboname"].Width = 80;
                // buttondg.Columns["remark"].HeaderText = "备注";
                //设置列的宽度
                //buttondg.Columns["remark"].Width = 150;
                formdg.Columns["MenuID"].Visible = false;

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            int row = buttiondg.Rows.Count;//得到总行数
            string strsql = "";
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                for (int i = 0; i < row; i++)//得到总行数并在之内循环
                {
                    //for (int j = 0; j < cell; j++)//得到总列数并在之内循环
                    //{
                    string buttonid_ = buttiondg.Rows[i].Cells[3].Value.ToString();
                    string ok_ = buttiondg.Rows[i].Cells[0].Value.ToString();
                    //}
                    string str = "select * from WEb_SOFTFORMBUTTON where MenuID='" + formid + "' and buttonid='" + buttonid_ + "'";
                    SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                    DataSet ds = new DataSet();

                    conn.Open();
                    sqldaper.Fill(ds);
                    if (ok_ == "True")
                    {
                        if (ds.Tables[0].Rows.Count <= 0)
                        {
                            strsql += "insert into WEb_SOFTFORMBUTTON(MenuID,buttonid) values (" + formid + "," + buttonid_ + ") ";
                        }
                        conn.Close();
                    }
                    if (ok_ == "False")
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            strsql += "delete from WEb_SOFTFORMBUTTON where MenuID='" + formid + "' and buttonid='" + buttonid_ + "' ";
                        }
                        conn.Close();
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

        private void formdg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            formid = formdg[1, formdg.CurrentCell.RowIndex].Value.ToString();
            string sqlstr = "select  CAST ('True' as bit) as ok,cade,name,buttionid from web_SOFTButtion where  exists (select * from WEb_SOFTFORMBUTTON where WEb_SOFTFORMBUTTON.buttonid=web_SOFTButtion.buttionid and WEb_SOFTFORMBUTTON.MenuID='" + formid + "')" +
                "union all select CAST ('False' as bit) as ok,cade,name,buttionid from web_SOFTButtion where not exists (select * from WEb_SOFTFORMBUTTON where WEb_SOFTFORMBUTTON.buttonid=web_SOFTButtion.buttionid and WEb_SOFTFORMBUTTON.MenuID='" + formid + "') order by buttionid";
            //save_ = 1;
            SqlDataAdapter sqldaper = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqldaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    buttiondg.DataSource = ds.Tables[0];
                }
                buttiondg.Columns["ok"].HeaderText = "选择";
                buttiondg.Columns["ok"].Width = 40;
                buttiondg.Columns["cade"].HeaderText = "编号";
                buttiondg.Columns["cade"].ReadOnly = true;
                buttiondg.Columns["cade"].Width = 80;
                buttiondg.Columns["name"].HeaderText = "名称";
                buttiondg.Columns["name"].ReadOnly = true;
                //设置列的宽度
                buttiondg.Columns["name"].Width = 80;
                // buttondg.Columns["remark"].HeaderText = "备注";
                //设置列的宽度
                //buttondg.Columns["remark"].Width = 150;
                buttiondg.Columns["buttionid"].Visible = false;


                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
