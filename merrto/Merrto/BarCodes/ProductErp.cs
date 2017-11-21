using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using U1Client;


namespace Merrto
{
    public partial class ProductERP : Form
    {
        public ProductERP()
        {
            InitializeComponent();
        }
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private void ProductExpress_Load(object sender, EventArgs e)
        {
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void BtnRead_Click(object sender, EventArgs e)
        {
            ReadData();
        }
        private void ReadData()
        {
            txtMsg.Text = ""; lblMsg.Text = "查询出库单信息处理结果：<br>-------------------------------------------------------------------------------<br><br>";
            ///接口参数
            Dictionary<string, string> date = new Dictionary<string, string>();
            date.Add("appKey", txtApiKey.Text);//AppKey[必填]
            date.Add("billNo", "");//出库单号
            date.Add("status", "0");//状态[0：已生成；1：已出库；2：已取消 默认全部]
            date.Add("startTime", "2014-01-01");//开始时间[必填]
            date.Add("endTime", "2014-06-01");//结束时间[必填]
            date.Add("pageIndex", "1");//页数[必填]
            date.Add("pageSize", "10");//每页条数[必填][数量： 10、20、50]
            string ddd = "xml";
            ///调用接口
            Client client = new Client(txtApiUrl.Text, "IOpenAPI.GetSaleStock", txtApiKey.Text, txtApiSerect.Text, ddd);
            ///获得接口返回值
            string sAPIResult = "";
            try
            {
                sAPIResult = client.Post(date);
            }
            catch (Exception ex)
            {
                txtMsg.Text = "第三方平台的Api_Url无效。" + ex;
                return;
            }
            if (ddd == "xml")
            {
                if (Comm.StrToInt(Comm.get_JsonValueByName(sAPIResult, "Code")) < 100)
                {
                    txtMsg.Text = sAPIResult;
                    return;
                }
                #region ========== Xml返回 ===========
                StringReader Reader = new StringReader(sAPIResult);
                XmlDocument TempXml = new XmlDocument();
                TempXml.Load(Reader);
                string ApiResultMessage = Comm.get_Xml_Nodes(TempXml, "//Message");
                string ApiResultCode = Comm.get_Xml_Nodes(TempXml, "//Code");
                if (ApiResultCode == "101")
                {
                    //XmlNodeList ApiResultApi_SelectOrderDeliverInfo = TempXml.SelectNodes("//Api_SelectOrderDeliverInfo");
                    //if (ApiResultApi_SelectOrderDeliverInfo[0].InnerXml != "")
                    //{
                    //    for (int i = 0; i < ApiResultApi_SelectOrderDeliverInfo.Count; i++)
                    //    {
                    //        XmlDocument OrderDeliverInfoXml = new XmlDocument();
                    //        OrderDeliverInfoXml.LoadXml("<tradeInfo>" + ApiResultApi_SelectOrderDeliverInfo[i].InnerXml + "</tradeInfo>");
                    //        string sOrderId = Comm.get_Xml_Nodes(OrderDeliverInfoXml, "//OrderId");//系统订单编号
                    //        string sBillNo = Comm.get_Xml_Nodes(OrderDeliverInfoXml, "//BillNo");//系统出库单号
                    //        string sSkuNo = Comm.get_Xml_Nodes(OrderDeliverInfoXml, "//SkuNo");//商品Sku
                    //        string sProCount = Comm.get_Xml_Nodes(OrderDeliverInfoXml, "//ProCount");//商品数量
                    //        string sExpName = Comm.get_Xml_Nodes(OrderDeliverInfoXml, "//ExpName");//快递名称
                    //        string sExpNum = Comm.get_Xml_Nodes(OrderDeliverInfoXml, "//ExpNum");//快递编号
                    //        lblMsg.Text += "系统订单编号：" + sOrderId + " 系统出库单号：" + sBillNo + " 商品Sku：" + sSkuNo + " 商品数量：" + sProCount + "快递名称：" + sExpName + " 快递编号：" + sExpNum + "<br/><br/>";
                    //        lblMsg.Text += "----------------------------------------------------------------<br/>";
                    //    }
                    //}
                }
                #endregion
            }
            else
            {
                #region ========== Json返回 ==========
                #endregion
            }
            txtMsg.Text = sAPIResult;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMsg.Text = ""; lblMsg.Text = "商品库存处理结果：<br>-------------------------------------------------------------------------------<br><br>";
            ///接口参数
            Dictionary<string, string> date = new Dictionary<string, string>();
            date.Add("appKey", txtApiKey.Text);//AppKey[必填]
            date.Add("proSkuNo", "37141030240005");//商品Sku[必填]
            string ddd = "xml";
            ///调用接口
            Client client = new Client(txtApiUrl.Text, "IOpenAPI.GetProductSkuInfo", txtApiKey.Text, txtApiSerect.Text, ddd);
            ///获得接口返回值
            string sAPIResult = "";
            try
            {
                sAPIResult = client.Post(date);
                txtMsg.Text += sAPIResult;
            }
            catch (Exception ex)
            {
                txtMsg.Text = "第三方平台的Api_Url无效。" + ex;
                return;
            }
            if (ddd == "xml")
            {
                if (Comm.StrToInt(Comm.get_JsonValueByName(sAPIResult, "Code")) < 100)
                {
                    txtMsg.Text = sAPIResult;
                    return;
                }
                #region ========== Xml返回 ===========
                StringReader Reader = new StringReader(sAPIResult);
                XmlDocument TempXml = new XmlDocument();
                TempXml.Load(Reader);
                string ApiResultMessage = Comm.get_Xml_Nodes(TempXml, "//Message");
                string ApiResultCode = Comm.get_Xml_Nodes(TempXml, "//Code");
                if (ApiResultCode == "101")
                {
                    string sProTitle = Comm.get_Xml_Nodes(TempXml, "//ProTitle");//商品标题
                    string sProNo = Comm.get_Xml_Nodes(TempXml, "//ProNo");//商品货号
                    string sProColorName = Comm.get_Xml_Nodes(TempXml, "//ProColorName");//颜色名称
                    string sProSizesName = Comm.get_Xml_Nodes(TempXml, "//ProSizesName");//规格名称
                    string sProSkuNo = Comm.get_Xml_Nodes(TempXml, "//ProSkuNo");//商品Sku
                    string sProCount = Comm.get_Xml_Nodes(TempXml, "//ProCount");//商品数量
                    lblMsg.Text += "商品标题：" + sProTitle + " 商品货号：" + sProNo + " 商品颜色：" + sProColorName + " 商品规格：" + sProSizesName + "商品Sku：" + sProSkuNo + " 商品数量：" + sProCount + "<br/>";
                }
                #endregion
            }
            else
            {
                //#region ========== Json返回 ==========
                //string ApiCode = Comm.get_JsonValueByName(sAPIResult, "Code");
                //if (ApiCode == "101")
                //{
                //    string ApiResult = Comm.get_JsonValueByName(sAPIResult, "Result");
                //    List<Dto_Pro_Sku_Info> listResult = new List<Dto_Pro_Sku_Info>();
                //    listResult = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dto_Pro_Sku_Info>>(ApiResult);
                //    for (int i = 0; i < listResult.Count; i++)
                //    {
                //        string ProTitle = listResult[i].ProTitle.ToString();
                //        string ProNo = listResult[i].ProNo.ToString();
                //        string ProColorName = listResult[i].ProColorName.ToString();
                //        string ProSizesName = listResult[i].ProSizesName.ToString();
                //        string ProSkuNo = listResult[i].ProSkuNo.ToString();
                //        string ProCount = listResult[i].ProCount.ToString();
                //        lblMsg.Text += "商品名称：" + ProTitle + " ，商品货号：" + ProNo + " ，商品颜色：" + ProColorName + " ，商品规格:" + ProSizesName + " ，商品SKU：" + ProSkuNo + " ，商品可用库存：" + ProCount + "<br/>";
                //    }
                //}
                //#endregion
            }
            txtMsg.Text = sAPIResult;
        }
    }
}
