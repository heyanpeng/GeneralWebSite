<%@ Page Title="" Language="C#" MasterPageFile="jysite.Master" AutoEventWireup="true" CodeBehind="content.aspx.cs" Inherits="AnHuiSite.content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content .newspic{
            margin-bottom:10px;
        }
        .content .newspic img {
            margin: 0px auto;
            display: block;
            /*width: 800px;*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newstitle">
        <asp:Literal runat="server" ID="litTitle" />
    </div>
    <div class="newssubtitle">
        发布日期：<asp:Literal runat="server" ID="litCreateDate" />&nbsp;&nbsp;
                        来源：<asp:Literal runat="server" ID="litComeFrome" />
        阅读：<asp:Literal runat="server" ID="litScanAmount" />
        次 <a href="javascript:window.opener=null;window.open('','_self');window.close();">【关闭】</a>
    </div>
    <div class="newscontent">
        <div class="newspic">
            <asp:Image runat="server" ID="img" />
        </div>
        <asp:Literal runat="server" ID="litContent" />
    </div>
    <div class="newseditor">
        责任编辑：<asp:Literal runat="server" ID="litUId" />
    </div>
    <div class="newsfiles" style="display: none;">
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
