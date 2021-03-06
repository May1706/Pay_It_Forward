﻿<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="PayItForward.Pages.AdminProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    </header>

    <h1>
        Admin Action Center
    </h1>

    <div class="container">
        <div class="row">
            <div class="col-sm-2">
                <ul class="nav nav-pills nav-stacked">
                    <li class="active"><a data-toggle="pill" href="#pendingRequests">Pending Requests</a></li>
                    <li><a data-toggle="pill" href="#requestHistory">Request History</a></li>
                    <li><a data-toggle="pill" href="#item">Manage Items</a></li>
                    <li><a data-toggle="pill" href="#category">Manage Categories</a></li>
                    <li><a data-toggle="pill" href="#donationCenters">Manage Donation Centers</a></li>
                </ul>
            </div>

            <div class="col-sm-10">
                <div class="tab-content">

                    <!-- Open Requests content -->
                    <div id="pendingRequests" class="tab-pane fade">
                        <h3>Pending Requests</h3>
                        <div class="table-responsive">
                            <div id="listPending" runat="server" />
                        </div>
                    </div>

                    <!-- Request History content -->
                    <div id="requestHistory" class="tab-pane fade">
                        <h3>Request History</h3>
                        <div class="table-responsive">
                            <div id="listHistory" runat="server"/>
                        </div>
                    </div>
                    
                    <!-- Manage Items content -->
                    <div id="item" class="tab-pane fade">
                        <h3>Manage Items</h3>

                        <p>Name</p>
                        <asp:TextBox id="itemName" runat="server"/>

                        <br />
                        <br />

                        <p>Weight</p>
                        <asp:TextBox id="itemWeight" runat="server"/>

                        <br />
                        <br />

                        <p>Category</p>
                        <asp:DropDownList id="itemCategory" runat="server"/>

                        <br />
                        <br />

                        <p>Low Price</p>
                        <asp:TextBox id="itemLow" runat="server"/>

                        <br />
                        <br />

                        <p>High Price</p>
                        <asp:TextBox id="itemHigh" runat="server"/>

                        <br />
                        <br />
                        <!-- Needs elaboration -->
                        <p id="itemErrorText" class="errorText" visible="false" runat="server">Incorrect Fields</p>

                        <asp:Button id="addItemButton" OnClick="addItemButton_Click" Text="Add Item" runat="server"/>
                    </div>

                    <!-- Manage Categories content -->
                    <div id="category" class="tab-pane fade">
                        <h3>Manage Categories</h3>
                        
                        <p>Name</p>
                        <asp:TextBox id="categoryName" runat="server"/>

                        <br />
                        <br />
                        <p id="categoryErrorText" class="errorText" visible="false" runat="server">Incorrect Fields</p>

                        <asp:Button ID="addCategoryButton" OnClick="addCategoryButton_Click" Text="Add Category" runat="server"/>
                    </div>

                    <!-- Manage Donation Centers -->
                    <div id="donationCenters" class="tab-pane fade">
                        <h3>Manage Donation Centers</h3>
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="dcGrid" CssClass="table table-hover table-striped table-bordered" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

   
    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">
    
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modal Header</h4>
                </div>
                <div class="modal-body">
                    <p>Some text in the modal.</p>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <p id="uid" style="display: none"></p>

                    <input id="Accept" value="Accept" type="button" class="btn btn-default" onclick="acceptRequest()"/>
                    <input id="Deny" value=" Deny " type="button" class="btn btn-default" onclick="denyRequest()"/>
                </div>
            </div>      
        </div>
    </div>

    <div class="modal fade" id="myDcModal" role="dialog">
        <div class="modal-dialog">
    
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modal Header</h4>
                </div>
                <div class="modal-body"></div>
                <div class="modal-footer" style="text-align: center;">
                    <p id="dcId" style="display: none"></p>

                    <input id="Visible" value=" Make Visible " type="button" class="btn btn-default" onclick="makeVisible()"/>
                    <input id="Invisible" value=" Make Invisible" type="button" class="btn btn-default" onclick="makeInvisible()"/>
                </div>
            </div>      
        </div>
    </div>

    <script>
        $('#pendingRequestTable').find('tr').click(function () {
            $(".selectedRow").removeClass("selectedRow");
            var old = $(this).find('td:first').text();
            var row = $(this);
            row.addClass("selectedRow");

            var close = '<button type="button" class="close" data-dismiss="modal">&times;</button>';
            var type = "<h3 id='type'>" + row.find('td:eq(2)').text() + "</h3>";
            var message = "<p>" + row.find('td:eq(4)').text() + "</p>";

            $(".modal-header").empty().append(close, type);
            $(".modal-body").empty().append(message);

            $("#uid").text(row.find('td:eq(0)').text());


            $("#myModal").modal();
        });

        function acceptRequest() {
            $.ajax({
                type: "POST",
                url: "AdminProfile.aspx/AcceptRequest",
                data: '{"type":"' + $('#type').text() + '","uid":"' + $("#uid").text() + '"}',
                contentType: "application/json",
                dataType: "json",
                success:
                    function (data) {
                        var row = $(".selectedRow");
                        var type = row.find('td:eq(2)').text();
                        var timeCreated = row.find('td:eq(3)').text();
                        var message = row.find('td:eq(4)').text();

                        lastUpdated = JSON.parse(data.d);
                        if (lastUpdated === "") {
                            alert("Request failed, please try again!");
                        } else {
                            $('#myModal').modal('toggle');
                            //Remove row from pending and add to history
                            $('<tr><td>' + type + '</td><td>' + timeCreated + '</td><td>' + lastUpdated + '</td><td>' + message + '</td><td>Approved</td>')
                                .insertBefore('#historyRequestTable > tbody > tr:first');
                            row.remove();
                        }
                    }
            });
        }
        
        function denyRequest() {
            $.ajax({
                type: "POST",
                url: "AdminProfile.aspx/DenyRequest",
                data: '{"type":"' + $('#type').text() + '","uid":"' + $("#uid").text() + '"}',
                contentType: "application/json",
                dataType: "json",
                success:
                    function (data) {
                        var row = $(".selectedRow");
                        var type = row.find('td:eq(2)').text();
                        var timeCreated = row.find('td:eq(3)').text();
                        var message = row.find('td:eq(4)').text();

                        lastUpdated = JSON.parse(data.d);
                        if (lastUpdated === "") {
                            alert("Request failed, please try again!");
                        } else {
                            $('#myModal').modal('toggle');
                            //Remove row from pending and add to history table
                            $('<tr><td>' + type + '</td><td>' + timeCreated + '</td><td>' + lastUpdated + '</td><td>' + message + '</td><td>Denied</td>')
                                .insertBefore('#historyRequestTable > tbody > tr:first');
                            row.remove();
                        }
                    }
            });
        }
    
        $('#MainContent_dcGrid').find('tr').click(function () {
            $(".selectedDcRow").removeClass("selectedDcRow");
            var old = $(this).find('td:first').text();
            var row = $(this);
            row.addClass("selectedDcRow");

            var close = '<button type="button" class="close" data-dismiss="modal">&times;</button>';
            var dcName = "<h3 id='dcName'>" + row.find('td:eq(1)').text() + "</h3>";

            $(".modal-header").empty().append(close, dcName);
            $("#dcId").text(row.find('td:eq(0)').text());

            //Todo make ajax call
            $.ajax({
                type: "POST",
                url: "AdminProfile.aspx/CheckVisibility",
                data: '{"id":"' + $('#dcId').text() + '"}',
                contentType: "application/json",
                dataType: "json",
                success:
                    function (data) {
 
                        vString = JSON.parse(data.d);
                        if (vString === "") {
                            alert("Request failed, please try again!");
                        } else {
                            var message = '<h4>' + vString + '</h4>';

                            $(".modal-body").empty().append(message);
                            if (vString === "visible") {
                                $("#Visible").hide();
                                $("#Invisible").show();
                            } else {
                                $("#Invisible").hide();
                                $("#Visible").show();
                            }
                            $("#myDcModal").modal();
                        }

                    }
            });

        });

        function makeVisible() {
            $.ajax({
                type: "POST",
                url: "AdminProfile.aspx/MakeVisible",
                data: '{"id":"' + $('#dcId').text() + '"}',
                contentType: "application/json",
                dataType: "json",
                success:
                    function (data) {
                        response = JSON.parse(data.d);
                        if (response === "") {
                            alert("Request failed, please try again!");
                        } else {
                            $('#myDcModal').modal('toggle');
                        }
                    }
            });
        }

        function makeInvisible() {
            $.ajax({
                type: "POST",
                url: "AdminProfile.aspx/MakeInvisible",
                data: '{"id":"' + $('#dcId').text() + '"}',
                contentType: "application/json",
                dataType: "json",
                success:
                    function (data) {
                        response = JSON.parse(data.d);
                        if (response === "") {
                            alert("Request failed, please try again!");
                        } else {
                            $('#myDcModal').modal('toggle');
                        }
                    }
            });
        }
    </script>

    <style>
        #<%=itemErrorText.ClientID%> {
            color: red;
        }

        #<%=categoryErrorText.ClientID%> {
            color: red;
        }
    </style>
</asp:Content>
