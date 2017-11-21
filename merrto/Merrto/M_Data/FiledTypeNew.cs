using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.M_Data
{
    public partial class FiledTypeNew : Form
    {
        private int Rows;
        private int save_;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public FiledTypeNew(int rows)
        {
            InitializeComponent();
            Rows = rows;
            if (Rows != 0)
            {
                this.Text = "修改字段类别";
                //int row = ;//得到总行数
                SqlConnection conn = sqlcon.getcon("");
                string rolestr = "select Cade,[Name],FormName,ID from M_FiledType where ID='" + Rows + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                this.TxtCade.Text = sizeds.Tables[0].Rows[0]["Cade"].ToString();
                this.TxtName.Text = sizeds.Tables[0].Rows[0]["Name"].ToString();
                save_ = 1;
            }
            else
            {
                this.Text = "新增字段类别";
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
                    str = "update M_FiledType set cade='" + this.TxtCade.Text + "', Name='" + this.TxtName.Text + "',FormName='" + this.TXTFormName.Text + "' where  ID='" + Rows + "' ";
                }
                else
                {
                    str = " insert into M_FiledType (Cade,Name,FormName) values ('" + this.TxtCade.Text + "','" + this.TxtName.Text + "','" + this.TXTFormName.Text + "')  ";
                }
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                this.TxtName.Text = "";
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
