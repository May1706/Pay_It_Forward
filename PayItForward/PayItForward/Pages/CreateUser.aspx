<%@ Page Title="CreateUser" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="PayItForward.Pages.CreateUser" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        User Create Login
    </h1>
    <div>
            Enter email: <br />
            <asp:Textbox id="Email" runat="server" CausesValidation="True" MaxLength="30" TextMode="Email" />
            <asp:RequiredFieldValidator id="UsernameRequiredValidator" runat="server"
                                      ControlToValidate="Email"
                                      ForeColor="red" Display="Static" ErrorMessage="Required" /> 
            <br />
            Enter password: <br />
            <asp:Textbox id="Password" TextMode="Password" runat="server" />
            <asp:requiredfieldvalidator id="passwordrequiredvalidator" runat="server"
                                      controltovalidate="password" forecolor="red"
                                      display="static" errormessage="Required" />
         <br />    
        Re-enter password: <br />
            <asp:Textbox id="RePassword" TextMode="Password" runat="server" />
            <asp:RequiredFieldValidator id="RePasswordRequiredValidator" runat="server"
                                      ControlToValidate="RePassword" ForeColor="red"
                                      Display="Static" ErrorMessage="Required" />
            <br />
            <asp:Button ID="LoginButton" Text="Register Me!" OnClick="LoginButton_Click" runat="server"/>
            <br>
            <asp:Label ID="ErrorMsg" ForeColor="red" runat="server"></asp:Label>
           

    </div>

</asp:Content>
