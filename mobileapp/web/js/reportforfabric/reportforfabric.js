
$(document).on('pageshow', function (event) {
  
    showLoader("加载中...");
    test();    
});

$(document).on('pageinit', function (event) {

});
function openReport(key) {    
    window.location.href = "../reportforfabric/ReportForFabricDetail.htm?key="+key;
}
//查询数据
function searchReport() {
    showLoader("加载中...");
    var materialcode = document.getElementById("materialcode").value;
    var reportnumber = document.getElementById("reportnumber").value;
    if (reportnumber == "") {
        reportnumber = 0;
    }
    var supplier = document.getElementById("supplier").value;
    test(reportnumber, supplier, materialcode);
}
//回首页
function home() {
    window.location.href = "../index.htm";
}
function test(reportnumber, supplier, materialcode) {
    console.log("test.js");
    if (reportnumber == undefined || reportnumber == "") {
        reportnumber = 0;
    }
    if (supplier == undefined) {
        supplier = "";
    }
    if (materialcode == undefined) {
        materialcode = "";
    }
    var param = { reportnumber: reportnumber, supplier: supplier, materialcode: materialcode };
    $.ajax({ type: 'post',
        url: '../webService/reportforfabric.asmx/GetReport',
        dataType: 'json',
        data:param,
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
                    
                    for (var i = 0; i < data.length; i++) {

                        html += "<li data-role=\"collapsible\" data-iconpos=\"right\" data-shadow=\"false\" data-corners=\"false\"><h2>报告编号:" + data[i].bgbh + "日期:" + data[i].rq + "</h2><table style='width:100%'><tr><td><div>客户名称:" + data[i].khmc + "</div><div>材料编码:" + data[i].chdm + "&nbsp;母体数:" + data[i].mtsl + "</div></td></tr><tr><td><a href=\"#\" data-role=\"button\"  onclick=\"openReport('" + data[i].id + "')\" data-icon=\"info\" data-transition=\"pop\">办理</a></td></tr></table></li>";
                       
                    }
                    html = "<ul data-role=\"listview\" class=\"ui-listview-outer\" data-inset=\"false\">" + html + "</ul>";
                }
                ($("#reportforfabric_content").html(html)).trigger('create');
            }
        }
    });
}