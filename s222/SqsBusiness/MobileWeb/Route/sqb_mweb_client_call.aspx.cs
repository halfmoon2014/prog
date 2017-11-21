using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataClass;
using System.Data;
namespace SqsBusiness.MobileWeb.Route
{


    /*
     * 1、页面初始化，为相应的全局变量赋值,判断当前的类型：当日路线(dayline)和线外拜访(line)    -----过程名：loadinfo
     * 2、当日路线:  将已安排的工作内容从表中提取，显示在相应的文本框中                         -----过程名：isdayline
     * 3、线外拜访:
     *    (1)查询是否有未完成的任务，如果有，则读取到文本框中,变量AddOrUpdate的值为False        -----过程名：isline
     *    (2)如果变量AddOrUpdate为false，且工作内容不为空的情况下，                             -----过程名：Content_update          
     *       则单击按钮时触发Content_update事件，更新操作      
     *    (3)否则，触发Content_add事件，添加操作                                                -----过程名：Content_add
     * 4、离开事件：更新拜访表的LeaveDate的日期为服务器的当前时间，代表该任务已完成             -----过程名：btnleave_Click
     */



    public partial class sqb_mweb_client : System.Web.UI.Page
    {
        protected String type = "";                 //类型（当日路线和线外拜访）
        protected String pattern = "";              //状态：（客户异常、电话拜访和上门拜访）
        protected String code = "";                 //客户编号
        SqlQuery SqlQuery = new SqlQuery();         //实例化执行SQL语句的函数
        DataTable linetable = new DataTable();      //临时表
        protected String sql = null;                //SQL语句
        protected String manage = "";
        protected String client_id = "";            //客户ID
        protected String Users_id = "";             //用户ID
        protected String jobcontent = "";           //工作内容
        protected String id = "";                   //工作内容表的记录ID
        protected Boolean AddOrUpdate = true;       //判断是线外拜访是添加还是更新
        protected int i;
        protected string process;                   //判断该页面是从客户列表跳转过来还是从客户信息页面跳转过来
        protected Boolean luxianend = false;              //判断是否结束拜访
        protected void Page_Load(object sender, EventArgs e)
        {

            loadinfo();

        }

        /// <页面初始化>
        /// 页面初始化
        /// </页面初始化>
        private void loadinfo()
        {

            process = Request.QueryString["process"];                       //得到从跳转的识别代码
            Users_id = Session["SqbMwebUserID"].ToString();                 //用户ID
            manage = Request.QueryString["manage"];
            type = Request.QueryString["type"];                             //得到当前模式：当日路线和线外拜访
            pattern = Server.UrlDecode(Request.QueryString["pattern"]);     //得到当前类型：客户异常、电话拜访、上门拜访
            code = Request.QueryString["code"];                             //得到当前客户的编号

            //根据客户编号得出发该客户编号的客户ID
            sql = "select id from sqb_client where code='" + code + "' and user_id=" + Users_id;
            linetable = SqlQuery.GetDataTable(sql);


            client_id = linetable.Rows[0][0].ToString();        //客户ID




            jobcontent = Job_Content.Text.ToString().Trim();    //工作内容

            if (type == "dayline" && pattern == "客户异常")       //如果当前模式为当日路线，则执行以下语句           
            {
                //表单上的文本框为只读状态，因为事先已接到派工，不可修改
                call_datatime.Attributes.Add("ReadOnly", "readonly");
                Job_Content.Attributes.Add("ReadOnly", "readonly");
                isdayline();        //执行当日路线过程

                if (jobcontent.Trim().ToString() != "")
                {
                    //根据当天时间，离开时间为空，类型相同、客户ID，查询是否已存在记录
                    sql = "select id from sqb_client_call where client_id='" + client_id + "' and user_id='" + Users_id + "' and call_type='" + pattern + "' and call_mode='" + type + "' and CONVERT(varchar(100), date, 23)='" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "' and leavedate is null";
                    linetable = SqlQuery.GetDataTable(sql);
                    id = linetable.Rows[0]["ID"].ToString();
                }
            }
            else  
            {

                //如果模式为线外拜访，日期文本框为只读状态
                call_datatime.Attributes.Add("ReadOnly", "readonly");
                this.call_datatime.Value = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");        //取得当前服务器时间
                isline();       //执行线外拜访过程
            }

        }


        /// <当日路线>
        /// 当日路线，读取已安排的工作内容
        /// </summary>
        private void isdayline()
        {

            Job_Content.Text = "";

            if (client_id != "")
            {
                //构造SQL语句，查询当前用户的当天日期的工作内容
                sql = "select date,job_content from sqb_client_call where user_id=" + Users_id + " and CONVERT(varchar(100), date, 23)='" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "' and call_mode='" + type + "' and call_type='" + pattern + "' and client_id='" + client_id + "' and leavedate is null";
                //执行SQL
                linetable = SqlQuery.GetDataTable(sql);

                if (linetable.Rows.Count > 0)
                {
                    //显示在相应的TextBox框中
                    this.call_datatime.Value = linetable.Rows[0][0].ToString();
                    Job_Content.Text = linetable.Rows[0][1].ToString();
                }
            }


        }


