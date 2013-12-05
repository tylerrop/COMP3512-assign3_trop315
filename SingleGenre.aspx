<%@ Page Title="Single Genre | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleGenre.aspx.cs" Inherits="SingleGenre" %>
<%@ Register Src="~/Controls/SortControl.ascx" TagPrefix="uc" TagName="SortControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <!--Prints out all of the genres-->
    <asp:GridView 
    ID="singleGenreGridView" 
    runat="server" 
    AutoGenerateColumns="false" 
    CssClass="col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftPadding searchGrid searchResultsGrid"
    AllowSorting="true"
    BackColor="Transparent"
    >
    <Columns>
        <asp:TemplateField HeaderStyle-CssClass="noBorder" ItemStyle-CssClass="noBorder">
            <HeaderTemplate><h2 class="hidden">Genre</h2></HeaderTemplate>
            <ItemTemplate>

                <!--Page header-->
                <h1 class="noTopMargin">Genre</h1>
                
                <!--Panel with genre info-->
                <div class="panel panel-default">
                    <div class="panel-heading noMargins leftPadEightPix bold">
                        <span class="orange-text" >
                            <%# Eval("GenreName") %>
                        </span>
                    </div>  
                            
                        <!--Table of the genre image and description-->
                        <table class="table">
                            <tr>
                                <td class="col-xs-2 col-sm-2 col-md-2 col-lg-2" style="border-bottom:none;">        
                                        <img class="noLeftPadding listThumbNail" src="art-images/genres/square-medium/<%# Eval("Id") %>.jpg" alt="<%# Eval("GenreName") %> photo"  />
                                </td>
                                       
                                <!-- Table formatting for the genre description-->
                                <td style="border-bottom:none;">
                                    <table class="table noBottomMargin">
                                        <tbody>                                            
                                            <tr>
                                                <td class="noPaddingLeft" style="padding-left: 0px; border-bottom-width:0px">
                                                    <%# Eval("Description") %>
                                                </td>
                                            </tr>
                                      </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>  
                 <!--End of panel panel-default-->
                 </div>
            </ItemTemplate>
        </asp:TemplateField>
     </Columns>
</asp:GridView>


<!--Display sorting options for the genres paintings-->
<div class="panel panel-default col-lg-12 noLeftRightPadding">
    <div class="panel-heading noMargins leftPadEightPix bold">
        Sorting
    </div>  
     
    <!--Table for sorting options-->
    <!--Can sort by Titlem MSRP, or Year-->
    <table class="table">
        <tr>
            <td style="border-bottom:none; padding-bottom:0px;">
                <asp:DropDownList runat="server" ID="searchSelect" CssClass="selectSpacing">
                    <asp:ListItem Value="Title">Title</asp:ListItem>
                    <asp:ListItem Value="MSRP">MSRP</asp:ListItem>
                    <asp:ListItem Value="YearOfWork">Year</asp:ListItem>
                </asp:DropDownList>                    
            </td>
        </tr>
        
        <tr>
            <td style="border-bottom:none; padding-top:0px; padding-bottom:0px;">
                
                <!--GenreSortRadios button group-->
                <!--Search Ascending--> 
                <asp:RadioButton ID="ASCRadioButton" 
                                    runat="server" 
                                    Value="1"  
                                    Text="&nbsp; Results: Ascending" 
                                    GroupName="GenreSortRadios"/>

                <!--Search Descending-->
                <asp:RadioButton ID="DESCRadioButton" 
                                    runat="server" 
                                    Value="2" 
                                    Text="&nbsp; Results: Descending" 
                                    GroupName="GenreSortRadios"/>
            </td>                        
        </tr>

        <tr style="border-bottom:none; padding-top:0px;">
            <td>
                <!--Submit sorting filter button-->
                 <asp:Button ID="FilterButton" runat="server" Text="Sort" CssClass="btn btn-primary" OnClick="FilterButtonPress" /> 
            </td>
        </tr>
    </table>                            
</div>


    <!--Paintings by the artist-->   
    <div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
        <div class="panel-heading">
            <h3 class="panel-title">Paintings</h3>
        </div>
                
        <div class="panel-body">
            <!--Sorts the artworks of the genre-->
            <uc:SortControl runat="server" ID="SortControl" />   
        </div>
     </div>

</asp:Content>

