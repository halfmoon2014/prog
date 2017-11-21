
var formSubmit = function () {
    if (InputBlur()) {
        var param = { usr: $("#userInput").val(), psw: $("#pswInput").val() };
        showLoader();
        $.ajax({ type: 'post',
            url: 'webService/login.asmx/getLogin',
            data: param,
            dataType: 'json',
            error: function (e) {
                showMsg("dialog/dialog.aspx?info=SysTemError");                
            },
            success: function (data) {
                if (data.isSuccess == "T") {
                    //不使用jqm跳转方法
                    window.location.href = "index.htm";
                }
                else {
                    hideLoader();
                    if (data.returnCode == "pswerror") {                        
                        showMsg("dialog/dialog.aspx?info=密码错误");                    }
                    else if (data.returnCode == "none") {                        
                        showMsg("dialog/dialog.aspx?info=用户名不存在");
                    } else if (data.returnCode == "ERR") {                        
                        showMsg("dialog/dialog.aspx?info=用户名不存在或密码错误");
                    }
                    else {                        
                        showMsg("dialog/dialog.aspx?info=系统异常");
                    }
                }
            }
        });
        return false;
    }
}


var InputBlur = function () {
    if ($("#userInput").val() == '' || $("#pswInput").val() == '') {
        if ($("#userInput").val() == '' && $("#pswInput").val() == '') {
            $("#login_error").show();
            $("#login_error").html("用户名,密码输入不能为空");
        } else if ($("#userInput").val() == '') {
            $("#login_error").show();
            $("#login_error").html("用户名输入不能为空");
        } else if ($("#pswInput").val() == '') {
            $("#login_error").show();
            $("#login_error").html("密码输入不能为空");
        }
        return false;
    } else {
        $("#login_error").hide();
        return true;
    }

}
var clear = function () {
    $("#pswInput").val("");
    $("#userInput").val("");
}



$('#loginpage').on('pageinit', function (event) {
    $('#btnOk').click(formSubmit);
    $('#btnClear').click(clear);
    console.log("loginpage_pageinit_ready");
});


