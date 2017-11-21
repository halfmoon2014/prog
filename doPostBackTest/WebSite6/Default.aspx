<%@ Page Title="主页" Language="C#" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<html>
<head>
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>    
    <script type="text/javascript">
        window.onload = function () {
            test();
        }
        function test() {
            var infoObj = new Object();
            infoObj.id = "26";
            infoObj.newpw = "aaaaaa";
            infoObj.newpw2 = "aaaaaa";
            if (1==1) {
                $.ajax({ type: 'get',
                    url: 'Handler.ashx',
                    contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                    data: { requestType: 'test', id: infoObj.id, newpw: infoObj.newpw },
                    error: function (e) {
                        //$(".password_button").removeAttr("disabled");
                        console.log(e);
                    },
                    success: function (data) {
                        alert(data);
                        return false;
                        //$(".password_button").removeAttr("disabled");
                        var myData = eval("(" + data.replace(/\\/g, "/") + ")");
                        if (myData.r == "true") {
                            alert("修改成功")
                        } else {
                            alert(myData.msg);
                        }
                    }
                });
            }
        }
    </script>
</head>
<body></body>
</html>