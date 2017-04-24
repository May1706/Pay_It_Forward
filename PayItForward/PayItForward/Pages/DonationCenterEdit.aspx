<%@ Page Title="Edit Donation Center" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationCenterEdit.aspx.cs" Inherits="PayItForward.Pages.DonationCenterEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div><h1>Edit Donation Center</h1></div>
        <asp:Panel ID="EditPanel" Visible="true" runat="server">
            <p>Donation Center Name</p>
            <asp:TextBox ID="CenterName" class="editCenterField" runat="server"></asp:TextBox>
            <br />
            <br />

            <p>Address</p>
            <asp:TextBox ID="Address" class="editCenterField" runat="server"></asp:TextBox>
            <br />
            <br />

            <p>Hours</p>
            <asp:TextBox ID="Hours" class="editCenterField" runat="server" TextMode="MultiLine" Columns="50" Rows="7"></asp:TextBox>
            <br />
            <br />

            <!--<asp:CheckBox ID="Pickup" class="editCenterField" runat="server" Text="Provides Pickup"></asp:CheckBox>
            <br />
            <br />

            <p>Categories</p>
            <asp:TextBox ID="CategoryNamesAsString" class="editCenterField" runat="server"></asp:TextBox>
            <br />
            <br />-->
            <asp:Button ID="SaveChanges" class="actionButton" Text="Save" OnClick="SaveChanges_Click" runat="server"/>
            <asp:Label ID="ErrMsg" ForeColor="red" runat="server"/>
        </asp:Panel>
        <asp:Panel ID="NotFoundPanel" Visible="false" runat="server">
            Specified donation center could not be found.
        </asp:Panel>
    </div>
    
</asp:Content>
