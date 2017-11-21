using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.WPH
{
    public partial class WphTheRetreat : Form
    {
        baseclass.ExcelData exceld = new baseclass.ExcelData();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public WphTheRetreat()
        {
            InitializeComponent();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            string path = System.Environment.CurrentDirectory;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Excel文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ofd.Filter = "Excel文件(*.xls)|*.xls";
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;

            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
            }

            if (strName == "")
            {
                MessageBox.Show("没有选择Excel文件，无法导入");
                return;
            }

            exceld.ExcelToDataGridView(strName, this.ExcelDGV);
            //ComboBox cbx = new ComboBox();

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DataSave();
        }
        private void DataSave()
        {
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            string strsql = "";
            try
            {
                for (int i = 0; i < ExcelDGV.Rows.Count; i++)//得到总行数并在之内循环
                {
                    if (ExcelDGV.Rows[i].Cells["数量"].Value.ToString() != "")
                    {
                        strsql += "insert into Wph_TheRetreat (Cade,BarCode,NO,po,Verify) values ('"
                            + ExcelDGV.Rows[i].Cells["箱号"].Value.ToString() + "','"
                            + ExcelDGV.Rows[i].Cells["商品条码"].Value.ToString() + "','"
                            + ExcelDGV.Rows[i].Cells["数量"].Value.ToString() + "','"
                            + ExcelDGV.Rows[i].Cells["箱号"].Value.ToString().Substring(4,10) + "','0') ;";
                    }
                }
                conn.Open();
                SqlCommand cmd = new SqlCommand(strsql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("数据更新成功！", "系统提示：", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
