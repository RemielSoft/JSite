<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="PrintInvoice.aspx.cs" Inherits="JSVisaTrackingWebApplication.PrintInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Print Invoice</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Utilities / Print Invoice</div>
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
                            <div class="col-sm-3 col-xs-12">
                                <label>Consignment No.</label>
                                 <asp:TextBox ID="txtConsignmentNo" runat="server" CssClass="form-control"></asp:TextBox>
                                  <asp:CompareValidator ID="validator" runat="server" ControlToValidate="txtConsignmentNo"
                    Operator="DataTypeCheck" Type="Integer" ErrorMessage="Consignment must be a Integer"
                    ValidationGroup="Summery1" Display="None" />
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <label>Consignment Date From</label>
                                  <div class="input-group text datepicker" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txtFromDate" runat="server" format="yyyy-MM-dd" CssClass="form-control"></asp:TextBox>
                    <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                </div>
                                </div>
                            <div class="col-sm-3 col-xs-12">
                                <label>Consignment Date To</label>
                                 <div class="input-group text datepicker" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txtEndDate" runat="server" format="yyyy-MM-dd" CssClass="form-control"></asp:TextBox>
                    <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                </div>
                                </div>
                             <div class="col-sm-3 col-xs-12">
                                <label>Agent Name</label>
                                  <asp:DropDownList ID="ddlagentName" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                                 </div>
                        </div>
                          <div class="text-right">
        <asp:Button ID="btnSearch" runat="server" Text="Go" ValidationGroup="Summery1" OnClick="btnSearch_Click"  CssClass="button-1"/>
    </div>
                    </div>
                </div>
         


    <div class="table-responsive">
        <asp:GridView runat="server" ID="gridviewPrintInvoice" AutoGenerateColumns="False"
            AllowPaging="True" CssClass="gridview table table-bordered table-striped table-condensed" OnPageIndexChanging="gridviewPrintInvoice_PageIndexChanging"
            PageSize="10" CellPadding="5"
            OnRowCommand="gridviewPrintInvoice_RowCommand" Width="100%">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Client Id">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Visa_City" runat="server" Text='<%#Eval("BillConsignment.FkAgentId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date">
                    <ItemTemplate>
                        <asp:Label ID="lbl_country" runat="server" Text='<%#Eval("BillConsignment.CgDate" ,"{0:dd MMM yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consignment No.">
                    <ItemTemplate>
                        <asp:Label ID="lbl_title" runat="server" Text='<%#Eval("ConsignmentId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Client Name">
                    <ItemTemplate>
                        <asp:Label ID="lbl_Form" runat="server" Text='<%#Eval("AgentDetails.AgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="linbtnPrint" runat="server" CommandName="Print" CommandArgument='<%#Eval("ConsignmentId") %>'
                            ToolTip="Edit"><i class="glyphicon glyphicon-edit" ></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </div>
                   </div>
        </div>
    </div>
</asp:Content>
