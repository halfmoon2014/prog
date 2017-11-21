<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        //document.write('<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"><\/script>');
        //document.write('<script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"><'+'/script>');
        window.onload = function () {            
            $.ajax({ type: 'get',
                url: 'Handler2.ashx',
                contentType: "application/x-www-form-urlencoded; charset=UTF-8",
                data: { requestType: 'test'  },
                error: function (e) {
                     
                    console.log(e);
                },
                success: function (data) {
                    alert(data);
                    return false;                    
                    
                }
            });
             
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    test   asdfasdfasdfas 
    </div>
    </form>
</body>
</html>
