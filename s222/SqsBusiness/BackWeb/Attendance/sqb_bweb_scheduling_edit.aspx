<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_scheduling_edit.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Attendance.sqb_bweb_scheduling_edit" %>

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
            $("#dg").datagrid({
                url: "sqb_bweb_scheduling_edit.aspx?getUsers=true"
            });

            $("#dg").datagrid({
                url: "sqb_bweb_scheduling_edit.aspx?getUsers=true",
                idField: 'ID',
                fitColumns: true,
                toolbar:'#tb',
                rownumbers: "true",
                pagination: true,
                columns: [[
                    { field: 'UserName', title: '用户名', width: 100 },
                    { field: 'ID', title: '权限', width: 100, checkbox: true }
                    ]]
            });

            $("#SignIn").timespinner("setValue", '<%= _signIn %>');
            $("#SignOut").timespinner("setValue", "<%= _signOut %>");
        });

        function save() {
            if (checkTime()) {
                var allow = ',';
                var allowName = ',';
                var rows = $('#dg').datagrid('getSelections');
                for (var i = 0; i < rows.length; i++) {
                    allow = allow + rows[i].ID + ',';
                    allowName = allowName + rows[i].UserName + ',';
                }

                $.ajax({
                    type: "POST",
                    url: "sqb_bweb_scheduling_edit.aspx",
                    data: { action: "update", name: $("#Name").val(), signIn: $("#SignIn").timespinner("getHours") + ':' + $("#SignIn").timespinner("getMinutes") + $("#SignIn").timespinner("getSeconds"), signOut: $("#SignOut").timespinner("getHours") + ':' + $("#SignOut").timespinner("getMinutes") + $("#SignOut").timespinner("getSeconds"), id: "<%= _id %>", userID: allow, allowName: allowName },
                    success: function (result) {
                        alert("保存成功");
                        location.href = "sqb_bweb_scheduling_set.aspx";
                    },
                    error: function () {
                        alert("保存失败");
                    }
                });
            }
        }

        function checkTime() {
            if ($("#Name").val() == "") {
                alert("排班名称不能为空");
                return false;
            }
            if ($("#SignIn").timespinner("getHours") < 0 || $("#SignIn").timespinner("getHours") > 23 || $("#SignIn").timespinner("getMinutes") < 0 || $("#SignIn").timespinner("getMinutes") > 59 || $("#SignIn").timespinner("getSeconds") < 0 || $("#SignIn").timespinner("getSeconds") > 59) {
                alert("签到时间格式不正确");
                return false;
            }
            if ($("#SignOut").timespinner("getHours") < 0 || $("#SignOut").timespinner("getHours") > 23 || $("#SignOut").timespinner("getMinutes") < 0 || $("#SignOut").timespinner("getMinutes") > 59 || $("#SignOut").timespinner("getSeconds") < 0 || $("#SignOut").timespinner("getSeconds") > 59) {
                alert("签到时间格式不正确");
                return false;
            }
            return true;
        }
        function load() {
            getAllow = "<%= _getUserID %>";
            var arrAllow = getAllow.split(",");
            for (var i = 0; i < arrAllow.length; i++) {
                $("#dg").datagrid("selectRecord", arrAllow[i]);
            }
        }

        function query() {
            var tree_obj = $('#zuzhijg').combotree('tree').tree('getChecked');
            var allid = "";
            $(tree_obj).each(function (i) {
                allid = allid + tree_obj[i].id + ",";
            })
            $("#dg").datagrid({
                url: "sqb_bweb_getUserJson.ashx?getUsers=" + allid,
                toolbar: "#tb",
                idField: 'ID',
                rownumbers: "true",
                toolbar: '#tb',
                pagination: true,
                fitColumns: true,
                columns: [[
        { field: 'UserName', title: '用户名', width: 100 },
        { field: 'ID', title: '权限', width: 100, checkbox: true }
    ]]

            });

        }
    </script>
</head>
<body onload="load()" style="margin: 0px; padding: 0px" class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'north',title:'排班设置'" style="height: 180px;">
        <div>
            <a id="save" class="easyui-linkbutton" iconcls="icon-ok" onclick="save()">保存</a>
            <a class="easyui-linkbutton" iconcls="icon-cancel" onclick="javascript:location.href='sqb_bweb_scheduling_set.aspx'">
                取消</a>
            <table>
                <tr>
                    <asp:HiddenField ID="id" runat="server" />
                    <td text-align="right">
                        <label>
                            排班名称：</label>
                    </td>
                    <td>
                        <input type="text" id="Name" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td text-align="right">
                        <label>
                            签到时间：</label>
                    </td>
                    <td>
                        <input id="SignIn" class="easyui-timespinner" style="width: 80px;" required="required"
                            data-options="showSeconds:true" />
                    </td>
                </tr>
                <tr>
                    <td text-align="right">
                        <label>
                            签退时间：</label>
                    </td>
                    <td>
                        <input id="SignOut" class="easyui-timespinner" style="width: 80px;" required="required"
                            data-options="showSeconds:true" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right">
                        <label>
                            假期：</label>
                    </td>
                    <td>
                        <ul>
                        </ul>
                    </td>
                </tr>
                <tr>
                    <td text-align="right">
                        <label>
                            登录签到:</label>
                    </td>
                    <td>
                        <input type="checkbox" id="LoginSign" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div data-options="region:'center',title:'当班用户'">
        <table id="dg" fit="true">
        </table>
        <div id="tb">
                组织架构:
                <select id="zuzhijg" class="easyui-combotree" name="language" data-options="url:'../Route/sqb_bweb_rount_dayline_tree.ashx',cascadeCheck:true"
                    multiple style="width: 130px;">
                </select>
                <a id="query" onclick="query()" class="easyui-linkbutton" data-options="iconCls:'icon-search'">
                    查询</a>
            </div>
    </div>
    </form>
</body>
</html>
sqb_bweb_getUserJson