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
    public partial class OutRuturnNOinforMation : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        private ComboBox cmb_Express = new ComboBox();
        private int comboBoxEpess = 2; // DataGridView的首列
        private string Rows;
        public OutRuturnNOinforMation(string rows)
        {
            InitializeComponent();
            InitComboBoxValues();
            cmb_Express.Visible = false;
            Rows = rows;
           
            this.DataDGV.Controls.Add(cmb_Express);
            this.DataDGV.CellEnter += new DataGridViewCellEventHandler(DataDGV_CellEnter);
            this.DataDGV.CellLeave += new DataGridViewCellEventHandler(DataDGV_CellLeave);
        }

        private void OutRuturnNOinforMation_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT ID,ShopName,ExpressName,"+
                "ExpressBarCode,Mobile,OrderCade,BarCode,Remarks2,Weat,Quality,type from CS_OutRuturnNOinforMation where ExpressBarCode='" + Rows + "' ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper.Fill(ds, "cs");
            conn.Close();
            DataDGV.DataSource = ds.Tables["cs"];
            DataDGV.Columns["ID"].Visible = false;
            DataDGV.Columns["type"].Visible = false;
           // DataDGV.Columns["OK"].HeaderText = "选择";
            DataDGV.Columns["Mobile"].HeaderText = "电话";
            DataDGV.Columns["BarCode"].HeaderText = "货品条码";
            DataDGV.Columns["ShopName"].HeaderText = "店铺";
            DataDGV.Columns["OrderCade"].HeaderText = "网络订单";
            //DataDGV.Columns["NBarCode"].HeaderText = "换货条码";
            DataDGV.Columns["Weat"].HeaderText = "是否穿过";
            DataDGV.Columns["Quality"].HeaderText = "是否质量问题";
            DataDGV.Columns["ExpressName"].HeaderText = "退回快递公司";
            DataDGV.Columns["ExpressBarCode"].HeaderText = "退回快递单号";
            DataDGV.Columns["Remarks2"].HeaderText = "问题处理";
            DataDGV.Columns["Remarks2"].Width = 200;

            if (Rows == "")
            {
                this.Text = "售后登记！！";
            }
            else
            {
                this.Text = "售后修改！！";
            }
        }

        private void InitComboBoxValues()
        {
            this.cmb_Express.Items.AddRange(new String[] { "韵达","圆通","中通", "申通","顺丰","EMS","天天","全峰","百世",
                "国通","快捷","优速","速尔","宅急送","信丰","中国邮政","龙邦","京东"  });
            this.cmb_Express.AutoCompleteMode = AutoCompleteMode.Suggest; //输入提示
            this.cmb_Express.AutoCompleteSource = AutoCompleteSource.ListItems;

        }

        private void DataDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == comboBoxEpess)
            {
                //此处cell即CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Rectangle rect = this.DataDGV.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                this.cmb_Express.Location = rect.Location;
                this.cmb_Express.Size = rect.Size;
                comfirmComboBoxValue(this.cmb_Express, (String)cell.Value.ToString());
                this.cmb_Express.Visible = true;
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
        private void DataDGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == comboBoxEpess)
            {
                //此处cell不为CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = this.cmb_Express.Text;
                this.cmb_Express.Visible = false;
            }
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strsql = "";
            for (int i = 0; i < DataDGV.Rows.Count - 1; i++)
            {

                SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from CS_OutRuturnNOinforMation where ExpressBarCode='" + DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString() + "' and ExpressBarCode !='" + Rows + "'", conn);
                DataSet ds = new DataSet();
                conn.Open();
                sqlDaper.Fill(ds, "cs");
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("订单号：" + DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString() + " 已存在不能保存！！");
                }
                else
                {
                    if (DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString() == "")
                    {
                        MessageBox.Show("快递单为空,不能保存！");
                        return;
                    }
                    if (DataDGV.Rows[i].Cells["ID"].Value.ToString() != "")
                    {

                        strsql += "update CS_OutRuturnNOinforMation set ExpressName='" + DataDGV.Rows[i].Cells["ExpressName"].Value.ToString() +
                            "',ExpressBarCode='" + DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString() +
                             "',Mobile='" + DataDGV.Rows[i].Cells["Mobile"].Value.ToString() +
                              "',ShopName='" + DataDGV.Rows[i].Cells["ShopName"].Value.ToString() +
                             "',OrderCade='" + DataDGV.Rows[i].Cells["OrderCade"].Value.ToString() +
                             "',BarCode='" + DataDGV.Rows[i].Cells["BarCode"].Value.ToString() +
                             "',Remarks2='" + DataDGV.Rows[i].Cells["Remarks2"].Value.ToString() +
                             "',Weat='" + DataDGV.Rows[i].Cells["Weat"].Value.ToString() +
                             "',Type='" + DataDGV.Rows[i].Cells["Type"].Value.ToString() +
                             "',Quality='" + DataDGV.Rows[i].Cells["Quality"].Value.ToString() + "' where ID='" + DataDGV.Rows[i].Cells["ID"].Value.ToString() + "';";
                    }
                    else
                    {
                        strsql += "insert into CS_OutRuturnNOinforMation(ExpressName,ShopName,ExpressBarCode,Mobile,OrderCade,BarCode,Remarks2,Weat,Quality,CadeDate,UserName,Type)values('"
                            + DataDGV.Rows[i].Cells["ExpressName"].Value.ToString() + "','"
                            + DataDGV.Rows[i].Cells["ShopName"].Value.ToString() + "','"
                            + DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString() + "','"
                            + DataDGV.Rows[i].Cells["Mobile"].Value.ToString() + "','"
                            + DataDGV.Rows[i].Cells["OrderCade"].Value.ToString() + "','"
                            + DataDGV.Rows[i].Cells["BarCode"].Value.ToString() + "','"
                            + DataDGV.Rows[i].Cells["Remarks2"].Value.ToString() + "','"
                            + DataDGV.Rows[i].Cells["Weat"].Value.ToString() + "','"
                            + DataDGV.Rows[i].Cells["Quality"].Value.ToString() + "','"
                            +DateTime.Now.ToString("yyyy-MM-dd")+"','"
                            + frmlogin.userID + "','1');";
                    }
                }
            }
            if (strsql == "")
            {
                MessageBox.Show("没有你要保存的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                conn.Open();
                SqlCommand sqlcom = new SqlCommand(strsql, conn);
                sqlcom.ExecuteNonQuery();
                conn.Close();
                sqlcom.Dispose();

                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //if (Rows != "")
            //{
            //    this.Close();
            //}
            //else
            //{
                OutRuturnNOinforMation_Load(sender, e);
            //}
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.DataDGV.SelectedRows.Count > 0)
            {
                DataRowView drv = DataDGV.SelectedRows[0].DataBoundItem as DataRowView;
                drv.Delete();
            }
        }
    }
}
