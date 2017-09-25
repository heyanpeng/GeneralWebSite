<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="FileManager.aspx.cs" Inherits="AnHuiSite.AHAdmin.FileManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/File.js"></script>
    <script type="text/javascript">
        $(function () {
            InitInputFile();
            if ('<%=isAdd%>' == "false") {
                $("#divNews,#liAdd").remove();
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>链接管理
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
                        <a data-toggle="tab" href="#divList">文件列表</a>
                    </li>

                    <li id="liAdd">
                        <a data-toggle="tab" href="#divNews">添加文件</a>
                    </li>

                </ul>

                <div class="tab-content">
                    <div id="divList" class="tab-pane active">
                        <form id="Form1" runat="server">
                            <div class="table-responsive">
                                <asp:GridView ID="gridContent" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover dataTable" runat="server"
                                    OnRowDeleting="GridView1_RowDeleting" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridContent_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemTemplate>
                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                    <a class="green" href="EditFiles.aspx?mId=<%=mId%>&mName=<%=mName %>&tId=<%=tId%>&id=<%#Eval("Id") %>"><i class="icon-pencil bigger-130"></i></a>
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
                                        <asp:TemplateField HeaderText="文件名称">
                                            <ItemTemplate>
                                                <a href="<%#Eval("FileAddress") %>" target="_blank"><%#Eval("FileName") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="DAmount" HeaderText="下载次数" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="是否公开">
                                            <ItemTemplate>
                                                <%# bool.Parse(Eval("Visibility").ToString())?"是":"否" %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="CreateTime" HeaderText="添加时间" ReadOnly="True" />
                                        <asp:BoundField DataField="ModifyTime" HeaderText="修改时间" ReadOnly="True" />
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
                                <label for="txtFileName" class="col-sm-3 control-label no-padding-right">文件名称</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtFileName" id="txtFileName" class="width-100" placeholder="输入文件名称" onblur="lostfocus('txtFileName')" />
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

                            <div class="form-group" id="div1">
                                <label for="txtDAmount" class="col-sm-3 control-label no-padding-right">下载次数</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="number" name="txtDAmount" id="txtDAmount" value="0" class="width-100" onblur="lostfocus('txtDAmount')" />
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
    </div>
</asp:Content>
