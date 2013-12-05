<%@ Page Title="Login | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <!--Page caption-->
    <h1 class="noTopMargin">Log In</h1>

    <!--Custom layout for user login-->
    <asp:Login ID="aLogin" runat="server" TitleTextStyle-CssClass="displayNone" CssClass="col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftPadding">
     <LayoutTemplate>
        
        <!--This table diplsays texts boxes for the user to input their username and password--> 
        <table class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
           <tr>
                <td class="fullWidth">

                    <!--User Name-->
                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
                                
                        <br />
                                
                        <!--Input for username-->
                        <asp:TextBox id="UserName" runat="server" CssClass="fullWidth"></asp:TextBox>
                        
                        <!--Username required indicator-->
                        <asp:requiredfieldvalidator id="UserNameRequired" runat="server" ControlToValidate="UserName" Text="*"></asp:requiredfieldvalidator>
                 </td>
            </tr>

            <tr>
                <td class="fullWidth">

                    <!--Password-->
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="UserName">Password</asp:Label>
                                
                        <br />
                                
                       <!--Input for password-->
                       <asp:TextBox id="Password" runat="server" textMode="Password" CssClass="fullWidth"></asp:TextBox>
                       
                       <!--Password required indicator-->
                       <asp:requiredfieldvalidator id="PasswordRequired" runat="server" ControlToValidate="Password" Text="*"></asp:requiredfieldvalidator>
                 </td>
             </tr>
             

             <tr>
                 <td class="fullWidth">
                     
                     <!--Login button-->                                    
                     <asp:button id="Login" CommandName="Login" runat="server" Text="Login" CssClass="btn"></asp:button>
                     
                     <br />
                     <br />   

                     <!--Error message text-->
                     <asp:Literal id="FailureText" runat="server"></asp:Literal>

                 </td>
             </tr>
            </table>
        </LayoutTemplate>
    </asp:Login>

</asp:Content>

