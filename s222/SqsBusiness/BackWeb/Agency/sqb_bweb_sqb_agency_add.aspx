<%@ Page Title="" Language="C#" MasterPageFile="~/BackWeb/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="sqb_bweb_sqb_agency_add.aspx.cs" Inherits="SqsBusiness.BackWeb.Agency.sqb_bweb_sqb_agency_add" %>

<%--内容页面头内容--%>
<asp:Content ID="Content_head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--内容页面主体内容--%>
<asp:Content ID="Content_page" ContentPlaceHolderID="ContentPlaceHolder_MasterPage"
    runat="server">
    <div id="cc" class="easyui-layout" style="width: 600px; height: 400px;">
        <div data-options="region:'north',title:'North Title',split:true" style="height: 100px;">
        </div>
        <div data-options="region:'south',title:'South Title',split:true" style="height: 100px;">
        </div>
        <div data-options="region:'east',iconCls:'icon-reload',title:'East',split:true" style="width: 100px;">
        </div>
        <div data-options="region:'west',title:'West',split:true" style="width: 100px;">
        </div>
        <div data-options="region:'center',title:'center title'" style="padding: 5px; background: #eee;">
        </div>
    </div>
</asp:Content>
