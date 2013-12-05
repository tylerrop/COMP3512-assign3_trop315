<%@ Page Title="Artworks | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtworkList.aspx.cs" Inherits="ArtworkList" %>
<%@ Register Src="~/Controls/FavWorkBtn.ascx" TagPrefix="uc" TagName="FavWorkBtn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    
    <!--Page title-->
    <h1 class="noTopMargin">Artworks</h1>   

    <!--Prints out all of the artworks-->
    <asp:Repeater ID="artworkList" runat="server" >
        <ItemTemplate>

            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-6 noLeftPadding listedDivMinHeight">   
                
                <!--Panel for ArtWork Details-->
                <div class="panel panel-default listedDivMinHeight">
                    <div class="panel-heading noMargins leftPadEightPix bold">
                        <!--Painting link to single page-->
                        <a class="orange-text" href="SingleArtwork.aspx?id=<%# Eval("Id") %>"><%# Eval("Title") %></a></div>          
                        
                        <!-- Table -->
                        <table class="table">
                            <tr>
                                <td class="col-xs-2 col-sm-2 col-md-2 col-lg-2 noBottomBorder" style="border-bottom:none;">
                                    <!--Artwork image link to single page-->
                                    <a href="SingleArtwork.aspx?id=<%# Eval("Id") %>">
                                        <img class="noLeftPadding listThumbNail" src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="<%# Eval("Title") %>"  />
                                    </a>
                                </td>
                                       
                                <!--Relevant artwork info-->
                                <td class="noBottomBorder" style="border-bottom:none;">
                                    <table class="table">
                                        <tbody">
                                            <tr>
                                                <td class="bold">Year:</td>
                                                <td><%# Eval("YearOfWork")%></td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="bold">Medium:</td>
                                                <td><%# Eval("Medium")%></td>
                                            </tr>
                                      </tbody>
                                    </table>

                                    <!--add to favorites button-->
                                    
                                        <!--Add to favorites button-->
                                        <uc:FavWorkBtn runat="server" id="FavWorkBtn" />
                                   
                                </td>
                            </tr>
                        </table>  
                 <!--End of panel panel-default-->
                 </div>
            </div>
           </ItemTemplate>
      </asp:Repeater>
</asp:Content>

