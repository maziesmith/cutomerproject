<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormModals.ascx.cs" Inherits="CustomerProject.User_Controls.FormModals" %>

<script type="text/javascript">

    function showBlankModal() {
        $('#ConfirmationDialog').modal();
    }


    function showDeleteDialog(sender) {
        initFields("Delete User", "Are you sure to delete this user: <b>" + getName(sender) + "</b>", "Cancel");
        document.getElementById("modal-okbutton").innerHTML = "Remove";
        document.getElementById("modal-okbutton").onclick = function () { deleteUser(sender); return false;};
    }

    function deleteUser(sender) {
        $('#ConfirmationDialog').modal('toggle');
        //function of DataTableLoader.js
        editTableRow(sender);
    }

    function initFields(title, mssg, cancelbutton) {
        $('#AddButtonModal').modal();
        document.getElementById("modal-title").innerHTML = title;
        document.getElementById("modal-message").innerHTML = mssg;
        document.getElementById("modal-cancelbutton").innerHTML = cancelbutton;
       
    }

    function getName(sender) {
        return $(sender).parent().siblings(':nth-child(2)').html();
   
    }

</script>

 
<script type="text/javascript">
    function addCustomer() {
        sendAJAX(
            OPERATION_ADD_CUSTOMER,
            function (response) {
                debugger;
                $('#AddButtonModal').modal('toggle');
                $('#CustomerTable').DataTable().ajax.reload();
            },
            JSON.stringify({
                Name: $('#inputName').val(),
                Age: $('#inputAge').val(),
                Address: $('#inputAddress').val(),
                PhoneNumber: $('#inputNumber').val(),
                Gender: $('#inputGender').val()
            })
        );
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
                        <h4 class="modal-title"><asp:Literal id="modalTitle" runat=server /></h4>
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
                                <label class="control-label col-md-2" for="gender">Gender</label>
                                <div class="col-md-10">
                                    <input class="form-control" id="inputGender" type="text" maxlength="1" />
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
                                    <input class="form-control" id="inputAge" type="number" min="0" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="address">Address</label>
                                <div class="col-md-10">
                                    <input class="form-control" id="inputAddress" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-default" onclick="addCustomer()">Submit Entry</button>
                            </div>
                        </form>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
