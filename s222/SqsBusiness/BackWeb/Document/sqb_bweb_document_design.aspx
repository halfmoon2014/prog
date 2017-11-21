<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_document_design.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Document.sqb_bweb_document_design" %>

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
            $("#document").panel({
                closable: false,
                collapsible: true
            });

            $('#pf').combotree({
                url: 'sqb_bweb_folder_tree.ashx?type=<%= _type %>',
                lines: true,
                animate: true,
                width:155
            });

            $('#pf').combotree("setValue", "<%= _pid %>");
        });

        function save() {
            if ($('#documentName').val() == "") {
                alert("文件名称不能为空");
                return false;
            }
            if ($('#pf').combotree('getValue') == "") {
                alert("文件目录不能空");
                return false;
            }
            $("#hfFolderName").val($('#pf').combotree('getValue'));
            return true;
        }

        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="fitem">
        <label>
            文件名称:</label>
        <input type="text" id="documentName" runat="server" name="documentName" />
    </div>
    <div class="fitem">
        <label>
            文件目录:</label>
        <ul id="pf" class="easyui-tree">
        </ul>
        <asp:HiddenField ID="hfFolderName" runat="server" />
    </div>
    <div class="fitem">
        <asp:FileUpload ID="upfile" runat="server" />
    </div>
    <a id="save" class="easyui-linkbutton" iconcls="icon-ok" onclick="return save()"
        runat="server" onserverclick="save_Click">保存</a> <a class="easyui-linkbutton" iconcls="icon-cancel"
            onclick="javascript:location.href='sqb_bweb_document_list.aspx?pid=<%= _pid %>&type=<%= _type %>'">
            取消</a>
    </form>
</body>
</html>
