<%@ Page Title="Modify Customer | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModifyCustomer.aspx.cs" Inherits="ModifyCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    
    <!--Page header-->
    <h1 class="noTopMargin">Modify Customer</h1>

    <h4 class="orange-text"><asp:Label ID="successMsg" runat="server" /></h4>
    
    <!-- Customer Modification -->
    <asp:Repeater runat="server" ID="singleCustomer">
        <ItemTemplate>
    <div class="col-xs-12 col-sm-12 col-md-8 col-lg-6 noLeftRightPadding overFlow">   
                
                <!--Panel for Customer Details-->
                <div class="panel panel-default">
                    <div class="panel-heading noMargins leftPadEightPix bold">
                       
                        <%# Eval("FirstName") %> <%# Eval ("LastName") %>

                    </div>          
                        
                        <!-- Table -->
                        <table class="table">
                            <tr>
                                <!--Relevant artwork info-->
                                <td class="noBottomBorder" style="border-bottom:none;">
                                    <table class="table noBottomMargin">
                                        <tbody">
                                            <tr>
                                                <td class="bold" style="padding-left:0;">Username:</td>
                                                <td><%# Eval("UserName") %></td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="bold" style="padding-left:0;">Password:</td>
                                                <td><%# Eval("Pass") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="padding-left:0;">Address:</td>
                                                <td><%# Eval("Address") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="padding-left:0;">City:</td>
                                                <td><%# Eval("City") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="padding-left:0;">State:</td>
                                                <td><%# Eval("State") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="padding-left:0;">Region:</td>
                                                <td><%# Eval("Region") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="padding-left:0;">Country:</td>
                                                <td><%# Eval("Country") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="padding-left:0;">Postal Code:</td>
                                                <td><%# Eval("Postal") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="padding-left:0;">Phone #:</td>
                                                <td><%# Eval("Phone") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="padding-left:0;">Email:</td>
                                                <td><%# Eval("Email") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="padding-left:0;">Privacy Level:</td>
                                                <td><%# Eval("Privacy") %></td>
                                            </tr>

                                            <tr>
                                                <td class="bold" style="border-bottom:none; padding-left:0; padding-bottom:0;">
                                                    Last Modification:
                                                </td>
                                                <td style="border-bottom:none; padding-left:0; padding-bottom:0;"><%# Eval("DateLastModified", "{0:dd/M/yyyy}") %></td>
                                            </tr>
                                      </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>  
                 <!--End of panel panel-default-->
                 </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <!-- End Customer Modification -->



    <div class="col-lg-12 noLeftRightPadding">

        <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-5 noLeftRightPadding pull-right">
        <div class="panel-heading">
            <h3 class="panel-title">Update Customer</h3>
        </div>
                
        <div class="panel-body noBottomPadding">
    <table class="fullWidth">
        <tr>
            <td class="fullWidth">            
                <!--First name input-->
                <asp:Label ID="newFirstLabel" runat="server" AssociatedControlID="newFirst">First Name</asp:Label>
                <asp:RegularExpressionValidator ID="FirstNameValidator" runat="server" 
                                            ControlToValidate="newFirst"
                                            ErrorMessage="Invalid First Name"
                                            CssClass="red paddingPointFiveEMBottom"
                                            ValidationExpression="^[A-Z,a-z]*$" />
                <br />

                <!--First name required indicator-->
                <asp:TextBox ID="newFirst" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td class="fullWidth">            
                <!--Last name input-->
                <asp:Label ID="newLastLabel" runat="server" AssociatedControlID="newLast">Last Name</asp:Label>
                <asp:RegularExpressionValidator ID="LastNameValidator" runat="server" 
                                            ControlToValidate="newLast"
                                            ErrorMessage="Invalid Last Name"
                                            CssClass="red paddingPointFiveEMBottom"
                                            ValidationExpression="^[A-Z,a-z]*$" />
                <br />

                <!--Last name required indicator-->
                <asp:TextBox ID="newLast" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fullWidth">            
                <!--Username input-->
                <asp:Label ID="newUsernameLabel" runat="server" AssociatedControlID="newUsername">Username</asp:Label>

                <br />

                <!--Username required indicator-->
                <asp:TextBox ID="newUsername" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fullWidth">            
                <!--Pass input-->
                <asp:Label ID="newPassLabel" runat="server" AssociatedControlID="newPass">Password</asp:Label>
                <asp:RegularExpressionValidator ID="PassValidator" runat="server" 
                            ControlToValidate="newPass"
                            ErrorMessage="Invalid Password. Must be between 5 and 20 characters and contain a numeric value."
                            CssClass="red paddingPointFiveEMBottom"
                            ValidationExpression="^(?=.*(\d|\W)).{5,20}$" />
                <br />

                <!--Pass required indicator-->
                <asp:TextBox ID="newPass" runat="server" CssClass="fullWidth searchBoxBottomMargin" TextMode="Password"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td class="fullWidth">            
                <!--Confirm Password input-->
                <asp:Label ID="confirmPassLabel" runat="server" AssociatedControlID="confirmPass">Confirm Password</asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToValidate="confirmPass"
                            CssClass="red paddingPointFiveEMBottom"
                            ControlToCompare="newPass"
                            ErrorMessage="Passwords must match" 
                            ToolTip="Passwords must match" />
                <br />

                <!--Confirm Password -->
                <asp:TextBox ID="confirmPass" runat="server" CssClass="fullWidth searchBoxBottomMargin" TextMode="Password"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fullWidth">            
                <!--State input-->
                <asp:Label ID="newStateLabel" runat="server" AssociatedControlID="newState">State</asp:Label>
                <asp:RegularExpressionValidator ID="StateValidator" runat="server" 
                            ControlToValidate="newState"
                            ErrorMessage="Invalid State Name. Enter a 1 digit number"
                            CssClass="red paddingPointFiveEMBottom"
                            ValidationExpression="^[1-9]$" />

                <br />

                <!--State required indicator-->
                <asp:TextBox ID="newState" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fullWidth">            
                <!--Address input-->
                <asp:Label ID="newAddressLabel" runat="server" AssociatedControlID="newAddress">Address</asp:Label>

                <br />

                <!--Address required indicator-->
                <asp:TextBox ID="newAddress" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fullWidth">            
                <!--City input-->
                <asp:Label ID="newCityLabel" runat="server" AssociatedControlID="newCity">City</asp:Label>
                <asp:RegularExpressionValidator ID="CityValidator" runat="server" 
                            ControlToValidate="newCity"
                            ErrorMessage="Invalid City Name"
                            CssClass="red paddingPointFiveEMBottom"
                            ValidationExpression="^[a-z, A-Z]*$" />
                <br />

                <!--City required indicator-->
                <asp:TextBox ID="newCity" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fullWidth">            
                <!--Region input-->
                <asp:Label ID="newRegionLabel" runat="server" AssociatedControlID="newRegion">Region</asp:Label>
                <asp:RegularExpressionValidator ID="RegionValidator" runat="server" 
                            ControlToValidate="newRegion"
                            ErrorMessage="Invalid Region Name"
                            CssClass="red paddingPointFiveEMBottom"
                            ValidationExpression="^[A-Z][A-Z]$" />

                <br />

                <!--Region required indicator-->
                <asp:TextBox ID="newRegion" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fullWidth">            
                <!--Country input-->
                <asp:Label ID="newCountryLabel" runat="server" AssociatedControlID="newCountry">Country</asp:Label>
                <asp:RegularExpressionValidator ID="CountryValidator" runat="server" 
                            ControlToValidate="newCountry"
                            ErrorMessage="Invalid Country Name"
                            CssClass="red paddingPointFiveEMBottom"
                            ValidationExpression="^[a-z, A-Z]*$" />

                <br />

                <!--Country required indicator-->
                <asp:TextBox ID="newCountry" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fullWidth">            
                <!--Postal input-->
                <asp:Label ID="newPostalLabel" runat="server" AssociatedControlID="newPostal">Postal Code</asp:Label>

                <br />

                <!--Postal required indicator-->
                <asp:TextBox ID="newPostal" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="fullWidth">            
                <!--Phone input-->
                <asp:Label ID="newPhoneLabel" runat="server" AssociatedControlID="newPhone">Phone #</asp:Label>
                <asp:RegularExpressionValidator ID="PhoneValidator" runat="server" 
                            ControlToValidate="newPhone"
                            ErrorMessage="Invalid Phone Number"
                            CssClass="red paddingPointFiveEMBottom"
                            ValidationExpression="^[^a-z, A-Z]*$" />

                <br />

                <!--Phone required indicator-->
                <asp:TextBox ID="newPhone" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td class="fullWidth">            
                <!--Email input-->
                <asp:Label ID="newEmailLabel" runat="server" AssociatedControlID="newEmail">Email</asp:Label>
                <asp:RegularExpressionValidator ID="EmailValidator" runat="server" 
                            ControlToValidate="newEmail"
                            ErrorMessage="Invalid Email"
                            CssClass="red paddingPointFiveEMBottom"
                            ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" />

                <br />

                <!--Email required indicator-->
                <asp:TextBox ID="newEmail" runat="server" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
            </td>
        </tr>

         <tr>
            <td class="fullWidth">            
                <!--Username input-->
                <asp:Label ID="PrivacyLabel" runat="server" AssociatedControlID="newEmail">Privacy Level</asp:Label>

                <br />

                <!--Username required indicator-->
                <asp:DropDownList ID="newPrivacy" runat="server" CssClass="fullWidth searchBoxBottomMargin">
                    <asp:ListItem Value="0">Not Changed</asp:ListItem>
                    <asp:ListItem Value="2">High</asp:ListItem>
                    <asp:ListItem Value="1">Low</asp:ListItem> 
                </asp:DropDownList>
            </td>
        </tr>

    </table>


            

     

    <!--Modify the customer-->
    <asp:Button ID="ModifyButton" runat="server" Text="Modify Customer" OnClick="ModifyCustomer_OnClick" CssClass="btn btn-primary modifyButton modifyClear" />
            <!-- End Modify Controls -->
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                            ControlToValidate="newPostal"
                                            ErrorMessage="Not a Postal Code"
                                            ValidationExpression="^[A-Z,a-z][0-9]?[A-Z,a-z][' ',-][0-9][A-Z,a-z][0-9]$" />

    </div>


    </div>
 </div>
    
</asp:Content>

