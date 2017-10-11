var dataTableID;

function loadDataTable(tableID) {

    dataTableID = '#' + tableID;

    $(dataTableID).DataTable({
        ajax: getOperationURL(URL_CUSTOMER_TABLE_HANDLER, OPERATION_GET_CUSTOMERS),
        paging: true,
        info: true,
        searching: true,
        oLanguage: {
            "sLengthMenu": "Display Records (per page)  _MENU_",
            "sSearch": "Search "
        },
        columns: [
            { title: 'Name', data: 'Name', orderable: true },
            { title: 'Gender', data: 'Gender', orderable: true },
            { title: 'Number', data: 'PhoneNumber', orderable: true },
            { title: 'Age', data: 'Age', orderable: true },
            { title: 'Address', data: 'Address', orderable: true },
            {
                title: 'Edit',
                orderable: false,
                render: function (data, type, row, meta) {
                    return '<button class="btn btn-sm" onclick="return false;">' +
                        '<span class="glyphicon glyphicon-pencil spinning"></span></button>';
                }
            },
            {
                title: 'Delete',
                orderable: false,
                render: function (data, type, row, meta) {
                    return '<button class="btn btn-sm" onclick="showDeleteDialog(\'' + row.Name + '\', ' +
                        'function(){ ajaxDeleteCustomer(\''+ row.ID +'\', function(){ $(\'#' + meta.settings.sTableId + '\').DataTable().ajax.reload(); }); }); return false;">' +
                        '<span class="glyphicon glyphicon-trash spinning"></span></button>';
                }
            }
        ]
    });
}