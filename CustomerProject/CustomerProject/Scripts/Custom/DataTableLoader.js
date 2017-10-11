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

function deleteTableRow(sender) {

    var idToDelete = $(sender).parent().siblings(':first').html();

    sendAJAX(
        OPERATION_DELETE_CUSTOMER,
        function (response) {
            $(sender).parents('table').DataTable().ajax.reload(); 
        },
        JSON.stringify({ ID: idToDelete }));
}

function editTableRow(sender) {

    var id = $(sender).parent().siblings(':first').html();
}