<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="tablediv_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <style>
        .div1
        {
            width: 200px;
        }
        .div2
        {
            width: 500px;
        }
    </style>
    <script language="javascript">
        window.onload = function () {
            $(".div1").css({ float: "left" })
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="" class="div1">
        1</div>
    <div style="float: left;" class="div2">
        2
        <div>
            asdfasdf</div>
    </div>
    </form>
</body>
</html>
