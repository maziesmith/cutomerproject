<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerProject._Default" %>

<%@ Register TagPrefix="uc" TagName="FormModals" Src="~/User_Controls/FormModals.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function openAddModal() {
            $("#AddButtonModal").modal();
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
                            OnClick="btnAdd_Click"  >
                    <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>  Add Customer
                        </asp:LinkButton>
                    </div>
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
            </div>

            <uc:FormModals ID="FormModals"
                runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
