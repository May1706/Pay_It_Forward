<%@ Page Title="View Centers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDonationCenters.aspx.cs" Inherits="PayItForward.Pages.ViewDonationCenters" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        Donation Centers
    </h1>

    <div id="centerDisplay" runat="server"/>

    <style>
        .dcBox {
            position: relative;
            width: 100%;
            border: 2px solid #50B948;
            margin: 10px;
            display: inline-block;
        }

        .dcStuff {
            display: inline-block;
            margin: 5px;
            max-width: 65%
        }

        .dcThumb {
            max-width: 30%;
            max-height: 200px;
            overflow: hidden;
            object-fit: cover;
            vertical-align: top;
            cursor: pointer;
        }
    </style>
</asp:Content>