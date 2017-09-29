function submit(id) {
    var validation = true;

    var fileName = $("#txtFileName").val();
    var dAmount = $("#txtDAmount").val();
    var Visibility = $("#cbVisibility").is(':checked');
    var mId = $("#hdMId").val();

    if (isEmpty(fileName)) {
        showErrorDialog("请输入文件名称!");
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
    var docObj = document.getElementById("inputFile");
    if (docObj.files && docObj.files[0]) {
        var time = new Date().getTime();
        var fName = $('#inputFile').val().replace(/.*(\/|\\)/, "");
        var fileExt = (/[.]/.exec(fName)) ? /[^.]+$/.exec(fName.toLowerCase()) : '';
        uploadFileName = time + "." + fileExt;
    }

    fd.append("mId", mId);
    fd.append("inputFile", $("#inputFile").get(0).files[0]);
    fd.append("uploadFileName", uploadFileName);
    fd.append("fileName", fileName);
    fd.append("dAmount", dAmount);
    fd.append("Visibility", Visibility);

    $.ajax({
        url: "handlers/FilesHandler.ashx",
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