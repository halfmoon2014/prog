<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_client_select.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Route.sqb_mweb_client_select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <title>客户查询</title>
    <script type="text/javascript">
    var manage=<%="'"+ manage +"'"%>;
  
        $(function () {
            //返回按钮，返回到客户拜访页面
            $("#backvisit").click(function () {
            if (manage=="manage")
            {location.href = "../sqb_mweb_main.aspx";}
             else if (manage=="xianwai")
                {  location.href = "sqb_mweb_visit.aspx";}
                
            })
            //新增客户
            $("#client_add").click(function () {
                location.href = encodeURI("sqb_mweb_client_add.aspx?addtype=新增客户");
            })
            //查询
            $("#search").click(function () {
                var code = $("#client_code").val();      //得到表单上文本框的值
                var name = $("#client_name").val();
                var address = $("#client_address").val();
                location.href = "sqb_mweb_client_list.aspx?type=line&manage="+<%="'"+ manage +"'"%>+"&code=" + code + "&name=" + name + "&address=" + address;
            })
            //主页
            $("#home").click(function () {
                location.href = "../sqb_mweb_main.aspx";
            });
            //注销
            $("#logout").click(function () {
                location.href = "../sqb_mweb_login.aspx";
            });
        })
    </script>
</head>
<body>
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form_client_select" runat="server">
    <div data-role="page" id="page_client_select">
        <div data-theme="c" data-role="header" data-position="inline" data-position="fixed">
            <a data-role="button" data-transition="fade" data-icon="back" data-iconpos="left"
                class="ui-btn-left" runat="server" id="backvisit">返回 </a>
            <h3>
                客户查询
            </h3>
        </div>
        <div data-role="content">
            <div data-role="fieldcontain">
                <label for="client_code">
                    客户编号
                </label>
                <input id="client_code" placeholder="" value="" type="text" runat="server">
            </div>
            <div data-role="fieldcontain">
                <label for="client_name">
                    客户名称
                </label>
                <input id="client_name" placeholder="" value="" type="text" runat="server">
            </div>
            <div data-role="fieldcontain">
                <label for="client_address">
                    客户地址
                </label>
                <input id="client_address" placeholder="" value="" type="text" runat="server">
            </div>
         
            <a data-role="button" data-icon="search" id="search">查询客户</a>
             <a data-role="button" data-icon="add" id="client_add">新增客户</a>
            
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a id="home" data-role="button" data-transition="fade" data-icon="home" data-iconpos="left">
                主页</a> <a id="logout" data-role="button" data-transition="fade" data-icon="delete"
                    data-iconpos="left">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
