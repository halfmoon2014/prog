<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dialog_error.aspx.cs" Inherits="SqsBusiness.MobileWeb.Dialog.dialog_error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>信息提示</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
</head>
<body>
    <form id="form_dialog_error" runat="server">
    <div data-role="dialog" data-theme="c">
        <div data-role="header" data-theme="c">
            <h1>
                信息提示</h1>
        </div>
        <div data-role="content" data-theme="c">
            <p id="dialog_error_msg" runat="server">
            </p>
            <a href="#" data-role="button" data-rel="back" data-theme="b">确定</a>
        </div>
    </div>
    </form>
</body>
</html>
