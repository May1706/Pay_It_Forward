<%@ Page Title="Pay It Forward - Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationCenterCreate.aspx.cs" Inherits="PayItForward.Pages.DonationCenterCreate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Create an Account</h1>
        <p class="lead">UNDER CONSTRUCTION</p>
        <p>Select the desired account type and complete the form to register</p>
    </div>

    <div class="row">
        <div><h1>Create Donation Center</h1></div>
        <asp:Panel ID="ExistsPanel" Visible="false" runat="server">
            A Donation Center with this name already exists.
        </asp:Panel>

        <asp:Panel ID="CreatePanel" Visible="true" runat="server">
            <p>Donation Center Name</p>
            <asp:TextBox ID="Name" class="addCenterField" runat="server"></asp:TextBox>
            <br />
            <br />

            <p>Address</p>
            <asp:TextBox ID="Address" class="addCenterField" runat="server"></asp:TextBox>
            <br />
            <br />

            <p>Hours</p>
            <asp:Label runat="server" CssClass="col-md-2 control-label">Sunday:</asp:Label>

                <asp:DropDownList runat="server" ID="DropDownList1" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Open" Value=-1></asp:ListItem>
                    <asp:ListItem Text="12 am" Value=0></asp:ListItem>
                    <asp:ListItem Text="1 am" Value=1></asp:ListItem>
                    <asp:ListItem Text="2 am" Value=2></asp:ListItem>
                    <asp:ListItem Text="3 am" Value=3></asp:ListItem>
                    <asp:ListItem Text="4 am" Value=4></asp:ListItem>
                    <asp:ListItem Text="5 am" Value=5></asp:ListItem>
                    <asp:ListItem Text="6 am" Value=6></asp:ListItem>
                    <asp:ListItem Text="7 am" Value=7></asp:ListItem>
                    <asp:ListItem Text="8 am" Value=8></asp:ListItem>
                    <asp:ListItem Text="9 am" Value=9></asp:ListItem>
                    <asp:ListItem Text="10 am" Value=10></asp:ListItem>
                    <asp:ListItem Text="11 am" Value=11></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value=12></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value=13></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value=14></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value=15></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value=16></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value=17></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value=18></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value=19></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value=20></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value=21></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value=22></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value=23></asp:ListItem>
                </asp:DropDownList> 
     
                <asp:DropDownList runat="server" ID="DropDownList2" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Close" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList> 
      
            <asp:Label runat="server" CssClass="col-md-2 control-label">Monday:</asp:Label>
             
   
                <asp:DropDownList runat="server" ID="DropDownList3" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Open" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList> 
    
                <asp:DropDownList runat="server" ID="DropDownList4" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Close" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList> 
     
            <asp:Label runat="server" CssClass="col-md-2 control-label">Tuesday:</asp:Label>
        
       
                <asp:DropDownList runat="server" ID="DropDownList5" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Open" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList> 
   
                <asp:DropDownList runat="server" ID="DropDownList6" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Close" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList>
    
            <asp:Label runat="server" CssClass="col-md-2 control-label">Wednesday:</asp:Label>
     
      
                <asp:DropDownList runat="server" ID="DropDownList7" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Open" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList> 
    
                <asp:DropDownList runat="server" ID="DropDownList8" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Close" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList> 
          
            <asp:Label runat="server" CssClass="col-md-2 control-label">Thursday:</asp:Label>
   
       
                <asp:DropDownList runat="server" ID="DropDownList9" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Open" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList>

                <asp:DropDownList runat="server" ID="DropDownList10" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Close" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList>
 
            <asp:Label runat="server" CssClass="col-md-2 control-label">Friday:</asp:Label>
   
     
                <asp:DropDownList runat="server" ID="DropDownList11" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Open" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList>

                <asp:DropDownList runat="server" ID="DropDownList12" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Close" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList> 
     
            <asp:Label runat="server" CssClass="col-md-2 control-label">Saturday:</asp:Label>
     
                <asp:DropDownList runat="server" ID="DropDownList13" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Open" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList>
  
                <asp:DropDownList runat="server" ID="DropDownList14" CssClass="form-control">
                    <asp:ListItem Enabled="true" Text="Close" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="12 am" Value="0"></asp:ListItem>
                    <asp:ListItem Text="1 am" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2 am" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3 am" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4 am" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5 am" Value="5"></asp:ListItem>
                    <asp:ListItem Text="6 am" Value="6"></asp:ListItem>
                    <asp:ListItem Text="7 am" Value="7"></asp:ListItem>
                    <asp:ListItem Text="8 am" Value="8"></asp:ListItem>
                    <asp:ListItem Text="9 am" Value="9"></asp:ListItem>
                    <asp:ListItem Text="10 am" Value="10"></asp:ListItem>
                    <asp:ListItem Text="11 am" Value="11"></asp:ListItem>
                    <asp:ListItem Text="12 pm" Value="12"></asp:ListItem>  
                    <asp:ListItem Text="1 pm" Value="13"></asp:ListItem>
                    <asp:ListItem Text="2 pm" Value="14"></asp:ListItem>
                    <asp:ListItem Text="3 pm" Value="15"></asp:ListItem>
                    <asp:ListItem Text="4 pm" Value="16"></asp:ListItem>
                    <asp:ListItem Text="5 pm" Value="17"></asp:ListItem>
                    <asp:ListItem Text="6 pm" Value="18"></asp:ListItem>
                    <asp:ListItem Text="7 pm" Value="19"></asp:ListItem>
                    <asp:ListItem Text="8 pm" Value="20"></asp:ListItem>
                    <asp:ListItem Text="9 pm" Value="21"></asp:ListItem>
                    <asp:ListItem Text="10 pm" Value="22"></asp:ListItem>
                    <asp:ListItem Text="11 pm" Value="23"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />








            <asp:TextBox ID="PickupTextBox" class="addCenterField" runat="server" Text="Provides Pickup"></asp:TextBox>
            <br />
            <br /> 

            <p>Categories</p>
            <asp:TextBox ID="CategoryNamesAsString" class="addCenterField" runat="server"></asp:TextBox>
            <br />
            <br />

            <p>Categories Accepted</p>
            <asp:CheckBox ID="Categories" runat="server"></asp:CheckBox>

            <asp:Button ID="SaveChanges" class="actionButton" Text="Save" OnClick="CreateCenter_Click" runat="server"/>
            <asp:Label ID="ErrMsg" ForeColor="red" runat="server"/>
        </asp:Panel>
        
    </div>

   
</asp:Content>
