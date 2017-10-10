var OPERATION_GET_CUSTOMERS = "GetCustomers";
var OPERATION_DELETE_CUSTOMER = "DeleteCustomer";

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
        "ordering": true,
        "info": true,
        "searching": true,
        "oLanguage": {
            "sLengthMenu": "Display Records (per page)  _MENU_",
            "sSearch": "Search "
        },
        columns: [
            { title: 'ID', data: 'ID' },
            { title: 'Name', data: 'Name' },
            { title: 'Gender', data: 'Gender' },
            { title: 'Number', data: 'PhoneNumber' },
            { title: 'Age', data: 'Age' },
            { title: 'Address', data: 'Address' },
            { title: 'Edit', data: null, defaultContent: '<button class="btn btn-sm" onclick="editTableRow(this); return false;"><span class="glyphicon glyphicon-pencil spinning"></span></button>' },
            { title: 'Delete', data: null, defaultContent: '<button class="btn btn-sm" onclick="showDeleteDialog(this);return false"><span class="glyphicon glyphicon-trash spinning"></span></button>' }
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

    var id = $(sender).parent().siblings(':first').html();
}