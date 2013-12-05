<%@ Page Title="Home | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Home" %>
<%@ Register Src="~/Controls/RemoveBtn.ascx" TagPrefix="uc" TagName="RemoveBtn" %>
<%@ Register Src="~/Controls/FavWorkBtn.ascx" TagPrefix="uc" TagName="FavWorkBtn" %>
<%@ Register Src="~/Controls/FavArtistBtn.ascx" TagPrefix="uc" TagName="FavArtistBtn" %>



<asp:Content ContentPlaceHolderID="pageContent" runat="server">
    <!--Page header-->
    <h1 class="noTopMargin">Home</h1>

    <!--Image carasel with link to artists, artworks, genres, and subjects-->
    <div id="carousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators" id="bullets">
            <li data-target="#carousel" data-slide-to="0" class="active"></li>
            <li data-target="#carousel" data-slide-to="1"></li>
            <li data-target="#carousel" data-slide-to="2"></li>
            <li data-target="#carousel" data-slide-to="3"></li>
        </ol>

        <!-- Wrapper for slides in carasel-->
        <div class="carousel-inner">
            
            <!--Artist slide-->
            <div class="item active">
                <a href="ArtistList.aspx">
                    <img src="art-images\custom\ArtistMosaic.jpg" alt="Artists">
                    <div class="carousel-caption carouselBG">
                    <span class="carouselTitle">Artists</span>
                    <p class="carouselSub">The Masters Behind the Canvas</p>
                    </div>
                </a>
            </div>
            
            <!--Artwork slide-->
            <div class="item">
                <a href="ArtworkList.aspx">
                    <img src="art-images\custom\ArtworksMosaic.jpg" alt="Artworks">
                    <div class="carousel-caption carouselBG">
                    <span class="carouselTitle">Artworks</span>
                    <p class="carouselSub">Browse Art from Around the World</p>
                    </div>
                </a>
            </div>
            
            <!--Genre slide-->
            <div class="item">
                <a href="GenreList.aspx">
                    <img src="art-images\custom\GenreMosaic.jpg" alt="Genres">
                    <div class="carousel-caption carouselBG">
                    <span class="carouselTitle">Genres</span>
                    <p class="carouselSub">Take a Look at Different Types of Art</p>
                    </div>
                </a>
            </div>

            <!--Subject slide-->
            <div class="item">
                <a href="SubjectList.aspx">
                    <img src="art-images\custom\SubjectMosaic.jpg" alt="Subjects">
                    <div class="carousel-caption carouselBG">
                    <span class="carouselTitle">Subjects</span>
                    <p class="carouselSub">Browse Artwork Subjects</p>
                    </div>
                </a>
            </div> 
        </div>

        <!-- Controls for switching slides-->
        <a class="left carousel-control" href="#carousel" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
        </a>
    
        <a class="right carousel-control" href="#carousel" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
        </a>

