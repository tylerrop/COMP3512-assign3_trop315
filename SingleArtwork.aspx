<%@ Page Title="Single Artwork | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleArtwork.aspx.cs" Inherits="SingleArtwork" %>

<%@ Register Src="~/Controls/GenreControl.ascx" TagPrefix="uc1" TagName="GenreControl" %>
<%@ Register Src="~/Controls/SubjectControl.ascx" TagPrefix="uc1" TagName="SubjectControl" %>
<%@ Register Src="~/Controls/PurchasesControl.ascx" TagPrefix="uc" TagName="PurchasesControl" %>
<%@ Register Src="~/Controls/RelatedArtworksControl.ascx" TagPrefix="uc" TagName="RelatedArtworksControl" %>
<%@ Register Src="~/Controls/GalleryControl.ascx" TagPrefix="uc" TagName="GalleryControl" %>
<%@ Register Src="~/Controls/FavWorkBtn.ascx" TagPrefix="uc" TagName="FavWorkBtn" %>
<%@ Register Src="~/Controls/RemoveBtn.ascx" TagPrefix="uc" TagName="RemoveBtn" %>



<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <asp:DataList ID="artWorkDetails" class="col-xs-12 col-sm-12 col-md-12 col-lg-12" runat="server">
            <ItemTemplate>

                <!--Artwork title as Page Header-->
                <h1 class="noTopMargin"><%# Eval("Title") %></h1>

                <!--Link of the Painter of the artwork-->
                <h4>By: <a class="orange-text" href="SingleArtist.aspx?id=<%# Eval("TheArtistID") %>"><%# Eval("ArtistFirstName") %> <%# Eval("ArtistLastName") %></a></h4>


                <!--ArtWork Picture trigger modal -->
                <a data-toggle="modal" href="#myModal">
                    <!-- ARTIST IMAGE -->                
                    <img src="art-images/works/medium/<%# Eval("ImageFileName") %>.jpg" alt="<%# Eval("Title") %> photo"  class="noLeftPadding col-xs-12 col-sm-5 col-md-4 col-lg-3 artistPicSpacing"/>
                </a>

                <!-- Modal for enlarged ArtWork image link -->
                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title"><%# Eval("Title") %> by <a class="orange-text" href="SingleArtist.aspx?id=<%# Eval("TheArtistID") %>" ><%# Eval("ArtistFirstName") %> <%# Eval("ArtistLastName") %></a></h4>
                            </div>
                                
                            <div class="modal-body">
                                <img src="art-images/works/large/<%# Eval("ImageFileName")%>.jpg" alt="<%# Eval("Title")%>" class="modalPic"/>
                            </div>
                                
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div><!-- /.modal-content -->
                   </div><!-- /.modal-dialog -->
                </div><!-- /.modal -->
                


                <!--Artwork Description-->
                <div class="noLeftPadding col-xs-12 col-sm-12 col-md-5 col-lg-9">
                    <!--Artist Description-->
                    <p><%# Eval("Description") %></p>
                <!--/lg-5-->
                </div>



                <div class="noLeftPadding col-xs-12 col-sm-12 col-md-8 col-lg-9">
                    <!--Favorite and Panel-->
                    <!--add to favorites and cart buttons-->
                    <div class="btn-group noLeftMargin">

                        <!--Favorite button-->
                        <span class="btn noPadding"><uc:FavWorkBtn runat="server" id="FavWorkBtn" /></span>

                        <!--Add to cart redirect-->
                        <a href="AddToCart.aspx?id=<%# Eval("Id") %>" Class="btn btn-default" ID="addCartButton" >
                            <span class="glyphicon glyphicon-shopping-cart"></span> Add to Cart
                        </a>

                        <!-- Write Review -->
                        <a ID="writeReviewBtn" href="WriteReview.aspx?id=<%# Eval("Id") %>" Class="btn btn-default" >
                            <span class="glyphicon glyphicon-pencil"></span> Write a Review
                        </a>
                    </div>
                    
                    <br />
                    <br />

                    <!--Drop down accordian with Gallery information-->
                    <uc:GalleryControl ID="GalleryControl1" runat="server" />

                    <!--Panel for Artwork Details-->
                    <div class="panel panel-default clearLeft">
                        <div class="panel-heading noMargins boldText leftPadEightPix bold">Painting Details</div>
                                
                                <!-- Table -->
                                <table class="table">
                                    <!--Rating-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Average Rating:</td>
                                        <td class="col-sm-3"><%# Eval("AvgReview") %>/5</td>
                                    </tr>
                                    <!--Year-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Year:</td>
                                        <td class="col-sm-3"><%# Eval("YearOfWork") %></td>
                                    </tr>

                                    <!--Width Height-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Width x Height:</td>
                                        <td class="col-sm-3"><%# Eval("Width") %> cm x <%# Eval("Height") %> cm</td>
                                    </tr>

                                    <!--Medium-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Medium:</td>
                                        <td class="col-sm-3"><%# Eval("Medium") %></td>
                                    </tr>

                                    <!--Prints out the Genres of the artwork-->
                                    <uc1:GenreControl runat="server"/>

                                    <!--Prints out the Subjects of the artwork-->
                                    <uc1:SubjectControl runat="server"/>

                                    <!--MSRP-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">MSRP:</td>
                                        <td class="col-sm-3"><%# Eval("MSRP", "{0:C}") %></td>
                                    </tr>

                                    <!--Wikipedia Link-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText ">Artwork Link:</td>
                                        <td class="col-sm-3 overFlow"><a class="orange-text" href="<%# Eval("ArtWorkLink") %>"><%# Eval("Title") %> on Wikipedia</a></td>
                                    </tr>

                                    <!--Google Link-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText ">Google:</td>
                                        <td class="col-sm-3 overFlow"><a class="orange-text" href="<%# Eval("GoogleLink") %>">Search for <%# Eval("Title") %> on Google</a></td>
                                    </tr>
                                </table>
                                
                            <!--End of panel panel-default-->
                            </div>
                    <!--./noLeftPadding col-md-6 col-lg-6-->   
                    </div>
                    
                 </ItemTemplate>
            </asp:DataList>
            

             
            <br class="clearAll" />



            <!--Related Paintings-->
            <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
                <div class="panel-heading">
                <h3 class="panel-title">Related Paintings</h3>
                </div>
                
                <div class="panel-body">
                     <!--Prints out all of the related artworks-->
                     <uc:RelatedArtworksControl ID="relatedArtworksControl" runat="server" />
                </div>
            </div>

            <!--Other Purchased Paintings-->
            <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
                <div class="panel-heading">
                <h3 class="panel-title">Customers Who Bought This Also Bought</h3>
                </div>
                
                <div class="panel-body">
                     <!--Prints out all of the related purchases-->
                     <uc:PurchasesControl ID="purchasesControl" runat="server" />
                </div>
            </div>

            <!--Reviews-->
            <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
                <div class="panel-heading">
                    <h3 class="panel-title">Reviews</h3>
                </div>
                
                <div class="panel-body">
                    <!--Prints out reviews of the artwork-->
                    <asp:Repeater ID="reviews" runat="server">
                        <ItemTemplate>
                            <!--Panel with review info-->
                                <div class="panel panel-default">
                                    <div class="panel-heading noMargins leftPadEightPix bold">
                                       By: <%# Eval("Reviewer") %>
                                    </div>  
                            
                                    <!--Table of the artwork image and description-->
                                    <table class="table">
                                        <tr>
                                            <!-- Table formatting for the review info-->
                                            <td style="border-bottom:none;">
                                                <table class="table noBottomMargin">
                                                    <tbody> 
                                                        <tr>
                                                            <td class="noPaddingLeft" style="padding-left: 0px; border-bottom-width: 0px; padding-bottom:0px;">
                                                                <strong>Date: <%# Eval("ReviewDate") %></strong>
                                                            </td>
                                                        </tr>

                                                        <!--review rating-->
                                                        <tr>
                                                            <td class="noPaddingLeft" style="padding-left: 0px; border-bottom-width: 0px">
                                                                <strong>Rating: <%# Eval("Rating") %>/5</strong>
                                                            </td>
                                                        </tr>

                                                        <!--review text-->
                                                        <tr>
                                                            <td class="noPaddingLeft" style="padding-left: 0px; border-bottom-width: 0px;">
                                                                <div class="reviewScroll"><%# Eval("Comment") %></div>
                                                            </td>
                                                        </tr>
                                                         
                                                        <!--Remove Btn-->
                                                        <tr>
                                                            <uc:RemoveBtn runat="server" id="ReviewInformation" />
                                                        </tr>

                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>  
                             <!--End of panel panel-default-->
                             </div>
                         </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
</asp:Content>