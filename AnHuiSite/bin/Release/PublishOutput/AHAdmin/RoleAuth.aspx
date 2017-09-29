<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="RoleAuth.aspx.cs" Inherits="AnHuiSite.AHAdmin.RoleAuth" %>

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
        function UpdateAuth(pLevel,pOption,pMenuId) {
            console.log(pLevel+" "+pOption+" "+pMenuId);
            var pRoleId = $("#hfRoleId").val();
            var pValue= $("#chb"+pOption+"_"+pMenuId)[0].checked;
            $.ajax({    
                url: "handlers/Role.ashx",
                type: 'post',
                data: { oper: 'UpdateAuth', roleId:pRoleId,level:pLevel,Option:pOption,Value:pValue,MenuId:pMenuId },
                success: function (data) {
                    var response = JSON.parse(data);
                    if (!response.Result) {
                        alert("失败");
                    } else {
                    }
                },
                error: function () {
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="page-header">
            <h1>权限管理
		<small>
            <i class="icon-double-angle-right"></i>
            权限列表
        </small>
            </h1>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <div class="table-header">
                    权限列表【角色名称：<asp:Literal runat="server" ID="litRole" />】
                    <asp:HiddenField ID="hfRoleId" ClientIDMode="Static" runat="server" />
                </div>
                <div class="table-responsive">
                    <asp:GridView ID="gridMenus" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover dataTable" Style="width: 100%; border: 0px;" runat="server" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDataBound="gridMenus_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="" HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <a onclick="ExpandCollapseGrid('<%#Eval("Id") %>')">
                                        <img id="img_<%#Eval("Id") %>" width="9" border="0" src="images/expand.gif" />
                                    </a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="管理" HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                        <input type="checkbox" <%#Eval("Manage") %> id='chbmanage_<%#Eval("Id") %>' onclick="UpdateAuth(1,'manage','<%#Eval("Id") %>')" />
                                    </div>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="新增" HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                        <input type="checkbox" <%#Eval("IsAdd") %> id='chbadd_<%#Eval("Id") %>' onclick="UpdateAuth(1,'add','<%#Eval("Id") %>')" />
                                    </div>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除" HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                        <input type="checkbox" <%#Eval("IsDelete") %> id='chbdelete_<%#Eval("Id") %>' onclick="UpdateAuth(1,'delete','<%#Eval("Id") %>')" />
                                    </div>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                        <input type="checkbox" <%#Eval("IsEdit") %> id='chbedit_<%#Eval("Id") %>' onclick="UpdateAuth(1,'edit','<%#Eval("Id") %>')" />
                                    </div>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="审核" HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                        <input type="checkbox" <%#Eval("IsCheck") %> id='chbcheck_<%#Eval("Id") %>' onclick="UpdateAuth(1,'check','<%#Eval("Id") %>')" />
                                    </div>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="TypeName" HeaderText="内容类型" ReadOnly="True" HeaderStyle-Width="200" />
                            <asp:BoundField DataField="MenuName" HeaderText="菜单名称" />
                            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="false" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <tr>
                                        <td colspan="100%">
                                            <div id='div<%# Eval("Id") %>'
                                                style="display: none; position: relative; left: 15px; overflow: auto; width: 90%">
                                                <asp:GridView ID="gvInnerItem" ClientIDMode="Static" Width="100%" Height="100%" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover dataTable" Style="border-collapse: collapse;" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating">
                                                    <HeaderStyle BackColor="#0083C1" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" HeaderStyle-Width="50">
                                                            <ItemTemplate>
                                                                <a onclick="ExpandCollapseGrid('<%#Eval("Id") %>')">
                                                                    <img id="img_<%#Eval("Id") %>" width="9" border="0" src="images/expand.gif" />
                                                                </a>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="管理" HeaderStyle-Width="50">
                                                            <ItemTemplate>
                                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                                    <input type="checkbox" <%#Eval("Manage") %> id='chbmanage_<%#Eval("Id") %>' onclick="UpdateAuth(1,'manage','<%#Eval("Id") %>')" />
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="新增" HeaderStyle-Width="50">
                                                            <ItemTemplate>
                                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                                    <input type="checkbox" <%#Eval("IsAdd") %> id='chbadd_<%#Eval("Id") %>' onclick="UpdateAuth(1,'add','<%#Eval("Id") %>')" />
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="删除" HeaderStyle-Width="50">
                                                            <ItemTemplate>
                                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                                    <input type="checkbox" <%#Eval("IsDelete") %> id='chbdelete_<%#Eval("Id") %>' onclick="UpdateAuth(1,'delete','<%#Eval("Id") %>')" />
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="50">
                                                            <ItemTemplate>
                                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                                    <input type="checkbox" <%#Eval("IsEdit") %> id='chbedit_<%#Eval("Id") %>' onclick="UpdateAuth(1,'edit','<%#Eval("Id") %>')" />
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="审核" HeaderStyle-Width="50">
                                                            <ItemTemplate>
                                                                <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                                                    <input type="checkbox" <%#Eval("IsCheck") %> id='chbcheck_<%#Eval("Id") %>' onclick="UpdateAuth(1,'check','<%#Eval("Id") %> ')" />
                                                                </div>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TypeName" HeaderText="内容类型" ReadOnly="True" HeaderStyle-Width="200" />
                                                        <asp:BoundField DataField="MenuName" HeaderText="菜单名称" />
                                                        <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" Visible="false" />
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
