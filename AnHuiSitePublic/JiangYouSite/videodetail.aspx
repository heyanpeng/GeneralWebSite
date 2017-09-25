<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="videodetail.aspx.cs" Inherits="AnHuiSite.videodetail" %>

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
    <link href="Style/css/content.css" rel="stylesheet" />
    <script src="Style/js/swfobject.js"></script>
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
    <script type="text/javascript">
        $(function () {
            if ('<%=mediaType%>' == '.wmv') {
                $("#CuPlayer").css('display', 'none');
                $("#mplayer").css('display', 'block');
            } else {
                $("#mplayer").css('display', 'none');
                $("#CuPlayer").css('display', 'block');
            }
        });
    </script>
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
                            <input runat="server" type="text" class="form-control" id="Text1" name="keyword"
                                placeholder="请输入关键字" style="width: 200px; float: left;" />
                            <asp:Button runat="server" ID="Button1" Text="搜索" CssClass="btn btn-info btnSearch" OnClick="btnSearch_Click" Style="float: left; margin-left: 2px;" />
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
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12 content">
                    <div class="newstitle">
                        <asp:Literal runat="server" ID="litTitle" Text="" />
                    </div>
                    <div class="newssubtitle">
                        发布日期：<asp:Literal runat="server" ID="litCreateDate" Text="" />&nbsp;&nbsp;
                        来源：<asp:Literal runat="server" ID="litComeFrome" Text="" />
                        阅读：<asp:Literal runat="server" ID="litScanAmount" Text="" />
                        次 <a href="javascript:window.opener=null;window.open('','_self');window.close();">【关闭】</a>
                    </div>
                    <div class="newscontent">
                        <div class="video" id="CuPlayer" style="display: none;"></div>
                        <script type="text/javascript">
                            var so = new SWFObject("../AHAdmin/Uploads/Video/CuPlayerMiniV4.swf", "CuPlayerV4", "820", "500", "9", "#000000");
                            so.addParam("allowfullscreen", "true");
                            so.addParam("allowscriptaccess", "always");
                            so.addParam("wmode", "opaque");
                            so.addParam("quality", "high");
                            so.addParam("salign", "lt");
                            so.addVariable("CuPlayerSetFile", "../AHAdmin/Uploads/Video/CuPlayerSetFileDetail.xml"); //播放器配置文件地址,例SetFile.xml、SetFile.asp、SetFile.php、SetFile.aspx
                            so.addVariable("CuPlayerFile", "http://<%=multiMediaSrc%>"); //视频文件地址
                            so.addVariable("CuPlayerImage", '../AHAdmin/<%=multiMediaPicAddress%>');//视频略缩图,本图片文件必须正确
                            so.addVariable("CuPlayerWidth", "820"); //视频宽度
                            so.addVariable("CuPlayerHeight", "500"); //视频高度
                            so.addVariable("CuPlayerAutoPlay", "no"); //是否自动播放
                            so.addVariable("CuPlayerLogo", "../AHAdmin/Uploads/Video/images/Logo1.png"); //Logo文件地址
                            //so.addVariable("CuPlayerPosition", "bottom-right"); //Logo显示的位置
                            so.write("CuPlayer");
                        </script>
                        <div id="mplayer" style="display: none;">
                            <object height="820" width="500" id="LuckyMediaPlayer" classid="clsid:22d6f312-b0f6-11d0-94ab-0080c74c7e95">
                                <param name="EnableContextMenu" value="0" />
                                <param name="Filename" value="../AHAdmin/Uploads/Video/<%=multiMediaSrc%>" />
                                <param name="showcontrols" value="-1" />
                                <param name="ShowStatusBar" value="-1" />
                                <param name="AutoStart" value="false" />
                                <embed type="application/x-mplayer2" src="../AHAdmin/Uploads/Video/<%=multiMediaSrc%>" width="820" height="500" />
                            </object>
                        </div>
                        <asp:Literal runat="server" ID="litContent" />
                         
                    </div>
                    <div class="newseditor">
                        <span style="float:left;margin-left:100px;">如无法正常观看视频，请下载后观看<a href="http://<%=multiMediaSrc%>" >【下载】</a></span>
                        责任编辑：<asp:Literal runat="server" ID="litUId" />
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
