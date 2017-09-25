<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="SiteConfig.aspx.cs" Inherits="AnHuiSite.AHAdmin.SiteConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            InitSiteConfig();
        });
        function InitSiteConfig() {
            $.ajax({
                url: "handlers/SiteConfig.ashx",
                type: 'post',
                data: { oper: 'GetSiteConfig' },
                success: function (data) {
                    console.log(data);
                    var response = JSON.parse(data);
                    if (!response.Result) {
                        $('#divWarn').attr("class", "alert alert-error");
                        $('#warnMsg').html("错误:" + response.Error);
                        $('#warnIco').attr("class", "icon-remove");
                    } else {
                        var siteConfig = JSON.parse(response.Data);
                        $("#txtSiteName").val(siteConfig.SiteName);
                        $("#txtCopyright")[0].value = siteConfig.Copyright;
                        $("#txtLogoUrl").val(siteConfig.LogoUrl);
                        $("#txtSiteTitle").val(siteConfig.SiteTitle);
                        $("#txtMeta_Keywords").val(siteConfig.Meta_Keywords);
                        $("#txtMeta_Description").val(siteConfig.Meta_Description);
                        if (siteConfig.EnableWebSite) {
                            $("#txtEnableWebSite").val(1);
                        } else {
                            $("#txtEnableWebSite").val(0);
                        }
                        $("#txtVersion").val(siteConfig.Version);
                    }
                },
                error: function () {
                    $('#divWarn').attr("class", "alert alert-error");
                    $('#warnMsg').html("发生错误!");
                    $('#warnIco').attr("class", "icon-remove");
                }
            });
        }
        function submit() {
            var txtSiteName = $("#txtSiteName").val();
            var txtCopyright = $("#txtCopyright")[0].value;
            var txtLogoUrl = $("#txtLogoUrl").val();
            var txtSiteTitle = $("#txtSiteTitle").val();
            var txtMeta_Keywords = $("#txtMeta_Keywords").val();
            var txtMeta_Description = $("#txtMeta_Description").val();
            var txtEnableWebSite = $("#txtEnableWebSite").val();
            var txtVersion = $("#txtVersion").val();
            $.ajax({
                url: "handlers/SiteConfig.ashx",
                type: 'post',
                data: {
                    oper: 'UpdateSiteConfig',
                    SiteName: txtSiteName,
                    Copyright: txtCopyright,
                    LogoUrl: txtLogoUrl,
                    SiteTitle: txtSiteTitle,
                    Meta_Keywords: txtMeta_Keywords,
                    Meta_Description: txtMeta_Description,
                    EnableWebSite: txtEnableWebSite,
                    Version: txtVersion,
                },
                success: function (data) {
                    console.log(data);
                    var response = JSON.parse(data);
                    if (!response.Result) {
                        $('#divWarn').attr("class", "alert alert-error");
                        $('#warnMsg').html("错误:" + response.Error);
                        $('#warnIco').attr("class", "icon-remove");
                    } else {
                        $('#divWarn').attr("class", "alert alert-success");
                        $('#warnMsg').html("更新成功!");
                        $('#warnIco').attr("class", "icon-ok");
                        $('#divWarn').show();
                    }
                },
                error: function () {
                    $('#divWarn').attr("class", "alert alert-error");
                    $('#warnMsg').html("发生错误!");
                    $('#warnIco').attr("class", "icon-remove");
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>网站配置
	<small>
        <i class="icon-double-angle-right"></i>
        基本信息    
    </small>
        </h1>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-horizontal">
                <div class="alert alert-danger" id="divWarn"  style="display: none;">
                    <button type="button" class="close" data-dismiss="alert">
                        <i class="icon-remove"></i>
                    </button>
                    <strong runat="server">
                        <i class="icon-remove" id="warnIco"></i>
                        <span id="warnMsg"></span>
                    </strong>
                </div>
                <div class="form-group" id="divSiteName">
                    <label for="txtSiteName" class="col-sm-3 control-label no-padding-right">网站名称</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtSiteName" id="txtSiteName" class="width-100" placeholder="输入网站名称" onblur="lostfocus('txtSiteName')" maxlength="16" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divCopyright">
                    <label for="txtCopyright" class="col-sm-3 control-label no-padding-right">版权信息</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <textarea name="txtCopyright" id="txtCopyright" class="width-100" placeholder="输入版权信息" onblur="lostfocus('txtCopyright')"></textarea>
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divLogoUrl">
                    <label for="txtLogoUrl" class="col-sm-3 control-label no-padding-right">LOGO地址</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtLogoUrl" id="txtLogoUrl" class="width-100" placeholder="输入LOGO地址" onblur="lostfocus('txtLogoUrl')" maxlength="16" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divSiteTitle">
                    <label for="txtSiteTitle" class="col-sm-3 control-label no-padding-right">网站标题</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtSiteTitle" id="txtSiteTitle" class="width-100" placeholder="输入LOGO地址" onblur="lostfocus('txtSiteTitle')" maxlength="16" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divMeta_Keywords">
                    <label for="txtMeta_Keywords" class="col-sm-3 control-label no-padding-right">针对搜索引擎的关键字</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtMeta_Keywords" id="txtMeta_Keywords" class="width-100" placeholder="输入针对搜索引擎的关键字" onblur="lostfocus('txtMeta_Keywords')" maxlength="16" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divMeta_Description">
                    <label for="txtMeta_Description" class="col-sm-3 control-label no-padding-right">针对搜索引擎的说明</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtMeta_Description" id="txtMeta_Description" class="width-100" placeholder="针对搜索引擎的说明" onblur="lostfocus('txtMeta_Description')" maxlength="16" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divVersion">
                    <label for="txtVersion" class="col-sm-3 control-label no-padding-right">网站版本号</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtVersion" id="txtVersion" class="width-100" placeholder="输入网站版本号" onblur="lostfocus('txtVersion')" maxlength="16" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divEnableWebSite">
                    <label for="txtEnableWebSite" class="col-sm-3 control-label no-padding-right">是否开启网站</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtEnableWebSite" id="txtEnableWebSite" class="width-100" placeholder="0：关闭  1：开启" onblur="lostfocus('txtEnableWebSite')" maxlength="16" />
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
