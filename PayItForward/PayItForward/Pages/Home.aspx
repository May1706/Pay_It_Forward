<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="PayItForward._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Pay It Forward</h1>
        <p class="lead">UNDER CONSTRUCTION</p>
        <p>Home page with links to all other pages</p>
    </div>

    <div>
        <a href="./CreateList.aspx">Create List</a><br />
        <a href="./ViewDonationCenters.aspx">View Donation Centers</a><br />
        <a href="./DonationCenterProfile.aspx">Donation Center Profile</a><br />
        <a href="./DonationCenterEdit.aspx">Create Donation Center</a><br />
        <a href="./UserProfile.aspx">User Profile</a><br />
        <a href="./AdminProfile.aspx">Admin Page</a><br />
    </div>

</asp:Content>
