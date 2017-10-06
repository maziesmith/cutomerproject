<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />


    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:LinkButton runat="server" CssClass="btn btn-primary addbutton" OnClick="On_Add_Button_Clicked">
        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>  Add
                </asp:LinkButton>
            </div>
            <asp:Label runat="server" ID="label"></asp:Label>
            <div class="col-md-12">
                <asp:Table ID="Table1" CssClass="table table-hover" runat="server">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Gender</asp:TableHeaderCell> 
                        <asp:TableHeaderCell>Number</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Age</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Address</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
</asp:Content>
