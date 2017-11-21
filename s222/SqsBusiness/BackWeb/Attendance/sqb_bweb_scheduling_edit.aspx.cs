using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;

namespace SqsBusiness.BackWeb.Attendance
{
    public partial class sqb_bweb_scheduling_edit : System.Web.UI.Page
    {
        string _action;
        public string _id = "";
        string _uid;
        string _name;
        string _allowName;
        string _userID;
        public string _signIn;
        public string _signOut;
        public string _getUserID;
        
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

            if (Request.QueryString["getUsers"] != null)
            {
                GetUsersJson();
            }

            if (Request.QueryString["id"] != null)
            {
                _id = Request.QueryString["id"].ToString();
                GetSchedulingInfo();
            }
            if (Request.Form["id"] != null)
            {
                _id = Request.Form["id"].ToString();
            }
            if (Request.Form["action"] != null)
            {
                if (_id == "")
                {
                    _action = "";
                }
                else
                {
                    _action = Request.Form["action"].ToString();
                }
                _name = Request.Form["name"].ToString();
                _signIn = Request.Form["signIn"].ToString();
                _signOut = Request.Form["signOut"].ToString();
                _userID = Request.Form["userID"].ToString();
                _allowName = Request.Form["allowName"].ToString();
                Save();
            }
        }


        //获取用户名和ID json数据
        public void GetUsersJson()
        {
            string sqlStr = "SELECT ID,UserName FROM sqb_users";
            DataTable dtUsers = sqlQuery.GetDataTable(sqlStr);
            string result = dt2Json.Dtb2Json(dtUsers);
            Response.Write(result);
            Response.End();
        }

        //保存
        public void Save()
        {
            string sqlStr = "";
            switch (_action)
            {
                case "":
                    sqlStr = "INSERT INTO [sqb_attendance_set]" +
                            "([Name]" +
                            ",[SignIn_Time]" +
                            ",[SignOut_Time]" +
                            ",[Holiday]" +
                            ",[Login_SignIn]" +
                            ",[User_ID]" +
                            ",[User_Name]"+
                            ",[Add_User])" +
                            "VALUES" +
                            "('" + _name + "'" +
                            ",Convert(Time(0),'" + _signIn + "')" +
                            ",Convert(Time(0),'" + _signOut + "')" +
                            ",0" +
                            ",0" +
                            ",'" + _userID + "'" +
                            ",'"+_allowName+"'"+
                            "," + _uid + ")";
                    break;
                case "update": 
                    sqlStr = "UPDATE [sqb_attendance_set]  " +
                            "SET [Name] = '"+_name+"'" +
                            ",[SignIn_Time] = Convert(Time(0),'"+_signIn+"')" +
                            ",[SignOut_Time] = Convert(Time(0),'"+_signOut+"')" +
                            ",[Holiday] = 0" +
                            ",[Login_SignIn] = 0" +
                            ",[User_ID] = '" + _userID + "'" +
                            ",[Update_User] = " +_uid+
                            ",[User_Name]='"+_allowName+"'"+
                            "WHERE ID=" + _id;
                    break;
            }
            if (sqlDML.DML(sqlStr) > 0)
            {
                Response.Write("<script>alert('aaa');</script>");
            }
            else
            {
                Response.Write("false");
            }
            Response.End();
        }

        public void GetSchedulingInfo()
        { 
           string sqlStr="select * from sqb_attendance_set where id="+_id;
           DataTable dt = sqlQuery.GetDataTable(sqlStr);
           if (dt.Rows.Count > 0)
           {
               this.Name.Value =dt.Rows[0]["Name"].ToString();
               this._signIn = dt.Rows[0]["SignIn_Time"].ToString().Substring(0, dt.Rows[0]["SignIn_Time"].ToString().LastIndexOf(':'));
               this._signOut = dt.Rows[0]["SignOut_Time"].ToString();
               this._getUserID = dt.Rows[0]["User_ID"].ToString();
           }
        }
    }
}