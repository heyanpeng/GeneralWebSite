<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="videolist.aspx.cs" Inherits="AnHuiSite.videolist" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
    <link href="Style/css/videolist.css" rel="stylesheet" />
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
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12 content">
                    <ul>
                        <asp:Repeater runat="server" ID="rptNewsList">
                            <ItemTemplate>
                                <li>
                                    <span class="vStartPic">
                                        <a href="videodetail.aspx?Id=<%#Eval("Id") %>" target="_blank" title="<%#Eval("Title") %>">
                                            <img src='../AHAdmin/<%#Eval("PicAddress") %>' title="<%#Eval("Title") %>" />
                                        </a>
                                    </span>
                                    <span>
                                        <span class="vTitle">
                                            <a href="videodetail.aspx?Id=<%#Eval("Id") %>" target="_blank" title="<%#Eval("Title") %>"><%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),40) %></a></span>
                                        <span class="vContent"><%#AnHuiSite.Common.SubStr(AnHuiSite.Common.RemoveHTML(HttpUtility.HtmlDecode(Eval("Content").ToString())),185) %></span>
                                        <span class="vInfo"><%#Eval("CreateTime") %> 播放:<%#Eval("ScanAmount") %> 来源：<%#Eval("Source") %>
                                        </span>
                                    </span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="newspage" style="float: right;">
                        <asp:TextBox runat="server" ID="newsid" Visible="false" Text="0" />
                        <asp:Label runat="server" ID="lblId" Visible="false" Text="1" />
                        <asp:Label runat="server" ID="lblParent" Visible="false" Text="1" />
                        <asp:Label runat="server" ID="lblWh" Visible="false" Text="1" />
                        <asp:Label runat="server" ID="lblOrderBy" Visible="false" Text="1" />
                        <webdiyer:AspNetPager ID="anp" runat="server"
                            PageSize="5" OnPageChanged="anp_PageChanged" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                            ShowPageIndexBox="Never" FirstPageText="首页" LastPageText="尾页" PrevPageText="上一页" NextPageText="下一页">
                        </webdiyer:AspNetPager>
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
                                    <img src='../ahadmin/<%#Eval("PicAddress") %>' /></a>
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
