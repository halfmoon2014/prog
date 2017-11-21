using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Merrto.baseclass
{
    public class SelectDate
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.getChar getC = new baseclass.getChar();
        /// <summary>
        /// 供货商资料选择
        /// </summary>
        /// <returns></returns>
        public DataTable Factory()
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlds = new SqlDataAdapter("select * from m_Factory", conn);
            conn.Open();
            sqlds.Fill(ds, "Factory");
            conn.Close();
            return ds.Tables["Factory"];
        }
        /// <summary>
        /// 仓库资料选择
        /// </summary>
        /// <returns></returns>
        public DataTable Stock()
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlds = new SqlDataAdapter("select * from m_Stock", conn);
            conn.Open();
            sqlds.Fill(ds, "Stock");
            conn.Close();
            return ds.Tables["Stock"];
        }
        /// <summary>
        /// 店铺
        /// </summary>
        /// <returns></returns>
        public DataTable GetShop()
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlds = new SqlDataAdapter("select * from STR_Shop", conn);
            conn.Open();
            sqlds.Fill(ds, "SShop");
            conn.Close();
            return ds.Tables["SShop"];
        }
        /// <summary>
        /// 取入库单据凭证号+单据号+仓库
        /// </summary>
        /// <returns></returns>
        public DataTable FStock()
        {
            SqlConnection conn = sqlcon.getcon("");

            DataSet ds = new DataSet();
            SqlDataAdapter Fda = new SqlDataAdapter("select ID,cast(BR_RStorageList.CAde as varchar(20))+'  |  '+cast(OrderCade as varchar(20))+'  |  '+cast(sTOCKNAME as varchar(20)) as Name from BR_RStorageList " +
                                        "LEFT JOIN M_Stock ON M_Stock.STOCKid=BR_RStorageList.STOCKID " +
                                        "where not exists(select * from ( " +
                                        "select rid,sum(qty)qty from BR_RStroageDetailList group by rid) rk " +
                                        "left join (select rid,sum(qTY)qty1 from BR_PassToStockReturn group by rid) returnrk on rk.rid=returnrk.rid " +
                                        "left join (select rid,sum(QTY)qty2 from BR_PassToStock group by rid) smrk on smrk.rid=rk.rid " +
                                        "where Qty-isnull(qty1,0)-isnull(qty2,0)<=0 and rk.rid=BR_RStorageList.id) and  listtype>0", conn);
            conn.Open();
            Fda.Fill(ds, "FStock");
            conn.Close();
            return ds.Tables["FStock"];
        }
        /// <summary>
        /// 取入库数据给文本
        /// </summary>
        /// <param name="ID">入库ID</param>
        /// <returns></returns>
        public DataTable RStorageList(string ID)  
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
               string sqlstr = "select ID,stockID,FID,ordercade from BR_RStorageList where ID='" + ID + "'";
              
               SqlDataAdapter Fda = new SqlDataAdapter(sqlstr, conn);
               conn.Open();
               Fda.Fill(ds, "FStock");
               conn.Close();
            return ds.Tables["FStock"];
        }
        /// <summary>
        /// 取入库单据的明细
        /// </summary>
        /// <param name="ID">入库ID</param>
        /// <returns></returns>
        public DataTable RKDetail(string ID)
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            string sqlstrrk = "select cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade barcode,TEMP2.qty as Rqty,isnull(temp.qty,0) PTSRQTY,0 as qty,isnull(temp1.qty,0) as PTSqtY,TEMP2.qty-isnull(temp.qty,0)-isnull(temp1.qty,0) syQty " +
                                "from (select rid,pid,sdid,colourid,sum(qty) as qty FROM BR_RStroageDetailList  group by rid,pid,sdid,colourid)TEMP2 " +
                                "left join (select rid,pid,sdid,colourid,sum(qty) as qty from  BR_PassToStockReturn group by rid,pid,sdid,colourid) temp  on temp.pid=TEMP2.pid " +
                                "and temp.SDID=TEMP2.SDID and temp.colourid=TEMP2.colourid and temp.RID=TEMP2.RID " +
                                "left join (select rid,pid,sdid,colourid,sum(qty) as qty from BR_PassToStock group by rid,pid,sdid,colourid) temp1 on temp1.pid=TEMP2.pid " +
                                "and temp1.SDID=TEMP2.SDID and temp1.colourid=TEMP2.colourid and temp1.RID=TEMP2.RID " +
                                "left join m_product on m_product.id=TEMP2.pid " +
                                "left join m_productsub on m_productsub.id=TEMP2.Colourid " +
                                "left join m_SizeDetails on m_SizeDetails.id=TEMP2.Sdid where TEMP2.RID='" + ID + "' and TEMP2.qty-isnull(temp.qty,0)-isnull(temp1.qty,0)!=0";
            SqlDataAdapter Frkda = new SqlDataAdapter(sqlstrrk, conn);
            conn.Open();
            Frkda.Fill(ds, "Detail");
            conn.Close();
            return ds.Tables["Detail"];
        }

        public string getChar(string strleng)
        {
            string strTemp = "";
            int iLen = strleng.Length;
            int i = 0;
            for (i = 0; i <= iLen - 1; i++)
            {
                strTemp += getC.GetCharSpellCode(strleng.Substring(i, 1));
            }
            return strTemp;
        }
    }
}
