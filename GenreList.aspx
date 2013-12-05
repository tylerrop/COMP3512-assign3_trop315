<%@ Page Title="Genres | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GenreList.aspx.cs" Inherits="GenreList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <!--Page header-->
    <h1 class="noTopMargin">Genres</h1>   

    <!--Prints out all of the genres-->
    <asp:Repeater ID="genreList" runat="server" >
        <ItemTemplate>
            <div class="genreBoxSize col-xs-12 col-sm-4 col-md-3 col-lg-4 noLeftPadding">   
                
                <!--Panel for Genre Details-->
                <div class="panel panel-default overFlow">
                    <div class="panel-heading noMargins leftPadEightPix bold">

                        <!--Genre link-->
                        <a class="orange-text" href="SingleGenre.aspx?id=<%# Eval("Id") %>&genre=1"><%# Eval("GenreName") %></a></div>          
                        
                        <!--Genre image link-->
                        <a href="SingleGenre.aspx?id=<%# Eval("Id") %>&genre=1">
                            <img class="noLeftPadding listThumbNail centerMargins" src="art-images/genres/square-medium/<%# Eval("Id") %>.jpg" alt="<%# Eval("GenreName") %>"  />
                        </a>
                 </div>
            </div>
           </ItemTemplate>
      </asp:Repeater>
</asp:Content>

