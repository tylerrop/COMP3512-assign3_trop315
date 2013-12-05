<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RemoveBtn.ascx.cs" Inherits="ReviewInformation" %>

<!--Button to remove a review of a painting-->
<asp:LoginView ID="LoginView1" runat="server">
    <RoleGroups>
        <asp:RoleGroup Roles="administrator">
            <ContentTemplate>
                <!--Remove Review Btn-->
                <asp:LinkButton runat="server" CssClass="btn btn-default" ID="removeReviewBtn" OnClick="RemoveReview_OnClick" CommandArgument='<%# Eval("Id") %>'>
                    Remove
                </asp:LinkButton>
            </ContentTemplate>
        </asp:RoleGroup>
     </RoleGroups>
</asp:LoginView>
