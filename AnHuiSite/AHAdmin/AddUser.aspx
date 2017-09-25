<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="AnHuiSite.AHAdmin.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function pwdlostfocus(self) {
            var text = $('#' + self).val();
            if (text == '' || text == null || text == undefined) {
                $('#' + self).next().attr("class", "icon-remove-sign red");
            }
            else {
                var pwd = $('#txtPwd').val();
                if (pwd != text) {
                    $('#' + self).next().attr("class", "icon-remove-sign red");
                    $("#divMsg").css("visibility", "visible");
                }
                else {
                    $('#' + self).next().attr("class", "icon-ok-sign green");
                    $("#divMsg").css("visibility", "hidden");
                }
            }
        }

        function submit() {
            $('#divWarn').css("display", "block");
            var validation = true;

            var userName = $("#txtUserName").val();
            var pwd = $("#txtPwd").val();
            var pwdConfirm = $("#txtPwdConfirm").val();
            var displayName = $("#txtDisplayName").val();
            if (isEmpty(userName) || isEmpty(pwd) || isEmpty(pwdConfirm) || isEmpty(displayName)) {
                validation = false;
            }
            if (pwd != pwdConfirm) {
                validation = false;
            }

            if (!validation) {
                $('#divWarn').attr("class", "alert alert-danger");
                $('#warnMsg').html("输入验证未通过!");
                $('#warnIco').attr("class", "icon-remove");
            }
            else {
                $.ajax({
                    url: "handlers/Users.ashx",
                    type: 'post',
                    data: { oper: 'add', userName: userName, passWord: pwd, displayName: displayName },
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
        <h1>用户管理
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    新增用户
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
                    <label for="txtUserName" class="col-sm-3 control-label no-padding-right">用户名</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtUserName" id="txtUserName" class="width-100" placeholder="输入登录名" onblur="lostfocus('txtUserName')" maxlength="16" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="divPwd">
                    <label for="txtPwd" class="col-sm-3 control-label no-padding-right">密码</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="password" id="txtPwd" class="width-100" placeholder="输入密码" onblur="lostfocus('txtPwd')" maxlength="16" />
                            <i class="icon-leaf green"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="divConfirmPwd">
                    <label for="txtPwd" class="col-sm-3 control-label no-padding-right">确认密码</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="password" id="txtPwdConfirm" name="txtPwdConfirm" class="width-100" placeholder="再次输入密码" onblur="pwdlostfocus('txtPwdConfirm')" maxlength="16" />
                            <i class="icon-leaf green"></i>
                        </span>
                    </div>
                    <div class="help-block col-xs-12 col-sm-reset inline" id="divMsg" style="visibility: hidden; color: red;">两次密码不一致</div>
                </div>

                <div class="form-group" id="divDisplyName">
                    <label for="txtDisplayName" class="col-sm-3 control-label no-padding-right">显示名称</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" id="txtDisplayName" name="txtDisplayName" class="width-100" placeholder="输入用户名称" onblur="lostfocus('txtDisplayName')" maxlength="16" />
                            <i class="icon-leaf orange"></i>
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
