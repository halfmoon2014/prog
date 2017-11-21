<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="frame_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    
        <script type="text/javascript">
            //top.document.close()
            //document.write("<script src='../Scripts/a.js'><\/script>");
//            window.onload = function () {
//                var input = document.createElement('input');
//                input.type = 'hidden'; input.name = 'dir'; input.id = 'dir';
//                var h1 = document.getElementsByTagName('h1')[0];
//                h1.parentNode.appendChild(input);
//                test();
//            }
//            function test() {
//                var input = document.getElementsByName('dir')[0];
//                alert(input);
            //            }
            //document.write('<script type="text\/javascript"> function abc(){alert(123);}<\/script>')
            window.onload = function () {
                alert(1);

                //                var btn = document.createElement("input")
                //                btn.type = "hidden";
                //                btn.name = "aaaa";
                //var btn = document.createElement("<input type='text' name='txtName'>")

                var btn = document.createElement("div");
                //btn.type = "text";
                btn.name = "txtName";
                btn.style = "display:none";
                document.body.appendChild(btn);
                //$(document.getElementById("goo")).after('<script type="text\/javascript"> function flowSession() { this.tzid = "@userssid"; this.dxtzid = "@userssid";this.zbid = "@zbid";this.userid = "@userid";this.username = "@username";}<\/script>')
            }
    </script>

    
</head>
<body>
<form name="MyForm">
<h1></h1>
<input type="hidden" />
<div id="adiv"></div>
    abc
    <iframe src="bbLeft.aspx"></iframe>
    <iframe src="bbShow.aspx"></iframe>    
    <input type="hidden" id="goo" />
    </form>
</body>
</html>
