<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_client_list.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Route.sqb_mweb_client_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <title>客户列表</title> 
    <script language="javascript">
        function loadinfo(str) {     //跳转页面到客户具体信息页面中
            location.href = "sqb_mweb_client_info.aspx?manage="+<%="'"+manage+"'"%>+"&type=line&code=" + str;
        }
         function kehuyc(str) {    //客户异常
            location.href = "sqb_mweb_client_call.aspx?manage="+<%="'"+manage+"'"%>+"&type=line&process=list&pattern="+encodeURI("客户异常")+"&code="+ str;
        } 
         function dianhuabf(str) {    //电话拜访
            location.href = "sqb_mweb_client_call.aspx?manage="+<%="'"+manage+"'"%>+"&type=line&process=list&pattern="+encodeURI("电话拜访")+"&code=" +str;
        }
         function shangmenbf(str) {   //上门拜访  
            location.href = "sqb_mweb_client_call.aspx?manage="+<%="'"+manage+"'"%>+"&type=line&process=list&pattern="+encodeURI("上门拜访")+"&code=" + str;
        }


      

        $(function () {
   
            //主页
            $("#home").click(function () {
                location.href = "../sqb_mweb_main.aspx";
            });
            //注销
            $("#logout").click(function () {
                location.href = "../sqb_mweb_login.aspx";
            });
            $("#backselect").click(function () {
                location.href = "sqb_mweb_client_select.aspx?manage="+<%="'"+manage+"'"%>+"";
            });
        })
    </script>
</head>
<body>
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form1" runat="server">
    <!-- sqb_mweb_client_list -->
    <div data-role="page" id="page4">
        <div data-theme="c" data-role="header" data-position="fixed">
            <a data-role="button" data-transition="fade" data-theme="c" runat="server" data-icon="star"
                data-iconpos="left" class="ui-btn-left" ID="backselect">返回</a>
            <h3>
                客户列表
            </h3>
        </div>
        &nbsp;<div data-role="content" style="padding: 15px">
            <div data-role="collapsible-set" data-theme="" data-content-theme="">
                <asp:Panel ID="pnlist" runat="server">
                </asp:Panel>
            </div>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a id="home" data-role="button" data-transition="fade" data-icon="home" data-iconpos="left">
                主页 </a><a id="logout" data-role="button" data-transition="fade" data-icon="delete"
                    data-iconpos="left">注销 </a>
        </div>
    </div>
    </form>
</body>
</html>
