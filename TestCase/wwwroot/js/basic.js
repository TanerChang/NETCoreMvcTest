
function InitTable(id, url, columns, queryParams) {
    $('#' + id).bootstrapTable('destroy').bootstrapTable({
        url: url,
        columns: columns,
        cache: false,
        method: 'post',
        sidePagination: 'server',
        pageList: '[10, 25, 50, 100]',
        pageSize: '10',
        pagination: true,
        paginationLoop: false,
        locale: 'zh-TW',
        queryParamsType: 'limit',
        queryParams: queryParams,
        classes: 'table table-striped table-bordered table-rwd',
        onLoadSuccess: function () {
            $('.bootstrap-table').css('padding-right', '0px').css('padding-left', '0px');
            $('#' + id + ' thead tr').removeClass().addClass('tr-only-hide mt-0');
            $('#' + id + ' tbody tr').each(function (tr_index) {
                $('#' + id + ' thead tr th').each(function (index) {
                    $('#' + id + ' tbody tr').eq(tr_index).find('td').eq(index).attr('data-th', $(this).text());
                });
            });
        }
    });
}

function InitTable2(name, url, uniqueId, columns, obj, pageSize, pageNumber, sortName, sortOrder) {

    if (pageSize === null || pageSize === undefined) {
        var orgPageSize = $("#" + name).bootstrapTable("getOptions").pageSize;
        if (orgPageSize === null || orgPageSize === undefined) {
            pageSize = 10;
        }
        else {

            pageSize = orgPageSize;
        }

    }
    if (pageNumber === null || pageNumber === undefined) {
        pageNumber = 1;

    }
    if (pageSize === 0) {
        pageSize = 10;
    }
    if (pageNumber === 0) {
        pageNumber = 1;
    }

    if (sortName === null || sortName === undefined) {
        sortName = null;

    }
    if (sortOrder === null || sortOrder === undefined) {
        sortOrder = "asc";

    }

    $("#" + name + "").bootstrapTable('destroy');
    $("#" + name + "").bootstrapTable({
        toggle: "table",
        url: url,
        method: 'post',
        //search: true, 
        queryParams: obj,
        queryParamsType: 'limit',
        sidePagination: "server",
        //ajaxOptions: { id: id },
        striped: true,                      //是否隔行填充顏色
        cache: false,
        pageNumber: pageNumber,
        uniqueId: uniqueId,
        sortName: sortName,
        sortOrder: sortOrder,
        pagination: true,                   //是否顯示分頁（*）
        pageSize: pageSize,
        pageList: [10, 20, 50, 100, 200, 500], //一頁顯示幾筆的選項
        columns: columns,
        onLoadError: function (status, jqXHR) {
            //	alert(JSON.stringify(status));
            console.log(jqXHR);

        },
        onLoadSuccess: function (data) { //載入成功時執行
            
        }
    });
};
