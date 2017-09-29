<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditVote.aspx.cs" Inherits="AnHuiSite.AHAdmin.EditVote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script charset="utf-8" src="assets/ueditor/ueditor.config.js"></script>
    <script charset="utf-8" src="assets/ueditor/ueditor.all.min.js"></script>
    <script charset="utf-8" src="assets/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="js/VoteManager.js"></script>
    <script type="text/javascript">
        $(function () {
            if ('<%=vote.IsPublic%>' == '1') {
                $("#cbIsPublic").attr("checked", "checked");
            }
        });
    </script>
    <style type="text/css">
        .over {
            display: none;
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #f5f5f5;
            opacity: 0.5;
            z-index: 1000;
        }

        .layout {
            display: none;
            position: absolute;
            top: 40%;
            left: 40%;
            width: 20%;
            height: 20%;
            z-index: 1001;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1><%=mName %>
            <small>
                <i class="icon-double-angle-right"></i>
                <a href="NewsManager.aspx?mId=<%=mId%>&mName=<%=mName%>&tId=<%=tId %>">返回列表</a>
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

                            <div class="form-group" id="div11">
                                <label for="txtTitle" class="col-sm-1 control-label no-padding-left">调查问题</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtQuestion" id="txtQuestion" class="width-100" value="<%=vote.Question %>" placeholder="输入调查问题，例如：你对本网站栏目设置是否满意？" onblur="lostfocus('txtTitle')" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group" id="div11">
                                <label for="txtTitle" class="col-sm-1 control-label no-padding-left">调查状态</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtStatus" id="txtStatus" class="width-100" value="<%=vote.Status %>" placeholder="输入调查状态，例如：1[根据时间自动计算]、2[未开启]、3[进行中]、4[已结束]、5[关闭]" onblur="lostfocus('txtTitle')" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group" id="div2">
                                <label for="txtScanAmount" class="col-sm-1 control-label no-padding-right"></label>
                                <div class="col-xs-12 col-sm-5">
                                    <div class="col-xs-3">
                                        <label>
                                            公开结果
                                            <input name="switch-field-1" id="cbIsPublic" class="ace ace-switch ace-switch-4" type="checkbox" />
                                            <span class="lbl"></span>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group" id="div3">
                                <label for="txtOrigin" class="col-sm-1 control-label no-padding-right">开始时间</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtBeginDateTime" id="txtBeginDateTime" class="width-100" value="<%=vote.BeginDateTime %>" placeholder="输入开始时间，例如：2017/01/01 08:00:00" onblur="lostfocus('txtBeginDateTime')" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>

                            <div class="form-group" id="div3">
                                <label for="txtOrigin" class="col-sm-1 control-label no-padding-right">结束时间</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtEndDateTime" id="txtEndDateTime" class="width-100" value="<%=vote.EndDateTime %>" placeholder="输入结束时间，例如：2017/01/031 18:00:00" onblur="lostfocus('txtEndDateTime')" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>

                            <div class="form-group" id="div5">
                                <label for="editor1" class="col-sm-1 control-label no-padding-right">内容</label>
                                <div class="col-xs-12 col-sm-11">
                                    <%--  <div class="wysiwyg-editor" id="editor1"></div>--%>
                                    <%--<script type="text/plain" id="myEditor" style="width: 1000px; min-height: 300px;">
                                    </script>--%>
                                    <textarea rows="10" cols="95" id="txtVoteItemList" placeholder="输入待选项，一行代表一个待选项,例如：&#xA满意&#xA不满意&#xA一般"><%=voteItemListStr %></textarea>
                                </div>
                            </div>

                            <div class="form-group" id="div4">
                                <label for="txtPeople" class="col-sm-1 control-label no-padding-right">发布人</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtPeople" id="txtPeople" value="<%=displayName %>" class="width-100" readonly="readonly" />
                                        <input type="text" name="txtUId" id="txtUId" class="width-100" value="<%=uId %>" style="display: none;" />
                                        <i class="icon-ok-sign green"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="clearfix form-actions">
                                <div class="col-md-offset-4 col-md-9">
                                    <button class="btn btn-info" type="button" onclick="submit('<%=vote.Id %>')">
                                        <i class="icon-ok bigger-110"></i>
                                        提交
                                    </button>
                                    &nbsp; &nbsp; &nbsp;
											<button class="btn" type="reset">
                                                <i class="icon-undo bigger-110"></i>
                                                重置
                                            </button>
                                </div>
                            </div>
                        </div>
            <div id="over" class="over">
            </div>
            <div id="layout" class="layout">
                <img src="images/loading.gif" />
            </div>
        </div>
    </div>


</asp:Content>
