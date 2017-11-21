<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test2.aspx.vb" Inherits="test2" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style>
.abc
{
    word-break:break-all ;
}

</style>
    <title></title>
    <%
        Dim gg_col_array As New Collections.Generic.Dictionary(Of Integer, Collections.Generic.Dictionary(Of String, String))
        
       
        Dim aa As New NameValueCollection
        aa.Add(1, "2")
        
        aa.Add(1, "22")
        
        Dim a As String = "aaa" + Decimal.Parse("1.22").ToString()+"g"
        Response.Write(a)
        %>
        <script type="text/javascript">
            function go() {
                window.showModalDialog("test2.aspx");

            }
            window.onload = function () {
                alert(window.arguments.srcElement);

            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" onclick="go()" />
    </div>
    </form>
</body>
</html>
