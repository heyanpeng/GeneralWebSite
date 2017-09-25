function btnSubmitMesssage() {
    $('#divWarn').css("display", "block");
    var name = $("#name").val();
    var email = $("#email").val();
    var tel = $("#tel").val();
    var topic = $("#topic").val();
    var content = $("#content").val();
    var menuid = $("#selectmenuid").find("option:selected").val();
    var validateCode = $("#validateCode").val();
    if (name == "") {
        $('#divWarn').attr("class", "alert alert-danger");
        $('#divWarn').html("请输入姓名!");
        return;
    }
    if (email == "") {
        $('#divWarn').attr("class", "alert alert-danger");
        $('#divWarn').html("请输入邮箱!");
        return;
    }
    if (tel == "") {
        $('#divWarn').attr("class", "alert alert-danger");
        $('#divWarn').html("请输入电话");
        return;
    }
    if (topic == "") {
        $('#divWarn').attr("class", "alert alert-danger");
        $('#divWarn').html("请输入主题");
        return;
    }
    if (content == "") {
        $('#divWarn').attr("class", "alert alert-danger");
        $('#divWarn').html("请输入留言内容");
        return;
    }
    if (validateCode == "") {
        $('#divWarn').attr("class", "alert alert-danger");
        $('#divWarn').html("请输入验证码");
        return;
    }
    else {
        $.ajax({
            url: "AHAdmin/handlers/Message.ashx",
            type: 'post',
            data: { Action: 'AddMessage', name: name, email: email, tel: tel, topic: topic, content: content, t_m_id: menuid, validateCode: validateCode },
            success: function (data) {
                var response = JSON.parse(data);
                if (!response.Result && response.Data == "") {
                    $('#divWarn').attr("class", "alert alert-danger");
                    $('#divWarn').html("留言失败，请重试！");
                }
                else if (!response.Result && response.Data == "验证码错误") {
                    $('#divWarn').attr("class", "alert alert-danger");
                    $('#divWarn').html("验证码错误！");
                    $('#ValidateCode').attr("src", "AHAdmin/handlers/Message.ashx?Action=GetValidateCode&" + Math.random());
                }
                else {
                    $('#divWarn').attr("class", "alert alert-success");
                    $('#divWarn').html("留言成功！");
                    $('#ValidateCode').attr("src", "AHAdmin/handlers/Message.ashx?Action=GetValidateCode&" + Math.random());
                    $("#name").attr("value", '');
                    $("#email").attr("value", '');
                    $("#tel").attr("value", '');
                    $("#topic").attr("value", '');
                    $("#content").attr("value", '');
                    $("#menuid").attr("value", '');
                    $("#validateCode").attr("value", '');
                }
            },
            error: function () {
                $('#divWarn').attr("class", "alert alert-error");
                $('#divWarn').html("Server Error!");
            }
        });
    }
}

function refreshCode() {
    $('#ValidateCode').attr("src", "AHAdmin/handlers/Message.ashx?Action=GetValidateCode&" + Math.random());
}
function WantMessage() {
    $("body,html").animate({ scrollTop: $("#name").offset().top });
}