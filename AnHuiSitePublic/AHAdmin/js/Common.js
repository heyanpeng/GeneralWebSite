Array.prototype.contains = function (element) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] == element) {
            return true;
        }
    }
    return false;
}

Array.prototype.remove = function (val) {
    var index = this.indexOf(val);
    if (index > -1) {
        this.splice(index, 1);
    }
};

//js constant
var selectPrompt = "===请选择==="
var topMenu = "TopMenu";
var detailMenu = "DetailMenu";

$(function () {
    $('.topMenu').click(function () {
        setCookie(topMenu, $(this).attr("Id"));
    });

    $('.topMenu li').click(function () {
        var data = getCookie(detailMenu);
        var id = $(this).attr("Id");
        if (data != null && data != '') {
            var dataArray = data.split(',');
            if (dataArray.contains(id)) {
                dataArray.remove(id);
            }
            dataArray.push(id);
            data = dataArray.join(',');
        }
        else {
            data = id;
        }
        setCookie(detailMenu, data);
    });

    var clickedTopMenuId = getCookie(topMenu);
    if (clickedTopMenuId != null && clickedTopMenuId != undefined) {
        $('#' + clickedTopMenuId).addClass("active open");
        clearCookie(topMenu);
    }

    var clickedDetailMenuIds = getCookie(detailMenu);
    if (clickedDetailMenuIds != null && clickedDetailMenuIds != undefined) {
        var menuIdArray = clickedDetailMenuIds.split(',');
        for (var i = 0; i < menuIdArray.length; i++) {
            var id = menuIdArray[i];
            if (i !=0) {
                $('#' + id).addClass("active open");
            }
            else {
                $('#' + id).addClass("active");
            }
        }
        clearCookie(detailMenu);
    }

});


function setCookie(name, value) {
    document.cookie = name + "=" + escape(value);
}
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
}
function clearCookie(name) {
    setCookie(name, "", -1);
}

function lostfocus(self) {
    var text = $('#' + self).val();
    if (text == '' || text == null || text == undefined || text == selectPrompt) {
        $('#' + self).next().attr("class", "icon-remove-sign red");
    }
    else {
        $('#' + self).next().attr("class", "icon-ok-sign green");
    }
}

function showErrorDialog(msg) {
    $.gritter.add({
        title: '出现了错误',
        text: msg,
        class_name: 'gritter-error gritter-light gritter-center'
    });
}

function showSuccessDialog(msg) {
    $.gritter.add({
        title: '操作成功',
        text: msg,
        class_name: 'gritter-success gritter-light gritter-center'
    });
}

function isEmpty(text) {
    var isEmpty = false;
    if (text == '' || text == null || text == undefined || text == selectPrompt) {
        isEmpty = true;
    }
    return isEmpty;
}

function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}

function InitInputImg() {
  
    $('#inputImg').ace_file_input({
        no_file: '没有选择图片 ...',
        btn_choose: '选择图片',
        btn_change: '修改图片',
        droppable: false,
        onchange: null,
        thumbnail: false //| true | large
        //whitelist:'gif|png|jpg|jpeg'
        //blacklist:'exe|php'
        //onchange:''
        //
    });
}

function InitInputFile() {

    $('#inputFile').ace_file_input({
        no_file: '没有选择文件 ...',
        btn_choose: '选择文件',
        btn_change: '修改文件',
        droppable: false,
        onchange: null,
        thumbnail: false //| true | large
        //whitelist:'gif|png|jpg|jpeg'
        //blacklist:'exe|php'
        //onchange:''
        //
    });
}