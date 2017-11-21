<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_users_role.aspx.cs"
    Inherits="SqsBusiness.BackWeb.User.sqb_bweb_users_role" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>用户角色</title>
    <%--JS引用--%>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <%--当前页面的JS代码,注意顺序，用到JQuery所以要先引用JQuery--%>
    <script type="text/javascript" src="/backweb/js/backweb/user/sqb_bweb_users_role.js"></script>
    <%--样式引用--%>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
</head>
<body id="main" class="easyui-layout" style="border: 5px solid rgb(255,255,255);
    margin: 0px; padding: 0px">
    <form id="form_role" runat="server">
    <div id="center" data-options="region:'center',border:false" style="overflow: hidden">
        <table id="users_role" class="easyui-datagrid">
        </table>
    </div>
    <div id="dialog_role" class="easyui-dialog" data-options="closed:true,modal:true,title:'用户角色',iconCls:'icon-save'"
        style="width: 500px; height: 300px; padding: 5px;" savemode="add" roleid="">
        <div class="easyui-layout" data-options="fit:true">
            <div data-options="region:'center',border:false" style="padding: 10px; background: #fff;
                border: 1px solid #ccc;">
                <table>
                    <tr>
                        <td>
                            权限级别：
                        </td>
                        <td>
                            <input id="allow_id" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            角色名称：
                        </td>
                        <td>
                            <input id="name" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            备注：
                        </td>
                        <td>
                            <input id="note" type="text" />
                        </td>
                    </tr>
                </table>
            </div>
            <div data-options="region:'south',border:false" style="text-align: right; padding: 5px 0;">
                <a id="save_role" class="easyui-linkbutton" data-options="iconCls:'icon-save'" href="#">
                    保存</a> <a id="cancel_role" class="easyui-linkbutton" data-options="iconCls:'icon-cancel'"
                        href="#">取消</a>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
