<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PayItForward._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Pay It Forward</h1>
        <p>Welcome to Pay It Forward, a site that enables a simple donation process for any potential donor. Create a list of items to see any donation center that accepts those items, or see all available centers by clicking one of the buttons below.</p>
    </div>

    <div class="actionCenter">
        <asp:Button id="createListButton"  class="actionButton actionButtonLeft"  Text="Create a Donation List"    OnClick="createListButton_Click"  runat="server"/>
        <asp:Button id="viewCentersButton" class="actionButton actionButtonRight" Text="View All Donation Centers" OnClick="viewCentersButton_Click" runat="server"/>
    </div>

    <style>
        .actionCenter {
            position: relative;
            height: 75px;
            width: 100%;
        }

        .actionButton {
            position: absolute;
            width: 49%;
            height: 100%;
            display: inline-block;
            background-color: #50B948;
            border: none;
            color: rgba(255, 255, 255, 1);
            font-size: 20px;
        }

        .actionButton:hover {
            color: #333;
            background-color: rgba(132, 201, 127, 1);
        }

        .actionButtonLeft {
            left: 0px;
        }

        .actionButtonRight {
            right: 0px;
        }
    </style>

</asp:Content>
