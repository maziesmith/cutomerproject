<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerProject._Default" %>

<%@ Register TagPrefix="uc" TagName="ConfirmDialog" Src="~/UserControls/Dialogs/ConfirmationDialog.ascx" %>
<%@ Register TagPrefix="uc" TagName="FormModals" Src="~/UserControls/FormModals.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="Scripts/Custom/AjaxCalls.js"></script>
    <script type="text/javascript" src="Scripts/Custom/DataTableLoader.js"></script>
    <script type="text/javascript">
        function reloadDataTable() {
            $('#CustomerTable').DataTable().ajax.reload();
        }
    </script>
    <br />
    <br />
    <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <div class="btn-group">
                        <asp:LinkButton ID="addButton" class="btn btn-primary addbutton" runat="server"
                            OnClick="btnAdd_Click">
                    <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>  Add Customer
                        </asp:LinkButton>
                    </div>
                </div>
                <br />
                <div class="col-md-12">
                    <div class="input-group searchInput">
                        <input type="text" class="form-control" placeholder="Search" name="searchInput" id="searchInput">
                        <div class="input-group-btn">
                            <button class="btn btn-default" onclick="reloadDataTable(); return false;"><i class="glyphicon glyphicon-search"></i></button>
                        </div>
                    </div>
                    <table id="CustomerTable" class="table table-condensed table-striped table-hover" cellspacing="0" width="100%"></table>
                </div>
            </div>

            <uc:ConfirmDialog runat="server" />
            <uc:FormModals ID="FormModals"
                runat="server" />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
