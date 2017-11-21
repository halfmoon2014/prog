<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_login.aspx.cs"
    Inherits="SqsBusiness.BackWeb.sqb_bweb_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业管家</title>
    <%--JS引用--%>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.cookie.js"></script>
    <%--当前页面的JS代码,注意顺序，用到JQuery所以要先引用JQuery--%>
    <script type="text/javascript" src="/backweb/js/backweb/sqb_bweb_login.js"></script>
    <%--样式引用--%>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
    <link href="/backweb/css/backweb/sqb_bweb_login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form_login" runat="server">
    <div class="loginfrm">
        <div class="logintop">
            <div class="logintopfont">
                商齐软件*企业管家</div>
        </div>
        <div class="loginfooter">
            <div style="padding-left: 125px;">
                <table width="327" border="0">
                    <tr>
                        <td width="58" height="25" align="right" valign="middle">
                            用户名：
                        </td>
                        <td height="25" colspan="5" valign="middle">
                            <input type="text" name="username" id="username" class="logintxt" value="" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" valign="middle">
                            密码：
                        </td>
                        <td height="25" colspan="5" valign="middle">
                            <input type="password" name="password" id="password" class="logintxt" value="" />
                        </td>
                    </tr>
                    <tr>
                        <td height="35" align="right" valign="middle">
                            <input type="checkbox" id="loginsave" />
                        </td>
                        <td valign="middle" height="35" colspan="5">
                            记住登录信息
                            <input type="button" id="loginok" value="登录" class="bt" />
                            <input type="button" id="loginreset" value="清除" class="bt" />
                        </td>
                    </tr>
                </table>
            </div>
            <p align="center" style='color: #e60000; margin-top: 55px;'>
            </p>
        </div>
    </div>
    </form>
</body>
</html>
