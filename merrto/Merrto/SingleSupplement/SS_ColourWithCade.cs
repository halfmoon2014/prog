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
    public partial class SS_ColourWithCade : Form
    {
        private int RowsID;
        private int save_;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public SS_ColourWithCade(int rows)
        {
            InitializeComponent();
            RowsID = rows;
        }

        private void SS_ColourWithCade_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            if (RowsID != 0)
            {
                this.Text = "库存监控颜色配比";
                string rolestr = "select SS_ColourWithCade.pid,item_no,colourID,Co_Code,S_color,Matching from SS_ColourWithCade  left join M_Product on M_Product.ID=SS_ColourWithCade.pid " +
               "left join M_ProductSub on M_ProductSub.ID=colourID where SS_ColourWithCade.pid='" + RowsID + "' union all "+
               "Select M_product.id as pid,item_no,M_ProductSub.id as colourID,Co_Code,S_color,0 from M_product left join M_ProductSub on M_ProductSub.PID=M_product.id " +
               "where  not exists(select * from SS_ColourWithCade where SS_ColourWithCade.pid=M_product.id and SS_ColourWithCade.colourID=M_ProductSub.ID) and pid='" + RowsID + "'";
               
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
                WithCodeDGV.Columns["Co_Code"].HeaderText = "色号";
                WithCodeDGV.Columns["Co_Code"].Width = 40;
                WithCodeDGV.Columns["Co_Code"].ReadOnly = true;
                WithCodeDGV.Columns["S_color"].HeaderText = "颜色";
                WithCodeDGV.Columns["S_color"].Width = 100;
                WithCodeDGV.Columns["S_color"].ReadOnly = true;
                WithCodeDGV.Columns["Matching"].HeaderText = "配比";
                WithCodeDGV.Columns["Matching"].Width = 40;
                WithCodeDGV.Columns["pid"].Visible = false;
                WithCodeDGV.Columns["colourID"].Visible = false;
                
                WithCodeDGV.Columns["item_no"].Visible = false;
               
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

                    string str = "select * from SS_ColourWithCade where ColourID='" +
                        WithCodeDGV.Rows[i].Cells["ColourID"].Value.ToString() +
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
                            strsql += "insert into SS_ColourWithCade(pid,ColourID,Matching) values ('"
                            + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "','"
                            + WithCodeDGV.Rows[i].Cells["ColourID"].Value.ToString() + "','"
                            + WithCodeDGV.Rows[i].Cells["Matching"].Value.ToString() + "') ";
                        }
                        else
                        {
                            strsql += "delete from SS_ColourWithCade where ColourID='" + WithCodeDGV.Rows[i].Cells["ColourID"].Value.ToString() +
                                   "' and pid='" + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "'";
                        }
                    }
                    conn.Close();


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        strsql += "update SS_ColourWithCade set Matching='" +WithCodeDGV.Rows[i].Cells["Matching"].Value.ToString() +
                             "' where ColourID='" + WithCodeDGV.Rows[i].Cells["ColourID"].Value.ToString() +
                             "' and pid='" + WithCodeDGV.Rows[i].Cells["PID"].Value.ToString() + "'";
                    }
                    conn.Close();

                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                BtnQuit_Click(sender, e);
                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
