using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto
{
    public partial class WPhProductEdit : Form
    {
        private int RowsID,save_;
        private string Cid;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WPhProductEdit(int rows,string cid)
        {
            InitializeComponent();
            RowsID = rows;
            Cid = cid;
        }

        private void WPhProductEdit_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "select Name,ID from WPh_Category";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                this.CmdCategory.DataSource = ds.Tables[0];
                this.CmdCategory.ValueMember = "ID";
                this.CmdCategory.DisplayMember = "Name";
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            if (RowsID != 0)
            {
                this.Text = "唯品汇档案修改";
                //int row = ;//得到总行数
                //SqlConnection conn = sqlcon.getcon("");
                string rolestr = "select m_Product.id as pid,cid,item_no,co_code,s_color,Wph_Item,PRICE_TAG,year,WPh_Category.name as Cname,pname,sdprice,class from m_Product" +
                " left join Wph_Product on Wph_Product.pid=m_Product.id " +
                " left join WPh_Category on Wph_Product.cid=WPh_Category.id where m_Product.id='" + RowsID + "' and co_code='" + Cid + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                this.TxtName.Text = sizeds.Tables[0].Rows[0]["pname"].ToString();
                this.TxtProduect.Text = sizeds.Tables[0].Rows[0]["Item_no"].ToString();
                if (sizeds.Tables[0].Rows[0]["Wph_Item"].ToString() == "")
                {
                    this.TXTWph_Item.Text = sizeds.Tables[0].Rows[0]["Item_no"].ToString();
                }else
                {
                    this.TXTWph_Item.Text = sizeds.Tables[0].Rows[0]["Wph_Item"].ToString();
                }
                TXTCo_Cade.Text = sizeds.Tables[0].Rows[0]["co_code"].ToString();
                Txts_colour.Text = sizeds.Tables[0].Rows[0]["s_color"].ToString();
                this.TxtYear.Text = sizeds.Tables[0].Rows[0]["year"].ToString();
                this.Txtsdprice.Text = sizeds.Tables[0].Rows[0]["sdprice"].ToString();
                this.TxtClass.Text = sizeds.Tables[0].Rows[0]["class"].ToString();
                if(sizeds.Tables[0].Rows[0]["cid"].ToString()!="")
                {
                    this.CmdCategory.SelectedValue = sizeds.Tables[0].Rows[0]["cid"].ToString();
                }
                this.CmdCategory.Text = sizeds.Tables[0].Rows[0]["Cname"].ToString();
                save_ = 1;
            }
            else
            {
                string rolestr = "select item_no from m_Product where m_Product.id='" + RowsID + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                conn.Close();
                this.TXTWph_Item.Text = sizeds.Tables[0].Rows[0]["Item_no"].ToString();
                this.Text = "唯品汇档案补充";
                save_ = 0;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string str;
                SqlDataAdapter sqlroleda = new SqlDataAdapter("select * from Wph_Product where pid='" + RowsID + "' and co_code='"+TXTCo_Cade.Text.ToString()+"'", conn);
                DataSet sizeds = new DataSet();
                conn.Open();
                sqlroleda.Fill(sizeds);
                if (sizeds.Tables[0].Rows.Count > 0)
                {
                    str = "update Wph_Product set cid='" + CmdCategory.SelectedValue.ToString() +
                                               "', pname='" + this.TxtName.Text +
                                               "', year='" + this.TxtYear.Text +
                                               "', sdprice='" + this.Txtsdprice.Text +
                                               "', class='" + this.TxtClass.Text +
                                               "', Wph_Item='" + this.TXTWph_Item.Text +
                                               "' where  pid='" + RowsID + "' and co_code='" + TXTCo_Cade.Text.ToString() + "'";
                    save_ = 1;
                }
                else
                {
                    str = " insert into Wph_Product (pid,cid,pname,year,sdprice,class,Wph_Item) values ('"
                        + RowsID + "','" + CmdCategory.SelectedValue.ToString() +
                        "','" + this.TxtName.Text + "','" + this.Txtsdprice.Text +
                        "','" + this.Txtsdprice.Text + "','" + this.TxtClass.Text + "','" + this.TXTWph_Item.Text +"')  ";
                    save_ = 0;
                }
                conn.Close();
                //select m_Product.id as pid,cid,item_no,PRICE_TAG,year,WPh_Category.name as Cname,pname,sdprice,class 

                conn.Open();
                SqlCommand sqlcom = new SqlCommand(str, conn);
                sqlcom.ExecuteNonQuery();
                sqlcom.Dispose();
                this.TxtName.Text = "";
                conn.Close();
                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnClose_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
