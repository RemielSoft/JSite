<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="GenerateInvoiceForm.aspx.cs" Inherits="JSVisaTrackingWebApplication.GenerateInvoiceForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2><b>
        <i class="  icon-file-word fg-color-blue"></i>Generate Invoice...</b></h2>
    <div align="right">
        <asp:Button ID="BtnAddMiscellaneousCharge" runat="server" Text="Add Miscellaneous Charge"
            Width="200px" />
    </div>
    <table class="bordered">
        <tr>
            <td class="left">
                <b>Description</b>
            </td>
            <td class="left">
                <b>Rate</b>
            </td>
            <td class="left">
                <b>Quantity</b>
            </td>
            <td class="left">
                <b>Amount</b>
            </td>
        </tr>
        <tr>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_descrpt" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_rate" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_quantity" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left" colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="left" colspan="4">
                <asp:GridView ID="GridviewInvoice" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                    CssClass="gridview" PageSize="10" CellPadding="5">
                    <HeaderStyle CssClass="gridViewHeader" />
                    <RowStyle CssClass="gridViewRow" />
                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                    <PagerStyle CssClass="gridViewPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblDesc" runat="server" Text='<% Eval("") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rate">
                            <ItemTemplate>
                                <asp:Label ID="lblRate" runat="server" Text='<% Eval("") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblqty" runat="server" Text='<% Eval("") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblamt" runat="server" Text='<% Eval("") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="left">
                &nbsp;
            </td>
            <td class="left">
                &nbsp;
            </td>
            <td class="left">
                Service Charge
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_serviceCharge" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                &nbsp;
            </td>
            <td class="left">
                &nbsp;
            </td>
            <td class="left">
                Service Tax
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_serviceTax" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                &nbsp;
            </td>
            <td class="left">
                &nbsp;
            </td>
            <td class="left">
                Total Amount
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_totalAmt" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                &nbsp;
            </td>
            <td class="left">
                &nbsp;
            </td>
            <td class="left">
                Net Amount
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_NetAmt" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
    </table>
    <div align="right">
        <asp:Button ID="btnSave" runat="server" Text="Save" />
        <asp:Button ID="btnPreview" runat="server" Text="Preview" />
        <asp:Button ID="btnExit" runat="server" Text="Exit" />
    </div>
</asp:Content>
