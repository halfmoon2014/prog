<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_massage_send.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.sqb_mweb_massage_send" %>

<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(":checkbox").click(function () {
                var chkval = $("#Recipient").val();

                if (this.checked) {
                    chkval = chkval + $.trim($("#lbl" + this.id).text()) + ";";
                    
                }
                else {
                    chkval = chkval.replace($.trim($("#lbl" + this.id).text()) + ";", "");
                }

                $("#Recipient").val(chkval)
            });

            $("#reback,#home,#logout,#sendmsg, #clear,#upfile").click(function () {
                switch (this.id) {
                    case "reback":
                        location.href = "sqb_mweb_massage_manage.aspx";
                        break
                    case "home":
                        location.href = "../sqb_mweb_main.aspx";
                        break
                    case "logout":
                        location.href = "../sqb_mweb_login.aspx";
                        break
                    case "sendmsg":
                        location.href = "sqb_mweb_massage_upload.aspx";
                    case "clear":
                        $("#Recipient").val("");
                        $("#tTltle").val("");
                        $("#tContent").val("");
                        $("#upfile").val("");
                }
            })
        })
        function callBack(fileName)
        { document.getElementById('Attach1').innerHTML = fileName; }
    </script>
</head>
<body>
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <form id="form1" runat="server" data-ajax="false">
    <!-- 发送短信 -->
    <div data-role="page" id="page6">
        <div data-theme="c" data-role="header">
            <input type="button" runat="server" data-theme="c"  id="reback" value="返回" class="ui-btn-left" />
            <h3>
                发送短信
            </h3>
            <%--<asp:Button ID="send" runat="server" data-theme="c" class="ui-btn-right" OnClick="send_Click" Text="确定" />--%>
                <input type="button" runat="server" data-theme="c" class="ui-btn-right" value="确定" id="send" onserverclick="send_Click" />

            &nbsp;
        </div>
        <div data-role="content" style="padding: 15px">
            <div data-role="fieldcontain">
                <fieldset data-role="controlgroup">
                    <label for="tTltle">
                        标题：
                    </label>
                    <input name="" id="tTltle" placeholder="" value="" type="text" runat="server">
                </fieldset>
            </div>
            <div data-role="fieldcontain">
                <fieldset data-role="controlgroup">
                    <label for="tContent">
                        内容：
                    </label>
                    <textarea name="" id="tContent" placeholder="" runat="server">
                     </textarea>
                </fieldset>
            </div>
            &nbsp;&nbsp;&nbsp; &nbsp;<div id="Div1" data-role="fieldcontain" runat="server">
                <div>
                    <asp:Panel ID="Pnlist" runat="server">
                    </asp:Panel>
                </div>
                <label for="Recipient">
                    收件人：
                    <input id="Recipient" runat="server" type="text" readonly="readonly" />&nbsp;&nbsp;&nbsp;
                    <br />
                </label>
                <br />
            </div>
            &nbsp;<div data-role="fieldcontain" runat="server">
                <fieldset data-role="controlgroup">
                    <asp:Label ID="Label3" runat="server" Text="上传文件："></asp:Label>
                    <asp:FileUpload runat="server" ID="upfile"></asp:FileUpload>
                    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" ForeColor="#FF3300"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False" 
                        ForeColor="#FF3300"></asp:Label>
                </fieldset>
                <input data-inline="true" value="清空" data-mini="true" type="submit" id="clear" />
            </div>
            &nbsp</div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a data-role="button" data-icon="home" id="home">主页</a> <a data-role="button" data-icon="delete"
                id="logout">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
