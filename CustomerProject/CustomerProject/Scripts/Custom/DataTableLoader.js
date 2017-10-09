function loadDataTable(tableID) {

    $.ajax({
        type: "GET",
        url: "Handlers/CustomerTableHandler.ashx?operation=GetCustomers",
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            setUpDataTable(tableID, response);
        },
        error: function (response) {
            alert(response);
        }
    });
}

function setUpDataTable(tableID, dataSource) {

    $('#' + tableID).DataTable({
        data: dataSource,
        columns: [
            { title: 'Name', data: 'Name' },
            { title: 'Gender', data: 'Gender' },
            { title: 'Number', data: 'PhoneNumber' },
            { title: 'Age', data: 'Age' },
            { title: 'Address', data: 'Address' },
            { title: 'Edit', data: null, defaultContent: '<button class="btn btn-sm"><span class="glyphicon glyphicon-pencil spinning"></span></button>' },
            { title: 'Delete', data: null, defaultContent: '<button class="btn btn-sm"><span class="glyphicon glyphicon-trash spinning"></span></button>' }
        ]
    });
}