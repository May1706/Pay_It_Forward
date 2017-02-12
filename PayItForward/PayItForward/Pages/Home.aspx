<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PayItForward._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Pay It Forward</h1>
        <p class="lead">UNDER CONSTRUCTION</p>
        <p>Home page with links to all other pages; for dev purposes</p>
        <p>This will probably not be in the real site</p>
    </div>

    <div>
        <a href="/Pages/CreateList.aspx">Create List</a><br />
        <a href="/Pages/ViewDonationCenters.aspx">View Donation Centers</a><br />
        <a href="/Pages/DonationCenterProfile.aspx">Donation Center Profile</a><br />
        <a href="/Pages/DonationCenterEdit.aspx">Edit Donation Center</a><br /> <!-- Probably should make this appear only if user has access to center -->
        <a href="/Pages/UserProfile.aspx">User Profile</a><br />
        <a href="/Pages/AdminProfile.aspx">Admin Page</a><br />
        <a href="/Pages/DonationCenterCreate.aspx">Create a Donation Center</a><br />
    </div>

</asp:Content>
