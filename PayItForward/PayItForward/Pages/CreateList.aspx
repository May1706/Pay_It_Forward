<%@ Page Title="Create List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateList.aspx.cs" Inherits="PayItForward.Pages.CreateList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>What are you looking to donate?</h1>

    <h3>Select the category of your item and drag it into your donation cart.
        After everything you wish to donate is in your cart, click the button below to find the best donation centers based on your items.</h3>
    
    <h4>Currently only supports categories and not specific items</h4>

    <asp:Textbox id="cartText" hidden="true" runat="server"/>

    <div class="actionCenter">
        <div class="listbox leftList" runat="server">
            <h2>Donation Cart</h2>
            <div id="cart" class="sortable" runat="server"/>
        </div>

        <div class="listbox rightList">
            <h2>Accepted Items</h2>
            <asp:DropDownList id="categoryList" class="categoryselect" OnSelectedIndexChanged="categoryList_SelectedIndexChanged" hidden="true" AutoPostBack="true" runat="server"/>
            <div id="availableItems" class="sortable" runat="server"/>
        </div>
    </div>

    <br />

    <asp:Button id="submitButton" class="actionButton" Text="Find Accepting Donation Centers" OnClientClick="submitClick()" OnClick="submitButton_Click" runat="server"/>

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

        var text = document.getElementById("<%=cartText.ClientID%>");
        $('.ditem').click(function () {
            //text.value += $(this).children(":first").html() + ";";
            cart.appendChild(this.cloneNode(true));
        });

        //Occurs before the server
        function submitClick() {
            var s = $(cart).html().split(/<[^>]*>/);

            for (var i = 0, len = s.length; i < len; i++) {
                if (s[i] != null && s[i].trim().length > 0 && s[i].trim() != "✖") {
                    text.value += s[i].trim() + ';';
                }
            }
        }
    </script>

    <style>
        .actionCenter {
            width: 100%;
            position: relative;
            height: 500px;
        }

        .listbox {
            display: inline-block;
            width: 49%;
            position: absolute;
            height: 85%;
            display: inline-block;
        }

        .leftList {
            left: 0px;
        }

        .rightList {
            right: 0px;
        }

        .categoryselect {
            width: 99%;
            margin: 1px;
        }

        .sortable {
            border: 2px solid #50B948;
            overflow: hidden;
            overflow-y: auto;
            height: 100%;
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

        .itemPreview{
            opacity: 0.5;
        }

        .actionButton {
            width: 100%;
            height: 75px;
            background-color: #50B948;
            border: none;
            color: rgba(255, 255, 255, 1);
            font-size: 20px;
        }

        .actionButton:hover {
            color: #333;
            background-color: rgba(132, 201, 127, 1);
        }
    </style>

</asp:Content>
