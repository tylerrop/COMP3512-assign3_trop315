<%@ Page Title="Single Artist | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleArtist.aspx.cs" Inherits="SingleArtist" %>
<%@ Register Src="~/Controls/RelatedArtistsControl.ascx" TagPrefix="uc" TagName="RelatedArtists" %>
<%@ Register Src="~/Controls/ArtistPaintingsControl.ascx" TagPrefix="uc" TagName="ArtistPaintings" %>
<%@ Register Src="~/Controls/FavArtistBtn.ascx" TagPrefix="uc" TagName="FavArtistBtn" %>


<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <asp:DataList ID="artistDetails" Cssclass="col-xs-12 col-sm-12 col-md-12 col-lg-12" runat="server" >
        <ItemTemplate>

            <!--Page header-->
            <h1 class="noTopMargin"><%# Eval("FirstName") %> <%# Eval("LastName") %></h1>

                <!--Artist image-->                
                <img src="art-images/artists/medium/<%# Eval("ID") %>.jpg" alt="<%# Eval("FirstName") %> <%# Eval("LastName") %> photo"  class="noLeftPadding col-xs-12 col-sm-5 col-md-4 col-lg-3 artistPicSpacing"/>
              
                <!--Artist Details-->
                <div class="noLeftPadding col-xs-12 col-sm-12 col-md-5 col-lg-9">
                    <!--Artist Description-->
                    <p><%# Eval("Details") %></p>
                <!--/lg-5-->
                </div>              
                
               

                <div class="noLeftPadding col-sm-11 col-md-8 col-lg-9">
                    <!--Favorite and Panel-->
                    <!--Favorites button-->
                    <span class="btn noPadding"><uc:FavArtistBtn runat="server" id="FavArtistBtn" /></span>
                    
                    <br />
                    <br />

                    <!--Panel for Artist Details-->
                    <div class="panel panel-default">
                        <div class="panel-heading noMargins boldText leftPadEightPix bold">Artist Details</div>
                                
                                <!-- Table -->
                                <table class="table">
                                    <!--Date-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Date:</td>
                                        <td class="col-sm-3"><%# Eval("YearOfBirth")%> - <%# Eval("YearOfDeath")%></td>
                                    </tr>

                                    <!--Nationality-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText">Nationality:</td>
                                        <td class="col-sm-3"><%# Eval("Nationality")%></td>
                                    </tr>

                                    <!--Wikipedia Link-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText ">More Info:</td>
                                        <td class="col-sm-3 overFlow"><a class="orange-text" href="<%# Eval("ArtistLink")%>"><%# Eval("FirstName") %> <%# Eval("LastName") %> on Wikipedia</a></td>
                                    </tr>
                                </table>
                                
                            <!--End of panel panel-default-->
                            </div>
                <!--./noLeftPadding col-md-6 col-lg-6-->   
                </div>

        </ItemTemplate>
    </asp:DataList>       
    
                
            <br class="clearAll" />

             <!--Paintings by the artist-->   
             <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
                <div class="panel-heading">
                    <h3 class="panel-title">Paintings</h3>
                </div>
                
                <div class="panel-body">
                     <!--Prints out all of the related artists-->
                    <uc:ArtistPaintings runat="server" ID="ArtistPaintings1" />
                </div>
            </div>
                        
            <!--Related Artists-->
            <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
                <div class="panel-heading">
                <h3 class="panel-title">Related Artists</h3>
                </div>
                
                <div class="panel-body">
                     <!--Prints out all of the related artists-->
                     <uc:RelatedArtists ID="a1" runat="server" />
                </div>

            </div>

           

</asp:Content>

