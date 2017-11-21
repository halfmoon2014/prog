using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private DataGridView DataGridView1 = new DataGridView();
        private CheckBox CheckBox1 = new CheckBox(); 
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str_sql = "select * from v_user_conn ;";
            DataSet ds = getDataset(GetConn("Mb", "conn"), CommandType.Text, str_sql, null);
            //DataGridViewSet(DataGridView1);
            //DataGridView1.Dock = DockStyle.Fill;
            //this.Controls.Add(DataGridView1);
            this.dataGridView2.DataSource = ds.Tables[0];
        }

        /// <summary>
        /// Add column to DataGridView
        /// </summary>
        private void DataGridViewSet(DataGridView DataGridView1)
        {
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            DataGridViewCheckBoxColumn columnb = new DataGridViewCheckBoxColumn();
            //columnb.ReadOnly = true;
            columnb.HeaderText = "选择";
            columnb.DisplayIndex = 0;
            //columnb.Name = "ck";
            DataGridView1.Columns.Add(columnb);

          
            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "id";
            column.DisplayIndex = 1;
            column.Name = "id";
            DataGridView1.Columns.Add(column);

         
            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "名称";
            column.DisplayIndex = 2;
            column.Name = "tzmc";
            DataGridView1.Columns.Add(column);

          
            column = new DataGridViewTextBoxColumn();
            column.HeaderText = "IP";
            column.DisplayIndex = 3;
            column.Name = "ds";
            DataGridView1.Columns.Add(column);

         

        }


        private void AddToDGV(DataGridView DataGridView1,DataSet ds)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();

                cell.Value = ds.Tables[0].Rows[i]["id"];
                dgvr.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = ds.Tables[0].Rows[i]["tzmc"];
                dgvr.Cells.Add(cell);

                cell = new DataGridViewTextBoxCell();
                cell.Value = ds.Tables[0].Rows[i]["ds"];
                dgvr.Cells.Add(cell);

                DataGridView1.Rows.Add(dgvr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public string GetConn(string ServerName, string Type)
        {
            string str_sql = "";
            if (ServerName == "Master")
            {
                str_sql = "select a.* from v_conn a   where mbbs=2";
            }
            else if (ServerName == "Mb")
            {
                str_sql = "select a.* from v_conn a   where mbbs=1";
            }
            DataSet ds = getDataset(System.Configuration.ConfigurationManager.AppSettings["DBCon"], CommandType.Text, str_sql, null);
            if (ds.Tables[0].Rows.Count <= 0)
            {//没有找到
                return "";
            }
            else
            {
                if (Type == "linkname" || Type == "ic")
                {
                    return ds.Tables[0].Rows[0][Type].ToString().Trim();
                }
                else if (Type == "conn")
                {
                    return "Data Source=" + ds.Tables[0].Rows[0]["ds"].ToString().Trim() + (ds.Tables[0].Rows[0]["m_port"].ToString() == "0" ? "" : "," + ds.Tables[0].Rows[0]["m_port"].ToString()) + ";Initial Catalog=" + ds.Tables[0].Rows[0]["ic"].ToString().Trim() + ";User ID=" + ds.Tables[0].Rows[0]["m_ui"].ToString().Trim() + ";Password=" + ds.Tables[0].Rows[0]["m_pw"].ToString().Trim() + ";";
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCon">连接字串</param>
        /// <param name="cmdType">类型</param>
        /// <param name="sql">要执行的SQL语句或存储过程名</param>
        /// <param name="paras">参数</param>
        /// <returns></returns>
        public static DataSet getDataset(string strCon, CommandType cmdType, string sql, SqlParameter[] paras)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = cmdType; cmd.CommandText = sql;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.SelectCommand = cmd;
            if (paras != null)
            {
                foreach (SqlParameter p in paras)
                {
                    cmd.Parameters.Add(p);
                }
            } try
            {
                con.Open(); adp.Fill(ds);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close(); con.Dispose(); cmd.Dispose(); adp.Dispose();
            }
            return ds;
        }
    }
}
