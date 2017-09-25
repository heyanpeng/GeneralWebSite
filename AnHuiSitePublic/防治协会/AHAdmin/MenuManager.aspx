<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="MenuManager.aspx.cs" Inherits="AnHuiSite.AHAdmin.MenuManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        /*隐藏嵌套的Gridview*/
        function ExpandCollapseGrid(id) {
            var status = $("#img_" + id).attr("src");

            if (status.indexOf('expand') > -1) {
                $("#div" + id).attr("style", "display:block; position: relative; left: 15px; OVERFLOW: auto; WIDTH: 97%");
                $("#img_" + id).attr("src", "images/collapse.gif");
                $("#hdRowIndex").val(id);
            }
            else {
                $("#div" + id).attr("style", "display:none; position: relative; left: 15px; OVERFLOW: auto; WIDTH: 97%");
                $("#img_" + id).attr("src", "images/expand.gif");
                $("#hdRowIndex").val(-1);
            }
        }

        function ExpandGrid(id) {
            var row = $("#div" + id);
            if (row == undefined || !row) {
                return;
            }
            $("#div" + id).attr("style", "display:block; position: relative; left: 15px; OVERFLOW: auto; WIDTH: 97%");
            $("#img_" + id).attr("src", "images/collapse.gif");
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="page-header">
            <h1>菜单管理
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    菜单列表
                                </small>
            </h1>
        </div>

        <div class="row">
            <div class="col-xs-12">
                <div class="table-header">
                    菜单列表
                </div>

                <div class="table-responsive">
                    <%--table table-striped table-bordered table-hover dataTable--%>
                    <asp:GridView ID="gridMenus" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover dataTable" Style="width: 100%; border: 0px;" runat="server"
                        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="gridMenus_RowDataBound">
                        <Columns>

                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <a onclick="ExpandCollapseGrid('<%#Eval("Id") %>')">
                                        <img id="img_<%#Eval("Id") %>" width="9" border="0" src="images/expand.gif" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>

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
                            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="false" />
                            <asp:BoundField DataField="TypeName" HeaderText="内容类型" ReadOnly="True" />
                            <asp:BoundField DataField="Level" HeaderText="菜单级别" ReadOnly="True" />
                            <asp:BoundField DataField="MenuName" HeaderText="菜单名称" />
                            <asp:BoundField DataField="SortIndex" HeaderText="排序序号" />
                            <asp:BoundField DataField="Visibility" HeaderText="是否显示" />
                            <asp:BoundField DataField="LinkSrc" HeaderText="链接地址" />
                            <asp:BoundField DataField="EnableLinkSrc" HeaderText="是否启用链接地址" />
                            <asp:BoundField DataField="IsMainNav" HeaderText="是否为导航菜单" />
                            <asp:BoundField DataField="PicAddress" HeaderText="图片地址" />
                            <asp:BoundField DataField="CreateTime" HeaderText="创建时间" ReadOnly="True" />
                            <asp:BoundField DataField="ModifyTime" HeaderText="修改时间" ReadOnly="True" />

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%# Eval("Id") %>' style="display: none; position: relative; left: 15px; overflow: auto; width: 90%">
                                                <asp:GridView ID="gvInnerItem" ClientIDMode="Static" Width="100%" Height="100%" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover dataTable" Style="border-collapse: collapse;" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
                                                    <HeaderStyle BackColor="#0083C1" />
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
                                                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="false" />
                                                        <asp:BoundField DataField="TypeName" HeaderText="内容类型" ReadOnly="True" />
                                                        <asp:BoundField DataField="Level" HeaderText="菜单级别" ReadOnly="True" />
                                                        <asp:BoundField DataField="MenuName" HeaderText="菜单名称" />
                                                        <asp:BoundField DataField="SortIndex" HeaderText="排序序号" />
                                                        <asp:BoundField DataField="Visibility" HeaderText="是否显示" />
                                                        <asp:BoundField DataField="LinkSrc" HeaderText="链接地址" />
                                                        <asp:BoundField DataField="EnableLinkSrc" HeaderText="是否启用链接地址" />
                                                        <asp:BoundField DataField="IsMainNav" HeaderText="是否为导航菜单" />
                                                        <asp:BoundField DataField="PicAddress" HeaderText="图片地址" />
                                                        <asp:BoundField DataField="CreateTime" HeaderText="创建时间" ReadOnly="True" />
                                                        <asp:BoundField DataField="ModifyTime" HeaderText="修改时间" ReadOnly="True" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hdRowIndex" ClientIDMode="Static" runat="server" Value="-1" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
