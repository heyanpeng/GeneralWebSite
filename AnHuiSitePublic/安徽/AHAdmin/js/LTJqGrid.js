function LTGrid(url, grid_selector, pager_selector, caption, height, colNames, colModel, editurl) {
    var grid = new Object;
    grid.url = url;
    grid.grid_selector = grid_selector;
    grid.pager_selector = pager_selector;
    grid.caption = caption;
    grid.height = height;
    grid.colNames = colNames;
    grid.colModel = colModel;
    grid.editurl = editurl;
    grid.BindData = bindData;
    return grid;
}

function bindData(grid) {
    $.ajax({
        url: grid.url,
        type: 'post',
        data: { oper: 'load' },
        //datatype:'json',
        success: function (data) {
            bindGrid(grid, data);
        },
        error: function () {
            alert('调用服务出错');
        }
    });
}

function bindGrid(grid, responseStr) {
    var response = JSON.parse(responseStr);
    if (!response.Result) {
        alert(response.Error);
        return;
    }
    var gridData = eval(response.Data);
    jQuery(grid.grid_selector).jqGrid({
        data: gridData,
        datatype: "local",
        caption: grid.caption,
        autowidth: true,
        height: grid.height,
        colNames: grid.colNames,
        colModel: grid.colModel,
        viewrecords: true,
        rowNum: 10,
        rowList: [10, 20, 30, 50],
        pager: grid.pager_selector,
        altRows: true,
        multiselect: false,
        multiboxonly: true,
        loadComplete: function () {
            var table = this;
            setTimeout(function () {
                updatePagerIcons(table);
                enableTooltips(table);
            }, 0);
        },

        editurl: grid.editurl,
    });

    jQuery(grid.grid_selector).bind("jqGridInlineSuccessSaveRow",
        function (e, jqXHR, rowid, options) {
            alert("successful server response:\"" + jqXHR.responseText + "\"");
            // in case of adding new row on the server you can return id
            // of the new row
            //return [true, jqXHR.responseText];
            return [true];
        }
    );


}

function deleteRow(responseObj, postdata) {
    var response = JSON.parse(responseObj.responseText);
    if (!response.Result) {
        alert(response.Error);
    }
    return [response.Result];
}

function beforeDeleteCallback(e) {
    var form = $(e[0]);
    if (form.data('styled')) return false;

    form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class="widget-header" />')
    style_delete_form(form);

    form.data('styled', true);
}

function beforeEditCallback(e) {
    var form = $(e[0]);
    form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class="widget-header" />')
    style_edit_form(form);
}

function aceSwitch(cellvalue, options, cell) {
    setTimeout(function () {
        $(cell).find('input[type=checkbox]')
                .wrap('<label class="inline" />')
            .addClass('ace ace-switch ace-switch-5')
            .after('<span class="lbl"></span>');
    }, 0);
}

//enable datepicker
function pickDate(cellvalue, options, cell) {
    setTimeout(function () {
        $(cell).find('input[type=text]')
                .datepicker({ format: 'yyyy-mm-dd', autoclose: true });
    }, 0);
}

//replace icons with FontAwesome icons like above
function updatePagerIcons(table) {
    var replacement =
    {
        'ui-icon-seek-first': 'icon-double-angle-left bigger-140',
        'ui-icon-seek-prev': 'icon-angle-left bigger-140',
        'ui-icon-seek-next': 'icon-angle-right bigger-140',
        'ui-icon-seek-end': 'icon-double-angle-right bigger-140'
    };
    $('.ui-pg-table:not(.navtable) > tbody > tr > .ui-pg-button > .ui-icon').each(function () {
        var icon = $(this);
        var $class = $.trim(icon.attr('class').replace('ui-icon', ''));

        if ($class in replacement) icon.attr('class', 'ui-icon ' + replacement[$class]);
    })
}

function enableTooltips(table) {
    $('.navtable .ui-pg-button').tooltip({ container: 'body' });
    $(table).find('.ui-pg-div').tooltip({ container: 'body' });
}

function style_delete_form(form) {
    var buttons = form.next().find('.EditButton .fm-button');
    buttons.addClass('btn btn-sm').find('[class*="-icon"]').remove();//ui-icon, s-icon
    buttons.eq(0).addClass('btn-danger').prepend('<i class="icon-trash"></i>');
    buttons.eq(1).prepend('<i class="icon-remove"></i>')
}

function style_edit_form(form) {
    //enable datepicker on "sdate" field and switches for "stock" field
    form.find('input[name=sdate]').datepicker({ format: 'yyyy-mm-dd', autoclose: true })
        .end().find('input[name=stock]')
              .addClass('ace ace-switch ace-switch-5').wrap('<label class="inline" />').after('<span class="lbl"></span>');

    //update buttons classes
    var buttons = form.next().find('.EditButton .fm-button');
    buttons.addClass('btn btn-sm').find('[class*="-icon"]').remove();//ui-icon, s-icon
    buttons.eq(0).addClass('btn-primary').prepend('<i class="icon-ok"></i>');
    buttons.eq(1).prepend('<i class="icon-remove"></i>')

    buttons = form.next().find('.navButton a');
    buttons.find('.ui-icon').remove();
    buttons.eq(0).append('<i class="icon-chevron-left"></i>');
    buttons.eq(1).append('<i class="icon-chevron-right"></i>');
}