<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="PayItForward.Pages.AdminProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        Admin Profile Page / Action Center
    </h1>

    <br />
    <asp:Button ID="Generate" runat="server" Text="Generate Requests" style="width:auto" onclick="Generate_Click" />
    <asp:Button ID="Remove" runat="server" Text="Remove Requests" style="width:auto" onclick="Remove_Click" />
    <asp:Button ID="Display" runat="server" Text="Display Requests" style="width:auto" onclick="Display_Click" />
    <hr />


</asp:Content>
