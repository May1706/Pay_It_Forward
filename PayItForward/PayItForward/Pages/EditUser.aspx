<%@ Page Title="Edit User Info" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="PayItForward.Pages.EditUser" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="loginContent">
            <div class="centerText">
                <h1>Edit User Info</h1>
            </div>

            <br />

            <p>Enter email:</p>
            <asp:Textbox id="Email" class="loginField" runat="server" CausesValidation="True" MaxLength="30" TextMode="Email" />
            <asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server"
                                        ControlToValidate="Email"
                                        ForeColor="red" Display="Static" ErrorMessage="Required" /> 
        
            <br />

            <p>Enter password:</p>
            <asp:Textbox id="Password" class="loginField" TextMode="Password" runat="server" />
            <asp:Requiredfieldvalidator id="passwordrequiredvalidator" runat="server"
                                        controltovalidate="password" forecolor="red"
                                        display="static" errormessage="Required" />

            <br />

            <br />
            <p>Optional Password Change</p>
            <br />

            <p>New password:</p>
            <asp:Textbox id="NewPassword" class="loginField" TextMode="Password" runat="server" />
           
        
            <br />

            <p>Re-enter new password:</p>
            <asp:Textbox id="RePassword" class="loginField" TextMode="Password" runat="server" />
            
        
            <br />
            <br />

            <asp:Button ID="SaveButton" class="actionButton" Text="Save" OnClick="SaveButton_Click" runat="server"/>
    
            <br />
            <br />

            <div class="centerText">
                <asp:Label ID="ErrorMsg" ForeColor="red" runat="server"></asp:Label>

                <br />
                <br />

     
            </div>           
        </div>
    </div>

    <style>
        .row {
            position: relative;
        }

        .loginContent {
            width: 275px;
            margin-left: auto;
            margin-right: auto;
            display: block;
        }

        .loginField {
            width: 100%;
        }

        .centerText {
            text-align: center;
        }

        .actionButton {
            width: 100%;
            height: 30px;
            background-color: #50B948;
            border: none;
            color: rgba(255, 255, 255, 1);
            font-size: 20px;
        }

        .actionButton:hover {
            color: #333;
            background-color: rgba(132, 201, 127, 1);
        }
    </style>
</asp:Content>
