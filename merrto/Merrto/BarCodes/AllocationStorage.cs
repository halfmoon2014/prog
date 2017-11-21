using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using grproLib;
using System.Xml;
using System.IO;

namespace Merrto.BarCodes
{
    public partial class AllocationStorage : Form
    {
         private int saveno = 0;//打印的份数
        private GridppReport Report = new GridppReport();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.xmldataset xmldate = new baseclass.xmldataset();
        baseclass.SelectDate sd = new baseclass.SelectDate();
        baseclass.DATECalse getcade = new baseclass.DATECalse();
        private int S = 0;//循环的数量
        private int print_ = 1;
        System.Media.SoundPlayer media;
        public AllocationStorage()
        {
            InitializeComponent();
        }

        private void AllocationStorage_Load(object sender, EventArgs e)
        {
            loadfrm();
        }

        private void loadfrm()
        {
            this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
            this.CboCallIn.DataSource = sd.Stock();
            CboCallIn.ValueMember = "StockID";
            CboCallIn.DisplayMember = "Stockname";
            CbmCallOut.DataSource = sd.Stock();
            CbmCallOut.ValueMember = "StockID";
            CbmCallOut.DisplayMember = "Stockname";
            TxtBatch.Text = getcade.uppacking("Br_AllocationStorage", DateTime.Now.ToString("yyyyMMdd"), "TB" + sd.getChar(Cmbprint.Text.ToString())); //CadeNom();
        }

        private void btnBARCode_Click(object sender, EventArgs e)
        {
            int s = 0;
            for (int i = 0; i < LBBarCode.Items.Count; i++)
            {
                if (LBBarCode.Items[i].ToString() != "")
                {
                    s += 1;
                }
            }
            DataSave(s);
            this.LBBarCode.Items.Clear();
            this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
        }

        private void DataSave(int s)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string sqlstr = "";

                sqlstr += " insert into Br_AllocationStorage(Cade,Cadedate,pid,colourID,sdid,BarCode,Qty,CallinID,CallOutID,OrderCade,username) select '"
                                        + getcade.uppacking("Br_AllocationStorage", DateTime.Now.ToString("yyyyMMdd"), "TB" + sd.getChar(Cmbprint.Text.ToString())) + "','"
                                        + DateTime.Now.ToString("yyyy-MM-dd") + "',"
                                        + "m_ProductSub.pid,m_ProductSub.id,m_SizeDetails.id,'"
                                        + LBBarCode.Items[0].ToString() + "','"
                                        + s + "','"
                                        + CboCallIn.SelectedValue.ToString() + "','"
                                        +CbmCallOut.SelectedValue.ToString() + "','"
                                        + TXTBill.Text.ToString() + "','"
                                        + frmlogin.userID + "' FROM m_product LEFT JOIN m_ProductSub " +
                                "ON m_ProductSub.PID=m_product.ID left join m_ProductSize on m_ProductSize.pid=m_product.ID " +
                                "LEFT join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                                "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='" + LBBarCode.Items[0].ToString() + "'";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnprints_Click(object sender, EventArgs e)
        {
        
            PrintData(1);
            if (print_ == 1)
            {
                Report.PrintPreview(true);
            }
       
        }

