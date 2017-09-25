<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Message.aspx.cs" Inherits="AnHuiSite.Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/message.css" rel="stylesheet" />
    <script src="js/message.js"></script>
    <style>
        .container {
            width: 960px;
            padding-right: 0px;
            padding-left: 0px;
        }

        a:hover {
            color: #ffffff;
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="listhead">
        <a href="Default.aspx">首页</a> >
        留言板
        <span class="iwantsay" onclick="WantMessage()">我要留言</span>
    </div>
    <div class="messagelist">
        <asp:Repeater runat="server" ID="rptMessageList">
            <ItemTemplate>
                <table style="box-shadow: 2px 2px 5px 0px #ccc; -moz-border-radius: 5px; -webkit-border-radius: 5px;">
                    <tr style="height: 40px;">
                        <td rowspan="3" style="width: 120px; border-right: 1px solid #e8e8e8; font-weight: bold; color: #757575; padding: 10px;"><%#Eval("Subject") %>
                        </td>
                        <td style="border-bottom: 1px dashed #e8e8e8;">&nbsp;&nbsp;
                                            <span style="color: #4f98cb; font-size: 16px; margin-right: 10px; font-weight: bold; padding-top: 20px;">
                                                <img src="images/user.png" style="width: 20px; height: 20px;" />
                                                <%#Eval("UserName") %></span>
                            <span style="color: #757575; line-height: 30px;">在 <%#Eval("CreateTime") %> 发表的</span>
                            <span style="float: right; color: #02854f; font-size: 18px; padding-right: 20px; margin-top: 5px;display:none;"><%#Eval("Id") %><sup>#</sup></span>
                        </td>
                    </tr>
                    <tr style="height: auto;">
                        <td style="padding-left: 10px; padding-right: 10px; text-indent: 0px; padding-top: 10px; padding-bottom: 10px;">内容：<%#Eval("Content") %>
                        </td>
                    </tr>
                    <tr style="height: auto;">
                        <td style="padding-left: 10px; padding-right: 10px;">
                            <textarea class="form-control" style="color: #02854f; background-color: white;" name="content" rows="4" readonly="readonly"><%#Eval("ReplyContent") %></textarea>
                            <span style="float: right; color: gray; height: 25px; margin-top: 10px;">回复时间：<%#Eval("ReplyTime") %></span>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="messagepage">
        <asp:Label runat="server" ID="lblPageCount" Visible="false" Text="1" />
        <asp:Label runat="server" ID="lblCount" Visible="false" Text="1" />
        <ul class="pagination">
            <li>
                <asp:LinkButton runat="server" OnClick="lbtnPage_Click" ID="lbtnFirstPage" Text="首页" /></li>
            <li>
                <asp:LinkButton runat="server" OnClick="lbtnPage_Click" ID="lbtnPrePage" Text="上一页" /></li>
            <li>
                <asp:LinkButton runat="server" OnClick="lbtnPage_Click" ID="lbtnNextPage" Text="下一页" /></li>
            <li>
                <asp:LinkButton runat="server" OnClick="lbtnPage_Click" ID="lbtnLasePage" Text="尾页" /></li>
        </ul>
    </div>
    <div id="divWarn" class="alert alert-success alert-dismissable" style="margin-top: 10px; display: none;">
        <button type="button" class="close" data-dismiss="alert"
            aria-hidden="true">
            &times;
        </button>
    </div>
    <div class="sendmessage">
        <table>
            <tr>
                <td style="width: 100px;">
                    <label for="name">姓&nbsp;&nbsp;&nbsp;&nbsp;名：</label></td>
                <td>
                    <input type="text" class="form-control" id="name" name="name"
                        placeholder="请输入姓名" style="width: 250px;" />
                </td>
            </tr>
            <tr>
                <td style="width: 100px;">
                    <label for="name">邮&nbsp;&nbsp;&nbsp;&nbsp;箱：</label></td>
                <td>
                    <input type="text" class="form-control" id="email" name="email"
                        placeholder="请输入邮箱" style="width: 250px;" /></td>
            </tr>
            <tr>
                <td>
                    <label for="name">电&nbsp;&nbsp;&nbsp;&nbsp;话：</label></td>
                <td colspan="3">
                    <input type="text" class="form-control" id="tel" name="tel"
                        placeholder="请输入电话" style="width: 250px;" />
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <label for="name">类&nbsp;&nbsp;&nbsp;&nbsp;型：</label></td>
                <td colspan="3">
                    <select id="selectmenuid" class="form-control" style="width: 250px;">
                        <option value="dd0f27e8cc134570a3c4294b7278d866">用户留言</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="name">主&nbsp;&nbsp;&nbsp;&nbsp;题：</label></td>
                <td colspan="3">
                    <input type="text" class="form-control" id="topic" name="topic"
                        placeholder="请输入主题" style="width: 644px;" /></td>
            </tr>
            <tr>
                <td style="height: 130px;">
                    <label for="name">留&nbsp;&nbsp;&nbsp;&nbsp;言：</label></td>
                <td colspan="3">
                    <textarea class="form-control" id="content" name="content" rows="5" placeholder="请输入留言内容" style="width: 645px;"></textarea>
                </td>
            </tr>
            <tr>
                <td>
                    <label for="name">验&nbsp;证&nbsp;码：</label></td>
                <td>
                    <input type="text" class="form-control" id="validateCode" name="validateCode"
                        placeholder="请输入验证码" style="width: 120px; float: left" />
                    <img id="ValidateCode" class="img-responsive" src="../AHAdmin/handlers/Message.ashx?Action=GetValidateCode" onclick="refreshCode()" style="margin-top: 2px; height: 30px;" />
                </td>
                <td colspan="2"></td>
            </tr>
            <tr>
                <td></td>
                <td colspan="3" style="text-align: left;">
                    <button type="button" class="btn btn-info" onclick="btnSubmitMesssage()">提交留言</button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
