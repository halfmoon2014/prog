using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Merrto
{
    public partial class WphBarCode : Form
    {
        //private IMultimediaServer server;
        //private IMultimediaManager multimediaManager;
        //private SilenceVideoFileMaker maker = new SilenceVideoFileMaker(); //录制无声视频
        //private DynamicDesktopConnector dynamicDesktopConnector = new DynamicDesktopConnector();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.Video video;
        public WphBarCode()
        {
            InitializeComponent();
            //int port = 9900;
            //OMCSConfiguration config = new OMCSConfiguration(10, 5, EncodingQuality.High, 16000, 640, 480, "");
            //this.server = MultimediaServerFactory.CreateMultimediaServer(port, new DefaultUserVerifier(), config, false);

            //this.multimediaManager = MultimediaManagerFactory.GetSingleton();
            //this.multimediaManager.DesktopEncodeQuality = 1; //通过此参数控制清晰度 
            //this.multimediaManager.Initialize("aa01", "", "127.0.0.1", port);

            //this.dynamicDesktopConnector.ConnectEnded += new ESBasic.CbGeneric<ConnectResult>(dynamicDesktopConnector_ConnectEnded);
            //this.dynamicDesktopConnector.BeginConnect("aa01");

            //this.Cursor = Cursors.WaitCursor; 
        }
        private int NO_;
        private int BC_=0;
        private int BN_ = 0;

        //void dynamicDesktopConnector_ConnectEnded(ConnectResult obj)
        //{
        //    System.Threading.Thread.Sleep(500);
        //    this.Ready();
        //}

        //private void Ready()
        //{
        //    if (this.InvokeRequired)
        //    {
        //        this.BeginInvoke(new CbGeneric(this.Ready));
        //    }
        //    else
        //    {
        //        this.Cursor = Cursors.Default;
        //        //this.button1.Enabled = true;
        //        this.lblTxt.Visible = false;
        //    }
        //}

        private System.Threading.Timer timer;
        System.Media.SoundPlayer media;
        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            SqlConnection conn =sqlcon.getcon("");
            DataSet ds = new DataSet();
            if (e.KeyCode == Keys.Enter)
            {
                if (TxtBarCode.Text.ToString().Length == 14)
                {
                    LBLPAsking.Text = "";
                    BC_ = 0;
                    NO_ = 0;
                    ProudctDGV.DataSource = "";
                }
                SqlDataAdapter sqlDaper = new SqlDataAdapter("select BarCode,Item,Colour,Size,Nomber,000 as barCodeNomber,[ADd],Special,Verify from Wph_Packing where cade='" + TxtBarCode.Text.ToString() + "'", conn);
                
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
                    ///*******开始录制************/
                    //MessageBox.Show("开始录象！");
                    string dir_ = "D://Video";
                    if (!System.IO.Directory.Exists(dir_))
                    {
                        System.IO.Directory.CreateDirectory(dir_);
                    }
                    video.StarKinescope(dir_+"//" + TxtBarCode.Text.ToString() + ".avi");  //"c://" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".avi");
                    ///*******************/
                    LBLPAsking.Text = TxtBarCode.Text.ToString();
                    TxtBarCode.Text = "";
                   
                    conn.Open();
                    sqlDaper.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ProudctDGV.DataSource = ds.Tables[0];
                        ProudctDGV.Columns["BarCode"].HeaderText = "条型码";
                        ProudctDGV.Columns["Item"].HeaderText = "款号";
                        ProudctDGV.Columns["Item"].Width = 80;
                        ProudctDGV.Columns["Size"].HeaderText = "尺码";
                        ProudctDGV.Columns["Size"].Width = 60;
                        ProudctDGV.Columns["Nomber"].HeaderText = "数量";
                        ProudctDGV.Columns["Nomber"].Width = 60;
                        ProudctDGV.Columns["barCodeNomber"].HeaderText = "扫描数量";
                        ProudctDGV.Columns["barCodeNomber"].Width = 80;
                        ProudctDGV.Columns["Colour"].HeaderText = "颜色";
                        ProudctDGV.Columns["Colour"].Width = 60;
                        ProudctDGV.Columns["ADd"].HeaderText = "目地日";
                        ProudctDGV.Columns["ADd"].Width = 80;
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
                        NO_ +=Convert.ToInt32(ProudctDGV.Rows[i].Cells["Nomber"].Value.ToString());
                    }
                    string S;
                }
                else {
                    if (BC_ <= NO_)
                    {
                        
                        for (int i = 0; i < ProudctDGV.Rows.Count; i++)
                        {
                            BN_ = 0;
                            if (TxtBarCode.Text.ToString() == ProudctDGV.Rows[i].Cells["BarCode"].Value.ToString())
                            {
                                if (Convert.ToInt32(ProudctDGV.Rows[i].Cells["barCodeNomber"].Value.ToString()) + 1 <= Convert.ToInt32(ProudctDGV.Rows[i].Cells["Nomber"].Value.ToString()))
                                {
                                    ProudctDGV.Rows[i].Cells["barCodeNomber"].Value = (Convert.ToInt32(ProudctDGV.Rows[i].Cells["barCodeNomber"].Value.ToString()) + 1).ToString();
                                    if (chkPrompt.Checked == true)
                                    {
                                        media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\通过.wav");
                                        media.Play();
                                    }
                                    if (ProudctDGV.Rows[i].Cells["barCodeNomber"].Value.ToString() == ProudctDGV.Rows[i].Cells["Nomber"].Value.ToString())
                                    {
                                        if (chkPrompt.Checked == true)
                                        {
                                            media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\款号检验成功.wav");
                                            media.Play();
                                        }
                                    }
                                    BN_ = 1;
                                    BC_++;
                                }
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
                                    if (LBLPAsking.Text.ToString() == "")
                                    {
                                        if (chkPrompt.Checked == true)
                                        {
                                            media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\无箱号无法检验成功.wav");
                                            media.Play();
                                            return;
                                        }
                                    }
                                    conn.Open();
                                    
                                    SqlCommand cmd = new SqlCommand("update Wph_Packing set Verify=1 where Cade='"+LBLPAsking.Text.ToString()+"'", conn);
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                    ///*******生成视频文件成功！******/
                                    ///
                                    video.StopKinescope();
                                    ///*************/
                                    //MessageBox.Show("生成视频文件成功！");

                                    LBLPAsking.Text = "";
                                    TxtBarCode.Text = "";
                                    ProudctDGV.DataSource = "";
                                    BC_ = 0;
                                    NO_ = 0;
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
                        ProudctDGV.DataSource = "";
                    } 

                }
            }
        }

        public void VideoShow()
        {
            video = new baseclass.Video(panelPreview.Handle, panelPreview.Width, panelPreview.Height);
            video.StartWebCam();
            video.get();
            video.Capparms.fYield = true;
            video.Capparms.fAbortLeftMouse = false;
            video.Capparms.fAbortRightMouse = false;
            video.set();

        } 
        private void WphBarCode_Load(object sender, EventArgs e)
        {
            LBLPAsking.Text = "";
            VideoShow();
        }
    }
}
