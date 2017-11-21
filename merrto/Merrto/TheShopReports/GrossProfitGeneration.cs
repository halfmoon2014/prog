using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.TheShopReports
{
    public partial class GrossProfitGeneration : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.DATECalse datec = new baseclass.DATECalse();
        public GrossProfitGeneration()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            string sqlselect = "";

            sqlselect += " StopDate >='" + DTPStop.Value.ToString("yyyy-MM-dd") + "' AND SHOPID='" + CmdShop.SelectedValue.ToString() + "'  and type='1'";
           
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds1 = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_GrossProfitGeneration where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds1);
            conn.Close();
            if (ds1.Tables[0].Rows.Count > 1)
            {
                MessageBox.Show("\n该终止日期的数据已生成不能重新生成！！   \n\n\n    ", "系统提示");
                
                    return;
                
            }
            if (ds1.Tables[0].Rows.Count ==1)
            {
                if (MessageBox.Show("\n该终止日期的数据已生成，是否从新生成   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_GrossProfitGeneration where " + sqlselect, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    return;
                }
            }
            string sqlstr = "select temp.shopID,ShopName,sumMoney,cost as costOFSales,isnull(BsumMoney,0) BsumMoney,isnull(tempb.Bcost,0) Bcost,round((isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08,2) as salesReturn,round((isnull(cost,0)-isnull(BCost,0))*0.08,2) as RturnCost," +
            "round(isnull(temp.sumMoney,0)-(isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08-isnull(tempb.BsumMoney,0),2) as actualSales,round(isnull(cost,0)-(isnull(cost,0)-isnull(BCost,0))*0.08-isnull(tempb.Bcost,0) ,2) as ActualCostOFSales,round((sumMoney-sumMoney*0.08)*0.06,2) as taobaoFeeDeduction,TurnFeededuction,Express,ArtificialCost,RentCost,OtherCost,pit,other,advertisement," +
            "round(isnull(temp.sumMoney,0)-(isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08-isnull(tempb.BsumMoney,0)-(isnull(sumMoney,0)-isnull(sumMoney,0)*0.08)*0.06-isnull(TurnFeededuction,0)-(isnull(cost,0)-(isnull(cost,0)-isnull(BCost,0))*0.08-isnull(tempb.Bcost,0))-isnull(pit,0)-isnull(Express,0)-isnull(advertisement,0)-isnull(other,0),2)-isnull(ArtificialCost,0)-isnull(RentCost,0)-isnull(OtherCost,0) as GrossProfit,customerUnit " +
            "from ( select shopID,sum(sumMoney) as summoney from STR_OrderList where  " +
            "cast(orderdate as datetime) Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' group by shopID) as temp " +
            "left join (select STR_OrderDetailList.shopiD,sum(cost*BuyNO) as cost from STR_OrderDetailList " +
            "left join STR_OrderList on STR_OrderDetailList.orderCade=STR_OrderList.ordercade "+
            "left join M_productCost on STR_OrderDetailList.pid=M_productCost.pid " +
            "where cast(orderdate as datetime) Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' group by STR_OrderDetailList.shopiD) as temps on temp.shopID=temps.shopID " +
            "left join (select sum(sumMoney) as BsumMoney,sum(cost*Qty) as Bcost,shopID from STR_BrushSingleData left join M_productCost on M_productCost.pid=STR_BrushSingleData.pid " +
            "where CadeDate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' group by shopID ) as tempb on temp.shopID=tempb.shopID " +
            "left join (select shopID,round(sum(sumMoney)*0.03,0) as TurnFeededuction from STR_OrderList where  " +
            "cast(orderdate as datetime) Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and (BobyName like '%【聚】%' or BobyName like '%.%' or BobyName like '%。%' or BobyName like '%`%') group by shopID) as temptemp " +
            "on temptemp.shopID=temp.shopID " +
            "left join STR_Shop on STR_Shop.id=temp.shopID " +
            "left join ( " +
            "select shopid,sum(Case when Weight>1 then FirstHeavy+continuedHeavy*FLOOR(Weight) else FirstHeavy end) as Express " +
            "from (select STR_OrderDetailList.shopID,VipAdd,STR_OrderList.orderCade,sum(Weight) as Weight,"+
            "case when isnull(ExpressName,'')!='' then ExpressName when isnull(ExpressName,'')='' and isnull(Remarks,'')!='' and Remarks not like '%''[已下载，时间' then Remarks else '韵达' end ExpressName from STR_OrderDetailList " +
            "left join STR_OrderList on STR_OrderList.ordercade=STR_OrderDetailList.ordercade " +
            "left join STR_ProductWeight on STR_ProductWeight.pid=STR_OrderDetailList.pid and " +
            "STR_ProductWeight.SDid=STR_OrderDetailList.SDID " +
            "where cast(orderdate as datetime) Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' " +
            "group by STR_OrderDetailList.shopID,VipAdd,STR_OrderList.orderCade,ExpressName,Remarks) temp left join STR_ExpressSET on temp.VipAdd like ''+STR_ExpressSET.Eadd+'%' and ExpressName like '%'+STR_ExpressSET.name+'%' group by shopID) " +
            "as tempExpress on tempExpress.shopid=temp.shopID " +
            "left join (select shopID,sum(sumMoney) as pit from STR_itemDBO where  CadeDate " +
            "Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='2' group by shopID) as tempitem2 on tempitem2.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as ArtificialCost from STR_itemDBO where  CadeDate " +
            "Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='5' group by shopID) as tempitem5 on tempitem5.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as RentCost from STR_itemDBO where  CadeDate " +
            "Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='6' group by shopID) as tempitem6 on tempitem6.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as OtherCost from STR_itemDBO where  CadeDate " +
            "Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='7' group by shopID) as tempitem7 on tempitem7.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as advertisement from STR_itemDBO where  CadeDate " +
            "Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='1' group by shopID) as tempitem1 on tempitem1.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as other from STR_itemDBO where  CadeDate " +
            "Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='3' group by shopID) as tempitem3 on tempitem3.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as customerUnit from STR_itemDBO where  CadeDate " +
            "Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='4' group by shopID) as tempitem4 on tempitem4.shopid=temp.shopId " +
            "where temp.shopid='" + CmdShop.SelectedValue.ToString() + "'";
            //"left join (select shopID,round(sum(photographmoney)/sum(photographno),2) as customerUnit from STR_CustomerUnit where not exists(select * from STR_CustomerUnitset where STR_CustomerUnitset.name=STR_CustomerUnit.name) and "+
            //"CadeDate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "' group by shopID )as tempCustomerUnit on tempCustomerUnit.shopID=temp.shopID "+
            

            
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "DS");
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string str = " insert into STR_GrossProfitGeneration (Cade,CadeDATE,StartDate,StopDate,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,ActualSales," +
                        "ActualCostOFSales,TaobaoFeeDeduction,Express,TurnFeededuction,ArtificialCost,RentCost,OtherCost,Pit,Other,Advertisement,GrossProfit,CustomerUnit,ShopID,type,username) values ('"
                            + "ML" + DTPCadeDate.Value.ToString("yyyyMMdd") +
                            datec.uppacking("STR_GrossProfitGeneration", DTPCadeDate.Value.ToString("yyyyMMdd")) + "','"
                            + this.DTPCadeDate.Value.ToString("yyyy-MM-dd") + "','"
                            + DTPStart.Value.ToString("yyyy-MM-dd") + "','"
                            + DTPStop.Value.ToString("yyyy-MM-dd") + "','"
                            + DTPStart.Value.ToString("yyyy-MM-dd") + "至" + DTPStop.Value.ToString("yyyy-MM-dd") + "','"
                            + ds.Tables["DS"].Rows[0]["sumMoney"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["CostOFSales"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["BsumMoney"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Bcost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["SalesReturn"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["RturnCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ActualSales"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ActualCostOFSales"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["TaobaoFeeDeduction"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Express"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["TurnFeededuction"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ArtificialCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["RentCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["OtherCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Pit"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Other"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Advertisement"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["GrossProfit"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["CustomerUnit"].ToString() + "','"
                            + CmdShop.SelectedValue.ToString() + "','1','"
                            + frmlogin.userID + "')  ";
                    //}
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(str, conn);
                    sqlcom.ExecuteNonQuery();
                    sqlcom.Dispose();

                    conn.Close();
                    MessageBox.Show("报表生成成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报表生成失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("没有你要生成月份的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GrossProfitGeneration_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT ID,Cade,ShopNAME FROM STR_Shop ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "Shop");
            conn.Close();
            if (ds.Tables["Shop"].Rows.Count > 0)
            {
                CmdShop.DataSource = ds.Tables["Shop"];
                CmdShop.ValueMember = "ID";
                CmdShop.DisplayMember = "ShopNAME";
                CboYshop.DataSource = ds.Tables["Shop"];
                CboYshop.ValueMember = "ID";
                CboYshop.DisplayMember = "ShopNAME";
            }
        }

        private void BtnYSave_Click(object sender, EventArgs e)
        {
            string sqlselect = "";

            sqlselect += " StopDate >='" + DtpActualStart.Value.ToString("yyyy-MM-dd") + "' AND SHOPID='" + CmdShop.SelectedValue.ToString() + "' and type='2'";

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds1 = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_GrossProfitGeneration where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds1);
            conn.Close();
            if (ds1.Tables[0].Rows.Count > 1)
            {
                MessageBox.Show("\n该终止日期的数据已生成不能重新生成！！   \n\n\n    ", "系统提示");

                return;

            }
            if (ds1.Tables[0].Rows.Count == 1)
            {
                if (MessageBox.Show("\n该终止日期的数据已生成，是否从新生成   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_GrossProfitGeneration where " + sqlselect, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    return;
                }
            }
            string sqlstr = "select temp.shopID,ShopName,sumMoney,cost as costOFSales,isnull(BsumMoney,0) BsumMoney,isnull(tempb.Bcost,0) Bcost,0 as salesReturn,0 as RturnCost," +
            "round(isnull(temp.sumMoney,0)-0-isnull(tempb.BsumMoney,0),2) as actualSales,round(isnull(cost,0)-0-isnull(tempb.Bcost,0) ,2) as ActualCostOFSales,round((sumMoney-sumMoney*0.08)*0.06,2) as taobaoFeeDeduction,TurnFeededuction,Express,ArtificialCost,RentCost,OtherCost,pit,other,advertisement," +
            "round((isnull(temp.sumMoney,0)-0-isnull(tempb.BsumMoney,0))-(isnull(sumMoney,0)-0-isnull(tempb.BsumMoney,0))*0.06-isnull(TurnFeededuction,0)-(isnull(cost,0)-0-isnull(tempb.Bcost,0))-isnull(pit,0)-isnull(Express,0)-isnull(advertisement,0)-isnull(other,0),2)-isnull(ArtificialCost,0)-isnull(RentCost,0)-isnull(OtherCost,0) as GrossProfit,customerUnit " +
            "from ( select shopID,sum(sumMoney) as summoney from Str_ActualOrderList where  " +
            "cast(orderdate as datetime) Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' group by shopID) as temp " +
            "left join (select Str_ActualOrderDetailList.shopiD,sum(cost*BuyNO) as cost from Str_ActualOrderDetailList " +
            "left join Str_ActualOrderList on Str_ActualOrderDetailList.orderCade=Str_ActualOrderList.ordercade "+
            "left join M_productCost on Str_ActualOrderDetailList.pid=M_productCost.pid " +
            "where cast(orderdate as datetime) Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + "  23:59:59.000' group by Str_ActualOrderDetailList.shopiD) as temps on temp.shopID=temps.shopID " +
            "left join (select sum(sumMoney) as BsumMoney,sum(cost*Qty) as Bcost,shopID from STR_BrushSingleData left join M_productCost on M_productCost.pid=STR_BrushSingleData.pid " +
            "where CadeDate Between '" + DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DtpActualStop.Value.ToString("yyyy-MM-dd") + "  23:59:59.000' group by shopID ) as tempb on temp.shopID=tempb.shopID " +
            "left join (select shopID,round(sum(sumMoney)*0.03,0) as TurnFeededuction from Str_ActualOrderList where  " +
            "cast(orderdate as datetime) Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and (BobyName like '%【聚】%' or BobyName like '%.%' or BobyName like '%。%' or BobyName like '%`%') group by shopID) as temptemp " +
            "on temptemp.shopID=temp.shopID " +
            "left join STR_Shop on STR_Shop.id=temp.shopID " +
            "left join ( " +
            "select shopid,sum(Case when Weight>1 then FirstHeavy+continuedHeavy*FLOOR(Weight) else FirstHeavy end) as Express " +
            "from (select Str_ActualOrderDetailList.shopID,VipAdd,Str_ActualOrderList.orderCade,sum(Weight) as Weight," +
            "case when isnull(ExpressName,'')!='' then ExpressName when isnull(ExpressName,'')='' and isnull(Remarks,'')!='' and Remarks not like '%''[已下载，时间' then Remarks else '韵达' end ExpressName from Str_ActualOrderDetailList " +
            "left join Str_ActualOrderList on Str_ActualOrderList.ordercade=Str_ActualOrderDetailList.ordercade " +
            "left join STR_ProductWeight on STR_ProductWeight.pid=Str_ActualOrderDetailList.pid and " +
            "STR_ProductWeight.SDid=Str_ActualOrderDetailList.SDID " +
            "where cast(orderdate as datetime) Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' " +
            "group by Str_ActualOrderDetailList.shopID,VipAdd,Str_ActualOrderList.orderCade,ExpressName,Remarks) temp left join STR_ExpressSET on temp.VipAdd like ''+STR_ExpressSET.Eadd+'%' and ExpressName like '%'+STR_ExpressSET.name+'%' group by shopID) " +
            "as tempExpress on tempExpress.shopid=temp.shopID " +
            "left join (select shopID,sum(sumMoney) as pit from STR_itemDBO where  CadeDate " +
            "Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='2' group by shopID) as tempitem2 on tempitem2.shopid=temp.shopId " +
             "left join (select shopID,sum(sumMoney) as ArtificialCost from STR_itemDBO where  CadeDate " +
            "Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='5' group by shopID) as tempitem5 on tempitem5.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as RentCost from STR_itemDBO where  CadeDate " +
            "Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='6' group by shopID) as tempitem6 on tempitem6.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as OtherCost from STR_itemDBO where  CadeDate " +
            "Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='7' group by shopID) as tempitem7 on tempitem7.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as advertisement from STR_itemDBO where  CadeDate " +
            "Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='1' group by shopID) as tempitem1 on tempitem1.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as other from STR_itemDBO where  CadeDate " +
            "Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='3' group by shopID) as tempitem3 on tempitem3.shopid=temp.shopId " +
            "left join (select shopID,sum(sumMoney) as customerUnit from STR_itemDBO where  CadeDate " +
            "Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='4' group by shopID) as tempitem4 on tempitem4.shopid=temp.shopId " +
            "where temp.shopid='" + CmdShop.SelectedValue.ToString() + "'";
            //"left join (select shopID,round(sum(photographmoney)/sum(photographno),2) as customerUnit from STR_CustomerUnit where not exists(select * from STR_CustomerUnitset where STR_CustomerUnitset.name=STR_CustomerUnit.name) and "+
            //"CadeDate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "' group by shopID )as tempCustomerUnit on tempCustomerUnit.shopID=temp.shopID "+



            SqlDataAdapter sqlDaper1 = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "DS");
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string str = " insert into STR_GrossProfitGeneration (Cade,CadeDATE,StartDate,StopDate,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,ActualSales," +
                        "ActualCostOFSales,TaobaoFeeDeduction,Express,TurnFeededuction,ArtificialCost,RentCost,OtherCost,Pit,Other,Advertisement,GrossProfit,CustomerUnit,ShopID,type,username) values ('"
                            + "ML" +this.DtpActualCadeDate.Value.ToString("yyyyMMdd") +
                            datec.uppacking("STR_GrossProfitGeneration", DtpActualCadeDate.Value.ToString("yyyyMMdd")) + "','"
                            + this.DtpActualCadeDate.Value.ToString("yyyy-MM-dd") + "','"
                            + DtpActualStart.Value.ToString("yyyy-MM-dd") + "','"
                            + DtpActualStop.Value.ToString("yyyy-MM-dd") + "','"
                            + DtpActualStart.Value.ToString("yyyy-MM-dd") + "至" + DtpActualStop.Value.ToString("yyyy-MM-dd") + "','"
                            + ds.Tables["DS"].Rows[0]["sumMoney"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["CostOFSales"].ToString() + "','"
                             + ds.Tables["DS"].Rows[0]["BsumMoney"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Bcost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["SalesReturn"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["RturnCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ActualSales"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ActualCostOFSales"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["TaobaoFeeDeduction"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Express"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["TurnFeededuction"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ArtificialCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["RentCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["OtherCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Pit"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Other"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Advertisement"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["GrossProfit"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["CustomerUnit"].ToString() + "','"
                            + CmdShop.SelectedValue.ToString() + "','2','"
                            + frmlogin.userID + "')  ";
                    //}
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(str, conn);
                    sqlcom.ExecuteNonQuery();
                    sqlcom.Dispose();

                    conn.Close();
                    MessageBox.Show("报表生成成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报表生成失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("没有你要生成月份的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnBBDelete_Click(object sender, EventArgs e)
        {
            string sqlselect = "";

            sqlselect += " cadedate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "' AND SHOPID='" + CmdShop.SelectedValue.ToString() + "' and type='1'";
            try
            {
                SqlConnection conn = sqlcon.getcon("");
                conn.Open();
                SqlCommand sqlcom = new SqlCommand("delete from STR_GrossProfitGeneration where " + sqlselect, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                conn.Close();
                MessageBox.Show("报表删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("报表删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BtnYbbDelete_Click(object sender, EventArgs e)
        {
            string sqlselect = "";

            sqlselect += " cadedate Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + "' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + "' AND SHOPID='" + CmdShop.SelectedValue.ToString() + "' and type='2'";
            try
            {
                SqlConnection conn = sqlcon.getcon("");
                conn.Open();
                SqlCommand sqlcom = new SqlCommand("delete from STR_GrossProfitGeneration where " + sqlselect, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                conn.Close();
                MessageBox.Show("报表删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("报表删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BtnYjblCreate_Click(object sender, EventArgs e)
        {
            string sqlselect = "";

            sqlselect += " StopDate >='" + DTPStop.Value.ToString("yyyy-MM-dd") + "' AND SHOPID='" + CmdShop.SelectedValue.ToString() + "'  and type='1'";

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds1 = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_BlGrossProfitGeneration where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds1);
            conn.Close();
            if (ds1.Tables[0].Rows.Count > 1)
            {
                MessageBox.Show("\n该终止日期的数据已生成不能重新生成！！   \n\n\n    ", "系统提示");

                return;

            }
            if (ds1.Tables[0].Rows.Count == 1)
            {
                if (MessageBox.Show("\n该终止日期的数据已生成，是否从新生成   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_BlGrossProfitGeneration where " + sqlselect, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    return;
                }
            }
            string sqlstr = "select temp.shopID,ShopName,sumMoney,cost as costOFSales,isnull(BsumMoney,0) BsumMoney,isnull(tempb.Bcost,0) Bcost,round((isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08,2) as salesReturn,round((isnull(cost,0)-isnull(BCost,0))*0.08,2) as RturnCost," +
            "round(isnull(temp.sumMoney,0)-(isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08-isnull(tempb.BsumMoney,0),2) as actualSales,round(isnull(cost,0)-(isnull(cost,0)-isnull(BCost,0))*0.08-isnull(tempb.Bcost,0) ,2) as ActualCostOFSales," +
            "round((isnull(temp.sumMoney,0)-(isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08-isnull(tempb.BsumMoney,0))*0.39,2) OutLay," +
            "round(isnull(temp.sumMoney,0)-(isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08-isnull(tempb.BsumMoney,0),2)-round(isnull(cost,0)-(isnull(cost,0)-isnull(BCost,0))*0.08-isnull(tempb.Bcost,0) ,2)-round((isnull(temp.sumMoney,0)-(isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08-isnull(tempb.BsumMoney,0))*0.39,2) GrossProfit,customerUnit " +
            "from ( select shopID,sum(sumMoney) as summoney from STR_OrderList where  " +
            "cast(orderdate as datetime) Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' group by shopID) as temp " +
            "left join (select STR_OrderDetailList.shopiD,sum(cost*BuyNO) as cost from STR_OrderDetailList " +
            "left join STR_OrderList on STR_OrderDetailList.orderCade=STR_OrderList.ordercade " +
            "left join M_productCost on STR_OrderDetailList.pid=M_productCost.pid " +
            "where cast(orderdate as datetime) Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' group by STR_OrderDetailList.shopiD) as temps on temp.shopID=temps.shopID " +
            "left join (select sum(sumMoney) as BsumMoney,sum(cost*Qty) as Bcost,shopID from STR_BrushSingleData left join M_productCost on M_productCost.pid=STR_BrushSingleData.pid " +
            "where CadeDate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' group by shopID ) as tempb on temp.shopID=tempb.shopID " +
            "left join (select shopID,round(sum(sumMoney)*0.03,0) as TurnFeededuction from STR_OrderList where  " +
            "cast(orderdate as datetime) Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and (BobyName like '%【聚】%' or BobyName like '%.%' or BobyName like '%。%' or BobyName like '%`%') group by shopID) as temptemp " +
            "on temptemp.shopID=temp.shopID " +
            "left join STR_Shop on STR_Shop.id=temp.shopID " +
            "left join ( " +
            "select shopid,sum(Case when Weight>1 then FirstHeavy+continuedHeavy*FLOOR(Weight) else FirstHeavy end) as Express " +
            "from (select STR_OrderDetailList.shopID,VipAdd,STR_OrderList.orderCade,sum(Weight) as Weight," +
            "case when isnull(ExpressName,'')!='' then ExpressName when isnull(ExpressName,'')='' and isnull(Remarks,'')!='' and Remarks not like '%''[已下载，时间' then Remarks else '韵达' end ExpressName from STR_OrderDetailList " +
            "left join STR_OrderList on STR_OrderList.ordercade=STR_OrderDetailList.ordercade " +
            "left join STR_ProductWeight on STR_ProductWeight.pid=STR_OrderDetailList.pid and " +
            "STR_ProductWeight.SDid=STR_OrderDetailList.SDID " +
            "where cast(orderdate as datetime) Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' " +
            "group by STR_OrderDetailList.shopID,VipAdd,STR_OrderList.orderCade,ExpressName,Remarks) temp left join STR_ExpressSET on temp.VipAdd like ''+STR_ExpressSET.Eadd+'%' and ExpressName like '%'+STR_ExpressSET.name+'%' group by shopID) " +
            "as tempExpress on tempExpress.shopid=temp.shopID " +
            "left join (select shopID,sum(sumMoney) as customerUnit from STR_itemDBO where  CadeDate " +
            "Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='4' group by shopID) as tempitem4 on tempitem4.shopid=temp.shopId " +
            "where temp.shopid='" + CmdShop.SelectedValue.ToString() + "'";
          
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "DS");
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string str = " insert into STR_BlGrossProfitGeneration (Cade,CadeDATE,StartDate,StopDate,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,ActualSales," +
                        "ActualCostOFSales,OutLay,GrossProfit,customerUnit,ShopID,type,username) values ('"
                            + "ML" + DTPCadeDate.Value.ToString("yyyyMMdd") +
                            datec.uppacking("STR_GrossProfitGeneration", DTPCadeDate.Value.ToString("yyyyMMdd")) + "','"
                            + this.DTPCadeDate.Value.ToString("yyyy-MM-dd") + "','"
                            + DTPStart.Value.ToString("yyyy-MM-dd") + "','"
                            + DTPStop.Value.ToString("yyyy-MM-dd") + "','"
                            + DTPStart.Value.ToString("yyyy-MM-dd") + "至" + DTPStop.Value.ToString("yyyy-MM-dd") + "','"
                            + ds.Tables["DS"].Rows[0]["sumMoney"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["CostOFSales"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["BsumMoney"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Bcost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["SalesReturn"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["RturnCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ActualSales"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ActualCostOFSales"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["OutLay"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["GrossProfit"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["customerUnit"].ToString() + "','"
                            + CmdShop.SelectedValue.ToString() + "','1','"
                            + frmlogin.userID + "')  ";
                    //}
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(str, conn);
                    sqlcom.ExecuteNonQuery();
                    sqlcom.Dispose();

                    conn.Close();
                    MessageBox.Show("报表生成成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报表生成失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("没有你要生成月份的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnYjblDelete_Click(object sender, EventArgs e)
        {
            string sqlselect = "";

            sqlselect += " cadedate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "' AND SHOPID='" + CmdShop.SelectedValue.ToString() + "' and type='1'";
            try
            {
                SqlConnection conn = sqlcon.getcon("");
                conn.Open();
                SqlCommand sqlcom = new SqlCommand("delete from STR_BlGrossProfitGeneration where " + sqlselect, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                conn.Close();
                MessageBox.Show("报表删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("报表删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void BtnSjBlCreate_Click(object sender, EventArgs e)
        {
            string sqlselect = "";

            sqlselect += " StopDate >='" + DtpActualStart.Value.ToString("yyyy-MM-dd") + "' AND SHOPID='" + CmdShop.SelectedValue.ToString() + "' and type='2'";

            SqlConnection conn = sqlcon.getcon("");
            DataSet ds1 = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from STR_BlGrossProfitGeneration where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds1);
            conn.Close();
            if (ds1.Tables[0].Rows.Count > 1)
            {
                MessageBox.Show("\n该终止日期的数据已生成不能重新生成！！   \n\n\n    ", "系统提示");

                return;

            }
            if (ds1.Tables[0].Rows.Count == 1)
            {
                if (MessageBox.Show("\n该终止日期的数据已生成，是否从新生成   \n\n\n    ", "系统提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from STR_BlGrossProfitGeneration where " + sqlselect, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                else
                {
                    return;
                }
            }
            string sqlstr = "select temp.shopID,ShopName,sumMoney,cost as costOFSales,isnull(BsumMoney,0) BsumMoney,isnull(tempb.Bcost,0) Bcost,0 as salesReturn,0 as RturnCost," +
            "round(isnull(temp.sumMoney,0)-0-isnull(tempb.BsumMoney,0),2) as actualSales,round(isnull(cost,0)-0-isnull(tempb.Bcost,0) ,2) as ActualCostOFSales,"+
                       "round((isnull(temp.sumMoney,0)-(isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08-isnull(tempb.BsumMoney,0))*0.39,2) OutLay," +
            "round(isnull(temp.sumMoney,0)-(isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08-isnull(tempb.BsumMoney,0),2)-round(isnull(cost,0)-(isnull(cost,0)-isnull(BCost,0))*0.08-isnull(tempb.Bcost,0) ,2)-round((isnull(temp.sumMoney,0)-(isnull(sumMoney,0)-isnull(BsumMoney,0))*0.08-isnull(tempb.BsumMoney,0))*0.39,2) GrossProfit,customerUnit " +
            "from ( select shopID,sum(sumMoney) as summoney from Str_ActualOrderList where  " +
            "cast(orderdate as datetime) Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' group by shopID) as temp " +
            "left join (select Str_ActualOrderDetailList.shopiD,sum(cost*BuyNO) as cost from Str_ActualOrderDetailList " +
            "left join Str_ActualOrderList on Str_ActualOrderDetailList.orderCade=Str_ActualOrderList.ordercade " +
            "left join M_productCost on Str_ActualOrderDetailList.pid=M_productCost.pid " +
            "where cast(orderdate as datetime) Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + "  23:59:59.000' group by Str_ActualOrderDetailList.shopiD) as temps on temp.shopID=temps.shopID " +
            "left join (select sum(sumMoney) as BsumMoney,sum(cost*Qty) as Bcost,shopID from STR_BrushSingleData left join M_productCost on M_productCost.pid=STR_BrushSingleData.pid " +
            "where CadeDate Between '" + DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + DtpActualStop.Value.ToString("yyyy-MM-dd") + "  23:59:59.000' group by shopID ) as tempb on temp.shopID=tempb.shopID " +
            "left join (select shopID,round(sum(sumMoney)*0.03,0) as TurnFeededuction from Str_ActualOrderList where  " +
            "cast(orderdate as datetime) Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and (BobyName like '%【聚】%' or BobyName like '%.%' or BobyName like '%。%' or BobyName like '%`%') group by shopID) as temptemp " +
            "on temptemp.shopID=temp.shopID " +
            "left join STR_Shop on STR_Shop.id=temp.shopID " +
            "left join ( " +
            "select shopid,sum(Case when Weight>1 then FirstHeavy+continuedHeavy*FLOOR(Weight) else FirstHeavy end) as Express " +
            "from (select Str_ActualOrderDetailList.shopID,VipAdd,Str_ActualOrderList.orderCade,sum(Weight) as Weight," +
            "case when isnull(ExpressName,'')!='' then ExpressName when isnull(ExpressName,'')='' and isnull(Remarks,'')!='' and Remarks not like '%''[已下载，时间' then Remarks else '韵达' end ExpressName from Str_ActualOrderDetailList " +
            "left join Str_ActualOrderList on Str_ActualOrderList.ordercade=Str_ActualOrderDetailList.ordercade " +
            "left join STR_ProductWeight on STR_ProductWeight.pid=Str_ActualOrderDetailList.pid and " +
            "STR_ProductWeight.SDid=Str_ActualOrderDetailList.SDID " +
            "where cast(orderdate as datetime) Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' " +
            "group by Str_ActualOrderDetailList.shopID,VipAdd,Str_ActualOrderList.orderCade,ExpressName,Remarks) temp left join STR_ExpressSET on temp.VipAdd like ''+STR_ExpressSET.Eadd+'%' and ExpressName like '%'+STR_ExpressSET.name+'%' group by shopID) " +
            "as tempExpress on tempExpress.shopid=temp.shopID " +
            "left join (select shopID,sum(sumMoney) as customerUnit from STR_itemDBO where  CadeDate " +
            "Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + " 00:00:00.000' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + " 23:59:59.000' and itemID='4' group by shopID) as tempitem4 on tempitem4.shopid=temp.shopId " +
            "where temp.shopid='" + CmdShop.SelectedValue.ToString() + "'";
            //"left join (select shopID,round(sum(photographmoney)/sum(photographno),2) as customerUnit from STR_CustomerUnit where not exists(select * from STR_CustomerUnitset where STR_CustomerUnitset.name=STR_CustomerUnit.name) and "+
            //"CadeDate Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "' group by shopID )as tempCustomerUnit on tempCustomerUnit.shopID=temp.shopID "+



            SqlDataAdapter sqlDaper1 = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper1.Fill(ds, "DS");
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string str = " insert into STR_BlGrossProfitGeneration (Cade,CadeDATE,StartDate,StopDate,PeriodDate,Sales,CostOFSales,BsumMoney,Bcost,SalesReturn,RturnCost,ActualSales," +
                        "ActualCostOFSales,OutLay,GrossProfit,customerUnit,ShopID,type,username) values ('"
                            + "ML" + this.DtpActualCadeDate.Value.ToString("yyyyMMdd") +
                            datec.uppacking("STR_GrossProfitGeneration", DtpActualCadeDate.Value.ToString("yyyyMMdd")) + "','"
                            + this.DtpActualCadeDate.Value.ToString("yyyy-MM-dd") + "','"
                            + DtpActualStart.Value.ToString("yyyy-MM-dd") + "','"
                            + DtpActualStop.Value.ToString("yyyy-MM-dd") + "','"
                            + DtpActualStart.Value.ToString("yyyy-MM-dd") + "至" + DtpActualStop.Value.ToString("yyyy-MM-dd") + "','"
                            + ds.Tables["DS"].Rows[0]["sumMoney"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["CostOFSales"].ToString() + "','"
                             + ds.Tables["DS"].Rows[0]["BsumMoney"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["Bcost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["SalesReturn"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["RturnCost"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ActualSales"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["ActualCostOFSales"].ToString() + "','"
                             + ds.Tables["DS"].Rows[0]["OutLay"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["GrossProfit"].ToString() + "','"
                            + ds.Tables["DS"].Rows[0]["customerUnit"].ToString() + "','"
                            + CmdShop.SelectedValue.ToString() + "','2','"
                            + frmlogin.userID + "')  ";
                    //}
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(str, conn);
                    sqlcom.ExecuteNonQuery();
                    sqlcom.Dispose();

                    conn.Close();
                    MessageBox.Show("报表生成成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("报表生成失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("没有你要生成月份的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnSjblDelete_Click(object sender, EventArgs e)
        {
            string sqlselect = "";

            sqlselect += " cadedate Between '" + this.DtpActualStart.Value.ToString("yyyy-MM-dd") + "' and '" + this.DtpActualStop.Value.ToString("yyyy-MM-dd") + "' AND SHOPID='" + CmdShop.SelectedValue.ToString() + "' and type='2'";
            try
            {
                SqlConnection conn = sqlcon.getcon("");
                conn.Open();
                SqlCommand sqlcom = new SqlCommand("delete from STR_BlGrossProfitGeneration where " + sqlselect, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                conn.Close();
                MessageBox.Show("报表删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("报表删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

    }
}
