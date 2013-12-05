<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PurchasesControl.ascx.cs" Inherits="Controls_PurchasesControl" %>
<%@ Register Src="~/Controls/FavWorkBtn.ascx" TagPrefix="uc" TagName="FavWorkBtn" %>

<asp:Repeater ID="relatedPurchasesRepeater" runat="server">
    <ItemTemplate>
        <!--EXTRA, cut out once repeater is made-->
                    <div class="listThumbNail col-xs-12 col-sm-6 col-md-4 col-lg-3 panelGroupMinHeight">
                        <a href="SingleArtwork.aspx?id=<%# Eval("Id") %>">
                            <img src="art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" class="thumbnail singlePaintingByArtistIMG" />
                            <p class="centerMarginsPanelPara overFlow orange-text"><%# Eval("Title") %></p>
                        </a>
                        
                        <br />

                        <!--Add to favorites button-->
                        <uc:FavWorkBtn runat="server" id="FavWorkBtn" />
                    </div>
    </ItemTemplate>
</asp:Repeater>