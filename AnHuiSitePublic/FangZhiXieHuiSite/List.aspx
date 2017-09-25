<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="AnHuiSite.List" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/list.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listhead">
        <a href="Default.aspx">首页</a> >
        <asp:Literal runat="server" ID="litNav" />
    </div>
    <div class="list">
        <ul>
            <%--<li><a href="#">四川林业有害生物信息网四川林四川林业有害生物信息网四川林<img src="images/new.gif" /><img src="images/hot.gif" /><span class="newsdate">2015-11-19</span></a></li>--%>
            <asp:Repeater runat="server" ID="rptList">
                <ItemTemplate>
                    <li>
                        <img src="images/nav_licon.jpg" /><a href='content.aspx?id=<%#Eval("Id")%>' title="<%#Eval("Title") %>" target="_blank">
                        <%#AnHuiSite.Common.SubStr(Eval("Title").ToString(),50) %></a>
                        <asp:Image runat="server" ImageUrl="images/new.gif" Visible='<%# Convert.ToBoolean(Eval("IsNew")) %>' />
                        <asp:Image runat="server" ImageUrl="images/hot.gif" Visible='<%# Convert.ToBoolean(Eval("IsHot")) %>' />
                        <span class="newsdate"><%#AnHuiSite.Common.GetShortDate(Eval("CreateTime").ToString()) %></span></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
        <div class="pager">
            <asp:Label runat="server" ID="lblId" Visible="false" Text="1" />
            <asp:Label runat="server" ID="lblWh" Visible="false" Text="1" />
            <asp:Label runat="server" ID="lblOrderBy" Visible="false" Text="1" />
            <webdiyer:AspNetPager ID="anp" runat="server"
                PageSize="20" OnPageChanged="anp_PageChanged" CssClass="pagination" LayoutType="Ul" PagingButtonLayoutType="UnorderedList" PagingButtonSpacing="0" CurrentPageButtonClass="active"
                ShowPageIndexBox="Never" FirstPageText="首页" LastPageText="尾页" PrevPageText="上一页" NextPageText="下一页">
            </webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
