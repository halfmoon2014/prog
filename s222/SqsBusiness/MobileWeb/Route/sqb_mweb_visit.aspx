<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_visit.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Route.sqb_mweb_visit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <title>客户拜访</title>

    <script type="text/javascript">
        $(function () {
            $("a").click(function () {
                switch (this.id) { 
                    case ("backmain"):
                        location.href = "../sqb_mweb_main.aspx";            //返回到主页面
                        break;
                    case ("dayline"):
                        location.href = "sqb_mweb_dayline.aspx?manage=xianwai&type=" + this.id;        //进入当日路线页面
                        break;
                    case ("line"):
                        location.href = "sqb_mweb_client_select.aspx?manage=xianwai&type=" + this.id;     //进入线外拜访查询页面
                        break;
                    case ("home"):
                        location.href = "../sqb_mweb_main.aspx";                //主页
                        break;
                    case ("logout"):
                        location.href = "../sqb_mweb_login.aspx";               //注销
                        break;
                }
            })

        })
    </script>
</head>
<body>
 <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form_visit" runat="server">
    <div data-role="page" id="page_visit">
        <div data-theme="c" data-role="header" data-position="fixed">
            <a data-role="button" data-transition="fade" data-theme="c" 
                data-icon="back" data-iconpos="left" class="ui-btn-left" id="backmain">返回 </a>
            <h1>
                客户拜访
            </h1>
        </div>
        <div data-role="content" style="padding: 15px">
            <a data-role="button" data-transition="fade" runat="server" id="dayline"
                data-icon="ios-pack-color-star" data-iconpos="left" data-iconsize="26" >计划内路线
            </a><a data-role="button" data-transition="fade"  runat="server" id="line"
                data-icon="ios-pack-color-star" data-iconpos="left" data-iconsize="26" >计划外路线
            </a>
          
        </div>
        

        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a id="home" data-role="button" data-icon="home">主页</a> 
            <a id="logout" data-role="button" data-icon="delete">注销</a>
                
        </div>
    </div>
    </form>
</body>
</html>
