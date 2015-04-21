<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ShowVisaForm.aspx.cs" Inherits="JSVisaTrackingWebApplication.ShowVisaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-file-pdf  fg-color-blue"></i>Find Visa From
    </h2>
    <table class="bordered">
        <tr>
            <td class="left">
                Select City
            </td>
            <td class="left">
                <asp:RadioButtonList ID="RadioButtonList_selectcity" runat="server" RepeatDirection="Horizontal"
                    OnSelectedIndexChanged="RadioButtonList_selectcity_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem>Delhi</asp:ListItem>
                    <asp:ListItem>Mumbai</asp:ListItem>
                    <asp:ListItem>Channai</asp:ListItem>
                    <asp:ListItem>Bangalore</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="center">
                <asp:LinkButton ID="LinkButtonA" runat="server" OnClick="LinkButtonA_Click" CommandArgument="A">A</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButtonA_Click" CommandArgument="B">B</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButtonA_Click" CommandArgument="c">C</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButtonA_Click" CommandArgument="D">D</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButtonA_Click" CommandArgument="E">E</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButtonA_Click" CommandArgument="F">F</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButtonA_Click" CommandArgument="G">G</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButtonA_Click" CommandArgument="H">H</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButtonA_Click" CommandArgument="I">I</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButtonA_Click" CommandArgument="J">J</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButtonA_Click" CommandArgument="K">K</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButtonA_Click" CommandArgument="L">L</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton13" runat="server" OnClick="LinkButtonA_Click" CommandArgument="M">M</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButtonA_Click" CommandArgument="N">N</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton15" runat="server" OnClick="LinkButtonA_Click" CommandArgument="O">O</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton16" runat="server" OnClick="LinkButtonA_Click" CommandArgument="P">P</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton17" runat="server" OnClick="LinkButtonA_Click" CommandArgument="Q">Q</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton18" runat="server" OnClick="LinkButtonA_Click" CommandArgument="R">R</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton19" runat="server" OnClick="LinkButtonA_Click" CommandArgument="S">S</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton20" runat="server" OnClick="LinkButtonA_Click" CommandArgument="T">T</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton21" runat="server" OnClick="LinkButtonA_Click" CommandArgument="U">U</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton22" runat="server" OnClick="LinkButtonA_Click" CommandArgument="V">V</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton23" runat="server" OnClick="LinkButtonA_Click" CommandArgument="W">W</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton24" runat="server" OnClick="LinkButtonA_Click" CommandArgument="X">X</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton25" runat="server" OnClick="LinkButtonA_Click" CommandArgument="Y">Y</asp:LinkButton>
                -
                <asp:LinkButton ID="LinkButton26" runat="server" OnClick="LinkButtonA_Click" CommandArgument="Z">Z</asp:LinkButton>
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView runat="server" ID="Visa_gridshow" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="gridview" PageSize="10" CellPadding="5">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Country Name For Visa">
                    <ItemTemplate>
                        <asp:Label ID="lbl_country" runat="server" Text='<%#Eval("CountryForVisa") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Form">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%#Eval("Form") %>' runat="server"
                            Text='<%#Eval("VisaTitle") %>' OnClick="OpenPDF"></asp:LinkButton>
                        <%-- <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#Eval("Form") %>'
                                    runat="server"><%#Eval("Visa_title") %></asp:HyperLink>--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerTemplate>
                <table width="100%">
                    <tr>
                        <td style="text-align: right">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                        </td>
                    </tr>
                </table>
            </PagerTemplate>
            <HeaderStyle Font-Size="10pt" />
        </asp:GridView>
    </div>
</asp:Content>
