﻿<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script language="javascript">
        
        function go() {
            var v1="select * from aa \0 where a=1";
            var tmp = "ddd";
            $.ajax({ type: 'post',
                url: '../WebService.asmx/a2',
                data: { v1: v1 },
                error: function () {

                },
                success: function (data) {
                    gotodo(tmp, data);
                }
            });

        }
        go();
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
