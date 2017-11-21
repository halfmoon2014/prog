<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qrcode.aspx.cs" Inherits="qrcode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="html5-qrcode-master/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="html5-qrcode-master/lib/html5-qrcode.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#reader').html5_qrcode(function (data) {
                $('#read').html(data);
            },
		    function (error) {
		        $('#read_error').html(error);
		    }, function (videoError) {
		        $('#vid_error').html(videoError);
		    });
        });


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="reader" style="width: 300px; height: 250px">
    </div>

    <h6 class="center"> Result</h6>
    <span id="read" class="center"></span>
    <br>
    <h6 class="center"> Read Error (Debug only)</h6>
    <span class="center">Will constantly show a message, can be ignored</span> <span id="read_error" class="center"></span>
    <br>
    <h6 class="center"> Video Error</h6>
    <span id="vid_error" class="center"></span>
    </div>
    </form>
</body>
</html>
