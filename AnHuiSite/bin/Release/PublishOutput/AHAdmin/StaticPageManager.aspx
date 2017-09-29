<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="StaticPageManager.aspx.cs" Inherits="AnHuiSite.AHAdmin.StaticPageManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script charset="utf-8" src="assets/ueditor/ueditor.config.js"></script>
    <script charset="utf-8" src="assets/ueditor/ueditor.all.min.js"></script>
    <script charset="utf-8" src="assets/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="js/StaticPage.js"></script>
    <script type="text/javascript">
        $(function () {
            if ('<%=staticPage.Visibility.ToString().ToLower()%>' == 'true') {
                $("#cbVisibility").attr("checked", "checked");
            }
            //实例化编辑器
            var ue = UE.getEditor('myEditor');

            var content = $('#hdContent').val();
            if (!isEmpty(content)) {
                setTimeout(function () {
                    UE.getEditor('myEditor').setContent(content);
                }, 500);
            }
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>静态页面
		    <small>
                <i class="icon-double-angle-right"></i>
                <%=mName %>
            </small>
        </h1>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-horizontal" style="text-align: left;">
                <input id="hdMId" type="hidden" value="<%=mId %>" />
                <div class="form-group" id="div4">
                    <label for="editor1" class="col-sm-1 control-label no-padding-right"></label>
                    <div class="col-xs-12 col-sm-11">
                        是否显示：<input name="switch-field-1" id="cbVisibility" class="ace ace-switch ace-switch-4" type="checkbox" />
                        <span class="lbl"></span>
                    </div>
                </div>
                <div class="form-group" id="div5">
                    <label for="editor1" class="col-sm-1 control-label no-padding-right"></label>
                    <div class="col-xs-12 col-sm-11">
                        <script type="text/plain" id="myEditor" style="width: 1000px; min-height: 300px;">
                        </script>
                        <textarea id="hdContent" cols="20" rows="2" style="display: none;"><%=staticPage.Content %></textarea>
                    </div>
                </div>

                <div class="clearfix form-actions">
                    <div class="col-md-offset-4 col-md-9">

                        <button class="btn btn-info" type="button" onclick="submit('<%=staticPage.Id %>')">
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
        </div>
    </div>
</asp:Content>
