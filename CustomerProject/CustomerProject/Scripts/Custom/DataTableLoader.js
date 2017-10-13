function loadDataTable(tableID) {

    $('#' + tableID).DataTable({
        ajax: getOperationURL(URL_CUSTOMER_TABLE_HANDLER, OPERATION_GET_CUSTOMERS),
        paging: true,
        info: true,
        searching: false,
        oLanguage: {
            "sLengthMenu": "Display Records (per page)  _MENU_",
            "sSearch": "Search "
        },
        columns: [
            { title: 'Name', data: 'Name', orderable: true },
            { title: 'Gender', data: 'Gender', orderable: true },
            { title: 'Number', data: 'PhoneNumber', orderable: true },
            { title: 'Age', data: 'Age', orderable: true },
            { title: 'Address', data: 'Address', orderable: true },
            {
                title: 'Edit',
                orderable: false,
                render: function (data, type, row, meta) {
                    return '<button class="btn btn-sm" onclick="onEditClicked(\'' + row.ID + '\'); return false;">' +
                        '<span class="glyphicon glyphicon-pencil spinning"></span></button>';
                }
            },
            {
                title: 'Delete',
                orderable: false,
                render: function (data, type, row, meta) {
                    return '<button class="btn btn-sm" onclick="onDeleteClicked(\'' + row.Name + '\', \'' + row.ID + '\', \'' + meta.settings.sTableId + '\'); return false;">' +
                        '<span class="glyphicon glyphicon-trash spinning"></span></button>';
                }
            }
        ]
    });
}

function onDeleteClicked(cName, cID, tableID) {

    showDeleteDialog(cName,
        function () {
            ajaxDeleteCustomer(
                cID,
                function () {
                    $('#' + tableID).DataTable().ajax.reload();
                }
            );
        }
    );
}

function onEditClicked(cID) {

    ajaxGetCustomer(cID,
        function (response) {
            if (response !== null && response !== undefined) {
                openFormModal('Edit Customer');
                populateFormModalFields(response);
            }
        });
}
}
function searchCustomers(searchString, tableID) {
    
}