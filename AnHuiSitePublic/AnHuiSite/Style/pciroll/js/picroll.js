(function () {
    var speed = 20; //滚动速度
    var lis = 190; //单个单位的宽度
    var i = 0;
    var t = true;
    var a = parseInt($('#picroll').css('width'));
    var b = parseInt($('#picroll ul li').length * lis);
    $('#picroll').css('width', b)
    var distance = b - a;
    // console.log(distance);
    function add() {
        i++;
    }
    function reduce() {
        i--;
    }
    function jia() {
        if ((i < distance || i < i) && t) {
            add();
        } else if (i >= distance || !t) {
            t = false;
            reduce();
        }
        if (i == 0) {
            t = true;
        }
        $('#picroll').css('left', -i)
    }
    var d = setInterval(jia, speed);
    $('#picroll').mouseover(function () {
        clearInterval(d);
    });
    $('#picroll').mouseleave(function () {
        d = setInterval(jia, speed);
    });
}());