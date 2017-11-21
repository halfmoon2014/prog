<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module.aspx.cs" Inherits="module" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <script src="Scripts/jquery/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/module.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        window.onload = function () {
            //alert(module1.m1() + module1.m2(" some "));
            //alert(module2.m1());
            //alert(module2.m3() + module2.m1());
            module2._seal();
            //alert(module2._private.a);
            alert(module2.m4());

        }
        

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
