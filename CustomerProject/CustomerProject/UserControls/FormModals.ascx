<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormModals.ascx.cs" Inherits="CustomerProject.User_Controls.FormModals" %>

<script type="text/javascript">
    function addCustomer() {
        var errorMessage = validateCustomer();

        if (errorMessage === undefined) {

            var newCustomer = {
                Name: $('#inputName').val(),
                Age: $('#inputAge').val(),
                Address: $('#inputAddress').val(),
                PhoneNumber: $('#inputNumber').val(),
                Gender: $('input[name=inputGender]:checked').val()
            }

            ajaxAddCustomer(newCustomer,
                function (response) {
                    $('#AddButtonModal').modal('hide');
                    $('#CustomerTable').DataTable().ajax.reload();
                });
        }
        else {
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
</script>


<!-- Bootstrap Modal Dialog -->
<div class="modal fade" id="AddButtonModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <asp:Literal ID="modalTitle" runat="server" /></h4>
                    </div>
                    <div class="modal-body">
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
                                        <input type="radio" name="inputGender" value="M">Male
                                    </label>
                                    <label class="radio-inline">
                                        <input type="radio" name="inputGender" value="F">Female
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
                                <button class="btn btn-primary btnResize" onclick="addCustomer(); return false;">OK</button>
                            </div>
                        </form>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
