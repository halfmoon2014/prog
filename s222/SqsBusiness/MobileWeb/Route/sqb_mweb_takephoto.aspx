<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_takephoto.aspx.cs"
    Inherits="SqsBusiness.MobileWeb.Route.sqb_mweb_takephoto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head_takephoto" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
    <title>拜访拍照</title>
    <script type="text/javascript"> 
        $(function () {
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
    <form name="form_takephoto" runat="server" data-ajax="false">
    <fieldset>
        <div data-role="page" id="page_takephoto">
            <div data-theme="c" data-role="header" data-position="fixed"><h1>拜访拍照</h1></div>
            <div data-role="content">
                 <fieldset data-role="controlgroup">
                  <label for="Photo_Type" class="select">
                    拍照类型:</label>
                <asp:DropDownList ID="photo_type" runat="server" Height="16px"  Width="107px" data-native-menu="false" >
                </asp:DropDownList>
               <label for="Note">备注：</label>
                <asp:TextBox runat="server" EnableTheming="True" Height="105px" Width="100%" 
                    ID="txtbz" TextMode="MultiLine"></asp:TextBox>
 </fieldset>
                <br />
                <asp:Label ID="lblupfile" runat="server" Text="上传图片"></asp:Label>
                <asp:FileUpload runat="server" ID="upfile"></asp:FileUpload></br>
                <asp:Label ID="lblmsg" runat="server" Text="Label" Visible="False" 
                    ForeColor="#FF3300"></asp:Label>
                <div class="ui-grid-a">
                    <div class="ui-block-a">
                        <asp:Button ID="BtnUpload" runat="server" Text="保存" onclick="BtnUpload_Click" />
                    </div>
                    <div class="ui-block-b">
                         <asp:Button ID="btnbackcall" runat="server" Text="返回" 
                             onclick="btnbackcall_Click" />
                    </div>
                </div>
                          <center>
                <div style="text-align: center; width: 96%; height: 300px; position: relative;
                    background-color: #fbfbfb; border: 1px solid #b8b8b8;">
                  
                    <asp:Image ID="Image2" ImageUrl="../Images/login.jpg" runat="server" 
                        Width="100%" Height="100%" />
                </div>
                </center>
            </div>
            <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
                <a id="home" data-role="button" data-icon="home">主页</a> <a id="logout"
                    data-role="button" data-icon="delete" >注销</a>
            </div>
        </div>
    </fieldset>
    </form>
</body>
</html>
