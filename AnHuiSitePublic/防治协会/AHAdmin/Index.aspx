<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AnHuiSite.AHAdmin.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/Index.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xs-12">
            <div class="alert alert-block alert-success">
                <i class="icon-ok green"></i>
                欢迎使用
                <strong class="green"><asp:Literal runat="server" ID="litSiteName" />
                    <small>(v<asp:Literal runat="server" ID="litVersion" />)</small>
                </strong>
                后台管理系统
            </div>
            <div class="hr hr14 hr-dotted"></div>
            <div class="row">
            </div>
        </div>
    </div>
</asp:Content>
