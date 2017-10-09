<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="Scripts/Custom/DataTableLoader.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            loadDataTable('CustomerTable');
        })

        function showModal() {
            $('#AddButtonModal').modal();
        }

    </script>

    <br />
    <br />

    <div class="row">
        <div class="col-md-12">
            <button id="addButton" class="btn btn-primary addbutton" onclick="showModal(); return false;">
                <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>  Add Customer
            </button>
        </div>

        <div class="col-md-12">
            <table id="CustomerTable" class="table table-hover" />
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
                                    <div class="modal-footer">
                                        <button type="submit" class="btn btn-default"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Submit Entry</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

</asp:Content>
