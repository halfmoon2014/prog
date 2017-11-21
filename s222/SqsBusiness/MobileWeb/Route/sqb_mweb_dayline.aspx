<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_dayline.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Route.sqb_mweb_dayline" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>当日路线</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
</head> 

  <script language="javascript">


      function loadinfo(str) {
          location.href="sqb_mweb_client_info.aspx?manage="+<%="'"+manage+"'"%>+"&process=daylist&type=dayline&code=" + str;
      }
               function kehuyc(str) {    //客户异常
            location.href = "sqb_mweb_client_call.aspx?manage="+<%="'"+manage+"'"%>+"&type=dayline&process=daylist&pattern="+encodeURI("客户异常")+"&code="+ str;
        } 
         function dianhuabf(str) {    //电话拜访
            location.href = "sqb_mweb_client_call.aspx?manage="+<%="'"+manage+"'"%>+"&type=dayline&process=daylist&pattern="+encodeURI("电话拜访")+"&code=" +str;
        }
         function shangmenbf(str) {   //上门拜访  
            location.href = "sqb_mweb_client_call.aspx?manage="+<%="'"+manage+"'"%>+"&type=dayline&process=daylist&pattern="+encodeURI("上门拜访")+"&code=" + str;
        }

      //返回客户拜访主页面
      $(function () {
          $("#backvisit").click(function () {
              location.href = "sqb_mweb_visit.aspx?";
          });
          //主页
          $("#home").click(function () {
              location.href = "../sqb_mweb_main.aspx";
          });
          //注销
          $("#logout").click(function () {
              location.href = "../sqb_mweb_login.aspx";
          });
      })

    </script>
<body>
 <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form_dayline" runat="server">
    <div data-role="page" id="page_dayline" data-title="当日路线" data-theme="c">
        <div data-role="header" data-position="inline" data-position="fixed" data-theme="c">
            <h1>
                当日路线</h1>
            <a data-icon="back" class="ui-btn-left" runat="server" id="backvisit">返回</a>
        </div>
        <div data-role="content">
            <asp:Panel ID="pnlist" runat="server">
            </asp:Panel>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a id="home" data-role="button" data-icon="home">主页</a> 
            <a id="logout" data-role="button" data-icon="delete">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
