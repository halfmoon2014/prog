<%@ Page Language="C#" AutoEventWireup="true" CodeFile="father.aspx.cs" Inherits="showmodaldialog_father" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function go() {
            if (window.showModalDialog) {
                var rt = window.showModalDialog("sub.aspx");
                alert(rt);
            } else {
                window.open("sub.aspx");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input value="打开子页面" type="button" onclick="go()" />
    </div>
    </form>
</body>
</html>
