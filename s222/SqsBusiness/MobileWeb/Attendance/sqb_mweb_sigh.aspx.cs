using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Web.Services;
using System.IO;

namespace SqsBusiness.MobileWeb.Attendance
{
    public partial class sqb_mweb_sigh : System.Web.UI.Page
    {

        #region 定义
        SqlDML sqlDML = new SqlDML();

        string _uid;
        #endregion

        #region 事件
        //Load事件
        protected void Page_Load(object sender, EventArgs e)
        {
            //object userID=Session["User_ID"];
            if (Session["SqbMwebUserID"] == null)
            {
                Response.Redirect("../sqb_mweb_login.aspx");
            }
            _uid = Session["SqbMwebUserID"].ToString(); ;
        }

        //保存
        protected void save_Click(object sender, EventArgs e)
        {
            string filetype = fulPhoto.PostedFile.ContentType; //文件类型
            //string username = Session["SqbMwebUserName"].ToString(); //用户名
            string date = DateTime.Now.Date.ToString("yyyy年MM月dd日");
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //string ddd = photo_type.Items[0].Text;
            //string dddd = photo_type.Items[1].Text; 
            string filename = signType.SelectedItem.Text.ToString() + datetime + Path.GetExtension(fulPhoto.FileName); //文件名

            if (fulPhoto.HasFile)
            {

                if (filetype.Contains("image"))
                {
                    if (!Directory.Exists(Server.MapPath("~/MobileWeb/Attendance/Photo/" + _uid + "/")))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/MobileWeb/Attendance/Photo/" + _uid + "/"));
                    }

                    string path = Server.MapPath("~/MobileWeb/Attendance/Photo/" + _uid + "/") + filename;

                    try
                    {
                        fulPhoto.SaveAs(path);
                        string sqlInsert = "INSERT INTO [sqb_attendance]" +
                          "([User_ID]" +
                          ",[Classes_ID]" +
                          ",[Sign_Time]" +
                          ",[Sign_Photo_Path]" +
                          ",[Note]" +
                          ",[SignType])" +
                          "VALUES" +
                          "(" + _uid +
                          "," + "1" +//班次ID    未修改
                          ",Convert(DateTime,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')" +
                          ",'" +_uid+"/"+filename+ "'" +//照片路劲 未修改
                          ",'" + this.comment.Value + "'" +
                          ",'" + this.signType.SelectedItem.Text.Trim().ToString() + "')";
                        if (sqlDML.DML(sqlInsert) > 0)
                        {
                            //Response.Write("<script>alert('保存成功')</script>");
                            //location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI("用户名或密码错误！");
                            Response.Redirect("../Dialog/dialog_error.aspx?errormsg=保存成功");
                            Response.Redirect("sqb_mweb_attendance_manage.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('保存失败')</script>");
                        }


                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('保存失败')</script>");
                    }
                }

                else
                {
                    //Response.Write("<script>alert('格式不正确')</script>");
                    Response.Redirect("../Dialog/dialog_error.aspx?errormsg=请先拍照");
                }

            }
            else
            {
                Response.Redirect("../Dialog/dialog_error.aspx?errormsg=请先拍照");
            }
        }
        #endregion

        #region 自定义函数

        #endregion
    }
}