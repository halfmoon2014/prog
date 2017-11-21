using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
using System.Web.Script.Serialization;

namespace SqsBusiness.BackWeb.Route
{
	public partial class sqb_bweb_rount_map : System.Web.UI.Page
	{
        SqlQuery SqlQuery = new SqlQuery();
        SqlDML SqlDML = new SqlDML();
        DataTable tb = new DataTable();
        DataTable mytable = new DataTable();
        protected string currentdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            //查询出拜访记录
            if (Request.QueryString["mode"] == "getdatagrid")
            {
                String starttime = Request.QueryString["starttime"].ToString();
                String endtime = Request.QueryString["endtime"].ToString();
                String zzjg = Request.QueryString["user_groups"].ToString();
                String linkman = Request.QueryString["linkman"].ToString();
                String client_id = Request.QueryString["client_id"].ToString();
                String call_mode = Request.QueryString["call_mode"].ToString();
                String call_type = Server.UrlDecode(Request.QueryString["call_type"].ToString());


                getdatagrid(starttime.Replace("'", "’"), endtime.Replace("'", "’"), zzjg.Replace("'", "’"), linkman.Replace("'", "’"), client_id.Replace("'", "’"), call_mode.Replace("'", "’"), call_type.Replace("'", "’"));
            }


            //查询相应的图片
            if (Request.Form["mode"] == "image")
            {
                getimage(Request.Form["client_call_id"], Request.Form["start_time"].Replace("'", "’"), Request.Form["end_time"].Replace("'", "’"));
            }
        }


        //***************************************************  查询数据，返回JSON***************************************************************************

        /// <summary>
        /// 查询相关记录
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="linkman"></param>
        /// <param name="client_id"></param>
        /// <param name="call_mode"></param>
        /// <param name="call_type"></param>
        private void getdatagrid(String starttime, String endtime, String zzjg, String linkman, String client_id, String call_mode, String call_type)
        {
            //以下是根据传的值是否为空来定义查询条件：分为精确查询和模糊查询
            //如果值为空时，构造的SQL语句为模糊查询
            //如果值不为空，构造的SQL语句为精确查询

            //定义返回JSON的数据引用
            JavaScriptSerializer Jss = new JavaScriptSerializer();
            List<Dictionary<string, object>> TreeJson = new List<Dictionary<string, object>>();
            String sqlstr = "";
            String sql = "";
            if (zzjg != "")
            {
                zzjg = zzjg.Substring(0, zzjg.Length - 1);
            }
            DataTable tb_rowcout = new DataTable();
            //如果未定义查询的时间段，则默认查询出所有的记录
            if (starttime == "" || endtime == "" || zzjg == "")
            {
                sqlstr = "select TOP " + Convert.ToInt32(Request["rows"].ToString()) + " id,name,username,date,call_type,call_mode,job_content from client_call_select where (id >=  (  SELECT ISNULL(MAX(id),0)  FROM (SELECT TOP (" + Convert.ToInt32(Request["rows"].ToString()) + "*(" + Convert.ToInt32(Request["page"].ToString()) + "-1)+1) id FROM client_call_select ORDER BY id ) A ))";

                sql = "select count(*) from client_call_select";

            }
            else
            {

                if (linkman == "")
                {
                    if (zzjg != "")
                    {
                        linkman = "group_id in (" + zzjg + ")";
                    }
                }
                else
                {
                    linkman = "user_id like '%" + linkman + "%'";
                }

                //构造sql 语句
                sqlstr = "select TOP " + Convert.ToInt32(Request["rows"].ToString()) + " id,name,username,date,call_type,call_mode,job_content from client_call_select " +
                    "where (" + linkman + " and client_id like '%" + client_id + "%' and call_mode like '%" + call_mode + "%' and call_type like '%" + call_type + "%') and date between '" + starttime + "' and '" + endtime + "' and (id >=  (  SELECT ISNULL(MAX(id),0)  FROM (SELECT TOP (" + Convert.ToInt32(Request["rows"].ToString()) + "*(" + Convert.ToInt32(Request["page"].ToString()) + "-1)+1) id FROM client_call_select ORDER BY id ) A ))";

                sql = "select count(*) from client_call_select where (" + linkman + " and client_id like '%" + client_id + "%' and call_mode like '%" + call_mode + "%' and call_type like '%" + call_type + "%') and date between '" + starttime + "' and '" + endtime + "'";

            }
            tb = SqlQuery.GetDataTable(sqlstr);
            //将查询结果添加到JSON数据中
            foreach (DataRow Dr in tb.Rows)
            {
                Dictionary<string, object> Drow = new Dictionary<string, object>();

                Drow.Add("id", Dr["id"].ToString());
                Drow.Add("client_name", Dr["name"].ToString());
                Drow.Add("username", Dr["username"].ToString());
                Drow.Add("date", Dr["date"].ToString());
                Drow.Add("call_type", Dr["call_type"].ToString());
                if (Dr["call_mode"].ToString() == "line")
                {
                    Drow.Add("call_mode", "计划外路线");
                }
                else
                {
                    Drow.Add("call_mode", "计划内路线");
                }

                Drow.Add("job_content", Dr["job_content"].ToString());



                TreeJson.Add(Drow);
            }
            tb_rowcout = SqlQuery.GetDataTable(sql);
            //json数据返回
            Response.Write("{ \"total\":" + tb_rowcout.Rows[0][0].ToString() + ",\"rows\":" + Jss.Serialize(TreeJson) + "}");

            Response.End();
        }



        //***************************************************  查询图片， 显示图片***************************************************************************

        private void getimage(String client_call_id, String start_time, String end_time)
        {
            String jsonimg = "";
            String sqlstr = "";
            //根据当前选择行的记录id来查询对应的3张图片
            if (start_time == "" || end_time == "")
            {
                sqlstr = "select top 3 date, back_path,name from sqb_photo_news,sqb_property where sqb_property.id=sqb_photo_news.photo_type_id and client_call_id='" + client_call_id + "'";
            }
            else
            {
                sqlstr = "select top 3 date, back_path,name from sqb_photo_news,sqb_property where sqb_property.id=sqb_photo_news.photo_type_id and client_call_id='" + client_call_id + "' and date between '" + start_time + "' and '" + end_time + "'";
            }
            tb = SqlQuery.GetDataTable(sqlstr);
            //构造json数据
            if (tb.Rows.Count != 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    jsonimg += "{\"date" + (i + 1) + "\":\"" + tb.Rows[i]["date"] + "\",\"back_path" + (i + 1) + "\":\"" + tb.Rows[i]["back_path"] + "\",\"type" + (i + 1) + "\":\"" + tb.Rows[i]["name"] + "\"},";
                }
                jsonimg = "[" + jsonimg.Substring(0, jsonimg.Length - 1) + "]";
            }
            //返回显示图片
            Response.Write(jsonimg);
            Response.End();
        }
	}
}