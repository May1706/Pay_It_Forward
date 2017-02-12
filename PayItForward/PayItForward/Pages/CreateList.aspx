<%@ Page Title="Create List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateList.aspx.cs" Inherits="PayItForward.Pages.CreateList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>
        What are you looking to donate?
    </h1>

    <br />

    <div class="shoppingcart">
        <ul class="sortable">
            <li draggable="true" class="ditem">Item 1
            <li draggable="true" class="ditem">Item 2
            <li draggable="true" class="ditem">Item 3
            <li draggable="true" class="ditem">Item 4
        </ul>
    </div>

    <div class="shoppingcart">
        <select class="categoryselect">
            <option>&lt;Category&gt;</option>
            <option>Category 1</option>
            <option>Category 2</option>
            <option>Category 3</option>
            <option>Category 4</option>
        </select>

        <ul class="sortable">
            <li draggable="true" class="ditem">Item 5
            <li draggable="true" class="ditem">Item 6
            <li draggable="true" class="ditem">Item 7
            <li draggable="true" class="ditem">Item 8
            <li draggable="true" class="ditem">Item 9
            <li draggable="true" class="ditem">Item 10
            <li draggable="true" class="ditem">Item 11
            <li draggable="true" class="ditem">Item 12
            <li draggable="true" class="ditem">Item 13
            <li draggable="true" class="ditem">Item 14
            <li draggable="true" class="ditem">Item 15
            <li draggable="true" class="ditem">Item 16
            <li draggable="true" class="ditem">Item 17
            <li draggable="true" class="ditem">Item 18
        </ul>
    </div>

    <br />

    <script src="/Scripts/jquery.sortable.js"></script>
    <script>
        $('.sortable').sortable({
               connectWith: '.connected'
        });
    </script>

    <style>
        .shoppingcart {
            display: inline-block;
        }

        .categoryselect {
            width: 300px;
            margin: 1px;
        }

        .sortable {
            border: 2px solid #50B948;
            list-style-type: square;
            overflow: hidden;
            overflow-y: scroll;
            height: 300px;
            width: 300px;
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
