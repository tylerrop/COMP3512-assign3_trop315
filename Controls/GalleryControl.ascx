<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryControl.ascx.cs" Inherits="GalleryControl" %>

<asp:DataList runat="server" ID="galleryData">
    <ItemTemplate>
        <!--Panel for Artist Details-->

                    <div class="panel panel-default panel-group" id="accordian">
                        <div class="panel-heading noMargins boldText leftPadEightPix bold">
                            <h4 class="panel-title orange-text">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne"><%# Eval("GalleryName") %></a>
                            </h4>
                        </div>

                        <div id="collapseOne" class="panel-collapse collapse out">
                            <div class="panel-body">
                                
                                <!-- Table -->
                                <table class="table noBottomMargin">           
                                    <!--City Link-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText ">City:</td>
                                        <td class="col-sm-3 overFlow"><%# Eval ("GalleryCity") %></td>
                                    </tr>

                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText ">Country:</td>
                                        <td class="col-sm-3 overFlow"><%# Eval("GalleryCountry") %></td>
                                    </tr>

                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText ">Latitude:</td>
                                        <td class="col-sm-3 overFlow"><%# Eval("Latitude") %></td>
                                    </tr>

                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText ">Longitude:</td>
                                        <td class="col-sm-3 overFlow"><%# Eval("Longitude") %></td>
                                    </tr>

                                     
                                    <!--Google Link-->
                                    <tr class="col-xs-12 col-sm-12 col-md-12">
                                        <td class="col-sm-3 boldText noBorderBottom" style="border-bottom-width:0px;">Gallery Website:</td>
                                        <td class="col-sm-3 overFlow noBorderBottom"style="border-bottom-width:0px;"><a class="orange-text" href="<%# Eval ("GalleryWebSite") %>">Click here to go to <%# Eval("GalleryName") %></a></td>
                                    </tr>
                                </table>

                             </div>
                        </div>
                  </div>
    </ItemTemplate>
</asp:DataList>