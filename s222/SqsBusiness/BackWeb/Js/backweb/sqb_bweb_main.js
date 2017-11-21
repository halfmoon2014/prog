$(function () {
    //初始时自适应
    var sHeight = $(window).height() - 10;
    $("#main").css({ "height": sHeight });
    //重新布局
    $("#main").layout();

    // 改变窗体大小时自适应
    $(window).resize(function () {
        var sHeight = $(window).height() - 10;

        $("#main").css({ "height": sHeight });

        //重新布局
        $("#main").layout();
    });

    //菜单单击添加tab
    $(".nav").click(function () {
        var title = $.trim($(this).text());
        //取得自定义的url
        var href = $.trim($(this).attr("url"));

        //验证该选择项是否存在，如果存在则选择
        if ($("#centertabs").tabs("exists", title)) {
            $("#centertabs").tabs("select", title);
        }
        else {
            if (href) {
                var content = '<iframe scrolling="no" frameborder="0" src="' + href + '" style="width:100%;height:100%;margin:0;padding:0;"></iframe>';
            } else {
                var content = '未实现';
            }

            //添加选择项
            $("#centertabs").tabs("add", {
                title: title,
                closable: true,
                content: content,
                tools: [{
                    iconCls: 'icon-mini-refresh',
                    handler: function () {
                        var selecttabs = $("#centertabs").tabs("getSelected");

                        //刷新tab
                        $("#centertabs").tabs("update", {
                            tab: selecttabs,
                            options: {
                                content: content
                            }
                        });
                    }
                }]
            });
        }
    });

    //绑定tabs的右键菜单
    $("#centertabs").tabs({
        onContextMenu: function (e, title) {
            e.preventDefault();
            $('#tabsMenu').menu('show', {
                left: e.pageX,
                top: e.pageY
            }).data("tabTitle", title);
        }
    });


    //实例化menu的onClick事件
    $("#tabsMenu").menu({
        onClick: function (item) {
            CloseTab(this, item.id);
        }
    });

    //几个关闭事件的实现
    function CloseTab(menu, type) {
        var curTabTitle = $(menu).data("tabTitle");
        var tabs = $("#centertabs");

        //关闭当前
        if (type === "close") {
            var thistab = tabs.tabs("getTab", curTabTitle);

            if ($(thistab).panel("options").closable) {
                tabs.tabs("close", curTabTitle);
            }

            return;
        }

        //关闭所有或其它
        var allTabs = tabs.tabs("tabs");
        var closeTabsTitle = [];

        $.each(allTabs, function () {
            var opt = $(this).panel("options");

            if (opt.closable && opt.title != curTabTitle && type === "Other") {
                closeTabsTitle.push(opt.title);
            } else if (opt.closable && type === "All") {
                closeTabsTitle.push(opt.title);
            }
        });

        for (var i = 0; i < closeTabsTitle.length; i++) {
            tabs.tabs("close", closeTabsTitle[i]);
        }
    };
});