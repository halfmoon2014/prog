using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.SingleSupplement
{
    public partial class TheSalesRate : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public TheSalesRate(string StrDate, int days)
        {
            InitializeComponent();
            SqlConnection conn = sqlcon.getcon("Wei");
            DataSet ds = new DataSet();
            string strsql = " select temp.fName,Qty,speed from (select FName,round(sum(fQty)/"+days+",0) Qty from T_CC_StockBillEntry left join t_ICItem on t_ICItem.fitemid=T_CC_StockBillEntry.FitemID where exists(select * from T_CC_StockBill where T_CC_StockBillEntry.fid=T_CC_StockBill.fid and  FBillNo like 'XSD%' and " + StrDate + ") group by FName) temp "+
                "left join (SELECT * from OPENROWSET('SQLOLEDB', 'server=192.168.0.177,1488;uid=sa;pwd=mt123','SELECT * FROM [M_sentu].dbo.SS_SalesRate'))temp2 "+
                "on temp2.fname=temp.Fname";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            
            conn.Open();
            sqlDaper.Fill(ds, "xsd");
            conn.Close();
            DGVData.DataSource = ds.Tables["xsd"];
            DGVData.Columns["FName"].HeaderText = "品名";
            DGVData.Columns["FName"].ReadOnly =true;
            DGVData.Columns["Qty"].HeaderText = "销售速度";
            DGVData.Columns["Qty"].ReadOnly = true;
            DGVData.Columns["speed"].HeaderText = "销售速度";
            DGVData.Columns["speed"].ReadOnly = false;
        }

        private void TheSalesRate_Load(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            string sqlselect = "";
            for (int i = 0; i < DGVData.Rows.Count; i++)//得到总行数并在之内循环
            {
                if (sqlselect != "")
                {
                    sqlselect += " or ";
                }
                sqlselect += " Fname ='" + DGVData.Rows[i].Cells["Fname"].Value.ToString() + "'";
            }
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from SS_SalesRate where " + sqlselect, conn);
            conn.Open();
            sqlDaper.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from SS_SalesRate where " + sqlselect, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

            }

            string strsql = "";
            try
            {
                for (int i = 0; i < DGVData.Rows.Count; i++)//得到总行数并在之内循环
                {

                    if (DGVData.Rows[i].Cells["speed"].Value.ToString() != "")
                    {
                        strsql += "insert into SS_SalesRate (FName,speed) values ('"
                            + DGVData.Rows[i].Cells["FName"].Value.ToString() + "','"
                            + DGVData.Rows[i].Cells["speed"].Value.ToString() + "');";
                    }//
                }

                conn.Open();
                strsql = strsql.Replace("'", "''");
                strsql = strsql.Replace("'',''", "','");
                strsql = strsql.Replace("(''", "('");
                strsql = strsql.Replace("'')", "')");
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
