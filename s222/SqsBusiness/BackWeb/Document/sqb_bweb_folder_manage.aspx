<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_folder_manage.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Document.sqb_bweb_folder_manage" %>

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
        var url;
        var getAllow = "";
        $(function () {
            $('#tt').tree({
                url: 'sqb_bweb_folder_tree.ashx?type=<%= _type %>',
                lines: true,
                animate: true,
                onClick: function (node) {
                    $.ajax({
                        type: "POST",
                        url: "sqb_bweb_folder_manage.aspx",
                        data: { getFolder: "true", id: node.id, getAllow: true },
                        dataType: "json",
                        success: function (gjson) {
                            add();
                            $("#folderName").val(gjson[0].Name);
                            $("#pf").combotree("setValue", gjson[0].Pid);
                            $("#id").val(gjson[0].ID);
                            getAllow = gjson[0].Allow_Content;
                            var arrAllow = getAllow.split(",");
                            for (var i = 0; i < arrAllow.length; i++) {
                                $("#dg").datagrid("selectRecord", arrAllow[i]);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) { $.messager.alert('错误提示', errorThrown, 'error'); }
                    });
                }
            });

            $('#pf').combotree({
                url: 'sqb_bweb_folder_tree.ashx?type=<%= _type %>',
                lines: true,
                animate: true
            });

            $("#dg").datagrid({
                url: "sqb_bweb_folder_manage.aspx?getUsers=",
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
        });

        function add() {
            $("#folderName").val("");
            $("#id").val("");
            $("#dg").datagrid("unselectAll");
        }

        function del() {
            if ($("#id").val() != "") {
                $.messager.confirm('提示', '你确定要删除吗?', function (r) {
                    if (r) {
                        $.ajax({
                            type: "POST",
                            url: "sqb_bweb_folder_manage.aspx",
                            data: { action: 'del', id: $("#id").val() },
                            success: function (result) {
                                alert("保存成功");
                                $("#tt").tree("reload");
                                $("#pf").combotree("reload");
                                add();
                            },
                            error: function () {
                                alert("保存失败");
                            }
                        });
                    }
                });
            }
        }

        function save() {
            if ($('#folderName').val() == "") {
                alert("文件名称不能为空");
                return false;
            }
            if ($('#pf').combotree('getValue') == "") {
                alert("文件目录不能空");
                return false;
            }
            if ($('#pf').combotree('getValue') == $("#id").val()) {
                alert("操作有误,不能保存在自身文件夹");
                return;
            }
            var allow = ',';
            var rows = $('#dg').datagrid('getSelections');
            for (var i = 0; i < rows.length; i++) {
                allow = allow + rows[i].ID + ',';
            }
            $.ajax({
                type: "POST",
                url: "sqb_bweb_folder_manage.aspx",
                data: { pid: $('#pf').combotree('getValue'), action: 'update', folderName: $('#folderName').val(), id: $("#id").val(), allow: allow, type: "<%=_type%>" },
                success: function (result) {
                    alert("保存成功");
                    $("#tt").tree("reload");
                    $("#pf").combotree("reload");
                    add();
                },
                error: function () {
                    alert("保存失败");
                }
            });
        }

        function query() {
            var tree_obj = $('#zuzhijg').combotree('tree').tree('getChecked');
            var allid = "";
            $(tree_obj).each(function (i) {
                allid = allid + tree_obj[i].id + ",";
            })
            $("#dg").datagrid({
                url: "sqb_bweb_folder_manage.aspx?getUsers=" + allid,
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
<body style="margin: 0px; padding: 0px" class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'west',title:'文件夹管理',split:true" style="width: 150px;">
        <ul id="tt" class="easyui-tree">
        </ul>
    </div>
    <div data-options="region:'center',title:'文件夹管理'">
        <div id="cc" class="easyui-layout" fit="true">
            <div data-options="region:'north',title:'文件夹信息'" style="height: 120px;">
                <table border="0" width="80%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="left">
                            <a class="easyui-linkbutton" iconcls="icon-add" plain="true" id="add" onclick="add()">
                                新建文件夹</a> <a class="easyui-linkbutton" iconcls="icon-cut" plain="true" id="del" onclick="del()">
                                    删除</a> <a class="easyui-linkbutton" iconcls="icon-edit" plain="true" id="save" onclick="save()">
                                        保存</a><a class="easyui-linkbutton" iconcls="icon-back" plain="true" id="return" href="sqb_bweb_document_manage.aspx?type=<%= _type %>">返回文件管理</a>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 5px; text-align: left">
                                <tr>
                                    <td valign="top">
                                        <table border="0" cellspacing="0" class="pubtable">
                                            <tr>
                                                <asp:HiddenField ID="id" runat="server" />
                                                <td class="table-column-one" align="right">
                                                    文件夹名称：
                                                </td>
                                                <td>
                                                    <input style="width: 123px;" type="text" id="folderName" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="table-column-one" align="right">
                                                    父级目录：
                                                </td>
                                                <td>
                                                    <ul id="pf" class="easyui-tree">
                                                    </ul>
                                                </td>
                                            </tr>
                                            <tr>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div data-options="region:'center',title:'权限管理'">
                <table id="dg" fit="true">
                </table>
            </div>
            <div id="tb">
                组织架构:
                <select id="zuzhijg" class="easyui-combotree" name="language" data-options="url:'../Route/sqb_bweb_rount_dayline_tree.ashx',cascadeCheck:true"
                    multiple style="width: 130px;">
                </select>
                <a id="query" onclick="query()" class="easyui-linkbutton" data-options="iconCls:'icon-search'">
                    查询</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
