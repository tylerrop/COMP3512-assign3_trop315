<%@ Page Title="Write Review | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WriteReview.aspx.cs" Inherits="WriteReview" %>


<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    
    <!--Page header-->
    <asp:DataList runat="server" ID="reviewTitle">       
        <ItemTemplate>
            <h1 class="noTopMargin">Rate and Review <a class="orange-text" href="SingleArtwork.aspx?id=<%# Eval("id") %>"><%# Eval("Title") %></h1></a>
        </ItemTemplate>
    </asp:DataList>
    
         <table class="fullWidth">
             <tr>
                <td class="fullWidth">
                    <!--Rating Label-->
                    <p><strong>Rating (Out of 5)</strong></p>

                    <!--Rating required indicator-->
                    <asp:DropDownList ID="ratingDropDown" runat="server" CssClass="fullWidth searchBoxBottomMargin">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem> 
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td class="fullWidth"> 
                               
                    <!--Review Label-->
                    <p><strong>Review</strong></p>

                    <!--Review-->
                    <asp:TextBox ID="reviewBox" runat="server" Placeholder="Write your review here..." TextMode="MultiLine" Height="12em" CssClass="fullWidth searchBoxBottomMargin"></asp:TextBox>
                </td>
            </tr>
        </table>

    <asp:Button ID="ReviewButton" runat="server" Text="Write Review" OnClick="AddReview_OnClick" CssClass="btn btn-primary" />

    <br />

    <asp:label id="message" runat="server" />

</asp:Content>

