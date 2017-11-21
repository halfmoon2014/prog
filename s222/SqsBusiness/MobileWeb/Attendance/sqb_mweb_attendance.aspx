<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_mweb_attendance.aspx.cs" Inherits="SqsBusiness.MobileWeb.Attendance.sqb_mweb_attendance" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="../WebControl/LoginControl.ascx" TagName="LoginControl" TagPrefix="LoginControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>考勤查询</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="../Js/jquery-1.8.0.min.js"></script>
    <link rel="stylesheet" href="../Css/jquery.mobile/jquery.mobile-1.1.1.min.css" />
    <script type="text/javascript" src="../Js/jquery.mobile/jquery.mobile-1.1.1.min.js"></script>
	<script type="text/javascript">
	    function checkDate(value) {
	        if ((/^\d{4}-\d{1,2}-\d{1,2}$/).test(value) == false)
	            return false;

	        dateArr = value.split("-");
	        monthPerDays = new Array(31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31);
	        year = dateArr[0];
	        month = dateArr[1];
	        day = dateArr[2];

	        if (month > 12 || month <= 0)
	            return false;

	        if (day > 31 || day <= 0)
	            return false;

	        if (year % 100 == 0) {
	            if (year % 400 == 0)
	                monthPerDays[1] = 29;
	        }
	        else {
	            if (year % 4 == 0)
	                monthPerDays[1] = 29;
	        }

	        if (monthPerDays[month - 1] < day)
	            return false;

	        return true;
	    }
	    function checkForm() {
	        if (!checkDate(document.getElementById("dateStart").value)) {
	            alert("开始日期格式有误！");
	            document.all.dateStart.focus();
	            return false;
	        }
	        if (!checkDate(document.getElementById("dateEnd").value)) {
	            alert("结束日期格式有误！");
	            document.all.dateEnd.focus();
	            return false;
	        }
	        var dateStart = document.getElementById("dateStart").value;
	        var dateEnd = document.getElementById("dateEnd").value;
	        var type = document.getElementById("selectType").value;
	        location.href = "sqb_mweb_attendance_select.aspx?dateStart=" + dateStart + "&dateEnd=" + dateEnd + "&type="+type;
        }

	    function bodyLoad() {
	        var dateTime = new Date();
	        var hh = dateTime.getHours();
	        var mm = dateTime.getMinutes();
	        var ss = dateTime.getSeconds();
	        var yy = dateTime.getFullYear();
	        var MM = dateTime.getMonth() + 1;
	        var dd = dateTime.getDate();
	        $("#dateStart,#dateEnd").val(yy + "-" + MM + "-" + dd);
	    }
	</script>
</head>
<body onload="bodyLoad()">    
    <!-- 登录验证 -->
    <LoginControl:LoginControl ID="LoginControl" runat="server" />
    <!-- 主页面 -->
    <form id="form1" runat="server">
    <div data-role="page" id="page_client_list" data-title="考勤查询" data-theme="c">
        <div data-role="header" data-position="inline" data-position="fixed" data-theme="c">
            <h1>
                考勤查询</h1>
            <a onclick="javascript:location.href='sqb_mweb_attendance_manage.aspx'" data-icon="back" class="ui-btn-left">返回</a>
        </div>
        <div data-role="content">
        <div class="demo">
        <p>开始日期:<span style="color:Red">格式2012-01-01</span> <input type="text" id="dateStart"></p>
        <p>结束日期:<span style="color:Red">格式2012-01-01</span> <input type="text" id="dateEnd"></p>
<%--        <p>开始日期: <input type="text" id="dateStart"></p>
        <p>结束日期: <input type="text" id="dateEnd"></p>--%>
        </div>
            <select id="selectType">
                <option>全部</option>
                <option>签到</option>
                <option>签退</option>
            </select>
            <a href="" data-role="button" id="query" onclick="return checkForm()">考勤查询</a>
        </div>
        <div data-role="footer" class="ui-bar" data-position="fixed" data-theme="c">
            <a onclick="javascript:location.href='../sqb_mweb_main.aspx'" data-role="button" data-icon="home">主页</a>
            <a onclick="javascript:location.href='../sqb_mweb_login.aspx'" data-role="button" data-icon="delete">注销</a>
        </div>
    </div>
    </form>
</body>
</html>
