<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_notice_main.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Notice.sqb_bweb_notice_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
    <script type="text/javascript">
    $(window).resize(function () {
        var sHeight = $(window).height() - 10;
        $("#dg").css({ "height": sHeight }); //设置高度
        $("#dg").layout(); //重新布局
    });
        $(function () {
            $("#dg").datagrid({
                toolbar: "#tb",
                loadMsg:'数据加载中,请稍后......',
                singleselect:"true",
                rownumbers:"true",
                fit:"true",
                fitColumns:"true",
                pagination:"true" ,
                pageSize:10,
                striped: "true",
                nowrap:"true",
                url: "sqb_bweb_notice_main.aspx?mode=1",
                idfield:"id",
                rownumbers: "true",    //行号列    
                singleSelect: "true",  //是否单选
                pagination: "true",    //分页控件    
                idfield: "id",
                singleSelect: "true",
                 columns: [[
                    { field: 'ID', title: 'ID', hidden: true },
					{ field: 'Title', title: '新闻标题', width: 140 },
					{ field: 'Notice_Content', title: '新闻标题', width: 140 },
                    { field: 'Notice_Type_ID',title:'新闻类型',width: 140},
					{ field: 'Date', title: '发布日期', width: 140, align: 'right', editor: { type: 'numberbox', options: { precision: 1}} },
					{ field: 'Active_Time', title: '有效日期', width: 140, align: 'right', editor: 'numberbox' },
                    { field: 'Add_User_Name', title: '发布人', width: 80,}			
				]]
            });
            var p = $('#dg').datagrid('getPager');         
            $(p).pagination({             
                pageSize: 10,//每页显示的记录条数，默认为10             
                pageList: [10,20,30,40,50],//可以设置每页记录条数的列表             
                beforePageText: '第',//页数文本框前显示的汉字             
                afterPageText: '页    共 {pages} 页',             
                displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'                  
            });  
            $('#serch').searchbox({
                prompt: '搜索',
                menu:('#mm'),

                searcher: function (value, name) {
//                    $('#dg').datagrid('load', {
//                        "searchKey": name, 
//                        "searchValue": value ,
//                        });
                alert(value+";"+name);
                }
            });
    });

function del() {
            var row = $('#dg').datagrid('getSelected');
            if (row) {
                $.messager.confirm('提示', '你确定要删除吗?', function (r) {
                    if (r) {
                        $.post('sqb_bweb_notice_main.aspx', { ID: row.ID }, function (result) {
                            if (result) {
                                $('#dg').datagrid('reload'); 
                                alert("删除成功")
                            } else {  
                            alert("Error"),                               
                                $.messager.show({	
                                    title: 'Error',
                                    msg: result.msg
                                    
                                });
                            }
                        }, 'json');
                    }
                });
            }
        }
        function edit(){
            var row = $('#dg').datagrid('getSelected');
            var mode = 1;
            location.href="sqb_bweb_notice_send.aspx?ID="+ row.ID+"&action=edit";
//            if (row) {
////                $.post("sqb_bweb_notice_send.aspx",{mode:mode}) 

//            }
        }
//        function edit(){
//            var row = $('#dg').datagrid('getSelected');
//            var mode = 1;
//            if (row) {
//             $.post('sqb_bweb_notice_send.aspx',{ mode: mode},function (result){
//             alert(mode);
//                if(result){
//                    alert(O.K);
//                }
//                else{
//                    alert(k.o)
//                }
//                },'json');
////                location.href="sqb_bweb_document_design.aspx?id="+row.ID;
//            }
//        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel datagrid">
        <div class="panel-header" style="width: auto;">
            <div class="panel-title">
                新闻管理</div>
            <div class="panel-tool">
            </div>
        </div>
        <div id="easyui-tabs" title="新闻管理" style="width: auto; height: auto;" fit="true"
            border="false">
            <table id="dg" class="easyui-datagrid">
                <thead>
                    <tr>
                        <%--<th field="Title" width="140">标题</th>
				<th field="Notice_Content" width="80">内容摘要</th>style="width: 778px; height: 574px"
                <th field="Notice_Type" width="60">新闻类型</th>
				<th field="Date" width="140" align="right">发布时间</th>
				<th field="Active_Time" width="180" align="right">有效日期</th>
				<th field="Add_User" width="60">发布人</th>       --%>
                    </tr>
                </thead>
                <div id="tb">
                    <a class="easyui-linkbutton" iconcls="icon-add" plain="true" id="add" href="sqb_bweb_notice_send.aspx"
                        target="_self">新增</a> <a class="easyui-linkbutton" iconcls="icon-cut" plain="true"
                            id="del" onclick="del()">删除</a> <a class="easyui-linkbutton" iconcls="icon-edit"
                                plain="true" id="edit" onclick="edit()">修改</a> <a class="easyui-linkbutton" iconcls="icon-search"
                                    plain="true" id="Select" onclick="Select()">查询</a>
                    <label>
                        发送时间段:</label>
                    <select id="searchs" class="easyui-datebox" runat="server">
                    </select>
                    <label>
                        至：</label>
                    <select id="searche" class="easyui-datebox" runat="server">
                    </select>
                    <label>
                        发送人：</label>
                    <select id="Add_User_Name" class="easyui-combobox" runat="server">
                    </select>
                    <%--easyui 控件 searchbox--%>
                    <%--<input id="serch" class="easyui-searchbox" style="width: 300px" runat="server" />--%>
                    <%--<div id="search" onclick="search"></div>'#search'---------data-options="prompt:'搜索',menu:'#mm', searcher:function(value,name){alert(value+':'+name)} " --%>
                    <%--<div id="mm" style="width: 120px">
                    <div data-options="Title:'Title',iconCls:'icon-ok'">
                        标题</div>
                    <div data-options="Notice_Type:'Notice_Type'">
                        新闻类型</div>
                    <div data-options="Add_User_Name:'Add_User_Name'">
                        发布人</div>
                </div>--%>
                    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                </div>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
