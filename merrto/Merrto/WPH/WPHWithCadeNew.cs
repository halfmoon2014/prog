using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.WPH
{
    public partial class WPHWithCadeNew : Form
    {
        private int RowsID;
        private int save_;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WPHWithCadeNew(int rows)
        {
            InitializeComponent();
            RowsID = rows;
        }

        private void WPHWithCadeNew_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (RowsID != 0)
            {
                this.Text = "唯品汇配比";
                string rolestr ="select S_WithCade.pid,S_WithCade.name,SSID,Sdid,m_SizeDetails.name as SDname,item_no,M_name,Matching from S_WithCade "+
                 "left join M_product on M_product.ID=S_WithCade.PID "+
                 "left join m_SizeDetails on S_WithCade.SDid=m_SizeDetails.id "+
                 "where pid='" + RowsID + "' union all "+
                "select M_product.id as pid,'',m_ProductSize.Sizeid as SSID,m_SizeDetails.id as Sdid,"+
                "m_SizeDetails.name as SDname,item_no,M_name,0 from M_product "+
			     "left join m_ProductSize  on m_ProductSize.PID=M_product.id "+
                "left join m_SizeDetails on m_ProductSize.Sizeid=m_SizeDetails.sizeid "+
                "where not exists(select * from S_WithCade where S_WithCade.pid=M_product.id and S_WithCade.sdid=m_SizeDetails.id) and pid='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                if (sizeds.Tables[0].Rows.Count > 0)
                {
                    this.TxtItem.Text = sizeds.Tables[0].Rows[0]["item_no"].ToString();
                    this.TxtName.Text = sizeds.Tables[0].Rows[0]["name"].ToString();
                    
                }
                WithCodeDGV.DataSource = sizeds.Tables[0];
                WithCodeDGV.Columns["SDName"].HeaderText = "尺码";
                WithCodeDGV.Columns["SDName"].ReadOnly = true;
                WithCodeDGV.Columns["Matching"].HeaderText = "配比";
                WithCodeDGV.Columns["pid"].Visible = false;
                WithCodeDGV.Columns["name"].Visible = false;
                WithCodeDGV.Columns["SSID"].Visible = false;
                WithCodeDGV.Columns["Sdid"].Visible = false;
                WithCodeDGV.Columns["item_no"].Visible = false;
                WithCodeDGV.Columns["M_name"].Visible = false;
                save_ = 1;
            }

        }
        

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string strsql = "";
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                for (int i = 0; i < WithCodeDGV.Rows.Count; i++)//得到总行数并在之内循环
                {

                    string str = "select * from S_WithCade where SDID='" +
                        WithCodeDGV.Rows[i].Cells["SDID"].Value.ToString() +
                        "' and pid='" + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "'";
                    SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                    DataSet ds = new DataSet();

                    conn.Open();
                    sqldaper.Fill(ds);
                    conn.Close();
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (Convert.ToInt32( WithCodeDGV.Rows[i].Cells["Matching"].Value.ToString()) >0)
                        {
                            strsql += "insert into S_WithCade(pid,sdid,ssid,Matching,Name) values ('"
                            + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "','"
                            + WithCodeDGV.Rows[i].Cells["sdid"].Value.ToString() + "','"
                            + WithCodeDGV.Rows[i].Cells["ssid"].Value.ToString() + "','"
                            + WithCodeDGV.Rows[i].Cells["Matching"].Value.ToString() + "','"
                            + TxtName.Text.ToString() + "') ";
                        }
                        else
                        {
                            strsql += "delete from S_WithCade where SDID='" + WithCodeDGV.Rows[i].Cells["SDID"].Value.ToString() +
                                   "' and pid='" + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "'";
                        }
                    }
                    conn.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strsql += "update S_WithCade set Matching='" +
                            WithCodeDGV.Rows[i].Cells["Matching"].Value.ToString() +
                            "',Name='" + TxtName.Text.ToString() + "' where SDID='" +
                    WithCodeDGV.Rows[i].Cells["SDID"].Value.ToString() +
                    "' and pid='" + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "'";
                    }
                    conn.Close();

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
