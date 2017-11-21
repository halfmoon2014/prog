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
namespace SqsBusiness.BackWeb.Massage
{
    public partial class sqb_bweb_message_manage : System.Web.UI.Page
    {
        SqlQuery SqlQuery = new SqlQuery();
        DataTable mytable = new DataTable();
        DataTableToJson dt2Json = new DataTableToJson();
        SqlDML sqlDML = new SqlDML();
        string result = "";
        //string _Action = "";
        public string _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["mode"] == "loadtable")
            {
                GetTJson();
            }
          
            if (Request.Form["ID"] != null)
            {
                _id = Request.Form["ID"].ToString();
                Delete();
            }
            if (Request.QueryString["mode"] == "loadcbbox")
            {
                //_Action = Request.QueryString["Action"];
                GetcbBoxJson();
            }
            if (Request.QueryString["mode"] == "Select")
            {
                Select();
            }
        }
        public void GetTJson()
        {
            string str = "select ID,Recipient,Title,Content,Date,ReadUser,Temp_File,Add_User_Name from sqb_message";
            mytable = SqlQuery.GetDataTable(str);
            result = dt2Json.Dtb2Json(mytable);

            Response.Write(result);
            Response.End();
        }

        public void GetcbBoxJson()
        {
            string str = "select id,UserName as text from sqb_users";
            mytable = SqlQuery.GetDataTable(str);

            result = dt2Json.Dtb2Json(mytable);

            Response.Write(result);
            Response.End();
        }


        public void Delete()
        {
            string sqlStr = "DELETE sqb_message WHERE ID=" + _id;
            if (sqlDML.DML(sqlStr) > 0)
            {
                Response.Write(GetDJson());
                Response.End();
            }
        }
        public string GetDJson()
        {
            string sqlStr = "select * from sqb_message  WHERE ID=" + _id;
            mytable = SqlQuery.GetDataTable(sqlStr);


            return dt2Json.Dtb2Json(mytable);
            Response.Write(result);
            Response.End();
        }

        public void Select()
        {
            //string RecipientCode = "";
           // string addUserCode = "";

            string searchs = Request.QueryString["searchs"];
            string searche = Request.QueryString["searche"];
            //string recipient = this.abcdef.Value;

            string addUserid = Request.QueryString["Add_User_Name"];//得到用户的IDAdd_User_ID
            string addUserName = Request.QueryString["Add_User_Name1"];//得到用户的名字Add_User_Name1
            string Recipient = Request.QueryString["Recipient"];//得到接受人Recipient

            if (addUserName == "") { addUserName = " Add_User_Name like '%%'"; }
            else { addUserName = " Add_User_Name='" + addUserName + "'"; }

            if (Recipient == "") { Recipient = " and Recipient like '%%'"; }
            else { Recipient = " and Recipient like '%" + Recipient + "%'"; }
            
            JavaScriptSerializer Jss = new JavaScriptSerializer();
            List<Dictionary<string, object>> TreeJson = new List<Dictionary<string, object>>();
            String sqlstr="";
            String sql = "";
            DataTable tb_rowcout = new DataTable();


            if (searchs == "" || searche == "")
            {
                sqlstr = "select ID,Recipient,Title,Content,Date,ReadUser,Temp_File,Add_User_Name from sqb_message order by Add_User_Name";
                sql = "select count(*) from sqb_message";
            }
            else
            {
                //构造sql 语句
                sqlstr = "select ID,Recipient,Title,Content,Date,ReadUser,Temp_File,Add_User_Name from sqb_message " +
                   "where (" + addUserName + Recipient+ ") and date between '" + searchs + "' and '" + searche + "' ";//
                sql = "select count(*) from sqb_message where (" + addUserName + Recipient + ") and date between '" + searchs + "' and '" + searche + "'";//
            }
            mytable = SqlQuery.GetDataTable(sqlstr);

            foreach (DataRow Dr in mytable.Rows)
            {
                Dictionary<string, object> Drow = new Dictionary<string, object>();

                Drow.Add("ID", Dr["ID"].ToString());
                Drow.Add("Recipient", Dr["Recipient"].ToString());
                Drow.Add("Title", Dr["Title"].ToString());
                Drow.Add("Content", Dr["Content"].ToString());
                Drow.Add("Date", Dr["Date"].ToString());
                Drow.Add("ReadUser", Dr["ReadUser"].ToString());
                Drow.Add("Temp_File", Dr["Temp_File"].ToString());
                Drow.Add("Add_User_Name", Dr["Add_User_Name"].ToString());
                TreeJson.Add(Drow);
            }
            tb_rowcout = SqlQuery.GetDataTable(sql);
            //json数据返回
            Response.Write("{ \"total\":" + tb_rowcout.Rows[0][0].ToString() + ",\"rows\":" + Jss.Serialize(TreeJson) + "}");

            Response.End();


//            if ((recipient != null || timestart != null) && timeend != null && addUser != null)
//            {
//                search = @"select ID,Recipient,Title,Content,Date,ReadUser,Temp_File,Add_User_Name from sqb_message 
//                            where Date >=" + timestart + "and Date <= " + timeend + "and Recipient like '%" + recipient + "'% and Add_User_Name = " + addUser;
//            }
//            else
//            {

//                if (recipient == null && addUser != null)
//                {
//                    search = @"select ID,Recipient,Title,Content,Date,ReadUser,Temp_File,Add_User_Name from sqb_message 
//                            where Date >=" + timestart + "and Date <= " + timeend + "and Add_User_Name = " + addUser;
//                }
//                if (addUser == null && recipient != null)
//                {
//                    search = @"select ID,Recipient,Title,Content,Date,ReadUser,Temp_File,Add_User_Name from sqb_message 
//                            where Date >=" + timestart + "and Date <= " + timeend + "and recipient like '%" + recipient + "'%";
//                }
//                if (addUser != null && recipient != null)
//                {
//                    search = @"select ID,Recipient,Title,Content,Date,ReadUser,Temp_File,Add_User_Name from sqb_message 
//                            where Date >=" + timestart + "and Date <= " + timeend;
//                }
//            }
//            mytable = SqlQuery.GetDataTable(search);

        }
    }
}