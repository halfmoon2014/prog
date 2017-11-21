<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_notice_send.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Notice.sqb_bweb_notice_send" %>

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

        function save() {
            if ($('#Title').val() == "") {
                alert("标题不能为空");
                return false;
            }            
            return true;
        }
    </script>
</head>
<body>
    <form runat="server">
    <div class="panel window" style="display: block; width: 388px; left: 218px; top: 69px;
        z-index: 9026; position: absolute;">
        <div class="panel-header panel-header-noborder window-header" style="width: 388px;">
            <div class="panel-title" style="">
                新闻管理</div>
        </div>
        <div id="dlg" class="easui-dialog">
            <div class="fitem">
                <label>
                    标题:</label>
                <input type="text" id="Title" runat="server" name="Title" />
            </div>
            <div class="fitem">
                <label>
                    内容摘要:</label>
                    <input type="text" id="Notice_Content" runat="server" name="Notice_Content" />
                <%--<input required="true" class="easyui-validatebox validatebox-text" name="Notice_Content" />--%>
            </div>
            <div class="fitem">
                <label>新闻类型:</label>                    
                <%--<input name="Notice_Type" />--%>
                <input type="text" id="Notice_Type_ID" runat="server" name="Notice_Type_ID" 
                    value="1" />
            </div>
            <%--<div class="fitem">
                <label>
                    发布时间:</label>
                <input class="easyui-validatebox validatebox-text" name="Date" />
                <input type="text" id="Date" runat="server" name="Date" />
            </div>--%>
            <div class="fitem">
                <label>
                    有效日期:</label>
                <%--<input name="Active_Time" />--%>
                <input type="text" id="Active_Time" runat="server" name="Active_Time" />
            </div>
            <div class="fitem">
                <label>
                    发布人:</label>
               <%-- <input name="Add_User" />--%>
                <input type="text" id="Add_User" runat="server" name="Add_User" />
            </div>
        </div>
        <div id="dlg-buttons" class="dialog-button">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
		<a id="save" class="easyui-linkbutton" iconcls="icon-ok" onclick="return save()"
        runat="server" onserverclick="save_Click">保存</a>
        <a class="easyui-linkbutton" iconcls="icon-cancel"
            onclick="javascript:location.href='sqb_bweb_notice_main.aspx?pid=<%= _pid %>'">返回</a>
	</div>
    </div>
    </form> 
</body>
</html>