</div>



    <br class="clearAll" /> 

    <!--Top Artworks-->
    <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
        <div class="panel-heading">
            <h3 class="panel-title">Top Artworks</h3>
        </div>
                
        <div class="panel-body">
            <!--Prints out all of the related artists-->
            <asp:Repeater ID="topArtWorkRepeater" runat="server">
                <ItemTemplate>
                    <div class="listThumbNail col-xs-12 col-sm-6 col-md-4 col-lg-3 panelGroupMinHeight overFlow">
                        <!--ArtWork image link-->
                            <a class="orange-text" href="SingleArtWork.aspx?id=<%# Eval("Id") %>">
                                <img src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="" class="thumbnail singlePaintingByArtistIMG" />
                                <p class="centerMarginsPanelPara orange-text overFlow"><%# Eval("Title") %></p>
                            </a>
                                    

                            <br />

                        <!--Add to favorites button-->
                        <uc:FavWorkBtn runat="server" id="FavWorkBtn" />


                        <!--End of thumbnail-->
                     </div>
                 </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>



   

    <!--Top Artists-->
    <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
        <div class="panel-heading">
            <h3 class="panel-title">Top Artists</h3>
        </div>
                
        <div class="panel-body">
            <!--Prints out all of the related artists-->
            <asp:Repeater ID="topArtistRepeater" runat="server">
                <ItemTemplate>
                    <div class="listThumbNail col-xs-12 col-sm-6 col-md-4 col-lg-3 panelGroupMinHeight overFlow">
                        <!--ArtWork image link-->
                            <a class="orange-text" href="SingleArtist.aspx?id=<%# Eval("Id") %>">
                                <img src="art-images/artists/square-medium/<%# Eval("Id") %>.jpg" alt="" class="thumbnail singlePaintingByArtistIMG" />
                                <p class="centerMarginsPanelPara orange-text overFlow"><%# Eval("FirstName") %> <%# Eval("LastName") %></p>
                            </a>
                                    

                            <br />

                        <!--Add to favorites button-->
                        <uc:FavArtistBtn runat="server" id="FavArtistBtn" />


                        <!--End of thumbnail-->
                     </div>
                 </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>





    
  
    <!--New Additions-->
    <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
        <div class="panel-heading">
            <h3 class="panel-title">New Additions</h3>
        </div>
                
        <div class="panel-body">
            <!--Prints out all of the related artists-->
            <asp:Repeater ID="newAdditionsRepeater" runat="server">
                <ItemTemplate>
                    <div class="listThumbNail col-xs-12 col-sm-6 col-md-4 col-lg-3 panelGroupMinHeight overFlow">
                        <!--ArtWork image link-->
                            <a class="orange-text" href="SingleArtWork.aspx?id=<%# Eval("Id") %>">
                                <img src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="" class="thumbnail singlePaintingByArtistIMG" />
                                <p class="centerMarginsPanelPara orange-text overFlow"><%# Eval("Title") %></p>
                            </a>
                                    

                            <br />

                            <!--Add to favorites button-->
                            <uc:FavWorkBtn runat="server" id="FavWorkBtn" />
            
                     <!--End of thumbnail-->
                     </div>
                 </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>



    <!--Recent Reviews-->
    <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
        <div class="panel-heading">
            <h3 class="panel-title">Recent Reviews</h3>
        </div>
                

        <div class="panel-body noBottomPadding">
            <!--Prints out recent reviews-->
            <asp:Repeater ID="recentReviews" runat="server">
                <ItemTemplate>

                <!--Panel with review info-->
                <div class="panel panel-default">
                    <div class="panel-heading noMargins leftPadEightPix bold">
                        Review: <a href="SingleArtWork.aspx?id=<%# Eval("ArtworkId") %>" class="orange-text" >
                           <%# Eval("Title") %>
                        </a>
                    </div>  
                    
                        <span class="leftTopMarginEightPix">
                            <uc:RemoveBtn runat="server" id="ReviewInformation" />
                        </span>
                        
                        <!--Table of the artwork image and description-->
                        <table class="table">
                            <tr>
                                <td class="col-xs-2 col-sm-2 col-md-2 col-lg-2" style="border-bottom:none;">        
                                        <a href="SingleArtWork.aspx?id=<%# Eval("ArtworkId") %>">
                                            <img class="noLeftPadding listThumbNail" src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="<%# Eval("Title") %> photo"  />
                                        </a>
                                </td>
                                       
                                <!-- Table formatting for the review info-->
                                <td style="border-bottom:none;">
                                    <table class="table noBottomMargin">
                                        <tbody> 

                                            <!--review name-->
                                            <tr>
                                                <td class="noPaddingLeft" style="padding-left: 0px; border-bottom-width:0px">
                                                    <strong>By: <%# Eval("Reviewer") %></strong>
                                                </td>
                                            </tr>

                                            <td class="noPaddingLeft" style="padding-left: 0px; border-bottom-width: 0px;">
                                                                <strong>Date: <%# Eval("ReviewDate") %></strong>
                                                            </td>       
                                            
                                            <!--review rating-->      
                                            <tr>
                                                <td class="noPaddingLeft" style="padding-left: 0px; border-bottom-width:0px">
                                                    <strong>Rating: <%# Eval("Rating") %>/5</strong>
                                                </td>
                                            </tr>       
                                            
                                            <!--review text-->                              
                                            <tr>
                                                <td class="noPaddingLeft" style="padding-left: 0px; border-bottom-width:0px;">
                                                   <div class="reviewScroll"><%# Eval("Comment") %></div>
                                                </td>
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

