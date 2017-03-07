<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="PayItForward.Pages.AdminProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        Admin Profile Page / Action Center
    </h1>

    <br />
    <asp:Button ID="Generate" runat="server" Text="Generate Requests" style="width:auto" onclick="Generate_Click" />
    <asp:Button ID="Remove" runat="server" Text="Remove Requests" style="width:auto" onclick="Remove_Click" />
    
    <hr />

    <asp:GridView ID="requestsGridView" SkinID="Professional" runat="server"></asp:GridView>

    <hr />
    <asp:Label ID="resultLabel" runat="server"></asp:Label>


</asp:Content>
