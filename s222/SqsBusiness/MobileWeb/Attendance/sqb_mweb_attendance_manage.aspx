<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_attendance_manage.aspx.cs" Inherits="SqsBusiness.MobileWeb.Attendance.sqb_mweb_attendance_manage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>考勤管理</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
</head>

<body>    
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form_attendance_manage" runat="server">
    <div data-role="page" id="page_client_list" data-title="考勤管理" data-theme="c">
        <div data-role="header" data-position="inline" data-position="fixed" data-theme="c">
            <h1>
                考勤管理</h1>
            <a onclick="javascript:location.href='../sqb_mweb_main.aspx'" data-icon="back" class="ui-btn-left">返回</a>
        </div>
        <div data-role="content">
            <div data-role="collapsible-set">
                <a data-role="button" onclick="javascript:location.href='sqb_mweb_sigh.aspx'">签到签退</a>
                <a data-role="button" onclick="javascript:location.href='sqb_mweb_attendance.aspx'">考勤查询</a>
            </div>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a onclick="javascript:location.href='../sqb_mweb_main.aspx'" data-role="button" data-icon="home">主页</a>
            <a onclick="javascript:location.href='../sqb_mweb_login.aspx'" data-role="button" data-icon="delete">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
