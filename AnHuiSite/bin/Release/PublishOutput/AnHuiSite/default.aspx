<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="AnHuiSite._default" %>

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
    <script src="Style/js/jquery-1.9.1.js"></script>
    <!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
    <script src="Style/bootstrap/js/bootstrap.min.js"></script>
    <link href="Style/css/menu.css" rel="stylesheet" />
    <script src="Style/js/jquery.1.4.2-min.js"></script>
    <link href="Style/css/tab.css" rel="stylesheet" />
    <link href="Style/css/tabPic.css" rel="stylesheet" />
    <script src="Style/js/jquery.tabso_yeso.js"></script>
    <script src="Style/js/tab.js"></script>
    <link href="Style/css/default.css" rel="stylesheet" />
    <link href="Style/css/tabPic.css" rel="stylesheet" />
    <link href="Style/pciroll/css/pciroll.css" rel="stylesheet" />
    <script src="Style/js/swfobject.js"></script>
    <%--banner--%>
    <link href="Style/css/lrtk.css" rel="stylesheet" />
    <script src="Style/js/lrtk.js"></script>
    <%--banner--%>
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
        .logotree{float:right;width:338px;margin-left:200px;}
        .zuixinyaowen{height:60px;}
    </style>
    <![endif]-->
    <script type="text/javascript">
        $(function () {
            if ('<%=mediaType%>' == '.wmv') {
                $("#mplayer").attr("style", "");
            } else {
                $("#CuPlayer").attr("style", "");
            }
            if ($("#roll1 ul li").length == 8) {
                var speed = 40
                roll2.innerHTML = roll1.innerHTML
                function Marquee() {
                    if (roll2.offsetTop - roll.scrollTop <= 0)
                        roll.scrollTop -= roll1.offsetHeight
                    else {
                        roll.scrollTop++
                    }
                }
                var MyMar = setInterval(Marquee, speed)
                roll.onmouseover = function () {
                    clearInterval(MyMar);
                }
                roll.onmouseout = function () {
                    MyMar = setInterval(Marquee, speed);
                }
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="width: 1100px;">
            <div class="row">
                <!--头部-->
                <div class="col-md-12">
                    <div class="col-md-12 titlelogo" style="border: 0px solid red; height: 160px;">
                        <a href="default.aspx" title="<%=siteConfig.SiteTitle %>">
                            <img src="<%=siteConfig.LogoUrl %>" style="margin-left: 0px; margin-top: 50px; float: left; width: 500px;" />
                        </a>
                        <img src="Style/images/tree.png" class="logotree" />
                        <div style="position:absolute;right:-150px;top:155px;z-index:999;float:right;">
                            <input runat="server" type="text" class="form-control" id="Text1" name="keyword"
                                placeholder="请输入关键字" style="width: 200px; margin-top: 2px; float: left;" />
                            <asp:Button runat="server" ID="Button1" Text="搜索" CssClass="btn btn-info btnSearch" OnClick="btnSearch_Click" Style="margin-top: 2px; float: left; margin-left: 1px;" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <!--菜单-->
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
            <div class="row-banner">
                <div class="left-pic">
                    <div id="box">
                        <div class="prev"></div>
                        <div class="next"></div>
                        <ul class="bigUl">
                            <asp:Repeater runat="server" ID="rptZuiXinYaoWenPic">
                                <ItemTemplate>
                                    <li <%# Container.ItemIndex==0?"style='z-index:1'":""%>>
                                        <a href='content.aspx?id=<%#Eval("Id")%>' target="_blank" title="<%#Eval("Title")%>">
                                            <img src='../ahadmin/<%#Eval("PicAddress") %>' />
                                        </a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <ul class="numberUl">
                            <asp:Repeater runat="server" ID="rptZuiXinYaoWenPicIndex">
                                <ItemTemplate>
                                     <li class="<%#(Container.ItemIndex+1)==1?"night":""%>"><a href="javascript:;"><%#Container.ItemIndex+1%></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div>
                            <ul class="textUl">
                                <asp:Repeater runat="server" ID="rptZuiXinYaoWenPicWord">
                                    <ItemTemplate>
                                        <li <%# Container.ItemIndex==0?"style='display: block;'":""%>>
                                            <a href='content.aspx?id=<%#Eval("Id")%>' style="text-decoration: none;" target="_blank" title="<%#Eval("Title")%>">
                                                <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),40) %>
                                            </a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="right-word">
                    <ul class="tabbtn" id="normaltab_banner1" style="margin-left: 0px; margin-top: 0px;">
                        <li class="current" style='margin-left: -40px;'><a href='list.aspx?Id=4aed673013ef4d2391816baa80469345'>最新要闻</a></li>
                        <li class="current"><a href="list.aspx?Id=4badd77399034ce0b3e283eb572ca985">市县新闻</a></li>
                    </ul>
                    <div class="tabcon" id="normalcon_banner1" style="border-bottom: 0px solid #d5d5d5; margin-left: 0px; height: 369px;">
                        <div class="sublist" style="padding: 0;">
                            <asp:Repeater runat="server" ID="rptZuiXinYaoWenWord">
                                <ItemTemplate>
                                    <div class="banner-word">
                                        <a href='content.aspx?id=<%#Eval("Id")%>' class="current" title="<%#Eval("Title")%>" target="_blank">
                                            <span><%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),20) %></span>
                                            <span style="float:right;margin-right:4px;color:gray;font-size:12px;"><%#AnHuiSite.Common.GetShortDate(Eval("CreateTime").ToString())%></span>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="sublist" style="padding: 0;">
                            <asp:Repeater runat="server" ID="rptShiXianXinWen">
                                <ItemTemplate>
                                    <div class="banner-word">
                                        <a href='content.aspx?id=<%#Eval("Id")%>' class="current" title="<%#Eval("Title")%>" target="_blank">
                                            <span><%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),20) %></span>
                                            <span style="float:right;margin-right:4px;color:gray;font-size:12px;"><%#AnHuiSite.Common.GetShortDate(Eval("CreateTime").ToString())%></span>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-4">
                    <div class="row">
                        <div class="col-md-12" style="border: 0px solid green; height: 265px;">
                            <ul class="tabbtn" id="normaltab_left1">
                                <li class="current" style='margin-left: -40px;'><a href='list.aspx?Id=6bfc4f2f3a3d4404b3cdfcd619ebce07'>通知公告</a></li>
                                <li class="current"><a href="list.aspx?Id=a85221f43911420896d4be66879e3b7a">领导讲话</a></li>
                                <li class="current"><a href="videolist.aspx?Id=b7af52f33c8944f7a55be14182952cfa">视频新闻</a></li>
                            </ul>
                            <div class="tabcon" id="normalcon_left1">
                                <div class="sublist">
                                    <div id="roll" style="overflow: hidden; width: 330px; height: 220px; border: 0px solid red;">
                                        <div id="roll1" style="overflow: hidden">
                                            <ul>
                                                <asp:Repeater runat="server" ID="rptTZGG">
                                                    <ItemTemplate>
                                                        <li>
                                                            <span>▪</span>
                                                            <a href="content.aspx?Id=<%#Eval("Id") %>" title="<%#Eval("Title") %>" target="_blank">
                                                                <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),13,Convert.ToBoolean(Eval("IsNew")),Convert.ToBoolean(Eval("IsHot"))) %>
                                                                <asp:Image runat="server" ImageUrl="Style/images/new.gif" Visible='<%# Convert.ToBoolean(Eval("IsNew")) %>' />
                                                                <asp:Image runat="server" ImageUrl="Style/images/hot.gif" Visible='<%# Convert.ToBoolean(Eval("IsHot")) %>' />
                                                            </a>
                                                            <span class="newsdatetime"><%#GetShortDate(Eval("CreateTime").ToString()) %></span>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                        <div id="roll2">
                                        </div>
                                    </div>
                                </div>
                                <div class="sublist">
                                    <ul>
                                        <asp:Repeater runat="server" ID="rptLDJH">
                                            <ItemTemplate>
                                                <li>
                                                    <span>▪</span>
                                                    <a href="content.aspx?Id=<%#Eval("Id") %>" title="<%#Eval("Title") %>" target="_blank">
                                                        <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),13,Convert.ToBoolean(Eval("IsNew")),Convert.ToBoolean(Eval("IsHot"))) %>
                                                        <asp:Image runat="server" ImageUrl="Style/images/new.gif" Visible='<%# Convert.ToBoolean(Eval("IsNew")) %>' />
                                                        <asp:Image runat="server" ImageUrl="Style/images/hot.gif" Visible='<%# Convert.ToBoolean(Eval("IsHot")) %>' />
                                                    </a>
                                                    <span class="newsdatetime"><%#GetShortDate(Eval("CreateTime").ToString()) %></span>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <div class="sublist">
                                    <div class="video" id="CuPlayer" style="display: none;"></div>
                                    <script type="text/javascript">
                                        var so = new SWFObject("../AHAdmin/Uploads/Video/CuPlayerMiniV4.swf", "CuPlayerV4", "330", "220", "9", "#000000");
                                        so.addParam("allowfullscreen", "true");
                                        so.addParam("allowscriptaccess", "always");
                                        so.addParam("wmode", "opaque");
                                        so.addParam("quality", "high");
                                        so.addParam("salign", "lt");
                                        so.addVariable("CuPlayerSetFile", "../AHAdmin/Uploads/Video/CuPlayerSetFileDetail.xml"); //播放器配置文件地址,例SetFile.xml、SetFile.asp、SetFile.php、SetFile.aspx
                                        so.addVariable("CuPlayerFile", "http://<%=multiMediaSrc%>"); //视频文件地址
                                        so.addVariable("CuPlayerImage", '../AHAdmin/<%=multiMediaPicAddress%>');//视频略缩图,本图片文件必须正确
                                        so.addVariable("CuPlayerWidth", "330"); //视频宽度
                                        so.addVariable("CuPlayerHeight", "220"); //视频高度
                                        so.addVariable("CuPlayerAutoPlay", "no"); //是否自动播放
                                        so.addVariable("CuPlayerLogo", "../AHAdmin/Uploads/Video/images/Logo1.png"); //Logo文件地址
                                        //so.addVariable("CuPlayerPosition", "bottom-right"); //Logo显示的位置
                                        so.write("CuPlayer");
                                    </script>
                                    <div id="mplayer" style="display: none;">
                                        <object height="220" width="330" id="LuckyMediaPlayer" classid="clsid:22d6f312-b0f6-11d0-94ab-0080c74c7e95">
                                            <param name="EnableContextMenu" value="0" />
                                            <param name="Filename" value="../AHAdmin/Uploads/Video/<%=multiMediaSrc%>" />
                                            <param name="showcontrols" value="-1" />
                                            <param name="ShowStatusBar" value="-1" />
                                            <param name="AutoStart" value="false" />
                                            <embed type="application/x-mplayer2" src="../AHAdmin/Uploads/Video/<%=multiMediaSrc%>" width="820" height="500" />
                                        </object>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-xs-4">
                    <div class="row">
                        <div class="col-md-12" style="border: 0px solid green; height: 265px;">
                            <ul class="tabbtn" id="normaltab_center1">
                                <li class="current" style='margin-left: -40px;'><a href='list.aspx?Id=4badd77399034ce0b3e283eb572ca985'>市县新闻</a></li>
                                <li class="current"><a href='list.aspx?Id=1d3fde6772614bb7883a347a551defcc'>兄弟省市</a></li>
                                <li class="current"><a href='list.aspx?Id=a5c7462fbcff45599193c849910c7faf'>林业动态</a></li>
                            </ul>
                            <div class="tabcon" id="normalcon_center1">
                                <div class="sublist SHIXIANXINWEN">
                                    <ul>
                                        <li>
                                            <table class="cityMap" style="background-image: url(Style/images/anhui.jpg);">
                                                <tr>
                                                    <td><a href="list.aspx?Id=5a6aa18b547a4e40a8c603797b23ccbc">合肥</a></td>
                                                    <td><a href="list.aspx?Id=f4ad5ed6f97047089bd8c08a0dc3c968">淮北</a></td>
                                                    <td><a href="list.aspx?Id=4434979ec8fb40dca7e16b35776ea678">亳州</a></td>
                                                    <td><a href="list.aspx?Id=73fa70be32b54a5d836fb8f65d1ff7e5">宿州</a></td>
                                                </tr>
                                                <tr>
                                                    <td><a href="list.aspx?Id=dfb4e0b8d112418e9058850fdf109e15">蚌埠</a></td>
                                                    <td><a href="list.aspx?Id=d32931b24390444584198ee487cc3b88">阜阳</a></td>
                                                    <td><a href="list.aspx?Id=89c82b286fa34e7d9538a414b1376c9e">淮南</a></td>
                                                    <td><a href="list.aspx?Id=2f3f32e54d2e4992b7db6bc64ffd0ef1">滁州</a></td>
                                                </tr>
                                                <tr>
                                                    <td><a href="list.aspx?Id=623bb54a3a27499997302e67d7e79d96">六安</a></td>
                                                    <td><a href="list.aspx?Id=c0f84339705e4b2ea26b6820e113af66">马鞍山</a></td>
                                                    <td><a href="list.aspx?Id=342444d796e44f1dba6f5a781223dfad">芜湖</a></td>
                                                    <td><a href="list.aspx?Id=d4250e771d6e4fb8a0c4f423babaf11b">宣城</a></td>
                                                </tr>
                                                <tr>
                                                    <td><a href="list.aspx?Id=18ab55743ec34d80adb40ab1cde1cb8f">铜陵</a></td>
                                                    <td><a href="list.aspx?Id=13d28e8bc04f4e9a8937c36d76fee55a">池州</a></td>
                                                    <td><a href="list.aspx?Id=dc678329d3b9462bb9847b4865181636">安庆</a></td>
                                                    <td><a href="list.aspx?Id=b6dbc0f2a6134f66b1c7ebfb0049d589">黄山</a></td>
                                                </tr>
                                            </table>
                                        </li>
                                    </ul>
                                </div>
                                <div class="sublist">
                                    <ul>
                                        <asp:Repeater runat="server" ID="rptXDSS">
                                            <ItemTemplate>
                                                <li>
                                                    <span>▪</span>
                                                    <a href="content.aspx?Id=<%#Eval("Id") %>" title="<%#Eval("Title") %>" target="_blank">
                                                        <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),13,Convert.ToBoolean(Eval("IsNew")),Convert.ToBoolean(Eval("IsHot"))) %>
                                                        <asp:Image runat="server" ImageUrl="Style/images/new.gif" Visible='<%# Convert.ToBoolean(Eval("IsNew")) %>' />
                                                        <asp:Image runat="server" ImageUrl="Style/images/hot.gif" Visible='<%# Convert.ToBoolean(Eval("IsHot")) %>' />
                                                    </a>
                                                    <span class="newsdatetime"><%#GetShortDate(Eval("CreateTime").ToString()) %></span>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <div class="sublist">
                                    <ul>
                                        <asp:Repeater runat="server" ID="rptLYDT">
                                            <ItemTemplate>
                                                <li>
                                                    <span>▪</span>
                                                    <a href="content.aspx?Id=<%#Eval("Id") %>" title="<%#Eval("Title") %>" target="_blank">
                                                        <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),13,Convert.ToBoolean(Eval("IsNew")),Convert.ToBoolean(Eval("IsHot"))) %>
                                                        <asp:Image runat="server" ImageUrl="Style/images/new.gif" Visible='<%# Convert.ToBoolean(Eval("IsNew")) %>' />
                                                        <asp:Image runat="server" ImageUrl="Style/images/hot.gif" Visible='<%# Convert.ToBoolean(Eval("IsHot")) %>' />
                                                    </a>
                                                    <span class="newsdatetime"><%#GetShortDate(Eval("CreateTime").ToString()) %></span>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 col-xs-4">
                    <div class="row">
                        <div class="col-md-12" style="border: 0px solid green; height: 265px;">
                            <ul class="tabbtn" id="normaltab_right2">
                                <li class="current" style="margin-left: -40px;"><a href="#">快速入口</a></li>
                                <li><a href="list.aspx?Id=147823f5f2f04fe291d9ab377e0e8152">专栏信息</a></li>
                                <li><a href="message.aspx?Id=ca3be86c0adf4891934d1d1ebbcb8c5a">网上互动</a></li>
                                <li><a href="file.aspx?Id=6322447e140a4df499f06b5f0bcfa62c">文件下载</a></li>
                            </ul>
                            <div id="normalcon_right2">
                                <div>
                                    <table class="sudokuZWGK">
                                        <tr>
                                            <td>
                                                <a href="VideoConference.html" target="_blank" title="视频会议">
                                                    <img src="Style/images/sudoku/视频会议.png" /><br />
                                                    视频会议</a>
                                            </td>
                                            <td>
                                                <a href="../ahadmin/login.aspx" target="_blank" title="市县入口">
                                                    <img src="Style/images/sudoku/市县入口.png" /><br />
                                                    市县入口</a>
                                            </td>
                                            <td>
                                                <a href="http://www.ssfzz.cn:81/ah" target="_blank" title="管理系统">
                                                    <img src="Style/images/sudoku/管理系统.png" /><br />
                                                    管理系统</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="static.aspx?Id=31de6e79562f4bda9197a2c0d8f75a27" title="联系方式">
                                                    <img src="Style/images/sudoku/联系方式.png" /><br />
                                                    联系方式</a>
                                            </td>
                                            <td>
                                                <a href="list.aspx?Id=4aa59dd05ba0499eb302b24939892277" title="公众意见箱">
                                                    <img src="Style/images/sudoku/公众意见箱.png" /><br />
                                                    公众意见箱</a>
                                            </td>
                                            <td>
                                                <a href="http://www.ssfzz.cn:4010/" target="_blank" title="旧网站入口">
                                                    <img src="Style/images/sudoku/管理系统.png" /><br />
                                                    旧网站入口</a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="sublist">
                                    <table class="sudokuZTBD">
                                        <tr>
                                            <td>
                                                <a href="list.aspx?Id=b051d046e89143fa9c263aa99ce9bce3" title="">
                                                    <img src="Style/images/ztbd/2.png" />
                                                </a>
                                            </td>
                                            <td>
                                                <a href="list.aspx?Id=691363efdc014d6caed0f89c5996bb28" title="">
                                                    <img src="Style/images/ztbd/1.png" />
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="list.aspx?Id=de5cfec7bc9341c6a161edebf67c9194" title="">
                                                    <img src="Style/images/ztbd/3.png" />
                                                </a>
                                            </td>
                                            <td>
                                                <a href="list.aspx?Id=6a6bd985c00a40399e290ff00201a0e9" title="">
                                                    <img src="Style/images/ztbd/4.png" />
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="sublist">
                                    <table class="sudokuWSHD">
                                        <tr>
                                            <td>
                                                <a href="message.aspx?Id=d07a7c74374d4cd0ba927cc84913e05f" title="">
                                                    <img src="Style/images/wshd/1.png" />
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="message.aspx?Id=45e261b20eb14c35b0e8350491bbb68b" title="">
                                                    <img src="Style/images/wshd/2.png" />
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="message.aspx?Id=56a3d6f9c9b24455984e62e4a38c0634" title="">
                                                    <img src="Style/images/wshd/3.png" />
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="sublist">
                                    <ul>
                                        <asp:Repeater runat="server" ID="rptWJXZ">
                                            <ItemTemplate>
                                                <li><span>▪</span>
                                                    <a href="../AHAdmin/<%#Eval("FileAddress") %>" title="<%#Eval("FileName") %>"
                                                        target="_blank">
                                                        <%#AnHuiSite.Common.SubStr(Eval("FileName").ToString(),20) %>
                                                    </a><span class="newsdatetime"><%#GetShortDate(Eval("CreateTime").ToString()) %></span></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" style="border: 0px solid red; height: 180px;">
                    <ul class="tabbtnpic" id="normaltab_left3">
                        <li class="current" style='margin-left: -40px;'><a href='list.aspx?Id=3c99ffda63844fc5b982b530ff9e7295'>有害生物</a></li>
                    </ul>
                    <div class="tabconpic" id="normalcon_left3">
                        <div class="sublistpic">
                            <div id="picroll">
                                <ul>
                                    <asp:Repeater runat="server" ID="rptYHSW">
                                        <ItemTemplate>
                                            <li>
                                                <a href="content.aspx?Id=<%#Eval("Id") %>" title="<%#Eval("Title") %>" target="_blank">
                                                    <img src="../ahadmin/<%# Eval("PicAddress") %>" />
                                                </a>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                        </div>
                        <script src="Style/pciroll/js/picroll.js"></script>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <!--友情链接-->
                <div class="col-md-12 col-xs-12" style="border: 0px solid red; height: 100px; text-align: center">
                    <div style="height: 3px; background: #1978bc;">
                    </div>
                    <div class="friendLink">
                        <asp:Repeater runat="server" ID="rptFriendLink">
                            <ItemTemplate>
                                <a href='<%#Eval("UrlAddress") %>' title="<%#Eval("LinkText") %>" target="_blank">
                                    <img src='../ahadmin/<%#Eval("PicAddress") %>' /></a>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="friendLinkList">
                        <asp:DropDownList runat="server" ID="rptFriendLinkDDL1" CssClass="friendLinkddl" Width="200" AutoPostBack="true" OnSelectedIndexChanged="rptFriendLinkDDL_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="rptFriendLinkDDL2" CssClass="friendLinkddl" Width="200" AutoPostBack="true" OnSelectedIndexChanged="rptFriendLinkDDL_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="rptFriendLinkDDL3" CssClass="friendLinkddl" Width="200" AutoPostBack="true" OnSelectedIndexChanged="rptFriendLinkDDL_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="rptFriendLinkDDL4" CssClass="friendLinkddl" Width="200" AutoPostBack="true" OnSelectedIndexChanged="rptFriendLinkDDL_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <%=siteConfig.Copyright %>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
