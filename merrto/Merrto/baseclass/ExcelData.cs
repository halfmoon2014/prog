using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Merrto.baseclass
{
    public class ExcelData
    {
        /// 

        /// 关联两个DataTable对象
        /// 

        /// 
        /// 
        /// 
        /// 
        /// 
        public DataTable JoinDataTable(DataTable First, DataTable Second, DataColumn[] FJC, DataColumn[] SJC)
        {

            //创建一个新的DataTable
            DataTable table = new DataTable("Join");

            using (DataSet ds = new DataSet())
            {
                //把DataTable Copy到DataSet中
                ds.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });

                DataColumn[] parentcolumns = new DataColumn[FJC.Length];

                for (int i = 0; i < parentcolumns.Length; i++)
                {
                    parentcolumns[i] = ds.Tables[0].Columns[FJC[i].ColumnName];
                }

                DataColumn[] childcolumns = new DataColumn[SJC.Length];

                for (int i = 0; i < childcolumns.Length; i++)
                {
                    childcolumns[i] = ds.Tables[1].Columns[SJC[i].ColumnName];
                }

                //创建关联
                DataRelation r = new DataRelation(string.Empty, parentcolumns, childcolumns, false);
                ds.Relations.Add(r);

                //为关联表创建列
                for (int i = 0; i < First.Columns.Count; i++)
                {
                    table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
                }

                for (int i = 0; i < Second.Columns.Count; i++)
                {
                    //看看有没有重复的列，如果有在第二个DataTable的Column的列明后加_Second
                    if (!table.Columns.Contains(Second.Columns[i].ColumnName))
                        table.Columns.Add(Second.Columns[i].ColumnName, Second.Columns[i].DataType);
                    else
                        table.Columns.Add(Second.Columns[i].ColumnName + "_Second", Second.Columns[i].DataType);
                }

                table.BeginLoadData();

                foreach (DataRow firstrow in ds.Tables[0].Rows)
                {
                    //得到行的数据
                    DataRow[] childrows = firstrow.GetChildRows(r);

                    if (childrows != null && childrows.Length > 0)
                    {
                        object[] parentarray = firstrow.ItemArray;

                        foreach (DataRow secondrow in childrows)
                        {
                            object[] secondarray = secondrow.ItemArray;
                            object[] joinarray = new object[parentarray.Length + secondarray.Length];
                            Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);
                            Array.Copy(secondarray, 0, joinarray, parentarray.Length, secondarray.Length);
                            table.LoadDataRow(joinarray, true);
                        }
                    }
                }
                table.EndLoadData();
            }
            return table;
        }  

        //将Excel导入到DataGridView中
        public void ExcelToDataGridView(string filePath, DataGridView dgv)
        {

            //string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties =\"Excel 8.0;IMEX=1\"";
            OleDbConnection strCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties =\"Excel 8.0;HDR=yes;IMEX=1\"");
            strCon.Open();
            //string strExcel = "";
            OleDbDataAdapter myCommand = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            DataTable sname = strCon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            myCommand = new OleDbDataAdapter("select * from [sheet1$]", strCon);
            ds = new DataSet();
            myCommand.Fill(ds,"Tables");
            dgv.DataSource = ds.Tables[0];
            strCon.Close();
        }
       
        //将Excel导入到DataGridView中
        public void ExcelToDataGridView(string filePath, string where, string DBoname, DataGridView dgv, int type, DataTable dt)
        {
            OleDbConnection strCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties =\"Excel 8.0;HDR=yes;IMEX=1\"");
            strCon.Open();
            //string strExcel = "";
            OleDbDataAdapter myCommand = new OleDbDataAdapter();
           // DataSet ds = new DataSet();
            DataTable sname = strCon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            string strsql = where + "[" + sname.Rows[0][2].ToString().Trim() + "]";
            myCommand = new OleDbDataAdapter(strsql, strCon);
            //ds = new DataSet();
            myCommand.Fill(dt);
            if (type == 1)
            {
                foreach (DataRow r in dt.Select("type='等待买家付款'"))
                {
                    r.Delete();
                }
                foreach (DataRow r in dt.Select("type='未创建支付宝交易'"))
                {
                    r.Delete();
                }
                foreach (DataRow r in dt.Select("type='交易关闭'"))
                {
                    r.Delete();
                }
                dt.Columns.Remove("type");
            }
            dgv.DataSource = dt;
            //dgv.DataSource = dt;
            strCon.Close();
        }
        /// <summary>   
        /// 取文本右边内容   
        /// </summary>   
        /// <param name="str">文本</param>   
        /// <param name="s">标识符</param>   
        /// <returns>右边内容</returns>   
        public static string GetRight(string str, string s)
        {
            string temp = str.Substring(str.IndexOf(s), str.Length - str.Substring(0, str.IndexOf(s)).Length);
            return temp;
        }  

        /// <summary>   
        /// 取文本左边内容   
        /// </summary>   
        /// <param name="str">文本</param>   
        /// <param name="s">标识符</param>   
        /// <returns>左边内容</returns>   
        public static string GetLeft(string str, string s)  
        {  
            string temp = str.Substring(0, str.IndexOf(s));  
            return temp;  
        }  
        /// <summary>   
        /// 取文本中间到List集合   
        /// </summary>   
        /// <param name="str">文本字符串</param>   
        /// <param name="leftstr">左边文本</param>   
        /// <param name="rightstr">右边文本</param>   
        /// <returns>List集合</returns>   
        public List<string> BetweenArr(string str, string leftstr, string rightstr)  
        {  
            List<string> list = new List<string>();  
            int leftIndex = str.IndexOf(leftstr);//左文本起始位置   
            int leftlength = leftstr.Length;//左文本长度   
            int rightIndex = 0;  
            string temp = "";  
            while (leftIndex != -1)  
            {  
                rightIndex = str.IndexOf(rightstr, leftIndex + leftlength);  
                if (rightIndex == -1)  
                {  
                    break;  
                }  
                temp = str.Substring(leftIndex + leftlength, rightIndex - leftIndex - leftlength);  
                list.Add(temp);  
                leftIndex = str.IndexOf(leftstr, rightIndex + 1);  
            }  
            return list;  
        }  


        public void CSVToDataGridView(string filePath, DataGridView dgv)
        {
            
            char[] chr = new char[1] { '\\' };
            string[] strs = filePath.Split(chr, StringSplitOptions.RemoveEmptyEntries);
            string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath.Substring(0, filePath.Length - strs[strs.Length - 1].Length) + "\\;Extended Properties=\"text;HDR=yes;FMT=Delimited\""; 
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr); 
            con.Open();
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter("select * from [" + strs[strs.Length - 1] + "]", con);
            DataTable dt = new DataTable(); 
            adapter.Fill(dt); 
            con.Close();
            dgv.DataSource = dt;
        }
        public DataTable CSVToDataGridViews(string filePath, DataGridView dgv)
        {

            char[] chr = new char[1] { '\\' };
            string[] strs = filePath.Split(chr, StringSplitOptions.RemoveEmptyEntries);
            string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath.Substring(0, filePath.Length - strs[strs.Length - 1].Length) + "\\;Extended Properties=\"text;HDR=yes;FMT=Delimited\"";
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);
            con.Open();
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter("select * from [" + strs[strs.Length - 1] + "]", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;
            //dgv.DataSource = dt;
        }
        public void CSVToDataGridView(string filePath,string select, DataGridView dgv,DataTable dt,int type)
        {

            char[] chr = new char[1] { '\\' };
            string[] strs = filePath.Split(chr, StringSplitOptions.RemoveEmptyEntries);
            string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath.Substring(0, filePath.Length - strs[strs.Length - 1].Length) + "\\;Extended Properties=\"text;HDR=yes;FMT=Delimited\"";
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);
            
            con.Open();
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(select+" [" + strs[strs.Length - 1] + "]", con);
            OleDbCommand SCD = new OleDbCommand(select + " [" + strs[strs.Length - 1] + "]", con);
           
            adapter.Fill(dt);
            con.Close();
            if (type == 1)
            {
                foreach (DataRow r in dt.Select("type='等待买家付款'"))
                {
                    r.Delete();
                }
                foreach (DataRow r in dt.Select("type='未创建支付宝交易'"))
                {
                    r.Delete();
                }
                foreach (DataRow r in dt.Select("type='交易关闭'"))
                {
                    r.Delete();
                }
                dt.Columns.Remove("type");
            }
            dgv.DataSource = dt;
        }
        public void CSVToDataGridView(string filePath, DataGridView dgv, DataTable dt)
        {

            char[] chr = new char[1] { '\\' };
            string[] strs = filePath.Split(chr, StringSplitOptions.RemoveEmptyEntries);
            string constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath.Substring(0, filePath.Length - strs[strs.Length - 1].Length) + "\\;Extended Properties=\"text;HDR=yes;FMT=Delimited\"";
            System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection(constr);

            con.Open();
            System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter("select * from [" + strs[strs.Length - 1] + "]", con);
            OleDbCommand SCD = new OleDbCommand("select * from [" + strs[strs.Length - 1] + "]", con);

            adapter.Fill(dt);
            con.Close();
           
            dgv.DataSource = dt;
        }
    }
}
