

function submit(id) {
    var validation = true;

    var ReplyContent = $("#txtReplyContent").val();
    var Visibility = $("#cbVisibility").is(':checked');
    var IsSolve = $("#cbIsSolve").is(':checked');
    if (isEmpty(ReplyContent)) {
        validation = false;
    }

    if (!validation) {
        showErrorDialog("输入验证未通过!");
    }
    else {
        var uId = $("#txtUId").val();

        var fd = new FormData();
        fd.append("Action", 'ReplayMessage');
        fd.append("ReplyContent", ReplyContent);
        fd.append("uId", uId);
        fd.append("id", id);
        fd.append("Visibility", Visibility);
        fd.append("IsSolve", IsSolve);
        $.ajax({
            url: "handlers/Message.ashx",
            type: 'post',
            data: fd,
            processData: false,
            contentType: false,
            success: function (data) {
                var response = JSON.parse(data);
                if (!response.Result) {
                    showErrorDialog("发生错误：" + response.Error);
                } else {
                    showSuccessDialog('修改成功');
                }
            },
            error: function () {
                //$('#divWarn').attr("class", "alert alert-error");
                //$('#warnMsg').html("发生错误!");
                //$('#warnIco').attr("class", "icon-remove");
                showErrorDialog("发生错误!");
            }
        });
    }
}