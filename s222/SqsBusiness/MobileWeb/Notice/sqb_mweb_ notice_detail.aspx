<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_ notice_detail.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.sqb_mweb__Notice_detail" %>

<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>公告明细</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#reback,#home,#logout,#sendmsg").click(function () {
                switch (this.id) {
                    case "reback":
                        location.href = "sqb_mweb_notice_release.aspx";
                        break
                    case "home":
                        location.href = "../sqb_mweb_main.aspx";
                        break
                    case "logout":
                        location.href = "../sqb_mweb_login.aspx";
                        break

                }
            })
        })
    </script>
</head>
<body>
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <form id="form1" runat="server">
    <!-- 公告详细 -->
    <div data-role="page" id="page13">
        <div data-theme="c" data-role="header">
            <h3>
                公告详细
            </h3> 
            <a data-role="button" data-inline="true" data-transition="fade" id="reback" class="ui-btn-left" >
                返回 </a>
        </div>
        <div data-role="content" style="padding: 15px">
        </div>
        <div data-role="fieldcontain">
            <fieldset data-role="controlgroup">
                <label for="text1">
                    新闻标题:
                </label>
                <input id="text1" value="" type="text" runat="server"/>
            </fieldset>
        </div>
        <div data-role="fieldcontain">
            <fieldset data-role="controlgroup">
                <label for="text2">
                内容:
                </label>
                <textarea id="text2" runat="server" style="clip: rect(auto, auto, auto, 0px); width: 93%;"></textarea>
            </fieldset>
        </div>
        <div data-role="fieldcontain">
            <fieldset data-role="controlgroup">
                
            </fieldset>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a data-role="button" data-icon="home" id="home">主页</a> <a data-role="button" data-icon="delete"
                id="logout">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
