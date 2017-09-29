function submit(id) {
    var content = UE.getEditor('myEditor').getContent();
    var Visibility = $("#cbVisibility").is(':checked');

    if (isEmpty(content)) {
        showErrorDialog("请输入内容!");
    }

    var fd = new FormData();
    if (id == '0') {
        fd.append("oper", 'add');
    }
    else {
        fd.append("oper", 'edit');
        fd.append("id", id);
    }
   
    var mId = $("#hdMId").val();
    fd.append("mId", mId);
    fd.append("content", content);
    fd.append("Visibility", Visibility);

    $.ajax({
        url: "handlers/StaticPage.ashx",
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