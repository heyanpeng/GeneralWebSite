<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="NewsManager.aspx.cs" Inherits="AnHuiSite.AHAdmin.NewsManager" ValidateRequest="false" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script src="js/NewsManager.js"></script>
    <script charset="utf-8" src="assets/ueditor/ueditor.config.js"></script>
    <script charset="utf-8" src="assets/ueditor/ueditor.all.min.js"></script>
    <script charset="utf-8" src="assets/ueditor/lang/zh-cn/zh-cn.js"></script>

    <script type="text/javascript">
        $(function () {
            //实例化编辑器
            var ue = UE.getEditor('myEditor');
            InitInputImg();
            var tId = getQueryString("tId");
            if (tId == 'bbf038d270cd4e218459d02082f05adc') {
                $("#divUpImg").attr("style", "");
            }
            if (tId == '26f6e85409ba4096beb7ebfadceaeeb4') {
                $("#divUpVideo").attr("style", "");
                $("#divUpImg").attr("style", "");
                document.getElementById('lUploadWord').innerText = "视频缩略图";
            }
            if ('<%=isAdd%>' == "false") {
                $("#divNews,#liAdd").remove();
            }
            else {
                if ('<%=isCheck%>' == "true") {
                    $("#cbCheck").attr("checked", "checked");
                } else {
                    $("#divCheck").remove();
                }
            }
        });
        function ToggleVisibility(id, type) {
            el = document.getElementById(id);
            if (el.style) {
                if (type == 'on') {
                    el.style.display = 'block';
                }
                else {
                    el.style.display = 'none';
                }
            }
            else {
                if (type == 'on') {
                    el.display = 'block';
                }
                else {
                    el.display = 'none';
                }
            }
        }
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
        <h1>内容管理
          <small>
              <i class="icon-double-angle-right"></i>
              <%=mName %>
          </small>
        </h1>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <div class="tabbable">
                <ul class="nav nav-tabs padding-12 tab-color-blue background-blue" id="myTab4">
                    <li class="active">
                        <a data-toggle="tab" href="#divList">内容列表</a>
                    </li>
                    <li id="liAdd">
                        <a data-toggle="tab" href="#divNews">添加内容</a>
                    </li>
                </ul>
                <div class="tab-content">
                    <div id="divList" class="tab-pane active">
                        <form id="Form1" runat="server">
                            <div class="table-responsive">
                                <asp:GridView ID="gridContent" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover dataTable" runat="server"
                                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="gridContent_RowDataBound" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridContent_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemTemplate>
                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                    <a class="green" href="EditNews.aspx?mId=<%=mId%>&mName=<%=mName %>&tId=<%=tId%>&id=<%#Eval("Id") %>"><i class="icon-pencil bigger-130"></i></a>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="删除">
                                            <ItemTemplate>
                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                    <asp:LinkButton ID="lbtRemove" runat="server" CssClass="red" CommandName="Delete" OnClientClick="return confirm('确定删除?')"><i class="icon-trash bigger-130"></i></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="false" />
                                        <asp:BoundField DataField="Title" HeaderText="标题" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="新闻图片">
                                            <ItemTemplate>
                                                <img src='<%#Eval("PicAddress") %>' style="width: 120px; height: 60px;" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="内容">
                                            <ItemTemplate>
                                                <a href="../content.aspx?id=<%#Eval("Id") %>" target="_blank">查看详情</a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ScanAmount" HeaderText="浏览次数" ReadOnly="True" ItemStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="是否置顶">
                                            <ItemTemplate>
                                                <input runat="server" id="colTop" class="ace ace-switch ace-switch-4" type="checkbox" onclick="this.checked = !this.checked" />
                                                <span class="lbl"></span>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否热门">
                                            <ItemTemplate>
                                                <input id="colHot" runat="server" class="ace ace-switch ace-switch-4" type="checkbox" onclick="this.checked = !this.checked" />
                                                <span class="lbl"></span>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否新">
                                            <ItemTemplate>
                                                <input runat="server" id="colNew" class="ace ace-switch ace-switch-4" type="checkbox" onclick="this.checked = !this.checked" />
                                                <span class="lbl"></span>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否通过审核">
                                            <ItemTemplate>
                                                <input runat="server" id="colCheck" class="ace ace-switch ace-switch-4" type="checkbox" onclick="this.checked = !this.checked" />
                                                <span class="lbl"></span>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Source" HeaderText="来源" ReadOnly="True" />
                                        <asp:BoundField DataField="ModifyTime" HeaderText="修改时间" ReadOnly="True" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="CreateTime" HeaderText="添加时间" ReadOnly="True" ItemStyle-HorizontalAlign="Center" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </form>
                    </div>
                    <div id="divNews" class="tab-pane in ">
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
                                        <input type="text" name="txtTitle" id="txtTitle" class="width-100" placeholder="输入标题" onblur="lostfocus('txtTitle')" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group" id="divUpVideo" style="display: none;">
                                <label for="txtTitle" class="col-sm-1 control-label no-padding-left">上传视频</label>
                                <div class="col-xs-12 col-sm-7">
                                    <span class="block input-icon input-icon-right">
                                        <iframe id="ifUpload" name="ifUpload" src="testupload.aspx" style="width: 100%; border: 0px solid red; height: 130px; margin-left: -9px;"></iframe>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group" id="divUpImg" style="display: none;">
                                <label id="lUploadWord" for="txtTitle" class="col-sm-1 control-label no-padding-left">上传图片</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <%--<input type="file" id="inputImg" name="inputImg" onchange="setImagePreview()" />--%>
                                        <input type="file" id="inputImg" name="inputImg" />
                                        *建议图片大小 800*400
                                    </span>
                                </div>
                            </div>


                            <div class="form-group" id="div1">
                                <label for="txtScanAmount" class="col-sm-1 control-label no-padding-right">浏览次数</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="number" name="txtScanAmount" id="txtScanAmount" value="0" class="width-100" onblur="lostfocus('txtScanAmount')" />
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
                                    <div class="col-xs-3" id="divCheck">
                                        <label>
                                            审核<input name="switch-field-1" id="cbCheck" class="ace ace-switch ace-switch-4" type="checkbox" />
                                            <span class="lbl"></span>
                                        </label>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group" id="div3">
                                <label for="txtOrigin" class="col-sm-1 control-label no-padding-right">新闻来源</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtOrigin" id="txtOrigin" class="width-100" placeholder="输入新闻来源" onblur="lostfocus('txtOrigin')" />
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
                                    <button class="btn btn-info" type="button" onclick="submit(0)">
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
            </div>
        </div>
        <!-- /span -->
    </div>
</asp:Content>
