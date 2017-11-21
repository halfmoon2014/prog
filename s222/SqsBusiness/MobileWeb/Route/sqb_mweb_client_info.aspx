<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_client_info.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Route.sqb_mweb_client_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客户信息</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript"> 
        $(function () {
            $("#edit").click(function (){
                 location.href = encodeURI("sqb_mweb_client_add.aspx?addtype=客户编辑&clientid=<%=client_id%>");
            });
            $("#kehuyichang").click(function () {
                location.href = "sqb_mweb_client_call.aspx?manage="+<%="'"+manage+"'"%>+"&type=" + <%="'"+type+"'"%> + "&pattern="+encodeURI("客户异常")+"&code=" + <%="'"+code+"'" %>;
            });

            $("#dianhua").click(function () {
                location.href = "sqb_mweb_client_call.aspx?manage="+<%="'"+manage+"'"%>+"&type=" +  <%="'"+type+"'"%>  + "&pattern="+encodeURI("电话拜访")+"&code=" + <%="'"+code+"'" %>;
            });
            $("#shangmen").click(function () {
                location.href = "sqb_mweb_client_call.aspx?manage="+<%="'"+manage+"'"%>+"&type=" + <%="'"+type+"'"%> + "&pattern="+encodeURI("上门拜访")+"&code=" + <%="'"+code+"'" %>;

            });

            $("#backlist1").click(function () {
                if (<%="'"+type+"'"%> == "dayline") {
                    location.href = "sqb_mweb_dayline.aspx?manage="+<%="'"+manage+"'"%>+"&type=dayline";
                }
                else {
                    location.href = "sqb_mweb_client_list.aspx?manage="+<%="'"+manage+"'"%>+"&type=line";
                }
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
</head>
<body>
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form_client_info" runat="server">
    <div data-role="page" id="page_client_info" data-position="fixed">
        <div data-theme="c" data-role="header" data-position="fixed">
            <a data-role="button" data-transition="fade" data-theme="c" data-icon="back" class="ui-btn-left"
                runat="server" id="backlist1">返回</a>
            <h1>
                客户信息
            </h1>
        </div>
         <div class="ui-grid-a">
                <div class="ui-block-a">
                    <a data-role="button" data-transition="fade" id="edit">客户编辑</a> 
                    <a id="kehuyichang" data-role="button" data-transition="fade" runat="server">客户异常</a>
                </div>
                <div class="ui-block-b">
                    <a id="dianhua" data-role="button" data-transition="fade" runat="server">电话拜访</a>
                    <a id="shangmen" data-role="button" data-transition="fade" runat="server">上门拜访</a>
                </div>
            </div>
        <div data-role="content">
            <fieldset data-role="controlgroup">
                <label for="Name">
                    客户名称
                    <br />
                </label>
                <asp:TextBox ID="Name" runat="server" readonly="True"></asp:TextBox>
                <label for="Address">
                    <br />
                    客户地址
                    <br />
                </label>
                <asp:TextBox ID="Address" runat="server" readonly="True"></asp:TextBox>
                <label for="Linkman">
                    <br />
                    联 系 人
                    <br />
                </label>
                <asp:TextBox ID="Linkman" runat="server" readonly="True"></asp:TextBox>
                <label for="Phone">
                    <br />
                    固定电话
                    <br />
                </label>
                <asp:TextBox ID="Phone" runat="server" readonly="True"></asp:TextBox>
                <label for="Mobile">
                    <br />
                    手机号码
                    <br />
                </label>
                <asp:TextBox ID="Mobile" runat="server" readonly="True"></asp:TextBox>
                <label for="Email">
                    <br />
                    电子邮件
                    <br />
                </label>
                <asp:TextBox ID="Email" runat="server" readonly="True"></asp:TextBox>
            </fieldset>
           
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a id="home" data-role="button" data-icon="home">主页</a> <a id="logout" data-role="button"
                data-icon="delete">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
