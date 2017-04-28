<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PayItForward.Pages.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="loginContent">
            <div class="centerText">
                <h1>Pay It Forward</h1>
            </div>
            <br />
            <p>To save your donation history or register for a new donation center, please log in or <a href="/Pages/CreateUser.aspx">create an account</a>!</p>
            <br />

            <p>Email:</p>
            <asp:TextBox ID="Email" class="loginField" runat="server"></asp:TextBox>

            <br />
            <br />

            <p>Password:</p>
            <asp:TextBox TextMode="Password" class="loginField" ID="Password" runat="server"></asp:TextBox>

            <br />
            <br />

            <asp:Button ID="LoginB" class="actionButton" Text="Login" OnClick="LoginB_Click" runat="server"/>

            <br />
            <br />

            <div class="centerText">
                <asp:Label ID="ErrMsg" ForeColor="red" runat="server"/>

                <br />
                <br />
                
                <a href="/Pages/CreateUser.aspx">I'm a new user!</a>
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
