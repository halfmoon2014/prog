<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_users_groups.aspx.cs"
    Inherits="SqsBusiness.BackWeb.User.sqb_bweb_users_groups" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>组织架构</title>
    <%--JS引用--%>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <%--当前页面的JS代码,注意顺序，用到JQuery所以要先引用JQuery--%>
    <script type="text/javascript" src="/backweb/js/backweb/user/sqb_bweb_users_groups.js"></script>
    <%--样式引用--%>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/backweb/user/sqb_bweb_users_groups.css" />
</head>
<body id="main" class="easyui-layout" style="border: 5px solid rgb(255,255,255);
    margin: 0px; padding: 0px;" scroll="auto">
    <form id="form_users_groups" runat="server">
    <div data-options="region:'west',iconCls:'icon-layout',split:true,border:true" title="组织架构"
        style="width: 180px; overflow: hidden;">
        <ul id="groups_tree" class="easyui-tree">
        </ul>
    </div>
    <div id="center" data-options="region:'center',title:'编辑组织架构',border:true,iconCls:'icon-save'" style="overflow: hidden;">
        <div style="width: 98%; text-align: left; position: relative; top: 1%; left: 1%;">
            <a href="#" id="addgroups" class="easyui-linkbutton" iconcls="icon-add" plain="true">
                新建组织架构</a> <a href="#" id="addlowergroups" class="easyui-linkbutton" iconcls="icon-add"
                    plain="true">新建下级组织架构</a> <a href="#" id="delgroups" class="easyui-linkbutton" iconcls="icon-delete"
                        plain="true">删除当前组织架构</a> <a href="#" id="savegroups" groupsid="" savemode="add" class="easyui-linkbutton" iconcls="icon-save"
                            plain="true">保存</a>
        </div>
        <table cellspacing="3px" cellpadding="3px" style="width: 98%; position: relative;
            top: 5%; left: 1%;">
            <tr>
                <td align="right">
                    组织架构排序号：
                </td>
                <td>
                    <input id="order_id" class="easyui-validatebox" type="text" data-options="required:true,missingMessage:'组织架构排序号是必须的'" />
                    <span style="color: #FF0000">(用于处于同一层次组织架构的排序)</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    组织架构名称：
                </td>
                <td>
                    <input class="easyui-validatebox" id="name" type="text" data-options="required:true,missingMessage:'组织架构名称是必须的'" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    电话：
                </td>
                <td>
                    <input class="easyui-validatebox" id="phone" type="text" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    传真：
                </td>
                <td>
                    <input class="easyui-validatebox" id="fax" type="text" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    备注：
                </td>
                <td>
                    <input class="easyui-validatebox" id="note" type="text" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    上级组织架构：
                </td>
                <td>
                    <input id="pid" class="easyui-combotree" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