        /// <线外拜访>
        /// 构造sql语句,查询出当天的工作是否都有完成
        /// 如果没有，则将工作内容显示在textbox上，可执行更新
        /// 否则，为添加新的工作内容
        /// 
        /// </summary>
        private void isline()
        {

            //根据当天时间，离开时间为空，类型相同、客户ID，查询是否已存在记录
            sql = "select date,job_content,leavedate,id from sqb_client_call where client_id='" + client_id + "' and user_id='" + Users_id + "' and call_type='" + pattern + "'and call_mode='" + type + "' and CONVERT(varchar(100), date, 23)='" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "' and leavedate is null";
            linetable = SqlQuery.GetDataTable(sql);
            //如果linetable有记录，则将记录显示在相应的文本框中
            //AddOrUpdate为false时，则为更新状态
            //AddOrUpdate为True时，则为添加状态
            if (linetable.Rows.Count > 0)
            {
                this.call_datatime.Value = linetable.Rows[0][0].ToString();
                Job_Content.Text = linetable.Rows[0][1].ToString();
                id = linetable.Rows[0][3].ToString();
                AddOrUpdate = false;
            }
            else
            {
                AddOrUpdate = true;
            }


        }


      



        /// <拍照保存、执行更新或添加>
        /// 保存或更新工作内容后，跳转到拍照页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnpz_Click(object sender, EventArgs e)
        {



            //判断工作内容是否为空，如果为空，则提示
            if (jobcontent.Trim().ToString() == "")
            {
                lblmsg.Visible = true;
                lblmsg.Text = "工作内容不能为空！";
                //Response.Redirect("../Dialog/dialog_error.aspx?errormsg=" + Server.UrlEncode("工作内容不能为空，请返回！")); 
            }
            else
            {
                if (type == "dayline" && pattern == "客户异常")
                {//如果为当日路线，则直接跳转到拍照页面
                    if (jobcontent.Trim().ToString() != "")
                    {
                        Response.Redirect("sqb_mweb_takephoto.aspx?manage=" + manage + "&process=" + process + "&type=" + type + "&client_call_id=" + Server.UrlEncode(id) + "&pattern=" + pattern + "&code=" + code);
                    }
                }
                //如果为线外拜访，则根据AddOrUpdate的值来判断是否为更新状态还是添加状态
                else
                {
                    Content_AddOrUpdate();      //执行添加或更新事件

                }

            }
        }






        /// <添加或更新工作内容>
        /// 添加新的工作内容和更新工作内容
        /// </summary>
        private void Content_AddOrUpdate()
        {

            String guid = System.Guid.NewGuid().ToString();
            if (AddOrUpdate == true)        //添加状态，构造SQL插入语句
            {
                sql = "insert into sqb_client_call(id,client_id,date,user_id,call_type,call_mode,job_content,add_user_id,add_time) values('" + guid + "','" + client_id + "','" + this.call_datatime.Value + "','" + Users_id + "','" + pattern + "','" + type + "','" + jobcontent.Replace("'", "‘") + "','" + Users_id + "','" + this.call_datatime.Value + "')";
                AddOrUpdate = false;

            }
            else
            {                               //更新状态，构造SQL更新语句
                sql = "update sqb_client_call set id='" + guid + "',job_content='" + jobcontent + "',update_user_id='" + Users_id + "',update_time='" + DateTime.Now.ToString() + "' where id='" + id + "'";
                AddOrUpdate = true;

            }

            i = SqlQuery.sqlselect(sql);
            //判断数据录入是否成功，如果成功，则跳转到拍照页面
            if (i == 0)
            {

                //如果不成功，则给出提示，工作内容失败
                lblmsg.Visible = true;
                lblmsg.Text = "工作内容保存失败！请重新输入！";
            }
            else
            {
                Response.Redirect("sqb_mweb_takephoto.aspx?manage=" + manage + "&process=" + process + "&type=" + type + "&client_call_id=" + Server.UrlEncode(guid.ToString()) + "&pattern=" + Server.UrlEncode(pattern) + "&code=" + code);
            }
        }








        /// <离开事件>
        /// 更新数据库中的离开时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnleave_Click(object sender, EventArgs e)
        {
          
                sql = "update sqb_client_call set leavedate='" +  DateTime.Now.ToString()+ "' where id='" + id + "'";

                i = SqlQuery.sqlselect(sql);

               if (i!=0){

                   if (process=="list"){
               Response.Redirect( "sqb_mweb_client_list.aspx?manage="+ manage +"&type="+ type +"&process="+ process +"");
                }
            else if(process=="daylist"){
                Response.Redirect("sqb_mweb_dayline.aspx?manage=" + manage + "&type=" + type + "&process=" + process + "");
            }else{
                Response.Redirect("sqb_mweb_client_info.aspx?manage=" + manage + "&type=" + type + "&code=" + code);
            }
  
               }
               else
               {
                   lblmsg.Visible = true;
                    lblmsg.Text="离开记录事件失败！数据库未有该工作内容！";
               }
            }

        }
       
    }
