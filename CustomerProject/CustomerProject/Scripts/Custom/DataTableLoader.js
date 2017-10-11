function loadDataTable(tableID) {

    $('#' + tableID).DataTable({
        ajax: baseURL + OPERATION_GET_CUSTOMERS,
        "paging": true,
        "info": true,
        "searching": false,
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
            { title: 'Edit', data: null, defaultContent: '<button class="btn btn-sm btn-primary" onclick="editTableRow(this); return false;"><span class="glyphicon glyphicon-pencil spinning"></span></button>', orderable: false},
            { title: 'Delete', data: null, defaultContent: '<button class="btn btn-sm btn-primary" onclick="showDeleteDialog(this); return false;"><span class="glyphicon glyphicon-trash spinning"></span></button>', orderable: false}
            // delete it without confirmation  { title: 'Delete', data: null, defaultContent: '<button class="btn btn-sm" onclick="deleteTableRow(this); return false;"><span class="glyphicon glyphicon-trash spinning"></span></button>' }

        ]
    });
}

function deleteTableRow(sender) {

    var idToDelete = $(sender).parent().siblings(':first').html();

    sendAJAX(
        OPERATION_DELETE_CUSTOMER,
        JSON.stringify({ ID: idToDelete }),
        function (response) {
            $(sender).parents('table').DataTable().ajax.reload();
        },
        function (response) {
            alert('Error: ' + response.statusText);
        });
}

function editTableRow(sender) {

    var idToEdit = $(sender).parent().siblings(':first').html();

    sendAJAX(
        OPERATION_EDIT_CUSTOMER,
        JSON.stringify({ id: idToEdit }),
        function (response) {
            $(sender).parents('table').DataTable().ajax.reload();
        },
        function (response) {
            alert('Error: ' + response.statusText);
        });
}