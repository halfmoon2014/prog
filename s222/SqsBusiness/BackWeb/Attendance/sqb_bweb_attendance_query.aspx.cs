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
	public partial class sqb_bweb_attendance_query : System.Web.UI.Page
	{
        string _dateStart;
        string _dateEnd;
        string _uid;
        SqlQuery sqlQuery=new SqlQuery ();
        DataTableToJson dt2Json = new DataTableToJson();
        
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["SqbBwebUserID"] == null)
            {
                Response.Write("<script>window.parent.location.href='../sqb_bweb_login.aspx'</script>");
            }
            _uid = Session["SqbBwebUserID"].ToString();
            if (Request.QueryString["getData"] != null)
            {
                _dateStart = Request.QueryString["dateStart"].ToString();
                _dateEnd = Request.QueryString["dateEnd"].ToString();
                GetData();    
            }
		}

        public void GetData()
        {
            //Response.Write(dt2Json.Dtb2Json("SELECT CONVERT(Varchar(10),Sign_Time,121) AS Date,B.Name,SignType,CONVERT(Time(0),Sign_Time) AS Time,"+
            //                                "Case SignType WHEN '签到' THEN CASE WHEN  CONVERT(Time(0),Sign_Time)>SignIn_Time THEN '迟到'+Convert(varchar(10),DATEDIFF ( minute, SignIn_Time,CONVERT(Time(0),Sign_Time)))+'分钟' ELSE '正常' END  "+
            //                                " WHEN '签退' THEN CASE WHEN  CONVERT(Time(0),Sign_Time)<=SignOut_Time  THEN '早退'+Convert(varchar(10),DATEDIFF ( minute,CONVERT(Time(0),Sign_Time),SignOut_Time))+'分钟' ELSE '正常' END" +
            //                                " END AS Type"+
            //                                " FROM sqb_attendance A,sqb_attendance_set B "+
            //                                " WHERE A.User_ID=1 "+
            //                                " AND Sign_Time>CONVERT(Date,'" + _dateStart + "') " +
            //                                " AND Sign_Time<CONVERT(Date,'" + _dateEnd + "') " +
            //                                " AND A.Classes_ID=B.ID "+
            //                                " AND B.USER_ID like '%,"+_uid+",%'"+
            //                                " ORDER BY Sign_Time"));

            Response.Write(dt2Json.Dtb2Json("SELECT TOP "+Request.Form["rows"]+" A.ID,A.User_ID,CONVERT(Varchar(10),Sign_Time,121) AS Date,B.Name,SignType,CONVERT(Time(0),Sign_Time) AS Time,Case SignType WHEN '签到' THEN CASE WHEN  CONVERT(Time(0),Sign_Time)>SignIn_Time THEN '迟到'+Convert(varchar(10),DATEDIFF ( minute, SignIn_Time,CONVERT(Time(0),Sign_Time)))+'分钟' ELSE '正常' END   WHEN '签退' THEN CASE WHEN  CONVERT(Time(0),Sign_Time)<=SignOut_Time  THEN '早退'+Convert(varchar(10),DATEDIFF ( minute,CONVERT(Time(0),Sign_Time),SignOut_Time))+'分钟' ELSE '正常' END END AS Type FROM sqb_attendance A,sqb_attendance_set B  WHERE A.User_ID="+_uid+"  AND Sign_Time>=CONVERT(Date,'"+_dateStart+"')  AND Sign_Time<=CONVERT(Date,'"+_dateEnd+"')  AND A.Classes_ID=B.ID  AND B.USER_ID like '%,"+_uid+",%' AND A.ID >= (SELECT ISNULL(MAX(id),0) FROM (SELECT TOP ("+Request["rows"]+"*("+Request["page"]+"-1)+1) ID FROM sqb_attendance WHERE User_ID="+_uid+" AND Sign_Time>=CONVERT(Date,'"+_dateStart+"')  AND Sign_Time<=CONVERT(Date,'"+_dateEnd+"') ORDER BY id) C ) ORDER BY Sign_Time", "select COUNT(*) FROM sqb_attendance A,sqb_attendance_set B  WHERE A.User_ID="+_uid+"  AND Sign_Time>CONVERT(Date,'"+_dateStart+"')  AND Sign_Time<CONVERT(Date,'"+_dateEnd+"')  AND A.Classes_ID=B.ID  AND B.USER_ID like '%,"+_uid+",%' "));
            Response.End();
        }
	}
}