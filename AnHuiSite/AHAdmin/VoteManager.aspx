<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="VoteManager.aspx.cs" Inherits="AnHuiSite.AHAdmin.VoteManager" ValidateRequest="false" %>

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
            if (tId == 'dad4469e96c24175bec133935bafa6a3') {
                $("#divUpImg").attr("style", "");
            }
            if ('<%=isAdd%>' == "false") {
                $("#divNews,#liAdd").remove();
            }
            else {
                if ('<%=isCheck%>' == "true") {
                    //$("#cbCheck").attr("checked", "checked");
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
                                        <asp:TemplateField HeaderText="标题">
                                            <ItemTemplate>
                                                <a href="../AnHuiSite/voteresult.aspx?id=<%#Eval("id").ToString() %>" target="_blank"><%#Eval("Question").ToString() %></a>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="BeginDateTime" HeaderText="开始时间" ReadOnly="True" />
                                        <asp:BoundField DataField="EndDateTime" HeaderText="结束时间" ReadOnly="True" />
                                        <asp:TemplateField HeaderText="调查状态">
                                            <ItemTemplate>
                                                <%#ReturnStatus(int.Parse(Eval("Status").ToString()),DateTime.Parse(Eval("BeginDateTime").ToString()),DateTime.Parse(Eval("EndDateTime").ToString())) %>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="是否公开调查结果">
                                            <ItemTemplate>
                                                <input runat="server" id="colIsPublic" class="ace ace-switch ace-switch-4" type="checkbox" onclick="this.checked = !this.checked" />
                                                <span class="lbl"></span>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ModifyTime" HeaderText="修改时间" ReadOnly="True" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="CreateTime" HeaderText="添加时间" ReadOnly="True" ItemStyle-HorizontalAlign="Center" />
                                    </Columns>
                                    <PagerTemplate>
                                        <asp:Label ID="lblPage" runat="Server" Text='<%# "第" +( ((GridView)Container.NamingContainer).PageIndex +1 ) +"页/共"+ (((GridView)Container.NamingContainer).PageCount) +"页" %>'></asp:Label>
                                        <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First"></asp:LinkButton>
                                        <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"></asp:LinkButton>
                                        <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next"></asp:LinkButton>
                                        <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last"></asp:LinkButton>
                                        到第<asp:TextBox runat="server" ID="inPageNum" Style="width: 50px; height: 24px; text-align: center;" MaxLength="4"></asp:TextBox>页
                                        <asp:Button ID="Button1" CommandName="go" runat="server" Text="跳转" />
                                    </PagerTemplate>
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
                                <label for="txtTitle" class="col-sm-1 control-label no-padding-left">调查问题</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtQuestion" id="txtQuestion" class="width-100" placeholder="输入调查问题" onblur="lostfocus('txtTitle')" />
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
                                        <input type="text" name="txtBeginDateTime" id="txtBeginDateTime" class="width-100" placeholder="输入开始时间" onblur="lostfocus('txtBeginDateTime')" />
                                        <i class="icon-leaf blue"></i>
                                    </span>
                                </div>
                            </div>

                            <div class="form-group" id="div3">
                                <label for="txtOrigin" class="col-sm-1 control-label no-padding-right">结束时间</label>
                                <div class="col-xs-12 col-sm-5">
                                    <span class="block input-icon input-icon-right">
                                        <input type="text" name="txtEndDateTime" id="txtEndDateTime" class="width-100" placeholder="输入结束时间" onblur="lostfocus('txtEndDateTime')" />
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
                                    <textarea rows="10" cols="95"></textarea>
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
