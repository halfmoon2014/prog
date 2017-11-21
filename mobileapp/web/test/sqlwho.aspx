<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sqlwho.aspx.cs" Inherits="test_sqlwho" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .mytable
        {
            border-style: solid;
            border-width: thin;
            border-collapse: collapse;
        }
        .mytable td
        {
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div style="background-color: #999966">
        <div>
            hostname:<input type="text" id="hostname" runat="server" />
            blk:<input type="checkbox" id="blk" runat="server" />
            <input type="submit" value="cx" />
        </div>
        <div>
            sp_who</div>
        <div id="spwho" runat="server">
        </div>
    </div>
    <div style="background-color: #669999">
        <div>
            sp_who_lock</div>
        <div id="spwholock" runat="server">
        </div>
    </div>
    <div style="background-color: #999966">
        <div>
            <textarea id="sql3" rows="5" runat="server"></textarea></div>
        <div id="div3" runat="server">
        </div>
    </did>
    </form>
</body>
</html>
