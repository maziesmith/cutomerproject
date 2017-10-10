<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfirmationDialog.ascx.cs" Inherits="CustomerProject.UserControls.Dialogs.ConfirmationDialog" %>



<script type="text/javascript">

    function showBlankModal() {
        $('#ConfirmationDialog').modal();
    }


    function showDeleteDialog(sender) {
        initFields("Delete User", "Are you sure to delete this user: <b>" + getName(sender) + "</b>", "Cancel");
        document.getElementById("modal-okbutton").innerHTML = "Remove this guy";
        document.getElementById("modal-okbutton").onclick = function () { deleteUser(sender); return false;};
    }

    function deleteUser(sender) {
        $('#ConfirmationDialog').modal('toggle');
        //function of DataTableLoader.js
        deleteTableRow(sender);
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

    function getName(sender) {
        return $(sender).parent().siblings(':nth-child(2)').html();
   
    }

   // function getID(sender) {
   //    return $(sender).parent().siblings(':first').html();
   // }



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
                                <button type="button" data-dismiss="modal" class="btn btn-danger" id="modal-cancelbutton" ><%= CancelButton%></button>
                                <button class="btn btn-primary" onclick="alert('BAM');return false" id="modal-okbutton" ><%= OkButton%></button>

                            </div>
                        </form>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
