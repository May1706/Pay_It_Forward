<%@ Page Title="Edit Donation Center" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationCenterEdit.aspx.cs" Inherits="PayItForward.Pages.DonationCenterEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Donation Center</h1>

    <asp:Panel ID="EditPanel" Visible="true" runat="server">
        <div class="side left">
            <p>Donation Center Name</p>
            <asp:TextBox ID="CenterName" class="field editCenterField" runat="server"></asp:TextBox>

            <br />
            <br />

            <p>Address</p>
            <asp:TextBox ID="Address" class="field editCenterField" runat="server"></asp:TextBox>

            <br />
            <br />

            <p>Hours</p>
            <div class="field">
                Sunday:     <asp:TextBox ID="SundayHours"       class="hours hoursBox editCenterField" runat="server"/><br /><br />
                Monday:     <asp:TextBox ID="MondayHours"       class="hours hoursBox editCenterField" runat="server"/><br /><br />
                Tuesday:    <asp:TextBox ID="TuesdayHours"      class="hours hoursBox editCenterField" runat="server"/><br /><br />
                Wednesday:  <asp:TextBox ID="WednesdayHours"    class="hours hoursBox editCenterField" runat="server"/><br /><br />
                Thursday:   <asp:TextBox ID="ThursdayHours"     class="hours hoursBox editCenterField" runat="server"/><br /><br />
                Friday:     <asp:TextBox ID="FridayHours"       class="hours hoursBox editCenterField" runat="server"/><br /><br />
                Saturday:   <asp:TextBox ID="SaturdayHours"     class="hours hoursBox editCenterField" runat="server"/><br /><br />
            </div>

            <br />
            <br />
        </div>

        <!--
        <asp:CheckBox ID="Pickup" class="editCenterField" runat="server" Text="Provides Pickup"></asp:CheckBox>

        <br />
        <br />
        -->

        <div class="side right">
            <p>Types of Accepted Items</p>
            <asp:CheckBoxList ID="Categories" runat="server"></asp:CheckBoxList>
        </div>

        <br />
        <br />

        <asp:Button ID="SaveChanges" class="actionButton" Text="Save" OnClick="SaveChanges_Click" runat="server"/>

        <asp:Label ID="ErrMsg" ForeColor="red" runat="server"/>
    </asp:Panel>

    <asp:Panel ID="NotFoundPanel" Visible="false" runat="server">
        Specified donation center could not be found.
    </asp:Panel>

    <style>
        .side {
            display: inline-block;
        }

        .left {
            width: 400px;
            margin-right: 50px;
            float: left;
        }

        .field {
            width: 275px;
        }

        .hours {
            display: inline-block;
        }

        .hoursBox {
            float: right;
            width: 60%;
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
