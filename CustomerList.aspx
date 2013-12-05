<%@ Page Title="Existing Customers | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CustomerList.aspx.cs" Inherits="CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
   
    <!--Page header-->
    <h1 class="noTopMargin">Existing Customers</h1>

    <!-- List all Customers -->
    <asp:Repeater runat="server" ID="customerList">
        <ItemTemplate>


            <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 noLeftPadding overFlow">   
                
                <!--Panel for Customer Details-->
                <div class="panel panel-default mofidyUsersSize">
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
                                                <td style="border-bottom:none; padding-left:0; padding-bottom:0;">
                                                    <a href="ModifyCustomer.aspx?id=<%# Eval("Id") %>" class="btn btn-primary">Modify</a>
                                                </td>
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
    <!-- End Customer List  -->
</asp:Content>

