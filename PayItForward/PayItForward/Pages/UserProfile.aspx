<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="PayItForward.Pages.UserProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div class="userContent">
        <asp:Label id="userName" Text="[First Last]" runat="server" />

        <br />
        <br />

        <asp:Label Text="Donation Centers:" runat="server" />
        <div id="userCenters" runat="server">

        </div>

        <br />
        <br />

        <asp:Label Text="Donation History:" runat="server" />
        <div id="userHistory" runat="server">

        </div>

        <br />
        <br />

        <asp:Button id="createCenter" class="actionButton" Text="Register a Donation Center" OnClick="createCenter_Click" runat="server"/>
        <asp:Button id="logoutButton" class="actionButton" Text="Logout" OnClick="logoutButton_Click" runat="server"/>
    </div>

    <style>
        .actionButton {
            width: 300px;
            height: 50px;
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
