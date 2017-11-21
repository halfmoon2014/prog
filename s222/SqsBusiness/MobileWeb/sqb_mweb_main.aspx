<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_main.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.sqb_mweb_main" %>

<%@ Register Src="WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>主界面</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("a").click(function () {
                switch (this.id) {
                    case "visit":
                        location.href = "Route/sqb_mweb_visit.aspx"
                        break
                    case "document":
                        location.href = "Document/sqb_mweb_document_manage.aspx"
                        break
                    case "notice":
                        location.href = "Notice/sqb_mweb_notice_release.aspx"
                        break
                    case "client":
                        location.href = "Route/sqb_mweb_client_select.aspx?manage=manage"
                        break
                    case "attendance":
                        location.href = "Attendance/sqb_mweb_attendance_manage.aspx"
                        break
                    case "system":
                        location.href = "Sys/sqb_mweb_system_set.aspx"
                        break
                    case "reback":
                        location.href = "sqb_mweb_login.aspx"
                        break
                }
            })
        })
    </script>
</head>
<body>
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form_main" runat="server">
    <div data-role="page" id="page_client_select" data-title="主界面" data-theme="c">
        <div data-role="header" data-position="inline" data-position="fixed" data-theme="c">
            <h1>
                企业管家</h1>
            <a data-role="button" data-transition="fade" data-icon="back" class="ui-btn-left"
                id="reback">注销</a>
        </div>
        <div data-role="content">
            <div class="ui-grid-a">
                <div class="ui-block-a">
                    <a data-role="button" data-transition="fade" id="visit">客户拜访 </a><a data-role="button"
                        data-transition="fade" id="document">文档管理 </a><a data-role="button" data-transition="fade"
                            id="notice">新闻公告 </a>
                </div>
                <div class="ui-block-b">
                    <a data-role="button" data-transition="fade" id="client">客户管理 </a><a data-role="button"
                        data-transition="fade" id="attendance">考勤管理 </a><a data-role="button" data-transition="fade"
                            id="system">系统设置 </a>
                </div>
            </div>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <h1>
                商齐软件</h1>
        </div>
    </div>
    </form>
</body>
</html>
