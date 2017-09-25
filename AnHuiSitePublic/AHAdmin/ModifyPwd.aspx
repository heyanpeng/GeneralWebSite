<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="AnHuiSite.AHAdmin.ModifyPwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/UserManager.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>用户管理
								<small>
                                    <i class="icon-double-angle-right"></i>
                                    密码修改
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
                    <strong id="Strong1" runat="server">
                        <i class="icon-remove" id="warnIco"></i>
                        <span id="warnMsg"></span>
                    </strong>
                </div>

                <div class="form-group" id="divUserName" style="display:none;">
                    <label for="txtUserName" class="col-sm-3 control-label no-padding-right">登录名</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtUserName" id="txtUserName" class="width-100" placeholder="输入登录名" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="div1">
                    <label for="txtPwdOld" class="col-sm-3 control-label no-padding-right">原密码</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="password" id="txtPwdOld" class="width-100" placeholder="输入密码" />
                            <i class="icon-leaf green"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="divPwd">
                    <label for="txtPwd" class="col-sm-3 control-label no-padding-right">新密码</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="password" id="txtPwd" class="width-100" placeholder="输入密码" />
                            <i class="icon-leaf green"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="divConfirmPwd">
                    <label for="txtPwd" class="col-sm-3 control-label no-padding-right">确认新密码</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="password" id="txtPwdConfirm" name="txtPwdConfirm" class="width-100" placeholder="再次输入密码" />
                            <i class="icon-leaf green"></i>
                        </span>
                    </div>
                    <div class="help-block col-xs-12 col-sm-reset inline" id="divMsg" style="visibility: hidden; color: red;">两次密码不一致</div>
                </div>

                <div class="form-group" id="divDisplyName">
                    <label for="txtDisplayName" class="col-sm-3 control-label no-padding-right">用户名称</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" id="txtDisplayName" name="txtDisplayName" class="width-100" placeholder="输入用户名称" />
                            <i class="icon-leaf orange"></i>
                        </span>
                    </div>
                </div>

                <div class="clearfix form-actions">
                    <div class="col-md-offset-4 col-md-9">

                        <button class="btn btn-info" type="button" onclick="ModifyPwd()">
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
