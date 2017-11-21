using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using grproLib;
using System.Xml;
using System.Data.SqlClient;
//using System.IO;

namespace Merrto.BarCodes
{
    public partial class PassToStockReturn : Form
    {
        private int saveno = 0;
        private GridppReport Report = new GridppReport();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.xmldataset xmldate = new baseclass.xmldataset();
        baseclass.getChar getC = new baseclass.getChar();
        baseclass.DATECalse getcade = new baseclass.DATECalse();
        baseclass.SelectDate sd = new baseclass.SelectDate();
        public PassToStockReturn()
        {
            InitializeComponent();
        }
        private int S = 0;
        private int print_ = 1;
        System.Media.SoundPlayer media;
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.LBBarCode.Items.Clear();
            this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
            this.TXTROEER.Text = "";
            S = 0;
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
        private void DataSave(int s,string barcode)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string sqlstr = "";

                sqlstr += " insert into BR_PassToStockReturn(Cade,CadeDate,pid,colourID,sdid,BarCode,QTy,FID,rid,OrderCade,username) select '"
                                        + TxtBatch.Text.ToString() + "','"
                                        + DateTime.Now.ToString("yyyy-MM-dd") + "',"
                                        + "m_ProductSub.pid,m_ProductSub.id,m_SizeDetails.id,'"
                                        + barcode + "','"
                                        + s + "','"
                                        + CboFile.SelectedValue.ToString() + "','"
                                        +this.CBoRK.SelectedValue.ToString() + "','"
                                        + TXTBill.Text.ToString() + "','"
                                        + frmlogin.userID + "' FROM m_product LEFT JOIN m_ProductSub " +
                                "ON m_ProductSub.PID=m_product.ID left join m_ProductSize on m_ProductSize.pid=m_product.ID " +
                                "LEFT join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                                "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='" + barcode + "'";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlstr, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                //if (Convert.ToInt32(DGVDetail.Rows[0].Cells["syQTY"].Value) == 0)
                //{
                //    loadfrm();
                //    cborkselect();
                //}

