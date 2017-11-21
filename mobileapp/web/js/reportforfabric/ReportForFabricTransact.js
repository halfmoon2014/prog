var KEY = 0;
var POST;
var POSTUSER;
$(document).on('pageshow', function (event) {
    var urlObj = parseURL(window.location.href);
    KEY = urlObj.params.key;
    showLoader("加载中...");  
    test(KEY);
});



//确认
function Transact() {
    alert("qr");
}

//返回
function back() {
    window.location.href = "../reportforfabric/ReportForFabricDetail.htm?key="+KEY;
}
//得到审核流程的内容
function test(mykey) {
    if (mykey == undefined || mykey == 0) {
        return false;
    }
    var param = { mykey: mykey };
    $.ajax({ type: 'post',
        url: '../webService/reportforfabric.asmx/GetReportTransact',
        dataType: 'json',
        data: param,
        async: true,
        error: function (e) {
            console.log("err");
            hideLoader();
            var html = "<a href=\"../login.htm\" data-role=\"button\" rel='external' data-inline=\"true\"  data-transition=\"pop\">系统挂起中,请联系管理员 或点击重新登陆</a> ";
            ($("#reportforfabrictransact_content").html(html)).trigger('create');
        },
        success: function (data) {
            console.log("success");
            hideLoader();
            if (data != "") {
                var html = "";
                if (data.err == "session_error") {//session失效  
                    html += "<a href=\"../login.htm\" data-role=\"button\" rel='external' data-inline=\"true\"  data-transition=\"pop\">登陆超时,点击重新登陆</a> ";
                    ($("#reportforfabrictransact_content").html(html)).trigger('create');
                } else {
                    POSTUSER = JSON.parse(data.info1);
                    POST = JSON.parse(data.info0)
                    // <input type="radio" name="radio-choice-v-2" id="radio-choice-v-2a" value="on" checked="checked">
                    //        <label for="radio-choice-v-2a">One</label>
                    //        <input type="radio" name="radio-choice-v-2" id="radio-choice-v-2b" value="off">
                    //        <label for="radio-choice-v-2b">Two</label>
                    //        <input type="radio" name="radio-choice-v-2" id="radio-choice-v-2c" value="other">
                    //        <label for="radio-choice-v-2c">Three</label>
                    for (var i = 0; i < POST.length; i++) {
                        var id = POST[i].id; var mc = POST[i].mc;
                        html += "<input type=\"radio\" onclick=\"cpost('"+id+"')\" name=\"radio-choice-v-2\" id=\"radio-choice-post-" + id + "\" value=\"" + id + "\" >";
                        html += "<label for=\"radio-choice-post-" + id + "\">" + mc + "</label>";
                    }
                    ($("#reportforfabrictransact_post").html("<form><fieldset data-role=\"controlgroup\"><legend>请选择下一道岗位</legend>" + html + "</fieldset></form>")).trigger('create');
                    
                }

            }
        }
    });

}
function cpost(postid) { 
    var html = "";
    for (var i = 0; i < POSTUSER.length; i++) {
        if (POSTUSER[i].id == postid) {
            var id = POSTUSER[i].id; var mc = POSTUSER[i].mc; var userid = POSTUSER[i].userid;
            html += "<input type=\"radio\" name=\"radio-choice-v-2\" id=\"radio-choice-postuser-" + userid + "\" value=\"" + userid + "\" >";
            html += "<label for=\"radio-choice-postuser-" + userid + "\">" + mc + "</label>";
        }
    }
    //$("#reportforfabrictransact_postuser").next();
    ($("#reportforfabrictransact_postuser").html("<form><fieldset data-role=\"controlgroup\"><legend >请选择下一道办理人</legend>" + html + "</fieldset></form>")).trigger('create');
}