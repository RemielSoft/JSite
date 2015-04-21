<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="HolidayList.aspx.cs" Inherits="JSVisaTrackingWebApplication.HolidayList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-list fg-color-blue"></i>Holiday List...
    </h2>
    <script type="text/javascript">
        function confirmation() {
            if (confirm('Are you sure you want to Delete ?')) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <table class="bordered">
        <tr>
            <td class="left">
                For
            </td>
            <td class="left">
                <asp:RadioButtonList ID="rbtnlstPurpose" runat="server" RepeatDirection="Horizontal"
                    Width="254px">
                    <asp:ListItem Text=" Mail" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text=" Website" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="left">
                Location
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_location"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a" InitialValue="0"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_location" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
    </table>
    <div align="right">
        <asp:Button ID="btn_go" runat="server" Text="Go" OnClick="btn_go_Click" ValidationGroup="a" /></div>
    <div>
        <asp:GridView ID="grid_holiday" runat="server" AutoGenerateColumns="False" AllowPaging="true"
            CssClass="gridview" PageSize="10" CellPadding="5" OnRowCommand="grid_holiday_RowCommand">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <%-- <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("HoliId") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Month">
                    <ItemTemplate>
                        <asp:Label ID="lbl_month" runat="server" Text='<%# Eval("HoliMonth") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Holiday Details">
                    <ItemTemplate>
                        <asp:Label ID="lbl_detail" runat="server" Text='<%# Eval("HoliDetails") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Holiday Notes">
                    <ItemTemplate>
                        <asp:Label ID="lbl_notes" runat="server" Text='<%# Eval("HoliNotes") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="cmdedit" CommandArgument='<%# Eval("HoliId") %>'
                            ToolTip="Edit"><i class="icon-pencil black"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="cmddel" CommandArgument='<%# Eval("HoliId") %>'
                            ToolTip="Delete" OnClientClick="return confirmation();"><i class=" icon-remove red"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
