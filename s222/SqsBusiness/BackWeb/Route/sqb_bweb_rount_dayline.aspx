<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_rount_dayline.aspx.cs" Inherits="SqsBusiness.BackWeb.Route.sqb_bweb_rount_dayline" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
   
 
<head runat="server">
 <script type="text/javascript" src="../Js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
        <script type="text/javascript" src= "../Js/backweb/Route/sqb_bweb_rount_dayline.js"></script>
   
   <link rel="stylesheet" type="text/css" href="../Css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="../Css/jquery.easyui/themes/default/easyui.css" />

    <title>线路管理</title>

</head>
<body id="main" class="easyui-layout" style="border: 5px solid rgb(255,255,255);
    margin: 0px; padding: 0px;" scroll="auto">
    <form id="CourseManage" runat="server" >

 
              <div id="luxianplan" title="路线安排" data-options="region:'west',split:false,iconCls:'icon-layout'" style="width: 250px;overflow: hidden;" align="center">
	        <table><tr><td>组织架构:</td>
            <td>
               <select id="zuzhijg" class="easyui-combotree" name="language" data-options="url:'sqb_bweb_rount_dayline_tree.ashx',cascadeCheck:true,multiple:true" style="width:150px;"></select>
            </td>
            </tr>
            <tr><td>业务代表人:</td>
            <td>
                   <select id="linkman" class="easyui-combobox" name="dept" style="width:150px;"></select>
            </td>
            </tr></table>
                <div id="link_calendar" class="easyui-calendar" style="width:240px" ></div>

	</div>
   <div id="luxiandata" title="线路浏览" data-options="region:'center',iconCls:'icon-user_red'" style="overflow: hidden;">

		<table id="luxiantable"  border="0" class="easyui-datagrid" fit=true fitColumns=true rownumbers="true" toolbar="#tb">

	</table>
	<div id="tb">
		
		<a id="save" class="easyui-linkbutton" iconCls="icon-save" plain="true" >保存</a>
        <a id="dcexcel" class="easyui-linkbutton" iconCls="icon-save" plain="true" >导出Excel</a>
	</div>
	</div>
  
    </form>
</body>
</html>



 