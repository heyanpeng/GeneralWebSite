<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AnHuiSite.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/default.css" rel="stylesheet" />
    <link href="css/tab.css" rel="stylesheet" />
    <script src="js/jquery.tabso_yeso.js"></script>
    <script src="js/jquery.SuperSlide.2.1.1.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="banner">
        <div class="bannernewsimg">
            <div id="slideBox" class="slideBox">
                <div class="hd">
                    <ul>
                        <li>1</li>
                        <li>2</li>
                        <li>3</li>
                        <li>4</li>
                        <li>5</li>
                    </ul>
                </div>
                <div class="bd">
                    <ul>
                        <asp:Repeater runat="server" ID="rptNewsBannerImg">
                            <ItemTemplate>
                                <li><a class="pc" href='content.aspx?id=<%#Eval("Id")%>' target="_blank" title="<%#Eval("Title")%>">
                                    <img src='../ahadmin/<%#Eval("PicAddress") %>' /></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <!-- 下面是前/后按钮代码，如果不需要删除即可 -->
                <a class="prev" href="javascript:void(0)"></a><a class="next" href="javascript:void(0)"></a>
            </div>
            <script type="text/javascript">
                jQuery(".slideBox").slide({ mainCell: ".bd ul", autoPlay: true });
            </script>
        </div>
        <div class="bannernews">
            <ul>
                <asp:Repeater runat="server" ID="rptNewsBannerWord">
                    <ItemTemplate>
                        <li>
                            <a href='content.aspx?id=<%#Eval("Id")%>' title="<%#Eval("Title")%>" target="_blank">
                                <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),45) %>
                                <label><%#AnHuiSite.Common.GetShortDate(Eval("CreateTime").ToString()) %></label>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
    <div class="center">
        <div class="about">
            <ul>
                <li class="abouthead">关于协会</li>
                <asp:Repeater runat="server" ID="rptAbout">
                    <ItemTemplate>
                        <li>
                            <a href='<%#Eval("LinkSrc") %>'>
                                <%#Eval("PicAddress") %>
                                <%#Eval("MenuName") %>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <div class="newsdynamic">
            <div class="newshead">
                协会动态
                <span class="more"><a href="List.aspx?Id=a7e585f521e948a09fcf23360fc85775" title="查看更多">More</a></span>
            </div>
            <div class="newslist">
                <ul>
                    <asp:Repeater runat="server" ID="rptNewsDynamic">
                        <ItemTemplate>
                            <%--<li class="newsfirst"><a href="#">四川林业有害生物信息网四川林四川林业有害生物信息网四川林<img src="images/new.gif" /><img src="images/hot.gif" /><span class="newsdate">2015-11-19</span></a></li>--%>
                            <li <%#Container.ItemIndex==0?"class=\"newsfirst\"":""%>><a href='content.aspx?id=<%#Eval("Id")%>' title="<%#Eval("Title") %>" target="_blank">
                                <img src="images/dot.png" />
                                <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),35)%></a>
                                <asp:Image runat="server" ImageUrl="images/new.gif" Visible='<%# Convert.ToBoolean(Eval("IsNew")) %>' />
                                <asp:Image runat="server" ImageUrl="images/hot.gif" Visible='<%# Convert.ToBoolean(Eval("IsHot")) %>' />
                                <span class="newsdate"><%#AnHuiSite.Common.GetLongDate(Eval("CreateTime").ToString()) %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <div class="newspromote">
        <ul class="tabbtn">
            <li class="current"><a href="List.aspx?Id=60a8e26113414f18a1d3aae1b0d65bcd" style="cursor: pointer;">技术推广</a></li>
        </ul>
        <div class="tabcon">
            <div class="picScroll-left">
                <div class="bd">
                    <ul class="picList">
                        <asp:Repeater runat="server" ID="rptNewsPromote">
                            <ItemTemplate>
                                <li>
                                    <div class="pic">
                                        <a class="pc" href='content.aspx?id=<%#Eval("Id")%>' target="_blank" title="<%#Eval("Title")%>">
                                            <img src='../ahadmin/<%#Eval("PicAddress") %>' /></a>
                                    </div>
                                    <div class="title">
                                        <a class="pc" href='content.aspx?id=<%#Eval("Id")%>' target="_blank" title="<%#Eval("Title")%>"><%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),10) %></a>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <a class="prev" href="javascript:void(0)"></a><a class="next" href="javascript:void(0)"></a>
            </div>

            <script type="text/javascript">
                jQuery(".picScroll-left").slide({ titCell: ".hd ul", mainCell: ".bd ul", autoPage: true, effect: "left", autoPlay: true, vis: 6, trigger: "click" });
            </script>
        </div>
    </div>
    <div class="bottom">
        <div class="newscommunicate">
            <div class="newshead">
                热点专题
                <span class="more"><a href="List.aspx?Id=a9b6ac0838a043a28dcdc610226872bc" title="查看更多">More</a></span>
            </div>
            <div class="newslist">
                <ul>
                    <asp:Repeater runat="server" ID="rptNewsCommunicate">
                        <ItemTemplate>
                            <li><a href='content.aspx?id=<%#Eval("Id")%>' title="<%#Eval("Title") %>" target="_blank">
                                <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),21) %></a>
                                <asp:Image runat="server" ImageUrl="images/new.gif" Visible='<%# Convert.ToBoolean(Eval("IsNew")) %>' />
                                <asp:Image runat="server" ImageUrl="images/hot.gif" Visible='<%# Convert.ToBoolean(Eval("IsHot")) %>' />
                                <span class="newsdate"><%#AnHuiSite.Common.GetLongDate(Eval("CreateTime").ToString()) %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="newsindustry">
            <div class="newshead">
                互动交流
                <span class="more"><a href="List.aspx?Id=db6e5b8e707e415e9864403fabf282d2" title="查看更多">More</a></span>
            </div>
            <div class="newslist">
                <ul>
                    <asp:Repeater runat="server" ID="rptNewsIndustry">
                        <ItemTemplate>
                            <li><a href='content.aspx?id=<%#Eval("Id")%>' title="<%#Eval("Title") %>" target="_blank">
                                <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),21) %></a>
                                <asp:Image runat="server" ImageUrl="images/new.gif" Visible='<%# Convert.ToBoolean(Eval("IsNew")) %>' />
                                <asp:Image runat="server" ImageUrl="images/hot.gif" Visible='<%# Convert.ToBoolean(Eval("IsHot")) %>' />
                                <span class="newsdate"><%#AnHuiSite.Common.GetLongDate(Eval("CreateTime").ToString()) %></span></li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <div class="member">
        <ul class="tabbtn">
            <li class="current"><a href="List.aspx?Id=312cecf611964b41a3eb1409b7043064">会员风采</a></li>
        </ul>
        <div class="tabcon">
            <div class="picScroll-left">
                <div class="bd">
                    <ul class="picList">
                        <asp:Repeater runat="server" ID="rptMembers">
                            <ItemTemplate>
                                <li>
                                    <div class="pic">
                                        <img src='../ahadmin/<%#Eval("PicAddress") %>' />
                                    </div>
                                    <div class="title">
                                        <a class="pc" href='content.aspx?id=<%#Eval("Id")%>' target="_blank" title="<%#Eval("Title")%>"><%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),10) %></a>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <script type="text/javascript">
                jQuery(".picScroll-left").slide({ titCell: ".hd ul", mainCell: ".bd ul", autoPage: true, effect: "left", autoPlay: true, vis: 6, trigger: "click" });
            </script>
        </div>
    </div>
</asp:Content>
