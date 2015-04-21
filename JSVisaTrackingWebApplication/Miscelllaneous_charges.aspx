<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/Default.Master"
    AutoEventWireup="true" CodeBehind="Miscelllaneous_charges.aspx.cs" Inherits="JSVisaTrackingWebApplication.Miscelllaneous_charges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Miscellaneous Charges</h2>
    <table class="table table-bordered table-striped table-condensed">
        <tr>
            <td class="left">
                Description<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                    <button class="btn-clear">
                    </button>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                    ErrorMessage="Please Enter Description" ValidationGroup="validgroup" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
            </td>
            <td class="left" colspan="2">
                <asp:RadioButtonList ID="Rbtnservice" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Service Tax" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Service Charge" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="left">
                Per Consignment/Visa<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="drpvisa" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="c" Text="Per Consignment"></asp:ListItem>
                        <asp:ListItem Value="v" Text="Per Visa"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select Per Consignment/Visa"
                    InitialValue="--Select--" ValidationGroup="validgroup" ControlToValidate="drpvisa"
                    Display="None">
                </asp:RequiredFieldValidator>
            </td>
            <td class="left">
                Amount (INR)<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                    <button class="btn-clear">
                    </button>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"
                        ErrorMessage="Please Enter The NumericValue in Amount" ControlToValidate="txtAmount"
                        ValidationGroup="validgroup" ValidationExpression="^[0-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                        ErrorMessage="Please Enter Amount" ValidationGroup="validgroup" ControlToValidate="txtAmount">
                    </asp:RequiredFieldValidator>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                <asp:Label ID="lblm" runat="server" Text="Mandatory"></asp:Label>
            </td>
            <td class="left" colspan="3">
                <label class="input-control checkbox" onclick="" style="display: none;">
                    <asp:CheckBox ID="CheckMandatory" runat="server" Text="True" />
                    <span class="helper"></span>
                </label>
            </td>
        </tr>
        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
            runat="server" ValidationGroup="validgroup" />
    </table>
    <br />
    <div align="right">
        <asp:Button ID="btnupdate" runat="server" Text="Update" Visible="false" OnClick="btnupdate_Click"
            ValidationGroup="validgroup" />
        <asp:Button ID="BtnAdd" runat="server" Text="Add" OnClick="BtnAdd_Click" ValidationGroup="validgroup" />
        <asp:Button ID="btnc" runat="server" Text="Cancel" OnClick="btnc_Click" />
    </div>
    <div>
        <asp:GridView ID="Grdm" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            OnPageIndexChanging="Grdm_PageIndexChanging" OnRowCommand="Grdm_RowCommand" CellPadding="5"
            CssClass="gridview" PageSize="10">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <%--                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lbldes" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount(INR)">
                    <ItemTemplate>
                        <asp:Label ID="lblamount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Per Consignment/visa">
                    <ItemTemplate>
                        <asp:Label ID="lblper" runat="server" Text='<%# Eval("Per_consignment") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Service Tax">
                    <ItemTemplate>
                        <asp:Label ID="lbltax" runat="server" Text='<%# Eval("ServiceTax") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- <asp:TemplateField HeaderText="Mandatory">
                    <ItemTemplate>
                        <asp:Label ID="lblmandatory" runat="server" Text='<%# Eval("Mandatory") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Service Charge">
                    <ItemTemplate>
                        <asp:Label ID="lblservicecharges" runat="server" Text='<%# Eval("ServiceCharges") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="Edit" CommandName="cmdedit"
                            CommandArgument='<%#Eval("Id") %>'><i class="icon-pencil black" ></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton5" runat="server" ToolTip="Delete" CommandName="cmddelete"
                            CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm ('Are you Sure to Delete?')"><i class=" icon-remove red"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
