<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_message_manage.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Massage.sqb_bweb_message_manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
    <script type="text/javascript" charset="utf-8">
        $(function () {

            $("#dg").datagrid({
                toolbar: "#tb",
                loadMsg: '数据加载中,请稍后......',
                singleselect: "true",
                rownumbers: "true",
                fit: "true",
                striped: "true",
                fitColumns: "true",
                pagination: "true",
                pageSize: 10,
                nowrap: "true",
                url: "sqb_bweb_message_manage.aspx?mode=loadtable",
                rownumbers: "true",    //行号列    
                singleSelect: "true",  //是否单选
                pagination: "true",    //分页控件    
                idfield: "id",
                singleSelect: "true",
                columns: [[
                    { field: 'ID', title: '短信ID', hidden: true, sortable: true },
					{ field: 'Recipient', title: '接受人', width: 100, sortable: true },
					{ field: 'Title', title: '短信标题', width: 100, sortable: true },
                    { field: 'Content', title: '短信内容', width: 100, sortable: true },
					{ field: 'Date', title: '发送时间', width: 100, align: 'right', editor: { type: 'numberbox', options: { precision: 1} }, sortable: true },
					{ field: 'ReadUser', title: '短信查看人', width: 140, align: 'right', editor: 'numberbox', sortable: true },
                    { field: 'Temp_File', title: '附件路径', width: 100, sortable: true },
                    { field: 'Add_User_Name', title: '发送人', width: 80, sortable: true }
				]],               
            });
            var p = $('#dg').datagrid('getPager');         
            $(p).pagination({             
                pageSize: 10,//每页显示的记录条数，默认为10             
                pageList: [10,20,30,40,50],//可以设置每页记录条数的列表             
                beforePageText: '第',//页数文本框前显示的汉字             
                afterPageText: '页    共 {pages} 页',             
                displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'                  
            });  

            $("#Recipient").combobox({
                url: 'sqb_bweb_message_manage.aspx?mode=loadcbbox',
                valueField: 'id',
                textField: 'text',
            });
            $("#Add_User_Name").combobox({
                url: 'sqb_bweb_message_manage.aspx?mode=loadcbbox',
                valueField: 'id',
                textField: 'text'

            });
        });
        //var row = $('#dg').datagrid('getSelected');
//        $("#Recipient").combobox({
//            url: 'sqb_bweb_message_manage.aspx?mode=cRecipient',
//            valueField: 'id',
//            textField: 'text'
//        });


        function del() {
            var row = $('#dg').datagrid('getSelected');
            if (row) {
                $.messager.confirm('提示', '你确定要删除吗?', function (r) {
                    if (r) {
                        $.post('sqb_bweb_message_manage.aspx', { ID: row.ID }, function (result) {
                            if (result) {
                                $('#dg').datagrid('reload');
                                alert("OK")
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
        function Select() {

            var searchs = $("#searchs").datebox('getValue');           //开始时间
            var searche = $("#searche").datebox('getValue');               //结束时间
            var Recipient = $("#Recipient").combobox('getText');               //接收人
            var Add_User_Name = $("#Add_User_Name").combobox('getValue');         //发送人ID
            var Add_User_Name1 = $("#Add_User_Name").combobox('getText');            //发送人姓名
            //location.href = "sqb_bweb_message_manage.aspx?action=Select&searchs =" + searchs + "&searche=" + searche + "&Recipient=" + Recipient + "&Add_User_Name=" + Add_User_Name;
            $("#dg").datagrid({
                url: "sqb_bweb_message_manage.aspx?mode=Select&searchs=" + searchs + "&searche=" + searche + "&Recipient=" + Recipient + "&Add_User_Name=" + Add_User_Name+"&Add_User_Name1="+ Add_User_Name1,
                idField: "id",
                rownumbers: "true",
                pagination: "true",
                singleSelect: "true",
                sortName: "Recipient",        //排序字段
                sortName: "Title",
                sortName: "Content",
                sortName: "date",
                sortName: "ReadUser",
                sortName: "Temp_File",
                sortName:"Add_User_Name",
                fit: "true",        //自动大小
                fitColumns: "true", //自适应列宽
                pageSize: 5,
                pageList: [5, 10, 15, 20, 25, 30, 35, 40, 45, 50]
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="panel datagrid">
        <div class="panel-header" style="width: auto;">
            <div class="panel-title">
                短信管理</div>
            <div class="panel-tool">
            </div>
        </div>
        <div id="easyui-tabs" title="短信管理" style="width: auto; height: auto;" fit="true"
            border="false">
            <table id="dg" class="easyui-datagrid" data-options="url:'sqb_bweb_message_select.ashx'">
                <thead>
                    <tr>
                    </tr>
                </thead>
                <div id="tb">
                    <%-- <a class="easyui-linkbutton" iconcls="icon-edit" plain="true" id="edit" onclick="edit()">
                                修改</a>                 
                                   <a class="easyui-linkbutton" iconcls="icon-add" plain="true" id="add" target="_self">
                        新增</a> --%>
                    <label>
                        发送时间段:</label>
                    <select id="searchs" class="easyui-datebox" runat="server">
                    </select>
                    <label>
                        至：</label>
                    <select id="searche" class="easyui-datebox" runat="server">
                    </select>
                    <label>
                        收件人：</label>
                    <select id="Recipient" class="easyui-combobox" runat="server">
                    </select>
                    <label>
                        发送人：</label>
                    <select id="Add_User_Name" class="easyui-combobox" runat="server">
                    </select>
                    <%--<input type="button" id="Select" runat="server" value="查询" onclick="return Select_onclick()" />--%>
                    <a class="easyui-linkbutton" iconcls="icon-search" plain="true" id="Select" onclick="Select()">
                        查询</a> <a class="easyui-linkbutton" iconcls="icon-cut" plain="true" id="del" onclick="del()">
                            删除 </a>
                    <asp:Label runat="server" ID="text"></asp:Label>
                    <%--    searchbox
                    <input id="ss" /> 
    <div id="mm" style="width:120px">  
        <div data-options="Recipient:'Recipient',iconCls:'icon-ok'">接收人</div>  
        <div data-options="Add_User_Name:'Add_User_Name'">发送人</div>  
    </div>  --%>
                </div>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
