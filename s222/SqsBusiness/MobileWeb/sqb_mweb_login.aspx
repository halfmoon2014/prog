<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_login.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.sqb_mweb_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业管家</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("a").click(function () {
                switch (this.id) {
                    case "login":
                        $.ajax({
                            type: "POST",
                            url: "sqb_mweb_login.aspx/login",
                            data: { mode: "chkuser", username: encodeURI($("#username").val()), password: encodeURI($("#password").val()) },
                            success: function (result) {
                                if (result == "true") {
                                    location.href = "sqb_mweb_main.aspx";
                                }
                                else {
                                    location.href = "Dialog/dialog_error.aspx?errormsg=" + encodeURI("用户名或密码错误！");
                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) { location.href = "Dialog/dialog_error.aspx?errormsg=" + encodeURI(errorThrown); }
                        });
                        break
                    case "reback":
                        $("#username").val("");
                        $("#password").val("");
                        break
                }
            });

            $(window).keydown(function (event) {
                if (event.keyCode == 13) {
                    $("#login").click();
                }
            })
        })
    </script>
</head>
<body>
    <form id="form_login" runat="server">
    <div data-role="page" id="page_login" data-title="企业管家" data-theme="c">
        <div data-role="header" data-position="inline" data-position="fixed" data-theme="c">
            <h1>
                企业管家</h1>
           
           
        </div>
        <div data-role="content">
            <div data-role="fieldcontain">
                <label for="username">
                    用户名:</label>
                <input type="text" name="username" id="username" value="" runat="server" />
            </div>
            <div data-role="fieldcontain">
                <label for="password">
                    密码:</label>
                <input type="password" name="password" id="password" value="" runat="server" />
            </div>
        </div>
        <div class="ui-grid-a">
            <div class="ui-block-a">
                <a data-role="button" data-icon="back" id="reback">重置</a>
            </div>
            <div class="ui-block-b">
                
                <a data-role="button" data-icon="search" id="login">登录</a>
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
