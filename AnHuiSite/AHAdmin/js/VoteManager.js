function submit(id) {
    var validation = true;
    var tId = getQueryString("tId");
    var question = $("#txtQuestion").val();
    var status = $("#txtStatus").val();
    var voteItemList = $("#txtVoteItemList").val();
    var beginDateTime = $("#txtBeginDateTime").val();
    var endDateTime = $("#txtEndDateTime").val();
    if (isEmpty(question) || isEmpty(status) || isEmpty(voteItemList)) {
        validation = false;
    }

    if (!validation) {
        showErrorDialog("输入验证未通过!");
    }
    else {
        OpenLoading();
        var uId = $("#txtUId").val();
        var mId = $("#hdMId").val();
        var isPublic = $("#cbIsPublic").is(':checked');

        var fd = new FormData();
        if (id == '0') {
            fd.append("oper", 'add');
        }
        else {
            fd.append("oper", 'edit');
            fd.append("id", id);
        }
        fd.append("tId", tId);
        fd.append("mId", mId);
        fd.append("uId", uId);
        fd.append("question", question);
        fd.append("status", status);
        fd.append("voteItemList", voteItemList);
        fd.append("isPublic", isPublic);
        fd.append("beginDateTime", beginDateTime);
        fd.append("endDateTime", endDateTime);
        $.ajax({
            url: "handlers/Vote.ashx",
            type: 'post',
            data: fd,
            dataType: "json",
            processData: false,
            contentType: false,
            success: function (data) {
                var response = data;
                CloseLoading();
                if (!response.Result) {
                    showErrorDialog("发生错误：" + response.Error);
                } else {
                    if (id == '0') {
                        showSuccessDialog('添加成功,3秒后自动跳转...');
                    }
                    else {
                        showSuccessDialog('修改成功,3秒后自动跳转...');
                    }
                    setTimeout(function () {
                        window.location.reload();
                    }, 3000);
                }
            },
            error: function () {
                CloseLoading();
                showErrorDialog("发生错误!");
            }
        });
    }
}
function OpenLoading() {
    document.getElementById("over").style.display = "block";
    document.getElementById("layout").style.display = "block";
}
function CloseLoading() {
    document.getElementById("over").style.display = "none";
    document.getElementById("layout").style.display = "none";
}