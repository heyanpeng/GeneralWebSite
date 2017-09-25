<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="RoleMembers.aspx.cs" Inherits="AnHuiSite.AHAdmin.RoleMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- page specific plugin styles -->
    <script src="assets/js/jqGrid/jquery.jqGrid.min.js"></script>
    <script src="assets/js/jqGrid/i18n/grid.locale-cn.js"></script>
    <script>
        function UpdateRoleMembers(pUserId){
            var pValue= $("#chbUser_"+pUserId)[0].checked;
            var pRoleId = $("#hfRoleId").val();
            $.ajax({    
                url: "handlers/Role.ashx",
                type: 'post',
                data: { oper: 'UpdateRoleMembers', userId:pUserId,roleId:pRoleId,value:pValue },
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
            <h1>成员管理
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    成员列表
                                </small>
            </h1>
        </div>

        <div class="row">
            <div class="col-xs-12">
                <div class="table-header">
                    成员列表【角色名称：<asp:Literal runat="server" ID="litRole" />】
                    <asp:HiddenField ID="hfRoleId" ClientIDMode="Static" runat="server" />
                </div>

                <div class="table-responsive">
                    <asp:GridView ID="gridUsers" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover dataTable" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="状态" HeaderStyle-Width="50">
                                <ItemTemplate>
                                    <div class="visible-md visible-lg hidden-sm hidden-xs action-buttons">
                                        <input type="checkbox" <%#Eval("Value") %> id='chbUser_<%#Eval("Id") %>' onclick="UpdateRoleMembers('<%#Eval("Id") %>')" />
                                    </div>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="True" />
                            <asp:BoundField DataField="UserName" HeaderText="登陆名" ReadOnly="True" />
                            <asp:BoundField DataField="DisplayName" HeaderText="用户名称" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
