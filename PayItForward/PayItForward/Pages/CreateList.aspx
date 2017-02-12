<%@ Page Title="Create List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateList.aspx.cs" Inherits="PayItForward.Pages.CreateList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        What are you looking to donate?
    </h1>

    <ul class="sortable">
        <li draggable="true" class="ditem">Item 1
        <li draggable="true" class="ditem">Item 2
        <li draggable="true" class="ditem">Item 3
        <li draggable="true" class="ditem">Item 4
    </ul>

    <ul class="sortable">
        <li draggable="true" class="ditem">Item 5
        <li draggable="true" class="ditem">Item 6
        <li draggable="true" class="ditem">Item 7
        <li draggable="true" class="ditem">Item 8
    </ul>
    
    <br />

    <script src="/Scripts/jquery.sortable.js"></script>
    <script>
        $('.sortable').sortable({
               connectWith: '.connected'
        });
    </script>

    <style>
        .sortable {
            border: 2px solid #50B948;
            display: inline-block;
            list-style: none;
            overflow: hidden;
            overflow-y: scroll;
            height: 200px;
            width: 200px;
            padding: 0;
        }

        .ditem {
            border: 1px solid #50B948;
            margin: 5px;
            padding: 5px;
        }
    </style>

    <a href="/Pages/ViewDonationCenters.aspx">
        <input type="button" value="Done!"/>
    </a>

</asp:Content>
