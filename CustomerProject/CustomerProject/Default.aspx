<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerProject._Default" %>

<%@ Register TagPrefix="uc" TagName="FormModals" Src="~/User_Controls/FormModals.ascx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="Scripts/Custom/DataTableLoader.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
           // loadDataTable('CustomerTable');
        })

        function showModal() {
            $('#AddButtonModal').modal();
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
            <table id="CustomerTable" class="table table-hover" />
        </div>
    </div>

            <uc:FormModals ID="FormModals"
                runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
