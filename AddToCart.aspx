<%@ Page Title="Add To Cart | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddToCart.aspx.cs" Inherits="AddToCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    
    <!--Page header-->
    <h1 class="noTopMargin">Add To Cart <span class="glyphicon glyphicon-shopping-cart blueLinks"></span></h1>

    <asp:DataList ID="selectedArtWork" runat="server">
        <ItemTemplate>

            <!--Painting being added to cart name link and artist of the painting name and link-->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="noTopMargin noBottomMargin"><a href="SingleArtwork.aspx?id=" class="orange-text panel-title"><%# Eval("Title") %></a></h3>
                    <p class="noBottomMargin">By: <a class="orange-text" href="SingleArtist.aspx?id=<%# Eval("TheArtistId") %>"><%# Eval("ArtistFirstName") %> <%# Eval("ArtistLastName") %></a></p> 
                </div>
                
                <!--Page content-->        
                <div class="panel-body">

                  <!-- Table -->
                  <table class="table noBottomMargin">
                    <tr>
                        <!--Image link of painting being added to cart-->
                        <td class="col-xs-2 col-sm-2 col-md-2 col-lg-2 noPadding" style="border-bottom:none; padding:0px;">        
                            <a href="SingleArtwork.aspx?id=<%# Eval("Id") %>"><img class="noLeftPadding listThumbNail" src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="photo"  /></a>
                        </td>
                                       
                        <!-- Table for some relevant artist info-->
                        <td style="border-bottom:none;">
                            <table class="table">
                                <tbody>                                            
                                    <tr>
                                        <!--Painting description-->
                                        <td class="noPaddingLeft" style="padding-left: 0px; padding-top:0px; border-bottom-width:0px">
                                            <%# Eval("Description") %>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                   </table>  
                </div>
            </div
        </ItemTemplate>
    </asp:DataList>


    <!--Matt drop down selection container-->
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Matt</h3>
        </div>
                        
        <div class="panel-body">
            <!--Matt drop down menu-->
            <asp:DropDownList runat="server" ID="mattList" CssClass="fullWidth" AutoPostBack="true"></asp:DropDownList>

            <br />

            <!--Pricing of the Matt option-->
            <asp:Image runat="server" CssClass="colourPicker" ID="mattColor" />

            <strong>Price: $</strong><asp:Label ID="mattPrice" runat="server" />

        </div>

    </div>


    <!--Glass drop down selection container-->
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Glass</h3>
        </div>
                        
        <div class="panel-body">
            <!--Glass drop down menu-->
            <asp:DropDownList runat="server" ID="glassList" CssClass="fullWidth" AutoPostBack="true"></asp:DropDownList>

            <br />

            <!--Pricing of the Glass option-->
            <strong>Description: </strong><asp:Label ID="glassDescription" runat="server" /><br />
            <strong>Price: $</strong><asp:Label ID="glassPrice" runat="server" />
        
        </div>

        
    </div>


    <!--Frame drop down selection-->
    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Frame</h3>
        </div>
                        
        <div class="panel-body">
            <!--Frame drop down menu-->
            <asp:DropDownList runat="server" ID="frameList" CssClass="fullWidth" AutoPostBack="true"></asp:DropDownList>

            <br />
            
            <strong>Color: </strong><asp:Label ID="frameColor" runat="server" /><br />
            <strong>Syle: </strong><asp:Label ID="frameSyle" runat="server" /><br />
            <strong>Price: $</strong><asp:Label ID="framePrice" runat="server" />
        </div>
</div>
                                    
    <!--Submit Paitning to Add to Cart button-->
    <asp:Button ID="CartButton" runat="server" Text="Add To My Cart" OnClick="AddArtworkCart_OnClick" CssClass="btn btn-primary" /> 

    <br />

</asp:Content>

