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
    
    public partial class WphProportionEdit : Form
    {
        private int RowsID;
        private int save_;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphProportionEdit(int rows)
        {
            InitializeComponent();
            RowsID = rows;
        }

        private void WphProportionEdit_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            //string strsql = ;
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select ID,cast(ITEM_NO as varchar(20))+'|'+M_NAME AS Name from M_product", conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                this.CmdCategory.DataSource = ds.Tables[0];
                this.CmdCategory.ValueMember = "ID";
                this.CmdCategory.DisplayMember = "Name";
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //string strsql1 = "select Name,ID from WPh_Storage";
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("select Name,ID from WPh_Storage", conn);
            DataSet ds1 = new DataSet();
            try
            {
                conn.Open();
                sqlDaper1.Fill(ds1);
                this.CmbStorage.DataSource = ds1.Tables[0];
                this.CmbStorage.ValueMember = "ID";
                this.CmbStorage.DisplayMember = "Name";
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (RowsID != 0)
            {
                this.Text = "比率修改";
                //int row = ;//得到总行数
                //SqlConnection conn = sqlcon.getcon("");
                string rolestr = "select  wph_proportion.id,wph_proportion.Pid,StorageID,cast(ITEM_NO as varchar(20))+'|'+M_NAME AS PName,Wph_Storage.name as Sname,Proportion from wph_proportion" +
                             " left join M_product on M_product.id=wph_proportion.pid" +
                             " left join Wph_Storage on Wph_Storage.id=StorageID where wph_proportion.id='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                if (sizeds.Tables[0].Rows[0]["StorageID"].ToString() != "")
                {
                    this.CmbStorage.SelectedValue = sizeds.Tables[0].Rows[0]["StorageID"].ToString();
                }
                this.CmbStorage.Text = sizeds.Tables[0].Rows[0]["Sname"].ToString();
                if (sizeds.Tables[0].Rows[0]["Pid"].ToString() != "")
                {
                    this.CmdCategory.SelectedValue = sizeds.Tables[0].Rows[0]["Pid"].ToString();
                }
                this.CmdCategory.Text = sizeds.Tables[0].Rows[0]["PName"].ToString();
                this.TxtProportion.Text = sizeds.Tables[0].Rows[0]["Proportion"].ToString();
                save_ = 1;
            }
            else
            {
                this.Text = "比率新增";
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
                {  //CmdCategory.SelectedValue.ToString()
                    str = "update wph_proportion set PID='" + CmdCategory.SelectedValue.ToString() + "',StorageID='" + CmbStorage.SelectedValue.ToString() +
                        "',Proportion='"+TxtProportion.Text.ToString()+"' where  ID='" + RowsID + "' ";
                }
                else
                {
                    str = " insert into wph_proportion (PID,StorageID,Proportion) values ('" + CmdCategory.SelectedValue.ToString() + "','" + CmbStorage.SelectedValue.ToString() +
                        "','" + TxtProportion.Text.ToString() + "')  ";
                }
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                this.TxtProportion.Text = "";
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
    }
}
