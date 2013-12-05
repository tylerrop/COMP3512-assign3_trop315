<%@ Page Title="Favorites | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFav.aspx.cs" Inherits="ViewFav" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">

<!--Page header-->
<h1 class="noTopMargin">Favorites</h1>

<div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 noLeftPadding">

    <!--Artworks Favorites list-->
    <h2 class="noTopMargin">Artworks</h2>
         <!--Prints out all favorited artworks-->
         <asp:GridView ID="artworkGrid" 
                       runat="server"
                       BackColor="White"
                       AllowPaging="false"
                       AutoGenerateColumns="false" 
                       CssClass="col-xs-12 col-sm-12 col-md-12 col-lg-12 searchGrid searchResultsGrid noBorder"
                       GridLines="None"
                       RowStyle-BorderStyle="Solid"
                       RowStyle-BorderWidth="1px"
                       RowStyle-BorderColor="#dddddd"
                       RowStyle-VerticalAlign="Middle"
                       ShowHeader="false"
                       DataKeyNames="Id" 
                       OnRowCommand="artwork_RowCommand">

            <Columns>
                <asp:TemplateField HeaderText="Path">
                    <ItemTemplate>
                        <a class="orange-text" href="SingleArtwork.aspx?id=<%# Eval("Id") %>">
                            <img class="favListIMG3px" src="art-images/works/square-thumbs/<%# Eval("ImageFileName") %>.jpg">
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>              
               

                <asp:TemplateField HeaderText="Link">
                    <ItemTemplate>
                        <a class="orange-text" href="SingleArtwork.aspx?id=<%# Eval("Id") %>"><%# Eval("Title") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
               
               
               <asp:ButtonField ButtonType="Image" CommandName="RemoveFavArtwork"
                  ImageUrl="~/art-images/delete-icon-64-2.png" ItemStyle-CssClass="rightDelete" ItemStyle-BackColor="#cd4d34"   />             
               </Columns>
            
        </asp:GridView> 
        
        <!--Empty list message-->
        <p><asp:Label ID="emptyArtworkMessage" runat="server" />    </p>

    </div>
    
    
    <!--Artist Favorite list-->
    <div class="col-xs-12 col-sm-12 col-md-6 col-lg-6 noLeftPadding">
         <h2 class="noTopMargin">Artists</h2>
         
         <!--Prints out the favorited artists-->
         <asp:GridView ID="artistGrid" 
                       runat="server"
                       BackColor="White"
                       AllowPaging="false"
                       AutoGenerateColumns="false" 
                       CssClass="col-xs-12 col-sm-12 col-md-12 col-lg-12 searchGrid searchResultsGrid noBorder"
                       GridLines="None"
                       RowStyle-BorderStyle="Solid"
                       RowStyle-BorderWidth="1px"
                       RowStyle-BorderColor="#dddddd"
                       RowStyle-VerticalAlign="Middle"
                       ShowHeader="false"
                       DataKeyNames="Id" 
                       OnRowCommand="artist_RowCommand">

            <Columns>
                <asp:TemplateField HeaderText="Path">
                    <ItemTemplate>
                        <a class="orange-text" href="SingleArtist.aspx?id=<%# Eval("Id") %>">
                            <img class="favListIMG3px" src="art-images/artists/square-thumb/<%# Eval("Id") %>.jpg">
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>            
                           
                <asp:TemplateField HeaderText="Link">
                    <ItemTemplate>
                        <a class="orange-text" href="SingleArtist.aspx?id=<%# Eval("Id") %>"><%# Eval("FirstName") %> <%# Eval("LastName") %></a>
                    </ItemTemplate>
                </asp:TemplateField>
               
               
               <asp:ButtonField ButtonType="Image" CommandName="RemoveFavArtist"
                  ImageUrl="~/art-images/delete-icon-64-2.png" ItemStyle-CssClass="rightDelete" ItemStyle-BackColor="#cd4d34"  />                        
            </Columns>
         </asp:GridView> 
         
         <!--Empty artist list message-->
         <p><asp:Label ID="emptyArtistMessage" runat="server" /></p>

     </div>
</asp:Content>

