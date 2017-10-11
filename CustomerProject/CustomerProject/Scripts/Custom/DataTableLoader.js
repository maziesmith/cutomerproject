var ATTRIBUTE_CUSTOMER_ID = 'customerid';
var ATTRIBUTE_CUSTOMER_NAME = 'customername';

function loadDataTable(tableID) {

    $('#' + tableID).DataTable({
        ajax: getOperationURL(URL_CUSTOMER_TABLE_HANDLER, OPERATION_GET_CUSTOMERS),
        "paging": true,
        "info": true,
        "searching": true,
        "oLanguage": {
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
                    return '<button class="btn btn-sm" onclick="editTableRow(this); return false;" ' +
                        ATTRIBUTE_CUSTOMER_ID + '="' + row.ID + '">' +
                        '<span class="glyphicon glyphicon-pencil spinning"></span></button>';
                }
            },
            {
                title: 'Delete',
                orderable: false,
                render: function (data, type, row, meta) {
                    return '<button class="btn btn-sm" onclick="showDeleteDialog(this); return false;" ' +
                        ATTRIBUTE_CUSTOMER_ID + '="' + row.ID + '" ' + ATTRIBUTE_CUSTOMER_NAME + '="' + row.Name + '">' +
                        '<span class="glyphicon glyphicon-trash spinning"></span></button>';
                }
            }
        ]
    });
}

function deleteTableRow(sender) {

    var id = $(sender).attr(ATTRIBUTE_CUSTOMER_ID);;

    sendCustomerTableAJAX(
        OPERATION_DELETE_CUSTOMER,
        JSON.stringify({ ID: id }),
        function (response) {
            $(sender).parents('table').DataTable().ajax.reload();
        });
}

function editTableRow(sender) {

    var idToEdit = $(sender).attr(ATTRIBUTE_CUSTOMER_ID);
    alert(idToEdit);
    /*sendCustomerTableAJAX(
        OPERATION_EDIT_CUSTOMER,
        JSON.stringify({ id: idToEdit }),
        function (response) {
            $(sender).parents('table').DataTable().ajax.reload();
        });*/
}