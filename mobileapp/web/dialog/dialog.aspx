<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dialog.aspx.cs" Inherits="dialog_dialog" %>
<html>
<body>
    <form id="form1" runat="server">
    <div data-role="dialog" id="dialog_dialog">
        <div data-role="header" data-theme="a">
            <h1>
                提示信息</h1>
        </div>
        <div data-role="content" data-theme="a">
            <h1>
            </h1>
            <p id="dialog_dialog_info" runat="server">
                info</p>
            <a href="#" data-role="button" data-rel="back" data-theme="a">ok</a>
        </div> 
    </div>
    </form>
</body>
</html>
