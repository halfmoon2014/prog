using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
namespace SqsBusiness.BackWeb.Photo
{
	public partial class sqb_bweb_photo_manage : System.Web.UI.Page
	{
        SqlQuery SqlQuery = new SqlQuery();
        DataTable tb = new DataTable();
        DataTableToJson dt2Json = new DataTableToJson();
        String sqlstr = "";
		protected void Page_Load(object sender, EventArgs e)
		{
            
                loadinfo();
            
            //组织架构数据和业务代表人
            if (Request.QueryString["mode"] == "selectlink")
            {
                selectlink(Request.QueryString["zuzhijg"].ToString().Replace("'", "’"));
            }

            //根据选择的业务代表人的ID查询所覆盖的客户列表
            if (Request.QueryString["mode"] == "selectclient")
            {
                selectclient(Request.QueryString["user_id"].ToString().Replace("'", "’"));
            }

            if (Request.QueryString["mode"] == "photos_preview")
            {
                String starttime = Request.QueryString["starttime"];
                String endtime = Request.QueryString["endtime"];
                String photo_type = Request.QueryString["photo_type"];
                String linkman = Request.QueryString["linkman"];
                String client_name = Server.UrlDecode(Request.QueryString["client_name"]);
                getphotos(starttime, endtime, photo_type, linkman, client_name);
            }
		}

     
        
        private void loadinfo() {

            //得到所有的照片类型
            sqlstr = "select id,name from sqb_property";
            tb = SqlQuery.GetDataTable(sqlstr);
            if (tb.Rows.Count!=0){
                photo_type.Items.Clear();
            foreach (DataRow dr in tb.Rows) {
                ListItem item = new ListItem();
                item.Text = dr["name"].ToString();
                item.Value = dr["id"].ToString();
                photo_type.Items.Add(item);
            }}
        }


        //***************************************************  组织架构 ---  业务代表人***************************************************************************
        /// <获得业务代表人数据过程>
        /// 
        /// </summary>
        /// <param name="id"></param>
        private void selectlink(String id)
        {
            string json = "";
            DataTable tb = new DataTable();
            id = id.Substring(0, id.Length - 1);
            String sqlstr = "select id,username,group_id from sqb_users where group_id in(" + id + ")";
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
            else
            {
                json = "[{\"value\":\"\",\"text\":\"\"}]";
            }
            //返回JSON数据到前台
            Response.Write(json);
            Response.End();

        }


        //***************************************************  业务代表人  ---  客户名称  ***************************************************************************

        /// <summary>
        /// 根据选择的业务代表人，查询出业务代表的客户列表
        /// </summary>
        /// <param name="user_id"></param>
        private void selectclient(String user_id)
        {
            String json = "";
            String sqlstr = "select id,code,name from sqb_client where user_id=" + user_id;
            tb = SqlQuery.GetDataTable(sqlstr);
            if (tb.Rows.Count != 0)
            {
                foreach (DataRow dr in tb.Rows)
                {
                    json += "{\"value\":\"" + dr["id"].ToString() + "\",\"text\":\"" + dr["name"].ToString() + "\"},";
                }
                json = "[" + json.Substring(0, json.Length - 1) + "]";
            }
            else
            {
                json = "[{\"value\":\"\",\"text\":\"\"}]";
            }
            Response.Write(json);
            Response.End();
        }





        //*****************************************************  查询照片    ********************************************************************************
        private void getphotos(String starttime, String endtime, String photo_type, String linkman, String client_name) {
           

            String sql = "";
            if (starttime == "" || endtime == "")
            {
               // sqlstr = "select TOP " + Convert.ToInt32(Request["rows"].ToString()) + " client_name,news_type,date,back_path,note,user_id from photos_manage where (id >=  (  SELECT ISNULL(MAX(id),0)  FROM (SELECT TOP (" + Convert.ToInt32(Request["rows"].ToString()) + "*(" + Convert.ToInt32(Request["page"].ToString()) + "-1)+1) id FROM photos_manage ORDER BY id ) A ))";
                sqlstr = "SELECT TOP " + Convert.ToInt32(Request["rows"].ToString()) + " client_name,news_type,date,back_path,note,user_id FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) AS RowNumber,* FROM photos_manage ) A WHERE RowNumber > (" + Convert.ToInt32(Request["rows"].ToString()) + "*(" + Convert.ToInt32(Request["page"].ToString()) + "-1))";
                sql = "select count(*) from photos_manage";
            }
            else
            {
                
                //sqlstr = "select TOP " + Convert.ToInt32(Request["rows"].ToString()) + " client_name,news_type,date,back_path,note,user_id from photos_manage where (photo_type_id like '%" + photo_type + "%' and user_id like '%" + linkman + "%' and client_name like '%" + client_name + "%') and date between '" + starttime + "' and '" + endtime + "' and (id >=  (  SELECT ISNULL(MAX(id),0)  FROM (SELECT TOP (" + Convert.ToInt32(Request["rows"].ToString()) + "*(" + Convert.ToInt32(Request["page"].ToString()) + "-1)+1) id FROM photos_manage ORDER BY id ) A ))";
                sqlstr = "SELECT TOP " + Convert.ToInt32(Request["rows"].ToString()) + " client_name,news_type,date,back_path,note,user_id FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) AS RowNumber,* FROM photos_manage where (photo_type_id like '%" + photo_type + "%' and user_id like '%" + linkman + "%' and client_name like '%" + client_name + "%') and  CONVERT(varchar(100), date, 23) between '" + starttime + "' and '" + endtime + "') A WHERE RowNumber > (" + Convert.ToInt32(Request["rows"].ToString()) + "*(" + Convert.ToInt32(Request["page"].ToString()) + "-1))";
                sql = "select count(*) from photos_manage where (photo_type_id like '%" + photo_type + "%' and user_id like '%" + linkman + "%' and client_name like '%" + client_name + "%') and  CONVERT(varchar(100), date, 23) between '" + starttime + "' and '" + endtime + "'";
            }
            Response.Write(dt2Json.Dtb2Json(sqlstr, sql));
            Response.End();

        }
	}
}