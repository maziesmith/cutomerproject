<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfirmationDialog.ascx.cs" Inherits="CustomerProject.UserControls.Dialogs.ConfirmationDialog" %>



<script type="text/javascript">

    function showModal() {
        $('#ConfirmationDialog').modal();
    }

</script>

<div class="modal fade" id="ConfirmationDialog" role="dialog" aria-labelledby="myModalLabel" aria-hidden="false">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">
                            <%= Titel%></h4>
                    </div>
                    <div class="modal-body">
                        <form class="form-horizontal" method="post" action="Default.aspx.cs">
                            <div class="form-group row">

                                <div class="col-md-12">
                                    <h5> <%= Message%></h5>
                                </div>
                            </div>

                            <div class="modal-footer">
                                <button type="button" data-dismiss="modal" class="btn btn-danger"><%= CancelButton%></button>
                                <button type="submit" class="btn btn-primary"><%= OkButton%></button>

                            </div>
                        </form>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
