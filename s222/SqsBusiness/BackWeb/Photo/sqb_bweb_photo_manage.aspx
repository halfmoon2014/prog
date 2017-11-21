<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_photo_manage.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Photo.sqb_bweb_photo_manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="../Js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <%--    <script type="text/javascript" src= "../Js/backweb/Route/sqb_bweb_rount_select.js"></script>--%>
    <link rel="stylesheet" type="text/css" href="../Css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="../Css/jquery.easyui/themes/default/easyui.css" />
    <title>照片核查</title>
    <script type="text/javascript">
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
            $("#zuzhijg").combotree({
                onChange: function (node) {

                    var tree_obj = $('#zuzhijg').combotree('tree').tree('getChecked');
                    var allid = "";
                    $(tree_obj).each(function (i) {
                        allid = allid + tree_obj[i].id + ",";
                    })
                    $("#linkman").combobox({
                        url: "sqb_bweb_photo_manage.aspx?mode=selectlink&zuzhijg=" + allid,
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
                        url: "sqb_bweb_photo_manage.aspx?mode=selectclient&user_id=" + $("#linkman").combobox('getValue'),
                        valueField: 'value',
                        textField: 'text'
                    });
                }
            });


            $("#search_image").click(function () {

                var starttime = $("#start_time").datebox('getValue');           //开始时间
                var endtime = $("#end_time").datebox('getValue');               //结束时间
                var photo_type = $("#photo_type").combobox('getValue');           //拍照类型
                var linkman = $("#linkman").combobox('getValue');               //业务代表人
                var client_name = $("#client_name").combobox('getText');         //客户名称
                var url = "mode=photos_preview&starttime=" + starttime + "&endtime=" + endtime + "&photo_type=" + photo_type + "&linkman=" + linkman + "&client_name=" + encodeURI(client_name);
                //                $.ajax({

                //                    type: "POST",
                //                    url: "sqb_bweb_photo_manage.aspx?" + url,


                //                    success: function (result) {

                //                        var obj_json = eval(result);
                //                        // var table = "<table width='800px'><tr><td>";
                //                        // var ddd="<img id='1' src=>";
                //                        var src = "";
                //                        var count = 0;
                //                        $(obj_json).each(function (i) {
                //                            count = i + 1;


                //                            if (count % 3 == 0) {
                //                                src += "<div><img id=" + i + " src='" + obj_json[i].path + "' width='200px' height='110px' /></br><a>asdfasdf</a></div>";

                //                            } else {
                //                                src += "<div style='float:left;margin:"0 0 10px 0"' ><img id=" + i + " src='" + obj_json[i].itemid + "' width='200px' height='110px' /></br><a>asdfasdf</a></div    >";

                //                            }
                //                          
                //                           
                //                        });
                //                        $("#photo_preview1").html(src);
                //                    }
                //                });

                //清空数据
               // $('#phototable').datagrid('loadData', { total: 0, rows: [] });
                $('#phototable').datagrid({


                    url: "sqb_bweb_photo_manage.aspx?"+url,

                    pagination: true,
                    total: 2000,
                    pageSize: 3,
                    pageList: [3, 10, 15, 20, 25, 30],

                    rownumbers: true,


                    remoteSort: false,
                    idField: 'itemid',

                    view: cardview

                });
            });





            var cardview = $.extend({}, $.fn.datagrid.defaults.view, {
                renderRow: function (target, fields, frozen, rowIndex, rowData) {
                    var cc = [];

                    cc.push('<td colspan=2 style="padding:5px 5px;border:0;float:left">');
                    if (!frozen) {
                        cc.push('<a  href="' + rowData.back_path + '" target=_blank title=点击可查看大图><img alt=不存在图片 src="' + rowData.back_path + '" style="height:150px;width:300px;float:left"></a>');
                        cc.push('<div style="float:left;margin-left:20px;">');

                        for (var i = 0; i < fields.length - 1; i++) {
                           
                            var copts = $(target).datagrid('getColumnOption', fields[i]);
                            cc.push('<p><span class="c-label">' + copts.title + ':</span> ' + rowData[fields[i]]);
                        }
                        cc.push('</div>');
                    }
                    cc.push('</td>');
                    return cc.join('');
                }
            });






        });
    </script>
</head>
<body id="main" class="easyui-layout" style="border: 5px solid rgb(255,255,255);
    margin: 0px; padding: 0px;" scroll="auto">
    <form id="fm_history" runat="server" fit="true">
    <div data-options="region:'north',title:'查询条件',split:true" style="height: 120px;">
        <table border="0">
            <tr>
                <td>
                    组织架构
                </td>
                <td>
                    <select id="zuzhijg" class="easyui-combotree" name="language" data-options="url:'../Route/sqb_bweb_rount_dayline_tree.ashx',cascadeCheck:true"
                        multiple style="width: 130px;">
                    </select>
                </td>
                <td>
                    开始时间
                </td>
                <td>
                    <input id="start_time" class="easyui-datebox" style="width: 130px" />
                </td>
                <td>
                    结束时间
                </td>
                <td>
                    <input id="end_time" class="easyui-datebox" style="width: 130px" />
                </td>
            </tr>
            <tr>
                <td>
                    照片类型
                </td>
                <td>
                    <select id="photo_type" class="easyui-combobox" runat="server" style="width: 130px">
                    </select>
                </td>
                <td>
                    业务代表
                </td>
                <td>
                    <select id="linkman" class="easyui-combobox" name="dept" style="width: 130px;">
                    </select>
                </td>
                <td>
                    终端名称
                </td>
                <td>
                    <select id="client_name" class="easyui-combobox" style="width: 130px">
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    客户组织
                </td>
                <td>
                    <select id="Select1" class="easyui-combobox" style="width: 130px">
                    </select>
                </td>
                <td>
                    客户属性
                </td>
                <td>
                    <select id="Select2" class="easyui-combobox" name="dept" style="width: 130px;">
                    </select>
                </td>
                <td>
                    客户类型
                </td>
                <td>
                    <select id="Select3" class="easyui-combobox" style="width: 130px">
                    </select>
                </td>
                <td colspan="2" align="center">
                    <a id="search_image" class="easyui-linkbutton" iconcls="icon-search" plain="true">查询</a>
                </td>
            </tr>
        </table>
    </div>
    <div id="photo_preview" data-options="region:'center',title:'图片预览',split:true" style="height: 100px;">
    <table id="phototable" singleSelect="true" fitColumns="true" fit=true fitcolumns=true remoteSort="false">
		<thead>
			<tr>
				<th field="client_name" width="80" sortable="true" hidden="true">客户名称</th>
				<th field="news_type" width="120" sortable="true" hidden="true">照片类型</th>
				<th field="date" width="80" sortable="true" hidden="true">拍摄日期</th>
                <th field="note" width="250" sortable="true" hidden="true">备注</th>
				<th field="back_path" width="250" sortable="true" hidden="true">地址</th>
				
			</tr>
		</thead>
	</table>
       <%-- <a id="photo_preview1"></a>--%>
    </div>
    </form>
</body>
</html>
