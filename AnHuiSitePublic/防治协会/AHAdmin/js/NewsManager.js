
function setImagePreview() {
    var tId = getQueryString("tId");
    if (tId != 3) {
        var docObj = document.getElementById("inputImg");
        if (docObj.files && docObj.files[0]) {
            var src = window.URL.createObjectURL(docObj.files[0]);
            var imgStr = '<img id="imgPreview" src=' + src + ' style="width: 800px; "/>';
            replaceTopPic(imgStr);
        }
        return true;
    }
}

function replaceTopPic(imgStr) {
    var content = UE.getEditor('myEditor').getContent();
    var contents = $.parseHTML(content);
    if (contents == null || contents == undefined) {
        UE.getEditor('myEditor').setContent('<p>' + imgStr + '</p>');
    }
    else {
        //contents[0].innerHTML = imgStr;
        //var newContent = '';
        //for (var i = 0; i < contents.length; i++) {
        //    newContent += contents[i].outerHTML;
        //}
        //UE.getEditor('myEditor').setContent(newContent);
    }
}


function submit(id) {
    var validation = true;
    var tId = getQueryString("tId");
    var status;
    var fileinfo;
    if (tId == '26f6e85409ba4096beb7ebfadceaeeb4') {
        try {
            fileinfo = document.getElementById('ifUpload').contentWindow.document.getElementById("txtFileInfo").value;
            if (isEmpty(fileinfo)) {
                status = document.getElementById('ifUpload').contentWindow.document.getElementById("ProgressBar1").contentWindow.document.getElementById("completed").innerText;
            }
        } catch (e) {
            validation = false;
            alert("请先上传视频文件！");
            return;
        }
        if (!isEmpty(fileinfo) || status.indexOf('完成') >= 0)
            validation = true;
        else {
            validation = false;
            alert("请先上传视频文件！");
            return;
        }
    }
    var title = $("#txtTitle").val();
    var scanAmount = $("#txtScanAmount").val();
    var source = $("#txtOrigin").val();
    if (isEmpty(title) || isEmpty(source)) {
        validation = false;
    }

    if (!validation) {
        showErrorDialog("输入验证未通过!");
    }
    else {
        OpenLoading();
        var uId = $("#txtUId").val();
        var mId = $("#hdMId").val();
        var isHot = $("#cbHot").is(':checked');
        var isNew = $("#cbNew").is(':checked');
        var isTop = $("#cbTop").is(':checked');
        var isCheck = $("#cbCheck").is(':checked');
        var videoSrc;
        if (tId == '26f6e85409ba4096beb7ebfadceaeeb4') {
            videoSrc = fileinfo;
        }

        var uploadFileName;
        var docObj = document.getElementById("inputImg");
        if (docObj.files && docObj.files[0]) {
            var time = new Date().getTime();
            var fileName = $('#inputImg').val().replace(/.*(\/|\\)/, "");
            var fileExt = (/[.]/.exec(fileName)) ? /[^.]+$/.exec(fileName.toLowerCase()) : '';
            uploadFileName = time + "." + fileExt;
            var imgStr = '<img id="imgPreview" src=\\AHAdmin\\Uploads\\Images\\' + uploadFileName + ' style="width: 800px; "/>';
            if (tId != 3)
                replaceTopPic(imgStr);
        }

        var content = UE.getEditor('myEditor').getContent();
        console.log(content);

        var fd = new FormData();
        if (id == '0') {
            fd.append("oper", 'add');
        }
        else {
            fd.append("oper", 'edit');
            fd.append("id", id);
        }
        fd.append("inputImg", $("#inputImg").get(0).files[0]);
        fd.append("fileName", uploadFileName);
        fd.append("mId", mId);
        fd.append("title", title);
        fd.append("scanAmount", scanAmount);
        fd.append("source", source);
        fd.append("content", content);
        fd.append("uId", uId);
        fd.append("isHot", isHot);
        fd.append("isNew", isNew);
        fd.append("isTop", isTop);
        fd.append("isCheck", isCheck);
        if (tId == '26f6e85409ba4096beb7ebfadceaeeb4') {
            fd.append("videoSrc", videoSrc);
        }
        $.ajax({
            url: "handlers/News.ashx",
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
                        showSuccessDialog('添加成功');
                    }
                    else {
                        showSuccessDialog('修改成功');
                    }
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