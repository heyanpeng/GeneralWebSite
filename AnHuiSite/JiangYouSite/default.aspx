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
    <!--轮播器Start-->
    <link href="Style/css/lunboqi.css" rel="stylesheet" />
    <script src="Style/js/lunboqi.js"></script>
    <!--轮播器End-->
    <script src="Style/js/jquery.1.4.2-min.js"></script>
    <link href="Style/css/tab.css" rel="stylesheet" />
    <link href="Style/css/tabPic.css" rel="stylesheet" />
    <script src="Style/js/jquery.tabso_yeso.js"></script>
    <script src="Style/js/tab.js"></script>
    <link href="Style/css/default.css" rel="stylesheet" />
    <link href="Style/css/tabPic.css" rel="stylesheet" />
    <link href="Style/pciroll/css/pciroll.css" rel="stylesheet" />
    <script src="Style/js/swfobject.js"></script>
    <script src="js/jquery.imgscroll.min.js"></script>
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
            imgScroll.rolling({
                name: 'g1',
                width: '200px',
                height: '150px',
                direction: 'left',
                speed: 20,
                addcss: true
            });
        });
    </script>
    <style>
        .g1 {
            margin-top: 10px;
        }

            .g1 ul {
                list-style: none;
            }

                .g1 ul li img {
                    width: 195px;
                    height: 150px;
                    margin-right: 5px;
                }
    </style>
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
                        <div style="float: right; margin-top: 110px;">
                            <input runat="server" type="text" class="form-control" id="Text1" name="keyword"
                                placeholder="请输入关键字" style="width: 200px; float: left;" />
                            <asp:Button runat="server" ID="Button1" Text="搜索" CssClass="btn btn-info btnSearch" OnClick="btnSearch_Click" Style="float: left; margin-left: 2px;" />
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
            <div class="row">
                <!--横幅-->
                <asp:Repeater runat="server" ID="rptBanner">
                    <ItemTemplate>
                        <a href='<%#Eval("UrlAddress") %>' title="<%#Eval("LinkText") %>" target="_blank">
                            <img src='../ahadmin/<%#Eval("PicAddress") %>' style="margin-bottom: 5px; width: 1100px; height: 140px;" /></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row">
                <!--轮播器-->
                <div class="col-md-12 col-xs-12 lbq" style="border: 0px solid red; height: 400px;">
                    <div id="showcase" class="cloud row-content showcase" style="border: 0px solid green;">
                        <div class="lbcontainer">
                            <div class="slide" style="display: block;">
                                <div class="content-main-visual">
                                    <asp:Repeater runat="server" ID="rptTPXWPic">
                                        <ItemTemplate>
                                            <a class="pc" href='content.aspx?id=<%#Eval("Id")%>' target="_blank" title="<%#Eval("Title")%>">
                                                <img src='../ahadmin/<%#Eval("PicAddress") %>' /></a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <div class="content-main-feature">
                                    <div id="myTabContent" class="tab-content">
                                        <div class="tab-pane fade in active" id="zuixinyaowen">
                                            <asp:Repeater runat="server" ID="rptTPXWWord">
                                                <ItemTemplate>
                                                    <div class="feature green">
                                                        <a href='content.aspx?id=<%#Eval("Id")%>' class="current" title="<%#Eval("Title")%>" target="_blank">
                                                            <span>
                                                                <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),40) %>
                                                                <label style="float:right;font-weight:normal;font-size:12px;">
                                                                <%# DateTime.Parse(Eval("CreateTime").ToString()).ToString("MM/dd") %>
                                                                    </label>
                                                            </span>
                                                            <div class="timerLine dark-green"></div>
                                                            <!-- 进度条 -->
                                                        </a>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-xs-4">
                    <div class="row">
                        <div class="col-md-12" style="border: 0px solid green; height: 265px;">
                            <ul class="tabbtn" id="normaltab_left1">
                                <li class="current" style='margin-left: -40px;'><a href='list.aspx?Id=e6c7a4c66bfc4912863d0ffefe613afa'>政策法规</a></li>
                                <li class="current"><a href="list.aspx?Id=4aed673013ef4d2391816baa80469345">领导讲话</a></li>
                                <li class="current"><a href="videolist.aspx?Id=252f2f248f1e4d4384f648b62de2dc55">视频新闻</a></li>
                            </ul>
                            <div class="tabcon" id="normalcon_left1">
                                <div class="sublist">
                                    <div id="roll" style="overflow: hidden; width: 330px; height: 220px; border: 0px solid red;">
                                        <div id="roll1" style="overflow: hidden">
                                            <ul>
                                                <asp:Repeater runat="server" ID="rptZCFG">
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
                                    <script>
                                        if ($("#roll2 ul li").length == 8) {
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
                                                clearInterval(MyMar)
                                            }
                                            roll.onmouseout = function () {
                                                MyMar = setInterval(Marquee, speed)
                                            }
                                        }
                                    </script>
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
                                <li class="current" style='margin-left: -40px;'><a href='list.aspx?Id=a153f60de0ce4a5b84beb3721e48e75f'>工作动态</a></li>
                                <li class="current"><a href='list.aspx?Id=b4f00cfdaead496e901127398d9a0799'>通知公告</a></li>
                                <%--<li class="current"><a href='list.aspx?Id=b051d046e89143fa9c263aa99ce9bce3'>林业科技</a></li>--%>
                                <li class="current"><a href='images.aspx?Id=0bf376ce084047c784bc6d05a9c795e9'>林业图片</a></li>
                            </ul>
                            <div class="tabcon" id="normalcon_center1">
                                <div class="sublist">
                                    <ul>
                                        <asp:Repeater runat="server" ID="rptGZDT">
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
                                <%--<div class="sublist">
                                    <ul>
                                        <asp:Repeater runat="server" ID="rptLYKJ">
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
                                </div>--%>
                                <div class="sublist">
                                    <ul>
                                        <asp:Repeater runat="server" ID="rptLYCP">
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
                                <li class="current" style="margin-left: -40px;"><a href="#">政务公开</a></li>
                                <li><a href="#">专题专栏</a></li>
                                <li><a href="#">网上互动</a></li>
                                <li><a href="#">办事服务</a></li>
                            </ul>
                            <div id="normalcon_right2">
                                <div>
                                    <table class="sudokuZWGK">
                                        <tr>
                                            <td>
                                                <a href="<%=menuZDWJ.LinkSrc %>" target="_blank" title="<%=menuZDWJ.MenuName %>">
                                                    <img src="<%=menuZDWJ.PicAddress %>" /><br />
                                                    <%=menuZDWJ.MenuName %></a>
                                            </td>
                                            <td>
                                                <a href="<%=menuGKZN.LinkSrc %>" target="_blank" title="<%=menuGKZN.MenuName %>">
                                                    <img src="<%=menuGKZN.PicAddress %>" /><br />
                                                    <%=menuGKZN.MenuName %></a>
                                            </td>
                                            <td>
                                                <a href="<%=menuGKML.LinkSrc %>" target="_blank" title="<%=menuGKML.MenuName %>">
                                                    <img src="<%=menuGKML.PicAddress %>" /><br />
                                                    <%=menuGKML.MenuName %></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="<%=menuYSQGK.LinkSrc %>" target="_blank" title="<%=menuYSQGK.MenuName %>">
                                                    <img src="<%=menuYSQGK.PicAddress %>" /><br />
                                                    <%=menuYSQGK.MenuName %></a>
                                            </td>
                                            <td>
                                                <a href="<%=menuNDBG.LinkSrc %>" target="_blank" title="<%=menuNDBG.MenuName %>">
                                                    <img src="<%=menuNDBG.PicAddress %>" /><br />
                                                    <%=menuNDBG.MenuName %></a>
                                            </td>
                                            <td style="display: none;">
                                                <a href="<%=menuSSBF.LinkSrc %>" target="_blank" title="<%=menuSSBF.MenuName %>">
                                                    <img src="<%=menuSSBF.PicAddress %>" /><br />
                                                    <%=menuSSBF.MenuName %></a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="sublist">
                                    <table class="sudokuZTBD">
                                        <tr>
                                            <td>
                                                <a href="<%=ztzlDt.Rows[0]["UrlAddress"] %>" target="_blank" <%=ztzlDt.Rows[0]["Id"].ToString()==""?"style='display:none;'":"" %> title="<%=ztzlDt.Rows[0]["LinkText"] %>">
                                                    <img src='../ahadmin/<%=ztzlDt.Rows[0]["PicAddress"] %>' />
                                                </a>
                                            </td>
                                            <td>
                                                <a href="<%=ztzlDt.Rows[1]["UrlAddress"] %>" target="_blank" <%=ztzlDt.Rows[1]["Id"].ToString()==""?"style='display:none;'":"" %> title="<%=ztzlDt.Rows[1]["LinkText"] %>">
                                                    <img src='../ahadmin/<%=ztzlDt.Rows[1]["PicAddress"] %>' />
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="<%=ztzlDt.Rows[2]["UrlAddress"] %>" target="_blank" <%=ztzlDt.Rows[2]["Id"].ToString()==""?"style='display:none;'":"" %> title="<%=ztzlDt.Rows[2]["LinkText"] %>">
                                                    <img src='../ahadmin/<%=ztzlDt.Rows[2]["PicAddress"] %>' />
                                                </a>
                                            </td>
                                            <td>
                                                <a href="<%=ztzlDt.Rows[3]["UrlAddress"] %>" target="_blank" <%=ztzlDt.Rows[3]["Id"].ToString()==""?"style='display:none;'":"" %> title="<%=ztzlDt.Rows[3]["LinkText"] %>">
                                                    <img src='../ahadmin/<%=ztzlDt.Rows[3]["PicAddress"] %>' />
                                                </a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="sublist">
                                    <table class="sudokuWSHD">
                                        <tr>
                                            <td>
                                                <a href="<%=menuJZXX.LinkSrc %>" target="_blank" title="<%=menuJZXX.MenuName %>">
                                                    <img src="<%=menuJZXX.PicAddress %>" /></a>
                                            </td>
                                        </tr>
                                        <tr style="display: none;">
                                            <td>
                                                <a href="<%=menuDCZJ.LinkSrc %>" target="_blank" title="<%=menuDCZJ.MenuName %>">
                                                    <img src="<%=menuDCZJ.PicAddress %>" /></a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href="<%=menuZWZX.LinkSrc %>" target="_blank" title="<%=menuZWZX.MenuName %>">
                                                    <img src="<%=menuZWZX.PicAddress %>" /></a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="sublist">
                                    <table class="sudokuZTBD">
                                        <tr>
                                            <td>
                                                <a href="<%=menuBSZN.LinkSrc %>" target="_blank" title="<%=menuBSZN.MenuName %>">
                                                    <img src="<%=menuBSZN.PicAddress %>" />
                                                </a>
                                            </td>
                                            <td>
                                                <a href="<%=menuWSBS.LinkSrc %>" target="_blank" title="<%=menuWSBS.MenuName %>">
                                                    <img src="<%=menuWSBS.PicAddress %>" />
                                                </a>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td>
                                                <a href="list.aspx?Id=91" title="">
                                                    <img src="Style/images/ztbd/3.png" />
                                                </a>
                                            </td>
                                            <td>
                                                <a href="list.aspx?Id=92" title="">
                                                    <img src="Style/images/ztbd/4.png" />
                                                </a>
                                            </td>
                                        </tr>--%>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" style="border: 0px solid red; height: 180px;">
                    <ul class="tabbtnpic" id="normaltab_left3">
                        <li class="current" style='margin-left: -40px;'><a href='list.aspx?Id=3c99ffda63844fc5b982b530ff9e7295'>林业图片</a></li>
                    </ul>
                    <div class="tabconpic" id="normalcon_left3">
                        <div class="g1">
                            <ul>
                                <asp:Repeater runat="server" ID="rptYHSW">
                                    <ItemTemplate>
                                        <li>
                                            <a href="content.aspx?Id=<%# Eval("Id") %>" target="_self">
                                                <img src="../ahadmin/<%# Eval("PicAddress") %>" />
                                            </a>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                        <script src="Style/pciroll/js/picroll.js"></script>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <!--友情链接-->
                <div class="col-md-12 col-xs-12" style="border: 0px solid red; height: 100px; text-align: center">
                    <div style="height: 3px; background: #34972b;">
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
                        <asp:DropDownList runat="server" ID="rptFriendLinkDDL1" CssClass="friendLinkddl" Width="200">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="rptFriendLinkDDL2" CssClass="friendLinkddl" Width="200">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="rptFriendLinkDDL3" CssClass="friendLinkddl" Width="200">
                        </asp:DropDownList>
                        <asp:DropDownList runat="server" ID="rptFriendLinkDDL4" CssClass="friendLinkddl" Width="200">
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
<script type="text/javascript">
    $("#<%=rptFriendLinkDDL1.ClientID%>").change(function () {
        if (!$(this)[0].selectedIndex == 0) {
            location.href = $(this)[0].value;
        }
    });
    $("#<%=rptFriendLinkDDL2.ClientID%>").change(function () {
        if (!$(this)[0].selectedIndex == 0) {
            location.href = $(this)[0].value;
        }
    });
    $("#<%=rptFriendLinkDDL3.ClientID%>").change(function () {
        if (!$(this)[0].selectedIndex == 0) {
            location.href = $(this)[0].value;
        }
    });
    $("#<%=rptFriendLinkDDL4.ClientID%>").change(function () {
        if (!$(this)[0].selectedIndex == 0) {
            location.href = $(this)[0].value;
        }
    });
</script>
</html>
