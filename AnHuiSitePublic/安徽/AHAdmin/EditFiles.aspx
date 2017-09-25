<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditFiles.aspx.cs" Inherits="AnHuiSite.AHAdmin.EditFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/File.js"></script>
    <script type="text/javascript">
        $(function () {
            InitInputFile();
            if ('<%=files.Visibility.ToString().ToLower()%>' == 'true') {
                $("#cbVisibility").attr("checked", "checked");
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1><%=mName %>
            <small>
                <i class="icon-double-angle-right"></i>
                <a href="FileManager.aspx?mId=<%=mId%>&mName=<%=mName%>&tId=<%=tId %>">返回列表</a>
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
                    <label for="txtFileName" class="col-sm-3 control-label no-padding-right">文件名称</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtFileName" id="txtFileName" class="width-100" value="<%=files.FileName %>" onblur="lostfocus('txtFileName')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="divUpImg">
                    <label for="inputFile" class="col-sm-3 control-label no-padding-right">上传文件</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="file" id="inputFile" name="inputFile" />
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div2">
                    <label for="inputFile" class="col-sm-3 control-label no-padding-right">已上传文件</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <a href="<%=files.FileAddress %>" target="_blank"><%=files.FileAddress %></a>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div1">
                    <label for="txtDAmount" class="col-sm-3 control-label no-padding-right">下载次数</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="number" name="txtDAmount" id="txtDAmount" value="<%=files.DAmount %>" class="width-100" onblur="lostfocus('txtDAmount')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="div98">
                    <label for="txtTitle" class="col-sm-3 control-label no-padding-left">是否公开</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input name="switch-field-1" id="cbVisibility" class="ace ace-switch ace-switch-4" type="checkbox" />
                            <span class="lbl"></span>
                        </span>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-4 col-md-9">

                        <button class="btn btn-info" type="button" onclick="submit('<%=files.Id %>')">
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
