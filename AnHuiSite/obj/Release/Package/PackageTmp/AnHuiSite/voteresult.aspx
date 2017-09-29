<%@ Page Title="" Language="C#" MasterPageFile="jysite.Master" AutoEventWireup="true" CodeBehind="voteresult.aspx.cs" Inherits="AnHuiSite.voteresult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content .newspic {
            margin-bottom: 10px;
        }

            .content .newspic img {
                margin: 0px auto;
                display: block;
                /*width: 800px;*/
            }

        .newscontent {
            /*border: 1px solid red;*/
        }

        .resultList {
            list-style: none;
            margin: 0px;
            padding: 0px;
        }

            .resultList li {
                height: 40px;
                margin: 0px;
                padding: 0px;
            }

                .resultList li span {
                    /*border: 1px solid green;*/
                    display: table-cell;
                    line-height: 20px;
                    font-size: 16px;
                }

                    .resultList li span.left {
                        width: 245px;
                        text-align: right;
                        padding-right: 20px;
                    }

                    .resultList li span.center {
                        width: 390px;
                    }

                        .resultList li span.center .progress {
                            width: inherit;
                            background-color: green;
                        }

                    .resultList li span.right {
                        width: 100px;
                    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="newstitle">
        <asp:Literal runat="server" ID="litTitle" />
    </div>
    <div class="newssubtitle">
        发布日期：<asp:Literal runat="server" ID="litCreateDate" /><a href="javascript:window.opener=null;window.open('','_self');window.close();">【关闭】</a>
    </div>
    <div class="newscontent">
        <ul class="resultList">
            <asp:Repeater runat="server" ID="rptVoteItemList">
                <ItemTemplate>
                    <li>
                        <span class="left"><%#Eval("Content") %></span><span class="center"><span class="progress" style='width: <%#Eval("width") %>px;'></span></span><span class="right"><%#Eval("Count") %></span>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</asp:Content>
