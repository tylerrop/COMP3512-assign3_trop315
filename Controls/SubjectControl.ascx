<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubjectControl.ascx.cs" Inherits="SubjectControl" %>

<asp:Repeater ID="subjectData" runat="server">
    <HeaderTemplate>
        <tr class="col-xs-12 col-sm-12 col-md-12">
            <td class="col-sm-3 boldText">Subjects:</td>
            <td class="col-sm-3">
                <ul class="panelList noBottomMargin">
    </HeaderTemplate>

                <ItemTemplate>
                    <li><a href="SingleSubject.aspx?id=<%# Eval("Id") %>&subject=1" class="orange-text"><%# Eval("SubjectName")%></a></li>
                </ItemTemplate>

    <FooterTemplate>
                </ul>
            </td>
        </tr>
    </FooterTemplate>
</asp:Repeater>
