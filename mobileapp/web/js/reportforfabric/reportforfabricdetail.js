var KEY = 0;
var SSP = "";//保存审批内容,再次刷新时直接调用
$(document).on('pageshow', function (event) {
    init();
});
//初始化,页面第一次呈现
function init() {
    $("a", "#navbar").click(function (e) {
        getDetail($(e.target).attr("mytype")) 
     });
    var urlObj = parseURL(window.location.href);
    KEY = urlObj.params.key;
    
    $("[index=0]", "#navbar").addClass("ui-btn-active");
    getDetail($("[index=0]", "#navbar").attr("mytype"));
}

$(document).on('pageinit', function (event) {
    $("#reportforfabricdetail").on("swipeleft", function () {
       
        //当前导航的li对象        
        var c = $(".ui-btn-active", "#navbar").parent().next();
        //移除当前选中class
        $(".ui-btn-active", "#navbar").removeClass("ui-btn-active");
        //下一个目标的mytype
        var mytype = ""; 
        if (c.length == 0) {//已经到最后一页
            mytype = $("a", "#navbar").first().attr("mytype");//第一页
            $("a", "#navbar").first().addClass("ui-btn-active");
        } else {
            mytype = $("a", $(c)).attr("mytype");            
            $("a", $(c)).addClass("ui-btn-active");
        }
        getDetail(mytype);

    });
    $("#reportforfabricdetail").on("swiperight", function () {
        //当前导航的li对象        
        var c = $(".ui-btn-active", "#navbar").parent().prev();
        //移除当前选中class
        $(".ui-btn-active", "#navbar").removeClass("ui-btn-active");
        //下一个目标的mytype
        var mytype = "";
        if (c.length == 0) {//已经到第一页
            mytype = $("a", "#navbar").last().attr("mytype"); //最后一页
            $("a", "#navbar").last().addClass("ui-btn-active");
        } else {
            mytype = $("a", $(c)).attr("mytype");
            $("a", $(c)).addClass("ui-btn-active");
        }
        getDetail(mytype);
    });
});
//办理
function go() {
    window.location.href = "../reportforfabric/ReportForFabricTransact.htm?key="+KEY;
}
//获取页面内容
function getDetail(f) {
    if (f == "sp") {
        showLoader("加载中...");    
        test(KEY);
    } else if (f == "zy") {
        ($("#reportforfabricdetail_content").html("")).trigger('create');
    } else if (f == "th") {
        ($("#reportforfabricdetail_content").html("")).trigger('create');
    }
}
//返回
function back() {
    window.location.href = "../reportforfabric/ReportForFabric.htm";
}
//得到审核流程的内容
function test(mykey) {
    if (mykey == undefined || mykey == 0) {
        return false;
    }
    if (SSP != "") {
        ($("#reportforfabricdetail_content").html(SSP)).trigger('create');
        hideLoader();
    } else {
        var param = { mykey: mykey };
        $.ajax({ type: 'post',
            url: '../webService/reportforfabric.asmx/GetReportDetail',
            dataType: 'json',
            data: param,
            async: true,
            error: function (e) {
                console.log("err");
                hideLoader();
                var html = "<a href=\"../login.htm\" data-role=\"button\" rel='external' data-inline=\"true\"  data-transition=\"pop\">系统挂起中,请联系管理员 或点击重新登陆</a> ";
                ($("#index_content").html(html)).trigger('create');
            },
            success: function (data) {
                console.log("success");
                hideLoader();
                if (data != "") {
                    var html = "";
                    if (data.err == "session_error") {//session失效  
                        html += "<a href=\"../login.htm\" data-role=\"button\" rel='external' data-inline=\"true\"  data-transition=\"pop\">登陆超时,点击重新登陆</a> ";
                    } else {
                        html += "<table style='width:100%'><tr><td>" + "报告编号:" + data[0].bgbh + "日期:" + data[0].rq + "</td></tr><tr><td><div>客户名称:" + data[0].khmc + "</div><div>材料编码:" + data[0].chdm + "&nbsp;母体数:" + data[0].mtsl + "</div><input type='hidden' value=" + data[0].id + "/></td></tr></table>";
                        SSP = html;

                    }
                    ($("#reportforfabricdetail_content").html(html)).trigger('create');
                }
            }
        });
    }
}