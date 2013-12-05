<%@ Page Title="Register | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">

    <h1 class="noTopMargin">Register</h1>

    <asp:CreateUserWizard ID="CreateUserWizard1" 
                          Runat="server" 
                          CssClass="col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftPadding" 
                          LoginCreatedUser="true" 
                          CreateUserButtonStyle-CssClass="btn btn-primay square"
                          ContinueDestinationPageUrl="Default.aspx"
                          CellPadding="0"
                          CellSpacing="0"
        >
        
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                 
                 <ContentTemplate>

                    <table class="fullWidth">
                        <tr>
                            <td class="fullWidth">
                                <!--Username label-->
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name</asp:Label>
                                
                                <br />
                                
                                <!--Username input-->
                                <asp:TextBox ID="UserName" runat="server" CssClass="fullWidth"></asp:TextBox>

                                <!--Username required indicator-->
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>


                        <tr class="fullWidth">
                            <td class="fullWidth">
                                <!--Password label-->
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password</asp:Label>
                                
                                <br />

                                <!--Password input-->
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="fullWidth"></asp:TextBox>

                                <!--Password required indicator-->
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        
                        <tr class="fullWidth">
                            <td class="fullWidth">
                                <!--Confirm Password label-->
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password</asp:Label>
                                
                                <br />

                                <!--Confirm Password input-->
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="fullWidth"></asp:TextBox>

                                <!--Confirm Password required indicator-->
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                    ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>


                        <tr class="fullWidth">
                            <td class="fullWidth">
                                <!--E-mail label-->
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail</asp:Label>
                            
                                <br />

                                <!--Email iput-->
                                <asp:TextBox ID="Email" runat="server" CssClass="fullWidth"></asp:TextBox>

                                <!--Email required indicator-->
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                    ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>



                        <tr class="fullWidth">
                            <td class="fullWidth">
                                <!--Security question label-->
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question</asp:Label>
                                
                                <br />

                                <!--Security question input-->
                                <asp:TextBox ID="Question" runat="server" CssClass="fullWidth"></asp:TextBox>

                                <!--Security question required indicator-->
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                    ErrorMessage="Security question is required." ToolTip="Security question is required."
                                    ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>



                        <tr class="fullWidth">
                            <td class="fullWidth">
                                <!--Security answer label-->
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer</asp:Label>
                            
                                <br />

                                <!--Answer input-->
                                <asp:TextBox ID="Answer" runat="server" CssClass="fullWidth"></asp:TextBox>

                                <!--Answer required indicator-->
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                    ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                                    ValidationGroup="CreateUserWizard1" >*</asp:RequiredFieldValidator>
                            </td>
                        </tr>


                        <tr class="fullWidth">
                            <td>
                                <!--Password comparision error messages-->
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="color: red">
                                <!--Error message-->
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>

            </asp:CreateUserWizardStep>




            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">

                <ContentTemplate>
                    <!--indication of cmopleted registration-->
                    <div class="col-lg-12 noLeftPadding">
                        <p>Registration Complete</p>
                        <p>Your account has been successfully created.</p>

                        <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                Text="Continue" CssClass="btn" ValidationGroup="CreateUserWizard1" />
                    </div>

                   
                </ContentTemplate>

            </asp:CompleteWizardStep>
        
        
        </WizardSteps>
    </asp:CreateUserWizard>

    <asp:Label ID="ErrorMessage" runat="server"/>
</asp:Content>

