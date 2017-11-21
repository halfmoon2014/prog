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


    $('#luxianplan').panel({

        closable: false,
        disabled: true,
        collapsible: true


    });

    $("#luxiansort").panel({

        closable: false,
        collapsible: true

    });

    $("#luxiandata").panel({

        closable: false,
        collapsible: true

    });

    //根据组织架构的值来查询位于该组织架构内的业务代表人
    $("#zuzhijg").combotree({ onChange: function (node) {

        var tree_obj = $('#zuzhijg').combotree('tree').tree('getChecked');
        var allid = "";
        $(tree_obj).each(function (i) {
            allid = allid + tree_obj[i].id + ",";
        })

        if (allid == "") {
            $.messager.show({ title: "提示", msg: "组织架构不能为空！", timeout: 3000 });
            return;
        }

        $("#linkman").combobox({
            url: "sqb_bweb_rount_dayline.aspx?mode=selectlink&zuzhijg=" + allid,
            valueField: 'value',
            textField: 'text'
        });

    }
    });






    var currendate;     //当前日期控件选择的日期
    var lastIndex;      //datagrid最后一行的行号
    $('#link_calendar').calendar({
        onSelect: function (date) {             //当选择日期时触发

            var month = date.getMonth() + 1;
            var day = date.getDate();
            if (month.toString().length == "1") { month = "0" + month; }

            if (day.toString().length == "1") { day = "0" + day; }
            //得到当前选择的日期，格式为:2012-08-09
            currendate = (date.getFullYear() + "-" + month + "-" + day);
            var selectlink;         //当前选择的联系人


            //判断是否有选择组织架构和业务代表人，没有选择：提示用户要选择业务代表人;
            if ($("#zuzhijg").combotree('getText') == "") {
                $.messager.alert("信息提示", "组织架构和业务代表人都不能为空！", "info");
                return;
            } else {
                
                //得到当前业务代表人组合框的VALUE值
                selectlink = $('#linkman').combobox('getValue');

            }

            //清除表格的所有数据
            $('#luxiantable').datagrid('loadData', { total: 0, rows: [] });



            //如果以上条件都成立：则根据选择的日期和选择的业务代表人
            //得到该业务代表人所拥有的客户信息，显示在datagrid中
            //并将已安排的工作内容显示出来
            $('#luxiantable').datagrid({

                width: 748,
                height: 570,
                url: "sqb_bweb_rount_dayline.aspx?mode=link_calendar&date=" + currendate + "&selectlink=" + selectlink,

                pagination: true,
                total: 2000,
                pageSize: 10,
                pageList: [10,20,30,40,50,60,70,80,90,100],

                rownumbers: true,

                fit: true,        //自动大小
                fitColumns: true, //自适应列宽
                sortName: 'client_id',          //可以排序的字段名
                sortName: 'no',
                sortOrder: 'desc',
                remoteSort: false,

                idField: 'baifang',
                columns: [[
                        { field: 'id', title: '客户ID', width: 60,hidden:true },
                        { field: 'user_id', title: '用户id', width: 60,hidden:true },
                        { field: 'client_code', title: '编号', width: 60 },
                        { field: 'client_name', title: '终端名称', width: 120 },
                        { field: 'mendian_type', title: '门店类型', width: 60 },
                        { field: 'address', title: '地址', width: 180 },
                        { field: 'no', title: '拜访序号', width: 60, editor: "numberbox" },
                        { field: 'job_content', title: '工作内容', width: 160, editor: "text" },
                        { field: 'baifang', title: '拜访', width: 100, checkbox: true }
                ]],
                //单击某行时，设置该行的拜访顺序和工作内容为编辑状态
                onClickRow: function (rowIndex) {
                    if (lastIndex != rowIndex) {
                        $('#luxiantable').datagrid('endEdit', lastIndex);
                        $('#luxiantable').datagrid('beginEdit', rowIndex);
                    }
                    lastIndex = rowIndex;
                },
                //数据加载成功时，将已安排的工作路线自动打勾
                onLoadSuccess: function (data) {
                    $('#luxiantable').datagrid('clearSelections');          //清除打勾项
                    var rows = $('#luxiantable').datagrid('getRows');
                    for (var i = 0; i < rows.length; i++) {
                            $("#luxiantable").datagrid("selectRecord", rows[i].client_code.toString().trim() + rows[i].id.toString().trim());
                    }
                }

            });



        }
    });










    //保存datagrid的数据
    $("#save").click(function () {

        //结束编辑状态
        $('#luxiantable').datagrid('endEdit', lastIndex);

        var rows = $('#luxiantable').datagrid('getRows');       //得到所有行
        var rowscount = rows.length;                            //得到当前行的总行数

        var rowselected = $('#luxiantable').datagrid('getSelections');      //得到所有选择的行


        for (var i = 0; i < rowscount; i++) {
            for (var j = 0; j < rowselected.length; j++) {                  //将所有选择行的拜访单元格的值改为TRUE，保存
                rowselected[j].baifang = "true";
            }


            $.ajax({
                type: "POST",
                url: "sqb_bweb_rount_dayline.aspx?mode=savedata&yes=" + rows[i].baifang + "&date=" + currendate + "&client_id=" + rows[i].id + "&user_id=" + rows[i].user_id + "&call_order=" + rows[i].no + "&job_content=" + encodeURI(rows[i].job_content)
            });
        }
        
        if (rowscount == 0) { $.messager.alert("信息提示", "没有数据可保存！", "info"); }
        else {
        $("#luxiantable").datagrid("reload");
        $.messager.alert("信息提示", "数据保存成功", "info"); }

    });



});

