<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="callback_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>

    <script language="javascript">
        function go() {
            var tmp = "ddd";
            $.ajax({ type: 'post',
                url: '../WebService.asmx/HelloWorld',
                error: function () {

                },
                success: function (data) {
                    gotodo(tmp,data);
                }
            })

        }
        function go2() {
            var t=1
            a2("string", function (e) { alert(e);alert(t) })
        }
        function a2(v1,v2) {
            console.log(1);
            v2(v1);
        }
        function gotodo(v,a) {
            alert(v);alert(a);
        }
        function test2() {
            alert(1);
        }
    </script>
</head>
<body onunload="test2()">
    <form id="form1" runat="server">
    <div>
    <input type="button" onclick="go()" />
    <input type="text" id="t_text" />
    </div>
    </form>
</body>
</html>
