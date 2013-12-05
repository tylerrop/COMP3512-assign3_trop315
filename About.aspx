<%@ Page Title="About Us | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" runat="server">

        <!--Page caption-->
        <h1 class="noTopMargin">About Us</h1>
                    
        <!--MRU Logo-->
        <img src="art-images/MRU-clear.png" alt="Mount Royal University Logo"  class="noLeftPadding col-xs-12 col-sm-12 col-md-4 col-lg-5"/>

        <!--About Info in Panel-->
        <div class="col-xs-12 col-sm-12 col-md-8 col-lg-7 noLeftRightPadding">

            <!--Panel for assignments and university information-->
            <div class="panel panel-default">
                <div class="panel-heading noMargins leftPadEightPix boldText"><h4>Assignment Details</h4></div>
                    <!-- Table -->
                    <table class="table">
                        <!--Date-->
                        <tr class="col-xs-12 col-sm-12 col-md-12">
                            <td class="col-sm-3 boldText">Due Date: </td>
                            <td class="col-sm-3">November 18, 2013</td>
                        </tr>

                        <!--University-->
                        <tr class="col-xs-12 col-sm-12 col-md-12">
                            <td class="col-sm-3 boldText">University:</td>
                            <td class="col-sm-3">Mount Royal University</td>
                        </tr>

                        <!--Class-->
                        <tr class="col-xs-12 col-sm-12 col-md-12">
                            <td class="col-sm-3 boldText">Class:</td>
                            <td class="col-sm-3">COMP 3512</td>
                        </tr>

                        <!--Professor-->
                        <tr class="col-xs-12 col-sm-12 col-md-12">
                            <td class="col-sm-3 boldText">Professor:</td>
                            <td class="col-sm-3">Randy Connolly</td>
                        </tr>

                        <!--Student-->
                        <tr class="col-xs-12 col-sm-12 col-md-12">
                            <td class="col-sm-3 boldText">Students:</td>
                            <td class="col-sm-3">Tyler Rop, Paul DeRose, Anthony Thomasson</td>
                        </tr>
                                    
                        <!--Assignment-->
                        <tr class="col-xs-12 col-sm-12 col-md-12">
                            <td class="col-sm-3 boldText">Assignment:</td>
                            <td class="col-sm-3">#2 Custom Database-Driven Web Pages - Three Layer Implementation</td>
                        </tr>
                           
                     </table>
                                
                <!--End of panel panel-default-->
                </div>

           
        <!--./col-xs-12 col-sm-12 col-md-8 col-lg-7-->                          
        </div>  
                         
     <br class="clearAll" />
    
     <!--Essay of info about the developers and the website-->
     <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftRightPadding font">
            
         <p class="noLeftPadding">This website was coded by Tyler Rop, Paul DeRose, and Anthony Thomasson for the class of COMP 3512 at Mount Royal University in the Fall semester of 2013.</p>
         
         <p class="noLeftPadding">The images and copy text present in this site are not owned by Rop, DeRose, or Thomasson and are not for sale.</p>

         <p class="noLeftPadding">The overall front end design and interface functionality was coded by Tyler. Paul worked to design the branding, logo, colour scheme, and also assisted with the 
             back end code. Anthony’s work was focussed mainly on the back end code that provides the database driven functionality of this site. All three students assisted each other with the 
             creation of this website for their term project.
         </p>

          <p class="noLeftPadding">The ASP.Net platform using a Three Layered model was used for this website's implementation. The Bootstrap CSS framework was used as the basis for the front end 
              layout, though the visual look of it was customized to be different than the defaults.
          </p>


     <!--col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftPadding-->                          
     </div>  


</asp:Content>

