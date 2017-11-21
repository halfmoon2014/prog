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


namespace Merrto.SingleSupplement
{
    public partial class DateStorage : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.DATECalse getcade = new baseclass.DATECalse();
        DataSet ds = new DataSet();
        public DateStorage()
        {
            InitializeComponent();
        }
        private int save_ = 0;
        private string ApiUrl ="";
        private string ApiKey = "";
        private string ApiSerect = "";
        private void DateStorage_Load(object sender, EventArgs e)
        {
            XmlNodeReader reader = null;
            string s = "";
            try
            {
                XmlDocument doc = new XmlDocument();
                // 装入指定的XML文档
                doc.Load("ErpUrl.xml");
                // 设定XmlNodeReader对象来打开XML文件
                reader = new XmlNodeReader(doc);
                // 读取XML文件中的数据，并显示出来
                while (reader.Read())
                {
                    //判断当前读取得节点类型
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            s = reader.Name;
                            break;
                        case XmlNodeType.Text:
                            if (s.Equals("Api_Url"))
                            {
                                ApiUrl = reader.Value;
                            }
                            else if (s.Equals("Api_Key"))
                            {
                                ApiKey = reader.Value;
                            }
                            else if (s.Equals("Api_Serect"))
                            {
                                ApiSerect = reader.Value;
                            }
                            break;
                    }
                }
            }
            catch
            {  //    //清除打开的数据流
                if (reader != null)
                    reader.Close();
            }
        }

        private void BtnKIS_Click(object sender, EventArgs e)
        {
            SqlConnection objConn = sqlcon.getcon("Wei");
            string strsql = "select t_ICItem.FBarCode as BarCode, cast(sum(fqty) as decimal(15,0)) qty from T_CC_Inventory " +
            "left join t_ICItem on t_ICItem.fitemID=T_CC_Inventory.fitemID "+
            "left join t_Stock on T_CC_Inventory.fstockID=t_Stock.fitemID where FBarCode like '%" + TxtCade.Text.ToString() + "%' and (T_CC_Inventory.fstockID='226' or T_CC_Inventory.fstockID='228') group by FBarCode";
             SqlDataAdapter myData = new SqlDataAdapter(strsql, objConn);
             save_ = 1;
            objConn.Open();
            myData.Fill(ds, "Table");//填充数据
            objConn.Close();
            DGVData.DataSource = ds.Tables["Table"];
            DGVData.Columns["BarCode"].HeaderText = "条码";
            DGVData.Columns["Qty"].HeaderText = "数量";
        }

        private void BtnERP_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BarCode", typeof(System.String));//用户姓名
            dt.Columns.Add("Qty", typeof(System.Int32));//用户编号
            SqlConnection Conn = sqlcon.getcon("");
            string strsql = "SELECT cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade as BarCode FROM m_product LEFT JOIN m_ProductSub " +
                            "ON m_ProductSub.PID=m_product.ID left join m_ProductSize on m_ProductSize.pid=m_product.ID " +
                            "LEFT join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid where item_no like '%"+TxtCade.Text.ToString()+"%'";
            SqlDataAdapter myData = new SqlDataAdapter(strsql, Conn);
            save_ =2;
            Conn.Open();
            myData.Fill(ds, "Table");//填充数据
            Conn.Close();
            if (ds.Tables["Table"].Rows.Count > 0)
            {
                try
                {
                    for (int s = 0; s < ds.Tables["Table"].Rows.Count; s++)
                    {
                        ERP(ds.Tables["Table"].Rows[s]["BarCode"].ToString(), dt);

                    }
                }
                catch (Exception ex)
                {
                    return;
                }
            }

            DGVData.DataSource = dt;
            DGVData.Columns["BarCode"].HeaderText = "条码";
            DGVData.Columns["Qty"].HeaderText = "数量";
        }
        private void ERP(string sku,DataTable dt)
        {
           
            ///接口参数
            Dictionary<string, string> date = new Dictionary<string, string>();
            date.Add("appKey", ApiKey);//AppKey[必填]
            date.Add("proSkuNo", sku);//商品Sku[必填]
            string ddd = "xml";
            ///调用接口
            Client client = new Client(ApiUrl, "IOpenAPI.GetProductSkuInfo", ApiKey, ApiSerect, ddd);
            ///获得接口返回值
            string sAPIResult = "";
            try
            {
                sAPIResult = client.Post(date);
            }
            catch (Exception ex)
            {
                
                //txtMsg.Text = "第三方平台的Api_Url无效。" + ex;
                return;
            }
            
            if (Comm.StrToInt(Comm.get_JsonValueByName(sAPIResult, "Code")) < 100)
            {
                //txtMsg.Text = sAPIResult;
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
                DataRow row2 = dt.NewRow();
                row2[0] = Comm.get_Xml_Nodes(TempXml, "//ProSkuNo");
                row2[1] = Comm.get_Xml_Nodes(TempXml, "//ProCount");
                dt.Rows.Add(row2);
             }
            #endregion
         
        }
        private void BTNSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string strsql = "";
                for (int i = 0; i < DGVData.Rows.Count; i++)
                {
                    int a = Convert.ToInt32(DGVData.Rows[i].Cells["Qty"].Value.ToString());
                    if (Convert.ToInt32(DGVData.Rows[i].Cells["Qty"].Value.ToString()) != 0 && DGVData.Rows[i].Cells["BarCode"].Value.ToString()!="")
                    {
                        strsql += "insert into SS_DateStorage (Cade,Cadedate,type,Barcode,Qty)values('"+getcade.uppacking("BR_PassToStock", DateTime.Now.ToString("yyyyMMdd"), "KC") +
                            "','" + DTPCade.Value.ToString("yyyy-MM-dd") + "','" + save_ + "','"
                            + DGVData.Rows[i].Cells["BarCode"].Value.ToString() + "','" + DGVData.Rows[i].Cells["Qty"].Value.ToString() + "')";
                    }
                }
                strsql += " update SS_DateStorage set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                           "left join M_productsub on M_productsub.pid=M_product.id " +
                           "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                           "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                           "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade=SS_DateStorage.BarCode;" +
                           " update SS_DateStorage set PID=M_product.id,Colourid=M_productsub.id,SDID=m_SizeDetails.id from M_product " +
                           "left join M_productsub on M_productsub.pid=M_product.id " +
                           "left join m_ProductSize on m_ProductSize.pid=M_product.id " +
                           "left join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
                           "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='MT'+SS_DateStorage.BarCode ;";
                conn.Open();
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据更新失败！", "系统提示：", MessageBoxButtons.OK);
                Console.WriteLine(ex.Message);
            }
        }
    }
}
