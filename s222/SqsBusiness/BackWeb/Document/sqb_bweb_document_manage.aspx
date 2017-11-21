<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_document_manage.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Document.sqb_bweb_document_manage" %>

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
        $(function () {
            $('#tt').tree({
                url: 'sqb_bweb_folder_tree.ashx?type=<%= _type %>',
                lines: true,
                animate: true,
                onClick: function (node) {
                    $('#cc').attr('src', "sqb_bweb_document_list.aspx?pid=" + node.id + '&type=<%= _type %>');
                }
                
            });
        });

        function add() {
            location.href = 'sqb_bweb_document_design.aspx';

        }

        function save() {
            //alert($('#documentName').text());
            if ($('#documentName').val() == "") {
                alert("文件名称不能为空");
                return false;
            }
            if ($('#folderName').combotree('getValue') == "") {
                alert("文件目录不能空");
                return false;
            }
            alert($('#documentName').val());
            $("#Literal1").val($('#documentName').val());
            $("#Literal2").text($('#folderName').combotree('getValue'));
            return true;
        }
    </script>
</head>
<body style="margin: 0px; padding: 0px;" class="easyui-layout" fit:"true">
    <form id="form1" runat="server">
    <div data-options="region:'west',title:'<%= _title %>',split:true" style="width: 150px;">
        <ul id="tt" class="easyui-tree">
        </ul>
    </div>
    <div data-options="region:'center',title:'<%= _title %>'" >
    <iframe id="cc" frameborder="0" scrolling="no" style="width: 100%; height: 100%"
                        src="sqb_bweb_document_list.aspx?type=<%= _type %>"></iframe>
    </div>
    </form>
</body>
</html>
