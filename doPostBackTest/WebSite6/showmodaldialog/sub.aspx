<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sub.aspx.cs" Inherits="showmodaldialog_sub" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        function myclose() {
            if (window.showModalDialog) {
                window.returnValue = "ok";
                window.close();
            } else {
                if (window.opener) {
                    window.opener.setValue(select_id, select_name);
                }
                window.close();
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="button" value="close" onclick="myclose()" />
    </div>
    </form>
</body>
</html>
