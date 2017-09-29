<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="AnHuiSite.message" %>

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
    <link href="Style/css/message.css" rel="stylesheet" />
    <script src="Style/js/AddMessage.js"></script>
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
                        <img src="Style/images/tree.png" class="logotree" />
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
                            <li style="display: none;">
                                <input runat="server" type="text" class="form-control" id="Text1" name="keyword"
                                    placeholder="请输入关键字" style="width: 120px; margin-top: 2px; float: left;" />
                                <asp:Button runat="server" ID="Button1" Text="搜索" CssClass="btn btn-info btnSearch" OnClick="btnSearch_Click" Style="margin-top: 2px; float: left; margin-left: 1px;" />
                            </li>
                        </ul>
                        <div class="clear"></div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-xs-12 nav">
                    <img src="Style/images/list/home.png" />
                    首页 >
                    <asp:Literal runat="server" ID="litTitleNav" />
                </div>
            </div>

            <div class="row content">
                <div class="col-md-3 col-xs-3 contentleft">
                    <table style="box-shadow: 1px 1px 5px 0px #ccc; -moz-border-radius: 5px; -webkit-border-radius: 5px;">
                        <tr>
                            <th colspan="2">
                                <img src="Style/images/newshome.png" />&nbsp;<asp:Literal runat="server" ID="litChildTitle" /></th>
                        </tr>
                        <asp:Repeater runat="server" ID="rptChilds">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 75px; border: none;"></td>
                                    <td class='<%#GetCurrentTdClass(Eval("Id").ToString()) %>'>
                                        <a class='<%#GetCurrentAClass(Eval("Id").ToString()) %>' href="message.aspx?Id=<%#Eval("Id") %>"><%#Eval("MenuName") %></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr style="height: 100px;">
                            <td style="border: none;"></td>
                            <td style="border: none;"></td>
                        </tr>
                    </table>
                </div>
                <div class="col-md-9 col-xs-9 contentright">
                    <div class="send">
                        <span style="float: left;">
                            <button type="button" class="btn btn-success" onclick="WantMessage()">我要留言</button></span>
                        <span style="float: inherit; padding-left: 400px;">
                            <input runat="server" type="text" class="form-control" id="keyword" name="keyword"
                                placeholder="请输入关键字" style="width: 250px;" />
                        </span>
                        <span style="float: right; padding-left: 5px;">
                            <asp:TextBox runat="server" ID="messageid" Visible="false" Text="0" />
                            <asp:Button runat="server" ID="btnSearch" Text="搜索" CssClass="btn btn-info" OnClick="btnSearch_Click" />
                        </span>
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
                                                <img src="Style/images/user.png" style="width: 20px; height: 20px;" />
                                                <%#Eval("UserName") %></span>
                                            <span style="color: #757575; line-height: 30px;">在 <%#Eval("CreateTime") %> 发表的</span>
                                            <span style="float: right; color: #02854f; font-size: 18px; padding-right: 20px; margin-top: 5px;"><%--<%#Eval("Id") %><sup>#</sup>--%></span>
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
                            <tr>
                                <td>
                                    <label for="name">类&nbsp;&nbsp;&nbsp;&nbsp;型：</label></td>
                                <td colspan="3">
                                    <select id="selectmenuid" class="form-control" style="width: 250px;">
                                        <option value="0">==请选择==</option>
                                        <option value="d07a7c74374d4cd0ba927cc84913e05f">局长信箱</option>
                                        <option value="47ee57c1da1b4a4fb8f60968fdc75b3b">调查征集</option>
                                        <option value="45e261b20eb14c35b0e8350491bbb68b">咨询交流</option>
                                        <option value="56a3d6f9c9b24455984e62e4a38c0634">投诉建议</option>
                                        <option value="4aa59dd05ba0499eb302b24939892277">公众意见箱</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="name">主&nbsp;&nbsp;&nbsp;&nbsp;题：</label></td>
                                <td colspan="3">
                                    <input type="text" class="form-control" id="topic" name="topic"
                                        placeholder="请输入主题" style="width: 395px;" /></td>
                            </tr>
                            <tr>
                                <td style="height: 100px;">
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
