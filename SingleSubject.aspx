<%@ Page Title="Single Subject | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleSubject.aspx.cs" Inherits="SingleSubject" %>
<%@ Register Src="~/Controls/SortControl.ascx" TagPrefix="uc" TagName="SortControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">

    <!--Prints out all of the subjects-->
    <asp:GridView 
    ID="singleSubjectGridView" 
    runat="server" 
    AutoGenerateColumns="false" 
    CssClass="col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftPadding searchGrid searchResultsGrid"
    AllowSorting="true"
    BackColor="Transparent"
    >
    <Columns>
        <asp:TemplateField HeaderStyle-CssClass="noBorder" ItemStyle-CssClass="noBorder">
            <HeaderTemplate><h2 class="hidden">Subject</h2></HeaderTemplate>
            <ItemTemplate>

                <!--Page header-->
                <h1 class="noTopMargin">Subject</h1>
                
                <!--Panel that displays the subject name and image-->
                <div class="panel panel-default col-sm-3 col-md-2 col-lg-2 noLeftRightPadding">
                    <div class="panel-heading noMargins leftPadEightPix bold">
                        <span class="orange-text">
                            <%# Eval("SubjectName") %>
                        </span>
                    </div>  
                            
                        <!--Table for formatting the subject image-->
                        <table class="table">
                            <tr>
                                <td class="col-xs-2 col-sm-2 col-md-2 col-lg-2" style="border-bottom:none;">
                                        <img class="noLeftPadding listThumbNail centerMargins" src="art-images/subjects/square-medium/<%# Eval("Id") %>.jpg" alt="<%# Eval("SubjectName") %> photo"  />
                                </td>
                            </tr>
                        </table>  
                 <!--End of panel panel-default-->
                 </div>
            </ItemTemplate>
        </asp:TemplateField>
     </Columns>
</asp:GridView>


<!--Subject sorting options-->
<div class="panel panel-default col-lg-12 noLeftRightPadding">
    <div class="panel-heading noMargins leftPadEightPix bold">
        Sorting
    </div>  
     
    <!--Table for sorting options-->
    <!--Can sort by Title, MSRP, or Year-->
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
                
                <!--SubjectSortRadios button group-->
                <!--Sort Ascending radio button--> 
                <asp:RadioButton ID="ASCRadioButton" 
                                    runat="server" 
                                    Value="1"  
                                    Text="&nbsp; Results: Ascending" 
                                    GroupName="SubjectSortRadios"/>

                <!--Sort Descending radio buttton-->
                <asp:RadioButton ID="DESCRadioButton" 
                                    runat="server" 
                                    Value="2" 
                                    Text="&nbsp; Results: Descending" 
                                    GroupName="SubjectSortRadios"/>
            </td>                        
        </tr>

        <tr style="border-bottom:none; padding-top:0px;">
            <td>
                <!--Submit sorting preferences button-->
                <asp:Button ID="FilterButton" runat="server" Text="Sort" CssClass="btn btn-primary" OnClick="FilterButtonPress" /> 
            </td>
        </tr>
    </table>                            
</div>



<!--Paintings in the Subject-->   
<div class="panel panel-primary col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding">
    <div class="panel-heading">
        <h3 class="panel-title">Paintings</h3>
    </div>
                
    <div class="panel-body">
        <!--Prints out the sorting results-->
        <uc:SortControl ID="SortControl" runat="server" />
    </div>
</div>
</asp:Content>

