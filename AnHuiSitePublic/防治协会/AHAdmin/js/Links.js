function setImagePreview() {
    var docObj = document.getElementById("inputImg");
    if (docObj.files && docObj.files[0]) {
        var src = window.URL.createObjectURL(docObj.files[0]);
        $("#divImg").attr("style", "");
        $("#upImg").attr("src", src);
    }
    return true;
}

function submit(id) {
    var validation = true;

    var linkText = $("#txtLinkText").val();
    var linkUrl = $("#txtLinkUrl").val();
    var Visibility = $("#txtVisibility").val();
    var SortIndex = $("#txtSortIndex").val();
    var Target = $("#txtTarget").val();

    var mId = $("#hdMId").val();

    if (isEmpty(linkUrl)) {
        showErrorDialog("请输入链接地址!");
        return;
    }

    var fd = new FormData();
    if (id == '0') {
        fd.append("oper", 'add');
    }
    else {
        fd.append("oper", 'edit');
        fd.append("id", id);
    }

    var uploadFileName;
    var docObj = document.getElementById("inputImg");
    if (docObj.files && docObj.files[0]) {
        var time = new Date().getTime();
        var fileName = $('#inputImg').val().replace(/.*(\/|\\)/, "");
        var fileExt = (/[.]/.exec(fileName)) ? /[^.]+$/.exec(fileName.toLowerCase()) : '';
        uploadFileName = time + "." + fileExt;
    }

    fd.append("mId", mId);
    fd.append("inputImg", $("#inputImg").get(0).files[0]);
    fd.append("fileName", uploadFileName);
    fd.append("linkText", linkText);
    fd.append("linkUrl", linkUrl);
    fd.append("Visibility", Visibility);
    fd.append("SortIndex", SortIndex);
    fd.append("Target", Target);

    $.ajax({
        url: "handlers/Links.ashx",
        type: 'post',
        data: fd,
        processData: false,
        contentType: false,
        success: function (data) {
            var response = JSON.parse(data);
            if (!response.Result) {
                showErrorDialog("发生错误：" + response.Error);
            } else {
                if (id == '0') {
                    showSuccessDialog('添加成功');
                }
                else {
                    showSuccessDialog('修改成功');
                }
            }
        },
        error: function () {
            showErrorDialog("发生错误!");
        }
    });
}