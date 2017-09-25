$(function () {
    bindContentTypes();
});

function bindContentTypes() {
    $.ajax({
        url: "handlers/ContentTypes.ashx",
        type: 'post',
        data: { oper: 'LoadAll' },
        success: function (responseStr) {
            console.log(responseStr);
            var response = JSON.parse(responseStr);
            if (!response.Result) {
                showErrorDialog(response.Error);
            } else {
                var loadHtml = "<option value=''>" + selectPrompt + "</option>";
                var data = JSON.parse(response.Data);
                for (var i = 0; i < data.length; i++) {
                    var item = data[i];
                    loadHtml += "<option value=" + item.Id + ">" + item.TypeName + "</option>";
                }
                $("#contentTypesSel").html(loadHtml);
                bindMenuTree();
            }
        },
        error: function () {
            showErrorDialog('异常错误');
        }
    });
}

function bindMenuTree() {
    var loadHtml = "<option value=''>" + selectPrompt + "</option>";
    $.ajax({
        url: "handlers/Menus.ashx",
        type: 'post',
        data: { oper: 'LoadTopMenu' },
        success: function (responseStr) {
            console.log(responseStr);
            var response = JSON.parse(responseStr);
            if (!response.Result) {
                showErrorDialog(response.Error);
            } else {
                var data = JSON.parse(response.Data);
                for (var i = 0; i < data.length; i++) {
                    var item = data[i];
                    loadHtml += "<option value=" + item.Id + ">" + item.MenuName + "</option>";
                }
                $("#parametMenuSel").html(loadHtml);
            }
        },
        error: function () {
            showErrorDialog('异常错误');
        }
    });
}


function submit() {
    $('#divWarn').css("display", "block");
    var validation = true;

    var typeId = $("#contentTypesSel").find("option:selected").val();
    var parentMenuId = $("#parametMenuSel").find("option:selected").val();
    var menuName = $("#txtMenuName").val();
    var sortIndex = $("#txtSortIndex").val();

    var PicAddress = $("#txtPicAddress").val();
    var LinkSrc = $("#txtLinkSrc").val();
    var EnableLinkSrc = $("#txtEnableLinkSrc").val();
    var IsMainNav = $("#txtIsMainNav").val();
    var Visibility = $("#txtVisibility").val();

    if (isEmpty(typeId) || isEmpty(menuName) || isEmpty(sortIndex)
        || isEmpty(EnableLinkSrc) || isEmpty(IsMainNav) || isEmpty(Visibility)) {
        validation = false;
    }

    if (!validation) {
        $('#divWarn').attr("class", "alert alert-danger");
        $('#warnMsg').html("输入验证未通过!");
        $('#warnIco').attr("class", "icon-remove");
    }
    else {
        $.ajax({
            url: "handlers/Menus.ashx",
            type: 'post',
            data: {
                oper: 'Add', typeId: typeId, parentMenuId: parentMenuId, menuName: menuName, sortIndex: sortIndex
            , PicAddress: PicAddress, LinkSrc: LinkSrc, EnableLinkSrc: EnableLinkSrc, IsMainNav: IsMainNav, Visibility: Visibility
            },
            success: function (data) {
                var response = JSON.parse(data);
                if (!response.Result) {
                    $('#divWarn').attr("class", "alert alert-error");
                    $('#warnMsg').html("错误:" + response.Error);
                    $('#warnIco').attr("class", "icon-remove");
                } else {
                    bindMenuTree();
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