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
    public partial class rStorageNew : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        private int Rows = 0;
        private int Brow = 0;
        public rStorageNew(int rows,int BROW)
        {
            Rows = rows;
            
            Brow = BROW;
            InitializeComponent();
        }

        private void rStorageNew_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter("SELECT Cade,Fid,StockID,OrderCade,Remarks from BR_RStorageList  where  ID='" + Rows + "' ", conn);
            SqlDataAdapter sqlDaper1 = new SqlDataAdapter("SELECT StockID,StockName from M_Stock ", conn);
            SqlDataAdapter sqlDaper = new SqlDataAdapter("select ID,Title from m_Factory ", conn);
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper3.Fill(ds, "LIST");
            sqlDaper1.Fill(ds, "Stock");
            sqlDaper.Fill(ds, "Factory");
            conn.Close();
            if (ds.Tables["Stock"].Rows.Count > 0)
            {
                CBOStorage.DataSource = ds.Tables["Stock"];
                CBOStorage.ValueMember = "StockID";
                CBOStorage.DisplayMember = "StockName";
            }
            if (ds.Tables["Factory"].Rows.Count > 0)
            {
                CboFID.DataSource = ds.Tables["Factory"];
                CboFID.ValueMember = "ID";
                CboFID.DisplayMember = "Title";
            }

            if (ds.Tables["LIST"].Rows.Count > 0)
            {
                TxtCade.Text = ds.Tables["LIST"].Rows[0]["Cade"].ToString();
                TxtorderCade.Text = ds.Tables["LIST"].Rows[0]["OrderCade"].ToString();
                TxtRemarks.Text = ds.Tables["LIST"].Rows[0]["Remarks"].ToString();
                CboFID.SelectedValue = ds.Tables["LIST"].Rows[0]["Fid"].ToString();
                CBOStorage.SelectedValue = ds.Tables["LIST"].Rows[0]["StockID"].ToString();
            }
            else
            {
                TxtCade.Text = getDate.uppacking("BR_RStorageList", DTPCadeDate.Value.ToString("yyyyMM"), "RKDJ");
            }


            string strwhere = "select BR_RStroageDetailList.ID,item_no,M_name,khdw,co_code,s_color,m_SizeDetails.NAME as SDName,Qty,m_product.id pid,Sdid,ColourID from BR_RStroageDetailList " +
                   "left join m_product on m_product.id=BR_RStroageDetailList.pid " +
                   "left join m_ProductSub on m_ProductSub.id=BR_RStroageDetailList.Colourid " +
                   "left join m_SizeDetails on m_SizeDetails.id=BR_RStroageDetailList.Sdid where RID='" + Rows + "'";
            
            SqlDataAdapter sqlDaper2 = new SqlDataAdapter(strwhere, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();

            sqlDaper2.Fill(ds,"Rk");
            conn.Close();
            DGVDetailList.DataSource = ds.Tables["Rk"];
            DGVDetailList.Columns["item_no"].HeaderText = "款号";
            DGVDetailList.Columns["item_no"].ReadOnly = true;
            DGVDetailList.Columns["co_code"].HeaderText = "色号";
            DGVDetailList.Columns["co_code"].ReadOnly = true;
            DGVDetailList.Columns["M_name"].HeaderText = "品名";
            DGVDetailList.Columns["M_name"].ReadOnly = true;
            DGVDetailList.Columns["khdw"].HeaderText = "单位";
            DGVDetailList.Columns["khdw"].ReadOnly = true;
            DGVDetailList.Columns["s_color"].HeaderText = "颜色";
            DGVDetailList.Columns["s_color"].ReadOnly = true;
            DGVDetailList.Columns["SDName"].HeaderText = "尺码";
            DGVDetailList.Columns["SDName"].ReadOnly = true;
            DGVDetailList.Columns["Qty"].HeaderText = "数量";
            DGVDetailList.Columns["Qty"].ReadOnly = false;
            DGVDetailList.Columns["pid"].Visible = false;
            DGVDetailList.Columns["Sdid"].Visible = false;
            DGVDetailList.Columns["ColourID"].Visible = false;
            DGVDetailList.Columns["ID"].Visible = false;
            TxtBarCode.Focus();
            if (Rows == 0)
            {
                this.Text = "入库登记！！";
            }
            else {
                this.Text = "入库修改！！";
            }
            if (Brow == 0)
            {
                BtnSave.Enabled = false;
                BtnitemSave.Enabled = false;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (DGVDetailList.Rows.Count > 0)
            {
                SqlConnection conn = sqlcon.getcon("");
                try
                {
                    string str;
                    if (Rows != 0)
                    {
                        str = "update BR_RStorageList set Cade='" + this.TxtCade.Text.ToString() +
                                                   "',CadeDate='" + this.DTPCadeDate.Value.ToString("yyyy-MM-dd") +
                                                   "',Fid='" + this.CboFID.SelectedValue.ToString() +
                                                   "',StockID='" + this.CBOStorage.SelectedValue.ToString() +
                                                   "',OrderCade='" + this.TxtorderCade.Text.ToString() +
                                                    "',Listtype='1',Remarks='" + this.TxtRemarks.Text.ToString() + "' where  ID='" + Rows + "' ";
                    }
                    else
                    {
                        str = "declare @I_ID int ; insert into BR_RStorageList (Cade,CadeDate,Fid,StockID,OrderCade,Remarks,Listtype,username) values ('"
                                        + getDate.uppacking("BR_RStorageList", DTPCadeDate.Value.ToString("yyyyMM"), "RKDJ") + "','"
                                        + this.DTPCadeDate.Value.ToString("yyyy-MM-dd") + "','"
                                        + this.CboFID.SelectedValue.ToString() + "','"
                                        + this.CBOStorage.SelectedValue.ToString() + "','"
                                        + this.TxtorderCade.Text.ToString() + "','"
                                        + this.TxtRemarks.Text.ToString() + "','1','"
                                        + frmlogin.userID + "') set @I_ID=@@IDENTITY;  ";
                    }
                    //int row = ;//得到总行数
                    string rolestr = "select * from BR_RStroageDetailList where RID='" + Rows + "'";
                    SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                    DataSet roleds = new DataSet();
                    conn.Open();
                    sqlroleda.Fill(roleds);
                    conn.Close();
                    if (roleds.Tables[0].Rows.Count <= 0)
                    {
                        for (int i = 0; i < DGVDetailList.Rows.Count; i++)//得到总行数并在之内循环
                        {
                            str += "insert into BR_RStroageDetailList(PID,SDID,COLOURID,QTY,RID) VALUES ('"
                                             + DGVDetailList.Rows[i].Cells["pid"].Value.ToString() + "','"
                                             + DGVDetailList.Rows[i].Cells["SDID"].Value.ToString() + "','"
                                             + DGVDetailList.Rows[i].Cells["COLOURID"].Value.ToString() + "','"
                                             + DGVDetailList.Rows[i].Cells["Qty"].Value.ToString() + "',";
                            if (Rows != 0)
                            {
                                str += "'" + Rows + "');";
                            }
                            else
                            {
                                str += "@I_ID);";
                            }

                        }
                    }
                    else if (roleds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < DGVDetailList.Rows.Count; i++)//得到总行数并在之内循环
                        {
                            // string rolestr = ;
                            SqlDataAdapter SDID = new SqlDataAdapter("select * from BR_RStroageDetailList where ID='" + DGVDetailList.Rows[i].Cells["ID"].Value.ToString() + "'", conn);
                            DataSet sizeds = new DataSet();
                            conn.Open();
                            SDID.Fill(sizeds);
                            conn.Close();
                            if (sizeds.Tables[0].Rows.Count > 0)
                            {
                                if (Convert.ToInt32(DGVDetailList.Rows[i].Cells["Qty"].Value.ToString()) > 0)
                                {
                                    str += "update BR_RStroageDetailList set PID='" + DGVDetailList.Rows[i].Cells["pid"].Value.ToString() +
                                        "',SDID='" + DGVDetailList.Rows[i].Cells["SDID"].Value.ToString() +
                                        "',COLOURID='" + DGVDetailList.Rows[i].Cells["COLOURID"].Value.ToString() +
                                        "',QTY='" + DGVDetailList.Rows[i].Cells["Qty"].Value.ToString() +
                                        "',RID='" + Rows +
                                        "' where id='" + DGVDetailList.Rows[i].Cells["ID"].Value.ToString() + "';";
                                }
                                else
                                {
                                    
                                    //MessageBox.Show("数据不能为零！！");
                                    //return;
                                    str += "delete from BR_RStroageDetailList where id='" + DGVDetailList.Rows[i].Cells["ID"].Value.ToString() + "';";
                                }
                            }
                            else
                            {
                                str += "insert into BR_RStroageDetailList(PID,SDID,COLOURID,QTY,RID) VALUES ('"
                                             + DGVDetailList.Rows[i].Cells["pid"].Value.ToString() + "','"
                                             + DGVDetailList.Rows[i].Cells["SDID"].Value.ToString() + "','"
                                             + DGVDetailList.Rows[i].Cells["COLOURID"].Value.ToString() + "','"
                                             + DGVDetailList.Rows[i].Cells["Qty"].Value.ToString() + "','" + Rows + "');";
                            }
                        }
                    }
                    if (Rows != 0)
                    {
                        str += "insert into BR_RstorageOperateList (Operate,Operatedatetime,RID,username)values('修改','" + DateTime.Now.ToString() + "','" + Rows + "','" + frmlogin.userID + "')";
                    }
                    else
                    {
                        str += "insert into BR_RstorageOperateList (Operate,Operatedatetime,RID,username)values('新增','" + DateTime.Now.ToString() + "',@I_ID,'" + frmlogin.userID + "')";
                    }
                    conn.Open();
                    SqlCommand sqlcom = new SqlCommand(str, conn);
                    sqlcom.ExecuteNonQuery();
                    conn.Close();
                    sqlcom.Dispose();
                    //this.txtCade.Text = "";
                    //this.TxtName.Text = "";

                    MessageBox.Show("数据保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (Rows != 0)
                    {
                        btnclose_Click(sender, e);
                    }
                    else
                    {
                        rStorageNew_Load(sender, e);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("没有你要保存的数据！！！");
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DTPCadeDate_ValueChanged(object sender, EventArgs e)
        {
            TxtCade.Text = getDate.uppacking("BR_RStorageList", DTPCadeDate.Value.ToString("yyyyMM"), "RKDJ");
        }

        private void BtnitemSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            string strwhere = "select item_no,M_name,khdw,co_code,s_color,m_SizeDetails.NAME as SDName,m_product.id as pid,m_ProductSub.id as colourID,m_SizeDetails.id as sdid from m_product " +
                  "left join m_productsize on m_product.id=m_productsize.pid " +
                  "left join m_ProductSub on m_product.id=m_ProductSub.pid " +
                  "left join m_SizeDetails on m_SizeDetails.sizeid=m_productsize.sizeid where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='" + this.TxtBarCode.Text.ToString() + "' ";

            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strwhere, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();
            sqlDaper.Fill(ds, "Rks");
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ((DataTable)DGVDetailList.DataSource).NewRow();
                dr["Item_no"] = ds.Tables["RKs"].Rows[0]["Item_no"].ToString();
                dr["co_code"] = ds.Tables["RKs"].Rows[0]["co_code"].ToString();
                dr["s_color"] = ds.Tables["RKs"].Rows[0]["s_color"].ToString();
                dr["M_name"] = ds.Tables["RKs"].Rows[0]["M_name"].ToString();
                dr["khdw"] = ds.Tables["RKs"].Rows[0]["khdw"].ToString();
                dr["SDName"] = ds.Tables["RKs"].Rows[0]["SDName"].ToString();
                dr["pid"] = ds.Tables["RKs"].Rows[0]["pid"].ToString();
                dr["colourID"] = ds.Tables["RKs"].Rows[0]["colourID"].ToString();
                dr["sdid"] = ds.Tables["RKs"].Rows[0]["sdid"].ToString();
                dr["Qty"] = TxtQty.Text.ToString();
                ((DataTable)DGVDetailList.DataSource).Rows.Add(dr);
            }
            else
            {
                MessageBox.Show("查无此条码");
            }
            //TxtBarCode.Text = "";
            TxtBarCode.Focus();
            TxtBarCode.SelectAll();
        }

        private void TxtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtQty.Focus();
                TxtQty.SelectAll();
            }
        }

        private void TxtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnitemSave.Focus();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.DGVDetailList.SelectedRows.Count > 0)
            {
                DataRowView drv = DGVDetailList.SelectedRows[0].DataBoundItem as DataRowView;
                drv.Delete();
            }
        }

        private void TxtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    }
}
