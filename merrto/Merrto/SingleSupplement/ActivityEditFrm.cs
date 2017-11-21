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
    public partial class ActivityEditFrm : Form
    {
        baseclass.sqldatacon sqlcon = new baseclass.sqldatacon();
        baseclass.DATECalse getDate = new baseclass.DATECalse();
        private int Rows = 0;
        private int Brow = 0;
        public ActivityEditFrm(int rows, int BROW)
        {
            InitializeComponent();
            Rows = rows;
            Brow = BROW;
        }

        private void ActivityEditFrm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            SqlDataAdapter sqlDaper3 = new SqlDataAdapter("SELECT Cade,CadeDate,Name,Remarks,Type from SS_ActivityList  where  ID='" + Rows + "' ", conn);
           
            DataSet ds = new DataSet();
            conn.Open();
            sqlDaper3.Fill(ds, "LIST");
            conn.Close();
          
            if (ds.Tables["LIST"].Rows.Count > 0)
            {
                TxtCade.Text = ds.Tables["LIST"].Rows[0]["Cade"].ToString();
                TxtName.Text = ds.Tables["LIST"].Rows[0]["Name"].ToString();
                DTPCadeDate.Text = ds.Tables["LIST"].Rows[0]["CadeDate"].ToString();
                TxtRemarks.Text = ds.Tables["LIST"].Rows[0]["Remarks"].ToString();
                if (ds.Tables["LIST"].Rows[0]["Type"].ToString() == "1")
                    RBtnYJ.Checked = true;
                else
                {
                    RBtnStorage.Checked = true;
                }
            }
            else
            {
                TxtCade.Text = getDate.uppacking("SS_ActivityList", DTPCadeDate.Value.ToString("yyyyMM"), "HD" + (RBtnYJ.Checked == true?"YJ":"FH"));
            }


            string strwhere = "select SS_ActivityDetailList.ID,item_no,M_name,khdw,co_code,s_color,m_SizeDetails.name SDName,Qty,m_product.id pid,m_SizeDetails.id sdid,m_ProductSub.id ColourID from SS_ActivityDetailList " +
                   "left join m_product on m_product.id=SS_ActivityDetailList.pid LEFT JOIN m_ProductSub ON m_ProductSub.ID=SS_ActivityDetailList.Sdid LEFT join m_SizeDetails on m_SizeDetails.ID=SDID  where RID='" + Rows + "'";

            SqlDataAdapter sqlDaper2 = new SqlDataAdapter(strwhere, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();

            sqlDaper2.Fill(ds, "HD");
            conn.Close();
            DGVDetailList.DataSource = ds.Tables["HD"];
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
                this.Text = "活动登记！！";
            }
            else
            {
                this.Text = "活动修改！！";
            }
            if (Brow == 0)
            {
                BtnSave.Enabled = false;
                BtnitemSave.Enabled = false;
            }
        }

        private void BtnitemSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            //string strwhere = "select item_no,M_name,khdw,m_product.id as pid from m_product " +
            //      " where ITEM_NO ='" + this.TxtBarCode.Text.ToString() + "' ";
            string strwhere = "SELECT ITEM_NO,M_name,khdw,S_COLOR,CO_CODE,m_SizeDetails.cade as SDcade,m_SizeDetails.[name] as SDName," +
                               "m_ProductSub.pid,M_productsub.id as colourID,m_SizeDetails.id sdid FROM m_product LEFT JOIN m_ProductSub " +
                            "ON m_ProductSub.PID=m_product.ID left join m_ProductSize on m_ProductSize.pid=m_product.ID " +
                            "LEFT join m_SizeDetails on m_SizeDetails.sizeid=m_ProductSize.sizeid " +
            "where cast(ITEM_NO as varchar(20))+cast(CO_CODE as varchar(20))+m_SizeDetails.Cade='" + TxtBarCode.Text.ToString() + "' ";
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDaper = new SqlDataAdapter(strwhere, conn);
            //SqlDataAdapter sqlDaper = sqlcon.getread(strwhere);
            conn.Open();
            sqlDaper.Fill(ds, "HDS");
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ((DataTable)DGVDetailList.DataSource).NewRow();
                dr["Item_no"] = ds.Tables["HDS"].Rows[0]["Item_no"].ToString();
                dr["M_name"] = ds.Tables["HDS"].Rows[0]["M_name"].ToString();
                dr["khdw"] = ds.Tables["HDS"].Rows[0]["khdw"].ToString();
                dr["S_COLOR"] = ds.Tables["HDS"].Rows[0]["S_COLOR"].ToString();
                dr["CO_CODE"] = ds.Tables["HDS"].Rows[0]["CO_CODE"].ToString();
                dr["SDName"] = ds.Tables["HDS"].Rows[0]["SDName"].ToString();
                dr["pid"] = ds.Tables["HDS"].Rows[0]["pid"].ToString();
                dr["ColourID"] = ds.Tables["HDS"].Rows[0]["ColourID"].ToString();
                dr["Sdid"] = ds.Tables["HDS"].Rows[0]["Sdid"].ToString();
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = sqlcon.getcon("");
            try
            {
                string str;
                if (Rows != 0)
                {
                    str = "update SS_ActivityList set Cade='" + this.TxtCade.Text.ToString() +
                                               "',CadeDate='" + this.DTPCadeDate.Value.ToString("yyyy-MM-dd") +
                                               "',Name='" + TxtName.Text.ToString() +
                                               "',Type='" + (RBtnYJ.Checked==true?"1":"2") +
                                                "',Listtype='1',Remarks='" + this.TxtRemarks.Text.ToString() + "' where  ID='" + Rows + "' ";
                }
                else
                {
                    str = "declare @I_ID int ; insert into SS_ActivityList (Cade,CadeDate,Name,Type,Remarks,Listtype,username) values ('"
                                    + getDate.uppacking("SS_ActivityList", DTPCadeDate.Value.ToString("yyyyMM"), "HD"+(RBtnYJ.Checked == true?"YJ":"FH")) + "','"
                                    + this.DTPCadeDate.Value.ToString("yyyy-MM-dd") + "','"
                                    + TxtName.Text.ToString() + "','"
                                    + (RBtnYJ.Checked == true ? "1" : "2") + "','"
                                    + this.TxtRemarks.Text.ToString() + "','1','"
                                    + frmlogin.userID + "') set @I_ID=@@IDENTITY;  ";
                }
                //int row = ;//得到总行数
                string rolestr = "select * from SS_ActivityDetailList where RID='" + Rows + "'";
                SqlDataAdapter sqlroleda = new SqlDataAdapter(rolestr, conn);
                DataSet roleds = new DataSet();
                conn.Open();
                sqlroleda.Fill(roleds);
                conn.Close();
                if (roleds.Tables[0].Rows.Count <= 0)
                {
                    for (int i = 0; i < DGVDetailList.Rows.Count; i++)//得到总行数并在之内循环
                    {
                        str += "insert into SS_ActivityDetailList(PID,ColourID,SdID,QTY,RID) VALUES ('"
                                         + DGVDetailList.Rows[i].Cells["pid"].Value.ToString() + "','"
                                         + DGVDetailList.Rows[i].Cells["ColourID"].Value.ToString() + "','"
                                         + DGVDetailList.Rows[i].Cells["SdID"].Value.ToString() + "','"
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
                        SqlDataAdapter SDID = new SqlDataAdapter("select * from SS_ActivityDetailList where ID='" + DGVDetailList.Rows[i].Cells["ID"].Value.ToString() + "'", conn);
                        DataSet sizeds = new DataSet();
                        conn.Open();
                        SDID.Fill(sizeds);
                        conn.Close();
                        if (sizeds.Tables[0].Rows.Count > 0)
                        {
                            if (Convert.ToInt32(DGVDetailList.Rows[i].Cells["Qty"].Value.ToString()) > 0)
                            {
                                str += "update SS_ActivityDetailList set PID='" + DGVDetailList.Rows[i].Cells["pid"].Value.ToString() +
                                    "',ColourID='" + DGVDetailList.Rows[i].Cells["ColourID"].Value.ToString() +
                                    "',SdID='" + DGVDetailList.Rows[i].Cells["SdID"].Value.ToString() +
                                    "',QTY='" + DGVDetailList.Rows[i].Cells["Qty"].Value.ToString() +
                                    "',RID='" + Rows +
                                    "' where id='" + DGVDetailList.Rows[i].Cells["ID"].Value.ToString() + "';";
                            }
                            else
                            {
                                str += "delete from SS_ActivityDetailList where id='" + DGVDetailList.Rows[i].Cells["ID"].Value.ToString() + "';";
                            }
                        }
                        else
                        {
                            str += "insert into SS_ActivityDetailList(PID,ColourID,SdID,QTY,RID) VALUES ('"
                                         + DGVDetailList.Rows[i].Cells["pid"].Value.ToString() + "','"
                                          + DGVDetailList.Rows[i].Cells["ColourID"].Value.ToString() + "','"
                                         + DGVDetailList.Rows[i].Cells["SdID"].Value.ToString() + "','"
                                         + DGVDetailList.Rows[i].Cells["Qty"].Value.ToString() + "','" + Rows + "');";

                        }
                    }
                }
                if (Rows != 0)
                {
                    str += "insert into SS_ActivityOperateList (Operate,Operatedatetime,RID,username)values('修改','" + DateTime.Now.ToString() + "','" + Rows + "','" + frmlogin.userID + "')";
                }
                else
                {
                    str += "insert into SS_ActivityOperateList (Operate,Operatedatetime,RID,username)values('新增','" + DateTime.Now.ToString() + "',@I_ID,'" + frmlogin.userID + "')";
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
                    ActivityEditFrm_Load(sender, e);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据保存失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