        private void PrintData(int save)
        {

            if (LBBarCode.Items.Count == 0)
            {
                print_ = 0;
                this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "请注意，没有您要打印的数据\r\n" + this.TXTROEER.Text;
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
            string strsql = "SELECT '" + getcade.uppacking("Br_AllocationStorage", DateTime.Now.ToString("yyyyMMdd"), "TB" + sd.getChar(Cmbprint.Text.ToString())) + "' as Cade,'出:" + CbmCallOut.Text.ToString() + "-入:" + CboCallIn.Text.ToString() + "' as files,khdw,ITEM_NO as Item,m_product.photo,m_name as Name,Ingredients,FabricBarCode,SafetyClass," +
                           "S_COLOR as Color,CO_CODE as Code,m_SizeDetails.cade as Sizecade,m_SizeDetails.[name] as Sizename," +
                            "cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade " +
                            "as Barcode,m_SizeDetails.Name as Size,'" + s + "' as Nomber,m_ProductSub.pid FROM m_product LEFT JOIN m_ProductSub " +
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
                    media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\货号颜色.wav");
                    media.Play();
                    this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "请注意，档案资料没有对应用的货号与颜色\r\n" + this.TXTROEER.Text;

                    print_ = 0;
                    return;
                }
                else
                {
                    try
                    {
                        //下载打印图片
                        string strimageurl = "http://120.43.209.230:8082/" + ds.Tables[0].Rows[0]["photo"].ToString();
                        System.Net.WebClient webclient = new System.Net.WebClient();
                        webclient.DownloadFile(strimageurl, @"D:\迈途\ZXCPTP.jpg");
                    }
                    catch (Exception ex)
                    {
                        if (File.Exists(@"D:\迈途\ZXCPTP.jpg"))//判断文件是不是存在           
                        {
                            File.Delete(@"D:\迈途\ZXCPTP.jpg");//如果存在则删除           
                        }
                        Console.WriteLine(ex.Message);
                    }
                    print_ = 1;
                }

                if (saveno < Convert.ToInt32(TxtBatchNO.Text.ToString()))
                {
                    if (save == 0)
                    {
                        DataSave(s);
                    }
                    Report.LoadFromFile(@rwos().ToString());
                    Report.ConnectionString = sqlcon.XMLIP();
                    Report.QuerySQL = "SELECT '" + getcade.uppacking("Br_AllocationStorage", DateTime.Now.ToString("yyyyMMdd"), "TB" + sd.getChar(Cmbprint.Text.ToString())) + "' as Cade,'出:" + CbmCallOut.Text.ToString() + "-入:" + CboCallIn.Text.ToString() + "' as files,khdw,ITEM_NO as Item,m_product.photo,m_name as Name,Ingredients,FabricBarCode,SafetyClass," +
                               "S_COLOR as Color,CO_CODE as Code,m_SizeDetails.cade as Sizecade,m_SizeDetails.[name] as Sizename," +
                                "cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade " +
                                "as Barcode,m_SizeDetails.Name as Size,'" + s + "' as Nomber,m_ProductSub.pid FROM m_product LEFT JOIN m_ProductSub " +
                                "ON m_ProductSub.PID=m_product.ID left join m_ProductSize on m_ProductSize.pid=m_product.ID " +
                                "LEFT join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                                "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='" + LBBarCode.Items[0].ToString() + "' ";

                    saveno++;
                    if (saveno == Convert.ToInt32(TxtBatchNO.Text.ToString()))
                    {
                        TxtBatch.Text = getcade.uppacking("Br_AllocationStorage", DateTime.Now.ToString("yyyyMMdd"), "TB" + sd.getChar(Cmbprint.Text.ToString()));
                        saveno = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private string rwos()
        {
            //唯品汇条码打印
            DataTable dt = new DataTable();
            string Rouet = Application.StartupPath + "\\PrintRoute.xml";
            string printR = "";
            dt = xmldate.CXmlToDataTable(Rouet);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["FormID"].ToString() == "装箱条码")
                {
                    printR = dt.Rows[i]["Route"].ToString();
                }
            }
            return printR;

        }

        private void TXTBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            int saveno = 0;
            if (e.KeyCode == Keys.Enter)
            {
                
                if (S < Convert.ToInt32(this.txtsmnomber.Text))
                {
                    if (this.LBBarCode.Items.Count > 0)
                    {
                        if (this.LBBarCode.Items[this.LBBarCode.Items.Count - 1].ToString() != "")
                        {
                            if (this.TXTBarCode.Text != LBBarCode.Items[this.LBBarCode.Items.Count - 1].ToString())
                            {
                                if (chkPrompt.Checked == true)
                                {
                                    media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\条码不一致.wav");
                                    media.Play();
                                }
                                this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "扫描条码不一致：" + this.TXTBarCode.Text + "\r\n" + this.TXTROEER.Text;
                                this.TXTBarCode.Text = "";
                                if (ChkBarCode.Checked == false)
                                {
                                    this.LBBarCode.Items.Clear();
                                    this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
                                    S = 0;
                                }
                                return;
                            }
                        }
                    }
                   
                    for (int DG = 0; DG < DGVDetail.Rows.Count; DG++)
                    {
                        //BN_ = 0;
                        if (this.TXTBarCode.Text.ToString() == DGVDetail.Rows[DG].Cells["BarCode"].Value.ToString())
                        {

                            this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "扫描数据超出原单数据：" + this.TXTBarCode.Text + "\r\n" + this.TXTROEER.Text;
                            this.TXTBarCode.Text = "";
                            if (chkPrompt.Checked == true)
                            {
                                media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\检验不一致.wav");
                                media.Play();
                            }
                            

                        }
                    }

                    S += 1;
                    this.LBBarCode.Items.Add(this.TXTBarCode.Text);
                    this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "扫描：" + this.TXTBarCode.Text + "\r\n" + this.TXTROEER.Text;
                    this.TXTBarCode.Text = "";
                    this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n   " + S.ToString();
                    if (chkPrompt.Checked == true)
                    {
                        media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\通过.wav");
                        media.Play();
                    }
                    if (S == Convert.ToInt32(this.txtsmnomber.Text))
                    {
                        if (chkprint.Checked == true)
                        {
                            if (chkPrompt.Checked == true)
                            {
                                media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\打印输出.wav");
                                media.Play();
                            }
                            PrintData(0);
                            if (print_ == 1)
                            {
                                Report.Print(false);
                                //Report.PrintPreview(true);
                            }
                            this.LBBarCode.Items.Clear();
                            this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
                            S = 0;
                        }
                        else
                        {
                            int s = 0;
                            for (int i = 0; i < LBBarCode.Items.Count; i++)
                            {
                                if (LBBarCode.Items[i].ToString() != "")
                                {
                                    s += 1;
                                }
                            }

                            if (saveno < Convert.ToInt32(TxtBatchNO.Text.ToString()))
                            {
                                DataSave(s);
                                saveno++;
                                if (saveno == Convert.ToInt32(TxtBatchNO.Text.ToString()))
                                {
                                    TxtBatch.Text = getcade.uppacking("Br_AllocationStorage", DateTime.Now.ToString("yyyyMMdd"), "TB" + sd.getChar(Cmbprint.Text.ToString()));
                                    saveno = 0;
                                }
                            }
                            S = 0;
                            this.LBBarCode.Items.Clear();
                            this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";

                        }
                    }

                }
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintData(1);
            if (print_ == 1)
            {
                Report.Print(false);
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
