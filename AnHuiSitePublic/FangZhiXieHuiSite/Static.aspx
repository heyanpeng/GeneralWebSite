<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Static.aspx.cs" Inherits="AnHuiSite.Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listhead">
        <a href="Default.aspx">首页</a> >
        <asp:Literal runat="server" ID="litNav" />
    </div>
    <div style="padding: 20px;">
        <asp:Literal runat="server" ID="litStaticContent" />
    </div>
</asp:Content>
