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
    public partial class sqb_mweb_client_list : System.Web.UI.Page
    {
        protected string manage;
        protected string code;
        protected string name;
        protected string address;
        protected string type;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack) {
                loadinfo();
            }

        }

        private void loadinfo()
        {

            SqlQuery SqlQuery = new SqlQuery();
            DataTable MyTable = new DataTable();

            //从URL中接收传递过来的客户编号，客户名称，客户地址
            //并存储在相应的变量当中
            manage = Request.QueryString["manage"];
            code = Request.QueryString["code"];
            name = Request.QueryString["name"];
            address = Request.QueryString["address"];
            type=Request.QueryString["type"];

            //判断URL是否有传递值过来，如果没有（为空值）;
            string sql;

            //    //根据参数条件查询所有满足条件的所有记录
            if (string.IsNullOrEmpty(code))
            {
                 sql = "select code,name,address,mobile from sqb_client where user_id=" + Session["SqbMwebUserID"] + " and code like '%" + code + "%' and name like '%" + name + "%' and address like '%" + address + "%'";

            }
            else {
                 sql = "select code,name,address,mobile from sqb_client where user_id=" + Session["SqbMwebUserID"] + " and code like '%" + code.Replace("'", "’") + "%' and name like '%" + name.Replace("'", "’") + "%' and address like '%" + address.Replace("'", "’") + "%'";

            }
                //执行查询，将数据保存到临时表MyTable中
            MyTable = SqlQuery.GetDataTable(sql);           




            //以下是动态在HTML前台页面添加数据控件
            var newslabel = new Label();

            newslabel.Text = "<div data-role=collapsible-set>";
            for (int I = 0; I < MyTable.Rows.Count; I++)
            {

                newslabel.Text = newslabel.Text +
                   "<div data-role=collapsible>" +
                   "<h3>" + MyTable.Rows[I]["name"] + "</h3>" +
                   "<fieldset data-role='controlgroup'>" +
                   "<label for='client_code_" + I.ToString() + "'>客户地址：</label><input type='text' name='client_code_" + I.ToString() + "' id='client_code' value='" + MyTable.Rows[I]["address"] + "' readonly='readonly' runat='server' /></fieldset>" +
                   "<fieldset data-role='controlgroup'>" +
                   "<label for='client_name_" + I.ToString() + "'>联系电话：</label><input type='text' name='client_name_" + I.ToString() + "' id='client_code' value='" + MyTable.Rows[I]["mobile"] + "' readonly='readonly' runat='server' /></fieldset>" +
                   //"<fieldset data-role='controlgroup'>" +
                   //"<label for='client_address_" + I.ToString() + "'>客户地址：</label><input type='text' name='client_address_" + I.ToString() + "' id='client_code' value='" + MyTable.Rows[I]["address"] + "' readonly='readonly' runat='server' /></fieldset>" +
                   "<div class=ui-grid-a><div class=ui-block-a><a onclick=loadinfo('" + MyTable.Rows[I]["code"] + "') data-role=button data-icon=home data-theme=b>查看资料</a>" +
                   "<a onclick=kehuyc('" + MyTable.Rows[I]["code"] + "') data-role=button data-icon=home data-theme=b>客户异常</a></div>" +
                   "<div class=ui-block-b><a onclick=dianhuabf('" + MyTable.Rows[I]["code"] + "') data-role=button data-icon=home data-theme=b>电话拜访</a>" +
                   "<a onclick=shangmenbf('" + MyTable.Rows[I]["code"] + "') data-role=button data-icon=home data-theme=b>上门拜访</a></div></div></div>";


            }


            newslabel.Text = newslabel.Text + "</div>";
            //添加控件
            this.pnlist.Controls.Add(newslabel);

        }
    }
    }
