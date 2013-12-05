<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RelatedArtistsControl.ascx.cs" Inherits="RelatedArtistsControl" %>
<%@ Register Src="~/Controls/FavArtistBtn.ascx" TagPrefix="uc" TagName="FavArtistBtn" %>

<asp:Repeater ID="relatedArtistsRepeater" runat="server">
    <ItemTemplate>
        <!--EXTRA, cut out once repeater is made-->
                    <div class="listThumbNail col-xs-12 col-sm-6 col-md-4 col-lg-3 panelGroupMinHeight">
                        <a href="SingleArtist.aspx?id=<%# Eval("Id") %>">
                            <img src="art-images/artists/square-medium/<%# Eval("Id") %>.jpg" class="thumbnail singlePaintingByArtistIMG" />
                            <p class="centerMarginsPanelPara orange-text overFlow"><%# Eval("FirstName") %> <%# Eval("LastName") %></p>
                        </a>
                        
                        <br />

                        <!--Favorites button-->
                        <uc:FavArtistBtn runat="server" id="FavArtistBtn" />
                    </div>
    </ItemTemplate>
</asp:Repeater>