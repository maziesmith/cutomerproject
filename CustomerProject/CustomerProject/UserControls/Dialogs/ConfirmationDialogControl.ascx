<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfirmationDialogControl.ascx.cs" Inherits="CustomerProject.UserControls.Dialogs.ConfirmationDialogControl" %>

<script>
    function disMiss() {
        $(function () {
            $('#myModal').modal('toggle');
        });
    }
</script>

<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><%=Title %></h4>
                    </div>
                    <div class="modal-body">
                        <%=Message %>
                    </div>
                    <div class="modal-footer">
                        <asp:Button runat="server" ID="CancelButton" data-dismiss="modal" aria-hidden="true" ></asp:Button>
                        <asp:Button ID="OkButton" runat="server" ></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
