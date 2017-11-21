<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_client_call.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Route.sqb_mweb_client" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head_client_call" runat="server">
    <title>
        <% = pattern %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript"> 

    var process=<%="'"+ process +"'"%>;
    var type=<%="'"+ type +"'"%>;
    var manage=<%="'"+manage+"'"%>;
        $(function () {
   


            $("#reback").click(function () {
            if (process=="list"){
                location.href = "sqb_mweb_client_list.aspx?manage="+ manage +"&type="+ type +"&process="+ process +""
                }
            else if(process=="daylist"){
                location.href = "sqb_mweb_dayline.aspx?manage="+ manage +"&type="+ type +"&process="+ process +""
            }else{
                location.href = encodeURI("sqb_mweb_client_info.aspx?manage="+ manage +"&type=<%=type%>&code=<%=code%>");
            }
            });

            //主页
            $("#home").click(function () {
                location.href = "../sqb_mweb_main.aspx";
            });
            //注销
            $("#logout").click(function () {
                location.href = "../sqb_mweb_login.aspx";
            })
        });
    </script>
</head>
<body>
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form_client_call" runat="server" data-ajax="false">
    <div data-role="page" id="page_client_call">
        <div data-theme="c" data-role="header" data-position="fixed">
            <a data-role="button" data-transition="fade" data-theme="c" data-icon="back" data-iconpos="left"
                class="ui-btn-left" runat="server" id="reback">返回</a><h1>
                    <%  =pattern  %>
                </h1>
        </div>
        <div data-role="content">
            <input id="call_datatime" placeholder="" value="" type="text" runat="server" />
            <label for="Job_Content">
                工作内容：</label><asp:TextBox ID="Job_Content" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Label ID="lblmsg" runat="server" Text="Label" Visible="False" ForeColor="#FF3300"></asp:Label>
            <div class="ui-grid-a">
                <div class="ui-block-a">
                    <asp:Button ID="takephoto" runat="server" Text="拍照" OnClick="btnpz_Click" />
                </div>
                <div class="ui-block-b">
                    <asp:Button ID="btnleave" runat="server" Text="结束拜访" OnClick="btnleave_Click" OnClientClick="return confirm('确定要结束拜访吗?')" />
         
                  
                </div>
            </div>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a id="home" data-role="button" data-icon="home">主页</a> <a id="logout" data-role="button"
                data-icon="delete">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
