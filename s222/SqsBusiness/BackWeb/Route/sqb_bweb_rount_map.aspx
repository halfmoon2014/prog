<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_rount_map.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Route.sqb_bweb_rount_map" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>路线查询</title>
    <%--JS引用--%>
    <script type="text/javascript" src="/backweb/js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/backweb/js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.3"></script>
    <%--当前页面的JS代码,注意顺序，用到JQuery所以要先引用JQuery--%>
    <script type="text/javascript" src="/backweb/js/backweb/route/sqb_bweb_rount_map.js"></script>
    <%--样式引用--%>
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/backweb/css/jquery.easyui/themes/default/easyui.css" />
</head>
<body id="main" class="easyui-layout" style="border: 5px solid rgb(210,224,242);
    margin: 0px; padding: 0px;" scroll="auto">
    <form id="form_map" runat="server">
    <div data-options="region:'north',title:'查询条件',split:true" style="height: 70px;">
        <table border="0">
            <tr>
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
                <td>
                    组织架构
                </td>
                <td>
                    <select id="user_groups" class="easyui-combotree" data-options="url:'/backweb/webservice/sqb_bweb_users_groups.ashx?loadmode=tree',cascadeCheck:true"
                        multiple="multiple" style="width: 130px;">
                    </select>
                </td>
                <td>
                    业务代表
                </td>
                <td>
                    <select id="linkman" class="easyui-combobox" name="dept" style="width: 130px;">
                    </select>
                </td>
                <td align="center">
                    <a id="search" class="easyui-linkbutton" iconcls="icon-search" plain="true">查询</a>
                    <a id="exportexcel" class="easyui-linkbutton" iconcls="icon-save" plain="true">导出Excel</a>
                </td>
            </tr>
        </table>
    </div>
    <div id="center" data-options="region:'center',split:true">
        <div id="clientmap" style="width: 100%; height: 100%">
        </div>
    </div>
    <div data-options="region:'east',iconCls:'icon-reload',title:'拜访顺序',split:true" style="width: 250px;">
        <table id="clientorder" class="easyui-datagrid">
        </table>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
//    var map = new BMap.Map("clientmap");          // 创建地图实例
//    var point = new BMap.Point(116.404, 39.915);  // 创建点坐标
//    map.centerAndZoom(point, 15);                 // 初始化地图，设置中心点坐标和地图级别
//    map.addControl(new BMap.NavigationControl());
//    map.addControl(new BMap.ScaleControl());
//    map.addControl(new BMap.OverviewMapControl());
//    map.addControl(new BMap.MapTypeControl());
//    map.setCurrentCity("北京"); // 仅当设置城市信息时，MapTypeControl的切换功能才能可用

//    var marker = new BMap.Marker(point);        // 创建标注  
//    map.addOverlay(marker);                     // 将标注添加到地图中 

//    var polyline = new BMap.Polyline([
//   new BMap.Point(116.399, 39.910),
//   new BMap.Point(116.405, 39.920)
// ],
// { strokeColor: "blue", strokeWeight: 6, strokeOpacity: 0.5 }
//);
//    map.addOverlay(polyline);

    //    // 编写自定义函数，创建标注  
    //    function addMarker(point, index) {
    //        // 创建图标对象  
    //        var myIcon = new BMap.Icon("markers.png", new BMap.Size(23, 25), {
    //            // 指定定位位置。  
    //            // 当标注显示在地图上时，其所指向的地理位置距离图标左上  
    //            // 角各偏移10像素和25像素。您可以看到在本例中该位置即是  
    //            // 图标中央下端的尖角位置。  
    //            offset: new BMap.Size(10, 25),
    //            // 设置图片偏移。  
    //            // 当您需要从一幅较大的图片中截取某部分作为标注图标时，您  
    //            // 需要指定大图的偏移位置，此做法与css sprites技术类似。  
    //            imageOffset: new BMap.Size(0, 0 - index * 25)   // 设置图片偏移  
    //        });
    //        // 创建标注对象并添加到地图  
    //        var marker = new BMap.Marker(point, { icon: myIcon });
    //        map.addOverlay(marker);
    //    }
    //    // 随机向地图添加10个标注  
    //    var bounds = map.getBounds();
    //    var lngSpan = bounds.maxX - bounds.minX;
    //    var latSpan = bounds.maxY - bounds.minY;
    //    for (var i = 0; i < 10; i++) {
    //        var point = new BMap.Point(bounds.minX + lngSpan * (Math.random() * 0.7 + 0.15),
    //                            bounds.minY + latSpan * (Math.random() * 0.7 + 0.15));
    //        addMarker(point, i);
    //    } 
</script>
