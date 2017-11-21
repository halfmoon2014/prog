using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DataClass;
using System.Data;
namespace SqsBusiness.MobileWeb.Route
{
    public partial class sqb_mweb_takephoto : System.Web.UI.Page
    {
        SqlQuery SqlQuery = new SqlQuery();
        private String sql;
        protected String type;
        protected String pattern;
        protected String code;
        protected String manage;
        protected String process;
        protected String client_call_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadinfo();
            }

            
        }


        private void loadinfo() {
            //Session["SqbMwebUserID"] = "1";
            //Session["SqbMwebUserName"] = "123";
            manage = Request.QueryString["manage"];

            DataTable MyTable = new DataTable();
            Label lbselect = new Label();
            //查询属性表中的拍照类型：门头，柜子等
            //动态添加到Panel控件中
           
            sql = "select id, name from sqb_property where Property_Type='Photo_Type'";
            MyTable = SqlQuery.GetDataTable(sql);

            photo_type.Items.Clear();
            for (int i = 0; i < MyTable.Rows.Count; i++) {
                ListItem type = new ListItem();
                type.Value = MyTable.Rows[i]["id"].ToString();
                type.Text = MyTable.Rows[i]["name"].ToString();
                photo_type.Items.Add(type);
            }
          
          
        }



        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            
                String userid = Session["SqbMwebUserID"].ToString();
                string filetype = upfile.PostedFile.ContentType; //文件类型
                string username = Session["SqbMwebUserName"].ToString(); //用户名
                string date = DateTime.Now.Date.ToString("yyyy年MM月dd日");
                string datetime = DateTime.Now.ToString("(yyyy年MM月dd日HH时mm分ss秒fff毫秒)");
                //string ddd = photo_type.Items[0].Text;
                //string dddd = photo_type.Items[1].Text;
                string filename = photo_type.Items[Int32.Parse(photo_type.Text)-1].Text + datetime + Path.GetExtension(upfile.FileName); //文件名

                if (upfile.HasFile)
                {
                    client_call_id = Server.UrlDecode(Request.QueryString["client_call_id"]);
                    if (filetype.Contains("image"))
                    {
                        if (!Directory.Exists(Server.MapPath("~/MobileWeb/photos/" + username + "/" + date + "/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/MobileWeb/photos/" + username + "/" + date + "/"));
                        }

                        string path = Server.MapPath("~/MobileWeb/photos/" + username + "/" + date + "/") + filename;
                        
                        try
                        {
                            upfile.SaveAs(path);
                            string back_path = "../../MobileWeb/photos/" + username + "/" + date + "/" + filename;

                            Image2.ImageUrl = "~/MobileWeb/photos/" + username + "/" + date + "/" + filename;
                            int i;

                            sql = "insert into sqb_photo_news(Client_Call_ID,Date,Photo_Type_ID,Photo_Path,back_path,Note) values('" + client_call_id +
                                "','" + DateTime.Now + "','" + photo_type.Text.Replace("'", "‘") + "','" + path + "','"+back_path+"','" + txtbz.Text.Replace("'", "‘") + "')";
                            i = SqlQuery.sqlselect(sql);

                            if (i != 0)
                            {
                                lblmsg.Visible = true;
                                lblmsg.Text = "数据保存成功.";
                            }



                        }
                        catch (Exception ex)
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "文件上传不成功." + ex.Message;
                        }
                    }
                    else
                    {
                        lblmsg.Visible = true;
                        lblmsg.Text = "只能够上传图片文件.";
                    }

                }


         
        }

        protected void btnbackcall_Click(object sender, EventArgs e)
        {
            type = Request.QueryString["type"].ToString();
            pattern = Server.UrlDecode(Request.QueryString["pattern"]);
            code = Request.QueryString["code"].ToString();
            Response.Redirect("sqb_mweb_client_call.aspx?manage=" + Request.QueryString["manage"] + "&process=" + Request.QueryString["process"] + "&type=" + type + "&pattern=" + Server.UrlEncode(pattern) + "&code=" + code);

        }

       
    }
}