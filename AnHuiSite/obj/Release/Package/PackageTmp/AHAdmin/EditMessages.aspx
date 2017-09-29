<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditMessages.aspx.cs" Inherits="AnHuiSite.AHAdmin.EditMessages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script charset="utf-8" src="assets/ueditor/ueditor.config.js"></script>
    <script charset="utf-8" src="assets/ueditor/ueditor.all.min.js"></script>
    <script charset="utf-8" src="assets/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="js/MessagesManager.js"></script>
    <script>
        $(function () {
            if ('<%=messages.Visibility.ToString().ToLower()%>' == 'true') {
                $("#cbVisibility").attr("checked", "checked");
            }
            if ('<%=messages.IsSolve.ToString().ToLower()%>' == 'true') {
                $("#cbIsSolve").attr("checked", "checked");
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1><%=mName %>
            <small>
                <i class="icon-double-angle-right"></i>
                <a href="MessagesManager.aspx?mId=<%=mId%>&mName=<%=mName%>&tId=<%=tId %>">返回列表</a>
            </small>
        </h1>
    </div>
    <div class="row">
        <div class="col-xs-12">

            <div class="form-horizontal" style="text-align: left;">
                <div class="alert alert-danger" id="divWarn" style="display: none;">
                    <button type="button" class="close" data-dismiss="alert">
                        <i class="icon-remove"></i>
                    </button>
                    <strong id="Strong1" runat="server">
                        <i class="icon-remove" id="warnIco"></i>
                        <span id="warnMsg"></span>
                    </strong>
                </div>

                <input id="hdMId" type="hidden" value="<%=mId %>" />

                <div class="form-group" id="div12">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">留言时间</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtCreateTime" id="txtCreateTime" class="width-100" value="<%=messages.CreateTime %>" onblur="lostfocus('txtCreateTime')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="div11">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">姓名</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtUserName" id="txtName" class="width-100" value="<%=messages.UserName %>" onblur="lostfocus('txtName')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="div10">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">邮编</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtEmail" id="txtEmail" class="width-100" value="<%=messages.Email %>" onblur="lostfocus('txtEmail')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div9">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">电话</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtPhoneNum" id="txtPhoneNum" class="width-100" value="<%=messages.PhoneNum %>" onblur="lostfocus('txtPhoneNum')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div8">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">主题</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtSubject" id="txtSubject" class="width-100" value="<%=messages.Subject %>" onblur="lostfocus('txtSubject')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div7">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">内容</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <textarea rows="10" name="txtContent" id="txtContent" class="width-100" onblur="lostfocus('txtContent')"><%=messages.Content %></textarea>
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div6">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">回复内容</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <textarea rows="10" name="txtReplyContent" id="txtReplyContent" class="width-100" onblur="lostfocus('txtReplyContent')"><%=messages.ReplyContent %></textarea>
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div98">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">是否公开</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input name="switch-field-1" id="cbVisibility" class="ace ace-switch ace-switch-4" type="checkbox" />
                            <span class="lbl"></span>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div99">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">已回复</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input name="switch-field-1" id="cbIsSolve" class="ace ace-switch ace-switch-4" type="checkbox" />
                            <span class="lbl"></span>
                        </span>
                    </div>
                </div>

                <input type="text" name="txtUId" id="txtUId" class="width-100" value="<%=uId %>" style="display: none;" />
                <div class="clearfix form-actions">
                    <div class="col-md-offset-4 col-md-9">

                        <button class="btn btn-info" type="button" onclick="submit('<%=messages.Id %>')">
                            <i class="icon-ok bigger-110"></i>
                            回复
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
