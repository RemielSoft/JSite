<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ReceiptGeneration.aspx.cs" Inherits="JSVisaTrackingWebApplication.ReceiptGeneration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        <i class="fg-color-blue icon-file"></i>Receipt Generation
    </h2>
    <asp:ValidationSummary ID="Summary" runat="server" ValidationGroup="a" ShowMessageBox="true"
        ShowSummary="false" DisplayMode="List" />
    <asp:UpdatePanel ID="update1" runat="server">
        <ContentTemplate>
            <table class="table table-bordered table-striped table-condensed">
                <tr>
                    <td class="left" colspan="4">
                        <asp:Label CssClass="fg-color-blue" ID="lblRcptHeader" runat="server" Text="Receipt Header" Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Receipt Type <span class="red">*</span>
                    </td>
                    <td class="left" colspan="3">
                        <asp:RadioButtonList ID="rbtnReceiptType" runat="server" RepeatDirection="Horizontal"
                            Width="220px" AutoPostBack="True" CausesValidation="True" OnSelectedIndexChanged="rbtnReceiptType_SelectedIndexChanged">
                            <asp:ListItem Text="  Normal" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="  Advance" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Date
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txtRcptDate" runat="server" ReadOnly="true"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                    <td class="left">
                        Receipt No.
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txtRecptNo" runat="server" ReadOnly="True"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Party Name <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:RequiredFieldValidator ID="RFV7" runat="server" ControlToValidate="ddlPartyName"
                                ErrorMessage="Please Select Party Name." InitialValue="0" ForeColor="Red" Display="None"
                                ValidationGroup="a"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlPartyName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPartyName_SelectedIndexChanged"
                                CausesValidation="True">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td class="left" rowspan="2">
                        Address
                    </td>
                    <td class="left" rowspan="2">
                        <div class="input-control text">
                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" ReadOnly="True">
                            </asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Outstanding
                        <asp:ImageButton ID="imgCurrency" runat="server" Height="18px" ImageUrl="~/images/currency_sign_rupee.png"
                            Width="18px" />
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txtOutstanding" runat="server" ReadOnly="True"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Payment Mode <span class="red">*</span>
                    </td>
                    <td class="left" colspan="3">
                        <asp:RadioButtonList ID="rbtnPaymentMode" runat="server" RepeatDirection="Horizontal"
                            Width="231px" OnSelectedIndexChanged="rbtnPaymentMode_SelectedIndexChanged" AutoPostBack="True"
                            CausesValidation="true">
                            <asp:ListItem Text="  Cash" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="  Cheque/DD" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        Amount <span class="red">* </span>
                        <asp:CompareValidator ID="CV3" runat="server" ControlToValidate="txtRcptAmount" Display="None"
                            ErrorMessage="Please Fill Amount With Only Numeric Value." ForeColor="Red" Operator="DataTypeCheck"
                            Type="Double" ValidationGroup="a"></asp:CompareValidator>
                    </td>
                    <td class="auto-style3">
                        <div class="input-control text">
                            <asp:RequiredFieldValidator ID="RFV6" runat="server" ControlToValidate="txtRcptAmount"
                                ErrorMessage="Please Fill Amount." ForeColor="Red" Display="None" ValidationGroup="a"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtRcptAmount" runat="server"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                    <td class="auto-style3">
                        Cheque/DD No. <span id="span1" runat="server" class="red">*</span>
                    </td>
                    <td class="auto-style3">
                        <div class="input-control text span4">
                            <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="txtChequeNo"
                                ErrorMessage="Please Fill Cheque No." ForeColor="Red" Display="None" ValidationGroup="b"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtChequeNo" runat="server"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Credit Account <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control select">
                            <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="ddlCreditAccount"
                                ErrorMessage="Please Select Credit Account." ForeColor="Red" Display="None" ValidationGroup="a"
                                InitialValue="--Select--"></asp:RequiredFieldValidator>
                            <asp:DropDownList ID="ddlCreditAccount" runat="server" CausesValidation="True">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td class="left">
                        Issuing Bank <span id="span2" runat="server" class="red">*</span>
                    </td>
                    </td>
                    <td class="left">
                        <div class="input-control text span4">
                            <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="txtIssuingBank"
                                ErrorMessage="Please Fill Issuing Bank." ForeColor="Red" Display="None" ValidationGroup="b"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="txtIssuingBank" runat="server"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Remark
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </td>
                    <td class="left">
                        Dated <span id="span3" runat="server" class="red">*</span>
                    </td>
                    </td>
                    <td class="left">
                        <asp:RequiredFieldValidator ID="RFV9" runat="server" ControlToValidate="txtDated"
                            ErrorMessage="Please Fill Dated." ForeColor="Red" Display="None" ValidationGroup="b"></asp:RequiredFieldValidator>
                        <div id="divdated" runat="server" class="input-control text datepicker span4" data-param-year-buttons="1"
                            data-param-lang="en">
                            <asp:TextBox ID="txtDated" runat="server"></asp:TextBox>
                            <i class="btn-date"></i>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <div align="right">
                <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" ValidationGroup="a" />
            </div>
            <table id="tbl2" runat="server" class="table table-bordered table-striped table-condensed">
                <tr>
                    <td class="left">
                        <asp:Label CssClass="fg-color-blue" ID="lblRcptDetails" runat="server" Text="Receipt Details For : "
                            Font-Bold="True" Width="200px"></asp:Label>
                    </td>
                    <td class="left" colspan="3">
                        <asp:Label CssClass="fg-color-blue" ID="lblAgent" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Invoice No.
                    </td>
                    <td class="left">
                        Dated
                    </td>
                    <td class="left">
                        Total Invoice Amount
                    </td>
                    <td class="left">
                        Adjusted Amount
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlInvoice" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInvoice_SelectedIndexChanged"
                                Width="175px">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txtInvoiceDate" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txtTotalInvoiceAmount" runat="server" Width="200px"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txtAdjustedAmt" runat="server" AutoPostBack="True" Width="200px"
                                CausesValidation="True"></asp:TextBox>
                            <button class="btn-clear" />
                        </div>
                    </td>
                </tr>
                
                        
                    
            </table>
            <div style="position:relative; text-align:center;">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlInvoice"
                            ErrorMessage="Please Select Invoice No." ForeColor="Red" ValidationGroup="add"
                            InitialValue="0" Font-Size="Small"></asp:RequiredFieldValidator>            
            </div>
            <br />
            <div id="divBtnAdd" runat="server" align="right">
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" ValidationGroup="add" />
            </div>
            <div>
                <asp:GridView ID="gridviewReceipt" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                    CellPadding="5" ShowFooter="true" OnRowDataBound="gridviewReceipt_RowDataBound"
                    OnRowCommand="gridviewReceipt_RowCommand">
                    <HeaderStyle CssClass="gridViewHeader" />
                    <RowStyle CssClass="gridViewRow" />
                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                    <PagerStyle CssClass="gridViewPager" />
                    <FooterStyle BackColor="#2D89EF" ForeColor="White" HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No.">
                            <ItemTemplate>
                                <asp:Label ID="lblIndex" runat="server" Text='<%#((Container.DataItemIndex)+1)%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text="Total Adjusted Amount" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice No.">
                            <ItemTemplate>
                                <asp:Label ID="lblInvNo" runat="server" Text='<%#Eval("InvoiceNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice Date">
                            <ItemTemplate>
                                <asp:Label ID="lblInvDate" runat="server" Text='<%#Eval("InvoiceDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblInvAmt" runat="server" Text='<%#Eval("InvoiceAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Adjsted Amount">
                            <ItemTemplate>
                                <asp:Label ID="lblAdjustedAmt" runat="server" Text='<%#Eval("AdjustedAmount") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalAdjustedAmt" runat="server" Font-Bold="True" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton CssClass="fg-color-red" ID="lkbtnDelet" runat="server"
                                    CommandName="cmdDelete" CommandArgument='<%#Container.DataItemIndex%>'><i class=" icon-remove red"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div align="right" id="divbtnSave" runat="server">
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"
                    Visible="False" CausesValidation="true" ValidationGroup="a" />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" AutoPostBack="true"
                    ValidationGroup="a" />
                <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreview_Click"
                    Visible="False" />
                <asp:Button ID="btnGenerateReceipt" runat="server" Text="Generate Receipt" OnClick="btnGenerateReceipt_Click"
                    Visible="False" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="rbtnPaymentMode" />
            <asp:PostBackTrigger ControlID="btnAdd"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="ddlPartyName"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="gridviewReceipt"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnSave"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="rbtnReceiptType"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="ddlPartyName"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="btnNext"></asp:PostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
