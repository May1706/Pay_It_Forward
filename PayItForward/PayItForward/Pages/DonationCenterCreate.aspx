<%@ Page Title="Pay It Forward - Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationCenterCreate.aspx.cs" Inherits="PayItForward.Pages.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Create an Account</h1>
        <p class="lead">UNDER CONSTRUCTION</p>
        <p>Select the desired account type and complete the form to register</p>
    </div>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <!-- Center Name -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CenterName" CssClass="col-md-2 control-label">Donation Center Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="CenterName" CssClass="form-control"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CenterName"
                    CssClass="text-danger" ErrorMessage="The donation center name field is required." />
            </div>
        </div>

        <!-- Hours -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>

        <!-- Description -->
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>

        <!-- Accepted categories -->

        <!-- Address -->

        <!-- Pickup? -->

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
