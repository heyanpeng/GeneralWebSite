<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="AddMenu.aspx.cs" Inherits="AnHuiSite.AHAdmin.AddMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/js/fuelux/data/fuelux.tree-sampledata.js"></script>
    <script src="assets/js/fuelux/fuelux.tree.min.js"></script>
    <script src="js/AddMenu.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1>菜单管理
	<small>
        <i class="icon-double-angle-right"></i>
        新增菜单
    </small>
        </h1>
    </div>
    <div class="row">
        <div class="col-xs-12">
            <div class="form-horizontal">
                <div class="form-group">
                    <label for="ddlContentTypes" class="col-sm-3 control-label no-padding-right">菜单内容类型</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <select id="contentTypesSel" class="width-100 form-control" onblur="lostfocus('contentTypesSel')">
                            </select>
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlContentTypes" class="col-sm-3 control-label no-padding-right">父菜单</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <select id="parametMenuSel" class="width-100">
                            </select>
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtMenuName" class="col-sm-3 control-label no-padding-right">菜单名称</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtMenuName" id="txtMenuName" class="width-100" placeholder="输入菜单名称" onblur="lostfocus('txtMenuName')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtSortIndex" class="col-sm-3 control-label no-padding-right">排序序号</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtSortIndex" id="txtSortIndex" value="0" class="width-100" placeholder="输入排序序号" onblur="lostfocus('txtSortIndex')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPicAddress" class="col-sm-3 control-label no-padding-right">图片地址</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtPicAddress" id="txtPicAddress" class="width-100" placeholder="输入图片地址" onblur="lostfocus('txtPicAddress')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtLinkSrc" class="col-sm-3 control-label no-padding-right">链接地址</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtLinkSrc" id="txtLinkSrc" class="width-100" placeholder="输入链接地址" onblur="lostfocus('txtLinkSrc')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtEnableLinkSrc" class="col-sm-3 control-label no-padding-right">是否启用链接地址</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtEnableLinkSrc" id="txtEnableLinkSrc" class="width-100" placeholder="0：否 1：是" onblur="lostfocus('txtEnableLinkSrc')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtIsMainNav" class="col-sm-3 control-label no-padding-right">是否为导航菜单</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtIsMainNav" id="txtIsMainNav" class="width-100" placeholder="0：否 1：是" onblur="lostfocus('txtIsMainNav')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtVisibility" class="col-sm-3 control-label no-padding-right">是否显示</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtVisibility" id="txtVisibility" class="width-100" placeholder="0：否 1：是" onblur="lostfocus('txtVisibility')" />
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
