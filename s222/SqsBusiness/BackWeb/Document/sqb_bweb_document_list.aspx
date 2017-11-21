<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_document_list.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Document.sqb_bweb_document_list" %>

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
            $('#tt').datagrid({
                iconCls: 'icon-edit',
                toolbar: "#tb",
                singleSelect: true,
                idField: 'ID',
                rownumbers: "true",
                fitColumns:true,
                pagination: true,
                nowrap:false,
                url: 'sqb_bweb_document_list.aspx?mode=1&pid=' + '<%= _pid %>&type=<%= _type %>',
                columns: [[
                { field: 'ID', title: 'ID', hidden: true },
					{ field: 'Name', title: '文件名称', width: 80 },
					{ field: 'UserName', title: '创建人', width: 60},
					{ field: 'Add_Time', title: '创建日期', width: 60, editor: { type: 'numberbox', options: { precision: 1}} },
					{ field: 'Update_Time', title: '上次修改日期', width: 60, editor: 'numberbox' },
					{ field: 'Document_Path', title: '下载', width: 40, align: 'center',
					    formatter: function (value, row, index) {
					        //var e = '<a href="javascript:downloadFile(../../MobileWeb/Document/Files/' + value + '")>下载</a> ';
                             var e = '<a href="../../MobileWeb/Document/Files/' + value + '">下载</a> ';
                            //var e = '<a href="javascript:downloadFile('+"'../../MobileWeb/Document/Files/" + value + "')"+'">下载</a> ';
					        //var e='<a href="javascript:downloadFile('+"'../../MobileWeb/Document/Files/1/20120903101153437.jpg'"+')">下载</>'
                            return e;
					    }
					}
				]]
            });
        });

        function del() {
            var row = $('#tt').datagrid('getSelected');
            if (row) {
                $.messager.confirm('提示', '你确定要删除吗?', function (r) {
                    if (r) {
                        $.post('sqb_bweb_document_list.aspx', { id: row.ID,pid:<%= _pid %> }, function (result) {
                            if (result) {
                                $('#tt').datagrid('reload'); 
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
        }

        function edit(){
            var row = $('#tt').datagrid('getSelected');
            if (row) {
                location.href="sqb_bweb_document_design.aspx?id="+row.ID+'&type=<%= _type %>';
            }
        }
    </script>
</head>
<body style="margin: 0px; padding: 0px" class="easyui-layout" >
    <form id="form1" runat="server">
    <div data-options="region:'center'" >
        <table id="tt" fit="true">
        </table>
        <div id="tb">
            <a class="easyui-linkbutton" iconcls="icon-add" plain="true" id="add" href="sqb_bweb_document_design.aspx?type=<%= _type %>"
                target="_self">添加</a> <a class="easyui-linkbutton" iconcls="icon-cut" plain="true"
                    id="del" onclick="del()">删除</a> <a class="easyui-linkbutton" iconcls="icon-edit"
                        plain="true" id="edit" onclick="edit()">修改</a> <a class="easyui-linkbutton" iconcls="icon-folder"
                            plain="true" id="folderManage" href="sqb_bweb_folder_manage.aspx?type=<%= _type %>"
                            target="_parent">文件夹管理</a>
        </div>
    </div>
    </form>
</body>
</html>
