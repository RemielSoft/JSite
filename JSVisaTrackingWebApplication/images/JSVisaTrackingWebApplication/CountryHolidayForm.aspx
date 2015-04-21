<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="CountryHolidayForm.aspx.cs" Inherits="JSVisaTrackingWebApplication.CountryHolidayForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-list fg-color-blue"></i>Country Holiday Form...
    </h2>
    <table class="bordered">
        <tr>
            <td class="left">
                For
            </td>
            <td colspan="3" class="left">
                <%--<asp:RadioButton ID="rdb_mail" runat="server" GroupName="a" Text=" Mail" />
                <asp:RadioButton ID="rdb_website" runat="server" GroupName="a" Text=" Website" />--%>
                <asp:RadioButtonList ID="rbtnlstPurpose" runat="server" RepeatDirection="Horizontal"
                    Width="254px">
                    <asp:ListItem Text=" Mail" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text=" Website" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="left">
                Month
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_month"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a"
                    InitialValue="0"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_month" runat="server" AutoPostBack="True">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem Value="1">January</asp:ListItem>
                        <asp:ListItem Value="2">Febraury</asp:ListItem>
                        <asp:ListItem Value="3">March</asp:ListItem>
                        <asp:ListItem Value="4">April</asp:ListItem>
                        <asp:ListItem Value="5">May</asp:ListItem>
                        <asp:ListItem Value="6">June</asp:ListItem>
                        <asp:ListItem Value="7">July</asp:ListItem>
                        <asp:ListItem Value="8">August</asp:ListItem>
                        <asp:ListItem Value="9">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </td>
            <td class="left">
                Location
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddl_location"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a"
                    InitialValue="0"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_location" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Detail
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_detail"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_detail" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </td>
            <td class="left">
                Notes
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_notes"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_notes" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;&nbsp;
    <div align="right">
        <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" ValidationGroup="a" />
        <asp:Button ID="btn_update" runat="server" Text="Update" Visible="false" OnClick="btn_update_Click" />
    </div>
</asp:Content>
