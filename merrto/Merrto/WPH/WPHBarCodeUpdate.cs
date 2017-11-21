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
    public partial class WPHBarCodeUpdate : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WPHBarCodeUpdate()
        {
            InitializeComponent();
        }

        private void WPHBarCodeUpdate_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select distinct [Special] from Wph_Packing2 union all select distinct [Special] from Wph_Packing ", conn);
            sqlDaper.Fill(ds, "Special");
            cmbSpecial.DataSource = ds.Tables["Special"];
            cmbSpecial.DisplayMember = "Special";
            conn.Close();
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            brows();
        }
            private void brows()
        {
            string strsql = "";

            //所有数据
            if (TxtCade.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " Cade like '%" + TxtCade.Text.ToString() + "%'";
            }
            if (this.cmbSpecial.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " SPecial='" + cmbSpecial.Text.ToString() + "'";
            }
            if (this.TXTBarCode.Text.ToString() != "")
            {
                if (strsql != "")
                {
                    strsql += " and ";
                }
                strsql = strsql + " BarCode like '%" + TXTBarCode.Text.ToString() + "%'";
            }
            if (strsql != "")
            {
                strsql = " where "+strsql;
            }


            strsql = "select CAde,Barcode,Item,Size,Colour,Nomber,[Add],Special,type,Barcode as oldBarCode from Wph_Packing " + strsql;

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();

            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();

            sqlDaper.Fill(ds);
            conn.Close();

            WPHbROWDGV.DataSource = ds.Tables[0];
            WPHbROWDGV.Columns["Cade"].HeaderText = "凭证号";
            WPHbROWDGV.Columns["Cade"].ReadOnly =true;
            WPHbROWDGV.Columns["Barcode"].HeaderText = "条码";
            WPHbROWDGV.Columns["Item"].HeaderText = "款号";
            WPHbROWDGV.Columns["Size"].HeaderText = "尺码";
            WPHbROWDGV.Columns["Colour"].HeaderText = "颜色";
            WPHbROWDGV.Columns["Nomber"].HeaderText = "数量";
            WPHbROWDGV.Columns["Add"].HeaderText = "地区";
            WPHbROWDGV.Columns["Add"].ReadOnly = true;
            WPHbROWDGV.Columns["Special"].HeaderText = "专场";
            WPHbROWDGV.Columns["type"].Visible = false;
            WPHbROWDGV.Columns["oldBarCode"].Visible = false;
            WPHbROWDGV.Columns["Special"].ReadOnly = true;

            //WPHbROWDGV.Columns["StockID"].Visible = false;
            //WPHbROWDGV.Columns["listtype"].Visible = false;
        }

            private void BtnSave_Click(object sender, EventArgs e)
            {
                SqlConnection conn = sqlcon.getcon("");
                if (Convert.ToInt32(WPHbROWDGV[8, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 1)//取状态为1的才能修改，0为作废，1为编辑，2为审核
                {
                    string strsql = "";
                    for (int da = 0; da < WPHbROWDGV.Rows.Count; da++)
                    {
                        if (Convert.ToInt32(WPHbROWDGV.Rows[da].Cells["Nomber"].Value.ToString()) == 0)
                        {
                            strsql += "delete from Wph_Packing where CAde='" + WPHbROWDGV.Rows[da].Cells["Cade"].Value.ToString() + "' and BarCode='" + WPHbROWDGV.Rows[da].Cells["oldBarCode"].Value.ToString() + "'";
                        }
                        else
                        {
                            strsql += "update Wph_Packing set Barcode='" + WPHbROWDGV.Rows[da].Cells["BarCode"].Value.ToString() +
                                "',Item='" + WPHbROWDGV.Rows[da].Cells["Item"].Value.ToString() + "',Size='" + WPHbROWDGV.Rows[da].Cells["Size"].Value.ToString() +
                                "',Colour='" + WPHbROWDGV.Rows[da].Cells["Colour"].Value.ToString() + "',Nomber='" + WPHbROWDGV.Rows[da].Cells["Nomber"].Value.ToString() + 
                                "'where CAde='" + WPHbROWDGV.Rows[da].Cells["Cade"].Value.ToString() + "' and BarCode='" + WPHbROWDGV.Rows[da].Cells["oldBarCode"].Value.ToString() + "' ";
                        }
                        
                    }
                    SqlCommand sqlcom = new SqlCommand(strsql, conn);
                    conn.Open();
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();
                    BTNbROW_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("此单据不能修改！！");
                }
                
            }

            private void WPHbROWDGV_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (Convert.ToInt32(WPHbROWDGV[8, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 0)
                {
                    lblType.Text = "作废";
                }else 
                if (Convert.ToInt32(WPHbROWDGV[8, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 2)
                {
                    lblType.Text = "审核";
                }else
                    if (Convert.ToInt32(WPHbROWDGV[8, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 1)
                    {
                        lblType.Text = "编辑";
                    }
                    else { lblType.Text = "编辑"; }
            }

            private void BtnToVoid_Click(object sender, EventArgs e)
            {
                if (Convert.ToInt32(WPHbROWDGV[8, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 1)
                {
                    SqlConnection conn = sqlcon.getcon("");
                    conn.Open();
                    string str = "update Wph_Packing set type=0 where Cade='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
                    SqlCommand sqlcom = new SqlCommand(str, conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();
                    BTNbROW_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("此单已审核或已作废不能作废！！");
                }
            }

            private void Btnlook_Click(object sender, EventArgs e)
            {
                if (Convert.ToInt32(WPHbROWDGV[8, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 1)
                {
                    SqlConnection conn = sqlcon.getcon("");
                    conn.Open();
                    string str = "update Wph_Packing set type=2 where Cade='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
                    SqlCommand sqlcom = new SqlCommand(str, conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();
                    BTNbROW_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("此单已审核或已作废不能作废！！");
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                if (Convert.ToInt32(WPHbROWDGV[8, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString()) == 2)
                {
                    SqlConnection conn = sqlcon.getcon("");
                    conn.Open();
                    string str = "update Wph_Packing set type=1 where Cade='" + WPHbROWDGV[0, WPHbROWDGV.CurrentCell.RowIndex].Value.ToString() + "'";
                    SqlCommand sqlcom = new SqlCommand(str, conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();
                    BTNbROW_Click(sender, e);

                }
                else
                {
                    MessageBox.Show("此单没有审核不能反审！！");
                }
            }

    }
}
