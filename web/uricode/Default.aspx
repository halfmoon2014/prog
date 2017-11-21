<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript">
        window.onload = function () {
            var url="default2.aspx?@aff='%121212%'"
            window.open(encodeURI(url));
            window.open("default2.aspx?@aff='" + escape('%121212%') + "'");

        }     
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="text" id="mytext" />
    </div>
    </form>
</body>
</html>
