using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
namespace SqsBusiness.BackWeb.Route
{
	public partial class sqb_bweb_rount_dayline : System.Web.UI.Page
	{
        
        
        SqlQuery SqlQuery = new SqlQuery();
        SqlDML SqlDML = new SqlDML();
        DataTable tb = new DataTable();
        DataTable mytable = new DataTable();
        protected string currentdate;
        protected void Page_Load(object sender, EventArgs e)
        {
            //组织架构数据和业务代表人
            if (Request.QueryString["mode"] == "selectlink")
            {
                selectlink(Request.QueryString["zuzhijg"].ToString().Replace("'", "’"));
            }

            //选择日期时触发
            if (Request.QueryString["mode"] == "link_calendar")
            {
                client_list(Request.QueryString["date"].ToString().Replace("'", "’"), Request.QueryString["selectlink"].ToString().Replace("'", "’"));
               
            }


            //保存数据时触发
            if (Request.QueryString["mode"] == "savedata")
            {
                save(Request.QueryString["yes"], Request.QueryString["date"].Replace("'", "’"), Request.QueryString["client_id"].Replace("'", "’"), Request.QueryString["user_id"].Replace("'", "’"), Request.QueryString["call_order"].Replace("'", "’"), Server.UrlDecode(Request.QueryString["job_content"].Replace("'", "’")));
            }
        }

        /// <获得业务代表人数据过程>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void selectlink(String id)
        {
            string json = "";
            DataTable tb = new DataTable();
            id = id.Substring(0, id.Length - 1);
            String sqlstr = "select id,username,group_id from sqb_users where group_id in("+id+")";
            tb = SqlQuery.GetDataTable(sqlstr);
            if (tb.Rows.Count != 0)
            {
                for (int j = 0; j < tb.Rows.Count; j++)
                {
                    //拼JSON数据
                    json += "{\"value\":\"" + tb.Rows[j]["id"].ToString().Trim() + "\",\"text\":\"" + tb.Rows[j]["username"].ToString().Trim() + "\"},";
                }
                json = "[" + json.Substring(0, json.Length - 1) + "]";

            }
            else {
                json = "[{\"value\":\"\",\"text\":\"\"}]";
            }
        
            Response.Write(json);
            Response.End();
            
        }



        
        /// <得到客户信息及工作内容>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="user_id"></param>
         String json1="";
        private void client_list(String date,String user_id) {
            //String sql = "SELECT TOP " + Convert.ToInt32(Request["rows"].ToString()) + " id ,User_ID, Code, Name, Type_ID, Address,'' as call_order,'' as job_content,''as states FROM sqb_client where user_id='"+user_id+"' and(id >=  (  SELECT ISNULL(MAX(id),0)  FROM (SELECT TOP (" + Convert.ToInt32(Request["rows"].ToString()) + "*(" + Convert.ToInt32(Request["page"].ToString()) + "-1)+1) id FROM sqb_client ORDER BY id ) A ))";
            String sql = "SELECT TOP " + Convert.ToInt32(Request["rows"].ToString()) + " id ,User_ID, Code, Name, Type_ID, Address,'' as call_order,'' as job_content,''as states FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) AS RowNumber,* FROM sqb_client where user_id='" + user_id + "') A WHERE RowNumber > (" + Convert.ToInt32(Request["rows"].ToString()) + "*(" + Convert.ToInt32(Request["page"].ToString()) + "-1))";
            SqlConn conn = new SqlConn();
            SqlConnection con= conn.GetConn(conn.GetConnStr());
            con.Open();

           mytable = SqlQuery.GetNotOpenDataTable(sql, con);

           if (mytable.Rows.Count != 0)
           {

               for (int i = 0; i < mytable.Rows.Count; i++)
               {
                   sql = "select call_order,job_content from client_list where CONVERT(varchar(100), date, 23)='" + date + "' and code='" + mytable.Rows[i]["code"] + "' order by call_order";
                   tb = SqlQuery.GetNotOpenDataTable(sql, con);
                   try
                   {
                       mytable.Rows[i]["job_content"] = tb.Rows[0]["job_content"].ToString();
                       mytable.Rows[i]["states"] = mytable.Rows[i]["code"].ToString() + mytable.Rows[i]["id"];
                       mytable.Rows[i]["call_order"] = tb.Rows[0]["call_order"].ToString();
                   }
                   catch (Exception ex)
                   {
                       mytable.Rows[i]["states"] = mytable.Rows[i]["id"].ToString();
                   }
               }
               con.Close();


               for (int i = 0; i < mytable.Rows.Count; i++)
               {
                   json1 += "{\"id\":\"" + mytable.Rows[i]["id"] + "\",\"user_id\":\"" + mytable.Rows[i]["user_id"] +
                       "\",\"client_code\":\"" + mytable.Rows[i]["code"] + "\",\"client_name\":\"" + mytable.Rows[i]["name"] +
                       "\",\"mendian_type\":\"" + mytable.Rows[i]["Type_ID"] +
                       "\",\"address\":\"" + mytable.Rows[i]["address"] + "\",\"no\":\"" + mytable.Rows[i]["Call_Order"] +
                       "\",\"job_content\":\"" + mytable.Rows[i]["job_content"] + "\",\"baifang\":\"" + mytable.Rows[i]["states"] + "\"},";
               }
               sql = "select count(*) from sqb_client";
               tb = SqlQuery.GetDataTable(sql);
               json1="{ \"total\":\""+tb.Rows[0][0].ToString()+"\",\"rows\":" + "["+json1.Substring(0, json1.Length - 1) + "]"+"}";
          
               Response.Write(json1);
                
               Response.End();

           }
           
        }




        /// <保存datagrid数据功能>
        /// 
        /// </summary>
        /// <param name="yes">判断是否要将数据插入</param>
        /// <param name="date">日期</param>
        /// <param name="client_id">客户ID</param>
        /// <param name="user_id">用户ID(业务代表人ID)</param>
        /// <param name="call_order">拜访序号</param>
        /// <param name="job_content">工作内容</param>
        private void save(String yes,String date,String client_id,String user_id,String call_order,String job_content) {
             String sql="";

             sql = "delete sqb_route_plan from sqb_route_plan,sqb_route_plan_detail where sqb_route_plan.id=sqb_route_plan_detail.route_plan_id and client_id='" + client_id + "' and CONVERT(varchar(100), date, 23)='" + date + "'";
             sql += "delete sqb_client_call from sqb_client_call where client_id='" + client_id + "' and CONVERT(varchar(100), date, 23)='" + date + "'";
                if (yes == "true")
                {
                    string plan_id = Guid.NewGuid().ToString();

                    sql += "insert into sqb_route_plan(id,user_id,date) values('" + plan_id + "','" + user_id + "','" + date + "')";

                    sql += "insert into sqb_route_plan_detail(route_plan_id,client_id,call_order,job_content) values('" + plan_id + "','" + client_id + "','" + call_order + "','" + job_content + "')";

                    sql += "insert into sqb_client_call(id,client_id,date,user_id,call_type,call_mode,job_content,add_user_id,add_time) values('"+plan_id+"','"+client_id+"','"+date+"','"+user_id+"','客户异常','dayline','"+job_content+"','"+user_id+"','"+DateTime.Now+"')";
                }
                int count = SqlQuery.sqlselect(sql);
            if (count != 0)
            {
                Response.Write("ture");
            }
            else {
                Response.Write("false");
            }
            Response.End();

                
        
        }


	}
}