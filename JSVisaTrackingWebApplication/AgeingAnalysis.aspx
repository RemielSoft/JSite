<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" ValidateRequest="true"
    CodeBehind="AgeingAnalysis.aspx.cs" Inherits="JSVisaTrackingWebApplication.AgeingAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modal
        {
            position: fixed;
            top: 0;
            left: 0;
            background-color: #fff;
            z-index: 99;
            opacity: 0.8;
            filter: alpha(opacity=80);
            -moz-opacity: 0.8;
            min-height: 100%;
            width: 100%;
        }
        .loading
        {
            font-family: Arial;
            font-size: 10pt;
            font-weight: bold;
            color: Blue;
            width: 180px;
            height: 80px;
            display: none;
            position: fixed;
            background-color: transparent;
            z-index: 999;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">

        function ShowProgress() {
            if (Page_ClientValidate()) {
                setTimeout(function () {
                    var modal = $('<div />');
                    modal.addClass("modal");
                    $('body').append(modal);
                    var loading = $(".loading");
                    loading.show();
                    var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                    var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                    loading.css({ top: top, left: left });
                }, 200);
            }
        }
        //    $('form').live("submit", function () {
        //        ShowProgress();
        //    });
    </script>
    <asp:ValidationSummary ID="Summary" runat="server" ForeColor="Red" ValidationGroup="a" DisplayMode="List"
        ShowMessageBox="true" ShowSummary="false" />
    <asp:UpdatePanel ID="panel1" runat="server">
        <ContentTemplate>
            <h2>
                <i class="fg-color-blue icon-calculate"></i>Ageing Analysis
            </h2>
            <table class="table table-bordered table-striped table-condensed">
                <tr>
                    <td class="left">
                        Start Day (In No.) <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txtStartDay" runat="server"></asp:TextBox>
                            <button class="btn-clear" />
                            </button>
                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtStartDay"
                                ForeColor="Red" ErrorMessage="Plz Fill Start Day." ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CV1" Operator="DataTypeCheck" runat="server" Type="Integer"
                                ErrorMessage="Plz Fill Only Numeric Start Day." ValidationGroup="a" Display="None"
                                ControlToValidate="txtStartDay" ForeColor="Red"></asp:CompareValidator>
                        </div>
                    </td>
                    <td class="left">
                        End Day (In No.) <span class="red">*</span>
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:TextBox ID="txtEndDay" runat="server"></asp:TextBox>
                            <button class="btn-clear" />
                            </button>
                            <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="txtEndDay"
                                ForeColor="Red" ErrorMessage="Plz Fill End Day." ValidationGroup="a" Display="None"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CV2" Operator="DataTypeCheck" runat="server" Type="Integer"
                                ErrorMessage="Plz Fill Only Numeric End Day." ValidationGroup="a" Display="None"
                                ControlToValidate="txtEndDay" ForeColor="Red"></asp:CompareValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="left">
                        Agent Name
                    </td>
                    <td class="left" colspan="3">
                        <div class="input-control select">
                            <asp:DropDownList ID="ddlAgent" runat="server" Width="350px">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
            </table>
            <br />
            <div align="right">
                <asp:Button ID="btnAgeingAnalysis" runat="server" Text="Ageing Analysis" Width="120px"
                    OnClick="btnAgeingAnalysis_Click" ValidationGroup="a" OnClientClick="ShowProgress();"
                    CausesValidation="False" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            </div>
            <div>
                <asp:GridView ID="grdvAgeingAnalysis" runat="server" AutoGenerateColumns="False"
                    ShowFooter="true" CssClass="gridview" AllowPaging="false" PageSize="10" CellPadding="5"
                    OnRowDataBound="grdvAgeingAnalysis_RowDataBound" OnRowCreated="grdvAgeingAnalysis_RowCreated">
                    <HeaderStyle CssClass="gridViewHeader" />
                    <RowStyle CssClass="gridViewRow" />
                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                    <PagerStyle CssClass="gridViewPager" />
                    <FooterStyle BackColor="#2D89EF" ForeColor="White" HorizontalAlign="Left" />
                    <Columns>
                        <asp:TemplateField HeaderText="Agent Id">
                            <ItemTemplate>
                                <asp:Label ID="lblAgentId" runat="server" Text='<%# Eval("AgentId") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text="Total (INR)" Font-Bold="true" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Agent Name">
                            <ItemTemplate>
                                <asp:Label ID="lblAgentName" runat="server" Text='<%# Eval("AgentName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Bill Amount (INR)">
                            <ItemTemplate>
                                <asp:Label ID="lblBillAmount" runat="server" Text='<%# Eval("TotalBillAmt") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalBillAmount" runat="server" Font-Bold="true" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unallocated Credit (INR)">
                            <ItemTemplate>
                                <asp:Label ID="lblUnallocatedCredit" runat="server" Text='<%# Eval("ReceiptAmount") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalUnallocatedCredit" runat="server" Font-Bold="true" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Balance (INR)">
                            <ItemTemplate>
                                <asp:Label ID="lblBalance" runat="server" Text='<%# Eval("Balance") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotalBalance" runat="server" Font-Bold="true" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div align="right">
                <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick="btnExport_Click" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExport" />
        </Triggers>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAgeingAnalysis" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="loading" align="center">
        Please wait...<br />
        <br />
        <img src="images/Loader.GIF" alt="" />
    </div>
</asp:Content>
