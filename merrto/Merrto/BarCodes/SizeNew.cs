using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto
{
    public partial class SizeNew : Form
    {
        private int RowsID;
        private int save_;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        
        public SizeNew(int rows)
        {
            InitializeComponent();
            RowsID = rows;
            if (RowsID != 0)
            {
                this.Text = "修改尺码";
                //int row = ;//得到总行数
                SqlConnection conn = sqlcon.getcon("");
                string rolestr = "select * from m_Size where ID='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                this.txtCade.Text = sizeds.Tables[0].Rows[0]["Cade"].ToString();
                this.TxtName.Text = sizeds.Tables[0].Rows[0]["Name"].ToString();
                save_ = 1;
            }
            else
            {
                this.Text ="新增尺码";
                save_ = 0;
            }
        }
        
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string str;
                if (save_ == 1)
                {
                    str = "update m_Size set Cade='" + this.txtCade.Text + "',name='" + this.TxtName.Text + "' where  ID='" + RowsID + "' ";
                }
                else
                {
                    str = "declare @I_ID int ; insert into m_Size (Cade,name) values ('" + this.txtCade.Text + "','" + this.TxtName.Text + "') set @I_ID=@@IDENTITY;  ";
                }
                //int row = ;//得到总行数
                string rolestr = "select * from m_SizeDetails where sIZEID='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet roleds = new DataSet();
                conn.Open();
                sqlroleda.Fill(roleds);
                conn.Close();
                if (roleds.Tables[0].Rows.Count <= 0)
                {
                    for (int i = 0; i < SizeDetailsDGV.Rows.Count-1; i++)//得到总行数并在之内循环
                    {
                        str += "insert into m_SizeDetails(CADE,NAME,USA,UK,sort,CM,SIZEID) VALUES ('" + SizeDetailsDGV.Rows[i].Cells["Cade"].Value.ToString() +
                                "','" + SizeDetailsDGV.Rows[i].Cells["NAME"].Value.ToString() + "','" + SizeDetailsDGV.Rows[i].Cells["USA"].Value.ToString() +
                                "','" + SizeDetailsDGV.Rows[i].Cells["UK"].Value.ToString() + "','" + SizeDetailsDGV.Rows[i].Cells["sort"].Value.ToString() + 
                                "','" + SizeDetailsDGV.Rows[i].Cells["CM"].Value.ToString() + "',";
                        if (save_ == 1)
                        {
                            str +="'"+ RowsID + "');";
                        }
                        else
                        { 
                            str +="@I_ID);";
                        }

                    }
                }
                else if (roleds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < SizeDetailsDGV.Rows.Count-1; i++)//得到总行数并在之内循环
                    {
                       // string rolestr = ;
                        SqlDataAdapter SDID = new SqlDataAdapter("select * from m_SizeDetails where ID='" + SizeDetailsDGV.Rows[i].Cells["ID"].Value.ToString() + "'", conn);
                        DataSet sizeds = new DataSet();
                        conn.Open();
                        SDID.Fill(sizeds);
                        conn.Close();
                        if (sizeds.Tables[0].Rows.Count > 0)
                        {
                            str += "update m_SizeDetails set CADE='" + SizeDetailsDGV.Rows[i].Cells["Cade"].Value.ToString() +
                                "',NAME='" + SizeDetailsDGV.Rows[i].Cells["NAME"].Value.ToString() +
                                "',USA='" + SizeDetailsDGV.Rows[i].Cells["USA"].Value.ToString() +
                                "',UK='" + SizeDetailsDGV.Rows[i].Cells["UK"].Value.ToString() +
                                "',CM='" + SizeDetailsDGV.Rows[i].Cells["CM"].Value.ToString() +
                                "',sort='" + SizeDetailsDGV.Rows[i].Cells["sort"].Value.ToString() +
                                "' where id='" + SizeDetailsDGV.Rows[i].Cells["ID"].Value.ToString() + "';";
                        }
                        else
                        {
                            str += "insert into m_SizeDetails(CADE,NAME,USA,UK,sort,CM,SIZEID) VALUES ('" + SizeDetailsDGV.Rows[i].Cells["Cade"].Value.ToString() +
                                    "','" + SizeDetailsDGV.Rows[i].Cells["NAME"].Value.ToString() + "','" + SizeDetailsDGV.Rows[i].Cells["USA"].Value.ToString() +
                                    "','" + SizeDetailsDGV.Rows[i].Cells["UK"].Value.ToString() + "','" + SizeDetailsDGV.Rows[i].Cells["sort"].Value.ToString() +
                                    "','" + SizeDetailsDGV.Rows[i].Cells["CM"].Value.ToString() + "','" + RowsID + "');";
                            
                        }
                    }
                }
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                conn.Close();
                sqlcom.Dispose();
                this.txtCade.Text = "";
                this.TxtName.Text = "";
                
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (save_ == 1)
                {
                    btnclose_Click(sender, e);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void SizeNew_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT CADE,NAME,USA,UK,CM,ID,sort FROM m_SizeDetails where sizeid='" + RowsID + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    SizeDetailsDGV.DataSource = ds.Tables[0];
                }
                SizeDetailsDGV.Columns["CADE"].Width = 60;
                SizeDetailsDGV.Columns["CADE"].HeaderText = "代码";
                SizeDetailsDGV.Columns["NAME"].Width = 70;
                SizeDetailsDGV.Columns["NAME"].HeaderText = "名称";
                SizeDetailsDGV.Columns["USA"].Width = 40;
                SizeDetailsDGV.Columns["UK"].Width = 40;
                SizeDetailsDGV.Columns["CM"].Width = 40;
                SizeDetailsDGV.Columns["ID"].Width = 30;
                SizeDetailsDGV.Columns["ID"].HeaderText = "ID";
                SizeDetailsDGV.Columns["ID"].Visible = false;
                SizeDetailsDGV.Columns["sort"].HeaderText = "顺序";
                SizeDetailsDGV.Columns["sort"].Width = 40;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
