<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FavWorkBtn.ascx.cs" Inherits="FavWorkBtn" %>

<!--Add to favorites button-->
<asp:LinkButton runat="server" CssClass="btn btn-default blueLinks bottom  fullWidth" ID="addFavButton" OnClick="AddArtworkFav_OnClick" CommandArgument='<%# Eval("Id") %>'>
    <span class="glyphicon glyphicon-heart blueLinks"></span> Add to Favorites
</asp:LinkButton>