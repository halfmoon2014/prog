using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Net;


namespace Merrto.CustomerService
{
    public partial class OutRuturnStorageEDIT : Form
    {
        // 定义下拉列表框
        private ComboBox cmb_Temp = new ComboBox();
        private ComboBox cmb_Express = new ComboBox();
        private ComboBox cmb_ShopName = new ComboBox();
        private ComboBox cmb_CadeType = new ComboBox();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        baseclass.SelectDate sd = new baseclass.SelectDate();
        private string Rows = "";
        private int Brow = 0;//查看
        private int comboBoxShopName = 1; // DataGridView的首列
        private int comboBoxCadeType = 2; // DataGridView的首列
        private int comboBoxColumnIndex = 8; // DataGridView的首列
        private int comboBoxEpess2 = 11; // DataGridView的首列
        private int comboBoxEpess = 12; // DataGridView的首列
        //private int comboBoxNEpess = 11; // DataGridView的首列
        public OutRuturnStorageEDIT(string rows, int BROW)
        {
            InitializeComponent();
            InitComboBoxValues();
            Rows = rows;
            Brow = BROW;
            cmb_Temp.Visible = false;
            cmb_Express.Visible = false;
            cmb_ShopName.Visible = false;
            cmb_CadeType.Visible = false;
            
            this.DataDGV.Controls.Add(cmb_Temp);
            this.DataDGV.Controls.Add(cmb_Express);
            this.DataDGV.Controls.Add(cmb_CadeType);
            this.DataDGV.Controls.Add(cmb_ShopName);
            this.DataDGV.CellEnter += new DataGridViewCellEventHandler(DataDGV_CellEnter);
            this.DataDGV.CellLeave += new DataGridViewCellEventHandler(DataDGV_CellLeave);
            
        }

