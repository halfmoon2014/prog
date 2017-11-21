using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace Merrto
{
    public partial class prtintform : Form
    {
        string barcode;
        int Sizelong;
        int Nomber;
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();

        public prtintform(string route, string BarCode, int sizelong, int nomber)
        {
            InitializeComponent();
            openFileName = route;
            barcode = BarCode;
            Sizelong = sizelong;
            Nomber = nomber;
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT ITEM_NO as Item,S_COLOR as Color,CO_CODE as Code,'" + barcode + "' as Barcode,'"
                + barcode.Substring(barcode.Length - Sizelong, Sizelong) + "' as Size,'" + Nomber + "' as Nomber FROM m_product LEFT JOIN m_ProductSub ON m_ProductSub.PID=m_product.ID where ITEM_NO+cast(CO_CODE as varchar(5))='" +
                barcode.Substring(0, barcode.Length - Sizelong) + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                //dsgname.DataSource = ds.Tables[0];
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 获取design的宽和高
        /// </summary>
        /// 
        private string openFileName = "";
        /// <summary>
        /// 设计器是对像删除事件


        private void prtintform_Load(object sender, EventArgs e)
        {
            //bool open = InOutPut.OpenFile(dsgname, openFileName);
            //打开文件是否成功
            //如果打开成功是重新绘标尺
            //if (open)
            //{
            //    panel1.Refresh();
            //}
            DataTable dt = new DataTable();
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT ITEM_NO as Item,S_COLOR as Color,CO_CODE as Code,'" + barcode + "' as Barcode,'"
                + barcode.Substring(barcode.Length - Sizelong, Sizelong) + "' as Size,'" + Nomber + "' as Nomber FROM m_product LEFT JOIN m_ProductSub ON m_ProductSub.PID=m_product.ID where ITEM_NO+cast(CO_CODE as varchar(5))='" +
                barcode.Substring(0, barcode.Length - Sizelong) + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //dsgname.DataSource = ds.Tables[0];
        }

        private void tsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "SELECT ITEM_NO as Item,S_COLOR as Color,CO_CODE as Code,'" + barcode + "' as Barcode,'"
                + barcode.Substring(barcode.Length - Sizelong, Sizelong) + "' as Size,'" + Nomber + "' as Nomber FROM m_product LEFT JOIN m_ProductSub ON m_ProductSub.PID=m_product.ID where ITEM_NO+cast(CO_CODE as varchar(5))='" +
                barcode.Substring(0, barcode.Length - Sizelong) + "'";
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                sqlDaper.Fill(ds);
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //dsgname.DataSource = ds.Tables[0];
            //dsgname.PrintPage(1);
        }
    }
}
