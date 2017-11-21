using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Collections;

namespace DataClass
{
    public class DataTableToJson
    {
        /// <summary> 
        /// DataTable转Json 
        /// </summary> 
        /// <param name="dtb"></param> 
        /// <returns></returns> 
        public string Dtb2Json(DataTable dtb)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ArrayList dic = new ArrayList();
            foreach (DataRow row in dtb.Rows)
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                foreach (DataColumn col in dtb.Columns)
                {
                    drow.Add(col.ColumnName, row[col.ColumnName].ToString());
                }
                dic.Add(drow);
            }
            return jss.Serialize(dic);
        }

        /// <summary>
        /// DataTable转Json 
        /// </summary>
        /// <param name="sqlStr">sql查询语句</param>
        /// <returns></returns>
        public string Dtb2Json(string sqlStr)
        {
            SqlQuery sqlQuery = new SqlQuery();
            DataTable dt = sqlQuery.GetDataTable(sqlStr);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ArrayList dic = new ArrayList();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    drow.Add(col.ColumnName, row[col.ColumnName].ToString());
                }
                dic.Add(drow);
            }
            return jss.Serialize(dic);
        }

        /// <summary>
        /// 获取数据Json数据
        /// </summary>
        /// <param name="sqlStr">查询sql语句</param>
        /// <param name="sqlCount">查询总行数sql语句</param>
        /// <returns>返回json格式数据</returns>
        public string Dtb2Json(string sqlStr,string sqlCount)
        {
            SqlQuery sqlQuery = new SqlQuery();
            DataTable dt = sqlQuery.GetDataTable(sqlStr);
            DataTable dtCount = sqlQuery.GetDataTable(sqlCount);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            ArrayList dic = new ArrayList();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<string, object> drow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    drow.Add(col.ColumnName, row[col.ColumnName].ToString());
                }
                dic.Add(drow);
            }
            return "{ \"total\":" + dtCount.Rows[0][0].ToString() + ",\"rows\":" + jss.Serialize(dic) + "}";
        }
    }
}
