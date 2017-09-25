<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="LinksManager.aspx.cs" Inherits="AnHuiSite.AHAdmin.LinksManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/Links.js"></script>
    <script type="text/javascript">
        $(function () {
            InitInputImg();
            if ('<%=isAdd%>' == "false") {
                $("#liAdd,#divNews").remove();
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
                                    OnRowDeleting="GridView1_RowDeleting" AllowPaging="true" PageSize="10" OnPageIndexChanging="gridContent_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="编辑">
                                            <ItemTemplate>
                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                    <a class="green" href="EditLinks.aspx?mId=<%=mId%>&mName=<%=mName %>&tId=<%=tId%>&id=<%#Eval("Id") %>"><i class="icon-pencil bigger-130"></i></a>
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
                                        <asp:BoundField DataField="LinkText" HeaderText="链接文本" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="链接图片">
                                            <ItemTemplate>
                                                <img src='<%#Eval("PicAddress") %>' style="width: 120px; height: 60px;" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="链接地址">
                                            <ItemTemplate>
                                                <a href="<%#Eval("UrlAddress") %>" target="_blank"><%#Eval("UrlAddress") %></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否可见">
                                            <ItemTemplate>
                                                <%# bool.Parse(Eval("Visibility").ToString())?"是":"否" %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SortIndex" HeaderText="序号" ReadOnly="True" />
                                        <asp:BoundField DataField="Target" HeaderText="打开方式" ReadOnly="True" />
                                        <asp:BoundField DataField="ModifyTime" HeaderText="修改时间" ReadOnly="True" />
                                        <asp:BoundField DataField="CreateTime" HeaderText="添加时间" ReadOnly="True" />
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
                                <label for="txtLinkText" class="col-sm-3 control-label no-padding-right">链接文本</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtLinkText" id="txtLinkText" class="width-100" placeholder="输入链接文本" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>

                            <div class="form-group" id="divUpImg">
                                <label for="inputImg" class="col-sm-3 control-label no-padding-right">链接图片</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="file" id="inputImg" name="inputImg" onchange="setImagePreview()" />
                                    </span>
                                </div>
                            </div>


                            <div class="form-group" id="divImg" style="display: none;">
                                <label for="inputImg" class="col-sm-3 control-label no-padding-right"></label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <img id="upImg" style="width: 300px; height: 200px;" />
                                    </span>
                                </div>
                            </div>

                            <div class="form-group" id="div1">
                                <label for="txtLinkUrl" class="col-sm-3 control-label no-padding-right">链接地址</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtLinkUrl" id="txtLinkUrl" value="http://" class="width-100" onblur="lostfocus('txtLinkUrl')" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group" id="divVisibility">
                                <label for="txtVisibility" class="col-sm-3 control-label no-padding-right">是否可见</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtVisibility" id="txtVisibility" placeholder="0：不可见  1：可见" class="width-100" onblur="lostfocus('txtVisibility')" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group" id="divSortIndex">
                                <label for="txtSortIndex" class="col-sm-3 control-label no-padding-right">序号</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtSortIndex" id="txtSortIndex" placeholder="请填写序号" class="width-100" onblur="lostfocus('txtSortIndex')" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>
                            <div class="form-group" id="divTarget">
                                <label for="txtTarget" class="col-sm-3 control-label no-padding-right">打开方式</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtTarget" id="txtTarget" placeholder="新窗口打开填写：_blank  本窗口打开：_self" class="width-100" onblur="lostfocus('txtTarget')" />
                                        <i class="icon-leaf blue"></i>
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
