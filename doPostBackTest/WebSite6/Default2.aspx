<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Dim hell As String
    Sub page_load(ByVal S As Object, ByVal E As EventArgs)
        hell = "aaa"
        Response.Write(hell)
    End Sub
    Sub go()
        Dim a=hell
    End Sub
    Sub s(ByVal d As String)
        Response.Write(d)
    End Sub
    Public Function finQ(ByVal key As String, ByVal allkey As System.Collections.Specialized.NameValueCollection) As Boolean
        Dim r As Boolean
        r = False
        For Each i As String In allkey.Keys
            If i = key Then
                r = True
                Exit For
            End If
        Next
        Return r
    End Function
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%
        Dim hell As string = "1"
        Response.Write(hell)
        s(hell)
        %>
        <asp:Button runat="server" OnClick="go" />
    </div>
    </form>
</body>
</html>
