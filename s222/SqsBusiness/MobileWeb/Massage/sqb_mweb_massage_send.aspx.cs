using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace SqsBusiness.MobileWeb
{
    public partial class sqb_mweb_massage_send : System.Web.UI.Page
    {
        SqlQuery SqlQuery = new SqlQuery();
        SqlConnection conn = new SqlConnection();
        private String sql;
        protected String type;
        protected String pattern;
        protected String code;
        protected void Page_Load(object sender, EventArgs e)
        {



            string sql = "select UserName,id from sqb_users";
            DataTable mytable = new DataTable();
            mytable = SqlQuery.GetDataTable(sql);
            //用循环语句画出个控件
            var newslabel = new Label();
            newslabel.Text = "<div data-role=collapsible-set data-theme= data-content-theme=><div data-role=collapsible><h3>联系人</h3><div data-role=fieldcontain>";
            for (int i = 0; i < mytable.Rows.Count; i++)
            {
                newslabel.Text = newslabel.Text + "<input id=checkbox" +
                     i + " type=checkbox runat=server><label for=checkbox" +
                     i + " runat=server id=lblcheckbox" + i + ">" + mytable.Rows[i][0] + "</label>";
            }//+ " value=" + mytable.Rows[i][1]
            newslabel.Text = newslabel.Text + "</div></div>";
            //"<a data-role=button data-inline=true  data-mini=true style=float:right onClick=add()>添加</a>
            this.Pnlist.Controls.Add(newslabel);


            if (!IsPostBack)
            {
                //try
                //{

                //}
                //catch (Exception ex)
                //{
                //    ex.Message.ToString();

                //}
                loadinfo();

            }
        }


        private void loadinfo()
        {


            DataTable MyTable = new DataTable();
            Label lbselect = new Label();
            //查询属性表中的拍照类型：门头，柜子等
            //动态添加到Panel控件中
            sql = "select * from sqb_message ";
            MyTable = SqlQuery.GetDataTable(sql);

            //photo_type.Items.Clear();
            //for (int i = 0; i < MyTable.Rows.Count; i++)
            //{
            //    ListItem type = new ListItem();
            //    type.Value = MyTable.Rows[i]["id"].ToString();
            //    type.Text = MyTable.Rows[i]["name"].ToString();
            //    photo_type.Items.Add(type);
            //}


        }




        protected void send_Click(object sender, EventArgs e)
        {


            
            String userid = Session["SqbMwebUserID"].ToString();//添加人ID
            string filetype = upfile.PostedFile.ContentType; //文件类型
            string Add_User_Name = Session["SqbMwebUserName"].ToString(); //用户名
            string datetime = DateTime.Now.Date.ToString("yyyy年MM月dd日");
            //string datetime = DateTime.Now.ToString("(yyyy年MM月dd日HH时mm分ss秒fff毫秒)");

            string title = this.tTltle.Value;//获得标题
            string content = this.tContent.Value;//获得内容
            DateTime date = DateTime.Now;//获得当前日期
            string filename = upfile.FileName;//文件名
            string file = System.IO.Path.GetExtension(filename);//文件后缀名
            //string filename = photo_type.Items[Int32.Parse(photo_type.Text)].Text + datetime + Path.GetExtension(upfile.FileName); //文件名
            //获得ID
            DataTable getid = new DataTable();
            string idstr = "select * from sqb_message";
            getid = SqlQuery.GetDataTable(idstr);
            int id = getid.Rows.Count;


            //得到接收人
            string Recipient = this.Recipient.Value.ToString();
            //string [] Recipientarr = strRecipient.Split(';');
            //string Recipient = null;

            //if (Recipientarr.Length < 2)
            //{
            //    Recipient = Recipientarr[0].ToString();
            //}
            //else
            //{
            //    for (int a = Recipientarr.Length;a>=0;a-- )
            //    {
            //        Recipient = Recipientarr[a].ToString() + ";" + Recipient;
            //    }
            //}

            int i = 0;
            string Temp_File = "";
            try
            {
                if (upfile.HasFile)//获取文件路径 判断文件是否存在
                {
                    if (file.Trim() != ".exe" && file.Trim() != ".bat")//判断是格式是否正确
                    {
                        if (!Directory.Exists(Server.MapPath("~/MobileWeb/message/" + Add_User_Name + "/" + datetime + "/")))
                        {
                            Directory.CreateDirectory(Server.MapPath("~/MobileWeb/message/" + Add_User_Name + "/" + datetime + "/"));
                        }
                        //bool boo = Directory.Exists("~/MobileWeb/Message/" + username + "/" + datetime + "/");
                        Temp_File = Server.MapPath("~/MobileWeb/Message/" + Add_User_Name + "/" + datetime + "/") + filename;
                        upfile.SaveAs(Temp_File);
                    }
                    else
                    {
                        Label2.Visible = true;
                        Label2.Text = "但文件格式有误，文件上传失败.";
                    }
                }

                if (Recipient != "")
                {
                    string str = "insert into sqb_message (Date,Title,Content,Recipient,ReadUser,Add_User_ID,Add_User_Name,Temp_File) values('" + date + "','" + title + "','" + content + "','" + Recipient.Trim() + "',''," + userid + ",'" + Add_User_Name + "','" + Temp_File + "')";
                    i += SqlQuery.sqlselect(str);
                    if (i != 0)
                    {
                        Label1.Visible = true;
                        Label1.Text = "短信发送成功.";
                    }
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "收件人不能为空，短信发送失败.";
                }

            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "短信发送失败.";
            }
            //if (file.Trim() != ".exe" && file.Trim() != ".bat")//判断上传类型是否符合标准
            //{
            //    if (upfile.HasFile)//获取文件路径 判断文件是否存在
            //    {
            //        if (!Directory.Exists("~/MobileWeb/Message/" + username + "/" + datetime + "/"))
            //        {
            //             Directory.CreateDirectory("~/MobileWeb/Message/" + username + "/" + datetime + "/");
            //        }
            //             string Temp_File = Server.MapPath("~/MobileWeb/Message/" + username + "/" + datetime + "/") + filename; 

            //    }
            //    try
            //    {
            //        upfile.SaveAs(Temp_File);
            //        if (i != 0)
            //        {
            //            Label1.Visible = true;
            //            Label1.Text = "数据保存成功.";
            //        }
            //    }

            //    catch (Exception ex)
            //    {
            //        Label1.Visible = true;
            //        Label1.Text = "文件上传不成功." + ex.Message;
            //    }

            //}
            //string str = "insert into sqb_message (Date,Title,Content,Recipient,Add_User_ID,Temp_File) values('" + date + "','" + title + "','" + content + "','" + Recipient + "'," + userid + ",'" + Temp_File + "')";
            //i += SqlQuery.sqlselect(str);
        }
    }
}
//if (file.Trim() != ".exe" && file.Trim() != ".bat")//判断上传类型是否符合标准
//{
//    if (upfile.HasFile)//获取文件路径 判断文件是否存在
//    {
//        if (!Directory.Exists(str1))
//        {
//            Directory.CreateDirectory(str1);
//        }
//    }
//    string Temp_File = Server.MapPath("~/MobileWeb/Message/" + username + "/" + datetime + "/") + filename;
//    try
//    {
//        upfile.SaveAs(Temp_File);
//        sql = "insert into sqb_message (Date,Title,Content,Recipient,Add_User_ID,Temp_File) values('" + date + "','" + title + "','" + content + "','" + Recipient + "'," + userid +",'"+Temp_File+"')";
//        i += SqlQuery.sqlselect(sql);
//        if (i != 0)
//        {
//            Label1.Visible = true;
//            Label1.Text = "数据保存成功.";
//        }
//    }
//    catch (Exception ex)
//    {
//        Label1.Visible = true;
//        Label1.Text = "文件上传不成功." + ex.Message;
//    }
//}


//else
//{
//    Label1.Visible = true;
//    Label1.Text = "该文件类型不能上传.";
//    try
//    {
//        //foreach (string str in Recipientarr)
//        //{
//        //    if (str.Trim() != "")
//        //    {
//        //        sql = "insert into sqb_message (Date,Title,Content,Recipient,Add_User_ID) values('" + date + "','" + title + "','" + content + "','" + str.Trim() + "'," + userid + ")";

//        //        i += SqlQuery.sqlselect(sql);
//        //    }
//        //}
//        sql = "insert into sqb_message (Date,Title,Content,Recipient,Add_User_ID) values('" + date + "','" + title + "','" + content + "','" + Recipient + "'," + userid + ")";
//        i += SqlQuery.sqlselect(sql);
//        if (i != 0)
//        {
//            Label1.Visible = true;
//            Label1.Text = "数据保存成功.";
//        }
//    }
//    catch (Exception ex)
//    {
//        Label1.Visible = true;
//        Label1.Text = "文件上传不成功." + ex.Message;
//    }
//}