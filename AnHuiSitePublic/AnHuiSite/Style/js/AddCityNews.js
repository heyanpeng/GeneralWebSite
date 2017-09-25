$(function () {
    BindDistrict();
    //实例化编辑器
    var ue = UE.getEditor('myEditor');
    //InitInputImg();
    //var tId = getQueryString("tId");
    //if (tId == '2') {
    //    $("#divUpImg").attr("style", "");
    //}
});
function BindDistrict() {
    $.ajax({
        url: "AHAdmin/handlers/Menus.ashx",
        type: 'post',
        data: { oper: 'LoadMenu', pId: 23, level: 3 },
        success: function (responseStr) {
            var response = JSON.parse(responseStr);
            if (!response.Result) {
                showErrorDialog(response.Error);
            } else {
                var selectPrompt = "请选择地区"
                var loadHtml = "<option value=" + selectPrompt + ">" + selectPrompt + "</option>";
                var data = JSON.parse(response.Data);
                for (var i = 0; i < data.length; i++) {
                    var item = data[i];
                    loadHtml += "<option value=" + item.Id + ">" + item.MenuName + "</option>";
                }
                $("#District").html(loadHtml);
            }
        },
        error: function () {
            showErrorDialog('异常错误');
        }
    });
}
function refreshCode() {
    $('#ValidateCode').attr("src", "AHAdmin/handlers/CityNews.ashx?Action=GetValidateCode&" + Math.random());
}
function submitNews(id) {
    var validation = true;
    var uId = $("#txtuId").val();
    var title = $("#txtTitle").val();
    var scanAmount = 0;
    var source = $("#District").find("option:selected").val();
    if (isEmpty(title) || isEmpty(source)) {
        validation = false;
    }

    if (!validation) {
        showErrorDialog("输入验证未通过!");
    }
    else {
        var mId = 23;
        var isHot = false;
        var isNew = false;
        var isTop = false;

        var uploadFileName;
        var docObj = document.getElementById("inputImg");
        //if (docObj.files && docObj.files[0]) {
        //    var time = new Date().getTime();
        //    var fileName = $('#inputImg').val().replace(/.*(\/|\\)/, "");
        //    var fileExt = (/[.]/.exec(fileName)) ? /[^.]+$/.exec(fileName.toLowerCase()) : '';
        //    uploadFileName = time + "." + fileExt;
        //    var imgStr = '<img id="imgPreview" src=\\AHAdmin\\Uploads\\Images\\' + uploadFileName + ' style="width: 800px; "/>';
        //    replaceTopPic(imgStr);
        //}

        var content = UE.getEditor('myEditor').getContent();

        var fd = new FormData();
        if (id == '0') {
            fd.append("oper", 'add');
        }
        else {
            fd.append("oper", 'edit');
            fd.append("id", id);
        }
        fd.append("inputImg", "");
        fd.append("fileName", "");
        fd.append("mId", mId);
        fd.append("title", title);
        fd.append("scanAmount", scanAmount);
        fd.append("source", source);
        fd.append("content", content);
        fd.append("uId", uId);
        fd.append("isHot", isHot);
        fd.append("isNew", isNew);
        fd.append("isTop", isTop);

        $.ajax({
            url: "handlers/News.ashx",
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
                //$('#divWarn').attr("class", "alert alert-error");
                //$('#warnMsg').html("发生错误!");
                //$('#warnIco').attr("class", "icon-remove");
                showErrorDialog("发生错误!");
            }
        });
    }
}