<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Page_Load(ByVal Src As Object, ByVal E As EventArgs)
        Dim cm(93), cmxg(30)
        cmxg(0) = "0"
        If cmxg(0) <> 0 Then
            Response.Write("is not 0")
        Else
            Response.Write("is 0")
        End If
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
