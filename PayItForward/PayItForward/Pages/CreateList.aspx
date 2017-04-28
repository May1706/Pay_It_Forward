<%@ Page Title="Create List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateList.aspx.cs" Inherits="PayItForward.Pages.CreateList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1>What are you looking to donate?</h1>

    <h3>Select the category of your item and drag it into your donation cart.
        After everything you wish to donate is in your cart, click the button below to find the best donation centers based on your items.</h3>

    <br />

    <asp:Textbox id="cartText" hidden="true" runat="server"/>
    
    <h2>Category</h2>
    <asp:DropDownList id="categoryList" class="categoryselect" runat="server"/>

    <div class="actionCenter">
        <div class="listbox leftList" runat="server">
            <h2>Donation Cart</h2>
            <div id="cart" class="sortable" runat="server"/>
        </div>

        <div class="listbox rightList">
            <h2>Accepted Items</h2>
            
            <div id="availableItems" class="sortable" runat="server"/>
        </div>
    </div>

    <br />

    <asp:Button id="submitButton" class="actionButton" Text="Find Accepting Donation Centers" OnClientClick="submitClick()" OnClick="submitButton_Click" runat="server" />
    <br />
    <br />
    <asp:Button id="saveButton" class="actionButton" Text="Save Donation List" OnClientClick="submitClick()" OnClick="saveButton_Click" runat="server"/>
    <script src="/Scripts/Sortable.js"></script>
    <script>
        // Selecting a new category updates the available items box
        $('#<%=categoryList.ClientID%>').change(function() {
            var selectedCategory = $(this).val();
            console.log("Category: " + selectedCategory);
            $.ajax({
                type: "POST",
                url: "CreateList.aspx/GetItemsFromCategory",
                data: '{"value":"' + selectedCategory + '"}',
                contentType: "application/json",
                dataType: "json",
                success:
                    function (data) {
                        obj = JSON.parse(data.d);
                        availableItems.innerHTML = "";
                        for (var key in obj) {
                            if (obj.hasOwnProperty(key)) {
                                availableItems.innerHTML += "<div class='ditem' draggable='false'>" +
                                                            "<div>" + obj[key] + "</div>" +
                                                            "<i class='js-remove'>✖</i>" +
                                                            "</div>";
                            }
                        }
                    }
            })
        });

        // Allows the cart to be dragged to
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

        // Allow the Available Items box to dragged from
        var availableItems = document.getElementById("<%=availableItems.ClientID%>");
        Sortable.create(availableItems, {
            group: { name: 'donation', pull: 'clone', put: false },
            animation: 150,
            ghostClass: 'itemPreview'
        });

        // Allows clicking in addition to the dragging
        $('.ditem').click(function () {
            cart.appendChild(this.cloneNode(true));
        });

        // Occurs before the server; adds all carted item to an invisible asp textbox so it can be read serverside
        var text = document.getElementById("<%=cartText.ClientID%>");
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
            width: 99.75%;
            margin: 1px;
            border: 1px solid #50B948;
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
