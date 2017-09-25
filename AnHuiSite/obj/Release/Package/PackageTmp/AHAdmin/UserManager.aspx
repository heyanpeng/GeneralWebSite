<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="AnHuiSite.AHAdmin.UserManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- page specific plugin styles -->
    <script src="assets/js/jqGrid/jquery.jqGrid.min.js"></script>
    <script src="assets/js/jqGrid/i18n/grid.locale-cn.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="page-header">
            <h1>用户管理
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    用户列表
                                </small>
            </h1>
        </div>

        <div class="row">
            <div class="col-xs-12">
                <div class="table-header">
                    用户列表
                </div>

                <div class="table-responsive">
                    <asp:GridView ID="gridUsers" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover dataTable" runat="server"
                        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                        <asp:LinkButton ID="lbtEdit" runat="server" CssClass="green" CommandName="Edit"><i class="icon-pencil bigger-130"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lbtRemove" runat="server" CssClass="red" CommandName="Delete" OnClientClick="return confirm('确定删除?')"><i class="icon-trash bigger-130"></i></asp:LinkButton>
                                    </div>
                                </ItemTemplate>

                                <EditItemTemplate>
                                    <asp:LinkButton ID="lbtEdit" runat="server" CommandName="Update">
                                    <div title="" style="float: left; display: block;" class="ui-pg-div ui-inline-save" id="jSaveButton_4"  onmouseover="jQuery(this).addClass('ui-state-hover');" onmouseout="jQuery(this).removeClass('ui-state-hover');" data-original-title="Submit">
                                        <span class="ui-icon ui-icon-disk"></span>
                                    </div>
                                    </asp:LinkButton>

                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Cancel">
                                      <div title="" style="float: left; margin-left: 5px; display: block;" class="ui-pg-div ui-inline-cancel" id="jCancelButton_4"  onmouseover="jQuery(this).addClass('ui-state-hover');" onmouseout="jQuery(this).removeClass('ui-state-hover');" data-original-title="Cancel">
                                          <span class="ui-icon ui-icon-cancel"></span>
                                      </div>
                                    </asp:LinkButton>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="false"/>
                            <asp:BoundField DataField="UserName" HeaderText="登陆名" ReadOnly="True" />
                            <asp:TemplateField HeaderText="密码">
                                <ItemTemplate>
                                    ******
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <input type="password" id="txtPwd" placeholder="输入新密码" class="col-xs-10 col-sm-5" runat="server" />
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DisplayName" HeaderText="用户名称" />
                            <asp:BoundField DataField="CreateTime" HeaderText="创建时间" ReadOnly="True" />
                            <asp:BoundField DataField="ModifyTime" HeaderText="修改时间" ReadOnly="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
