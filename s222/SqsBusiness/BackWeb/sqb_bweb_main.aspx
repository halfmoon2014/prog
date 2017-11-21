<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_main.aspx.cs"
    Inherits="SqsBusiness.sqb_bweb_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业管家</title>
    <%--JS引用--%>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <%--当前页面的JS代码,注意顺序，用到JQuery所以要先引用JQuery--%>
    <script type="text/javascript" src="/backweb/js/backweb/sqb_bweb_main.js"></script>
    <%--样式引用--%>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
    <link rel="Stylesheet" type="text/css" href="/backweb/css/backweb/sqb_bweb_main.css" />
</head>
<body id="main" class="easyui-layout" style="border: 5px solid rgb(210,224,242);
    margin: 0px; padding: 0px;" scroll="auto">
    <form id="form_main" runat="server">
    <div data-options="region:'north',split:true" style="height: 69px; overflow: hidden;">
        <iframe scrolling="no" frameborder="0" src="/backweb/main/sqb_bweb_north.aspx" style="width: 100%;
            height: 100%;"></iframe>
    </div>
    <div data-options="region:'west',split:true,iconCls:'icon-layout'" title="导航菜单" style="width: 187px;
        overflow: hidden;">
        <div class="easyui-accordion" data-options="fit:true,border:false">
            <div class="menubtn" title="考勤管理" data-options="iconCls:'icon-date'">
                <ul>
                    <%--<li><a href="#" url="/backweb/attendance/sqb_bweb_attendance_manage.aspx" class="nav">
                        考勤核查</a></li>--%>
                        <li><a href="#" url="/backweb/attendance/sqb_bweb_attendance_query.aspx" class="nav">
                        考勤查询</a></li>
                        <li><a href="#" url="/backweb/attendance/sqb_bweb_scheduling_set.aspx" class="nav">
                        考勤设置</a></li>
                </ul>
            </div>
            <div class="menubtn" title="出差管理" data-options="iconCls:'icon-calendar'">
                <ul>
                    <li><a href="#" url="/backweb/route/sqb_bweb_rount_dayline.aspx" class="nav">路线管理</a></li>
                    <li><a href="#" url="/backweb/route/sqb_bweb_rount_select.aspx" class="nav">拜访历史</a></li>
                </ul>
            </div>
            <div class="menubtn" title="GIS地图" data-options="iconCls:'icon-map'">
                <ul>
                    <li><a href="#" url="/backweb/route/sqb_bweb_rount_map.aspx" class="nav">路线查询</a></li>
                </ul>
            </div>
            <div class="menubtn" title="文档管理" data-options="iconCls:'icon-folder'">
                <ul>
                    <li><a href="#" url="/backweb/document/sqb_bweb_document_manage.aspx?type=public"
                        class="nav">公共文档</a></li>
                    <li><a href="#" url="/backweb/document/sqb_bweb_document_manage.aspx?type=person"
                        class="nav">个人文档</a></li>
                </ul>
            </div>
            <div class="menubtn" title="终端视频" data-options="iconCls:'icon-film'">
                <ul>
                    <li><a href="#" url="" class="nav">视频查看</a></li>
                </ul>
            </div>
            <div class="menubtn" title="照片管理" data-options="iconCls:'icon-picture'">
                <ul>
                    <li><a href="#" url="/backweb/photo/sqb_bweb_photo_manage.aspx" class="nav">照片核查</a></li>
                </ul>
            </div>
            <div class="menubtn" title="报表分析" data-options="iconCls:'icon-tip'">
                <ul>
                    <li><a href="#" url="" class="nav">考勤分析</a></li>
                    <li><a href="#" url="" class="nav">出差分析</a></li>
                </ul>
            </div>
            <div class="menubtn" title="客户管理" data-options="iconCls:'icon-user'">
                <ul>
                    <li><a href="#" url="/backweb/agency/sqb_bweb_sqb_agency.aspx" class="nav">经销商管理</a></li>
                    <li><a href="#" url="/backweb/client/sqb_bweb_sqb_client.aspx" class="nav">终端管理</a></li>
                </ul>
            </div>
            <div class="menubtn" title="信息管理" data-options="iconCls:'icon-email'">
                <ul>
                    <li><a href="#" url="/backweb/notice/sqb_bweb_notice_main.aspx" class="nav">公告管理</a></li>
                    <li><a href="#" url="/backweb/massage/sqb_bweb_message_manage.aspx" class="nav">短信管理</a></li>
                </ul>
            </div>
            <div class="menubtn" title="系统管理" data-options="iconCls:'icon-application'">
                <ul>
                    <li><a href="#" url="/backweb/user/sqb_bweb_users_groups.aspx" class="nav">组织架构</a></li>
                    <li><a href="#" url="/backweb/user/sqb_bweb_users_role.aspx" class="nav">角色管理</a></li>
                    <li><a href="#" url="/backweb/user/sqb_bweb_users.aspx" class="nav">用户管理</a></li>
                    <li><a href="#" url="/backweb/sys/sqb_bweb_property.aspx" class="nav">属性列表</a></li>
                    <li><a href="#" url="/backweb/sys/sqb_bweb_sysset.aspx" class="nav">系统设置</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div data-options="region:'center',iconCls:'icon-user_red'" style="overflow: hidden;">
        <div id="centertabs" class="easyui-tabs" data-options="fit:true,border:false">
            <div title="首页" style="padding: 20px; overflow: hidden;">
                <iframe scrolling="no" frameborder="0" src="/backweb/main/sqb_bweb_center.aspx" style="width: 100%;
                    height: 100%;"></iframe>
            </div>
        </div>
    </div>
    <div data-options="region:'south',border:true,split:true" style="height: 30px; overflow: hidden;
        background: rgb(210,224,242); text-align: center">
        <span>版权所有：石狮市商齐软件科技有限公司</span>
    </div>
    <div id="tabsMenu" class="easyui-menu" style="width: 120px;">
        <div id="close">
            关闭</div>
        <div id="Other">
            关闭其他</div>
        <div id="All">
            关闭所有</div>
    </div>
    </form>
</body>
</html>
