<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_massage_manage.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.sqb_mweb_massage_manage" %>

<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>短信管理</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#reback,#home,#logout,#sendmsg").click(function () {
                switch (this.id) {
                    case "reback":
                        location.href = "../Notice/sqb_mweb_notice_release.aspx";
                        break
                    case "home":c
                        location.href = "../sqb_mweb_main.aspx";
                        break
                    case "logout":
                        location.href = "../sqb_mweb_login.aspx";
                        break                   
                    case "sendmsg":
                        location.href = "sqb_mweb_massage_send.aspx";
                }
            })
        })
        function goto1(str) {
            location.href = "sqb_mweb_massage_detail.aspx?type=line&ID=" + str;
        };
    </script>
</head>
<body>
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <form id="sqb_massage_manage" runat="server">
    <!-- 短信管理 -->
    <div data-role="page" id="page14">
        <div data-theme="c" data-role="header">
            <a data-role="button" data-transition="fade" id="reback" class="ui-btn-left">返回
            </a>
            <h3>
                短信管理
            </h3>
        </div>
        <div data-role="content" style="padding: 15px">
            <div data-role="collapsible-set" data-theme="c" data-content-theme="">
                <div data-role="collapsible" data-collapsed="false">
                    <asp:Panel ID="Pnlist" runat="server">
                    </asp:Panel>
                </div>
                <div data-role="collapsible" data-collapsed="false">
                </div>
            </div>
            <a data-role="button" data-transition="fade" id="sendmsg" >发送信息 </a>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a data-role="button" data-icon="home" id="home" runat="server">主页</a> <a data-role="button" data-icon="delete"
                id="logout" runat="server">注销</a></div>
    </div>
    </form>
</body>
</html>
