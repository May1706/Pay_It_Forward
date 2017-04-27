<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationCenterProfile.aspx.cs" Inherits="PayItForward.Pages.DonationCenterProfile" %>

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

            <asp:Label id="dcDescription" Text="[Description]" runat="server" />

            <br />
            <br />

            <asp:Label Text="Phone:" class="bolded" runat="server" /><br />
            <asp:Label id="dcPhone" Text="[Phone Number]" runat="server" />

            <br />
            <br />

            <asp:Label Text="Email:" class="bolded" runat="server" /><br />
            <asp:Label id="dcEmail" Text="[Contact Email]" runat="server" />

            <br />
            <br />

            <asp:Label Text="Website:" class="bolded" runat="server" /><br />
            <asp:Label id="dcWebsite" Text="[Website]" runat="server" />

            <br />
            <br />

            <asp:Label Text="Hours:" class="bolded" runat="server" />
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

            <asp:Label Text="Accepted Items:" class="bolded" runat="server" />
            <div id="dcItems" runat="server"/>

            <br />

            <asp:Label Text="Information Last Updated:" class="bolded" runat="server" /><br />
            <asp:Label id="dcUpdated" Text="[Date]" runat="server" />

            <br />
            <br />
        </div>

        <div class="dcPanel dcImageAndMap">
            <asp:Image CssClass="dcImage" ImageUrl="/Images/DefaultDCImage.png" ID="dcImage" runat="server"/>
            <iframe id="dcMapsFrame" class="dcImage" frameborder="0" allowfullscreen="true" runat="server"></iframe>
        </div>
    </div>

    <style>
        .dcContent {
            background-color: red;
        }

        .dcInfo {
            width: 300px;
            margin-right: 50px;
            float: left;
        }
        
        .dcImage {
            height: 400px;
            width: 400px;
            overflow: hidden;
            margin: 5px;
            float: left;
            object-fit: contain;
            border: 2px solid #50B948;
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

        .bolded {
            font-weight: bold;
        }
    </style>

</asp:Content>
