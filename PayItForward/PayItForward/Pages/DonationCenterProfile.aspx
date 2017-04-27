﻿<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationCenterProfile.aspx.cs" Inherits="PayItForward.Pages.DonationCenterProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div class="dcContent">
        <div class="dcPanel dcInfo">
            <asp:Label id="dcName" Text="[Donation Center Name]" runat="server"/>

            <br />
            <br />

            <asp:Label id="dcAddress" Text="[Address]" runat="server"/>

            <br />
            <br />

            <asp:Label id="dcPhone" Text="[Phone Number]" runat="server" />

            <br />
            <br />
            <asp:Label id="dcEmail" Text="[Contact Email]" runat="server" />

            <br />
            <br />
            <asp:Label id="dcWebsite" Text="[Website]" runat="server" />

            <br />
            <br />
            <asp:Label id="dcDescription" Text="[Description]" runat="server" />

            <br />
            <br />

            <asp:Label Text="Hours:" runat="server" />
            <div id="dcHours">
                <asp:Label class="hours" Text="Sunday" runat="server" />
                <asp:Label id="sundayHours" class="hours time" Text="[Hours]" runat="server" />

                <br />

                <asp:Label class="hours" Text="Monday" runat="server" />
                <asp:Label id="mondayHours" class="hours time" Text="[Hours]" runat="server" />

                <br />

                <asp:Label class="hours" Text="Tuesday" runat="server" />
                <asp:Label id="tuesdayHours" class="hours time" Text="[Hours]" runat="server" />

                <br />

                <asp:Label class="hours" Text="Wednesday" runat="server" />
                <asp:Label id="wednesdayHours" class="hours time" Text="[Hours]" runat="server" />

                <br />

                <asp:Label class="hours" Text="Thursday" runat="server" />
                <asp:Label id="thursdayHours" class="hours time" Text="[Hours]" runat="server" />

                <br />

                <asp:Label class="hours" Text="Friday" runat="server" />
                <asp:Label id="fridayHours" class="hours time" Text="[Hours]" runat="server" />

                <br />

                <asp:Label class="hours" Text="Saturday" runat="server" />
                <asp:Label id="saturdayHours" class="hours time" Text="[Hours]" runat="server" />
            </div>

            <br />

            <asp:Label Text="Accepted Items:" runat="server" />
            <div id="dcItems" runat="server">

            </div>

            <br />

            <asp:Label Text="Information Last Updated:" runat="server" /><br />
            <asp:Label id="dcUpdated" Text="[Date]" runat="server" />
        </div>

        <div class="dcPanel dcImageAndMap">
            <asp:Image CssClass="dcImage" ImageUrl="/Images/DefaultDCImage.png" ID="dcImage" runat="server"/>
            <img class="dcImage" src="/Images/DefaultMap.jpg"/>
        </div>
    </div>

    <style>
        .dcContent {
            position: relative;
            width: 100%;
            min-height: 850px;
        }

        .dcPanel {
            position: absolute;
            width: 49%;
            height: 100%;
            display: inline-block;
        }

        #dcHours {
            width: 200px;
        }

        .hours {
            display: inline-block;
        }

        .time {
            float: right;
        }

        .dcImage {
            position: static;
            height: 400px;
            width: 400px;
            overflow: hidden;
            margin: 5px;
            float: right;
            object-fit: contain;
            border: 2px solid #50B948;
        }

        .dcImageAndMap {
            right: 0px;
        }

        .dcInfo {
            left: 0px;
        }
    </style>

</asp:Content>
