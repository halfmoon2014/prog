<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doPostBack.aspx.cs" Inherits="testpro.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CDEF</title>
</head>
<body>
    <form id="form123" runat="server" onsubmit=" return ck()" >
    <div>
    <input type="text" />
    <asp:Button runat="server" Text="aspbutton" ID="sbtn" onclick="sbtn_Click"  />
    <input type="button" onclick="goo()" value="goo" />
    <asp:LinkButton ID="lbtn" runat="server" onclick="lbtn_Click">dd</asp:LinkButton>
    </div>
    </form>
    <script type="text/javascript">
        function goo() {
            var obj = new Object();
            obj.name = "51js";
            window.showModalDialog("dopostback2.aspx", obj);
            __doPostBack("lbtn", "");
        }
        function ck() {
            alert(1);
           // window.event.returnValue = false;
            return true;
        }
    </script>
</body>
</html>
