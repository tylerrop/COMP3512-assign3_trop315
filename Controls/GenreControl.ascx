<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GenreControl.ascx.cs" Inherits="GenreControl" %>

<asp:Repeater ID="genreData" runat="server">
    <HeaderTemplate>
        <tr class="col-xs-12 col-sm-12 col-md-12">
            <td class="col-sm-3 boldText noBottomPadding">Genre:</td>
            <td class="col-sm-3 noBottomPadding">
                <ul class="panelList noBottomPadding noBottomMargin">
    </HeaderTemplate>

                <ItemTemplate>
                    <li><a href="SingleGenre.aspx?id=<%# Eval("Id") %>&genre=1" class="orange-text"><%# Eval("GenreName")%></a></li>
                </ItemTemplate>

    <FooterTemplate>
                </ul>
            </td>
        </tr>
    </FooterTemplate>
</asp:Repeater>
