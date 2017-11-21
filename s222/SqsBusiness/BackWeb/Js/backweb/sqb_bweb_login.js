$(function () {
    //储存的用户名
    $("#username").val($.cookie("SqbBwebUserName"));

    //登录
    $("#loginok").click(function () {
        if ($("#username").val() == "") {
            $.messager.alert('错误提示', '请输入用户名！', 'info');
            return;
        }

        var ajaxdata=$("form").serialize() + "&mode=chkuser"; //提交表单数据

        $.ajax({
            type: "POST",
            url: "sqb_bweb_login.aspx",
            data: ajaxdata,
            success: function (result) {
                if (result == "true") {
                    if ($("#loginsave").attr("checked")) {
                        $.cookie("SqbBwebUserName", $("#username").val(), { expires: 7 }); //存储一个带7天期限的cookie 
                    }
                    location.href = "sqb_bweb_main.aspx";
                }
                else {
                    $.messager.alert('错误提示', '用户名或密码错误！', 'info');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { $.messager.alert('错误提示', errorThrown, 'error'); }
        });
    });

    //重置
    $("#loginreset").click(function () {
        $("#username").val("");
        $("#password").val("");
    });

    //回车
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            $("#loginok").click();
        }
    });
})    
