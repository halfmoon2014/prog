using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.SingleSupplement
{
    public partial class SSizeSETNew : Form
    {
        private int RowsID;
        private int save_;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        
        public SSizeSETNew(int rows)
        {
            InitializeComponent();
            RowsID = rows;
            

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
                    str = "update SS_Size set Cade='" + this.txtCade.Text + "',name='" + this.TxtName.Text + "' where  ID='" + RowsID + "' ";
                }
                else
                {
                    str = "declare @I_ID int ; insert into SS_Size (Cade,name) values ('" + this.txtCade.Text + "','" + this.TxtName.Text + "') set @I_ID=@@IDENTITY;  ";
                }
                //int row = ;//得到总行数
                string rolestr = "select * from SS_SizeDetails where SSid='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet roleds = new DataSet();
                conn.Open();
                sqlroleda.Fill(roleds);
                if (roleds.Tables[0].Rows.Count <= 0)
                {
                    for (int i = 0; i < SizeDetailsDGV.Rows.Count; i++)//得到总行数并在之内循环
                    {
                        str += "insert into SS_SizeDetails(SDID,Proportion,SSid) VALUES ('" + SizeDetailsDGV.Rows[i].Cells["SDID"].Value.ToString() +
                            "','" + SizeDetailsDGV.Rows[i].Cells["Proportion"].Value.ToString() + "',";
                        if (save_ == 1)
                        {
                            str += "'" + RowsID + "');";
                        }
                        else
                        {
                            str += "@I_ID);";
                        }

                    }
                }
                else if (roleds.Tables[0].Rows.Count > 0)
                {
                    str += "delete from SS_SizeDetails where SSid='" + RowsID + "';";

                    for (int i = 0; i < SizeDetailsDGV.Rows.Count; i++)//得到总行数并在之内循环
                    {
                        str += "insert into SS_SizeDetails(SDID,Proportion,SSid) VALUES ('" + SizeDetailsDGV.Rows[i].Cells["SDID"].Value.ToString() +
                            "','" + SizeDetailsDGV.Rows[i].Cells["Proportion"].Value.ToString() + "',";
                        if (save_ == 1)
                        {
                            str += "'" + RowsID + "');";
                        }
                        else
                        {
                            str += "@I_ID);";
                        }
                    }
                }
                //conn.Close();
                //conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                this.txtCade.Text = "";
                this.TxtName.Text = "";
                conn.Close();
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

        private void SSizeSETNew_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            //string strsql = ;
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT NAME,Proportion,SSid,SDID FROM SS_SizeDetails left join M_SizeDetails on M_SizeDetails.id =SS_SizeDetails.SDID  where SSid='" + RowsID + "'", conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    SizeDetailsDGV.DataSource = ds.Tables[0];
                }
                SizeDetailsDGV.Columns["Proportion"].Width = 70;
                SizeDetailsDGV.Columns["Proportion"].HeaderText = "转换率";
                SizeDetailsDGV.Columns["NAME"].Width = 120;
                SizeDetailsDGV.Columns["NAME"].HeaderText = "名称";
                SizeDetailsDGV.Columns["SSID"].Width = 30;
                SizeDetailsDGV.Columns["SSID"].HeaderText = "ID";
                SizeDetailsDGV.Columns["SSID"].Visible = false;
                SizeDetailsDGV.Columns["SDID"].Visible = false;
                SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT ID,Cade,NAME FROM M_Size ", conn);
                DataSet ds1 = new DataSet();
                sqlDaper1.Fill(ds1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    CMBSize.DataSource = ds1.Tables[0];
                    CMBSize.ValueMember = "ID";
                    CMBSize.DisplayMember = "Name";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (RowsID != 0)
            {
                this.Text = "修改配码";
                //int row = ;//得到总行数
                //SqlConnection conn = sqlcon.getcon("");
                string rolestr = "select * from SS_Size where ID='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                this.txtCade.Text = sizeds.Tables[0].Rows[0]["Cade"].ToString();
                this.TxtName.Text = sizeds.Tables[0].Rows[0]["Name"].ToString();
                if (sizeds.Tables[0].Rows[0]["SizeID"].ToString() != "")
                {
                    this.CMBSize.SelectedValue = sizeds.Tables[0].Rows[0]["SizeID"].ToString();
                }
                save_ = 1;
            }
            else
            {
                this.Text = "新增配码";
                save_ = 0;
            }
        
        }

        private void CMBSize_SelectedValueChanged(object sender, EventArgs e)
        {
            string strsql = "";
            SqlConnection conn = sqlcon.getcon("");
            if (RowsID == 0)
            {
               strsql = "select Name,0.00 as Proportion,ID as SDID from m_SizeDetails where Sizeid='" + CMBSize.SelectedValue.ToString() + "'";
            }
            else
            {
                if (SizeDetailsDGV.Rows.Count== 0)
                {
                    strsql = "select Name,0.00 as Proportion,ID as SDID from m_SizeDetails where Sizeid='" + CMBSize.SelectedValue.ToString() + "'";
                }
                else
                {
                    strsql = "select Name,Proportion,SDID from SS_SizeDetails left join m_SizeDetails on m_SizeDetails.id=SS_SizeDetails.sDid where SSID='" + RowsID + "'";
                }
            }
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
                SizeDetailsDGV.Columns["Name"].Width = 60;
                SizeDetailsDGV.Columns["Name"].HeaderText = "名称";
                SizeDetailsDGV.Columns["Name"].ReadOnly = true;
                SizeDetailsDGV.Columns["Name"].Width = 120;
                SizeDetailsDGV.Columns["Proportion"].HeaderText = "转换率";
                SizeDetailsDGV.Columns["Proportion"].ReadOnly = false;
                 SizeDetailsDGV.Columns["SDID"].Visible = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
