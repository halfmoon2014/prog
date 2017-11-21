<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testsubmit.aspx.cs" Inherits="testsubmit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
        window.onload = function () {
            sub(function () {
                cc(123);
            })
        }
        function cc(i) {
            alert(i);
        }
        function sub(f) {
            var efg = 'd(f)';
            eval(efg);
        }
        function d(f) {
            f();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" onclick="sub()" />
    <input type="text" id="aaa" />
    </div>
    </form>
</body>
</html>
