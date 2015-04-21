<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="BankStatement.aspx.cs" Inherits="JSVisaTrackingWebApplication.BankStatement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
<i class="icon-keyboard fg-color-blue"></i>Bank Statement
</h2>
<table class="bordered">
 <tr>
            
            <td class="left" colspan="3">
                <label class="input-control checkbox" onclick="">
                    <asp:CheckBox ID="Chkicicibank" runat="server" />
                    <span class="helper">ICICI Bank</span>
                </label>
                &nbsp;<label class="input-control checkbox" onclick="">
                    <asp:CheckBox ID="Chkobc" runat="server" />
                    <span class="helper">Oriental Bank Of Commerce</span>
                </label>
                <label class="input-control checkbox" onclick="">
                    <asp:CheckBox ID="Chkall" runat="server" />
                    <span class="helper">All</span>
                </label>
            </td>
        </tr>
        <tr>
        <td>
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
        
</table>
</asp:Content>
