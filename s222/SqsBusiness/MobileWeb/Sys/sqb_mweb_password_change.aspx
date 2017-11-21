<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_password_change.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Sys.sqb_mweb_password_change" %>

<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改密码</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("a").click(function () {
                switch (this.id) {
                    case "save":
                        if ($("#newpass").val() != $("#chknewpass").val()) {
                            location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI("新密码两次输入不一致！");
                            return;
                        }

                        $.ajax({
                            type: "POST",
                            url: "sqb_mweb_password_change.aspx",
                            data: { mode: "PasswordChange", oldpass: encodeURI($("#oldpass").val()), newpass: encodeURI($("#newpass").val()) },
                            success: function (result) {
                                if (result == "true") {
                                    location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI("密码修改成功！");
                                }
                                else {
                                    location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI("旧密码错误！");
                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) { location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI(errorThrown); }
                        });
                        break
                    case "reback":
                        location.href = "sqb_mweb_system_set.aspx";
                        break
                    case "home":
                        location.href = "../sqb_mweb_main.aspx";
                        break
                    case "logout":
                        location.href = "../sqb_mweb_login.aspx";
                        break
                    case "reset":
                        $("#oldpass").val("");
                        $("#newpass").val("");
                        $("#chknewpass").val("");
                }
            })
        })

    </script>
</head>
<body>
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form_password_change" runat="server">
    <!-- 修改密码 -->
    <div data-role="page" id="page_password_change">
        <div data-theme="c" data-role="header">
            <h3>
                修改密码
            </h3>
            <a data-role="button" data-inline="true" data-rel="back" data-transition="fade" data-theme="c"
                id="reback" data-icon="back" data-iconpos="left" class="ui-btn-left">返回
            </a>
        </div>
        <div data-role="content" style="padding: 15px">
            <div data-role="fieldcontain">
                <fieldset data-role="controlgroup">
                    <label for="oldpass">
                        旧密码：
                    </label>
                    <input id="oldpass" placeholder="" value="" type="password" runat="server" />
                </fieldset>
            </div>
            <div data-role="fieldcontain">
                <fieldset data-role="controlgroup">
                    <label for="newpass">
                        新密码：
                    </label>
                    <input id="newpass" placeholder="" value="" type="password" runat="server" /></fieldset>
            </div>
            <div data-role="fieldcontain">
                <fieldset data-role="controlgroup">
                    <label for="chknewpass">
                        再次输入新密码：
                    </label>
                    <input id="chknewpass" placeholder="" value="" type="password" runat="server"></fieldset>
            </div>
            <a data-role="button" data-inline="true" data-transition="fade" id="save">保存 </a>
            <a data-role="button" data-inline="true" data-transition="fade" id="reset">重置 </a>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a data-role="button" data-icon="home" id="home">主页</a> <a data-role="button" data-icon="delete"
                id="logout" >注销</a></div>
    </div>
    </form>
</body>
</html>
