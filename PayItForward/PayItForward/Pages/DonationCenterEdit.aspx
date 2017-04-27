<%@ Page Title="Edit Donation Center" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationCenterEdit.aspx.cs" Inherits="PayItForward.Pages.DonationCenterEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div><h1>Edit Donation Center</h1></div>
        <asp:Panel ID="EditPanel" Visible="true" runat="server">
            <p>Donation Center Name</p>
            <asp:TextBox ID="CenterName" class="editCenterField" runat="server"></asp:TextBox>
            <br />
            <br />
            <p>Image</p>
            <asp:Image CssClass="dcImage" ImageUrl="/Images/DefaultDCImage.png" ID="dcImage" runat="server"/>
            <asp:FileUpload ID="ImageUpload" runat="server" />
            <p>Address</p>
            <asp:TextBox ID="Address" class="editCenterField" runat="server"></asp:TextBox>
            <br />
            <br />

            <p>Hours</p>
            Monday: <asp:TextBox ID="MondayHours" class="editCenterField" runat="server"></asp:TextBox><br />
            Tuesday: <asp:TextBox ID="TuesdayHours" class="editCenterField" runat="server"></asp:TextBox><br />
            Wednesday: <asp:TextBox ID="WednesdayHours" class="editCenterField" runat="server"></asp:TextBox><br />
            Thursday: <asp:TextBox ID="ThursdayHours" class="editCenterField" runat="server"></asp:TextBox><br />
            Friday: <asp:TextBox ID="FridayHours" class="editCenterField" runat="server"></asp:TextBox><br />
            Saturday: <asp:TextBox ID="SaturdayHours" class="editCenterField" runat="server"></asp:TextBox><br />
            Sunday: <asp:TextBox ID="SundayHours" class="editCenterField" runat="server"></asp:TextBox><br />

            <br />
            <br />

            <!--<asp:CheckBox ID="Pickup" class="editCenterField" runat="server" Text="Provides Pickup"></asp:CheckBox>
            <br />
            <br />
                -->
            <p>Types of Accepted Items</p>
            <asp:CheckBoxList ID="Categories" runat="server"></asp:CheckBoxList>
            <br />
            <br />
            <asp:Button ID="SaveChanges" class="actionButton" Text="Save" OnClick="SaveChanges_Click" runat="server"/>
            <asp:Label ID="ErrMsg" ForeColor="red" runat="server"/>
        </asp:Panel>
        <asp:Panel ID="NotFoundPanel" Visible="false" runat="server">
            Specified donation center could not be found.
        </asp:Panel>
    </div>
    
</asp:Content>
