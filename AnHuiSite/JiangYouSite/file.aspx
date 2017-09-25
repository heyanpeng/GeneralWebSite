﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="file.aspx.cs" Inherits="AnHuiSite.file" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%=siteConfig.SiteTitle %></title>
    <!-- 新 Bootstrap 核心 CSS 文件 -->
    <link href="Style/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- jQuery文件。务必在bootstrap.min.js 之前引入 -->
    <script src="Style/js/jquery-2.1.4.min.js"></script>
    <%--<script src="Style/js/jquery-1.9.1.js"></script>--%>
    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="Style/bootstrap/js/bootstrap.min.js"></script>
    <link href="Style/css/menu.css" rel="stylesheet" />
    <script src="Style/js/jquery.1.4.2-min.js"></script>
    <link href="Style/css/default.css" rel="stylesheet" />
    <link href="Style/css/file.css" rel="stylesheet" />
    <!--[if lte IE 8]>
    <style>
    /* CSS for all versions of IE 8 and below */
        .col-md-4{width:366px;float:left}
        .titlelogo{float:left}
        .titletree{float:right}
        .menu{margin-top:-10px;}
        .wordGG{margin-top:-21px;}
        .lbq{margin-top:5px;}
        .sublistGG ul a:hover{color: #209062;}
        .subTitle{font-family:宋体;}
        .logotree{margin-top: 22px;float:right;width:500px;}
    </style>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="width: 1100px;">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-12 titlelogo" style="border: 0px solid red; height: 160px;">
                        <a href="default.aspx" title="<%=siteConfig.SiteTitle %>">
                            <img src="<%=siteConfig.LogoUrl %>" style="margin-left: 0px; margin-top: 50px; float: left; width: 500px;" />
                        </a>
                        <div style="float: right; margin-top: 110px;">
                            <input runat="server" type="text" class="form-control" id="Text2" name="keyword"
                                placeholder="请输入关键字" style="width: 200px; float: left;" />
                            <asp:Button runat="server" ID="Button2" Text="搜索" CssClass="btn btn-info btnSearch" OnClick="btnSearch_Click" Style="float: left; margin-left: 2px;" />
                        </div>
                    </div>
                </div>
            </div>
            <!--菜单Start-->
            <div class="row">
                <div class="col-md-12 col-xs-12" style="border: 0px solid red; height: 38px;">
                    <div class="menu" style="border: 0px solid red">
                        <ul style="border: 0px solid blue; margin-left: 136px;">
                            <asp:Repeater runat="server" ID="rptMenu">
                                <ItemTemplate>
                                    <li <%#Eval("LinkSrc").ToString()!="default.aspx"?"":"style='margin-left: 25px;'" %>>
                                        <a href='<%#Eval("LinkSrc") %>'><%#Eval("MenuName") %></a>
                                        <ul>
                                            <asp:Repeater ID="rptMenuChild" runat="server">
                                                <ItemTemplate>
                                                    <li>
                                                        <a href='<%#Eval("LinkSrc") %>'><%#Eval("MenuName") %></a>
                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                            <li style="display: none;">
                                <input runat="server" type="text" class="form-control" id="Text1" name="keyword"
                                    placeholder="请输入关键字" style="width: 120px; margin-top: 2px; float: left;" />
                                <asp:Button runat="server" ID="Button1" Text="搜索" CssClass="btn btn-info btnSearch" OnClick="btnSearch_Click" Style="margin-top: 2px; float: left; margin-left: 1px;" />
                            </li>
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
            </div>
            <!--菜单End-->

            <div class="row">
                <div class="col-md-12 col-xs-12 nav">
                    <img src="Style/images/list/home.png" />
                    首页 >
                    <asp:Literal runat="server" ID="litTitleNav" />
                </div>
            </div>

            <div class="row content">
                <div class="col-md-3 col-xs-3 contentleft">
                    <table style="box-shadow: 1px 1px 5px 0px #ccc; -moz-border-radius: 5px; -webkit-border-radius: 5px;">
                        <tr>
                            <th colspan="2">
                                <img src="Style/images/newshome.png" />&nbsp;<asp:Literal runat="server" ID="litChildTitle" /></th>
                        </tr>
                        <asp:Repeater runat="server" ID="rptChilds">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 75px; border: none;"></td>
                                    <td>
                                        <a href='<%#GetMenuLinkSrc(Eval("Id").ToString(),Eval("TypeId").ToString()) %>'><%#Eval("MenuName") %></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr style="height: 100px;">
                            <td style="border: none;"></td>
                            <td style="border: none;"></td>
                        </tr>
                    </table>
                </div>
                <div class="col-md-9 col-xs-9 contentright">
                    <div class="listtitle">
                        <asp:Literal runat="server" ID="litTitle" />
                        <a href="#" style="display: none;"><b>MORE>>&nbsp;&nbsp;</b></a>
                    </div>
                    <div>
                        <ul>
                            <asp:Repeater runat="server" ID="rptFilesList">
                                <ItemTemplate>
                                    <li><span>▪&nbsp;</span><a href="<%#Eval("FileAddress") %>" target="_blank"><%#Eval("FileName") %>
                                    </a><span class="newsdatetime"><%#Eval("CreateTime") %></span></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="row">
                <!--友情链接-->
                <div class="col-md-12 col-xs-12" style="border: 0px solid red; height: 70px; text-align: center">
                    <div style="height: 3px; background: #1978bc;">
                    </div>
                    <div class="friendLink">
                        <asp:Repeater runat="server" ID="rptFriendLink">
                            <ItemTemplate>
                                <a href='<%#Eval("UrlAddress") %>'>
                                    <img src='ahadmin/<%#Eval("PicAddress") %>' /></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <div class="row">
                <%=siteConfig.Copyright %>
            </div>
        </div>
    </form>
</body>
</html>


