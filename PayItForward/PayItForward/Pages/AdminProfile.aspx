<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminProfile.aspx.cs" Inherits="PayItForward.Pages.AdminProfile" %>

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
                    <li class="active"><a data-toggle="pill" href="#home">Home</a></li>
                    <li><a data-toggle="pill" href="#pendingRequests">Pending Requests</a></li>
                    <li><a data-toggle="pill" href="#requestHistory">Request History</a></li>
                    <li><a data-toggle="pill" href="#user">Manage Users</a></li>
                    <li><a data-toggle="pill" href="#item">Manage Items</a></li>
                    <li><a data-toggle="pill" href="#category">Manage Categories</a></li>
                    <li><a data-toggle="pill" href="#donationCenters">Manage Donation Centers</a></li>
                </ul>
            </div>

            <div class="col-sm-10">
                <div class="tab-content">
                    <!-- Home content -->
                    <div id="home" class="tab-pane fade in active">
                        <h3>Home</h3>
                        <p>Select the action you would like to take using the links on the left.</p>
                        <asp:Button ID="Generate" runat="server" Text="Generate Requests" style="width:auto" onclick="Generate_Click" />
                        <asp:Button ID="Remove" runat="server" Text="Remove Requests" style="width:auto" onclick="Remove_Click" />
                        <hr />
                        
                        <!--<asp:GridView ID="requestsGridView" SkinID="Professional" runat="server"></asp:GridView>-->

                        <h2>Modal Example</h2>
                        <!-- Trigger the modal with a button -->
                        <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Modal</button>

                    </div>

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
                        <!--<asp:GridView ID="requestHistoryGridView" SkinID="Professional" runat="server"></asp:GridView>-->
                    </div>
                    
                    <!-- Manage Users content -->
                    <div id="user" class="tab-pane fade">
                        <h3>Manage Users</h3>
                        <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    </div>
                    
                    <!-- Manage Items content -->
                    <div id="item" class="tab-pane fade">
                        <h3>Manage Items</h3>
                        <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    </div>

                    <!-- Manage Categories content -->
                    <div id="category" class="tab-pane fade">
                        <h3>Manage Categories</h3>
                        <p>Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
                    </div>

                    <!-- Manage Donation Centers -->
                    <div id="donationCenters" class="tab-pane fade">
                        <h3>Manage Donation Centers</h3>
                        <p>This feature is not implemented yet.</p>
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
                    <button type="button" class="btn btn-default" data-dismiss="modal" onclick="Accept_Click">Accept</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal" onclick="Deny_Click">Deny</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                </div>
            </div>      
        </div>
    </div>


</asp:Content>
