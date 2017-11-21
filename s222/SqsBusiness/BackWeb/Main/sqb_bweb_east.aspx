<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_east.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Main.sqb_bweb_east" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--JS引用--%>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <%--样式引用--%>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />

    <script type="text/javascript">
        $(function () {
            $("#easttoday").calendar({
                current: new Date()
            });
        });
    </script>
</head>
<body class="easyui-layout">
    <form id="form_east" runat="server">
    <div data-options="region:'north',border:'false'" style="width:170px;height: 180px; overflow: hidden;">
        <div id="easttoday" class="easyui-calendar" data-options="width:170,height:180,border:false"></div>
    </div>
    <div data-options="region:'south',border='false',title:'用户在线列表'" style="overflow: hidden;">
    </div>
    </form>
</body>
</html>
