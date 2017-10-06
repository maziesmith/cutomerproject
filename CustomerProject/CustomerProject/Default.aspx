<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function showModal() {
            $('#AddButtonModal').modal();
        }

    </script>

    <br />
    <br />

    <div class="row">
        <div class="col-md-12">
            <button id="addButton" class="btn btn-primary addbutton" onclick="showModal(); return false;">
                <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>Add
            </button>
        </div>

        <div class="col-md-12">
            <asp:Table ID="CustomerTable" CssClass="table table-hover" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Gender</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Number</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Age</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Address</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Edit</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Delete</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>

        <!-- Bootstrap Modal Dialog -->
        <div class="modal fade" id="AddButtonModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">Add Customer</h4>
                            </div>
                            <div class="modal-body">
                                <form class="form-horizontal" method="post" action="Default.aspx.cs">
                                    <div class="form-group row">
                                        <label class="control-label col-md-2" for="name">Name</label>
                                        <div class="col-md-10">
                                            <input class="form-control" name="name" type="text"/>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label col-md-2" for="gender">Gender</label>
                                        <div class="col-md-10">
                                            <input class="form-control" name="gender" type="text" maxlength="1"/>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label col-md-2" for="number">Phone Number</label>
                                        <div class="col-md-10">
                                            <input class="form-control" name="number" type="number"/>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label col-md-2" for="age">Age</label>
                                        <div class="col-md-10">
                                            <input class="form-control" name="age" type="number"/>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="control-label col-md-2" for="address">Address</label>
                                        <div class="col-md-10">
                                            <input class="form-control" name="address"/>
                                        </div>
                                    </div>
                                    <button type="submit" class="btn btn-default">Add</button>
                                </form>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
