<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="PayItForward.Pages.AdminProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        Admin Profile Page / Action Center
    </h1>

    <p>Type: </p>
    <asp:TextBox ID="TB1" input="text" runat="server" style="width:224px"/>
    <br />    



    <br />
    <asp:Button ID="Button2" runat="server" Text="Enter" style="width:85px" onclick="Button2_Click" />
    <hr />


</asp:Content>
