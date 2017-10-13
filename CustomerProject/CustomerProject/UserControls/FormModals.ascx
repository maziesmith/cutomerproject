<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormModals.ascx.cs" Inherits="CustomerProject.User_Controls.FormModals" %>

<script type="text/javascript">

    function openFormModal(title) {

        $('#FormModal').modal();

        if (title !== undefined) {
            $('#FormModalTitle').text(title);
        }
    }

    function addOrEditCustomer() {

        var errorMessage = validateCustomer();

        if (errorMessage === undefined) {

            var newCustomer = {
                Name: $('#inputName').val(),
                Age: $('#inputAge').val(),
                Address: $('#inputAddress').val(),
                PhoneNumber: $('#inputNumber').val(),
                Gender: $('input[name=inputGender]:checked').val()
            }

            var customerID = $('#editID').text();

            if (customerID !== '') { // if editing...

                newCustomer['ID'] = customerID;

                ajaxEditCustomer(newCustomer,
                    function (response) {
                        $('#FormModal').modal('hide');
                        $('#CustomerTable').DataTable().ajax.reload();
                    });

            } else {

                ajaxAddCustomer(newCustomer,
                    function (response) {
                        $('#FormModal').modal('hide');
                        $('#CustomerTable').DataTable().ajax.reload();
                    });
            }
        } else {
            alert(errorMessage);
        }
    }

    function validateCustomer() {

        var errorMessage;

        if ($('#inputName').val() === '') {
            errorMessage = 'Error: Name is empty';
        } else if ($('input[name=inputGender]:checked').val() === '') {
            errorMessage = 'Error: Gender is empty';
        } else if ($('#inputNumber').val() === '') {
            errorMessage = 'Error: Number is empty';
        } else if ($('#inputAge').val() === '') {
            errorMessage = 'Error: Age is empty';
        } else if ($('#inputAddress').val() === '') {
            errorMessage = 'Error: Address is empty';
        }
        return errorMessage;
    }

    function populateFormModalFields(customer) {

        if (customer.ID !== undefined) {
            $('#editID').text(customer.ID);
        }

        $('#inputName').val(customer.Name);
        $('#inputNumber').val(customer.PhoneNumber);
        $('#inputAge').val(customer.Age);
        $('#inputAddress').val(customer.Address);

        customer.Gender === 'M' ? $("#inputGenderMale").prop("checked", true) : $("#inputGenderFemale").prop("checked", true)
    }
</script>


<!-- Bootstrap Modal Dialog -->
<div class="modal fade" id="FormModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="FormModalTitle">
                            <asp:Literal ID="modalTitle" runat="server" />
                        </h4>
                    </div>
                    <div class="modal-body">
                        <p style="display:none" id="editID"></p>
                        <form id="addCustomerForm" class="form-horizontal" method="post" action="Default.aspx.cs">
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="name">Name</label>
                                <div class="col-md-10">
                                    <input class="form-control" id="inputName" type="text" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="inputGender">Gender</label>
                                <div class="col-md-10">
                                    <label class="radio-inline">
                                        <input type="radio" id="inputGenderMale" name="inputGender" value="M">Male
                                    </label>
                                    <label class="radio-inline">
                                        <input type="radio" id="inputGenderFemale" name="inputGender" value="F">Female
                                    </label>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="number">Phone Number</label>
                                <div class="col-md-10">
                                    <input class="form-control" id="inputNumber" type="number" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="age">Age</label>
                                <div class="col-md-10">
                                    <input class="form-control" id="inputAge" type="number" min="0" max="120" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="address">Address</label>
                                <div class="col-md-10">
                                    <input class="form-control" id="inputAddress" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-default" onclick="addOrEditCustomer(); return false;">Submit Entry</button>
                            </div>
                        </form>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
