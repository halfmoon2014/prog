//跳转页面
function goTo(page) {
    $.mobile.changePage(page, {
        transition: "slide"
    });
}
//显示加载器
function showLoader(showText) {
    if (showText == undefined) {
        showText = "登陆中...";
    }
    console.log("showLoader");
    //显示加载器.for jQuery Mobile 1.2.0
    $.mobile.loading('show', {
        text: showText, //加载器中显示的文字
        textVisible: true, //是否显示文字
        theme: 'a',        //加载器主题样式a-e
        textonly: false,   //是否只显示文字
        html: ""           //要显示的html内容，如图片等
    });
}

//隐藏加载器.for jQuery Mobile 1.2.0
function hideLoader() {
    //隐藏加载器
    console.log("hideLoader");
    $.mobile.loading('hide');
}
//对话框
function showMsg(page, msg) {
    if (page == "#index_dialog") {
        $("#index_dialog_info", $(page)).html(msg);
    }
    $.mobile.changePage(page, {
        transition: "pop"
    });
}
function parseURL(url) {
    var a = document.createElement('a');
    //创建一个链接
    a.href = url;
    return {
        source: url,
        protocol: a.protocol.replace(':', ''),
        host: a.hostname,
        port: a.port,
        query: a.search,
        params: (function () {
            var ret = {},
            seg = a.search.replace(/^\?/, '').split('&'),
            len = seg.length, i = 0, s;
            for (; i < len; i++) {
                if (!seg[i]) { continue; }
                s = seg[i].split('=');
                ret[s[0]] = s[1];
            }
            return ret;
        })(),
        file: (a.pathname.match(/\/([^\/?#]+)$/i) || [, ''])[1],
        hash: a.hash.replace('#', ''),
        path: a.pathname.replace(/^([^\/])/, '/$1'),
        relative: (a.href.match(/tps?:\/\/[^\/]+(.+)/) || [, ''])[1],
        segments: a.pathname.replace(/^\//, '').split('/')
    };
}