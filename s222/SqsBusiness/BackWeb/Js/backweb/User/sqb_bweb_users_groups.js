$(function () {
    //初始时自适应
    var sHeight = $(window).height() - 10;
    $("#main").css({ "height": sHeight }); //设置高度
    $("#main").layout(); //重新布局

    // 改变窗体大小时自适应
    $(window).resize(function () {
        var sHeight = $(window).height() - 10;
        $("#main").css({ "height": sHeight }); //设置高度
        $("#main").layout(); //重新布局
    });

    //初始化树目录
    $("#groups_tree").tree({
        url: "/backweb/user/sqb_bweb_users_groups.aspx?mode=loadtree",
        onClick: function (node) {
            //读取当前组织架构信息
            $.ajax({
                type: "POST",
                url: "/backweb/user/sqb_bweb_users_groups.aspx",
                data: { mode: "loadgroups", id: node.id },
                dataType: "json",
                success: function (gjson) {
                    $("#order_id").val(gjson[0].order_id);
                    $("#name").val(gjson[0].name);
                    $("#phone").val(gjson[0].phone);
                    $("#fax").val(gjson[0].fax);
                    $("#note").val(gjson[0].note);
                    $("#pid").combotree("setValue", gjson[0].pid);  //上级组织架构
                    $("#savegroups").attr("groupsid", gjson[0].id) //当前ID
                    $("#savegroups").attr("savemode", "edit"); //保存模式
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) { $.messager.alert('错误提示', errorThrown, 'error'); }
            });
        }
    });

    //上级组织架构
    $("#pid").combotree({
        url: "/backweb/user/sqb_bweb_users_groups.aspx?mode=loadtree"
    });

    //新增组织架构
    $("#addgroups").click(function () {
        AddVal(); //新增清空控件
    });

    //新建下级组织架构
    $("#addlowergroups").click(function () {
        $("#order_id").val("");
        $("#name").val("");
        $("#phone").val("");
        $("#fax").val("");
        $("#note").val("");
        $("#savegroups").attr("savemode", "add"); //保存模式
        $("#pid").combotree("setValue", $("#groups_tree").tree("getSelected").id) //上级组织架构
    });

    //删除当前组织架构
    $("#delgroups").click(function () {
        $("#savegroups").attr("savemode", "del"); //保存模式

        SaveData(); //保存数据
    });

    //保存组织架构
    $("#savegroups").click(function () {
        if ($("#order_id").val() == "" || $("#order_id").val() == null) {
            $.messager.alert('错误提示', '组织架构顺序号不能为空！', 'info');
            return;
        }

        if ($("#name").val() == "" || $("#name").val() == null) {
            $.messager.alert('错误提示', '组织架构名称不能为空！', 'info');
            return;
        }

        SaveData();  //保存数据
    });

    //保存数据
    function SaveData() {
        $.ajax({
            type: "POST",
            url: "/backweb/user/sqb_bweb_users_groups.aspx",
            data: { mode: "savegroups", savemode: $("#savegroups").attr("savemode"), groupsid: $("#savegroups").attr("groupsid"), order_id: $("#order_id").val(), name: $("#name").val(), phone: $("#phone").val(), fax: $("#fax").val(), note: $("#note").val(), pid: $("#pid").combotree("getValue") },
            success: function (result) {
                if (result == "true") {
                    if ($("#savegroups").attr("savemode") == "del") {
                        $.messager.alert('信息提示', '删除成功！', 'info');
                    }
                    else {
                        $.messager.alert('信息提示', '保存成功！', 'info');
                    }

                    $("#groups_tree").tree("reload"); //刷新tree数据
                    $("#pid").combotree("reload"); //刷新combotree数据

                    AddVal(); //新增清空控件
                }
                else {
                    $.messager.alert('错误提示', '保存失败，请重新保存！', 'info');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { $.messager.alert('错误提示', errorThrown, 'error'); }
        });
    }

    //新增清空控件
    function AddVal() {
        $("#order_id").val("");
        $("#name").val("");
        $("#phone").val("");
        $("#fax").val("");
        $("#note").val("");
        $("#savegroups").attr("savemode", "add"); //保存模式
        $("#pid").combotree("setText", "") //上级组织架构
        $("#pid").combotree("setValue", "") //上级组织架构
    }
});
