var OPERATION_GET_CUSTOMERS = "GetCustomers";
var OPERATION_DELETE_CUSTOMER = "DeleteCustomer";

function sendAJAX(operation, successFunction, data) {

    $.ajax({
        type: 'POST',
        data: data,
        url: 'Handlers/CustomerTableHandler.ashx?operation=' + operation,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: successFunction,
        error: function (response) {
            alert(response);
        }
    });
}

function loadDataTable(tableID) {

    sendAJAX(
        OPERATION_GET_CUSTOMERS,
        function (response) {
            setUpDataTable(tableID, response);
        },
        null);
}

function setUpDataTable(tableID, dataSource) {

    $('#' + tableID).DataTable({
        data: dataSource,
        columns: [
            { title: 'ID', data: 'ID' },
            { title: 'Name', data: 'Name' },
            { title: 'Gender', data: 'Gender' },
            { title: 'Number', data: 'PhoneNumber' },
            { title: 'Age', data: 'Age' },
            { title: 'Address', data: 'Address' },
            { title: 'Edit', data: null, defaultContent: '<button class="btn btn-sm" onclick="editTableRow(this); return false;"><span class="glyphicon glyphicon-pencil spinning"></span></button>' },
            { title: 'Delete', data: null, defaultContent: '<button class="btn btn-sm" onclick="deleteTableRow(this); return false;"><span class="glyphicon glyphicon-trash spinning"></span></button>' }
        ]
    });
}

function deleteTableRow(sender) {

    var idToDelete = $(sender).parent().siblings(':first').html();

    sendAJAX(
        OPERATION_DELETE_CUSTOMER,
        function (response) {
            setUpDataTable(tableID, response);
        },
        { id: idToDelete });
}

function editTableRow(sender) {

    var id = $(sender).parent().siblings(':first').html();
}