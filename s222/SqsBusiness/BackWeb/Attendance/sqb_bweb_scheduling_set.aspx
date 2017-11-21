<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_scheduling_set.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Attendance.sqb_bweb_scheduling_set" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
    <script type="text/javascript">
        $(function () {
            $('#scheduling').datagrid({
                iconCls: 'icon-edit',
                toolbar: '#tb',
                singleSelect: true,
                idField: 'ID',
                rownumbers: "true",
                pagination: true,
                fitColumns: true,
                url: 'sqb_bweb_scheduling_set.aspx?mode=getScheduling',
                columns: [[
					{ field: 'Name', title: '班次名称', width: 140 },
					{ field: 'SignIn_Time', title: '签到时间', width: 60 },
					{ field: 'SignOut_Time', title: '签退时间', width: 60 },
					{ field: 'Holiday', title: '假期', width: 140 },
                    { field: 'User_Name', title: '当班人员', width: 140 },
					{ field: 'ID', title: '操作', width: 80, align: 'center',
					    formatter: function (value, row, index) {
					        var e = '<a href="sqb_bweb_scheduling_edit.aspx?id=' + value + '">编辑</a> ';
					        var d = '<a href="#" onclick="deleterow(' + value + ')">删除</a>';
					        return e + d;
					    }
					}
				]]
            });

            $("#dgMana").datagrid({
                url: "sqb_bweb_scheduling_set.aspx?getUsers=true",
                idField: 'ID',
                toolbar: '#tbMana',
                pagination: true,
                rownumbers: "true",
                fitColumns: true,
                columns: [[
                    { field: 'UserName', title: '用户名', width: 100 },
                    { field: 'ID', title: '权限', width: 100, checkbox: true }
                ]]
            });


        });

        function deleterow(value) {
            $.messager.confirm('提示', '确定要删除吗?', function (r) {
                if (r) {
                    $.post('sqb_bweb_scheduling_set.aspx', { action: "del", id: value }, function (result) {
                        if (result) {
                            $('#scheduling').datagrid('reload');
                        } else {
                            $.messager.show({
                                title: 'Error',
                                msg: result.msg
                            });
                        }
                    }, 'json');
                }
            });
        }

        function save() {
            var allow = ',';
            var rows = $('#dgMana').datagrid('getSelections');
            for (var i = 0; i < rows.length; i++) {
                allow = allow + rows[i].ID + ',';
            }
            $.ajax({
                type: "POST",
                url: "sqb_bweb_scheduling_set.aspx",
                data: { allow: allow },
                success: function (result) {
                    alert("保存成功");
                },
                error: function () {
                    alert("保存失败");
                }
            });
        }

        function load() {
            getAllow = "<%= _getAllow %>";
            var arrAllow = getAllow.split(",");
            for (var i = 0; i < arrAllow.length; i++) {
                $("#dgMana").datagrid("selectRecord", arrAllow[i]);
            }
        }
    </script>
</head>
<body class="easyui-layout" onload="load()">
    <form id="form1" runat="server">
    <div data-options="region:'center' ">
        <div id="tabs" class="easyui-tabs" fit="true">
            <div title="排班设置" data-options="border:false">
                <table id="scheduling" fit="true">
                </table>
            </div>
            <div title="假期设置" data-options="border:false">
                tab2
            </div>
            <div title="设置考勤管理人员" data-options="border:false">
                <table id="dgMana" fit="true">
                </table>
            </div>
        </div>
    </div>
    <div id="tb">
        <a class="easyui-linkbutton" iconcls="icon-add" plain="true" id="add" href="sqb_bweb_scheduling_edit.aspx">
            新建排班</a>
    </div>
    <div id="tbMana" <%--style="height: 60px"--%>>
        <table>
            <tr>
                <a class="easyui-linkbutton" iconcls="icon-save" plain="true" id="save" onclick="save()">保存</a></tr>
            <tr>
                <td>
                    <%--<a class="easyui-linkbutton" iconcls="icon-search" plain="true" id="query">查询</a>--%>
                </td>
                
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
