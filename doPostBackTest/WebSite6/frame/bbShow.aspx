<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bbShow.aspx.cs" Inherits="frame_bbShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
//        window.onload = function () {
//            var input = top.document.createElement('input');
//            input.type = 'hidden'; input.name = 'dir'; input.id = 'dir';
//            var h1 = top.document.getElementsByTagName('h1')[0];
//            h1.parentNode.appendChild(input);
//            test();
//        }
//        function test() {
//            var input = top.document.getElementsByName('dir')[0];
//            alert(input);
        //        }
        window.onload = function () {
            //top.document.write("<script src='../Scripts/a.js'><\/script>");
            //top.document.close()
            top.document.getElementById("adiv").innerHTML = '<script defer  type="text\/javascript"> function flowSession() { this.tzid = "@userssid"; this.dxtzid = "@userssid";this.zbid = "@zbid";this.userid = "@userid";this.username = "@username";}<\/script>';

            //alert($(top.document.getElementById("goo")).length)
            //$(top.document.getElementById("goo")).after("asdfasdfsa")
            //$(top.document.getElementById("goo")).after('<script type="text\/javascript"> function flowSession() { this.tzid = "@userssid"; this.dxtzid = "@userssid";this.zbid = "@zbid";this.userid = "@userid";this.username = "@username";}<\/script>')
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
   
    <div>
        <input type="hidden" />
        ABC
    </div>
    <div id="GOGO">
    </div>
    </form>
</body>
</html>
