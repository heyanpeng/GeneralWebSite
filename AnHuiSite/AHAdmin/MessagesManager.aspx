<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="MessagesManager.aspx.cs" Inherits="AnHuiSite.AHAdmin.MessagesManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                </ul>

                <div class="tab-content">
                    <div id="divList" class="tab-pane active">
                        <form id="Form1" runat="server">
                            <div class="table-responsive">
                                <asp:GridView ID="gridContent" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover dataTable" runat="server"
                                    OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="gridContent_RowDataBound" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridContent_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="回复">
                                            <ItemTemplate>
                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                    <a class="green" href="EditMessages.aspx?mId=<%=mId%>&mName=<%=mName %>&tId=<%=tId%>&id=<%#Eval("Id") %>"><i class="icon-pencil bigger-130"></i></a>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="删除">
                                            <ItemTemplate>
                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                    <asp:LinkButton ID="lbtRemove" runat="server" CssClass="red" CommandName="Delete"><i class="icon-trash bigger-130"></i></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="false" />
                                        <asp:BoundField DataField="UserName" HeaderText="姓名" ReadOnly="True" />
                                        <asp:BoundField DataField="Email" HeaderText="邮件" ReadOnly="True" />
                                        <asp:BoundField DataField="PhoneNum" HeaderText="电话" ReadOnly="True" />
                                        <asp:BoundField DataField="Subject" HeaderText="主题" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="内容">
                                            <ItemTemplate>
                                                <%# AnHuiSite.Common.SubStr(Eval("Content").ToString(), 40) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CreateTime" HeaderText="留言时间" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="回复内容">
                                            <ItemTemplate>
                                                <%# AnHuiSite.Common.SubStr(Eval("ReplyContent").ToString(), 30) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="回复时间">
                                            <ItemTemplate>
                                                <%# bool.Parse(Eval("IsSolve").ToString())?Eval("ReplyTime").ToString():"" %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否公开">
                                            <ItemTemplate>
                                                <%# bool.Parse(Eval("Visibility").ToString())?"是":"否" %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="状态">
                                            <ItemTemplate>
                                                <%# bool.Parse(Eval("IsSolve").ToString())?"已回复":"未处理" %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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

                            <div class="form-group" id="divUpImg" style="display: none;">
                                <label for="txtTitle" class="col-sm-1 control-label no-padding-left">上传图片</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="file" id="inputImg" name="inputImg" onchange="setImagePreview()" />
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
                    </div>
                </div>
            </div>
        </div>
        <!-- /span -->
    </div>
</asp:Content>
