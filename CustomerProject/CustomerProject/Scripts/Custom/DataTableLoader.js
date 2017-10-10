﻿var OPERATION_GET_CUSTOMERS = "GetCustomers";
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

function setUpDataTable(tableID, dataSource) {

    
}

function deleteTableRow(sender) {

    var idToDelete = $(sender).parent().siblings(':first').html();

    sendAJAX(
        OPERATION_DELETE_CUSTOMER,
        null,
        { id: idToDelete });

    $(sender).parents('table')[0].ajax.reload();
}

function editTableRow(sender) {

    var id = $(sender).parent().siblings(':first').html();
}