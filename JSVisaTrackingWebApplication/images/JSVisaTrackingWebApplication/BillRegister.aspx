<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="BillRegister.aspx.cs" Inherits="JSVisaTrackingWebApplication.BillRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-keyboard fg-color-blue"></i>Bill Register
    </h2>
    <table class="bordered">
        <tr>
            <td class="left">
                Search Criteria
            </td>
            <td class="left" colspan="3">
                <label class="input-control checkbox" onclick="">
                    <asp:CheckBox ID="ChkPeriod" runat="server" />
                    <span class="helper">Period</span>
                </label>
                &nbsp;<label class="input-control checkbox" onclick="">
                    <asp:CheckBox ID="ChkBill" runat="server" />
                    <span class="helper">Bill</span>
                </label>
            </td>
        </tr>
        <tr>
            <td class="left">
                From Date
            </td>
            <td class="left">
                <asp:TextBox ID="txt_fromDate" runat="server"></asp:TextBox>
            </td>
            <td class="left">
                To Date
            </td>
            <td class="left">
                <asp:TextBox ID="txt_toDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="left">
                From Bill
            </td>
            <td class="left">
                <asp:TextBox ID="txt_fromBill" runat="server"></asp:TextBox>
            </td>
            <td class="left">
                To Bill
            </td>
            <td class="left">
                <asp:TextBox ID="txt_toBill" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div align="right">
        <asp:Button ID="btnGo" runat="server" Text="GO" />
    </div>
</asp:Content>
