<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pagediv.aspx.cs" Inherits="pagediv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript">
        window.onload = function () {
            var bh = document.body.scrollHeight;
            document.getElementById("mytable").style.height = (bh - 50) + "px"
            setTimeout(function () {
                document.getElementById("testdiv").innerHTML = "code";
                document.getElementById("test2").className ="test2"
            }, 10000);
        }
        function show(obj) {
            alert(obj.innerHTML);
        }
        function test2() {alert("test2");}
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <div >
    <div id="testdiv" onclick="show(this)" class="panel-title">0</div>
    <div id="test2" onclick="test2()" class="panel-title">1</div>
    <div  class="panel-title">2</div>
    固定
    </div>
    <div id="mytable" style=" height:100px; overflow: auto;"  runat="server">
   
    </div>

    </form>
</body>
</html>
