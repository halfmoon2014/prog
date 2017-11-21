<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="jspost_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript">
        window.onload = function () {
            PostSubmit("default2.aspx", "%@''asdfsdf%", "汉字");
        }
        //Post方式提交表单
        function PostSubmit(url, data, msg) {
            var postUrl = url; //提交地址
            var postData = data; //第一个数据
            var msgData = msg; //第二个数据
            var ExportForm = document.createElement("FORM");
            document.body.appendChild(ExportForm);
            ExportForm.method = "POST";
            var newElement = document.createElement("input");
            newElement.setAttribute("name", "sn");
            newElement.setAttribute("type", "hidden");
            var newElement2 = document.createElement("input");
            newElement2.setAttribute("name", "no");
            newElement2.setAttribute("type", "hidden");
            ExportForm.appendChild(newElement);
            ExportForm.appendChild(newElement2);
            newElement.value = postData;
            newElement2.value = msgData;
            ExportForm.action = postUrl;
            ExportForm.submit();
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
