<%@ Page Title="" Language="C#" MasterPageFile="~/AHAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="EditLinks.aspx.cs" Inherits="AnHuiSite.AHAdmin.EditLinks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/Links.js"></script>
    <script type="text/javascript">
        $(function () {
            InitInputImg();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1><%=mName %>
            <small>
                <i class="icon-double-angle-right"></i>
                <a href="LinksManager.aspx?mId=<%=mId%>&mName=<%=mName%>&tId=<%=tId %>">返回列表</a>
            </small>
        </h1>
    </div>
    <div class="row">
        <div class="col-xs-12">
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
                    <label for="txtLinkText" class="col-sm-3 control-label no-padding-right">链接文本</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtLinkText" id="txtLinkText" class="width-100" value="<%=links.LinkText%>" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>

                <div class="form-group" id="divUpImg">
                    <label for="inputImg" class="col-sm-3 control-label no-padding-right">链接图片</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="file" id="inputImg" name="inputImg" onchange="setImagePreview()" />
                        </span>
                    </div>
                </div>

                <div class="form-group" id="divImg">
                    <label for="inputImg" class="col-sm-3 control-label no-padding-right"></label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <img id="upImg" src="<%=links.PicAddress%>" style="width: 300px; height: 200px;" />
                        </span>
                    </div>
                </div>



                <div class="form-group" id="div1">
                    <label for="txtLinkUrl" class="col-sm-3 control-label no-padding-right">链接地址</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtLinkUrl" id="txtLinkUrl" value="<%=links.UrlAddress%>" class="width-100" onblur="lostfocus('txtLinkUrl')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divVisibility">
                    <label for="txtVisibility" class="col-sm-3 control-label no-padding-right">是否可见</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtVisibility" id="txtVisibility" value="<%=links.Visibility?1:0%>" placeholder="0：不可见  1：可见" class="width-100" onblur="lostfocus('txtVisibility')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divSortIndex">
                    <label for="txtSortIndex" class="col-sm-3 control-label no-padding-right">序号</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtSortIndex" id="txtSortIndex" value="<%=links.SortIndex%>" placeholder="请填写序号" class="width-100" onblur="lostfocus('txtSortIndex')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="form-group" id="divTarget">
                    <label for="txtTarget" class="col-sm-3 control-label no-padding-right">打开方式</label>
                    <div class="col-xs-12 col-sm-5">
                        <span class="block input-icon input-icon-right">
                            <input type="text" name="txtTarget" id="txtTarget" value="<%=links.Target%>" placeholder="新窗口打开填写：_blank  本窗口打开：_self" class="width-100" onblur="lostfocus('txtTarget')" />
                            <i class="icon-leaf blue"></i>
                        </span>
                    </div>
                </div>
                <div class="clearfix form-actions">
                    <div class="col-md-offset-4 col-md-9">

                        <button class="btn btn-info" type="button" onclick="submit('<%=links.Id%>')">
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
