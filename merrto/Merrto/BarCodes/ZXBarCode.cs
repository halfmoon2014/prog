using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using grproLib;
using System.Xml;
using System.IO;

namespace Merrto
{
    public partial class ZXBarCode : Form
    {
        private GridppReport Report = new GridppReport();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.xmldataset xmldate = new baseclass.xmldataset();
        public ZXBarCode()
        {
            InitializeComponent();
        }
        private int S = 0;
        private int print_ = 1;
        System.Media.SoundPlayer media;
        private void TXTBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (S < 1) //Convert.ToInt32(this.txtsmnomber.Text）
                {
                    if (this.LBBarCode.Items.Count > 0)
                    {
                        if (this.LBBarCode.Items[this.LBBarCode.Items.Count-1].ToString() != "")
                        {
                            if (this.TXTBarCode.Text != LBBarCode.Items[this.LBBarCode.Items.Count - 1].ToString())
                            {
                                if (chkPrompt.Checked == true)
                                {
                                    media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\条码不一致.wav");
                                    media.Play();
                                }
                                this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "扫描条码不一致：" + this.TXTBarCode.Text + "\r\n" + this.TXTROEER.Text;//给TXT赋值提示的内容
                                this.TXTBarCode.Text = "";
                                return;
                            }
                        }
                    }
                    S += 1;
                    this.LBBarCode.Items.Add(this.TXTBarCode.Text);
                    this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "扫描：" + this.TXTBarCode.Text + "\r\n"+this.TXTROEER.Text;//给TXT赋值提示的内容
                    this.TXTBarCode.Text = "";
                    this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n   " + S.ToString();
                    if (chkPrompt.Checked == true)
                    {
                        media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\通过.wav");
                        media.Play();
                    }
                    if (S == 1)
                    {
                        if (chkprint.Checked == true)
                        {
                            if (chkPrompt.Checked == true)
                            {
                                media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\打印输出.wav");
                                media.Play();
                            }
                            PrintData();
                            if (print_ == 1)
                            {
                                Report.Print(false);
                            }
                            this.LBBarCode.Items.Clear();
                            this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
                            S = 0;
                        }
                    }
               
                }
            }
        }

        private void BarCode_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
            DataTable dt = new DataTable();
            string Rouet = Application.StartupPath + "\\FormRoute.xml";
            dt = xmldate.CXmlToDataTable(Rouet);
            Cmbprint.DataSource = dt;
            this.Cmbprint.ValueMember = "Route";
            this.Cmbprint.DisplayMember = "FormID";
            DataTable dtfield = new DataTable();
            SqlDataAdapter sqlds = new SqlDataAdapter("select * from m_ProductField",conn);
            //LBBarCode.CreateGraphics().DrawString(LBBarCode.Items[1].ToString(), LBBarCode.Font, new SolidBrush(LBBarCode.Font.Size), LBBarCode.GetItemRectangle(1)); 


        }

        private void btnBARCode_Click(object sender, EventArgs e)
        {
            DataTable xds = new DataTable();
            string Rouet = Application.StartupPath + "\\FormRoute.xml";//读取xml
            xds = xmldate.CXmlToDataTable(Rouet);
            Rouet = "";
            for (int i = 0; i < xds.Rows.Count; i++)
            {
                if (Cmbprint.Text.ToString() == xds.Rows[i]["FormID"].ToString())
                {
                    Rouet = xds.Rows[i]["Route"].ToString();//读取xml中的路径
                }
            }
            if (Rouet != "")
            {
                this.LBBarCode.Items.Add("");
                if (LBBarCode.Items[0].ToString() != "")
                {
                    SqlConnection conn = sqlcon.getcon("");
                    string strsql = "SELECT ITEM_NO,S_COLOR,CO_CODE FROM m_product LEFT JOIN m_ProductSub ON m_ProductSub.PID=m_product.ID where ITEM_NO+cast(CO_CODE as varchar(5))='" +
                        LBBarCode.Items[0].ToString().Substring(0, LBBarCode.Items[0].ToString().Length - 2) + "'";
                    SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
                    DataSet ds = new DataSet();
                    int s = 0;
                    for (int i = 0; i < LBBarCode.Items.Count; i++)
                    {
                        if (LBBarCode.Items[i].ToString() != "")
                        {
                            s += 1;
                        }
                    }
                    try
                    {
                        conn.Open();
                        sqlDaper.Fill(ds);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Merrto.BarCodeCade bcc = new Merrto.BarCodeCade(@Rouet, LBBarCode.Items[0].ToString(), 2, s);//设置报表
                            bcc.ShowDialog();
                        }
                        else
                        {
                            if (chkPrompt.Checked == true)
                            {
                                media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\货号颜色.wav");
                                media.Play();
                            }
                            this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "请注意，档案资料没有对应用的货号与颜色\r\n" + this.TXTROEER.Text;//给TXT赋值提示的内容
                            return;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "没有预览的数据\r\n" + this.TXTROEER.Text;//给TXT赋值提示的内容

                }
            }
        }

        private void TXTNomber_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT ITEM_NO,S_COLOR,CO_CODE FROM m_product LEFT JOIN m_ProductSub ON m_ProductSub.PID=m_product.ID where ITEM_NO+cast(CO_CODE as varchar(5))='" +
                LBBarCode.Items[0].ToString().Substring(0, LBBarCode.Items[0].ToString().Length - 2) + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                if (ds.Tables[0].Rows.Count < 1)
                {
                    media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\货号颜色.wav");
                    media.Play();
                    this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "请注意，档案资料没有对应用的货号与颜色\r\n" + this.TXTROEER.Text;//给TXT赋值提示的内容
                    return;
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            baseclass.BarCode.Code128 _Code = new baseclass.BarCode.Code128();
            //Code128 _Code = new Code128();
            _Code.ValueFont = new Font("宋体", 20);
            System.Drawing.Bitmap imgTemp = _Code.GetCodeImage(LBBarCode.Items[0].ToString(), baseclass.BarCode.Code128.Encode.Code128A);
            imgTemp.Save(System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "BarCode.gif", System.Drawing.Imaging.ImageFormat.Gif);
        }

        private void btnpringbrow_Click(object sender, EventArgs e)
        {
            if (LBBarCode.Items[0].ToString() == "")
            {
                SqlConnection conn = sqlcon.getcon("");
                string strsql = "SELECT ITEM_NO,S_COLOR,CO_CODE FROM m_product LEFT JOIN m_ProductSub ON m_ProductSub.PID=m_product.ID where ITEM_NO+cast(CO_CODE as varchar(5))='" +
                    LBBarCode.Items[0].ToString().Substring(0, LBBarCode.Items[0].ToString().Length - 2) + "'";
                SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    sqlDaper.Fill(ds);
                    conn.Close();
                    if (ds.Tables[0].Rows.Count < 1)
                    {
                        media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\货号颜色.wav");
                        media.Play();
                        this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "请注意，档案资料没有对应用的货号与颜色\r\n" + this.TXTROEER.Text;//给TXT赋值提示的内容
                        return;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("没有预览的数据！！");

            }
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnprints_Click(object sender, EventArgs e)
        {
            PrintData();
            if (print_ == 1)
            {
                Report.PrintPreview(true);
            }
        }
        private void PrintData()
        {
            if (LBBarCode.Items.Count == 0)
            {
                print_ = 0;
                this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "请注意，没有您要打印的数据\r\n" + this.TXTROEER.Text;//给TXT赋值提示的内容
                return;
            }
            int s = 0;
            for (int i = 0; i < LBBarCode.Items.Count; i++)
            {
                if (LBBarCode.Items[i].ToString() != "")
                {
                    s += 1;
                }
            }

            DataTable dt = new DataTable();
            
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT ITEM_NO as Item,m_product.photo,m_name as Name,standard_3 as Standard,PRICE_TAG,material_m,Ingredients,FabricBarCode,SafetyClass,S_COLOR as Color,CO_CODE as Code,m_SizeDetails.cade as Sizecade,m_SizeDetails.[name] as Sizename,USA,UK,CM," +
                            "cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade " +
                            "as Barcode,m_SizeDetails.Name as Size,'" + s + "' as Nomber,m_ProductSub.pid,CASE M_sex when '男' then 'Men' when '女' then 'WoMen' else '' end as Sex FROM m_product LEFT JOIN m_ProductSub " +
                            "ON m_ProductSub.PID=m_product.ID left join m_ProductSize on m_ProductSize.pid=m_product.ID " +
                            "LEFT join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                            "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='" + LBBarCode.Items[0].ToString() + "' ";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count < 1)
                {
                    media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\货号颜色.wav");//提示的内容
                    media.Play();//声音提示
                    this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "请注意，档案资料没有对应用的货号与颜色\r\n" + this.TXTROEER.Text;//给TXT赋值提示的内容
                    print_ = 0;
                    return;
                }
                else {
                    try
                    {
                        //下载打印图片
                        string strimageurl = "http://120.43.209.230:8082/" + ds.Tables[0].Rows[0]["photo"].ToString();
                        System.Net.WebClient webclient = new System.Net.WebClient();
                        webclient.DownloadFile(strimageurl, @"D:\迈途\CPTP.jpg");
                    }
                    catch (Exception ex)
                    {
                        if (File.Exists(@"D:\迈途\CPTP.jpg"))//判断文件是不是存在           
                        {
                            File.Delete(@"D:\迈途\CPTP.jpg");//如果存在则删除           
                        }  
                        Console.WriteLine(ex.Message);
                    }
                    print_ = 1;
                }
                if (Cmbprint.SelectedValue.ToString() == "")
                {
                    print_ = 0;
                    this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "请注意，没有您要打印的条码报表\r\n" + this.TXTROEER.Text;
                    return;
                }
                else
                {
                    print_ = 1;
                }
                Report.LoadFromFile(@Cmbprint.SelectedValue.ToString());
                Report.ConnectionString = sqlcon.XMLIP();
                Report.QuerySQL = "SELECT ITEM_NO as Item,m_name as Name,standard_3 as Standard,PRICE_TAG,material_m,Ingredients,FabricBarCode,SafetyClass,S_COLOR as Color,CO_CODE as Code,m_SizeDetails.cade as Sizecade,m_SizeDetails.[name] as Sizename,USA,UK,CM," +
                            "cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade " +
                            "as Barcode,m_SizeDetails.Name as Size,'" + s + "' as Nomber,m_ProductSub.pid,CASE M_sex when '男' then 'Men' when '女' then 'WoMen' else '' end as Sex FROM m_product LEFT JOIN m_ProductSub " +
                            "ON m_ProductSub.PID=m_product.ID left join m_ProductSize on m_ProductSize.pid=m_product.ID " +
                            "LEFT join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                            "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='" + LBBarCode.Items[0].ToString() + "' ";

                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintData();//打印数据
            if (print_ == 1)
            {
                Report.PrintPreview(true);
                //Report.Print(false);//打印不提示打印框
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.LBBarCode.Items.Clear();
            this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
            this.TXTROEER.Text = "";
            S = 0;
        }
    }
}

