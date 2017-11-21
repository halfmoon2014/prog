<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_client_add.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Client.sqb_mweb_client_add" %>

<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=RAddType%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("a").click(function () {
                switch (this.id) {
                    case "save": //保存
                        var code = $("#code").val();
                        var name = $("#name").val();
                        var address = $("#address").val();
                        var linkman = $("#linkman").val();
                        var phone = $("#phone").val();
                        var mobile = $("#mobile").val();
                        var email = $("#email").val();
                        var acreage = $("#acreage").val();
                        var longitude = $("#longitude").val();
                        var latitude = $("#latitude").val();

                        $.ajax({
                            type: "POST",
                            url: "sqb_mweb_client_add.aspx",
                            data: { mode: "saveuser", stype: "<%=RAddType%>", cid: "<%=RClientID%>", ccode: code, cname: name, caddress: address, clinkman: linkman, cphone: phone, cmobile: mobile, cemail: email, cacreage: acreage, clongitude: longitude, clatitude: latitude },
                            success: function (result) {
                                switch (result) {
                                    case "saveisnull":
                                        location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI("必填字段不能为空！");
                                        break;
                                    case "ClientExist":
                                        location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI("<%=RAddType%>失败，客户已存在！");
                                        break;
                                    case "savetrue":
                                        location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI("保存成功！");
                                        break;
                                    case "savefalse":
                                        location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI("保存失败！");
                                        break;
                                    case "ClientNoExist":
                                        location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI("<%=RAddType%>失败，客户不存在！");
                                        break;
                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) { location.href = "../Dialog/dialog_error.aspx?errormsg=" + encodeURI(errorThrown); }
                        });
                        break
                    case "reback": //返回
                        location.href = "<%=RUrlRes%>";
                        break
                    case "home": //主页
                        location.href = "../sqb_mweb_main.aspx";
                        break
                    case "logout": //注销
                        location.href = "../sqb_mweb_login.aspx";
                        break
                }
            })
        })
    </script>
</head>
<body>
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form_client_add" runat="server">
    <div data-role="page" id="page_client_add" data-position="fixed">
        <div data-theme="c" data-role="header" data-position="fixed">
            <h1>
                <%=RAddType%>
            </h1>
            <a id="reback" data-role="button" data-transition="fade" data-theme="c" data-icon="back"
                data-iconpos="left" class="ui-btn-left">返回 </a><a id="save" data-role="button" data-transition="fade"
                    data-theme="c" data-icon="back" data-iconpos="left" class="ui-btn-right">保存
            </a>
        </div>
        <div data-role="content">
            <fieldset data-role="controlgroup">
                <label for="code">
                    客户编号<font color="red">(必填)</font>
                </label>
                <input id="code" placeholder="" value="" type="text" runat="server" />
                <label for="name">
                    客户名称<font color="red">(必填)</font>
                </label>
                <input id="name" placeholder="" value="" type="text" runat="server" />
                <label for="address">
                    客户地址<font color="red">(必填)</font>
                </label>
                <input id="address" placeholder="" value="" type="text" runat="server" />
                <label for="linkman">
                    联系人
                </label>
                <input id="linkman" placeholder="" value="" type="text" runat="server" />
                <label for="phone">
                    固定电话
                </label>
                <input id="phone" placeholder="" value="" type="text" runat="server" />
                <label for="mobile">
                    手机号码
                </label>
                <input id="mobile" placeholder="" value="" type="text" runat="server" />
                <label for="email">
                    电子邮件
                </label>
                <input id="email" placeholder="" value="" type="text" runat="server" />
                <label for="acreage">
                    面积
                </label>
                <input id="acreage" placeholder="" value="" type="text" runat="server" />
                <label for="longitude">
                    经度
                </label>
                <input id="longitude" placeholder="" value="" type="text" runat="server" />
                <label for="latitude">
                    纬度
                </label>
                <input id="latitude" placeholder="" value="" type="text" runat="server" />
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
