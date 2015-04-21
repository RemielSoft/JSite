<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="EmbassyFees.aspx.cs" Inherits="JSVisaTrackingWebApplication.EmbassyFees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class=" icon-user-2 fg-color-blue"></i>EMBASSY FEES MASTER
    </h2>
    <script type="text/javascript">
        function confirmation() 
        {
            if (confirm('Are you sure you want to Delete ?')) 
            {
                return true;
            } else 
            {
                return false;
            }
        }
    </script>
    <table class="bordered">
        <tr>
            <td class="left">
                <strong>Embassy Country</strong>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_embsycountry"
                    ErrorMessage="*" ForeColor="Red" InitialValue="0"
                    ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left" colspan="3">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_embsycountry" runat="server" CausesValidation="true" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left" colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="left">
                Visa Type
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_visatype"
                    ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_visatype" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td class="left">
                &nbsp;
            </td>
            <td class="left">
            </td>
        </tr>
        <tr>
            <td class="left">
                Visa Duration
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_visaduration"
                    ErrorMessage="*" ForeColor="Red" InitialValue="0"
                    ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_visaduration" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td class="left">
                Process Time
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_processtime"
                    ErrorMessage="*" ForeColor="Red" InitialValue="0"
                    ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_processtime" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Number of Visit
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_no_ofvisit"
                    ErrorMessage="*" ForeColor="Red" InitialValue="0"
                    ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_no_ofvisit" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </td>
            <td class="left">
                Fees
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_fees"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_fees" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
    </table>
    <div align="right">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn_save" runat="server" Text="Save" OnClick="btn_save_Click" ValidationGroup="a" />
        <asp:Button ID="btn_update" runat="server" Text="Update" Visible="false" OnClick="btn_update_Click"
            ValidationGroup="a" />
        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" OnClick="btn_cancel_Click" />
    </div>
    <div>
        <asp:GridView ID="gv_embsyfees" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            CssClass="gridview" PageSize="10" CellPadding="5" OnPageIndexChanging="gv_embsyfees_PageIndexChanging"
            OnRowCommand="gv_embsyfees_RowCommand">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("EmbsyMasterId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="lblcontry" runat="server" Text='<%# Eval("country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visa Type">
                    <ItemTemplate>
                        <asp:Label ID="lblvisatype" runat="server" Text='<%# Eval("visatype") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No. of Visit">
                    <ItemTemplate>
                        <asp:Label ID="lblno_ofvisit" runat="server" Text='<%# Eval("NoOfVisit") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fees">
                    <ItemTemplate>
                        <asp:Label ID="lblfees" runat="server" Text='<%# Eval("fees") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visa Duration">
                    <ItemTemplate>
                        <asp:Label ID="lblvisaduration" runat="server" Text='<%# Eval("DurationDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Process Time">
                    <ItemTemplate>
                        <asp:Label ID="lblprocesstime" runat="server" Text='<%# Eval("ProcessTimeDesc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="cmdedit" CommandArgument='<%# Eval("EmbsyMasterId") %>'
                            ToolTip="Edit"><i class="icon-pencil black"></i></asp:LinkButton>&nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="cmddel" CommandArgument='<%# Eval("EmbsyMasterId") %>'
                            ToolTip="Delete" OnClientClick="return confirmation();"><i class=" icon-remove red"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div align="right">
        <asp:HyperLink ID="linkembsyMASTER" runat="server" Text="GO TO EMBASSY MASTER PAGE"
            NavigateUrl="~/EmbassyMaster.aspx" Font-Bold="true" ForeColor="olive"></asp:HyperLink>
    </div>
</asp:Content>
