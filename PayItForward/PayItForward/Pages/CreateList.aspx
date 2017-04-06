<%@ Page Title="Create List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateList.aspx.cs" Inherits="PayItForward.Pages.CreateList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>What are you looking to donate?</h1>

    <h3>Select the category of your item and drag it into your donation cart.
        After everything you wish to donate is in your cart, click the button below to find the best donation centers based on your items.</h3>
    
    <h4>Currently only supports categories and not specific items</h4>

    <div id="test1" runat="server">

    </div>

    <div id="test2" runat="server">

    </div>

    <br />

    <div class="listbox">
        <h2>Donation Cart</h2>
        <div id="cart" class="sortable" runat="server"/>
    </div>

    <div class="listbox">
        <h2>Donation Items</h2>

        <!--
        <asp:DropDownList id="categoryList" class="categoryselect" OnSelectedIndexChanged="categoryList_SelectedIndexChanged" AutoPostBack="true" runat="server"/>
        -->

        <div id="availableItems" class="sortable" clientmode="Static" runat="server"/>
    </div>

    <br />

    <asp:Button id="submitButton" Text="Find Accepting Donation Centers" OnClick="submitButton_Click" runat="server" />

    <script src="/Scripts/Sortable.js"></script>
    <script>
        var cart = document.getElementById("<%=cart.ClientID%>");
        Sortable.create(cart, {
            group: { name: 'donation', pull: true, put: true },
            animation: 150,
            ghostClass: 'itemPreview',
            filter: '.js-remove',
            onFilter: function (evt) {
                evt.item.parentNode.removeChild(evt.item);
            }
        });

        var availableItems = document.getElementById("<%=availableItems.ClientID%>");
        Sortable.create(availableItems, {
            group: { name: 'donation', pull: 'clone', put: false },
            animation: 150,
            ghostClass: 'itemPreview'
        });
    </script>

    <style>
        .itemPreview{
            opacity: 0.5;
        }

        .listbox {
            display: inline-block;
        }

        .categoryselect {
            width: 99%;
            margin: 1px;
        }

        .sortable {
            border: 2px solid #50B948;
            overflow: hidden;
            overflow-y: auto;
            height: 300px;
            width: 300px;
            padding: 0;
        }

        .ditem {
            border: 1px solid #50B948;
            margin: 5px;
            padding: 5px;
            cursor: pointer;
            position: relative;
        }
        
        #<%=cart.ClientID%> .js-remove:hover {
            color: red !important;
        }

        #<%=cart.ClientID%> .ditem:hover .js-remove {
            opacity: 1;
            color: black;
        }

        .js-remove {
            transition: opacity .2s;
            opacity: 0;
            display: block;
            top: 5px;
            right: 10px;
            position: absolute;
            font-style: normal;
        }
    </style>

</asp:Content>
