jQuery(function ($) {
    var url = "handlers/Users.ashx";
    var colNames = [' ', '序号', '用户名', '密码', '显示名称', '创建时间', '修改时间'];
    var colModel = [
            {
                name: 'myac', index: '', width: 80, fixed: true, sortable: false, resize: false,
                formatter: 'actions',
                formatoptions: {
                    keys: true,
                    editbutton: true,
                    delbutton: true,
                    delOptions: {
                        recreateForm: true,
                        beforeShowForm: beforeDeleteCallback,
                        afterSubmit: deleteRow
                    },
                    editOptions: {
                        closeAfterEdit: true,
                        reloadAfterSubmit: false,
                    }
                }
            },
            { name: 'Id', index: 'Id', width: 60, sorttype: "int", editable: false },
            { name: 'UserName', index: 'UserName', width: 90, editable: true },
            { name: 'UserPwd', index: 'UserPwd', width: 150, editable: true, formatoptions: { newformat: '******' } },
            { name: 'DisplayName', index: 'DisplayName', width: 70, editable: true },
            { name: 'CreateTime', index: 'CreateTime', width: 90, sorttype: "date", editable: true, formatter: 'date', formatoptions: { newformat: 'Y-m-d' }, unformat: pickDate },
            { name: 'ModifyTime', index: 'ModifyTime', width: 150, sorttype: "date", formatter: 'date', formatoptions: { newformat: 'Y-m-d' }, unformat: pickDate }
    ];

    var editurl = "handlers/Users.ashx";

    var ltGrid = LTGrid(url, "#grid-table", "#grid-pager", "用户列表", 300, colNames, colModel, editurl)
    ltGrid.BindData(ltGrid);
});

function ModifyPwd() {
    var validation = true;
    var pwdOld = $("#txtPwdOld").val();
    var pwd1 = $("#txtPwd").val();
    var pwd2 = $("#txtPwdConfirm").val();
    var displayName = $("#txtDisplayName").val();
    if (isEmpty(pwdOld) || isEmpty(pwd1) || isEmpty(pwd2) || isEmpty(displayName)) {
        validation = false;
    }
    if (pwd1 != pwd2) {
        validation = false;
    }
    if (!validation) {
        showErrorDialog("输入验证未通过!");
    }
    var fd = new FormData();
    fd.append("oper", 'ModifyPwd');
    fd.append("pwdOld", pwdOld);
    fd.append("pwd1", pwd1);
    fd.append("pwd2", pwd2);
    fd.append("displayName", displayName);
    $.ajax({
        url: "handlers/Users.ashx",
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