                //MessageBox.Show("数据保存成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("数据保存失败！", "系统提示：", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
            }
        }
        private void TXTBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            int saveno = 0;
            if (e.KeyCode == Keys.Enter)
            {
                this.LBBarCode.Items.Add(this.TXTBarCode.Text);
                this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "扫描：" + this.TXTBarCode.Text + "\r\n" + this.TXTROEER.Text;
                this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n   " + S.ToString();
                if (chkPrompt.Checked == true)
                {
                    media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\通过.wav");
                    media.Play();
                }
                int OK = 0;
                for (int DG = 0; DG < DGVDetail.Rows.Count; DG++)
                {
                   
                    //BN_ = 0;
                    if (this.TXTBarCode.Text.ToString() == DGVDetail.Rows[DG].Cells["BarCode"].Value.ToString())
                    {
                        if (Convert.ToInt32(DGVDetail.Rows[DG].Cells["syQTY"].Value.ToString()) <= 0)
                        {

                            this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "扫描数据超出原单数据：" + this.TXTBarCode.Text + "\r\n" + this.TXTROEER.Text;
                            this.TXTBarCode.Text = "";
                            if (chkPrompt.Checked == true)
                            {
                                media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\检验不一致.wav");
                                media.Play();
                            }
                            return;
                        }
                        else
                        {
                            DGVDetail.Rows[DG].Cells["QTY"].Value = (Convert.ToInt32(DGVDetail.Rows[DG].Cells["QTY"].Value.ToString()) + 1).ToString();
                            DGVDetail.Rows[DG].Cells["syQTY"].Value = (Convert.ToInt32(DGVDetail.Rows[DG].Cells["syQTY"].Value.ToString()) - 1).ToString();
                            if (Convert.ToInt32(DGVDetail.Rows[DG].Cells["syQTY"].Value.ToString()) == 0)
                            {
                                DataSave(Convert.ToInt32(DGVDetail.Rows[DG].Cells["QTY"].Value.ToString()), DGVDetail.Rows[DG].Cells["BarCode"].Value.ToString());
                                TxtBatch.Text = getcade.uppacking("BR_PassToStockReturn", DateTime.Now.ToString("yyyyMM"), "RT" + getChar());
                                this.LBBarCode.Items.Clear();
                                this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
                                this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + " 数据已保存：" + this.TXTBarCode.Text + "\r\n" + this.TXTROEER.Text;
                                this.TXTBarCode.Text = "";
                                if (chkPrompt.Checked == true)
                                {
                                    media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\款号检验成功.wav");
                                    media.Play();
                                }
                            }
                            this.TXTBarCode.Text = "";
                            OK = 1;
                            break;
                        }
                    }
                    
                }
                if (OK == 0)
                {
                    this.TXTROEER.Text = System.DateTime.Now.ToString("HH:mm:ss") + "原单据查无此款号：" + this.TXTBarCode.Text + "\r\n" + this.TXTROEER.Text;
                    this.TXTBarCode.Text = "";
                    if (chkPrompt.Checked == true)
                    {
                        media = new System.Media.SoundPlayer(Application.StartupPath + @"\wav\原单据查无此款号.wav");
                        media.Play();
                    }
                    return;
                }
                

            }
        }

        
        private void Cmbprint_SelectedValueChanged(object sender, EventArgs e)
        {
            TxtBatch.Text = getcade.uppacking("BR_PassToStockReturn", DateTime.Now.ToString("yyyyMM"), "RT" + getChar());
            //TxtAdd.Text = strTemp;
        }
        private string getChar()
        {
            string strTemp = "";
            int iLen = Cmbprint.Text.ToString().Length;
            int i = 0;
            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += getC.GetCharSpellCode(Cmbprint.Text.ToString().Substring(i, 1));
            }
            return strTemp;
        }

        private void PassToStockReturn_Load(object sender, EventArgs e)
        {
            loadfrm();
        }

        private void loadfrm()
        {
            this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
            CboFile.DataSource =sd.Factory();
            CboFile.ValueMember = "id";
            CboFile.DisplayMember = "title";
            CBoRK.DataSource = sd.FStock(); //ds.Tables["FStock"];
            CBoRK.ValueMember = "ID";
            CBoRK.DisplayMember = "Name";
            TxtBatch.Text = getcade.uppacking("BR_PassToStockReturn", DateTime.Now.ToString("yyyyMM"), "RT" + getChar()); //CadeNom();
        }

       private void CBoRK_SelectedIndexChanged(object sender, EventArgs e)
        {
            cborkselect();
        }

       private void cborkselect()
       {
           DataRowView rowView = (DataRowView)CBoRK.SelectedItem;
           if (CBoRK.SelectedValue.ToString() != rowView.ToString())
           {

               if (sd.RStorageList(CBoRK.SelectedValue.ToString()).Rows.Count > 0)
               {
                   CboFile.SelectedValue = sd.RStorageList(CBoRK.SelectedValue.ToString()).Rows[0]["FID"].ToString();
                   TXTBill.Text = sd.RStorageList(CBoRK.SelectedValue.ToString()).Rows[0]["ordercade"].ToString();
               }
               this.DGVDetail.RowsDefaultCellStyle.ForeColor = Color.Black;     //所有行字体颜色
               DGVDetail.DataSource = sd.RKDetail(CBoRK.SelectedValue.ToString()); //ds.Tables["Detail"];
               //if (sd.RKDetail(CBoRK.SelectedValue.ToString()).Rows.Count > 0)
               //{
               //    this.txtsmnomber.Text = sd.RKDetail(CBoRK.SelectedValue.ToString()).Rows[0]["syQTY"].ToString();
               //} 
               DGVDetail.Columns["BarCode"].HeaderText = "条码";
               DGVDetail.Columns["RQTY"].HeaderText = "单据数量";
               DGVDetail.Columns["RQTY"].Width = 60;
               DGVDetail.Columns["QTY"].HeaderText = "数量";
               DGVDetail.Columns["QTY"].Width = 60;
               DGVDetail.Columns["PTSRQTY"].HeaderText = "退货数量";
               DGVDetail.Columns["PTSRQTY"].Width = 80;
               DGVDetail.Columns["PTSQTY"].HeaderText = "入库数量";
               DGVDetail.Columns["PTSQTY"].Width = 80;
               DGVDetail.Columns["syQTY"].HeaderText = "剩余数量";
               DGVDetail.Columns["syQTY"].Width = 80;
           }
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
           DataSave(s, LBBarCode.Items[0].ToString());
           this.LBBarCode.Items.Clear();
           this.TXTNomber.Text = "扫描次数: \r\n \r\n \r\n\n\n  0";
       }



    }
}
