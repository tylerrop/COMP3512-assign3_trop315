<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SortControl.ascx.cs" Inherits="Controls_SortControl" %>
<%@ Register Src="~/Controls/FavWorkBtn.ascx" TagPrefix="uc" TagName="FavWorkBtn" %>
<%@ Register Src="~/Controls/FavArtistBtn.ascx" TagPrefix="uc" TagName="FavArtistBtn" %>

<asp:Label ID="errorMessage" runat="server" />

<!--REPEATER THAT SHOWS ARTIST SEARH RESULTS-->
<asp:Repeater runat="server" ID="displaySearchArtists">
    <HeaderTemplate>
        <h2>Artists</h2>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftPadding">
            <!--Panel for ArtistWork Details-->
            <div class="panel panel-default">
                <div class="panel-heading noMargins leftPadEightPix bold">
                    <a class="orange-text" href="SingleArtist.aspx?id=<%# Eval("Id") %>">
                        <%# Eval("FirstName") %> <%# Eval("LastName") %>
                    </a>
                </div>

                <!-- Table -->
                <table class="table">
                    <tr>
                        <td class="col-xs-2 col-sm-2 col-md-2 col-lg-2" style="border-bottom: none;">
                            <a href="SingleArtist.aspx?id=<%# Eval("Id") %>">
                                <img class="noLeftPadding listThumbNail" src="art-images/artists/square-medium/<%# Eval("Id") %>.jpg" alt="<%# Eval("FirstName") %> <%# Eval("LastName") %> photo" />
                            </a>
                        </td>

                        <!-- Table for some relevant artist info-->
                        <td style="border-bottom: none;">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <td class="noPaddingLeft" style="padding-left: 0px;">
                                            <%# Eval("Details") %>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="btn-group noLeftMargin">
                                <!--Favorites button-->
                                <uc:FavArtistBtn runat="server" id="FavArtistBtn" />
                            </div>

                        </td>
                    </tr>
                </table>
                <!--End of panel panel-default-->
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<!--REPEATER THAT SHOWS WORKS SEARH RESULTS-->
<asp:Repeater runat="server" ID="displaySearchWorks">
    <HeaderTemplate>
        <h2>Works</h2>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftPadding">
            <!--Panel for ArtWork Details-->
            <div class="panel panel-default">
                <div class="panel-heading noMargins leftPadEightPix bold">
                    <a class="orange-text" href="SingleArtwork.aspx?id=<%# Eval("Id") %>">
                        <%# Eval("Title") %>
                    </a>
                </div>

                <!-- Table -->
                <table class="table">
                    <tr>
                        <td class="col-xs-2 col-sm-2 col-md-2 col-lg-2" style="border-bottom: none;">
                            <a href="SingleArtwork.aspx?id=<%# Eval("Id") %>">
                                <img class="noLeftPadding listThumbNail" src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="<%# Eval("Title") %> photo" />
                            </a>
                        </td>

                        <!-- Table for some relevant artist info-->
                        <td style="border-bottom: none;">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <td class="noBottomBorder" style="padding-left: 0px; border-bottom: none; margin-bottom: 0; padding-bottom: 0; padding-top: 0;">
                                            <h5>By: <a class="orange-text" href="SingleArtist.aspx?id=<%# Eval("TheArtistID") %>"><%# Eval("ArtistFirstName") %> <%# Eval("ArtistLastName") %></a></h5>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="noBottomBorder" style="padding-left: 0px;"><%# Eval("Description") %></td>
                                    </tr>
                                </tbody>
                            </table>
                            <!--add to favorites and cart buttons-->
                            <div class="btn-group noLeftMargin">
                                <!--Add to favorites button-->
                                <uc:FavWorkBtn runat="server" id="FavWorkBtn" />
                            </div>

                        </td>
                    </tr>
                </table>
                <!--End of panel panel-default-->
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

<!--REPEATER THAT SHOWS WORKS OF A SUBJECT-->
<asp:Repeater runat="server" ID="displaySubjects">
    <ItemTemplate>
        <div class="listThumbNail col-xs-12 col-sm-6 col-md-4 col-lg-3 panelGroupMinHeight">
            <!--Item template-->
            <!--ArtWork image-->
            <a href="SingleArtWork.aspx?id=<%# Eval("Id") %>"">
                <img src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="<%# Eval("Id") %>" class="thumbnail singlePaintingByArtistIMG" />
                <p class="centerMarginsPanelPara orange-text overFlow"><%# Eval("Title") %></p>
            </a>

            <br />

            <!--Add to favorites button-->
            <uc:FavWorkBtn runat="server" id="FavWorkBtn" />
        <!--End of thumbnail-->
        </div>
    </ItemTemplate>
</asp:Repeater>

<!--REPEATER THAT SHOWS WORKS OF A GENRE-->
<asp:Repeater runat="server" ID="displayGenres">
    <ItemTemplate>
        <div class="listThumbNail col-xs-12 col-sm-6 col-md-4 col-lg-3 panelGroupMinHeight">
            <!--Item template-->
            <!--ArtWork image-->
            <a href="SingleArtWork.aspx?id=<%# Eval("Id") %>"">
                <img src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="<%# Eval("Id") %>" class="thumbnail singlePaintingByArtistIMG" />
                <p class="centerMarginsPanelPara orange-text overFlow"><%# Eval("Title") %></p>
            </a>

            <br />

            <!--Add to favorites button-->
            <uc:FavWorkBtn runat="server" id="FavWorkBtn" />
        <!--End of thumbnail-->
        </div>
    </ItemTemplate>
</asp:Repeater>