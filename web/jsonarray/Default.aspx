<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="jsonarray_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script  language="javascript">

        window.onload = function () {
            var c = "hello";
            var mobj = { c: 1, b: 2 };
            var mobj2 = { "c": 1, "b": 2 };
            var mjson = { "name": "姓名", "sex": 25 }; var mjson1 = mjson; mjson1.name = "dd";
            var jsonstring = '{name:"姓名",sex:25}';

            var array1 = [1, 2, 3];
            var array2 = [['a', 'b'], ['2', 4], { a: 1, b: 2}];
            console.log(1);
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
