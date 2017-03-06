<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="PayItForward.Pages.UserProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        User Login
    </h1>
    <div>
        <p>
            Enter email:
            <br>
            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
            <br>
            Enter password:
            <br>
            <asp:TextBox TextMode="Password" ID="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="LoginB" Text="Login" OnClick="LoginB_Click" runat="server"/>
            <br>
            <asp:Label ID="ErrMsg" ForeColor="red" runat="server"></asp:Label>
            <br />
            <a href="/Pages/CreateUser.aspx">I'm a new user!</a>
        </p>

    </div>

</asp:Content>
