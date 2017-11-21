<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <title></title>
    <script language="javascript">
        function go() {
            var r = new Array();
            var o = {};
            o.chdm = "a_zym";
            o.t = 1;
            o.row = 1;
            o.col = 1;
            r.push(o);
            var rr = {};
            rr.mytype = "save";
            rr.r = r;
            rr.pageno = 1;

            //"{\"mytype\":\"save\",\"r\":[{\"chdm\":\"a_zym\",\"t\":\"1\",\"row\":\"1\",\"col\":\"1\"}],\"pageno\":\"1\"}"

            
            $.ajax({ type: 'post',
                url: 'a.ashx',
                //data: { mytype: "chdmcx", r:r, chdm: "c", chmc: "b" },
                data: JSON.stringify(rr),
                error: function (e) {
                    alert(e);
                    alert("查询错误");
                },
                success: function (data) {
                    alert(data);
                }
            })
        }
        window.onload = function () {
            var j = {"aa":[{ "a": "b" },{ "a": "b" }]};
            //var j=["AreaId":"123","AreaId":"345"]
            alert(j.a);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" onclick="go()" value="test" />
    </div>
    </form>
</body>
</html>
