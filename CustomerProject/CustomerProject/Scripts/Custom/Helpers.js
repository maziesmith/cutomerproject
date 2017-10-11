﻿var OPERATION_GET_CUSTOMERS = "GetCustomers";
var OPERATION_DELETE_CUSTOMER = "DeleteCustomer";
var OPERATION_ADD_CUSTOMER = "AddCustomer";

var baseURL = 'Handlers/CustomerTableHandler.ashx?operation=';

function sendAJAX(
    operation,
    data,
    successFunction,
    errorFunction) {

    $.ajax({
        type: 'POST',
        data: data,
        url: baseURL + operation,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: successFunction,
        error: errorFunction
    });
}