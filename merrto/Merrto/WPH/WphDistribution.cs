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
    public partial class WphDistribution : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphDistribution()
        {
            InitializeComponent();
        }

        private void WphDistribution_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            conn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select distinct Special from Wph_Report", conn);
            sqlda.Fill(ds,"special");
            this.CmbSpecial.DataSource = ds.Tables["special"];
            this.CmbSpecial.DisplayMember = "Special";
            SqlDataAdapter sqlda1 = new SqlDataAdapter("select * from Wph_Storage", conn);
            sqlda1.Fill(ds, "Storage");
            this.Cmbstorange.DataSource=ds.Tables["Storage"];
            this.Cmbstorange.ValueMember = "ID";
            this.Cmbstorange.DisplayMember = "Name";
            conn.Close();

        }

        private void BtnBrow_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            conn.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select Wph_Report.id as rID,Wph_Report.Cade,Wph_Report.Special,Wph_Report.Pid," +
                    "item_NO,M_name,Wph_Report.ColourID,s_color,Wph_Report.SizeID,m_SizeDetails.name as SDname,Wph_Report.[Qty] as BBNO,"+
                    "Wph_Distribution.[Qty] as PHno,Wph_Report.[Qty]-isnull(Wph_Distribution.[Qty],'0') as [NO],Wph_Report.StorageID from Wph_Report "+
                    "left join Wph_Distribution on Wph_Distribution.rid=Wph_Report.id "+
                    "and Wph_Distribution.ColourID=Wph_Report.ColourID and Wph_Distribution.SizeID=Wph_Report.SizeID  and Wph_Distribution.Special=Wph_Report.Special and Wph_Distribution.PID=Wph_Report.PID " +
                    "left join M_productsub  on M_productsub.id=Wph_Report.ColourID "+
                    "left join m_SizeDetails on m_SizeDetails.id=Wph_Report.SizeID "+
                    "left join M_product on M_product.id=Wph_Report.PID "+
                    "where Wph_Report.Special='"+ this.CmbSpecial.Text.ToString() +
                    "' and Wph_Report.StorageID='" + this.Cmbstorange.SelectedValue.ToString() + "'", conn);
            sqlda.Fill(ds);
            DistriButionDGV.DataSource=ds.Tables[0];
            conn.Close();
            DistriButionDGV.Columns["Special"].HeaderText = "专场";
            DistriButionDGV.Columns["Special"].ReadOnly = true;
            DistriButionDGV.Columns["Special"].Visible = false;
            DistriButionDGV.Columns["s_color"].HeaderText = "颜色";
            DistriButionDGV.Columns["s_color"].Width = 60;
            DistriButionDGV.Columns["s_color"].ReadOnly = true;
            DistriButionDGV.Columns["SDname"].HeaderText = "尺码";
            DistriButionDGV.Columns["SDname"].Width = 60;
            DistriButionDGV.Columns["SDname"].ReadOnly = true;
            DistriButionDGV.Columns["BBNO"].HeaderText = "唯品会报表数";
            DistriButionDGV.Columns["BBNO"].ReadOnly = true;
            DistriButionDGV.Columns["PHno"].HeaderText = "配货数";
            DistriButionDGV.Columns["PHno"].ReadOnly = true;
            DistriButionDGV.Columns["PHno"].Width = 70;
            DistriButionDGV.Columns["Cade"].HeaderText = "报表单号";
            DistriButionDGV.Columns["Cade"].Width = 100;
            DistriButionDGV.Columns["Cade"].ReadOnly = true;
            DistriButionDGV.Columns["NO"].HeaderText = "本单数";
            DistriButionDGV.Columns["NO"].Width = 70;
            DistriButionDGV.Columns["item_NO"].HeaderText = "款号";
            DistriButionDGV.Columns["item_NO"].Width = 70;
            DistriButionDGV.Columns["item_NO"].ReadOnly = true;
            DistriButionDGV.Columns["M_name"].HeaderText = "品名";
            DistriButionDGV.Columns["M_name"].Width = 60;
            DistriButionDGV.Columns["M_name"].ReadOnly = true;
            DistriButionDGV.Columns["Rid"].Visible = false;
            DistriButionDGV.Columns["Pid"].Visible = false;
            DistriButionDGV.Columns["ColourID"].Visible = false;
            DistriButionDGV.Columns["SizeID"].Visible = false;
            DistriButionDGV.Columns["StorageID"].Visible = false;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataSave();
        }

        private void DataSave()
        {
            string Cade_ = "";//DTTDATE.Text.ToString().Substring(0, 4) + DTTDATE.Text.ToString().Substring(5, 2) + DTTDATE.Text.ToString().Substring(7, 2);
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            string sqlselect;
            sqlselect = "select max(cade) as cade from Wph_Report where cade like '%" + DTTDATE.Value.ToString("yyyyMMdd") + "%'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            if (ds.Tables[0].Rows[0]["Cade"].ToString() == "")
            {
                Cade_ = "0001";
            }
            else
            {
                Cade_ = ("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(ds.Tables[0].Rows[0]["Cade"].ToString().Length - 4, 4)) + 1).ToString())
                    .Substring(("0000" + (Convert.ToInt32(ds.Tables[0].Rows[0]["Cade"].ToString().Substring(ds.Tables[0].Rows[0]["Cade"].ToString().Length - 4, 4)) + 1).ToString()).Length - 4, 4);
            }
            conn.Close();

            string strsql = "";
            try
            {
                for (int i = 0; i < DistriButionDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    if (DistriButionDGV.Rows[i].Cells["NO"].Value.ToString() != "")
                    {
                        strsql += "insert into Wph_Distribution (Rid,Date,Special,pid,ColourID,SizeID,Qty,StorageID,Cade) values ('"
                            + DistriButionDGV.Rows[i].Cells["Rid"].Value.ToString() + "','"
                            + DTTDATE.Value.ToString("yyyy-MM-dd") + "','" + DistriButionDGV.Rows[i].Cells["Special"].Value.ToString() + "','"
                            + DistriButionDGV.Rows[i].Cells["Pid"].Value.ToString() + "','" + DistriButionDGV.Rows[i].Cells["ColourID"].Value.ToString() +
                            "','" + DistriButionDGV.Rows[i].Cells["SizeID"].Value.ToString() + "','" + DistriButionDGV.Rows[i].Cells["NO"].Value.ToString() + "','" +
                            DistriButionDGV.Rows[i].Cells["StorageID"].Value.ToString() + "','WP" + DTTDATE.Value.ToString("yyyyMMdd") + Cade_ + "') ;";
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
