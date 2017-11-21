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

    $('#users_role').datagrid({
        striped: false,   //奇偶数条纹
        fit: true,        //自动大小
        fitColumns: true, //自适应列宽
        url: "/backweb/user/sqb_bweb_users_role.aspx?mode=loadallrole",  //获取数据
        columns: [[       //字段
                    {field: 'id', title: '系统ID', width: 100, sortable: true },
                    { field: 'name', title: '角色名称', width: 100, sortable: true },
                    { field: 'note', title: '备注', width: 100, sortable: true },
                    { field: 'allow_content', title: '权限', width: 100, sortable: true },
                    { field: 'allow_id', title: '权限级别', width: 100, sortable: true },
                    { field: 'add_user_id', title: '新增用户', width: 100, sortable: true },
                    { field: 'update_user_id', title: '编辑用户', width: 100, sortable: true },
                    { field: 'add_time', title: '新增时间', width: 100, sortable: true },
                    { field: 'update_time', title: '编辑时间', width: 100, sortable: true }
                ]],
        rownumbers: true,    //行号列    
        singleSelect: true,  //是否单选
        pagination: true,    //分页控件          
        toolbar: [{          //工具栏
            text: '添加',
            iconCls: 'icon-add',
            handler: function () {
                OpenDialog("add");

            }
        }, '-', {
            text: '编辑',
            iconCls: 'icon-edit',
            handler: function () {
                OpenDialog("edit");
            }
        }, '-', {
            text: '删除',
            iconCls: 'icon-delete',
            handler: function () {
                OpenDialog("del");
            }
        }, '-', {
            text: '授权',
            iconCls: 'icon-user_edit',
            handler: function () {
                OpenDialog("del");
            }
        }]
    });

    //设置分页控件       
    var P = $('#users_role').datagrid('getPager');
    $(P).pagination({
        pageSize: 10, //每页显示的记录条数，默认为10           
        pageList: [10, 20, 50], //可以设置每页记录条数的列表           
        beforePageText: '第', //页数文本框前显示的汉字           
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });

    //打开对话框
    function OpenDialog(Mode) {
        $("#dialog_role").attr("savemode", Mode); //保存模式

        switch (Mode) {
            case "add":
                $("#dialog_role").dialog('open').dialog('setTitle', '新增用户角色');
                break;
            case "edit":
                var Row = $('#users_role').datagrid('getSelected');

                if (Row == null) {
                    $.messager.alert('错误提示', '请选择需要编辑的记录！', 'info');
                    return;
                }

                //读取角色信息
                $.ajax({
                    type: "POST",
                    url: "/backweb/user/sqb_bweb_users_role.aspx",
                    data: { mode: "loadrole", id: Row.id },
                    dataType: "json",
                    success: function (rjson) {
                        $("#allow_id").val(rjson[0].allow_id);
                        $("#name").val(rjson[0].name);
                        $("#note").val(rjson[0].note);
                        $("#dialog_role").attr("roleid", rjson[0].id);
                        $("#dialog_role").dialog('open').dialog('setTitle', '编辑用户角色');
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) { $.messager.alert('错误提示', errorThrown, 'error'); }
                });

                break;
            case "del":
                var Row = $('#users_role').datagrid('getSelected');

                if (Row == null) {
                    $.messager.alert('错误提示', '请选择需要删除的记录！', 'info');
                    return;
                }

                $.messager.confirm("信息提示", "是否要删除当前记录？", function (r) {
                    if (r) {
                        $("#dialog_role").attr("roleid", Row.id);

                        SaveRole(); //保存数据
                    }
                });

                break;
        }
    };

    //关闭对话框
    $("#cancel_role").click(function () {
        $("#dialog_role").dialog("close")
    });

    //对话框保存按钮
    $("#save_role").click(function () {
        SaveRole(); //保存角色
    });

    //保存角色
    function SaveRole() {
        $.ajax({
            type: "POST",
            url: "/backweb/user/sqb_bweb_users_role.aspx",
            data: { mode: "saverole", savemode: $("#dialog_role").attr("savemode"), roleid: $("#dialog_role").attr("roleid"), allow_id: $("#allow_id").val(), name: $("#name").val(), note: $("#note").val() },
            success: function (result) {
                if (result == "true") {
                    if ($("#dialog_role").attr("savemode") == "del") {
                        $.messager.alert('信息提示', '删除成功！', 'info');
                    }
                    else {
                        $.messager.alert('信息提示', '保存成功！', 'info');
                    }

                    $("#users_role").datagrid("reload"); //刷新datagrid数据

                    //新增清空控件
                    $("#allow_id").val("");
                    $("#name").val("");
                    $("#note").val("");

                    //关闭对话框
                    $("#dialog_role").dialog("close")
                }
                else {
                    $.messager.alert('错误提示', '保存失败，请重新保存！', 'info');
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) { $.messager.alert('错误提示', errorThrown, 'error'); }
        });
    };
});