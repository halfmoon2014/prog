using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DataClass;
namespace SqsBusiness.BackWeb.Attendance
{
    public partial class sqb_bweb_scheduling_set : System.Web.UI.Page
    {
        string _id;//排班ID
        string _allow;//设置考勤管理人员
        public string _getAllow;//获取设置考勤管理人员
        string _uid;//用户ID
        SqlQuery sqlQuery = new SqlQuery();
        SqlDML sqlDML = new SqlDML();
        DataTableToJson dt2Json = new DataTableToJson();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SqbBwebUserID"] == null)
            {
                Response.Write("<script>window.parent.location.href='../sqb_bweb_login.aspx'</script>");
            }
            _uid = Session["SqbBwebUserID"].ToString();
            
            //获取考勤管理用户
            if (Request.QueryString["getUsers"] != null)
            {
                Response.Write(dt2Json.Dtb2Json("SELECT ID,UserName FROM sqb_users"));
                
                    Response.End();
                
            }
            DataTable dt = sqlQuery.GetDataTable("select * from sqb_attendance_manage");
                if(dt.Rows.Count>0)
                {
                    _getAllow = dt.Rows[0]["User_ID"].ToString();
                }
            if (Request.QueryString["mode"] != null)
            {
                
                GetScheduling();
            }

            //排班删除
            if (Request.Form["id"] != null)
            {
                _id = Request.Form["id"].ToString();
                Del();
            }

            //设置考勤管理人员
            if (Request.Form["allow"] != null)
            {
                _allow = Request.Form["allow"].ToString();
                string sqlStr = "DELETE FROM [sqb_attendance_manage] |" +
                                "INSERT INTO [sqb_attendance_manage]" +
                                "([User_ID]" +
                                ",[Update_UserID]" +
                                ",[Update_Time])" +
                                "VALUES" +
                                "('" +_allow+"'"+
                                "," +_uid+
                                ",Convert(DateTime,'"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"'))";
                sqlDML.DML(sqlStr);
            }

        }

        public void GetScheduling()
        {
            string sqlStr = "SELECT * FROM sqb_attendance_set";
            DataTable dt = sqlQuery.GetDataTable(sqlStr);
            string result = dt2Json.Dtb2Json(dt);
            Response.Write(result);
            Response.End();
        }

        public void Del()
        {
            string sqlStr = "DELETE [sqb_attendance_set] WHERE ID=" + _id;
            if (sqlDML.DML(sqlStr) > 0)
            {
                Response.Write("true");

            }
            else
            {
                Response.Write("false");
            }
            Response.End();
        }
    }
}