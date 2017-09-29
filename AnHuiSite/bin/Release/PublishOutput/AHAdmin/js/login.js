var isEncrypt = false;
$(function () {
    AutoLogin();
});

function AutoLogin() {
    var userName = GetQueryString("username");
    var passWord = GetQueryString("password");

    if (userName == null || passWord == null || userName == '' || passWord == '') {
        return;
    }

    $("#txtUsername").val(userName);
    $("#txtPassword").val(passWord);
    isEncrypt = true;
    btnLoginEvent();
}

function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

function btnLoginEvent() {
    var txtUsername = $("#txtUsername").val();
    var txtPassword = $("#txtPassword").val();
    $.ajax({
        type: "post",
        url: "handlers/Login.ashx?Action=Login",
        data: { username: txtUsername, password: txtPassword, isEncrypt: isEncrypt },
        contentType: "text",
        dataType: "text",
        success: function (data) {
            if (data == "false") {
                alert("密码错误");
            }
            else if (data == "NoExists") {
                alert("用户名不存在");
            }
            else {
                window.location.href = data;
            }
        },
        error: function () {
            alert("Error");
        }
    });
}

function getBrowserInfo() {
    var agent = navigator.userAgent.toLowerCase();

    var regStr_ie = /msie [\d.]+;/gi;
    var regStr_ff = /firefox\/[\d.]+/gi
    var regStr_chrome = /chrome\/[\d.]+/gi;
    var regStr_saf = /safari\/[\d.]+/gi;
    //IE
    if (agent.indexOf("msie") > 0) {
        return agent.match(regStr_ie);
    }

    //firefox
    if (agent.indexOf("firefox") > 0) {
        return agent.match(regStr_ff);
    }

    //Chrome
    if (agent.indexOf("chrome") > 0) {
        return agent.match(regStr_chrome);
    }

    //Safari
    if (agent.indexOf("safari") > 0 && agent.indexOf("chrome") < 0) {
        return agent.match(regStr_saf);
    }

}