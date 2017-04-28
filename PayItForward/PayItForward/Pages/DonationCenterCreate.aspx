<%@ Page Title="Pay It Forward - Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationCenterCreate.aspx.cs" Inherits="PayItForward.Pages.DonationCenterCreate" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Create Donation Center</h1>

    <asp:Panel ID="ExistsPanel" Visible="false" runat="server">
        A Donation Center with this name already exists.
    </asp:Panel>

    <asp:Panel ID="CreatePanel" Visible="true" runat="server">
        <div class="side left">
            <p>Donation Center Name</p>
            <asp:TextBox ID="Name" class="addCenterField" runat="server"></asp:TextBox>

            <br />
            <br />

            <p>Description</p>
            <asp:TextBox ID="Description" runat="server"></asp:TextBox>

            <br />
            <br />

            <p>Address</p>
            <asp:TextBox ID="Address" class="addCenterField" runat="server"></asp:TextBox>

            <br />
            <br />

            <p>Phone Number</p>
            <asp:TextBox ID="PhoneNumber" runat="server" />

            <br />
            <br />

            <p>Hours</p>
            <div class="dcHours">
                <div class="dayRow">
                    <asp:Label runat="server" class="day" Text="Sunday:"/>
                    <asp:DropDownList runat="server" ID="DropDownList1" class="open">
                        <asp:ListItem Enabled="true" Text="Open" Value=-1/>
                        <asp:ListItem Text="12 AM" Value=0/>
                        <asp:ListItem Text="1 AM" Value=1/>
                        <asp:ListItem Text="2 AM" Value=2/>
                        <asp:ListItem Text="3 AM" Value=3/>
                        <asp:ListItem Text="4 AM" Value=4/>
                        <asp:ListItem Text="5 AM" Value=5/>
                        <asp:ListItem Text="6 AM" Value=6/>
                        <asp:ListItem Text="7 AM" Value=7/>
                        <asp:ListItem Text="8 AM" Value=8/>
                        <asp:ListItem Text="9 AM" Value=9/>
                        <asp:ListItem Text="10 AM" Value=10/>
                        <asp:ListItem Text="11 AM" Value=11/>
                        <asp:ListItem Text="12 pm" Value=12/>
                        <asp:ListItem Text="1 pm" Value=13/>
                        <asp:ListItem Text="2 pm" Value=14/>
                        <asp:ListItem Text="3 pm" Value=15/>
                        <asp:ListItem Text="4 pm" Value=16/>
                        <asp:ListItem Text="5 pm" Value=17/>
                        <asp:ListItem Text="6 pm" Value=18/>
                        <asp:ListItem Text="7 pm" Value=19/>
                        <asp:ListItem Text="8 pm" Value=20/>
                        <asp:ListItem Text="9 pm" Value=21/>
                        <asp:ListItem Text="10 pm" Value=22/>
                        <asp:ListItem Text="11 pm" Value=23/>
                    </asp:DropDownList> 
     
                    <asp:DropDownList runat="server" ID="DropDownList2" class="closeDrop">
                        <asp:ListItem Enabled="true" Text="Close" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
                </div>
      
                <div class="dayRow">
                    <asp:Label runat="server" class="day" Text="Monday:"/>
                    <asp:DropDownList runat="server" ID="DropDownList3" class="open">
                        <asp:ListItem Enabled="true" Text="Open" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
    
                    <asp:DropDownList runat="server" ID="DropDownList4" class="closeDrop">
                        <asp:ListItem Enabled="true" Text="Close" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
                </div>
     
                <div class="dayRow">
                    <asp:Label runat="server" class="day" Text="Tuesday:"/>
                    <asp:DropDownList runat="server" ID="DropDownList5" class="open">
                        <asp:ListItem Enabled="true" Text="Open" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
   
                    <asp:DropDownList runat="server" ID="DropDownList6" class="closeDrop">
                        <asp:ListItem Enabled="true" Text="Close" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
                </div>

                <div class="dayRow">
                    <asp:Label runat="server" class="day" Text="Wednesday:"/>
                    <asp:DropDownList runat="server" ID="DropDownList7" class="open">
                        <asp:ListItem Enabled="true" Text="Open" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
    
                    <asp:DropDownList runat="server" ID="DropDownList8" class="closeDrop">
                        <asp:ListItem Enabled="true" Text="Close" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
                </div>

                <div class="dayRow">
                    <asp:Label runat="server" class="day" Text="Thursday:"/>
                    <asp:DropDownList runat="server" ID="DropDownList9" class="open">
                        <asp:ListItem Enabled="true" Text="Open" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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

                    <asp:DropDownList runat="server" ID="DropDownList10" class="closeDrop">
                        <asp:ListItem Enabled="true" Text="Close" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
                </div>

                <div class="dayRow">
                    <asp:Label runat="server" class="day" Text="Friday:"/>
                    <asp:DropDownList runat="server" ID="DropDownList11" class="open">
                        <asp:ListItem Enabled="true" Text="Open" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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

                    <asp:DropDownList runat="server" ID="DropDownList12" class="closeDrop">
                        <asp:ListItem Enabled="true" Text="Close" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
                </div>

                <div class="dayRow">
                    <asp:Label runat="server" class="day" Text="Saturday:"/>
                    <asp:DropDownList runat="server" ID="DropDownList13" class="open">
                        <asp:ListItem Enabled="true" Text="Open" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
  
                    <asp:DropDownList runat="server" ID="DropDownList14" class="closeDrop">
                        <asp:ListItem Enabled="true" Text="Close" Value="-1"/>
                        <asp:ListItem Text="12 AM" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 AM" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 AM" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 AM" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4 AM" Value="4"></asp:ListItem>
                        <asp:ListItem Text="5 AM" Value="5"></asp:ListItem>
                        <asp:ListItem Text="6 AM" Value="6"></asp:ListItem>
                        <asp:ListItem Text="7 AM" Value="7"></asp:ListItem>
                        <asp:ListItem Text="8 AM" Value="8"></asp:ListItem>
                        <asp:ListItem Text="9 AM" Value="9"></asp:ListItem>
                        <asp:ListItem Text="10 AM" Value="10"></asp:ListItem>
                        <asp:ListItem Text="11 AM" Value="11"></asp:ListItem>
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
                </div>
            </div>

            <br />
            <br />
        </div> 

        <div class="right side">
            <p>Pickup</p>
            <asp:TextBox ID="PickupTextBox" class="addCenterField" runat="server"/>

            <br />
            <br />

            <p>Categories Accepted</p>
            <asp:CheckBoxList ID="CheckBoxList" runat="server"/>

            <br />
            <br />
        </div>

        <asp:Button ID="SaveChanges" class="actionButton" Text="Submit for Review" OnClick="CreateCenter_Click" runat="server"/>

        <asp:Label ID="ErrMsg" ForeColor="red" runat="server"/>
    </asp:Panel>

    <style>
        .side {
            display: inline-block;
        }

        .left {
            width: 400px;
            margin-right: 100px;
            float: left;
        }

        .dcHours {
            width: 500px;
            display: inline-block;
        }

        .dayRow {
            width: 95%;
            margin: 5px;
            position: relative;
            display: inline-block;
        }

        .day {
            float: left;
        }

        .open {
            position: absolute;
            width: 100px;
            left: 100px;
        }

        .closeDrop {
            position: absolute;
            width: 100px;
            left: 205px;
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
