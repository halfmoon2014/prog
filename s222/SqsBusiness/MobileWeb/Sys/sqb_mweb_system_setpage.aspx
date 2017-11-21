<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_system_setpage.aspx.cs" Inherits="SqsBusiness.MobileWeb.Sys.sqb_mweb_system_setpage" %>

<%@ Register src="../WebControl/LoginControl.ascx" tagname="LoginControl" tagprefix="LoginControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>XX设置</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
        <script language="javascript">
            function back() {
                location.href = "sqb_mweb_system_set.aspx";
            }
            function main() {
                location.href = "../sqb_mweb_main.aspx";
            }
            function page() {
                location.href = "sqb_mweb_system_setpage.aspx";
            }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
            <a data-role="button" data-transition="fade" onclick="back()"   class="ui-btn-left">
            返回
        </a>
                <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a data-role="button" data-icon="home" id="home">主页</a> <a data-role="button" data-icon="delete"
                id="logout" >注销</a>
        </div>
    </div>
    </form>
</body>
</html>
