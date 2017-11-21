
$(document).on('pageshow', function (event) {
    console.log("pageshow.js");
    showLoader("加载中...");
    test();
});

$(document).on('pageinit', function (event) {
    console.log("pageinit.js");
});
function contentGo(cmd) {
    if (cmd == "ReportForFabric") {
        window.location.href = "ReportForFabric/ReportForFabric.htm";
    }
}
function test() {
    console.log("test.js");
    $.ajax({ type: 'post',
        url: 'webService/index.asmx/getIndex',
        dataType: 'json',
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
                    html += "<a href=\"login.htm\" data-role=\"button\" rel='external' data-inline=\"true\"  data-transition=\"pop\">登陆超时,点击重新登陆</a> ";
                } else {
                    //                    var currentNo = 0;
                    for (var i = 0; i < data.length; i++) {
                        //                        if (currentNo == 0) {
                        //                            html += "<div class=\"ui-block-a\"><a href=\"#\" onclick=\"contentGo('" + data[i].command + "')\" data-role=\"button\"   data-transition=\"pop\">" + data[i].text + "</a>  </div>"
                        //                        } else if (currentNo == 1) {
                        //                            html += "<div class=\"ui-block-b\"><a href=\"#\" onclick=\"contentGo('" + data[i].command + "')\" data-role=\"button\"   data-transition=\"pop\">" + data[i].text + "</a>  </div>"
                        //                        }
                        //                        currentNo = currentNo + 1;
                        //                        if (currentNo == 2) {
                        //                            currentNo = 0;
                        //                        }
                        html += "<li data-icon=\"info\"><a href=\"#\" onclick=\"contentGo('" + data[i].command + "')\"     data-transition=\"pop\"><img src=\"images/ic_index_page.png\" /><h2>" + data[i].text + "</h2><p>" + data[i].description + "</p><span class=\"ui-li-count\">12</span></a> </li>  "
                    }
                    //                    html = "<div class=\"ui-grid-a\">" + html + "</div>";
                    html = "<ul data-role=\"listview\" data-inset=\"true\"  >" + html + "</ul>"
                }
                ($("#index_content").html(html)).trigger('create');
            }
        }
    });
}