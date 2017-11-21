<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SqsBusiness._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业管家</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="/mobileweb/js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="/mobileweb/css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="/mobileweb/js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("a").click(function () {
                switch (this.id) {
                    case "backweb":
                        location.href = "/backweb/sqb_bweb_login.aspx";
                        break
                    case "mobileweb":
                        location.href = "/mobileweb/sqb_mweb_login.aspx";
                        break
                }
            });
        })
    </script>
</head>
<body>
    <form id="form_Default" runat="server">
    <div data-role="page" id="page_login" data-title="企业管家" data-theme="c">
        <div data-role="header" data-position="inline" data-position="fixed" data-theme="c">
            <h1>
                企业管家</h1>
        </div>
        <div data-role="content">
            <a data-role="button" data-icon="home" id="backweb">后台管理登录</a> <a data-role="button"
                data-icon="home" id="mobileweb">前台管理登录</a>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <h1>
                商齐软件</h1>
        </div>
    </div>
    </form>
</body>
</html>
