<%@ Page Title="" Language="C#" MasterPageFile="jysite.Master" AutoEventWireup="true" CodeBehind="votecontent.aspx.cs" Inherits="AnHuiSite.votecontent" %>

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

        .answerlist {
            margin: 0;
            padding: 0;
            list-style: none;
            font-size: 14px;
        }

        .answerradio {
        }

        .submit {
            width: 100px;
            height: 30px;
            border: none;
            background: rgb(57,139,197);
            color: #fff;
            font-size: 16px;
            margin-top: 30px;
            margin-left: 30px;
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
        <asp:RadioButtonList ID="answerrbl" runat="server" RepeatDirection="Vertical">
            <asp:ListItem Value="1">男</asp:ListItem>
            <asp:ListItem Value="2">女</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btnSubmit" runat="server" Text="提交" CssClass="submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
