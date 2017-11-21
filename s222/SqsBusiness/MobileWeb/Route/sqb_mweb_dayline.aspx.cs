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
    public partial class sqb_mweb_dayline : System.Web.UI.Page
    {
      
        protected string manage;
        protected string type;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) {
                loadinfo();
            }
        }


        private void loadinfo() {
            manage=Request.QueryString["manage"];
            SqlQuery SqlQuery = new SqlQuery();


            manage = Request.QueryString["manage"];
            type = Request.QueryString["type"];
            //根据当前系统日期及用户id查询出用户当天的工作路线，存储在临时表MyTable中

            DataTable MyTable = new DataTable();
            String sql = "select code,name,address,mobile from plan_list where CONVERT(varchar(100), date, 23)='" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "' and user_id=" + Session["SqbMwebUserID"];
            MyTable = SqlQuery.GetDataTable(sql);

            //根据表每个单元格，构造HTML代码使之形成下拉页面，将MyTable的值赋进去

            Label labelist = new Label();
            labelist.Text = "<div data-role=collapsible-set>";
            for (int I = 0; I< MyTable.Rows.Count; I++)
            {

                labelist.Text = labelist.Text +
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

            labelist.Text = labelist.Text + "</div>";
            //在HTML中的PANEL中添加该下拉框
            this.pnlist.Controls.Add(labelist);   
        }
    }
}