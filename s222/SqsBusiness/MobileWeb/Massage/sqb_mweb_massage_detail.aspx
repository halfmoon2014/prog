<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_massage_detail.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Massage.sqb_mweb_massage_detail" %>

<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>短信详细</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#reback,#home,#logout").click(function () {
                switch (this.id) {
                    case "reback":
                        location.href = "sqb_mweb_massage_manage.aspx";
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
    <%--   <script type="text/javascript">
        $(function () {
            $("a").click(function () {
                switch (this.id) {
                 case "telephone": //电话拜访
                        location.href = "sqb_mweb_client_call.aspx?type=" + <%="'"+type+"'"%> + "&pattern="+encodeURI("电话拜访")+"&code=" + <%="'"+code+"'"%>;
                        break
                

             }
           })
        });
    </script>--%>
    <style type="text/css">
        #text1
        {
            width: 93%;
        }
    </style>
</head>
<body>
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <form id="form1" runat="server">
    <div data-role="page" id="page13">
        <div data-theme="c" data-role="header">
            <h3>
                短信详细
            </h3>
            <a data-role="button" data-transition="fade" id="reback" class="ui-btn-left">返回
            </a>
        </div>
        <div data-role="content">
        </div>
        <div data-role="fieldcontain">
            <fieldset data-role="controlgroup">
                <input id="text1" value="" type="text" runat="server" readonly="readonly" align="left" />
            </fieldset>
        </div>
        <div data-role="fieldcontain">
            <fieldset data-role="controlgroup">
                <textarea id="text2" runat="server" style="clip: rect(auto, auto, auto, 0px); width: 93%;"></textarea>
                <br />
                <br />
                &nbsp;</fieldset>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a data-role="button" data-icon="home" id="home">主页</a> <a data-role="button" data-icon="delete"
                id="logout" >注销</a>
        </div>
    </div>
    </form>
</body>
</html>
