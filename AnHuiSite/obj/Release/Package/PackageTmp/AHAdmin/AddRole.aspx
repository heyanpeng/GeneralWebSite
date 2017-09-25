<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AddRole.aspx.cs" Inherits="AnHuiSite.AHAdmin.AddRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function submit() {
            $('#divWarn').css("display", "block");
            var validation = true;
            var roleName = $("#txtRoleName").val();
            if (isEmpty(roleName)) {
                validation = false;
            }
            if (!validation) {
                $('#divWarn').attr("class", "alert alert-danger");
                $('#warnMsg').html("输入验证未通过!");
                $('#warnIco').attr("class", "icon-remove");
            }
            else {
                $.ajax({
                    url: "handlers/Role.ashx",
                    type: 'post',
                    data: { oper: 'add', roleName: roleName },
                    success: function (data) {
                        var response = JSON.parse(data);
                        if (!response.Result) {
                            $('#divWarn').attr("class", "alert alert-error");
                            $('#warnMsg').html("错误:" + response.Error);
                            $('#warnIco').attr("class", "icon-remove");
                        } else {
                            $('#divWarn').attr("class", "alert alert-success");
                            $('#warnMsg').html("添加成功!");
                            $('#warnIco').attr("class", "icon-ok");
                        }
                    },
                    error: function () {
                        $('#divWarn').attr("class", "alert alert-error");
                        $('#warnMsg').html("发生错误!");
                        $('#warnIco').attr("class", "icon-remove");
                    }
                });
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>角色管理
	<small>
        <i class="icon-double-angle-right"></i>
        新增角色    
    </small>
        </h1>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-horizontal">
                <div class="alert alert-danger" id="divWarn" style="display: none;">
                    <button type="button" class="close" data-dismiss="alert">
                        <i class="icon-remove"></i>
                    </button>
                    <strong runat="server">
                        <i class="icon-remove" id="warnIco"></i>
                        <span id="warnMsg"></span>
                    </strong>
                </div>
                <div class="form-group" id="divUserName">
                    <label for="txtRoleName" class="col-sm-3 control-label no-padding-right">角色名称</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtUserName" id="txtRoleName" class="width-100" placeholder="输入角色名称" onblur="lostfocus('txtRoleName')" maxlength="16" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-4 col-md-9">
                        <button class="btn btn-info" type="button" onclick="submit()">
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
