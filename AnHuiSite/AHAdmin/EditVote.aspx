<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditVote.aspx.cs" Inherits="AnHuiSite.AHAdmin.EditVote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script charset="utf-8" src="assets/ueditor/ueditor.config.js"></script>
    <script charset="utf-8" src="assets/ueditor/ueditor.all.min.js"></script>
    <script charset="utf-8" src="assets/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="js/VoteManager.js"></script>
    <script type="text/javascript">
        $(function () {
            var ue = UE.getEditor('myEditor');
            InitInputImg();
            var tId = '<%=tId%>';
            if (tId == 'bbf038d270cd4e218459d02082f05adc') {
                $("#divUpImg").attr("style", "");
            }
            if (tId == 'dad4469e96c24175bec133935bafa6a3') {
                $("#divUpImg").attr("style", "");
            }
            if (tId == '26f6e85409ba4096beb7ebfadceaeeb4') {
                $("#divUpVideo").attr("style", "");
                $("#divUpImg").attr("style", "");
            }
            if ('<%=news.IsHot%>' == '1') {
                $("#cbHot").attr("checked", "checked");
            }
            if ('<%=news.IsNew%>' == '1') {
                $("#cbNew").attr("checked", "checked");
            }
            if ('<%=news.IsTop%>' == '1') {
                $("#cbTop").attr("checked", "checked");
            }
            if ('<%=news.IsCheck%>' == '1') {
                $("#cbCheck").attr("checked", "checked");
            }
            setTimeout(function () {
                var content = $('#hdContent').val();
                UE.getEditor('myEditor').setContent(content);
            }, 500);
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
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">新闻标题</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtTitle" id="txtTitle" class="width-100" value="<%=news.Title %>" onblur="lostfocus('txtTitle')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divUpVideo" style="display: none;">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">上传视频</label>
                    <div class="col-xs-12 col-sm-7">
                        <span class="block input-icon input-icon-right">
                            <iframe id="ifUpload" name="ifUpload" src="testupload.aspx?videoSrc=<%=thisvideoSrc%>" style="width: 100%; border: 0px solid red; height: 130px; margin-left: -9px;"></iframe>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divUpImg" style="display: none;">
                    <label for="txtTitle" class="col-sm-1 control-label no-padding-left">上传图片</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="file" id="inputImg" name="inputImg" onchange="setImagePreview()" />
                            *建议图片大小 800*400
                        </span>
                    </div>
                </div>
                <div class="form-group" id="div1">
                    <label for="txtScanAmount" class="col-sm-1 control-label no-padding-right">浏览次数</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="number" name="txtScanAmount" id="txtScanAmount" value="<%=news.ScanAmount %>" class="width-100" onblur="lostfocus('txtScanAmount')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div2">
                    <label for="txtScanAmount" class="col-sm-1 control-label no-padding-right"></label>
                    <div class="col-xs-12 col-sm-5">
                        <div class="col-xs-3">
                            <label>
                                置顶
                                            <input name="switch-field-1" id="cbTop" class="ace ace-switch ace-switch-4" type="checkbox" />
                                <span class="lbl"></span>
                            </label>
                        </div>

                        <div class="col-xs-3">
                            <label>
                                热门<input name="switch-field-1" id="cbHot" class="ace ace-switch ace-switch-4" type="checkbox" />
                                <span class="lbl"></span>
                            </label>
                        </div>

                        <div class="col-xs-3">
                            <label>
                                新<input name="switch-field-1" id="cbNew" class="ace ace-switch ace-switch-4" type="checkbox" />
                                <span class="lbl"></span>
                            </label>
                        </div>
                        <asp:Panel runat="server" ID="plCheck">
                            <div class="col-xs-3">
                                <label>
                                    审核<input name="switch-field-1" id="cbCheck" class="ace ace-switch ace-switch-4" type="checkbox" />
                                    <span class="lbl"></span>
                                </label>
                            </div>
                        </asp:Panel>
                    </div>
                </div>

                <div class="form-group" id="div3">
                    <label for="txtOrigin" class="col-sm-1 control-label no-padding-right">新闻来源</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtOrigin" id="txtOrigin" class="width-100" value="<%=news.Source %>" onblur="lostfocus('txtOrigin')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div5">
                    <label for="editor1" class="col-sm-1 control-label no-padding-right">内容</label>
                    <div class="col-xs-12 col-sm-11">
                        <%--  <div class="wysiwyg-editor" id="editor1"></div>--%>
                        <script type="text/plain" id="myEditor" style="width: 1000px; min-height: 300px;">
                        </script>
                        <textarea id="hdContent" cols="20" rows="2" style="display: none;"><%=news.Content %></textarea>
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

                        <button class="btn btn-info" type="button" onclick="submit('<%=news.Id %>')">
                            <i class="icon-ok bigger-110"></i>
                            更新
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
