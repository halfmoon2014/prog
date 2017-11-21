using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Merrto.BarCodes
{
    public partial class PassToStockReturnBrow : Form
    {
        baseclass.SelectDate sd = new baseclass.SelectDate();
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        public PassToStockReturnBrow()
        {
            InitializeComponent();
        }

        private void BTNbROW_Click(object sender, EventArgs e)
        {
            string str = "";
            try
            {
                if (this.CboFile.SelectedValue.ToString() != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str = str + " BR_PassToStockReturn.FID='" + CboFile.SelectedValue.ToString() + "'";
                }

                if (this.TXtBill.Text.ToString() != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str = str + " BR_PassToStockReturn.OrderCade like '%" + TXtBill.Text.ToString() + "%'";
                }
                if (this.DTPStart.Value.ToString() != "" && DTPStop.Value.ToString("yyyy-MM-dd") != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str += " CadeDATE Between '" + DTPStart.Value.ToString("yyyy-MM-dd") + "' and '" + DTPStop.Value.ToString("yyyy-MM-dd") + "'";
                }
                if (this.TxtCade.Text.ToString() != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str = str + "BR_PassToStockReturn.cade like '%" + TxtCade.Text.ToString() + "%'";
                }
                if (this.TxtItem.Text.ToString() != "")
                {
                    if (str != "")
                    {
                        str += " and ";
                    }
                    str = str + "BarCode like '%" + TxtCade.Text.ToString() + "%'";
                }
                if (str != "")
                {
                    str = " where " + str;
                }

                string strsql = "select BR_PassToStockReturn.cade,Cadedate,m_Factory.title,Ordercade,BarCode,item_no,co_code,s_color," +
                                "m_SizeDetails.cade as sdCade,m_SizeDetails.[Name] as sdName,Qty,username,BR_PassToStockReturn.id " +
                                "from BR_PassToStockReturn " +
                                "left join m_Factory on m_Factory.id=BR_PassToStockReturn.FID " +
                                "left join m_product on m_product.id=BR_PassToStockReturn.pid " +
                                "left join m_ProductSub on m_ProductSub.id=BR_PassToStockReturn.colourid " +
                                "left join m_SizeDetails on m_SizeDetails.id=BR_PassToStockReturn.sdid " + str;

                SqlConnection conn = sqlcon.getcon("");
                DataSet ds = new DataSet();
                SqlDataAdapter sqlDaper = new SqlDataAdapter(strsql, conn);
                conn.Open();
                sqlDaper.Fill(ds);
                conn.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row2 = ds.Tables[0].NewRow();
                    decimal Qty = 0;


                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        Qty = Qty + decimal.Parse(ds.Tables[0].Rows[k][10].ToString());


                    }
                    row2[0] = "合计";
                    row2[10] = Qty.ToString();

                    ds.Tables[0].Rows.Add(row2);
                }
                WPHbROWDGV.DataSource = ds.Tables[0];
                WPHbROWDGV.Columns["BarCode"].HeaderText = "条型码";
                WPHbROWDGV.Columns["qty"].HeaderText = "数量";
                WPHbROWDGV.Columns["Ordercade"].Width = 60;
                WPHbROWDGV.Columns["Ordercade"].HeaderText = "单据";
                WPHbROWDGV.Columns["Qty"].Width = 70;
                WPHbROWDGV.Columns["Cade"].HeaderText = "凭证号";
                WPHbROWDGV.Columns["Cade"].Width = 150;
                WPHbROWDGV.Columns["Cadedate"].HeaderText = "日期";
                WPHbROWDGV.Columns["Cadedate"].Width = 70;
                WPHbROWDGV.Columns["title"].HeaderText = "供方";
                WPHbROWDGV.Columns["title"].Width = 80;
                WPHbROWDGV.Columns["item_no"].HeaderText = "款号";
                WPHbROWDGV.Columns["item_no"].Width = 80;
                WPHbROWDGV.Columns["co_code"].HeaderText = "色号";
                WPHbROWDGV.Columns["co_code"].Width = 60;
                WPHbROWDGV.Columns["s_color"].HeaderText = "颜色";
                WPHbROWDGV.Columns["s_color"].Width = 80;
                WPHbROWDGV.Columns["sdCade"].HeaderText = "代码";
                WPHbROWDGV.Columns["sdCade"].Width = 60;
                WPHbROWDGV.Columns["sdName"].HeaderText = "尺码";
                WPHbROWDGV.Columns["sdName"].Width = 60;
                WPHbROWDGV.Columns["username"].HeaderText = "制单人";
                WPHbROWDGV.Columns["username"].Width = 80;
                WPHbROWDGV.Columns["ID"].Visible = false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PassToStockReturnBrow_Load(object sender, EventArgs e)
        {
            DataTable dt = sd.Factory();
            DataRow row = dt.NewRow();
            dt.Rows.Add(row);
            CboFile.DataSource = dt;
            CboFile.ValueMember = "id";
            CboFile.DisplayMember = "title";
            string strsql = "select * from m_MenuButtonUser left join m_MenuButton on m_MenuButton.id=MBID left join m_user on m_user.id=m_MenuButtonUser.userid where menuID='173' and m_user.userName='" + frmlogin.userID + "' order by Sort";
            SqlConnection conn = sqlcon.getcon("");
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter(strsql, conn);
            conn.Open();
            sqlDaper3.Fill(ds, "User");
            conn.Close();
            if (ds.Tables["User"].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables["User"].Rows.Count; i++)
                {
                    Button BtnNumber = new Button()
                    {
                        Text = ds.Tables["User"].Rows[i]["Name"].ToString(),
                        Name = ds.Tables["User"].Rows[i]["Cade"].ToString(),
                        Location = new System.Drawing.Point(i * 78 + 5, 2),
                        Font = new System.Drawing.Font("宋体", 9F),
                        UseVisualStyleBackColor = true
                    };
                    BtnNumber.Click += new System.EventHandler(this.BtnNumber_Click);
                    this.GpbBtn.Controls.Add(BtnNumber);
                }
            }
        }
        private void BtnNumber_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            PassToStockEdit ors;
            switch (btn.Name)
            {
                case "Delete":
                    try
                    {
                        SqlConnection conn = sqlcon.getcon("");
                        string strsql = "delete from BR_PassToStock where ID='" + WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString() + "'";
                        conn.Open();
                        SqlCommand sqlcom = new SqlCommand(strsql, conn);
                        sqlcom.ExecuteNonQuery();
                        conn.Close();
                        sqlcom.Dispose();
                        MessageBox.Show("已删除！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch
                    {
                        MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case "Edit":
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        ors = new PassToStockEdit(WPHbROWDGV.Rows[WPHbROWDGV.CurrentCell.RowIndex].Cells["ID"].Value.ToString(), "BR_PassToStockReturn");
                        ors.ShowDialog();
                    }
                    break;
                case "Excel":
                    if (WPHbROWDGV.Rows.Count > 0)
                    {
                        //建立Excel对象    
                        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                        excel.Application.Workbooks.Add(true);
                        //生成字段名称    
                        for (int i = 0; i < WPHbROWDGV.ColumnCount; i++)
                        {
                            excel.Cells[1, i + 1] = WPHbROWDGV.Columns[i].HeaderText;

                        }    //填充数据    
                        for (int i = 0; i < WPHbROWDGV.RowCount; i++)
                        {
                            for (int j = 0; j < WPHbROWDGV.ColumnCount; j++)
                            {
                                if (WPHbROWDGV[j, i].Value == typeof(string))
                                {
                                    excel.Cells[i + 2, j + 1] = "" + WPHbROWDGV[i, j].Value.ToString();
                                }
                                else
                                {
                                    excel.Cells[i + 2, j + 1] = WPHbROWDGV[j, i].Value.ToString();
                                }
                            }
                        }
                        excel.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("没有你要导的数据！！！");
                    }
                    break;
               
            }
        }
        private void btnupEXcel_Click(object sender, EventArgs e)
        {
            if (WPHbROWDGV.Rows.Count > 0)
            {
                //建立Excel对象    
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);
                //生成字段名称    
                for (int i = 0; i < WPHbROWDGV.ColumnCount; i++)
                {
                    excel.Cells[1, i + 1] = WPHbROWDGV.Columns[i].HeaderText;
                    //if (y == 0)
                    //{
                    //    y = 1;
                    //    //toolStripStatusLabel6.Text = "数据导入中，请等待!";
                    //}
                }    //填充数据    
                for (int i = 0; i < WPHbROWDGV.RowCount; i++)
                {
                    for (int j = 0; j < WPHbROWDGV.ColumnCount; j++)
                    {
                        if (WPHbROWDGV[j, i].Value == typeof(string))
                        {
                            excel.Cells[i + 2, j + 1] = "" + WPHbROWDGV[i, j].Value.ToString();
                        }
                        else
                        {
                            excel.Cells[i + 2, j + 1] = WPHbROWDGV[j, i].Value.ToString();
                        }
                    }
                }
                excel.Visible = true;
            }
            else
            {
                MessageBox.Show("没有你要导的数据！！！");
            }
        }
    }
}
