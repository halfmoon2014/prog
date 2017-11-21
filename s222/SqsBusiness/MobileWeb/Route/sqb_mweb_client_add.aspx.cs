using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;

namespace SqsBusiness.MobileWeb.Client
{
    public partial class sqb_mweb_client_add : System.Web.UI.Page
    {
        SqlQuery SqlQuery = new SqlQuery(); //查询类
        SqlDML SqlDML = new SqlDML(); //操作类
        protected string RClientID; //客户ID
        protected string RAddType; //传递类型
        protected string RUrlRes; //来源的URL
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                RClientID = Server.UrlDecode(Request.QueryString["ClientID"]);
                RAddType = Server.UrlDecode(Request.QueryString["AddType"]);
                RUrlRes = Request.UrlReferrer.AbsoluteUri;

                if (RAddType == "客户编辑")
                {
                    loadinfo(RClientID); //读取客户信息
                }
            }

            if (Request.Form["mode"] == "saveuser")
            {
                string stype = Request.Form["stype"];
                string cid = Request.Form["cid"];
                string ccode = Request.Form["ccode"];
                string cname = Request.Form["cname"];
                string caddress = Request.Form["caddress"];
                string clinkman = Request.Form["clinkman"];
                string cphone = Request.Form["cphone"];
                string cmobile = Request.Form["cmobile"];
                string cemail = Request.Form["cemail"];
                string cacreage = Request.Form["cacreage"];
                string clongitude = Request.Form["clongitude"];
                string clatitude = Request.Form["clatitude"];
                //保存客户信息
                saveinfo(stype, cid, ccode, cname, caddress, clinkman, cphone, cmobile, cemail, cacreage, clongitude, clatitude);
            }
        }

        /// <summary>
        /// 读取客户信息
        /// </summary>
        /// <param name="code">客户ID</param>
        protected void loadinfo(string RClientID)
        {
            DataTable client_table = new DataTable();

            string Sqlstr = "Select * From sqb_client Where ID=" + RClientID;
            client_table = SqlQuery.GetDataTable(Sqlstr);

            if (client_table.Rows.Count > 0)
            {
                this.code.Value = client_table.Rows[0]["code"].ToString();
                this.name.Value = client_table.Rows[0]["name"].ToString();
                this.address.Value = client_table.Rows[0]["address"].ToString();
                this.linkman.Value = client_table.Rows[0]["linkman"].ToString();
                this.phone.Value = client_table.Rows[0]["phone"].ToString();
                this.mobile.Value = client_table.Rows[0]["mobile"].ToString();
                this.email.Value = client_table.Rows[0]["email"].ToString();
                this.acreage.Value = client_table.Rows[0]["acreage"].ToString();
                this.longitude.Value = client_table.Rows[0]["longitude"].ToString();
                this.latitude.Value = client_table.Rows[0]["latitude"].ToString();
            }
        }

        /// <summary>
        /// 保存客户信息
        /// </summary>
        protected void saveinfo(string stype, string cid, string ccode, string cname, string caddress, string clinkman, string cphone, string cmobile, string cemail, string cacreage, string clongitude, string clatitude)
        {

            string SqlString = "";
            string SelectString = "";
            string uid = Session["SqbMwebUserID"].ToString();
            DataTable ClientTable = new DataTable();
            string DD = caddress;
            //判断必填字段是否为空，不为空则进行添加保存或修改保存
            if (ccode.Trim() == "" || cname.Trim() == "" || caddress.Trim() == "")
            {
                Response.Write("saveisnull");
                Response.End();
            }
            else
            {


                if (stype == "新增客户")
                {
                    SelectString = "Select * From sqb_client Where code='" + ccode + "'";
                }
                else
                {
                    SelectString = "Select * From sqb_client Where ID=" + cid;
                }

                ClientTable = SqlQuery.GetDataTable(SelectString);

                if (stype == "新增客户")
                {
                    if (ClientTable.Rows.Count > 0) //如果客户存在
                    {
                        Response.Write("ClientExist"); //反回值"客户存在"
                    }
                    else
                    {
                        SqlString = "Insert Into sqb_client (code,name,address,linkman,phone,mobile,email,acreage,longitude,latitude,user_id,add_user_id,add_time) Values('" + ccode.Trim() + "','" + cname.Trim() + "','" + caddress.Trim() + "','" + clinkman.Trim() + "','" + cphone.Trim() + "','" + cmobile.Trim() + "','" + cemail.Trim() + "','" + cacreage.Trim() + "','" + clongitude.Trim() + "','" + clatitude.Trim() + "','" + uid.Trim() + "','" + uid.Trim() + "','" + DateTime.Now + "')";

                        if (SqlDML.DML(SqlString) > 0)
                        {
                            Response.Write("savetrue"); //反回成功
                        }
                        else
                        {
                            Response.Write("savefalse"); //反回值失败
                        }
                    }
                }
                else
                {
                    if (ClientTable.Rows.Count > 0) //如果客户存在
                    {
                        SqlString = "Update sqb_client set code='" + ccode.Trim() + "',name='" + cname.Trim() + "',address='" + caddress.Trim() + "',linkman='" + clinkman.Trim() + "',phone='" + cphone.Trim() + "',mobile='" + cmobile.Trim() + "',email='" + cemail.Trim() + "',acreage='" + cacreage.Trim() + "',longitude='" + clongitude.Trim() + "',latitude='" + clatitude.Trim() + "',update_user_id='" + uid.Trim() + "',update_time='" + DateTime.Now + "' Where ID=" + cid;

                        if (SqlDML.DML(SqlString) > 0)
                        {
                            Response.Write("savetrue"); //反回成功
                        }
                        else
                        {
                            Response.Write("savefalse"); //反回值失败
                        }
                    }
                    else
                    {
                        Response.Write("ClientNoExist"); //反回值"客户不存在"
                    }
                }

                Response.End();//停止其他输出
            }
        }
    }
}