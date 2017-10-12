var OPERATION_PARAMETER = 'operation';

var OPERATION_GET_CUSTOMERS = 'GetCustomers';
var OPERATION_DELETE_CUSTOMER = 'DeleteCustomer';
var OPERATION_ADD_CUSTOMER = 'AddCustomer';
var OPERATION_SEARCH_CUSTOMER = 'SearchCustomers';

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

function ajaxAddCustomer(customer, successFunction) {

    sendCustomerTableAJAX(
        OPERATION_ADD_CUSTOMER,
        JSON.stringify(customer),
        successFunction
    );
}

function ajaxDeleteCustomer(id, successFunction) {

    sendCustomerTableAJAX(
        OPERATION_DELETE_CUSTOMER,
        JSON.stringify({ ID: id }),
        successFunction
    );
}

function ajaxEditCustomer(customer, successFunction) {

}

function ajaxSearchCustomers(searchString, successFunction) {
    sendCustomerTableAJAX(
        OPERATION_SEARCH_CUSTOMER,
        JSON.stringify(searchString),
        successFunction
    );
}