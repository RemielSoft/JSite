<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="InvoiceList.aspx.cs" Inherits="JSVisaTrackingWebApplication.InvoiceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Invoice List</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Accounting / Invoice List</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Summery1"
                            HeaderText="Following error occurs:" ShowMessageBox="true" DisplayMode="BulletList"
                            ShowSummary="false" />
                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>For</label>
                                <asp:RadioButtonList ID="rbtnInvoiceLst" runat="server" RepeatDirection="Horizontal"
                                    Width="254px" OnSelectedIndexChanged="rbtnInvoiceLst_SelectedIndexChanged" AutoPostBack="True">
                                    <asp:ListItem Text=" Invoice" Value="1" Selected="True"></asp:ListItem>
                                    <%--    <asp:ListItem Text=" Receipt" Value="2"></asp:ListItem>--%>
                                </asp:RadioButtonList>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <%--<asp:Label ID="lblcon" runat="server" Text="Consignment"></asp:Label>--%>
                                <label>Consignment</label>
                                <asp:TextBox ID="txtConsignMntNO" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:CompareValidator ID="validator" runat="server" ControlToValidate="txtConsignMntNO"
                                    Operator="DataTypeCheck" Type="Integer" ErrorMessage="Consignment must be a Integer"
                                    ValidationGroup="Summery1" Display="None" />
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Invoice Number.</label>
                                <asp:TextBox ID="txtDocumentNo" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:CompareValidator ID="cvDocument" runat="server" ControlToValidate="txtDocumentNo"
                                    Operator="DataTypeCheck" Type="Integer" ErrorMessage="Document must be a Integer"
                                    ValidationGroup="Summery1" Display="None" />
                            </div>
                        </div>

                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>From Date</label>
                                <div class="input-group text datepicker  span4" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txtFromDate" runat="server" format="MM/dd/yyyy" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon glyphicon glyphicon-calendar"></span>
                                </div>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>To Date</label>
                                <div class="input-group text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txtToDate" runat="server" format="MM/dd/yyyy" CssClass="form-control"></asp:TextBox>
                                    <span class="input-group-addon glyphicon glyphicon-calendar"></span>
                                </div>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Agent Name</label>
                                <asp:DropDownList ID="ddlagentName" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="text-right">
                            <asp:Button ID="BtnGo" runat="server" Text="Go" ValidationGroup="Summery1" OnClick="BtnGo_Click" CssClass="button-1" />
                        </div>
                    </div>
                </div>


                <div class="table-responsive">
                    <asp:GridView runat="server" ID="gridviewInvoiceList" AutoGenerateColumns="False"
                        AllowPaging="True" CssClass="gridview table table-bordered table-striped table-condensed" OnPageIndexChanging="gridviewInvoiceList_PageIndexChanging"
                        PageSize="50" CellPadding="5" OnRowCommand="gridviewInvoiceList_RowCommand" Width="100%">
                        <HeaderStyle CssClass="gridViewHeader" />
                        <RowStyle CssClass="gridViewRow" />
                        <AlternatingRowStyle CssClass="gridViewAltRow" />
                        <SelectedRowStyle CssClass="gridViewSelectedRow" />
                        <PagerStyle CssClass="gridViewPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="Invoice Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocDate" runat="server" Text='<%#Eval("BillDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDocdate" runat="server" Text='<%#Eval("BillDate","{0:MM/dd/yyyy}") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Invoice Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocNo" runat="server" Text='<%#Eval("BillId") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBillId" runat="server" Text='<%#Eval("BillId") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Applicant Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblDocType" runat="server" Text='<%#Eval("Paxs") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDocType" runat="server" Text='<%#Eval("Paxs") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Corporate Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("BillConsignment.CgCorporate") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtClient" runat="server" Text='<%#Eval("BillConsignment.CgCorporate") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Visa Country">
                                <ItemTemplate>
                                    <asp:Label ID="lblcountryname" runat="server" Text='<%#Eval("PaxDetails.CountryName") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtcountryname" runat="server" Text='<%#Eval("PaxDetails.CountryName") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No. of Passports">
                                <ItemTemplate>
                                    <asp:Label ID="lblNoOfPassport" runat="server" Text='<%#Eval("BillConsignment.CgNoOfPass") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNoOfPassport" runat="server" Text='<%#Eval("BillConsignment.CgNoOfPass") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Consignment Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblRefNo" runat="server" Text='<%#Eval("ConsignmentId") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRefNo" runat="server" Text='<%#Eval("ConsignmentId") %>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>

                            <%--<asp:CommandField HeaderText="Action" ShowCancelButton="true" ShowEditButton="true" ShowDeleteButton="true" />--%>
                            <asp:TemplateField HeaderText="Print">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linbtnPrint" runat="server" CommandName="Print" CommandArgument='<%#Eval("BillId")+","+Eval("Version")%>'
                                        ToolTip="Print"><i class="glyphicon glyphicon-print"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
