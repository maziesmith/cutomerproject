var OPERATION_PARAMETER = 'operation';

var OPERATION_GET_CUSTOMERS = 'GetCustomers';
var OPERATION_DELETE_CUSTOMER = 'DeleteCustomer';
var OPERATION_ADD_CUSTOMER = 'AddCustomer';
var OPERATION_EDIT_CUSTOMER = 'EditCustomer';
var OPERATION_GET_CUSTOMER = 'GetCustomer';

var URL_CUSTOMER_TABLE_HANDLER = 'Handlers/CustomerTableHandler.ashx';

function getOperationURL(baseURL, operation) {

    return baseURL + '?' + OPERATION_PARAMETER + '=' + operation;
}

function sendJsonWithAjax(type, url, data, successFunction, errorFunction) {

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

function postAjaxToCustomerTable (operation, data, successFunction) {

    sendJsonWithAjax(
        'POST',
        getOperationURL(URL_CUSTOMER_TABLE_HANDLER, operation),
        data,
        successFunction,
        function (response) {
            alert('Error: ' + response.statusText);
        });
}

function ajaxAddCustomer(customer, successFunction) {

    postAjaxToCustomerTable(
        OPERATION_ADD_CUSTOMER,
        JSON.stringify(customer),
        successFunction
    );
}

function ajaxDeleteCustomer(id, successFunction) {

    postAjaxToCustomerTable(
        OPERATION_DELETE_CUSTOMER,
        JSON.stringify({ ID: id }),
        successFunction);
}

function ajaxEditCustomer(customer, successFunction) {

    postAjaxToCustomerTable(
        OPERATION_EDIT_CUSTOMER,
        JSON.stringify(customer),
        successFunction);
}

function ajaxGetCustomer(id, successFunction) {

    postAjaxToCustomerTable(
        OPERATION_GET_CUSTOMER,
        JSON.stringify({ ID: id }),
        successFunction);
}