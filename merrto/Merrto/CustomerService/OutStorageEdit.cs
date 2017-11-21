using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.CustomerService
{
    public partial class OutStorageEdit : Form
    {
        // 定义下拉列表框
        private ComboBox cmb_Temp = new ComboBox();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        baseclass.SelectDate sd = new baseclass.SelectDate();
        baseclass.SendSMS SMS = new baseclass.SendSMS();
        private string Rows = "";
        private int Brow = 0;//查看
        private int comboBoxName = 10; // DataGridView的首列
        public OutStorageEdit(string rows, int BROW)
        {
            InitializeComponent();
            InitComboBoxValues();
            Rows = rows;
            Brow = BROW;
            cmb_Temp.Visible = false;
            this.DataDGV.Controls.Add(cmb_Temp);
            this.DataDGV.CellEnter += new DataGridViewCellEventHandler(DataDGV_CellEnter);
            this.DataDGV.CellLeave += new DataGridViewCellEventHandler(DataDGV_CellLeave);
        }

        private void OutStorageEdit_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT ID,ShopName,CadeType,VipName,Mobile,OrderCade,BarCode,NBarCode,Remarks," +
                "Reason,NExpressName,NExpressBarCode,type from CS_OutRuturnStorage where  OrderCade='" + Rows + "' and type='6' ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper.Fill(ds, "cs");
            conn.Close();
            DataDGV.DataSource = ds.Tables["cs"];
            DataDGV.Columns["ID"].Visible = false;
            DataDGV.Columns["ShopName"].HeaderText = "店铺";
            DataDGV.Columns["ShopName"].ReadOnly = true;
            DataDGV.Columns["VipName"].HeaderText = "会员";
            DataDGV.Columns["VipName"].ReadOnly = true;
            DataDGV.Columns["CadeType"].HeaderText = "状态";
            DataDGV.Columns["CadeType"].ReadOnly = true;
            DataDGV.Columns["Mobile"].HeaderText = "电话";
            DataDGV.Columns["Mobile"].ReadOnly = true;
            DataDGV.Columns["OrderCade"].HeaderText = "订单";
            DataDGV.Columns["OrderCade"].ReadOnly = true;
            DataDGV.Columns["BarCode"].HeaderText = "退货条码";
            DataDGV.Columns["BarCode"].ReadOnly = true;
            DataDGV.Columns["NBarCode"].HeaderText = "换货条码";
            DataDGV.Columns["NBarCode"].ReadOnly = true;
            DataDGV.Columns["NExpressName"].HeaderText = "发出快递公司";
            DataDGV.Columns["NExpressBarCode"].HeaderText = "发出快递单号";
            DataDGV.Columns["Remarks"].HeaderText = "问题处理";
            DataDGV.Columns["Remarks"].ReadOnly = true;
            DataDGV.Columns["Type"].Visible = false;

            if (Rows == "")
            {
                this.Text = "售后登记！！";
            }
            else
            {
                this.Text = "售后修改！！";
            }
            if (Brow == 0)
            {
                BtnSave.Enabled = false;
            }
        }
       
        private void InitComboBoxValues()
        {
            this.cmb_Temp.Items.AddRange(new String[] { "顺丰", "圆通", "中通", "申通","韵达","天天","EMS","全峰","百世",
                "国通","快捷","优速","速尔","宅急送","信丰" });
            this.cmb_Temp.AutoCompleteMode = AutoCompleteMode.Suggest; //输入提示
            this.cmb_Temp.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void DataDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == comboBoxName)
            {
                //此处cell即CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Rectangle rect = this.DataDGV.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                this.cmb_Temp.Location = rect.Location;
                this.cmb_Temp.Size = rect.Size;
                comfirmComboBoxValue(this.cmb_Temp, (String)cell.Value.ToString());
                this.cmb_Temp.Visible = true;
            }
        }

        private void DataDGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == comboBoxName)
            {
                //此处cell不为CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = this.cmb_Temp.Text;
                this.cmb_Temp.Visible = false;
            }
        }

        private void comfirmComboBoxValue(ComboBox com, String cellValue)
        {
            com.SelectedIndex = -1;
            if (cellValue == null)
            {
                com.Text = "";
                return;
            }
            com.Text = cellValue;
            foreach (Object item in com.Items)
            {
                if ((String)item == cellValue)
                {
                    com.SelectedItem = item;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "";
            for (int i = 0; i < DataDGV.Rows.Count; i++)
            {
                string type = "";
                if (DataDGV.Rows[i].Cells["NExpressBarCode"].Value.ToString() != "")
                {
                    type = "4";
                }
                else {
                    type = DataDGV.Rows[i].Cells["Type"].Value.ToString();
                }
                if (DataDGV.Rows[i].Cells["ID"].Value.ToString() != "")
                {
                    strsql += "update CS_OutRuturnStorage set NExpressName='" + DataDGV.Rows[i].Cells["NExpressName"].Value.ToString() +
                         "',NExpressBarCode='" + DataDGV.Rows[i].Cells["NExpressBarCode"].Value.ToString() + 
                         "',Type='" +type + "' where ID='" + DataDGV.Rows[i].Cells["ID"].Value.ToString() + "';";
                }
                
            }
            conn.Open();
            SqlCommand sqlcom = new SqlCommand(strsql, conn);
            sqlcom.ExecuteNonQuery();
            conn.Close();
            sqlcom.Dispose();
            if (DataDGV.Rows.Count > 0)
            {
               SqlDataAdapter sqldaper2 = new SqlDataAdapter("select * from M_ShortMessage", conn);
                
                DataSet ds = new DataSet();
                conn.Open();
                sqldaper2.Fill(ds, "MSM");
                conn.Close();
                if (ds.Tables["MSM"].Rows[0]["Type"].ToString() == "True")
                {
                    SMS.GETpost("ac=send&uid=" + ds.Tables["MSM"].Rows[0]["UserName"].ToString() +
                        "&pwd=" + ds.Tables["MSM"].Rows[0]["PWD"].ToString() + "&mobile=" + DataDGV.Rows[0].Cells["Mobile"].Value.ToString() +
                        "&content=", ds.Tables["MSM"].Rows[0]["IPAdd"].ToString(), "您换货已发:" + DataDGV.Rows[0].Cells["NExpressName"].Value.ToString() +
                        "单号:" + DataDGV.Rows[0].Cells["NExpressBarCode"].Value.ToString() + ",请注意签收,如疑问联系:18900339706." + DateTime.Now.ToString("MM") + "月" + DateTime.Now.ToString("dd") + "日&encode=utf8");
                    ///http://api.cnsms.cn/?ac=send&uid=100860&pwd=fa246d0262c3925617b0c72bb20eeb1d&mobile=15102110086,18297974783&content=%D6%D0%B9%FA%B6%CC%D0%C5%CD%F8%B7%A2%CB%CD%B2%E2%CA%D4
                }
            }
            MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Rows != "")
            {
                this.Close();
            }
        }

       
    }
}
