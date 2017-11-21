<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sqb_bweb_rount_select.aspx.cs"
    Inherits="SqsBusiness.BackWeb.Route.sqb_bweb_rount_select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="../Js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="../Js/jquery.easyui/locale/easyui-lang-zh_CN.js"></script>
    <script type="text/javascript" src= "../Js/backweb/Route/sqb_bweb_rount_select.js"></script>
    <link rel="stylesheet" type="text/css" href="../Css/jquery.easyui/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="../Css/jquery.easyui/themes/default/easyui.css" />
    <title>拜访历史</title>
</head>

<body id="main" class="easyui-layout" style="border: 5px solid rgb(255,255,255);margin: 0px; padding: 0px;" scroll="auto">
    <form id="fm_history" runat="server" fit="true">
    <div data-options="region:'north',title:'查询条件',split:true" style="height:100px;"> 
        <table border="0">
            <tr>
                <td>
                    开始时间
                </td>
                <td>
                    <input id="start_time" class="easyui-datebox" style="width: 130px"/>
                </td>
                <td>
                    结束时间
                </td>
                <td>
                    <input id="end_time" class="easyui-datebox"  style="width: 130px"/>
                </td>
                <td>
                    组织架构
                </td>
                <td>
                    <select id="zuzhijg" class="easyui-combotree" name="language" data-options="url:'sqb_bweb_rount_dayline_tree.ashx',cascadeCheck:true"
                        multiple style="width: 130px;">
                    </select>
                </td>
                <td>
                    业务代表
                </td>
                <td>
                    <select id="linkman" class="easyui-combobox" name="dept" style="width: 130px;">
                    
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    终端名称
                </td>
                <td>
                    <select id="client_name" class="easyui-combobox" style="width: 130px">
                    </select>
                </td>
                <td>
                    拜访类型
                </td>
                <td>
                    <select id="call_mode" class="easyui-combobox" style="width: 130px">
                        <option value=""></option>
                        <option value="dayline">计划内路线</option>
                        <option value="line">计划外路线</option>
                    </select>
                </td>
                <td>
                    拜访模式
                </td>
                <td>
                    <select id="call_type" class="easyui-combobox" style="width: 130px">
                        <option value=""></option>
                        <option value="kehuyc">客户异常</option>
                        <option value="dianhuabf">电话拜访</option>
                        <option value="shangmenbf">上门拜访</option>
                    </select>
                </td>
                <td colspan="2" align="center">
                    <a id="search" class="easyui-linkbutton" iconcls="icon-search" plain="true">查询</a>
                    <a id="dcexcel" class="easyui-linkbutton" iconcls="icon-save" plain="true">导出Excel</a>
                </td>
            </tr>
            </table>
       </div>

      <div id="abcd" data-options="region:'center',split:false" style="height:100px;">
                  <table id="historytable" title="拜访记录" fit=true fitColumns=true  class="easyui-datagrid" rownumbers="true">
		<thead>
			<tr align="center">
                <th  field="id" hidden="true">客户id</th>
                <th align="center" field="client_name" width="110" sortable="true">终端名称</th>
				<th align="center" field="username" width="80" sortable="true">业务代表</th>
				<th align="left" field="job_content" width="200">工作内容</th>
				<th align="center" field="date"   width="110" sortable="true">拜访时间</th>
				<th align="center" field="call_mode" width="80" sortable="true">拜访类型</th>
				<th align="center" field="call_type" sortable="true" width="80" >拜访模式</th>
				
         
			
		</tr>
        </thead>
        </table>
        </div>
        
      
    
          <div id="images" title="图片预览" data-options="region:'east',iconCls:'icon-reload',title:'East',split:true" style="display:none;width:220px;height:100%;">
             <table border="0">
             <tr><td>
              <a id="newa1" target="_blank"><img id ="image1" width="200px" height="110px" alt="暂无图片" /></a>
              </td></tr>
               <tr><td>
                  
                   <a id="label1"></a>
              <tr><td>
               <a id="newa2" target="_blank"><img id ="image2" width="200px" height="110px" alt="暂无图片" /></a>
               </td></tr>
                <tr><td>
                   <a id="label2"></a> </td></tr>
               <tr><td>
                <a id="newa3" target="_blank"><img id ="image3" width="200px" height="110px" alt="暂无图片" /></a>
                </td></tr>
                <tr><td>
                   <a id="label3"></a></td></tr>
                </table>
             </div>

    </form>
</body>
</html>
