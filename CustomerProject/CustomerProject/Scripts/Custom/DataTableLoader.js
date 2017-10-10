var OPERATION_GET_CUSTOMERS = "GetCustomers";
var OPERATION_DELETE_CUSTOMER = "DeleteCustomer";
var OPERATION_EDIT_CUSTOMER = "EditCustomer";

var baseURL = 'Handlers/CustomerTableHandler.ashx?operation=';

function sendAJAX(operation, successFunction, data) {

    $.ajax({
        type: 'POST',
        data: data,
        url: baseURL + operation,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: successFunction,
        error: function (response) {
            alert('Error: ' + response.statusText);
        }
    });
}

function loadDataTable(tableID) {

    $('#' + tableID).DataTable({
        ajax: baseURL + OPERATION_GET_CUSTOMERS,
        "paging": true,
        "info": true,
        "searching": true,
        "oLanguage": {
            "sLengthMenu": "Display Records (per page)  _MENU_",
            "sSearch": "Search "
        },
        columns: [
            { title: 'ID', data: 'ID', orderable: true},
            { title: 'Name', data: 'Name', orderable: true},
            { title: 'Gender', data: 'Gender', orderable: true},
            { title: 'Number', data: 'PhoneNumber', orderable: true},
            { title: 'Age', data: 'Age', orderable: true},
            { title: 'Address', data: 'Address', orderable: true},
            { title: 'Edit', data: null, defaultContent: '<button class="btn btn-sm" onclick="editTableRow(this); return false;"><span class="glyphicon glyphicon-pencil spinning"></span></button>', orderable: false},
            { title: 'Delete', data: null, defaultContent: '<button class="btn btn-sm" onclick="showDeleteDialog(this); return false;"><span class="glyphicon glyphicon-trash spinning"></span></button>', orderable: false}
            // delete it without confirmation  { title: 'Delete', data: null, defaultContent: '<button class="btn btn-sm" onclick="deleteTableRow(this); return false;"><span class="glyphicon glyphicon-trash spinning"></span></button>' }

        ]
    });
}

function deleteTableRow(sender) {

    var idToDelete = $(sender).parent().siblings(':first').html();

    sendAJAX(
        OPERATION_DELETE_CUSTOMER,
        function (response) {
            $(sender).parents('table').DataTable().ajax.reload();
        },
        JSON.stringify({ id: idToDelete }));
}

function editTableRow(sender) {

    var idToEdit = $(sender).parent().siblings(':first').html();

    sendAJAX(
        OPERATION_EDIT_CUSTOMER,
        function (response) {
            $(sender).parents('table').DataTable().ajax.reload();
        },
        JSON.stringify({ id: idToEdit }));
}