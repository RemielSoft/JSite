<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="EditDeleteConsignment.aspx.cs" Inherits="JSVisaTrackingWebApplication.EditDeleteConsignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-search  fg-color-blue"></i>Edit/Delete Consignment List</h2>
    <table class="table table-bordered table-striped table-condensed">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Following error occurs:"
            ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="Go" />
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="lblfromDate" runat="server" Text="From Date"></asp:Label>
                </td>
                <td>
                    <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                        <asp:TextBox ID="txtfrmdate" runat="server"></asp:TextBox>
                        <i class="btn-date"></i>
                         </div>
                </td>
                <td>
                    <asp:Label ID="lbltodate" runat="server" Text="ToDate"></asp:Label>
                </td>
                <td>
                    <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                        <asp:TextBox ID="txttodate" runat="server"></asp:TextBox>
                        <i class="btn-date"></i>
                    </div>
                    <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="txttodate"
                                    ValidationGroup="Go" ControlToCompare="txtfrmdate" Operator="GreaterThanEqual"
                                    Display="None" Type="Date" ForeColor="Red" ErrorMessage="To Date Can not be Less Then From date" /><br />
                            
                </td>
            </tr>
            <tr>
                <td>
                    Country Name
                </td>
                <td>
                    <div class="input-control select">
                        <asp:DropDownList ID="ddlcountry" runat="server" CausesValidation="true" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>
                    Agent Name
                </td>
                <td>
                    <div class="input-control select">
                        <asp:DropDownList ID="ddlAgent" runat="server" CausesValidation="true" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    Consignment No.
                </td>
                <td colspan="3">
                    <div class="input-control text">
                        <asp:TextBox ID="txtConsignmentNosearch" runat="server">
                        </asp:TextBox>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <div align="right">
        <asp:Button ID="btnGo" align="right" runat="server" Text="Search" OnClick="btnGo_Click" />
    </div>
    <div id="Div1" style="width: 100%; height: auto;" runat="server">
        <asp:GridView runat="server" ID="gridViewConsignment" AutoGenerateColumns="False"
            AllowPaging="True" CssClass="gridview" PageSize="10" OnRowCommand="gridViewConsignment_RowCommand"
            CellPadding="5" OnPageIndexChanging="gridViewConsignment_PageIndexChanging" OnRowDataBound="gridViewConsignment_RowDataBound">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Visa Country">
                    <ItemTemplate>
                        <asp:Label ID="lblvisaCountry" runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Consignment No">
                    <ItemTemplate>
                        <asp:Label ID="lblConsignmentId" runat="server" Text='<%#Eval("ConsignmentId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agent Name">
                    <ItemTemplate>
                        <asp:Label ID="lblCgAgntname" runat="server" Text='<%#Eval("ConsignmentAgent.AgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Submission Date">
                    <ItemTemplate>
                        <asp:Label ID="lblCgSubmissionDate" runat="server" Text='<%#Eval("CgSubmissionDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Collection Date">
                    <ItemTemplate>
                        <asp:Label ID="lblCgEntryDate" runat="server" Text='<%#Eval("CgDeliveryDate","{0:MM/dd/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Collection Status">
                    <ItemTemplate>
                        <asp:Label ID="lblCgDeliveryStatus" runat="server" Text='<%#Eval("CgDeliveryStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="pax name">
                    <ItemTemplate>
                        <asp:GridView ID="gvChildGrid" runat="server" AutoGenerateColumns="false" GridLines="None" ShowHeader="false">
                            <Columns>
                                <asp:BoundField DataField="paxname" HeaderStyle-VerticalAlign="Top"/>
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No. Of Passport">
                    <ItemTemplate>
                        <asp:Label ID="lblCgNoOfPass" runat="server" Text='<%#Eval("CgNoOfPass") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--  <asp:TemplateField HeaderText="Remarks">
                    <ItemTemplate>
                        <asp:Label ID="lblCgRemark" runat="server" Text='<%#Eval("CgRemarks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="145px">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" ToolTip="ConsignmentEdit" CommandName="cmdEdit"
                            ForeColor="Blue" CommandArgument='<%#Eval("ConsignmentId") %>'><i class="icon-pencil black"></i></asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" runat="server" ToolTip="ConsignmentDelete" CommandName="cmdDelete"
                            OnClientClick="return confirm('Are you sure you want to Delete');" ForeColor="Blue"
                            CommandArgument='<%#Eval("ConsignmentId") %>'><i class="icon-remove red"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
