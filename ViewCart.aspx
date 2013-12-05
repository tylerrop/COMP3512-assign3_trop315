<%@ Page Title="Cart | Pinpoint Art" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageContent" Runat="Server">

    <!--Page header-->
    <h1 class="noTopMargin">Cart: <asp:Label ID="totalCostLabel" runat="server" /></h1>

    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12 noLeftPadding">
         <!--Prints out all of the artworks in the user's cart-->
         <asp:GridView ID="artworkGrid" 
                       runat="server"
                       BackColor="Transparent"
                       AllowPaging="false"
                       AutoGenerateColumns="false" 
                       CssClass="col-xs-12 col-sm-12 col-md-12 col-lg-12 searchGrid searchResultsGrid noBorder paddingPointFiveEM"
                       GridLines="None"
                       RowStyle-BorderStyle="Solid"
                       RowStyle-BorderWidth="1px"
                       RowStyle-BorderColor="#dddddd"
                       RowStyle-VerticalAlign="Top"
                       ShowHeader="true"
                       DataKeyNames="Id" 
                       OnRowCommand="artwork_RowCommand"
                       HeaderStyle-BackColor="Transparent"
                       HeaderStyle-CssClass="transparentBackground"
                       CellPadding="10"
                       RowStyle-Height="100"                      
             >

            <Columns>
                <asp:TemplateField HeaderText="Artwork" ItemStyle-BackColor="White" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <a class="orange-text" href="SingleArtwork.aspx?id=<%# Eval("Id") %>"><%# Eval("Title") %></a>
                        <br />
                        <a class="orange-text" href="SingleArtwork.aspx?id=<%# Eval("Id") %>">
                            <img  style="margin-left:0; margin-top:5px;" src="art-images/works/square-thumbs/<%# Eval("ImageFileName") %>.jpg">
                        </a>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Price" ItemStyle-BackColor="White">
                    <ItemTemplate>
                        <p><%# Eval("PaintingCost", "{0:c}") %></p>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Matt" ItemStyle-BackColor="White" ItemStyle-Width="15%"> 
                    <ItemTemplate>
                        <p><%# Eval("MattPrice", "{0:c}") %> <%# Eval("MattTitle") %></p>
                    </ItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Glass" ItemStyle-BackColor="White" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <p><%# Eval("GlassPrice", "{0:c}") %> <%# Eval("GlassTitle") %></p>
                        <p><%# Eval("GlassDescription") %></p>
                    </ItemTemplate>
                </asp:TemplateField>

                

                <asp:TemplateField HeaderText="Frame" ItemStyle-BackColor="White" ItemStyle-Width="15%">
                    <ItemTemplate>
                        <p><%# Eval("FramesPrice", "{0:c}") %> <%# Eval("FramesTitle") %></p>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Total" ItemStyle-BackColor="White">
                    <ItemTemplate>
                        <h4 class="noTopMargin"><%# Eval("TotalCost", "{0:c}") %></h4>
                    </ItemTemplate>
                </asp:TemplateField>




                <asp:ButtonField ButtonType="Image" ImageUrl="~/art-images/edit-icon-64.png" CommandName="ModifyCartItem" ItemStyle-CssClass="centerMargins noTopBottomPadding" ItemStyle-BackColor="#cd4d34"/>
               

                <asp:ButtonField ButtonType="Image" CommandName="RemoveCartItem"
                  ImageUrl="~/art-images/delete-icon-64-2.png" ItemStyle-CssClass="centerMargins noTopBottomPadding" ItemStyle-BackColor="#cd4d34" />             
                </Columns>
            
        </asp:GridView> 
       

        <!--Empty cart message lable-->
        <p><asp:Label ID="emptyArtworkMessage" runat="server" /></p>

        <!--checkout cart dummy button-->
        <asp:Button ID="CheckoutButton" runat="server" Text="Checkout My Cart" CssClass="btn btn-primary" />

    </div>
    
</asp:Content>


