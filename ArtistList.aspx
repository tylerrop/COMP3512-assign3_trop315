<%@ Page Title="Artists | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtistList.aspx.cs" Inherits="ArtistList" %>
<%@ Register Src="~/Controls/FavArtistBtn.ascx" TagPrefix="uc" TagName="FavArtistBtn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">

    <!--Page title-->
    <h1 class="noTopMargin">Artists</h1>
    
    <!--Prints out all of the artists into a formatted list-->
    <asp:Repeater ID="artistList" runat="server" >
        <ItemTemplate>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6 noLeftPadding">   
                
                <!--Panel for ArtistWork Details-->
                <div class="panel panel-default listedDivMinHeight">

                    <!--Artist Name link-->
                    <div class="panel-heading noMargins leftPadEightPix bold"><a class="orange-text" href="SingleArtist.aspx?id=<%# Eval("ID") %>"><%# Eval("FirstName") %> <%# Eval("LastName") %></a></div>          
                        
                        <!--Displays the image of the artist and some general info about them-->
                        <table class="table">
                            <tr>
                                <td class="col-xs-2 col-sm-2 col-md-2 col-lg-2" style="border-bottom:none;">
                                    <!--Artist image link-->
                                    <a href="SingleArtist.aspx?id=<%# Eval("ID") %>">
                                        <img class="noLeftPadding listThumbNail" src="art-images/artists/square-medium/<%# Eval("ID") %>.jpg" alt="<%# Eval("FirstName") %> <%# Eval("LastName") %> photo"  />
                                    </a>
                                </td>
                                       
                                <!--Artist info-->
                                <td style="border-bottom:none;">
                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <td class="bold">Nationality:</td>
                                                <td><%# Eval("Nationality")%></td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="bold">Birth:</td>
                                                <td><%# Eval("YearOfBirth")%></td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="bold">Death:</td>
                                                <td><%# Eval("YearOfDeath")%></td>
                                            </tr>
                                      </tbody>
                                    </table>

                                    <!--Favorites button-->
                                    <uc:FavArtistBtn runat="server" id="FavArtistBtn" />
                                   
                                </td>
                            </tr>
                        </table>  
                 <!--End of panel panel-default-->
                 </div>
            </div>
           
           </ItemTemplate>
      </asp:Repeater>
</asp:Content>

