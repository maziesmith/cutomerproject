<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormModals.ascx.cs" Inherits="CustomerProject.User_Controls.FormModals" %>

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
                        <form class="form-horizontal" method="post" action="Default.aspx.cs">
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="name">Name</label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" id="nameInput" class="form-control" name="name" type="text" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="gender">Gender</label>
                                <div class="col-md-10">
                                    <input class="form-control" name="gender" type="text" maxlength="1" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="number">Phone Number</label>
                                <div class="col-md-10">
                                    <input class="form-control" name="number" type="number" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="age">Age</label>
                                <div class="col-md-10">
                                    <input class="form-control" name="age" type="number" />
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="control-label col-md-2" for="address">Address</label>
                                <div class="col-md-10">
                                    <input class="form-control" name="address" />
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span>Submit Entry</button>
                            </div>
                        </form>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
