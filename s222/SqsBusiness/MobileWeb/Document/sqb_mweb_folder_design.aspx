<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_folder_design.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Document.sqb_mweb_folder_design" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文档信息</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#save").click(function () {
                if ($.trim($("#documentName").val()) == "") {
                    alert("文档名称不能为空");
                    return;
                }               
            }); 
        });

        $(function () {
            $("#selectFolder").click(function () {
                location.href = "sqb_mweb_folder_select.aspx?folderName=" + $("#documentName").val() + "&pid=" + '0' + "&url=document&type=<%= _type %>&id=<%= _id %>&dateTime=<%= _dateTime %>";
            });
        }
        );

        $(function () {
            $("#delete").click(function () {
                $.ajax({
                    type: "GET",
                    url: "sqb_mweb_folder_design.aspx/Document",
                    data: { flag: "true", action: 'delete', id: '<%= _id %>' ,type:'<%= _type %>'},
                    success: function (result) {
                        alert("删除成功");
                        location.href = "sqb_mweb_folder_list.aspx";
                        //location.href = "Dialog/dialog_error.aspx?errormsg=" + encodeURI("用户名或密码错误！");
                    },
                    error: function () {
                        alert("删除失败");
                    }
                });
            });
        });
    </script>
</head>
<body>    
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form1" runat="server" data-ajax="false">
    <div data-role="page" id="page_client_list" data-title="文档信息" data-theme="c">
        <div data-role="header" data-position="inline" data-position="fixed" data-theme="c">
            <h1>文档信息</h1>
            <a onclick="javascript:location.href='sqb_mweb_folder_list.aspx?type=<%= _type %>'" data-icon="back" class="ui-btn-left">返回</a>
        </div>
        <div data-role="content">
            <p>日期<input type="text" id="date" readonly="readonly" runat="server"></p>
            <p>文档名称<input type="text" id="documentName" runat="server"></p>
            <asp:Panel ID="pnlUpLoad" runat="server">
            </asp:Panel>
            <p>文件夹名称<a data-role="button" data-inline="true" id="selectFolder">选择文件夹</a>
            <input type="text" id="folderName" readonly="readonly" runat="server"></p>
          <%--  <p>文件路径<input type="text" id="filePath" readonly="readonly">--%>
                <%--<input id="FileUpLoad1" type="file" runat="server" />--%>
            <%--<asp:FileUpload ID="upfile" runat="server" /></p>--%>
          <%--  <a data-role="button" data-inline="true" id="selectFolder">选择文件夹</a> --%>
          <%--  <a data-role="button"   data-inline="true" style="float: right">选择文件</a> --%>
            <%--<a data-inline="true" data-role="button" id="save1" runat="server" onclick="btnFileUpload_Click">保存</a> --%>
            <asp:Button ID="save" runat="server" Text="保存" onclick="save_Click" />
            <%--<a data-inline="true" data-role="button" style="float: right" id="delete">删除</a>--%>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a onclick="javascript:location.href='../sqb_mweb_main.aspx'" data-role="button" data-icon="home">主页</a>
            <a onclick="javascript:location.href='../sqb_mweb_login.aspx'" data-role="button" data-icon="delete">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
