$(function () {

    //*****************************************************************页面初始调整************************************************************************
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


    $('#history_search').panel({
        closable: false,
        disabled: true
    });

    //**************************************************************组织架构   业务代表***************************************************************************

    //根据组织架构的值来查询位于该组织架构内的业务代表人
    $("#zuzhijg").combotree({
        onChange: function (node) {

            var tree_obj = $('#zuzhijg').combotree('tree').tree('getChecked');
            var allid = "";
            $(tree_obj).each(function (i) {
                allid = allid + tree_obj[i].id + ",";
            })

//            if (allid == "") {          //
//                $.messager.show({ title: "提示", msg: "组织架构不能为空！", timeout: 3000 });
//                return;
//            }

            $("#linkman").combobox({
                url: "sqb_bweb_rount_select.aspx?mode=selectlink&zuzhijg=" + allid,
                valueField: 'value',
                textField: 'text'
            });
        }

    });


    //***************************************************************   客户名称   **************************************************************************

    //根据业务代表人得到所有的客户信息
    $("#linkman").combobox({
        onSelect: function () {

            $("#client_name").combobox({
                url: "sqb_bweb_rount_select.aspx?mode=selectclient&user_id=" + $("#linkman").combobox('getValue'),
                valueField: 'value',
                textField: 'text'
            });
        }
    });

    //****************************************************************  查询数据   *************************************************************************

    //查询事件
    $("#search").click(function () {
        var tree_obj = $("#zuzhijg").combotree('tree').tree('getChecked');
        var zzjg = "";
       
        $(tree_obj).each(function (i) {
            zzjg = zzjg + tree_obj[i].id + ",";

        });

        //得到文本控件的值
      
        var starttime = $("#start_time").datebox('getValue');           //开始时间
        var endtime = $("#end_time").datebox('getValue');               //结束时间
        var linkman = $("#linkman").combobox('getValue');               //业务代表人
        var client_id = $("#client_name").combobox('getValue');         //客户名称
        var call_mode = $("#call_mode").combobox('getValue');           //拜访类型
        var call_type = $("#call_type").combobox('getText');            //拜访模式
        
            
         //根据条件查询数据显示到Datagrid控件上
        $("#historytable").datagrid({
            url: 'sqb_bweb_rount_select.aspx?mode=getdatagrid&starttime=' + starttime + '&endtime=' + endtime + '&zuzhijg=' + zzjg + '&linkman=' + linkman + '&client_id=' + client_id + '&call_mode=' + call_mode + '&call_type=' + encodeURI(call_type),
            idField: "id",
            rownumbers: true,
            pagination: true,
            singleSelect: true,
            sortName: 'client_name',        //排序字段
            sortName: 'username',
            sortName: 'job_content',
            sortName: 'date',
            sortName: 'call_mode',
            sortName:'call_type',
            fit: true,        //自动大小
            fitColumns: true, //自适应列宽
            pageSize: 10,
            pageList: [10,20,30,40,50,60,70,80,90,100]
        });
    });


    //***********************************************************   单击选择行：显示图片   ******************************************************************************

    //单击行事件
    $('#historytable').datagrid({

        onClickRow: function (rowIndex, rowData) {

            if (rowData) {
                //得到日期框的日期时间段
                var starttime = $("#start_time").datebox('getValue');
                var endtime = $("#end_time").datebox('getValue');
                $.ajax({
                    type: "POST",
                    url: "sqb_bweb_rount_select.aspx",
                    data: { mode: "image", client_call_id: rowData.id, start_time: starttime, end_time: endtime },
                    success: function (result) {
                    //返回JSON
                        var json = eval(result);
                        //图片框默认显示的图片为空，且不可见
                        $("#images").attr("style", "display:none;");
                        document.getElementById("image1").setAttribute("src", "");
                        $("#label1").html("");
                        document.getElementById("newa1").setAttribute("href", "");

                        document.getElementById("image2").setAttribute("src", "");
                        $("#label2").html("");
                        document.getElementById("newa2").setAttribute("href", "");

                        document.getElementById("image3").setAttribute("src", "");
                        $("#label3").html("");
                        document.getElementById("newa3").setAttribute("href", "");

                        //如果返回的JSON数据不为空，则显示图片列表
                        if (result.toString() != "") {
                            $("#images").attr("style", "display:inherit;");
                        }

                        //显示图片
                        $(json).each(function (i) {
                            if (i == 0) {
                                var obj1 = document.getElementById("image1");
                                obj1.setAttribute("src", json[i].back_path1);
                                $("#label1").html("拍摄类型:"+json[i].type1+"</br>拍摄日期:" + json[i].date1);
                                document.getElementById("newa1").setAttribute("href", json[i].back_path1);
                            } else if (i == 1) {
                                var obj1 = document.getElementById("image2");
                                obj1.setAttribute("src", json[i].back_path2);
                                $("#label2").html("拍摄类型:" + json[i].type2 + "</br>拍摄日期：" + json[i].date2);
                                document.getElementById("newa2").setAttribute("href", json[i].back_path2);
                            } else {
                                var obj1 = document.getElementById("image3");
                                obj1.setAttribute("src", json[i].back_path3);
                                $("#label3").html("拍摄类型:" + json[i].type3 + "</br>拍摄日期：" + json[i].date3);
                                document.getElementById("newa3").setAttribute("href", json[i].back_path3);
                            }
                        });

                    }
                });
            }

        }
    });
});