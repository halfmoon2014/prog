<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_notice_release.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.sqb_mweb_notice__release" %>

<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#reback,#home,#logout,#message").click(function () {
                switch (this.id) {
                    case "reback":
                        location.href = "../sqb_mweb_main.aspx";
                        break
                    case "home":
                        location.href = "../sqb_mweb_main.aspx";
                        break
                    case "logout":
                        location.href = "../sqb_mweb_login.aspx";
                        break
                    case "message":
                        location.href = "../Massage/sqb_mweb_massage_manage.aspx";
                }
            })
        })
        function goto1(str) {
            location.href = "sqb_mweb_massage_detail.aspx?type=line&ID=" + str;
        };
    </script>
    <title>新闻公告</title>
    <script type="text/javascript">
        function goto1(i) {
            location.href = "sqb_mweb_ notice_detail.aspx?type=line&id=" + i;
        }
    </script>
</head>
<body>
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <form id="form1" runat="server">
    <!-- 新闻公告 -->
    <div data-role="page" id="page11">
        <div data-theme="c" data-role="header">
            <h3>
                新闻公告
            </h3>
            <a data-role="button" data-inline="true" data-transition="fade" id="reback" class="ui-btn-left" >
                返回 </a>
        </div>
        <div data-role="content" style="padding: 15px">
            <div data-role="collapsible-set" data-theme="" data-content-theme="">
                <div data-role="collapsible" data-collapsed="false">
                    <asp:Panel ID="Pnlist" runat="server">
                    </asp:Panel>
                </div>
            </div>
            <a data-role="button" data-transition="fade" data-icon="back" data-iconpos="left"
                class="ui-btn-left" runat="server" id="message">短信管理 </a>
            <%--<a id="massagem" name="massagem" data-role=button  data-transition=fade runat="server" href="~/MobileWeb/Massage/sqb_mweb_massage_manage.aspx" >短信管理</a>--%>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a data-role="button" data-icon="home" id="home">主页</a> <a data-role="button" data-icon="delete"
                id="logout">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
