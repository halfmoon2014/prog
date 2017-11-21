using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;

namespace DataClass
{
    public class JsonClass
    {
        SqlQuery SqlQuery = new SqlQuery(); //SQL查询类
        JavaScriptSerializer Jss = new JavaScriptSerializer(); //实例化字符串

        /// <summary>
        /// 根据SQL语句返datagrid分页Json格式字符串
        /// </summary>
        /// <param name="SqlString">查询分页数据的语句</param>
        /// <param name="SqlCountString">查询总记录语句</param>
        /// <returns>datagrid的Json格式字符串</returns>
        public string GetDataGridJson(string SqlString, string SqlCountString)
        {
            DataTable JsonTable = SqlQuery.GetDataTable(SqlString); //查询数据
            DataTable CountTable = SqlQuery.GetDataTable(SqlCountString); //数据记录数

            return "{ \"total\":" + CountTable.Rows[0][0].ToString() + ",\"rows\":" + TableToBasicJson(JsonTable) + "}";
        }

        /// <summary>
        /// 根据SQL语句返Json格式字符串
        /// </summary>
        /// <param name="SqlString">查询语句</param>
        public string GetListJson(string SqlString)
        {
            DataTable JsonTable = SqlQuery.GetDataTable(SqlString); //查询数据
            return TableToBasicJson(JsonTable);
        }

        /// <summary>
        /// 根据表得到Json格式字符串
        /// </summary>
        /// <param name="JsonTable">数据表</param>
        /// <returns>Json格式字符串</returns>
        public string TableToBasicJson(DataTable JsonTable)
        {
            //组合Json数据
            List<Dictionary<string, object>> JsonList = new List<Dictionary<string, object>>();
            foreach (DataRow Row in JsonTable.Rows)
            {
                Dictionary<string, object> JsonDrow = new Dictionary<string, object>();

                foreach (DataColumn Col in JsonTable.Columns)
                {
                    JsonDrow.Add(Col.ColumnName.ToLower(), Row[Col.ColumnName].ToString());
                }

                JsonList.Add(JsonDrow);
            }

            return Jss.Serialize(JsonList);
        }
    }
}
