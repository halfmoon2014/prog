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
    public partial class WphStroageAdd : Form
    {
        private int RowsID;
        private int save_;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphStroageAdd(int rows)
        {
            InitializeComponent();
            RowsID = rows;
            if (RowsID != 0)
            {
                this.Text = "修改仓库";
                //int row = ;//得到总行数
                SqlConnection conn = sqlcon.getcon("");
                string rolestr = "SELECT Cade,NAME,ID FROM Wph_Storage where ID='" + RowsID + "'";
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
                this.Text = "新增仓库";
                save_ = 0;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string str;
                if (save_ == 1)
                {
                    str = "update Wph_Storage set cade='" + this.TxtCade.Text + "', name='" + this.TxtName.Text + "' where  ID='" + RowsID + "' ";
                }
                else
                {
                    str = " insert into Wph_Storage (Cade,name) values ('" + this.TxtCade.Text + "','" + this.TxtName.Text + "')  ";
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
