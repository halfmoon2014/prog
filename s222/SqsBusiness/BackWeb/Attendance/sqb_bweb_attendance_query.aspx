<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_attendance_query.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Attendance.sqb_bweb_attendance_query" %>

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
        $(function () {
            $('#record').datagrid({
                url: 'sqb_bweb_attendance_query.aspx',
                rownumbers: "true",
                fitColumns: true,
                pageSize: 20,
                pageList:[20,40,60,80,100],
                columns: [[
        { field: 'Date', title: '考勤日期', width: 100 },
        { field: 'Name', title: '班次类型', width: 100 },
        { field: 'SignType', title: '考勤类型', width: 100 },
        { field: 'Time', title: '考勤时间', width: 100 },
        { field: 'Type', title: '考勤状态', width: 100 }
    ]]
            });

            $('#dateStart').datebox({
                required: true,
                editable: false
            });

            $('#dateEnd').datebox({
                required: true,
                editable: false
            });


            $("#query").click(function () {
                if ($('#dateStart').datebox('getValue') == "") {
                    return;
                }
                if ($('#dateEnd').datebox('getValue') == "") {
                    return;
                }
                $('#record').datagrid({
                    url: 'sqb_bweb_attendance_query.aspx?getData=ture&dateStart=' + $('#dateStart').datebox('getValue') + "&dateEnd=" + $('#dateEnd').datebox('getValue'),
                    rownumbers: "true",
                    fitColumns: true,
                    pagination: true,
                    columns: [[
                        { field: 'Date', title: '考勤日期', width: 100 },
                        { field: 'Name', title: '班次类型', width: 100 },
                        { field: 'SignType', title: '考勤类型', width: 100 },
                        { field: 'Time', title: '考勤时间', width: 100 },
                        { field: 'Type', title: '考勤状态', width: 100 }
                    ]]
                });
            });

        });

        function query() {

        }
    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'north',title:'条件选择'" style="height: 80px;">
        <table>
            <tr style="width: 100%">
                <td style="width: 20%">
                    起始日期：
                    <input id="dateStart" type="text" />
                </td>
                <td style="width: 20%">
                    截至日期：
                    <input id="dateEnd" type="text" />
                </td>
                <td style="width: 20%">
                    <a id="query" onclick="query()" class="easyui-linkbutton" data-options="iconCls:'icon-search'">
                        查询</a>
                </td>
            </tr>
        </table>
    </div>
    <div data-options="region:'center',title:'考勤查询'">
        <table id="record" fit="true">
        </table>
    </div>
    </form>
</body>
</html>
