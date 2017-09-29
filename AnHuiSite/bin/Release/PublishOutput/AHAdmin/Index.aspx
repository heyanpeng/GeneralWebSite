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
                <strong class="green">
                    <asp:Literal runat="server" ID="litSiteName" />
                    <small>(v<asp:Literal runat="server" ID="litVersion" />)</small>
                </strong>
                后台管理系统
            </div>
            

            <div class="hr hr14 hr-dotted"></div>
            <div class="row" style="display:none;">
                <div class="space-6">
                </div>
                <div class="col-sm-6 infobox-container">
                    <div class="widget-box">
                        <div class="widget-header widget-header-flat widget-header-small" style="text-align: left;">
                            <h5>
                                <i class="icon-signal"></i>
                                历史数据统计
                            </h5>
                        </div>
                        <div class="widget-body">
                            <div class="widget-main">
                                <div class="infobox infobox-green  ">

                                    <div class="infobox-icon">
                                        <i class="icon-book"></i>
                                    </div>

                                    <div class="infobox-data">
                                        <span class="infobox-data-number"><%=HistoryNewsCount %></span>
                                        <div class="infobox-content">今日新闻</div>
                                    </div>
                                </div>

                                <div class="infobox infobox-green2  ">

                                    <div class="infobox-icon">
                                        <i class="icon-book"></i>
                                    </div>

                                    <div class="infobox-data">
                                        <span class="infobox-data-number"><%=TodayNewsCount %></span>
                                        <div class="infobox-content">今日留言</div>
                                    </div>
                                </div>

                                <div class="infobox infobox-blue  ">
                                    <div class="infobox-icon">
                                        <i class="icon-table"></i>
                                    </div>

                                    <div class="infobox-data">
                                        <span class="infobox-data-number"><%=HistoryRegionCount %></span>
                                        <div class="infobox-content">历史市县新闻</div>
                                    </div>
                                </div>

                                <div class="infobox infobox-blue2  ">
                                    <div class="infobox-icon">
                                        <i class="icon-table"></i>
                                    </div>

                                    <div class="infobox-data">
                                        <span class="infobox-data-number"><%=TodayRegionCount %></span>
                                        <div class="infobox-content">历史新闻</div>
                                    </div>
                                </div>

                                <div class="infobox infobox-orange">
                                    <div class="infobox-icon">
                                        <i class="icon-envelope"></i>
                                    </div>

                                    <div class="infobox-data">
                                        <span class="infobox-data-number"><%=HistoryMessageCount %></span>
                                        <div class="infobox-content">历史消息</div>
                                    </div>
                                </div>


                                <div class="infobox infobox-orange2  ">
                                    <div class="infobox-icon">
                                        <i class="icon-envelope"></i>
                                    </div>

                                    <div class="infobox-data">
                                        <span class="infobox-data-number"><%=TodayMessageCount %></span>
                                        <div class="infobox-content">今日消息</div>
                                    </div>
                                </div>

                                <div class="space-6"></div>

                                <div class="infobox infobox-green infobox-small infobox-dark">
                                    <div class="infobox-data">
                                        <div class="infobox-data-number"><%=ScanAmount %></div>
                                        <div class="infobox-content">新闻浏览</div>
                                    </div>
                                </div>

                                <div class="infobox infobox-blue infobox-small infobox-dark">
                                    <div class="infobox-data">
                                        <div class="infobox-data-number"><%=FileDAmount %></div>
                                        <div class="infobox-content">文件下载</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
