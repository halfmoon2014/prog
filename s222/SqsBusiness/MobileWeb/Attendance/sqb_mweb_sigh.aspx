<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_sigh.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Attendance.sqb_mweb_sigh" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>签到签退</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
</head>
<body onload="bodyLoad()">    
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form1" runat="server" data-ajax="false">
    <div data-role="page" id="page_client_list" data-title="签到签退" data-theme="c">
        <div data-role="header" data-position="inline" data-position="fixed" data-theme="c">
            <h1>
                签到签退</h1>
            <a href="sqb_mweb_attendance_manage.aspx" data-icon="back" class="ui-btn-left">返回</a>
        </div>
        <div data-role="content">
            <input id="dateTime" type="text" readonly="readonly" name="dateTime" runat="server"/>
            <div data-role="fieldcontain">
                <fieldset data-role="controlgroup">
                    <label for="textarea1">
                        备注
                    </label>
                    <textarea name="" id="comment" placeholder="" data-mini="true" runat="server"></textarea>
                </fieldset>
            </div>
            
            
            <div <%--style="text-align: center;"--%>>
<%--            <a data-role="button" data-inline="true" data-transition="fade"  id="signIn">签到</a>
                <a data-role="button" data-inline="true" data-transition="fade">拍照</a>
                <a data-role="button" data-inline="true" data-transition="fade"  id="signOut">签退</a>--%>    
                <p><asp:FileUpload ID="fulPhoto" runat="server" /></p>
                <%--<asp:Image ID="Image2" ImageUrl="../Images/login.jpg" runat="server" Width="100%" Height="100%" />--%>
<%--                <input id="signIn" data-inline="true" type="button" value="签到" /> --%>
              <%--  <input id="Button2" data-inline="true" type="button" value="拍照" /> --%>
              <%--  <input id="signOut" data-inline="true" type="button" value="签退" style="float:right;" /> --%>
                <%--<select id="type">
                    <option>签到</option>
                    <option>签退</option>
                </select>--%>
                <asp:DropDownList ID="signType" runat="server">
                    <asp:ListItem>签到</asp:ListItem>
                    <asp:ListItem>签退</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="save" runat="server" Text="保存" onclick="save_Click" />
            </div>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a onclick="javascript:location.href='../sqb_mweb_main.aspx'" data-role="button" data-icon="home">主页</a>
            <a onclick="javascript:location.href='../sqb_mweb_login.aspx'" data-role="button" data-icon="delete">注销</a>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        function bodyLoad() {
            var dateTime = new Date();
            var hh = dateTime.getHours();
            var mm = dateTime.getMinutes();
            var ss = dateTime.getSeconds();
            var yy = dateTime.getFullYear();
            var MM = dateTime.getMonth() + 1;
            var dd = dateTime.getDate();
            $("#dateTime").val(yy + "年" + MM + "月" + dd + "日 " + hh + "时" + mm + "分" + ss + "秒");
            //document.getElementById("dateTime").value = yy + "年" + MM + "月" + dd + "日 " + hh + "时" + mm + "分" + ss + "秒";
            setTimeout(bodyLoad, 1000);
        }

        $(function () {
            $("#signIn").click(function () {
                var dt = document.getElementById("dateTime").value;
                if (dt == "") {
                    alert("日期不能为空，请刷新，若仍为空,请确认开启Javascript，或换个浏览器");
                    return;
                }
                var comment = document.getElementById("comment").value;

                $.post("sqb_mweb_attendance_ajax.ashx", { action: "insert", type: "签到", dateTime: dt, userID: "1", comment: comment
                }, function (result) {
                    if (result == "true") {
                        alert("签到成功");
                        location.href = "sqb_mweb_attendance_manage.aspx";
                    }
                    else {
                        alert("签到失败");
                    }
                });
            });
        });

        $(function () {
            $("#signOut").click(function () {
                var dt = document.getElementById("dateTime").value;
                if (dt == "") {
                    alert("日期不能为空，请刷新，若仍为空,请确认开启Javascript，或换个浏览器");
                    return;
                }
                var comment = document.getElementById("comment").value;

                $.post("sqb_mweb_attendance_ajax.ashx", { action: "insert", type: "签退", dateTime: dt, userID: "1", comment: comment
                }, function (result) {
                    if (result == "true") {
                        alert("签退成功");
                        location.href = "sqb_mweb_attendance_manage.aspx";
                    }
                    else {
                        alert("签退失败");
                    }
                });
            });
        });
    </script>
</body>
</html>
