using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Merrto.WPH
{
    public partial class WphtrBarCode : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphtrBarCode()
        {
            InitializeComponent();
        }
        private int NO_;
        private int BC_ = 0;
        private int BN_ = 0;
        System.Media.SoundPlayer media;

        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
        

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            DataTable dt=new DataTable();
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtBarCode.Text.ToString().Length == 20)
                {
                    LBLPAsking.Text = "";
                }
                SqlDataAdapter sqlDaper = new SqlDataAdapter("select Cade,BarCode,PO,NO,0 as barCodeNomber,Verify from Wph_TheRetreat where cade='" + TxtBarCode.Text.ToString() + "'", conn);
                SqlDataAdapter sqlDaper1 = new SqlDataAdapter("select * from Wph_TRBarCode where cade='" + TxtBarCode.Text.ToString() + "'", conn);
                if (LBLPAsking.Text == "")
                {
                    if (TxtBarCode.Text.ToString().Length != 20)
                    {
                        TxtBarCode.Text = "";
                        BC_ = 0;
                        NO_ = 0;
                        ProudctDGV.DataSource = "";
                        if (chkPrompt.Checked == true)
                        {
                            
                            media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\找无箱号.wav");
                            media.Play();
                            return;
                        }
                    }
                    LBLPAsking.Text = TxtBarCode.Text.ToString();
                    TxtBarCode.Text = "";

                    conn.Open();
                    sqlDaper.Fill(ds, "TheRetreat");
                    dt=ds.Tables["TheRetreat"];
                    sqlDaper1.Fill(ds, "TRBarCode");
                    conn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable myTable = ds.Tables["TheRetreat"];//创建Table

                        BindingSource myBindingSource= new BindingSource();//创建BindingSource


                        ProudctDGV.DataSource = myBindingSource;//将BindingSource绑定到GridView 


                        ProudctDGV.DataSource = ds.Tables[0];
                        ProudctDGV.Columns["BarCode"].HeaderText = "条型码";
                        ProudctDGV.Columns["NO"].HeaderText = "数量";
                        ProudctDGV.Columns["NO"].Width = 60;
                        ProudctDGV.Columns["barCodeNomber"].HeaderText = "扫描数量";
                        ProudctDGV.Columns["barCodeNomber"].Width = 80;
                        ProudctDGV.Columns["PO"].HeaderText = " PO单号";
                        ProudctDGV.Columns["PO"].Width = 80;
                        ProudctDGV.Columns["Verify"].Visible = false;
                        ProudctDGV.Columns["Cade"].Visible = false;
                    }
                    if (ds.Tables["TRBarCode"].Rows.Count>0)
                    {
                        LBLPAsking.Text = "";
                        if (chkPrompt.Checked == true)
                        {
                            media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\此箱号以校验成功.wav");

                            media.Play();
                            conn.Close();
                            return;
                        }
                    }
                    //conn.Close();

                    if (chkPrompt.Checked == true)
                    {
                        media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\此箱号可以校验.wav");
                        media.Play();
                    }
                    for (int i = 0; i < ProudctDGV.Rows.Count; i++)
                    {
                        NO_ += Convert.ToInt32(ProudctDGV.Rows[i].Cells["NO"].Value.ToString());
                    }
                }
                else
                {
                    if (BC_ <= NO_)
                    {

                        for (int i = 0; i < ProudctDGV.Rows.Count; i++)
                        {
                            BN_ = 0;
                            if (TxtBarCode.Text.ToString() == ProudctDGV.Rows[i].Cells["BarCode"].Value.ToString())
                            {
                                ProudctDGV.Rows[i].Cells["barCodeNomber"].Value = (Convert.ToInt32(ProudctDGV.Rows[i].Cells["barCodeNomber"].Value.ToString()) + 1).ToString();
                                if (chkPrompt.Checked == true)
                                {
                                    media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\通过.wav");
                                    media.Play();
                                }
                                BN_ = 1;
                                BC_++;

                                if (BC_ == NO_)
                                {
                                    int rowsno = 0;
                                    string strsql = "";
                                    for (int j = 0; j < ProudctDGV.Rows.Count; j++)
                                    {
                                        string aab = ProudctDGV.Rows[j].Cells["barCodeNomber"].Value.ToString();
                                        if (ProudctDGV.Rows[j].Cells["barCodeNomber"].Value.ToString() == "0")
                                        {
                                            rowsno++;
                                        }
                                        if (ProudctDGV.Rows[j].Cells["barCodeNomber"].Value.ToString() != "0")
                                        {
                                            strsql += "insert into Wph_TRBarCode (Cade,BarCode,NO,PO) values('"
                                                + ProudctDGV.Rows[j].Cells["Cade"].Value.ToString() + "','"
                                                + ProudctDGV.Rows[j].Cells["BarCode"].Value.ToString() + "','"
                                                + ProudctDGV.Rows[j].Cells["barCodeNomber"].Value.ToString() + "','"
                                                + ProudctDGV.Rows[j].Cells["Cade"].Value.ToString().Substring(4, 10) + "')";
                                        }
                                    }
                                    if (rowsno == 0)
                                    {
                                        conn.Open();
                                        SqlCommand cmd = new SqlCommand(strsql, conn);
                                        cmd.ExecuteNonQuery();
                                        conn.Close();
                                        LBLPAsking.Text = "";
                                        TxtBarCode.Text = "";
                                        BC_ = 0;
                                        NO_ = 0;
                                        ProudctDGV.DataSource = "";
                                        if (chkPrompt.Checked == true)
                                        {
                                            media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\校验成功.wav");
                                            media.Play();
                                        }
                                    }
                                    else
                                    {

                                        if (chkPrompt.Checked == true)
                                        {
                                            media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\检验不一致.wav");
                                            media.Play();
                                        }
       
                                        if (MessageBox.Show("\n此箱检验数据与原单数据不一致！！   \n\n\n确认是否保存(Y/N)", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                                        {
                                            String PM = Interaction.InputBox("请输入备注", "输入备注", "", 70, 100);
                                            if (PM != string.Empty)
                                            {
                                                strsql += " update Wph_TRBarCode set remark='" + PM + "' where Cade='" + ProudctDGV.Rows[1].Cells["Cade"].Value.ToString() + "'";
                                                conn.Open();
                                                SqlCommand cmd = new SqlCommand(strsql, conn);
                                                cmd.ExecuteNonQuery();
                                                conn.Close();
                                                LBLPAsking.Text = "";
                                                TxtBarCode.Text = "";
                                                BC_ = 0;
                                                NO_ = 0;
                                                ProudctDGV.DataSource = "";
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        }
                        //箱号条码.wav
                        if (BN_ == 0)
                        {
                            DataRow dr = ((DataTable)ProudctDGV.DataSource).NewRow();
                            dr["Cade"] = LBLPAsking.Text.ToString();
                            dr["BarCode"] = TxtBarCode.Text.ToString();
                            dr["barCodeNomber"] = 1;
                            ((DataTable)ProudctDGV.DataSource).Rows.Add(dr);

                            if (chkPrompt.Checked == true)
                            {
                                media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\箱号条码.wav");
                                media.Play();

                            }
                            BC_++;
                        }
                        TxtBarCode.Text = "";

                    }
                    else
                    {
                        LBLPAsking.Text = "";
                        TxtBarCode.Text = "";
                        ProudctDGV.DataBindingComplete += delegate { ProudctDGV.Columns.Clear(); };
                    }

                }
            }
        
        }
    }
}
