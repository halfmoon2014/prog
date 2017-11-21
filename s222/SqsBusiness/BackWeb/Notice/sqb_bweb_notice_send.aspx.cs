using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
using System.Data.SqlClient;
namespace SqsBusiness.BackWeb.Notice
{
    public partial class sqb_bweb_notice_send : System.Web.UI.Page
    {

        string _Notice_Content;
        public string _pid;
        int _Notice_Type_ID;
        string _TiTle = string.Empty;
        // string _Active_Time = "";
        int _ID;
        int _id;
        string _Add_User;
        string _action;
        SqlQuery sqlQuery = new SqlQuery();
        SqlDML sqlDML = new SqlDML();
        DataTable Mytable = new DataTable();
        DataTableToJson dt2Json = new DataTableToJson();
        string a = "";
        string Date = DateTime.Today.Date.ToString();
        string table = "select * from sqb_notice";
        int i = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            _TiTle = this.Title.Value;// 得到标题
            _Notice_Content = this.Notice_Content.Value;//得到内容
            _Notice_Type_ID = Int32.Parse(this.Notice_Type_ID.Value);//得到新闻类型ID
            _Add_User = this.Add_User.Value;//得到新闻发送人姓名

            string strID = "select * from sqb_notice";
            Mytable = sqlQuery.GetDataTable(strID);
            _ID = Mytable.Rows.Count;//插入时数据的ID号
            
            if (Request.QueryString["ID"] != null)
            {
                //得到选择行的ID
                _id = Int32.Parse(Request.QueryString["ID"]);

               
                string sqlse = "select ID,Title,Notice_Content,Notice_Type_ID,Active_Time,Add_User_Name from sqb_notice where ID = " + _id;
                Mytable = sqlQuery.GetDataTable(sqlse);
                this.Title.Value = Mytable.Rows[0][1].ToString();
                this.Notice_Content.Value = Mytable.Rows[0][2].ToString();
                this.Notice_Type_ID.Value = Mytable.Rows[0][3].ToString();
                this.Active_Time.Value = Mytable.Rows[0][4].ToString();
                this.Add_User.Value = Mytable.Rows[0][5].ToString();

            }
            else {
                _TiTle = this.Title.Value;
                _Notice_Content = this.Notice_Content.Value;
                _Notice_Type_ID = Int32.Parse(this.Notice_Type_ID.Value);
                _Add_User = this.Add_User.Value;
                string Date = DateTime.Today.Date.ToString();
            }
                if (Request.QueryString["action"] != null)
                {
                    _action = Request.QueryString["action"];
                }

                switch (_action)
                {
                    case null:
                        a = "save";
                        break;

                    case "edit":
                        a = "edit";
                        break;
                }
               
            }
            
        

        protected void save_Click(object sender, EventArgs e)
        {
            switch (a)
            {
                case "save":
                    save1();
                    break;
                case "edit": 
                    edit(); 
                    break;
            }

            _TiTle = this.Title.Value;
            _Notice_Content = this.Notice_Content.Value;
            _Notice_Type_ID = Int32.Parse(this.Notice_Type_ID.Value);
            _Add_User = this.Add_User.Value;

            Mytable = sqlQuery.GetDataTable(table);

            if (i != 0)
            {
                this.Label1.Text = "保存成功";
                Response.Write("");
            }
            else
            {
                this.Label1.Text = "保存失败";
            }

        }
        //public void edit()
        //{
        //    string sqlstr = "update sqb_notice set Title = '你好' where ID = 4";
        //}
        public void save1()
        {
            i = 0;
            string sql = "select ID from sqb_notice";
            Mytable = sqlQuery.GetDataTable(sql);
            i = Mytable.Rows.Count;
            string _id = Mytable.Rows[i - 1][0].ToString();
            int id = Int32.Parse(_id)+1;

            string SqlInsert = "insert into [sqb_notice] ([ID],[Date],[Title],[Notice_Type_ID],[Notice_Content],[Add_User_Name])" +
                "values ("+id+",'" + Date + "','" + _TiTle + "'," + _Notice_Type_ID + ",'" + _Notice_Content + "','" + _Add_User + "')";

            i += sqlQuery.sqlselect(SqlInsert);
        }




        public void edit()
        {

            string strsql = "update sqb_notice set Title = '" + _TiTle + "', Notice_Content='" + _Notice_Content + "', Notice_Type_ID=" + _Notice_Type_ID + " , Add_User_Name = '" + _Add_User + "' , Date = '" + Date + "' where ID = " + _id + "";
           
            i += sqlQuery.sqlselect(strsql);

        }
        public void Delete()
        {
            string sqlStr = "DELETE sqb_notice WHERE ID=" + _id;
            if (sqlDML.DML(sqlStr) > 0)
            {
                Response.Write(GetJson());
                Response.End();
            }
            else
            {

            }
        }
        public string GetJson()
        {
            string sqlStr = "select Title,Notice_Content,Notice_Type_ID,Date,Active_Time,Add_User_Name from sqb_notice WHERE ID=" + _pid;
            Mytable = sqlQuery.GetDataTable(sqlStr);
            return dt2Json.Dtb2Json(Mytable);

        }
        public void GetDocumentJson()
        {
            string str = "select Title,Notice_Content,Notice_Type_ID,Date,Active_Time,Add_User_Name from sqb_notice";
            Mytable = sqlQuery.GetDataTable(str);

            string result = "";
            result = dt2Json.Dtb2Json(Mytable);

            Response.Write(result);
            Response.End();

        }
    }
}