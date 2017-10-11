﻿var OPERATION_PARAMETER = 'operation';

var OPERATION_GET_CUSTOMERS = 'GetCustomers';
var OPERATION_DELETE_CUSTOMER = 'DeleteCustomer';
var OPERATION_ADD_CUSTOMER = 'AddCustomer';

var URL_CUSTOMER_TABLE_HANDLER = 'Handlers/CustomerTableHandler.ashx';

function getOperationURL(baseURL, operation) {

    return baseURL + '?' + OPERATION_PARAMETER + '=' + operation;
}

function sendJSONWithAJAX(type, url, data, successFunction, errorFunction) {

    $.ajax({
        type: type,
        url: url,
        data: data,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: successFunction,
        error: errorFunction
    });
}

function sendCustomerTableAJAX (operation, data, successFunction) {

    sendJSONWithAJAX(
        'POST',
        getOperationURL(URL_CUSTOMER_TABLE_HANDLER, operation),
        data,
        successFunction,
        function (response) {
            alert('Error: ' + response.statusText);
        });
}