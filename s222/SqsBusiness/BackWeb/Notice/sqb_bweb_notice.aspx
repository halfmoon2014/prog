<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="sqb_bweb_notice.aspx.cs" Inherits="SqsBusiness.BackWeb.Notice.sqb_bweb_notice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
        <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
    <script type="text/javascript" charset="utf-8">
        $(function () {
            $("#dg").datagrid({
                url: "sqb_bweb_notice.aspx"
            });
        });
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <div id="notice" title="新闻管理" style="width:100%;height:100%;">
        <table id="dg" class="easyui-datagrid" style="width:778px;height:574px" url="sqb_bweb_notice.aspx.ashx" rownumbers="true" toolbar="#tb" singleSelect="true">
            <tr>
				<th field="Title" width="140">标题</th>
				<th field="Notice_Content" width="80">内容摘要</th>
                <th field="Notice_Type" width="60">新闻类型</th>
				<th field="Date" width="140" align="right">发布时间</th>
				<th field="Active_Time" width="180" align="right">有效日期</th>
				<th field="Add_User" width="60">发布人</th>                
			</tr>
        </table>
        <div id="tb">
		<a class="easyui-linkbutton" iconCls="icon-add" plain="true" id="add" href="sqb_bweb_notice.aspx" target="_self" >添加</a>
		<a class="easyui-linkbutton" iconCls="icon-cut" plain="true" id="del" onclick="del()">删除</a>
		<a class="easyui-linkbutton" iconCls="icon-edit" plain="true" id="edit" onclick="edit()">修改</a>
	</div>
    </div>
    </form>
</body>
</html>
