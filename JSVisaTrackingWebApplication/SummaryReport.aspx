<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="SummaryReport.aspx.cs" Inherits="JSVisaTrackingWebApplication.SummaryReport" %>

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
    <style type="text/css">
        .style1
        {
            width: 98px;
        }
        .style2
        {
            width: 89%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-keyboard fg-color-blue"></i>Summary Report
    </h2>
    <table class="table table-bordered table-striped table-condensed" id="tbl1" runat="server">
        <tr>
            <td class="left">
                From Date
            </td>
            <td class="left">
                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txt_fromDate" runat="server" format="MM/dd/yyyy"></asp:TextBox>
                    <i class="btn-date"></i>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter The From Date"
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter The To Date"
                        Display="None" ControlToValidate="txt_toDate" ValidationGroup="ValidDate"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Party Name
            </td>
            <td class="left" colspan="3">
                <div class="input-control select">
                    <asp:DropDownList ID="ddlPartyName" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="reqparty" runat="server" ErrorMessage="Please select Party Name"
                        ControlToValidate="ddlPartyName" InitialValue="0" ValidationGroup="ValidDate"
                        Display="None"></asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <div id="divsearch" align="right" runat="server">
        <asp:Button ID="btnGO" runat="server" Text="Search" ValidationGroup="ValidDate" OnClick="btnGO_Click" />
        <asp:Button ID="cancel" runat="server" Text="Cancel" OnClick="cancel_Click" />
    </div>
    <div align="right">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValidDate"
            ShowMessageBox="true" ShowSummary="false" />
    </div>
    <table class="table table-bordered table-striped table-condensed" id="tbl2" runat="server">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Party Name :  "></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblPartyName" runat="server"></asp:Label>
            </td>
            <td class="right">
                <asp:Label ID="Label2" runat="server" Text=" Dates :   "></asp:Label>
            </td>
            <td class="left">
                <%--<asp:Label ID="Label3" runat="server" Text=" Dates :   " Font-Bold="true" Font-Size=""></asp:Label>--%>
                <asp:Label ID="lbldate" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <div style="width:100%; overflow:scroll; overflow-y:hidden; ">
        <asp:GridView ID="grdsummary" runat="server" AutoGenerateColumns="false" CssClass="gridview" AllowPaging="true"
            PageSize="10" OnPageIndexChanging="grdsummary_PageIndexChanging" 
            CellPadding="5">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <%--<asp:TemplateField HeaderText="Party Name">
                    <ItemTemplate>
                        <asp:Label ID="lblparty" runat="server" Text='<%# Eval("PartyName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="lblcountry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No.of Passport">
                    <ItemTemplate>
                        <asp:Label ID="lblnoofpassport" runat="server" Text='<%# Eval("NumberOfPassport") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pax Name">
                    <ItemTemplate>
                        <asp:Label ID="lblPax" runat="server" Text='<%# Eval("PaxName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="23%" Height="10%" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Passport No.">
                    <ItemTemplate>
                        <asp:Label ID="lblpassport" runat="server" Text='<%# Eval("PassportNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lblremarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
        </asp:GridView>
    </div>
    <br />
    <div id="DivExport" align="right" runat="server">
        <asp:Button ID="btncancle" runat="server" Text="Back" OnClick="btncancle_Click" />
        <asp:Button ID="btnexport" runat="server" Text="Export To  Excel " OnClick="btnexport_Click" />
    </div>
</asp:Content>
