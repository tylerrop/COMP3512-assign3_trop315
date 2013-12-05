<%@ Page Title="Subjects | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SubjectList.aspx.cs" Inherits="SubjectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">
    
    <!--Page Header-->
    <h1 class="noTopMargin">Subjects</h1>   

    <!--Prints out all of the subjects-->
    <asp:Repeater ID="subjectList" runat="server" >
        <ItemTemplate>
            <div class="genreBoxSize col-xs-12 col-sm-4 col-md-3 col-lg-4 noLeftPadding">   
                
                <!--Panel for Subject Details-->
                <div class="panel panel-default">
                    <div class="panel-heading noMargins leftPadEightPix bold">
                        <!--Subject name link-->
                        <a href="SingleSubject.aspx?id=<%# Eval("Id") %>&subject=1" class="orange-text"><%# Eval("SubjectName") %></a></div>          
                        
                        <!--Subject image link-->
                        <a href="SingleSubject.aspx?id=<%# Eval("Id") %>&subject=1">
                            <img class="noLeftPadding listThumbNail centerMargins" src="art-images/subjects/square-medium/<%# Eval("Id") %>.jpg" alt="<%# Eval("SubjectName") %>"  />
                        </a>
                    
                 <!--End of panel panel-default-->
                 </div>
            </div>
           </ItemTemplate>
      </asp:Repeater>
</asp:Content>

