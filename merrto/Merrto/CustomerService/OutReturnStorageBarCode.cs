using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Net;

namespace Merrto.CustomerService
{
    public partial class OutReturnStorageBarCode : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        System.Media.SoundPlayer media;
        private ComboBox cmb_Express = new ComboBox();
        private int comboBoxEpess = 12; // DataGridView的首列
        public OutReturnStorageBarCode()
        {
            InitializeComponent();
            InitComboBoxValues();
            cmb_Express.Visible = false;
            this.ProudctDGV.Controls.Add(cmb_Express);
            this.ProudctDGV.CellEnter += new DataGridViewCellEventHandler(ProudctDGV_CellEnter);
            this.ProudctDGV.CellLeave += new DataGridViewCellEventHandler(ProudctDGV_CellLeave);
        }

        private void ProudctDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == comboBoxEpess)
            {
                //此处cell即CurrentCell
                DataGridViewCell cell = this.ProudctDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Rectangle rect = this.ProudctDGV.GetCellDisplayRectangle(cell.ColumnIndex, cell.RowIndex, true);
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
        private void ProudctDGV_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == comboBoxEpess)
            {
                //此处cell不为CurrentCell
                DataGridViewCell cell = this.ProudctDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.Value = this.cmb_Express.Text;
                this.cmb_Express.Visible = false;
            }

        }

        private void InitComboBoxValues()
        {
            this.cmb_Express.Items.AddRange(new String[] { "韵达","圆通","中通", "申通","顺丰","EMS","天天","全峰","百世",
                "国通","快捷","优速","速尔","宅急送","信丰" ,"中国邮政","龙邦","京东","增益","联邦" });
            this.cmb_Express.AutoCompleteMode = AutoCompleteMode.Suggest; //输入提示
            this.cmb_Express.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            SqlConnection conn =sqlcon.getcon("");
            DataSet ds = new DataSet();
            if (e.KeyCode == Keys.Enter)
            {
                string strsql = "select ID,Case when type>2 then CAST ('True' as bit) else CAST ('False' as bit)end as ok,ShopName,CadeType,case when type=1 then '等待寄回' when type=2 then '等待收货' when type=3 then '确认收货' when type=4 then '换货完毕' when type=5 then '退款完毕'  when type=6 then 'ERP已审核' else '订单关闭' end type,CadeDate,barCodeDate,VipName,Mobile,OrderCade,BarCode,Remarks,ExpressName,ExpressBarCode," +
               "userName from CS_OutRuturnStorage  where type>0 and (OrderCade like '%" + TxtBarCode.Text.ToString() + "%' or VipName='" + TxtBarCode.Text.ToString() + "' or ExpressBarCode='" + TxtBarCode.Text.ToString() + "' or Mobile='" + TxtBarCode.Text.ToString() + "')";
                SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);

                conn.Open();
                sqlDaper.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ProudctDGV.DataSource = ds.Tables[0];
                    ProudctDGV.Columns["ShopName"].HeaderText = "店铺";
                    ProudctDGV.Columns["ok"].HeaderText = "选";
                    ProudctDGV.Columns["ok"].Width = 45;
                    ProudctDGV.Columns["ShopName"].ReadOnly = true;
                    ProudctDGV.Columns["CadeType"].HeaderText = "类型"; 
                    ProudctDGV.Columns["CadeType"].Width = 60;
                    ProudctDGV.Columns["CadeType"].ReadOnly = true;
                    ProudctDGV.Columns["VipName"].HeaderText = "会员";
                    ProudctDGV.Columns["VipName"].ReadOnly = true;
                    ProudctDGV.Columns["Mobile"].HeaderText = "电话";
                    ProudctDGV.Columns["Mobile"].ReadOnly = true;
                    ProudctDGV.Columns["OrderCade"].HeaderText = "订单";
                    ProudctDGV.Columns["OrderCade"].ReadOnly = true;
                    ProudctDGV.Columns["CadeDate"].HeaderText = "登记日期";
                    ProudctDGV.Columns["CadeDate"].ReadOnly = true;
                    ProudctDGV.Columns["BarCodeDate"].HeaderText = "收货日期";
                    ProudctDGV.Columns["BarCodeDate"].ReadOnly = false;
                    ProudctDGV.Columns["BarCode"].HeaderText = "货品条码";
                    ProudctDGV.Columns["BarCode"].ReadOnly = true;
                    ProudctDGV.Columns["Remarks"].HeaderText = "问题";
                    ProudctDGV.Columns["Remarks"].ReadOnly = true;
                    ProudctDGV.Columns["Type"].HeaderText = "状态";
                    ProudctDGV.Columns["Type"].ReadOnly = true;
                    ProudctDGV.Columns["ExpressName"].HeaderText = "退回快递公司";
                    ProudctDGV.Columns["ExpressBarCode"].HeaderText = "退回快递单";
                    ProudctDGV.Columns["UserName"].HeaderText = "操作员";
                    ProudctDGV.Columns["UserName"].ReadOnly = true;
                    ProudctDGV.Columns["ID"].Visible = false;
                    for (int i = 0; i < ProudctDGV.Rows.Count; i++)
                    {
                        if (ProudctDGV.Rows[i].Cells["barCodeDate"].Value.ToString().Trim() == "")
                        {
                            ProudctDGV.Rows[i].Cells["barCodeDate"].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        }

                    }
                    //ProudctDGV.Columns["barCodeDate"].Visible = false;
 
                }
                else
                {
                     DialogResult result=MessageBox.Show("没有此相关信息，“是”新增退货单,“否”输入无信息", "消息提示！", MessageBoxButtons.YesNoCancel);
                    if ( result== DialogResult.Yes)
                    {
                        OutRuturnStorageEDIT ors = new OutRuturnStorageEDIT("", 3);
                        ors.ShowDialog();
                    }
                    else if (result == DialogResult.No)
                    {
                        OutRuturnNOinforMation ornm = new OutRuturnNOinforMation("");
                        ornm.ShowDialog();
                    }
                    else
                    {
                        return;
                    }

                }
                TxtBarCode.Text = "";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ProudctDGV.Rows.Count > 0)
            {
                SqlConnection conn = sqlcon.getcon("");
                string strsql = "";
                string strornm = "";
                //string date_ = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                int type = 0;
                for (int i = 0; i < ProudctDGV.Rows.Count; i++)
                {

                    if (ProudctDGV.Rows[i].Cells["Ok"].Value.ToString() == "True")
                    {
                        if (ProudctDGV.Rows[i].Cells["Type"].Value.ToString() == "换货完毕" || ProudctDGV.Rows[i].Cells["Type"].Value.ToString() == "退款完毕" || ProudctDGV.Rows[i].Cells["Type"].Value.ToString() == "ERP已审核" || ProudctDGV.Rows[i].Cells["Type"].Value.ToString() == "订单关闭")
                        {
                        }
                        else
                        {
                            strsql += "insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('确认收货','" + DateTime.Now.ToString() + "','" + ProudctDGV.Rows[i].Cells["OrderCade"].Value.ToString().Trim() + "','" + frmlogin.userID + "');";
                            strornm += "select * from CS_OutRuturnNOinforMation where expressbarcode='" + ProudctDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString() + "'";
                            strsql += "update CS_OutRuturnStorage set Remarks2='" + TxtRemarks2.Text.ToString() +
                                "',Type='3',Feedback='"+TxtFeedback.Text.ToString()+
                                "',BarCodeDate='" + ProudctDGV.Rows[i].Cells["BarCodeDate"].Value.ToString() + 
                                "',ExpressName='" + ProudctDGV.Rows[i].Cells["ExpressName"].Value.ToString() +
                               "',ExpressBarCode='" + ProudctDGV.Rows[i].Cells["ExpressBarCode"].Value.ToString() + "' where ID='" + ProudctDGV.Rows[i].Cells["ID"].Value.ToString() + "';";
                        }
                    }
                    else
                        if (ProudctDGV.Rows[i].Cells["Ok"].Value.ToString() == "False")
                        {
                            if (ProudctDGV.Rows[i].Cells["Remarks"].Value.ToString().IndexOf("(领用生成)") > -1)
                            {
                                MessageBox.Show("有单从无信息中领用过来的不能取消收货！！！");
                                return;
                            }
                            if (ProudctDGV.Rows[i].Cells["Type"].Value.ToString() == "换货完毕" || ProudctDGV.Rows[i].Cells["Type"].Value.ToString() == "退款完毕" || ProudctDGV.Rows[i].Cells["Type"].Value.ToString() == "ERP已审核" || ProudctDGV.Rows[i].Cells["Type"].Value.ToString() == "订单关闭")
                            {
                                MessageBox.Show("此状态不能返回！！");
                                return;
                            }
                            else
                            {
                                strsql += "insert into CS_OutRuturnStorageOperate (Operate,Operatedatetime,OrderCade,username)values('取消收货','" + DateTime.Now.ToString() + "','" + ProudctDGV.Rows[i].Cells["OrderCade"].Value.ToString() + "','" + frmlogin.userID + "');";
                               strsql += "update CS_OutRuturnStorage set Remarks2='',Type='" + (ProudctDGV.Rows[i].Cells["ExpressName"].Value.ToString() == ""?1:2) + "',BarCodeDate=NULL where ID='" + ProudctDGV.Rows[i].Cells["ID"].Value.ToString() + "';";
                            }
                        }
                }
               
                if (strornm != "")
                {
                    DataSet ds = new DataSet();

                    //SqlDataAdapter sqlDaper = new SqlDataAdapter(str, conn);
                    //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
                    SqlDataAdapter sqlDaperornm = new SqlDataAdapter(strornm, conn);
                    conn.Open();

                    sqlDaperornm.Fill(ds);
                    conn.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show(ds.Tables[0].Rows[0]["ExpressBarCode"].ToString() + "快递单已存在无信息里不能保存！！！");
                        return;
                    }
                }

                if (strsql != "")
                {
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(strsql, conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();
                    ProudctDGV.DataSource = "";
                    TxtBarCode.Text = "";
                    TxtRemarks2.Text = "";
                    MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("没有你要保存的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("没有你要保存的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        

        private void ProudctDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string imagename = "";
            imagename = ImagesBrow("", "01");
            if (File.Exists(System.Environment.CurrentDirectory + @"\Images\" + imagename))//如果是文件的话
            {
                Pimage1.ImageLocation = System.Environment.CurrentDirectory + @"\Images\" + imagename;
            }
            else
            {
                Pimage1.ImageLocation = "";
            }
            imagename = ImagesBrow("", "02");
            if (File.Exists(System.Environment.CurrentDirectory + @"\Images\" + imagename))//如果是文件的话
            {
                Pimage2.ImageLocation = System.Environment.CurrentDirectory + @"\Images\" + imagename;
            }
            else
            {
                Pimage2.ImageLocation = "";
            }
            imagename = ImagesBrow("", "03");
            if (File.Exists(System.Environment.CurrentDirectory + @"\Images\" + imagename))//如果是文件的话
            {
                Pimage3.ImageLocation = System.Environment.CurrentDirectory + @"\Images\" + imagename;
            }
            else
            {
                Pimage3.ImageLocation = "";
            }
            imagename = ImagesBrow("", "04");
            if (File.Exists(System.Environment.CurrentDirectory + @"\Images\" + imagename))//如果是文件的话
            {
                Pimage4.ImageLocation = System.Environment.CurrentDirectory + @"\Images\" + imagename;
            }
            else
            {
                Pimage4.ImageLocation = "";
            }
            imagename = ImagesBrow("", "05");
            if (File.Exists(System.Environment.CurrentDirectory + @"\Images\" + imagename))//如果是文件的话
            {
                Pimage5.ImageLocation = System.Environment.CurrentDirectory + @"\Images\" + imagename;
            }
            else
            {
                Pimage5.ImageLocation = "";
            }
        }
        private string ImagesBrow(string fileName, string no)
        {
            string imagename = ProudctDGV[6, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + ProudctDGV[7, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + "_" + no + ".jpg";
            string filepath = "";//具体自己添
            string strimageurl = "http://120.43.209.230:808/AutoUpdate$/IMages/";
            if (!Directory.Exists(System.Environment.CurrentDirectory + @"\Images\"))//判断目录是否存在
            {
                //DirectoryInfo dir = new DirectoryInfo(System.Environment.CurrentDirectory+@"\Images\");
                Directory.CreateDirectory(System.Environment.CurrentDirectory + @"\Images\");
            }
            if (!File.Exists(System.Environment.CurrentDirectory + @"\Images\" + imagename))//如果是文件的话
            {
                try
                {
                    System.Net.WebClient webclient = new System.Net.WebClient();
                    webclient.DownloadFile(strimageurl + imagename, System.Environment.CurrentDirectory + @"\Images\" + imagename);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                //Pimage2.ImageLocation = System.Environment.CurrentDirectory + @"\Images\" + imagename;
            }

            return imagename;
        }

        private void Pimage1_Click(object sender, EventArgs e)
        {
            if (File.Exists(System.Environment.CurrentDirectory + @"\Images\" + ProudctDGV[6, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + ProudctDGV[7, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + "_01.jpg"))//如果是文件的话
            {
                ImageMaxFrm imagemax = new ImageMaxFrm(ProudctDGV[6, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + ProudctDGV[7, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + "_01.jpg");
                imagemax.ShowDialog();
            }
        }

        private void Pimage2_Click(object sender, EventArgs e)
        {
            ImageMaxFrm imagemax = new ImageMaxFrm(ProudctDGV[6, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + ProudctDGV[7, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + "_02.jpg");
            imagemax.ShowDialog();
        }

        private void Pimage3_Click(object sender, EventArgs e)
        {
            ImageMaxFrm imagemax = new ImageMaxFrm(ProudctDGV[6, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + ProudctDGV[7, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + "_03.jpg");
            imagemax.ShowDialog();
        }

        private void Pimage4_Click(object sender, EventArgs e)
        {
            ImageMaxFrm imagemax = new ImageMaxFrm(ProudctDGV[6, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + ProudctDGV[7, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + "_04.jpg");
            imagemax.ShowDialog();
        }

        private void Pimage5_Click(object sender, EventArgs e)
        {
            ImageMaxFrm imagemax = new ImageMaxFrm(ProudctDGV[6, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + ProudctDGV[7, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + "_05.jpg");
            imagemax.ShowDialog();
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
            string imagename = ProudctDGV[5, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + ProudctDGV[6, ProudctDGV.CurrentCell.RowIndex].Value.ToString() + "_" + no + ".jpg";
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
    }
}
