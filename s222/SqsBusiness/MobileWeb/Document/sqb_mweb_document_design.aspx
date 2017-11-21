<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_document_design.aspx.cs" Inherits="SqsBusiness.MobileWeb.Document.sqb_mweb_document_design" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文件夹信息</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
</head>
<body>    
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl1" runat="server" />
    <!-- 主页面 -->
<LoginControl:LoginControl ID="LoginControl" runat="server" />
    <form id="form1" runat="server" data-ajax="false">
    <div data-role="page" id="page_client_list" data-title="文件夹信息" data-theme="c">
        <div data-role="header" data-position="inline" data-position="fixed" data-theme="c">
            <h1>文件夹信息</h1>
            <a onclick="javascript:location.href='sqb_mweb_folder_list.aspx?type=<%= _type %>'" data-icon="back" class="ui-btn-left">返回</a>
        </div>
        <div data-role="content">
            <p>文件夹名称: <input type="text" id="folderName" runat="server" /></p>
            <p>上级文件夹名称:
            <a data-inline="true" data-role="button" id="select">选择</a> <input type="text" id="p_folderName" readonly="readonly" runat="server" data-inline="true"/></p>
            <a data-inline="true" data-role="button" id="save">保存</a>
            <%--<a data-inline="true" data-role="button" id="select">选择</a>--%>
            <%-- <a data-inline="true" data-role="button" style="float:right" id="delete">删除</a>--%>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a onclick="javascript:location.href='../sqb_mweb_main.aspx'" data-role="button" data-icon="home">主页</a>
            <a onclick="javascript:location.href='../sqb_mweb_login.aspx'" data-role="button" data-icon="delete">注销</a>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            $("#save").click(function () {
                if ($.trim($("#folderName").val()) == "") {
                    alert("文件夹名称不能为空");
                    return
                }
                if ($.trim($("#p_folderName").val()) == "") {
                    alert("上级文件夹名称不能为空");
                    return;
                }
                $.ajax({
                    type: "GET",
                    url: "sqb_mweb_document_design.aspx/Folder",
                    data: { flag: "true", folderName: $("#folderName").val(), pid: '<%= _pid %>', action: '<%= _action %>', id: '<%= _id %>',type:'<%=_type %>' },
                    success: function (result) {
                        alert("保存成功");
                        location.href = "sqb_mweb_folder_list.aspx?type=<%= _type %>";
                        //location.href = "Dialog/dialog_error.aspx?errormsg=" + encodeURI("用户名或密码错误！");
                    },
                    error: function () {
                        alert("保存失败");
                    }
                });
            });
        });
        $(function () {
            $("#delete").click(function () {
                $.ajax({
                    type: "GET",
                    url: "sqb_mweb_document_design.aspx/Folder",
                    data: { flag: "true", folderName: $("#folderName").val(), pid: '<%= _pid %>', action: 'delete', id: '<%= _id %>', type: '<%= _type %>' },
                    success: function (result) {
                        alert("删除成功");
                        location.href = "sqb_mweb_folder_list.aspx?type=<%= _type %>";
                        //location.href = "Dialog/dialog_error.aspx?errormsg=" + encodeURI("用户名或密码错误！");
                    },
                    error: function () {
                        alert("删除失败");
                    }
                });
            });
        });

        $(function () {
            $("#select").click(function () {
                location.href = "sqb_mweb_folder_select.aspx?folderName=" + $("#folderName").val() + "&pid=0&type=<%= _type%>&id=<%= _id %>";
            });
        }
        );
    </script>
</body>
</html>
