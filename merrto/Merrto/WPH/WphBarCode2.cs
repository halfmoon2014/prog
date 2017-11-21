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
    public partial class WphBarCode2 : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphBarCode2()
        {
            InitializeComponent();
        }
        private int NO_;
        private int BC_=0;
        private int BN_ = 0;
        System.Media.SoundPlayer media;
        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtBarCode.Text.ToString().Length == 14)
                {
                    LBLPAsking.Text = "";
                }
                SqlDataAdapter sqlDaper = new SqlDataAdapter("select Wph_Packing2.Cade,Special,Wph_Item,item_NO,"+
                "s_color,isnull(Wph_Item,'')+cast(CO_CODE as varchar(5))+cast(m_SizeDetails.cade as varchar(5)) as BarCode,"+
                "m_SizeDetails.name as SDname, [NO],0 as barCodeNomber,Wph_Storage.[name] stname,Verify from Wph_Packing2 " +
                "left join Wph_Product on Wph_Product.pid=Wph_Packing2.PID "+
                "left join M_productsub  on M_productsub.id=Wph_Packing2.ColourID "+
                "left join m_SizeDetails on m_SizeDetails.id=Wph_Packing2.SizeID "+
                "left join Wph_Storage on Wph_Storage.id=StorageID " +
                "left join M_product on M_product.id=Wph_Packing2.PID where Wph_Packing2.cade='" + TxtBarCode.Text.ToString() + "'", conn);

                if (LBLPAsking.Text == "")
                {
                    if (TxtBarCode.Text.ToString().Length != 14)
                    {
                        if (chkPrompt.Checked == true)
                        {
                            TxtBarCode.Text = "";
                            media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\找无箱号.wav");
                            media.Play();
                            return;
                        }
                    }
                    LBLPAsking.Text = TxtBarCode.Text.ToString();
                    TxtBarCode.Text = "";

                    conn.Open();
                    sqlDaper.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ProudctDGV.DataSource = ds.Tables[0];
                        ProudctDGV.Columns["BarCode"].HeaderText = "条型码";
                        ProudctDGV.Columns["item_NO"].HeaderText = "款号";
                        ProudctDGV.Columns["item_NO"].Width = 80;
                        ProudctDGV.Columns["Wph_Item"].HeaderText = "新款号";
                        ProudctDGV.Columns["Wph_Item"].Width = 80;
                        ProudctDGV.Columns["SDname"].HeaderText = "尺码";
                        ProudctDGV.Columns["SDname"].Width = 60;
                        ProudctDGV.Columns["NO"].HeaderText = "数量";
                        ProudctDGV.Columns["NO"].Width = 60;
                        ProudctDGV.Columns["barCodeNomber"].HeaderText = "扫描数量";
                        ProudctDGV.Columns["barCodeNomber"].Width = 80;
                        ProudctDGV.Columns["s_color"].HeaderText = "颜色";
                        ProudctDGV.Columns["s_color"].Width = 60;
                        ProudctDGV.Columns["stname"].HeaderText = "目地日";
                        ProudctDGV.Columns["stname"].Width = 80;
                        ProudctDGV.Columns["Special"].HeaderText = "专场";
                        ProudctDGV.Columns["Special"].Width = 120;
                        ProudctDGV.Columns["Verify"].Visible = false;
                    }
                    if (ds.Tables[0].Rows[0]["Verify"].ToString() == "1")
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
                    conn.Close();

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
                                if (Convert.ToInt32(ProudctDGV.Rows[i].Cells["barCodeNomber"].Value.ToString()) + 1 <= Convert.ToInt32(ProudctDGV.Rows[i].Cells["NO"].Value.ToString()))
                                {
                                    ProudctDGV.Rows[i].Cells["barCodeNomber"].Value = (Convert.ToInt32(ProudctDGV.Rows[i].Cells["barCodeNomber"].Value.ToString()) + 1).ToString();
                                    if (chkPrompt.Checked == true)
                                    {
                                        media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\通过.wav");
                                        media.Play();
                                    }
                                    BN_ = 1;
                                    BC_++;
                                }//BC_++;
                                else
                                {
                                    BN_ = 2;
                                    if (chkPrompt.Checked == true)
                                    {
                                        media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\配货超出.wav");
                                        media.Play();
                                    }
                                    //MessageBox.Show("这个款的数量超出！！");
                                }
                                if (BC_ == NO_)
                                {

                                    conn.Open();
                                    SqlCommand cmd = new SqlCommand("update Wph_Packing2 set Verify=1 where Cade='" + LBLPAsking.Text + "'", conn);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                    LBLPAsking.Text = "";
                                    TxtBarCode.Text = "";
                                    if (chkPrompt.Checked == true)
                                    {
                                        media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\校验成功.wav");
                                        media.Play();
                                    }
                                }
                                break;
                            }
                        }
                        //箱号条码.wav
                        if (BN_ == 0)
                        {
                            if (chkPrompt.Checked == true)
                            {
                                media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\箱号条码.wav");
                                media.Play();

                            }
                            //MessageBox.Show("此箱号找无 " + TxtBarCode.Text.ToString() + " 条码！！");
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
