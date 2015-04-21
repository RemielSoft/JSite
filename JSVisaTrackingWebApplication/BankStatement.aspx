<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="BankStatement.aspx.cs" Inherits="JSVisaTrackingWebApplication.BankStatement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <script type="text/javascript">
        document.createElement('header');
        document.createElement('section');
        document.createElement('article');
        document.createElement('aside');
        document.createElement('nav');
        document.createElement('footer');
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-keyboard fg-color-blue"></i>Bank Statement
    </h2>
    <table class="table table-bordered table-striped table-condensed" id="tbl" runat="server">
        <tr>
        <td>Bank Name</td>
            <td class="left" colspan="4">            
                <label class="input-control checkbox" onclick="">
                    <asp:CheckBox ID="Chkicicibank" runat="server"/>
                    <span class="helper">ICICI Bank</span>
                </label>
                &nbsp;<label class="input-control checkbox" onclick="">
                    <asp:CheckBox ID="Chkobc" runat="server"  />
                    <span class="helper">Oriental Bank Of Commerce</span>
                </label>
                <label class="input-control checkbox" onclick="">
                    <asp:CheckBox ID="Chkall" runat="server"  AutoPostBack = "true" 
                    oncheckedchanged="Chkall_CheckedChanged" />
                    <span class="helper">All</span>
                </label>
            </td>
        </tr>
        <tr>
            <td>
                From Date
            </td>
            <td class="left">
                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txt_fromDate" runat="server" format="MM/dd/yyyy"></asp:TextBox>
                    <i class="btn-date"></i>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter the from date"
                        Display="None" ControlToValidate="txt_fromDate" ValidationGroup="ValidDate"></asp:RequiredFieldValidator>
                </div>
            </td>
            <td class="left">
                To Date
            </td>
            <td class="left">
                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txt_toDate" runat="server" format="MM/dd/yyyy"></asp:TextBox>
                    <i class="btn-date"></i>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter the To date"
                        Display="None" ControlToValidate="txt_toDate" ValidationGroup="ValidDate"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="right">
            <div align="right">
                <asp:Button ID="btnGO" runat="server" Text="Search" OnClick="btnGO_Click" ValidationGroup="ValidDate" />
                <asp:Button ID="cancel" runat="server" Text="Cancel" onclick="cancel_Click" />
                </div>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidDate"
        ShowMessageBox="true" ShowSummary="false" />
    <div>
        <asp:Label ID="lbl" runat="server" Text="Bank_Name:" Visible="true"></asp:Label>
        <asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Larger"></asp:Label>
        <asp:GridView ID="grdBank" runat="server" AutoGenerateColumns="False" CssClass="gridview"
            AllowPaging="true" ShowFooter="true" PageSize="10" CellPadding="5" OnRowDataBound="grdBank_RowDataBound"
            OnPageIndexChanging="grdBank_PageIndexChanging">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <FooterStyle BackColor="#2D89EF" ForeColor="White" HorizontalAlign="Left" />
            <Columns>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server" Text='<%# Eval("DATE") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotal" runat="server" Text="Total(INR)"></asp:Label>
                       <%-- <asp:Image ID ="img" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="17px" Width="18px" />--%>
                       <br></br>
                        <asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total(INR)"></asp:Label>
                    </FooterTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Voucher No.">
                    <ItemTemplate>
                        <asp:Label ID="lblvouchno" runat="server" Text='<%# Eval("VouchNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Code">
                    <ItemTemplate>
                        <asp:Label ID="lblacountcode" runat="server" Text='<%# Eval("Account_Code") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Account Head">
                    <ItemTemplate>
                        <asp:Label ID="lblacounthead" runat="server" Text='<%# Eval("Account_Head") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Particulars">
                    <ItemTemplate>
                        <asp:Label ID="lblParticulars" runat="server" Text='<%# Eval("Particulars") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cheque No.">
                    <ItemTemplate>
                        <asp:Label ID="lblChqNo" runat="server" Text='<%# Eval("Chq_No") %>'></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Debit Amount(INR)">
                    <ItemTemplate>
                        <asp:Label ID="lblDebitAmt" runat="server" Text='<%# Eval("DEBITAMOUNT") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblTotalDebit" runat="server" Font-Bold="true"></asp:Label>
                        <br></br>
                        <asp:Label ID="lblgrandtotal123" runat="server" Font-Bold="true"></asp:Label>
                    </FooterTemplate>
                </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="Credit Amount">
                    <ItemTemplate>
                        <asp:Label ID="lblcridetamount" runat="server" Text='<%# Eval("CREDITAMOUNT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
    <br />
    <div align="right">
    <asp:Button ID="btnBack" runat="server" Text="Back" onclick="btnBack_Click1" />
        <asp:Button ID="btnExport" runat="server" Text="Exoprt To Excel" Width="150px" OnClick="btnExport_Click" />

    </div>
</asp:Content>
