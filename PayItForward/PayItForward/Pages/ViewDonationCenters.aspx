<%@ Page Title="View Centers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDonationCenters.aspx.cs" Inherits="PayItForward.Pages.ViewDonationCenters" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        View all donation centers or a filtered list
    </h1>

    <a href="./DonationCenterProfile.aspx">
        <input type="button" value="DC One"/>
    </a>
    <a href="./DonationCenterProfile.aspx">
        <input type="button" value="DC Two"/>
    </a>
    <a href="./DonationCenterProfile.aspx">
        <input type="button" value="DC Three"/>
    </a>

</asp:Content>