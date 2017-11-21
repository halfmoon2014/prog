using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.SingleSupplement
{
    public partial class SS_SizeWithCade : Form
    {
        private int RowsID;
        private int save_;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public SS_SizeWithCade(int rows)
        {
            InitializeComponent();
            RowsID = rows;
        }

        private void SS_SizeWithCade_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (RowsID != 0)
            {
                this.Text = "库存监控配比";
                string rolestr = "select SS_SizeWithCade.pid,SSID,Sdid,m_SizeDetails.name as SDname,item_no,M_name,Matching from SS_SizeWithCade " +
                 "left join M_product on M_product.ID=SS_SizeWithCade.PID " +
                 "left join m_SizeDetails on SS_SizeWithCade.SDid=m_SizeDetails.id " +
                 "where pid='" + RowsID + "' union all " +
                "select M_product.id as pid,m_ProductSize.Sizeid as SSID,m_SizeDetails.id as Sdid," +
                "m_SizeDetails.name as SDname,item_no,M_name,0 from M_product " +
                 "left join m_ProductSize  on m_ProductSize.PID=M_product.id " +
                "left join m_SizeDetails on m_ProductSize.Sizeid=m_SizeDetails.sizeid " +
                "where not exists(select * from SS_SizeWithCade where SS_SizeWithCade.pid=M_product.id and SS_SizeWithCade.sdid=m_SizeDetails.id) and pid='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                if (sizeds.Tables[0].Rows.Count > 0)
                {
                    this.TxtItem.Text = sizeds.Tables[0].Rows[0]["item_no"].ToString();
                    

                }
                WithCodeDGV.DataSource = sizeds.Tables[0];
                WithCodeDGV.Columns["SDName"].HeaderText = "尺码";
                WithCodeDGV.Columns["SDName"].ReadOnly = true;
                WithCodeDGV.Columns["Matching"].HeaderText = "配比";
                WithCodeDGV.Columns["pid"].Visible = false;
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

                    string str = "select * from SS_SizeWithCade where SDID='" +
                        WithCodeDGV.Rows[i].Cells["SDID"].Value.ToString() +
                        "' and pid='" + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "'";
                    SqlDataAdapter sqldaper = new SqlDataAdapter(str, conn);
                    DataSet ds = new DataSet();

                    conn.Open();
                    sqldaper.Fill(ds);
                    conn.Close();
                    if (ds.Tables[0].Rows.Count <= 0)
                    {
                        if (Convert.ToInt32(WithCodeDGV.Rows[i].Cells["Matching"].Value.ToString()) > 0)
                        {
                            strsql += "insert into SS_SizeWithCade(pid,sdid,ssid,Matching) values ('"
                            + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "','"
                            + WithCodeDGV.Rows[i].Cells["sdid"].Value.ToString() + "','"
                            + WithCodeDGV.Rows[i].Cells["ssid"].Value.ToString() + "','"
                            + WithCodeDGV.Rows[i].Cells["Matching"].Value.ToString() + "') ";
                        }
                        else
                        {
                            strsql += "delete from SS_SizeWithCade where SDID='" + WithCodeDGV.Rows[i].Cells["SDID"].Value.ToString() +
                                   "' and pid='" + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "'";
                        }
                    }
                    conn.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strsql += "update SS_SizeWithCade set Matching='" +
                            WithCodeDGV.Rows[i].Cells["Matching"].Value.ToString() +
                             "' where SDID='" +WithCodeDGV.Rows[i].Cells["SDID"].Value.ToString() +
                             "' and pid='" + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "'";
                    }
                    conn.Close();

                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                BtnQuit_Click(sender,e);
                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
