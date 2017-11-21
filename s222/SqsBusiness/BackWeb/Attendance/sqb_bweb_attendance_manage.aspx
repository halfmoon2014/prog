<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_attendance_manage.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Attendance.sqb_bweb_attendance_manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'north',title:'North Title',split:true" style="height: 100px;">
    </div>
    <div data-options="region:'south',title:'South Title',split:true" style="height: 100px;">
    </div>
    <div data-options="region:'east',iconCls:'icon-reload',title:'East',split:true" style="width: 100px;">
    </div>
    <div data-options="region:'west',title:'West',split:true" style="width: 100px;">
    </div>
    <div data-options="region:'center',title:'center title'" style="padding: 5px; background: #eee;">
    </div>
    </form>
</body>
</html>
