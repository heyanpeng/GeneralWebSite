<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="AnHuiSite.Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/content.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title">
        <asp:Literal runat="server" ID="litTitle" />
    </div>
    <div class="subtitle">
        发布日期：<asp:Literal runat="server" ID="litCreateDate" />&nbsp;&nbsp;
                        来源：<asp:Literal runat="server" ID="litComeFrome" />
        阅读：<asp:Literal runat="server" ID="litScanAmount" />
        次 <a href="javascript:window.opener=null;window.open('','_self');window.close();" style="text-decoration: none; color: green;">【关闭】</a>
    </div>
    <div class="content">
        <div class="newspic">
            <asp:Image runat="server" ID="img" />
        </div>
        <asp:Literal runat="server" ID="litContent" />
    </div>
    <div class="editor">
        编辑：<asp:Literal runat="server" ID="litUId" />
    </div>
    <div class="files" style="display: none;">
        附件下载：
        <ul>
            <li>
                <a href="#">国家林业局调查规划设计院就拟建安徽天柱山松材线虫病综合防控建设项目来桐调研</a>
            </li>
            <li>
                <a href="#">国家林业局调查规划设计院就拟建安徽天柱山松材线虫病综合防控建设项目来桐调研</a>
            </li>
            <li>
                <a href="#">国家林业局调查规划设计院就拟建安徽天柱山松材线虫病综合防控建设项目来桐调研</a>
            </li>
        </ul>
    </div>
</asp:Content>
