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
    </div>

</asp:Content>
