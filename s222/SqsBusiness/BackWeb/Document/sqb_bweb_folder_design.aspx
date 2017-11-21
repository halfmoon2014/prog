<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_folder_design.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Document.sqb_bweb_folder_design" %>

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
            $('#tt').combotree({
                url: 'sqb_bweb_folder_tree.ashx',
                lines: true,
                animate: true
            });

            $("#dg").datagrid({
                url: "sqb_bweb_folder_design.aspx?mode=getUsers"
            });

            $('#tt').combotree("setValue", "<%= _pid %>");

        });

        function save() {
            if ($('#folderName').val() == "") {
                alert("文件名称不能为空");
                return false;
            }
            if ($('#tt').combotree('getValue') == "") {
                alert("文件目录不能空");
                return false;
            }
            $.ajax({
                type: "POST",
                url: "sqb_bweb_folder_design.aspx",
                data: { pid: $('#tt').combotree('getValue'), action: 'update', folderName: $('#folderName').val(),id:'<%= _id %>'},
                success: function (result) {
                    alert("保存成功");
                    $("#tt").combotree("reload");
                    //location.href = "Dialog/dialog_error.aspx?errormsg=" + encodeURI("用户名或密码错误！");
                },
                error: function () {
                    alert("保存失败");
                }
            });
        }

        
        function del() {
            if ("<%= _id %>"!="") {
                $.messager.confirm('提示', '你确定要删除吗?', function (r) {
                    if (r) {
                        $.ajax({
                            type: "POST",
                            url: "sqb_bweb_folder_design.aspx",
                            data: { action: 'del', id: '<%= _id %>' },
                            success: function (result) {
                                alert("保存成功");
                                $("#tt").combotree("reload");
                            },
                            error: function () {
                                alert("保存失败");
                            }
                        });
                    }
                });
            }
        }
    </script>
    <style type="text/css">
        .table-column-one
        {
            height: 20px;
            color: #3366cc;
            font-size: 12px;
        }
    </style>
</head>
<body style="margin: 0px; padding: 0px">
    <form id="form1" runat="server">
    <table border="0" width="80%" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left">
                <a class="easyui-linkbutton" iconcls="icon-add" plain="true" id="add" href="sqb_bweb_folder_design.aspx"
                    target="_self">创建新文件夹</a> <a class="easyui-linkbutton" iconcls="icon-cut" plain="true"
                        id="del" onclick="del()">删除</a> <a class="easyui-linkbutton" iconcls="icon-edit"
                            plain="true" id="save" onclick="save()">保存</a>
            </td>
        </tr>
        <tr>
            <td align="left">
                <table border="0" cellpadding="0" cellspacing="0" style="margin-top: 5px; text-align: left">
                    <tr>
                        <td valign="top">
                            <table border="0" cellspacing="0" class="pubtable">
                                <tr>
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
                                        <ul id="tt" class="easyui-tree">
                                        </ul>
                                    </td>
                                </tr>
                                <tr>
                                    <table id="dg" class="easyui-datagrid" style="width: 778px; height: 574px" rownumbers="true"
                                        toolbar="#tb">
                                        <thead>
                                            <tr>
                                                <th field="UserName" width="140">
                                                    用户名
                                                </th>
                                                <th field="Allow_Content" checkbox="true">
                                                    权限
                                                </th>
                                            </tr>
                                        </thead>
                                    </table>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
