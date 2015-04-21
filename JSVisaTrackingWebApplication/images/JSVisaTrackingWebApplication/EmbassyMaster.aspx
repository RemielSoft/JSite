<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="EmbassyMaster.aspx.cs" Inherits="JSVisaTrackingWebApplication.EmbassyMaster1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class=" icon-user-2 fg-color-blue"></i>Embassy Master
    </h2>
    <script type="text/javascript">
        function confirmation() {
            if (confirm('Are you sure you want to Delete ?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>
    <table class="bordered">
        <tr>
            <td class="left">
                <strong>Embassy Country</strong><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_embsycountry"
                    ErrorMessage="*" InitialValue="0" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left" colspan="3">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_embsycountry" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left" colspan="4">
                &nbsp; &nbsp; &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td class="left">
                Visa Duration Status
            </td>
            <td class="left">
                <asp:RadioButtonList ID="rbtnlst_visadurationlist" runat="server" RepeatDirection="Horizontal"
                    Width="254px">
                    <asp:ListItem Text=" Enable" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text=" Disable" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="left">
                Process Time Status
            </td>
            <td class="left">
                <asp:RadioButtonList ID="rdblst_processtime" runat="server" RepeatDirection="Horizontal"
                    Width="254px">
                    <asp:ListItem Text=" Enable" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text=" Disable" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="left">
                Token Fee
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_tokenfee"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_tokenfee" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Attestation Fee
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_attentfee"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_attentfee" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                VFS / BLS / TTS
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_vfs_bls"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_vfs_bls" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Handling Fee
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_handlingfee"
                    ErrorMessage="*" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                &nbsp;
                <div class="input-control text">
                    <asp:TextBox ID="txt_handlingfee" runat="server"></asp:TextBox>
                    <button class="btn-clear">
                    </button>
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
                &nbsp;
            </td>
            <td class="left">
                &nbsp;
            </td>
        </tr>
    </table>
    <div align="right">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="a" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click1"
            ValidationGroup="a" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click1" />
    </div>
    <div>
        <asp:GridView ID="gv_embsymaster" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            OnRowCommand="gv_embsymaster_RowCommand" OnPageIndexChanging="gv_embsymaster_PageIndexChanging"
            CssClass="gridview" PageSize="10" CellPadding="5">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Master Id">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("EmbsyMasterId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="lblcontry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
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
                <asp:TemplateField HeaderText="VFS/BLS/TTS Fees">
                    <ItemTemplate>
                        <asp:Label ID="lbltts" runat="server" Text='<%# Eval("VfsBlsFee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Token Fees">
                    <ItemTemplate>
                        <asp:Label ID="lbltokenfee" runat="server" Text='<%# Eval("TokenFee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Attestation Fees">
                    <ItemTemplate>
                        <asp:Label ID="lblattastationfee" runat="server" Text='<%# Eval("AttastationFee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Handling Fees">
                    <ItemTemplate>
                        <asp:Label ID="lblHandlingfee" runat="server" Text='<%# Eval("HandlingFee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CommandName="cmdedit" CommandArgument='<%# Eval("EmbsyMasterId") %>'
                            ToolTip="Edit"><i class="icon-pencil black"></i></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton5" runat="server" CommandName="cmddel" CommandArgument='<%# Eval("EmbsyMasterId") %>'
                            ToolTip="Delete" OnClientClick="return confirmation();"><i class=" icon-remove red"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>    
</asp:Content>
