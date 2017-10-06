<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomerProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <br />


    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <asp:LinkButton runat="server" CssClass="btn btn-primary addbutton" data-toggle="modal" data-target="#addModal">
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



    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Modal -->
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label><br />
            <div class="modal fade" id="addModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Add New Customer</h4>
                        </div>
                        <div class="modal-body">
                            <asp:TextBox ID="TBName" runat="server" placeholder="Name" class="form-control"></asp:TextBox><br />
                            <asp:DropDownList class="form-control" ID="DDLGender" runat="server">
                                <asp:ListItem Enabled="true" Text="Gender" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Male" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Female" Value="1"></asp:ListItem>
                            </asp:DropDownList><br />
                            <asp:TextBox ID="TBNumber" type="tel" runat="server" placeholder="Number" class="form-control"></asp:TextBox><br />
                            <asp:TextBox ID="TBAge" min="0" max="150" type="number" runat="server" placeholder="Age" class="form-control"></asp:TextBox><br />
                            <asp:TextBox ID="TBAddress" runat="server" placeholder="Address" class="form-control"></asp:TextBox><br />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                Close</button>
                            <asp:Button Text="Save" class="btn btn-primary"  OnClick ="On_Add_Button_Clicked" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
