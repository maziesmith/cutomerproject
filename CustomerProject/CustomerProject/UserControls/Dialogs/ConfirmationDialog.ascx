<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfirmationDialog.ascx.cs" Inherits="CustomerProject.UserControls.Dialogs.ConfirmationDialog" %>

<script type="text/javascript">

    function showBlankModal() {
        $('#ConfirmationDialog').modal();
    }

    function showDeleteDialog(name, okFunction) {
        initFields("Delete User", "Are you sure you want to delete this user: <b>" + name + "</b>", "Cancel");
        document.getElementById("modal-okbutton").innerHTML = "Remove";
        document.getElementById("modal-okbutton").onclick = function () { hideConfirmationDialog(); okFunction(); return false; };
    }

    function hideConfirmationDialog() {
        $('#ConfirmationDialog').modal('toggle');
    }

    function showInfoDialog(title, mssg, cancelbutton) {
        initFields(title, mssg, cancelbutton);
        document.getElementById("modal-okbutton").style = "display:none;";
    }

    function initFields(title, mssg, cancelbutton) {
        $('#ConfirmationDialog').modal();
        document.getElementById("modal-title").innerHTML = title;
        document.getElementById("modal-message").innerHTML = mssg;
        document.getElementById("modal-cancelbutton").innerHTML = cancelbutton;
    }

</script>

<div class="modal fade" id="ConfirmationDialog" role="dialog" aria-labelledby="myModalLabel" aria-hidden="false">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="modal-title">
                            <%= Titel%></h4>
                    </div>
                    <div class="modal-body">
                        <form class="form-horizontal" method="post" action="Default.aspx.cs">
                            <div class="form-group row">

                                <div class="col-md-12">
                                    <h5 id="modal-message"> <%= Message%></h5>
                                </div>
                            </div>

                            <div class="modal-footer" >
                                <button type="button" data-dismiss="modal" class="btn btn-danger btnResize" id="modal-cancelbutton" ><%= CancelButton%></button>
                                <button class="btn btn-primary btnResize" onclick="return false;" id="modal-okbutton" ><%= OkButton%></button>
                            </div>
                        </form>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
