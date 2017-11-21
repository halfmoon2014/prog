using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataClass;
using System.Data;
using System.Web.UI;
using System.Web.SessionState;

namespace SqsBusiness.BackWeb.Document
{
    /// <summary>
    /// sqb_bweb_folder_tree 的摘要说明
    /// </summary>
    public class sqb_bweb_folder_tree : IHttpHandler,IRequiresSessionState
    {
        string result = "";
        DataTable dt;
        SqlQuery sqlQuery = new SqlQuery();
        string _uid ;
        string _type="1";//0公共文档，1个人文档
        string _title = "个人文档";
        string _pid = "0";
        public void ProcessRequest(HttpContext context)
        {
            
            _uid = context.Session["SqbBwebUserID"].ToString();
            
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["type"].ToString() == "public")
            {
                _type = "0";
                _title = "公共文档";
                _pid = "-1";
            }
            string sqlStr = "SELECT Name,ID,PID,'" + _title + "' AS P_Name FROM sqb_folder WHERE (Add_User_ID=" + _uid + " OR  Allow_Content like '%," + _uid + ",%')" + "AND pid=" + _pid + " AND Folder_Type_ID=" + _type;
            dt = sqlQuery.GetDataTable(sqlStr);
            result = "[{\"id\":"+_pid+",\"text\":\""+_title+"\",\"children\":[";

            foreach (DataRow dr in dt.Rows)
            {
                //result += "{\"id\":\"" + dr["id"] + "\",\"text\":\"" + dr["Name"] + "\",\"children\":[{\"id\":1,\"text\":\"语文\",\"children\":\"\"}]";
                result += "{\"id\":\"" + dr["id"] + "\",\"text\":\"" + dr["Name"] + "\",\"children\":";
                GetChildren(dr["id"].ToString());

                result += "},";
            }
            result = result.TrimEnd(',');
            result += "]}]";
            context.Response.Write(result);
        }

        public void GetChildren(string pid)
        {
            string sqlStr = "SELECT Name,ID,PID,'" + _title + "' AS P_Name FROM sqb_folder WHERE (Add_User_ID=" + _uid + " OR  Allow_Content like '%," + _uid + ",%')" + "AND pid=" + pid + " AND Folder_Type_ID=" + _type;
            DataTable  dtChildren = sqlQuery.GetDataTable(sqlStr);
            result += "[";
            foreach (DataRow dr in dtChildren.Rows)
            {
                //result += "{\"id\":\"" + dr["id"] + "\",\"text\":\"" + dr["Name"] + "\",\"children\":";
                result += "{\"id\":\"" + dr["id"] + "\",\"text\":\"" + dr["Name"] + "\",\"children\":";
                GetChildren(dr["id"].ToString());

                result += "},";
            }
            if (result[result.Length-1] == ',')
            { 
                result = result.TrimEnd(',');
            }
            result += "]";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}