        private void OutRuturnStorageEDIT_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper = new SqlDataAdapter("SELECT ID,ShopName,CadeType,VipName,Mobile,OrderCade,BarCode,SumMOney,Reason,Remarks,Remarks2," +
                "NExpressName,ExpressName,ExpressBarCode,type,UserName,barCodeDate from CS_OutRuturnStorage where  OrderCade='" + Rows + "' ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper.Fill(ds, "cs");
            conn.Close();

            if (Rows == "")
            {
                for (int i = 0; i < 10; i++)
                {
                    ds.Tables["cs"].Rows.Add();
                }

            }
            DataDGV.DataSource = ds.Tables["cs"];
            DataDGV.Columns["ID"].Visible = false;
            DataDGV.Columns["ShopName"].HeaderText = "店铺";
            DataDGV.Columns["ShopName"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["ShopName"].Width = 150;
            DataDGV.Columns["VipName"].HeaderText = "会员";
            DataDGV.Columns["VipName"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["CadeType"].HeaderText = "类型";
            DataDGV.Columns["CadeType"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["CadeType"].Width=60;
            DataDGV.Columns["CadeType"].ReadOnly = true;
            DataDGV.Columns["Mobile"].HeaderText = "电话";
            DataDGV.Columns["Mobile"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["OrderCade"].HeaderText = "订单";
            DataDGV.Columns["OrderCade"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["SumMoney"].HeaderText = "金额";
            DataDGV.Columns["SumMoney"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["BarCode"].HeaderText = "条码";
            DataDGV.Columns["BarCode"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["Reason"].HeaderText = "原因";
            DataDGV.Columns["Reason"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["Remarks2"].Width = 150;
            DataDGV.Columns["Remarks2"].HeaderText = "收货问题";
            DataDGV.Columns["Remarks2"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["Reason"].Width = 150;
            DataDGV.Columns["UserName"].Visible = false;
            DataDGV.Columns["barCodeDate"].Visible = false;
            if (ds.Tables["cs"].Rows.Count > 0)
            {
                if (ds.Tables["cs"].Rows[0]["type"].ToString() == "3")
                {
                    DataDGV.Columns["BarCode"].ReadOnly = true;
                }
            }
            if (Brow != 3)
            {
                DataDGV.Columns["Remarks2"].Visible = false;
            }
            DataDGV.Columns["NExpressName"].HeaderText = "换出快递公司";
            DataDGV.Columns["NExpressName"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["ExpressName"].HeaderText = "寄回快递公司";
            DataDGV.Columns["ExpressName"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["ExpressBarCode"].HeaderText = "寄回快递单号";
            DataDGV.Columns["ExpressBarCode"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["Remarks"].HeaderText = "问题处理";
            DataDGV.Columns["Remarks"].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataDGV.Columns["UserName"].HeaderText = "操作员";
            DataDGV.Columns["UserName"].ReadOnly = true;
            DataDGV.Columns["Remarks"].Width = 200;
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
            this.cmb_Temp.Items.AddRange(new String[] { "七天无理由（买家不喜欢）", "尺码问题偏小", "尺码问题偏大", "质量问题（承担邮费）",
                "发错货（承担邮费）","退货重拍（尺码偏大）","退货重拍（尺码偏小）","描述不符（色差）","拒签退回" });
            this.cmb_Temp.AutoCompleteMode = AutoCompleteMode.Suggest; //输入提示
            this.cmb_Temp.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cmb_Express.Items.AddRange(new String[] { "韵达","圆通","中通", "申通","顺丰","EMS","天天","全峰","百世",
                "国通","快捷","优速","速尔","宅急送","信丰","中国邮政","龙邦","京东","增益","联邦"});
            this.cmb_Express.AutoCompleteMode = AutoCompleteMode.Suggest; //输入提示
            this.cmb_Express.AutoCompleteSource = AutoCompleteSource.ListItems;

            this.cmb_CadeType.Items.AddRange(new String[] { "退货", "换货", "维修" });
            this.cmb_CadeType.AutoCompleteMode = AutoCompleteMode.Suggest; //输入提示
            this.cmb_CadeType.AutoCompleteSource = AutoCompleteSource.ListItems;

            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper = new SqlDataAdapter("Select * from M_user where Username='" + frmlogin.userID + "' ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper.Fill(ds, "US");
            conn.Close();
            string StrUS = "";
            if (ds.Tables["US"].Rows[0]["ShopID"].ToString() != "")
            {
                StrUS = "Select ShopName from M_softshop where ID in (" + ds.Tables["US"].Rows[0]["ShopID"].ToString() + ")";
            }
            else
            {
                StrUS = "Select ShopName from M_softshop ";
            }
            SqlDataAdapter SDAShop = new SqlDataAdapter(StrUS, conn);
            conn.Open();
            SDAShop.Fill(ds, "Shop");
            conn.Close();
            string[] STRUS = new string[ds.Tables["Shop"].Rows.Count];
            StrUS = "";
            if (ds.Tables["Shop"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["Shop"].Rows.Count; i++)
                {
                    STRUS[i] = ds.Tables["Shop"].Rows[i]["ShopName"].ToString() ;
                }
            }
            this.cmb_ShopName.Items.AddRange(STRUS);
            this.cmb_ShopName.AutoCompleteMode = AutoCompleteMode.Suggest; //输入提示
            this.cmb_ShopName.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        
        private void DataDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
       {
            if (e.ColumnIndex == comboBoxColumnIndex)
           {
                //此处cell即CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Rectangle rect = this.DataDGV.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                this.cmb_Temp.Location = rect.Location;
                this.cmb_Temp.Size = rect.Size;
                comfirmComboBoxValue(this.cmb_Temp, (String)cell.Value.ToString());
                this.cmb_Temp.Visible = true;             
            }
            if (e.ColumnIndex == comboBoxCadeType)
            {
                //此处cell即CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Rectangle rect = this.DataDGV.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                this.cmb_CadeType.Location = rect.Location;
                this.cmb_CadeType.Size = rect.Size;
                comfirmComboBoxValue(this.cmb_CadeType, (String)cell.Value.ToString());
                this.cmb_CadeType.Visible = true;
            }
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
            if (e.ColumnIndex == comboBoxEpess2)
            {
                //此处cell即CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Rectangle rect = this.DataDGV.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                this.cmb_Express.Location = rect.Location;
                this.cmb_Express.Size = rect.Size;
                comfirmComboBoxValue(this.cmb_Express, (String)cell.Value.ToString());
                this.cmb_Express.Visible = true;
            }
            if (e.ColumnIndex == comboBoxShopName)
            {
                //此处cell即CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Rectangle rect = this.DataDGV.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
                this.cmb_ShopName.Location = rect.Location;
                this.cmb_ShopName.Size = rect.Size;
                comfirmComboBoxValue(this.cmb_ShopName, (String)cell.Value.ToString());
                this.cmb_ShopName.Visible = true;
            }
        }

        private void DataDGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == comboBoxColumnIndex)
            {
                //此处cell不为CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = this.cmb_Temp.Text;
                this.cmb_Temp.Visible = false;
            }
            if (e.ColumnIndex == comboBoxCadeType)
            {
                //此处cell不为CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = this.cmb_CadeType.Text;
                this.cmb_CadeType.Visible = false;
            }
            if (e.ColumnIndex == comboBoxEpess)
            {
                //此处cell不为CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = this.cmb_Express.Text;
                this.cmb_Express.Visible = false;
            }
            if (e.ColumnIndex == comboBoxEpess2)
            {
                //此处cell不为CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = this.cmb_Express.Text;
                this.cmb_Express.Visible = false;
            }
            if (e.ColumnIndex == comboBoxShopName)
            {
                //此处cell不为CurrentCell
                DataGridViewCell cell = this.DataDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = this.cmb_ShopName.Text;
                this.cmb_ShopName.Visible = false;
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
            string str = "";
            string strornm = "";
            if (Rows != "")
            {
                strsql += "delete from CS_OutRuturnStorage where ID='" + DataDGV.Rows[0].Cells["ID"].Value.ToString() + "' or Ordercade='" + DataDGV.Rows[0].Cells["Ordercade"].Value.ToString() + "'";
            }
            for (int i = 0; i < DataDGV.Rows.Count - 1; i++)
            {
                SqlDataAdapter sqlDaper = new SqlDataAdapter("select * from CS_OutRuturnStorage where OrderCade='" + DataDGV.Rows[i].Cells["OrderCade"].Value.ToString() + "' and OrderCade !='" + Rows + "'", conn);
                DataSet ds = new DataSet();
                conn.Open();
                sqlDaper.Fill(ds, "cs");
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show("订单号：" + DataDGV.Rows[i].Cells["OrderCade"].Value.ToString() + " 已存在请先删，再保存！！");
                    return;
                }
                else
                {
                    if (DataDGV.Rows[i].Cells["CadeType"].Value.ToString() == "退货")
                    {
                        if (DataDGV.Rows[i].Cells["SumMoney"].Value.ToString() == "")
                        {
                            MessageBox.Show("退货单退货金额不能为空");
                            return;
                        }
                    }
                    if (DataDGV.Rows[i].Cells["OrderCade"].Value.ToString() != "")
                    {
                        int type = 0;
                        if (DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString().Trim() == "")
                        {
                            type = 1;
                        }
                        else
                        {
                            //strornm += "select * from CS_OutRuturnNOinforMation where expressbarcode='" + DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString() + "'";
                            type = 2;
                        }
                        if (DataDGV.Rows[i].Cells["Type"].Value.ToString() == "3")
                        {
                            type =Convert.ToInt32( DataDGV.Rows[i].Cells["Type"].Value.ToString());
                        }

                        if (Brow == 3)
                        {
                            type = 3;
                        }
                        if (Brow == 3)
                        {
                            strsql += "insert into CS_OutRuturnStorage(ShopName,CadeType,VipName,Mobile,OrderCade,BarCode,Remarks,Remarks2,Reason,SumMoney,NExpressName,ExpressName,cAdedate,username,BarCodeDate,type,ExpressBarCode)values('"
                                + DataDGV.Rows[i].Cells["ShopName"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["CadeType"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["VipName"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["Mobile"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["OrderCade"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["BarCode"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["Remarks"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["Remarks2"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["Reason"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["SumMoney"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["NExpressName"].Value.ToString().Trim() + "','"
                                + DataDGV.Rows[i].Cells["ExpressName"].Value.ToString().Trim() + "','"
                                + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','"
                                + (DataDGV.Rows[i].Cells["UserName"].Value.ToString().Trim() == "" ? frmlogin.userID : DataDGV.Rows[i].Cells["UserName"].Value.ToString()) + "','"
                                + (DataDGV.Rows[i].Cells["barCodeDate"].Value.ToString().Trim() == "" ? DateTime.Now.ToString("yyyy-MM-dd HH:mm") : DataDGV.Rows[i].Cells["barCodeDate"].Value.ToString()) + "','"
                                + type + "','"
                                + DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString().Trim() + "');";
                        }
                        else
                        {
                           
                                strsql += "insert into CS_OutRuturnStorage(ShopName,CadeType,VipName,Mobile,OrderCade,BarCode,Remarks,Remarks2,Reason,SumMoney,NExpressName,ExpressName,cAdedate,username,BArCodeDate,type,ExpressBarCode)values('"
                                        + DataDGV.Rows[i].Cells["ShopName"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["CadeType"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["VipName"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["Mobile"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["OrderCade"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["BarCode"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["Remarks"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["Remarks2"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["Reason"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["SumMoney"].Value.ToString().Trim() + "','"
                                         + DataDGV.Rows[i].Cells["NExpressName"].Value.ToString().Trim() + "','"
                                        + DataDGV.Rows[i].Cells["ExpressName"].Value.ToString().Trim() + "','"
                                        + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "','"
                                        + (DataDGV.Rows[i].Cells["UserName"].Value.ToString() == "" ? frmlogin.userID : DataDGV.Rows[i].Cells["UserName"].Value.ToString()) + "',"
                                        + (DataDGV.Rows[i].Cells["barCodeDate"].Value.ToString() == "" ? "NULL" : "'" + DataDGV.Rows[i].Cells["barCodeDate"].Value.ToString() + "'") + ",'"
                                        + type + "','"
                                        + DataDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString().Trim() + "');";
                           
                        }
                        if (Rows == "")
                        {
                            strsql += "insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('新增','" + DateTime.Now.ToString().Trim() + "','" + DataDGV.Rows[i].Cells["OrderCade"].Value.ToString().Trim() + "','" + frmlogin.userID + "');";
                        }
                    }
                }
            }
            if (strsql == "")
            {
                MessageBox.Show("没有你要保存的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //if (str == "" && strornm == "")
                //{ }
                //else
                //{
                //    DataSet ds = new DataSet();

                //    //SqlDataAdapter sqlDaper = new SqlDataAdapter(str, conn);
                //    SqlDataAdapter sqlDaperornm = new SqlDataAdapter(strornm, conn);
                //    //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
                //    conn.Open();
                //    //sqlDaper.Fill(ds, "ORS");
                //    sqlDaperornm.Fill(ds, "ornm");
                //    conn.Close();
                //    //if (ds.Tables["ORS"].Rows.Count > 0)
                //    //{
                //    //    string express = "";
                //    //    for (int s = 0; s < ds.Tables["ORS"].Rows.Count; s++)
                //    //    {
                //    //        express = "(" + ds.Tables["ORS"].Rows[s]["ExpressBarCode"].ToString() + ")";
                //    //    }
                //    //    MessageBox.Show(express + "快递单已存在不能保存！！！");
                //    //    return;
                //    //}

                //    if (ds.Tables["ornm"].Rows.Count > 0)
                //    {
                //        string express = "";
                //        for (int s = 0; s < ds.Tables["ornm"].Rows.Count; s++)
                //        {
                //            express = "(" + ds.Tables["ornm"].Rows[s]["ExpressBarCode"].ToString() + ")";
                //        }
                //        MessageBox.Show(express + "快递单已存在无信息中请领用！！！");
                //        return;
                //    }
                //}

                conn.Open();
                SqlCommand sqlcom = new SqlCommand(strsql, conn);
                sqlcom.ExecuteNonQuery();
                conn.Close();
                sqlcom.Dispose();

                MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

                if (Rows != "")
                {
                    this.Close();
                }
                else
                {
                    OutRuturnStorageEDIT_Load(sender, e);
                }
            

        }
      
        private string ImagesBrow(string fileName,string no)
        {
            string imagename = DataDGV[5, DataDGV.CurrentCell.RowIndex].Value.ToString() + DataDGV[6, DataDGV.CurrentCell.RowIndex].Value.ToString() + "_" + no + ".jpg";
            string filepath = "";//具体自己添
            string strimageurl = "http://120.43.209.230:808/AutoUpdate$/IMages/";
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\"))//判断目录是否存在
            {
                //DirectoryInfo dir = new DirectoryInfo(System.Environment.CurrentDirectory+@"\Images\");
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\");
            }
            if (!File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + imagename))//如果是文件的话
            {
                try
                {
                    System.Net.WebClient webclient = new System.Net.WebClient();
                    webclient.DownloadFile(strimageurl + imagename, System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + imagename);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Pimage2.ImageLocation = System.Environment.CurrentDirectory + @"\Images\" + imagename;
            }

            return System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\"+imagename;
        }

        private void DataDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string imagename="";
            imagename=ImagesBrow("", "01");
            if (File.Exists(imagename))//如果是文件的话
            {
                Pimage1.ImageLocation = imagename;
            }
            else
            {
                Pimage1.ImageLocation = "";
            }
            imagename = ImagesBrow("", "02");
            if (File.Exists(imagename))//如果是文件的话
            {

                Pimage2.ImageLocation = imagename;
            }
            else
            {
                Pimage2.ImageLocation = "";
            }
            imagename = ImagesBrow("", "03");
            if (File.Exists(imagename))//如果是文件的话
            {
                Pimage3.ImageLocation = imagename;
            }
            else
            {
                Pimage3.ImageLocation = "";
            }
            imagename = ImagesBrow("", "04");
            if (File.Exists(imagename))//如果是文件的话
            {
                Pimage4.ImageLocation = imagename;
            }
            else
            {
                Pimage4.ImageLocation = "";
            }
            imagename = ImagesBrow("", "05");
            if (File.Exists(imagename))//如果是文件的话
            {
                Pimage5.ImageLocation = imagename;
            }
            else
            {
                Pimage5.ImageLocation = "";
            }
        }

        private string ImageUpdate(string no)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "图片文件";
            ofd.FileName = "";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //ofd.Filter = "Excel文件(*.xls)|*.xls";
            ofd.Filter = "图片文件(*.Jpg)|*.jpg|所有文件|*.*";
            string strName = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strName = ofd.FileName;
            }
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            string imagename = DataDGV[5, DataDGV.CurrentCell.RowIndex].Value.ToString() + DataDGV[6, DataDGV.CurrentCell.RowIndex].Value.ToString() + "_" + no + ".jpg";
            if (strName != "")
            {
                System.IO.File.Copy(strName, System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + imagename, true);
                string uriString = "http://120.43.209.230:808/AutoUpdate$/IMages/";

                if (uriString.EndsWith("/") == false) uriString = uriString + "/";

                uriString = uriString + imagename;
                /// 创建WebClient实例
                WebClient myWebClient = new WebClient();
                myWebClient.Credentials = CredentialCache.DefaultCredentials;

                // 要上传的文件
                FileStream fs = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + imagename, FileMode.Open, FileAccess.Read);
                //FileStream fs = OpenFile();
                BinaryReader r = new BinaryReader(fs);

                byte[] postArray = r.ReadBytes((int)fs.Length);
                Stream postStream = myWebClient.OpenWrite(uriString, "PUT");
                //
                try
                {
                    if (postStream.CanWrite)
                    {
                        postStream.Write(postArray, 0, postArray.Length);
                        postStream.Close();
                        fs.Dispose();
                    }
                    else
                    {
                        postStream.Close();
                        fs.Dispose();
                    }

                }
                catch (Exception err)
                {
                    postStream.Close();
                    fs.Dispose();
                    throw err;
                }
                finally
                {
                    postStream.Close();
                    fs.Dispose();
                }
            }
            return System.AppDomain.CurrentDomain.BaseDirectory + @"\Images\" + imagename;
        }
        private void BtnImage1_Click(object sender, EventArgs e)
        {
            string imagename = ImageUpdate("01");
            if (File.Exists(imagename))//如果是文件的话
            {
                Pimage1.ImageLocation = imagename;
            }

        }
        private void BtnImage2_Click(object sender, EventArgs e)
        {

            string imagename = ImageUpdate("02");
            if (File.Exists(imagename))//如果是文件的话
            {
                Pimage2.ImageLocation = imagename;
            }

        }

        private void BtnImage3_Click(object sender, EventArgs e)
        {

            string imagename = ImageUpdate("03");
            if (File.Exists(imagename))//如果是文件的话
            {
                Pimage3.ImageLocation = imagename;
            }
        }

        private void BtnImage4_Click(object sender, EventArgs e)
        {

            string imagename = ImageUpdate("04");
            if (File.Exists(imagename))//如果是文件的话
            {
                Pimage4.ImageLocation = imagename;
            }
        }

        private void BtnImage5_Click(object sender, EventArgs e)
        {

            string imagename = ImageUpdate("05");
            if (File.Exists(imagename))//如果是文件的话
            {
                Pimage5.ImageLocation = imagename;
            }
        }

        private void Pimage1_Click(object sender, EventArgs e)
        {
            ImageMaxFrm imagemax=new ImageMaxFrm(DataDGV[5, DataDGV.CurrentCell.RowIndex].Value.ToString() + DataDGV[6, DataDGV.CurrentCell.RowIndex].Value.ToString() + "_01.jpg");
            imagemax.ShowDialog();
        }

        private void Pimage2_Click(object sender, EventArgs e)
        {
            ImageMaxFrm imagemax = new ImageMaxFrm(DataDGV[5, DataDGV.CurrentCell.RowIndex].Value.ToString() + DataDGV[6, DataDGV.CurrentCell.RowIndex].Value.ToString() + "_02.jpg");
            imagemax.ShowDialog();
        }

        private void Pimage3_Click(object sender, EventArgs e)
        {
            ImageMaxFrm imagemax = new ImageMaxFrm(DataDGV[5, DataDGV.CurrentCell.RowIndex].Value.ToString() + DataDGV[6, DataDGV.CurrentCell.RowIndex].Value.ToString() + "_03.jpg");
            imagemax.ShowDialog();
        }

        private void Pimage4_Click(object sender, EventArgs e)
        {
            ImageMaxFrm imagemax = new ImageMaxFrm(DataDGV[5, DataDGV.CurrentCell.RowIndex].Value.ToString() + DataDGV[6, DataDGV.CurrentCell.RowIndex].Value.ToString() + "_04.jpg");
            imagemax.ShowDialog();
        }

        private void Pimage5_Click(object sender, EventArgs e)
        {
            ImageMaxFrm imagemax = new ImageMaxFrm(DataDGV[5, DataDGV.CurrentCell.RowIndex].Value.ToString() + DataDGV[6, DataDGV.CurrentCell.RowIndex].Value.ToString() + "_05.jpg");
            imagemax.ShowDialog();
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
