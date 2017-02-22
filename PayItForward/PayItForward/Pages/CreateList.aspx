<%@ Page Title="Create List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateList.aspx.cs" Inherits="PayItForward.Pages.CreateList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>What are you looking to donate?</h1>

    <h3>Select the category of your item and drag it into your donation cart.
        After everything you wish to donate is in your cart, click the button below to find the best donation centers based on your items.</h3>

    <br />

    <div class="listbox">
        <h2>Donation Cart</h2>
        <div id="cart" class="sortable">

        </div>
    </div>

    <div class="listbox">
        <h2>Donation Items</h2>

        <div id="availableItems" class="sortable">
            <select class="categoryselect">
                <option>&lt;Category&gt;</option>
                <option>Category 1</option>
                <option>Category 2</option>
                <option>Category 3</option>
                <option>Category 4</option>
            </select>
            <div class="ditem">Item 1<i class="js-remove">✖</i></div>
            <div class="ditem">Item 2<i class="js-remove">✖</i></div>
            <div class="ditem">Item 3<i class="js-remove">✖</i></div>
        </div>
    </div>

    <br />

    <script src="/Scripts/Sortable.js"></script>
    <script>
        var cart = document.getElementById('cart');
        Sortable.create(cart, {
            group: { name: 'donation', pull: true, put: true },
            animation: 150,
            ghostClass: 'itemPreview',
            filter: '.js-remove',
            onFilter: function (evt) {
                evt.item.parentNode.removeChild(evt.item);
            }
        });

        var availableItems = document.getElementById('availableItems');
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
            cursor: move;
            position: relative;
        }

        #cart .ditem:hover .js-remove {
            opacity: 1;
            cursor: pointer;
        }

        .js-remove {
            transition: opacity .2s;
            opacity: 0;
            display: block;
            color: #c00;
            top: 5px;
            right: 10px;
            position: absolute;
            font-style: normal;
        }
    </style>

    <a href="/Pages/ViewDonationCenters.aspx">
        <input type="button" value="Find Accepting Donation Centers"/>
    </a>

</asp:Content>
