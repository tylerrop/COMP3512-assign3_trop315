<%@ Page Title="Search | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdvancedSearch.aspx.cs" Inherits="AdvancedSearch" %>
<%@ Register Src="~/Controls/SortControl.ascx" TagPrefix="uc" TagName="SortControl" %>



<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    <!--Page header-->
    <h1 class="noTopMargin">Search</h1>
    
    <div class="highlight">
                <!--GroupName="SearchRadios"-->
                <!--Radio to hide/show searching by artist-->
                <asp:RadioButton ID="ArtistFilterButton" 
                                 runat="server" 
                                 Value="1"  
                                 Text="&nbsp; Search by Artist"
                                 OnCheckedChanged="RadioButton_CheckedChanged" 
                                 AutoPostBack="true" 
                                 GroupName="SearchRadios"
                                 Active="true"   />
                
                <!--Artist search text box-->                 
                <asp:TextBox ID="ArtistSearch" TextMode="SingleLine" runat="server" CssClass="form-control" Visible="false" Placeholder="Search by Artist Name" />
                <br />

                <!--Radio to hide/show searching by artwork-->
                <asp:RadioButton ID="ArtworkFilterButton" 
                                 runat="server" 
                                 Value="2" 
                                 Text="&nbsp; Search by Artwork" 
                                 OnCheckedChanged="RadioButton_CheckedChanged" 
                                 AutoPostBack="true" 
                                 GroupName="SearchRadios"/>
                                
                
                <!--Drop down for sorting-->                  
                <asp:DropDownList runat="server" ID="searchSelect" Visible="false" CssClass="selectSpacing">
                    <asp:ListItem Value="Title">Title</asp:ListItem>
                    <asp:ListItem Value="MSRP">MSRP</asp:ListItem>
                    <asp:ListItem Value="YearOfWork">Year</asp:ListItem>
                </asp:DropDownList>

                <!--Artwork title-->
                <asp:TextBox ID="ArtworkTitle" TextMode="SingleLine" runat="server" CssClass="form-control searchBoxBottomMargin" Visible="false" Placeholder="Artwork Title" />      
                
                <!--Start Year-->
                <asp:TextBox ID="ArtworkYearStart" TextMode="SingleLine" runat="server" CssClass="form-control searchBoxBottomMargin" Visible="false" Placeholder="Year Range Start" />
              
                <!--End Year-->
                <asp:TextBox ID="ArtworkYearEnd" TextMode="SingleLine" runat="server" CssClass="form-control searchBoxBottomMargin" Visible="false" Placeholder="Year Range End" />
                
                <!--Cost Start-->
                <asp:TextBox ID="ArtworkCostStart" TextMode="SingleLine" runat="server" CssClass="form-control searchBoxBottomMargin" Visible="false" Placeholder="Cost Range Start" />
              
                <!--Cost End-->
                <asp:TextBox ID="ArtworkCostEnd" TextMode="SingleLine" runat="server" CssClass="form-control" Visible="false" Placeholder="Cost Range End" />

                
                <br />
                
                <!--Advanced Search button-->
                <asp:Button ID="FilterButton" runat="server" Text="Advanced Search" CssClass="btn btn-primary filterButtonSpacing" OnClick="FilterButtonPress" /> 
                
                    <br />
                    <br />

                        <asp:RadioButton ID="ASCRadioButton" 
                                         runat="server" 
                                         Value="1"  
                                         Text="&nbsp; Results: Ascending" 
                                         GroupName="ArtistSortRadios"
                                         Visible="false"   />
                
                        <asp:RadioButton ID="DESCRadioButton" 
                                         runat="server" 
                                         Value="2" 
                                         Text="&nbsp; Results: Descending" 
                                         GroupName="ArtistSortRadios"
                                         visible="false"/>

            <!--End of col-lg-12 highlight-->
            </div>
    <uc:SortControl runat="server" id="SortControl" />
</asp:Content>
