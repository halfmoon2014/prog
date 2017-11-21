<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_system_set.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Sys.sqb_mweb_system_set" %>

<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>系统设置</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        function back() {
            location.href = "../sqb_mweb_main.aspx";
        }
        function main() {
            location.href = "../sqb_mweb_main.aspx";
        }
        function page() {
            location.href = "sqb_mweb_system_setpage.aspx";
        }
        function password() {
            location.href = "sqb_mweb_password_change.aspx";
        }
    </script>
</head>
<body>
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <form id="form1" runat="server">
    <!-- 系统设置 -->
    <div data-role="page" id="page12">
        <div data-theme="c" data-role="header">
            <h3>
                系统设置
            </h3>
            <a data-role="button" data-transition="fade" onclick="back()" class="ui-btn-left">返回
            </a>
        </div>
        <div data-role="content" style="padding: 15px">
            <ul data-role="listview" data-divider-theme="c" data-inset="true">
                <li data-role="list-divider" role="heading">系统管理</li>
                <li data-theme="c"><a onclick="page()" data-transition="slide">组织架构 </a></li>
                <li data-theme="c"><a onclick="page()" data-transition="slide">角色管理 </a></li>
                <li data-theme="c"><a onclick="page()" data-transition="slide">用户管理 </a></li>
                <li data-theme="c"><a onclick="page()" data-transition="slide">属性列表 </a></li>
                <li data-theme="c"><a onclick="page()" data-transition="slide">系统设置 </a></li>
                <li data-theme="c"><a data-transition="slide" onclick="password()">修改密码 </a></li>
                    
            </ul>
            <input data-inline="true" value="保存" data-mini="true" type="submit">
            <input data-inline="true" value="重置" data-mini="true" type="submit">
            <%--<a data-role="button" data-transition="fade" onclick="password()">修改密码 </a>--%>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a data-role="button" data-icon="home" id="home">主页</a> <a data-role="button" data-icon="delete"
                id="logout">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
