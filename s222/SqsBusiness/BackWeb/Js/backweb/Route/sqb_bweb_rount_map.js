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

    //根据组织架构的值来查询位于该组织架构内的业务代表人
    $("#user_groups").combotree({
        onChange: function (node) {
            var tree_obj = $('#user_groups').combotree('tree').tree('getChecked');
            var allid = "";

            $(tree_obj).each(function (i) {
                allid = allid + tree_obj[i].id + ",";
            })

            $("#linkman").combobox({
                url: "/backweb/webservice/sqb_bweb_users.ashx?loadmode=combo&user_groups=" + allid,
                valueField: 'id',
                textField: 'username'
            });
        }

    });

        //查询事件
    $("#search").click(function () {
        var map = new BMap.Map("clientmap");          // 创建地图实例
        var point = new BMap.Point(116.404, 39.915);  // 创建点坐标
        map.centerAndZoom(point, 15);  

            var starttime = $("#start_time").datebox('getValue');           //开始时间
            var endtime = $("#end_time").datebox('getValue');               //结束时间
            var linkman = $("#linkman").combobox('getValue');               //业务代表人

            $('#clientorder').datagrid({
                striped: false,   //奇偶数条纹
                fit: true,        //自动大小
                fitColumns: true, //自适应列宽
                url: "/backweb/user/sqb_bweb_users_role.aspx?mode=loadclient",  //获取数据
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
                rownumbers: true,     //行号列    
                singleSelect: false,  //是否单选
                pagination: true      //分页控件          
            });


            //根据条件查询数据显示到Datagrid控件上
//            $("#clientorder").datagrid({
//                url: 'sqb_bweb_rount_select.aspx?mode=getdatagrid&starttime=' + starttime + '&endtime=' + endtime + '&user_groups=' + zzjg + '&linkman=' + linkman + '&client_id=' + client_id + '&call_mode=' + call_mode + '&call_type=' + encodeURI(call_type),
//                idField: "id",
//                rownumbers: true,
//                pagination: true,
//                singleSelect: true,
//                sortName: 'client_name',        //排序字段
//                sortName: 'username',
//                sortName: 'job_content',
//                sortName: 'date',
//                sortName: 'call_mode',
//                sortName: 'call_type',
//                fit: true,        //自动大小
//                fitColumns: true, //自适应列宽
//                pageSize: 10,
//                pageList: [10, 20, 30, 40, 50, 60, 70, 80, 90, 100]
//            });
        });


    //    //***********************************************************   单击选择行：显示图片   ******************************************************************************

    //    //单击行事件
    //    $('#clientorder').datagrid({

    //        onClickRow: function (rowIndex, rowData) {

    //            if (rowData) {
    //                //得到日期框的日期时间段
    //                var starttime = $("#start_time").datebox('getValue');
    //                var endtime = $("#end_time").datebox('getValue');
    //                $.ajax({
    //                    type: "POST",
    //                    url: "sqb_bweb_rount_select.aspx",
    //                    data: { mode: "image", client_call_id: rowData.id, start_time: starttime, end_time: endtime },
    //                    success: function (result) {
    //                        //返回JSON
    //                        var json = eval(result);
    //                        //图片框默认显示的图片为空，且不可见
    //                        $("#images").attr("style", "display:none;");
    //                        document.getElementById("image1").setAttribute("src", "");
    //                        $("#label1").html("");
    //                        document.getElementById("newa1").setAttribute("href", "");

    //                        document.getElementById("image2").setAttribute("src", "");
    //                        $("#label2").html("");
    //                        document.getElementById("newa2").setAttribute("href", "");

    //                        document.getElementById("image3").setAttribute("src", "");
    //                        $("#label3").html("");
    //                        document.getElementById("newa3").setAttribute("href", "");

    //                        //如果返回的JSON数据不为空，则显示图片列表
    //                        if (result.toString() != "") {
    //                            $("#images").attr("style", "display:inherit;");
    //                        }

    //                        //显示图片
    //                        $(json).each(function (i) {
    //                            if (i == 0) {
    //                                var obj1 = document.getElementById("image1");
    //                                obj1.setAttribute("src", json[i].back_path1);
    //                                $("#label1").html("拍摄类型:" + json[i].type1 + "</br>拍摄日期:" + json[i].date1);
    //                                document.getElementById("newa1").setAttribute("href", json[i].back_path1);
    //                            } else if (i == 1) {
    //                                var obj1 = document.getElementById("image2");
    //                                obj1.setAttribute("src", json[i].back_path2);
    //                                $("#label2").html("拍摄类型:" + json[i].type2 + "</br>拍摄日期：" + json[i].date2);
    //                                document.getElementById("newa2").setAttribute("href", json[i].back_path2);
    //                            } else {
    //                                var obj1 = document.getElementById("image3");
    //                                obj1.setAttribute("src", json[i].back_path3);
    //                                $("#label3").html("拍摄类型:" + json[i].type3 + "</br>拍摄日期：" + json[i].date3);
    //                                document.getElementById("newa3").setAttribute("href", json[i].back_path3);
    //                            }
    //                        });

    //                    }
    //                });
    //            }

    //        }
    //    });
});

