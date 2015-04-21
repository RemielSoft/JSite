<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="EmbassyMaster.aspx.cs" Inherits="JSVisaTrackingWebApplication.EmbassyMaster1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="scriptManager1" runat="server"></asp:ScriptManager>
    <asp:ValidationSummary ID="EmbMasterSummary" runat="server" ShowMessageBox="true" DisplayMode="List" ShowSummary="false" ValidationGroup="a" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" ValidationGroup="search" />
    <h2>
        <i class=" icon-user-2 fg-color-blue"></i>Embassy Country Master
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
    <asp:UpdatePanel ID="updatePanel1" runat="server">
    <ContentTemplate>
    <table class="table table-bordered table-striped table-condensed">
        <tr>
            <td class="left">
                <strong>Embassy Country</strong> <span class="red">*</span>
                <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="ddl_embsycountry"
                    ErrorMessage="Please Select Embassy Country." Display="None" InitialValue="0" ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left" colspan="3">
                <div class="input-control select">
                    <asp:DropDownList ID="ddl_embsycountry" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        
        <tr>
            <td class="left">
                Visa Duration Status <span class="red">*</span>
            </td>
            <td class="left">
                <asp:RadioButtonList ID="rbtnlst_visadurationlist" runat="server" RepeatDirection="Horizontal"
                    Width="254px" AutoPostBack="True" 
                    onselectedindexchanged="rbtnlst_visadurationlist_SelectedIndexChanged">
                    <asp:ListItem Text=" Enable" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text=" Disable" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="left">
                Process Time Status <span class="red">*</span>
            </td>
            <td class="left">
                <asp:RadioButtonList ID="rdblst_processtime" runat="server" RepeatDirection="Horizontal"
                    Width="254px" AutoPostBack="True" 
                    onselectedindexchanged="rdblst_processtime_SelectedIndexChanged">
                    <asp:ListItem Text=" Enable" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text=" Disable" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="left">
                Token Fees (INR) <span class="red">*</span>
                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="txt_tokenfee" Display="None"
                    ErrorMessage="Please Fill Token Fee." ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CV1" Operator="DataTypeCheck" runat="server" Type="Double" 
                        ErrorMessage="Please Fill Token Fee With Only Numeric Value." ValidationGroup="a" Display="None" 
                        ControlToValidate="txt_tokenfee" ForeColor="Red" ></asp:CompareValidator>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_tokenfee" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Attestation Fees (INR) <span class="red">*</span>
                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="txt_attentfee" Display="None"
                    ErrorMessage="Please Fill Attestation Fee." ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CV2" Operator="DataTypeCheck" runat="server" Type="Double" 
                        ErrorMessage="Please Fill Attestation Fee With Only Numeric Value." ValidationGroup="a" Display="None" 
                        ControlToValidate="txt_attentfee" ForeColor="Red" ></asp:CompareValidator>
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
                VFS/BLS/TTS (INR) <span class="red">*</span>
                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txt_vfs_bls"
                    Display="None" ErrorMessage="Please Fill VFS/BLS/TTS Fee." ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CV3" Operator="DataTypeCheck" runat="server" Type="Double" 
                        ErrorMessage="Please Fill VFS/BLS/TTS Fee With Only Numeric Value." ValidationGroup="a" Display="None" 
                        ControlToValidate="txt_vfs_bls" ForeColor="Red" ></asp:CompareValidator>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_vfs_bls" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Handling Fees (INR) <span class="red">*</span>
                <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="txt_handlingfee"
                    Display="None" ErrorMessage="Please Fill Handling Fee." ForeColor="Red" ValidationGroup="a"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CV4" Operator="DataTypeCheck" runat="server" Type="Double" 
                        ErrorMessage="Please Fill Handling Fee With Only Numeric Value." ValidationGroup="a" Display="None" 
                        ControlToValidate="txt_handlingfee" ForeColor="Red" ></asp:CompareValidator>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_handlingfee" runat="server"></asp:TextBox>
                    <button class="btn-clear">
                    </button>
                </div>
            </td>
        </tr>        
    </table>
    <br />
    <div align="right">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="a" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click1"
            ValidationGroup="a" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click1" />
    </div>
    <table class="table table-bordered table-striped table-condensed">    
        <tr>
            <td class="left" width="190px">
                Search By Country
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddlCountry" runat="server" CausesValidation="true" AutoPostBack="true">
                    </asp:DropDownList>
                    <asp:LinkButton ID="lknbtnSearch" runat="server" onclick="lknbtnSearch_Click" ValidationGroup="search"><i class="icon-search black"></i></asp:LinkButton>
                </div>
                 </td>
        </tr>
    </table>
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
                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("EmbsyMasterId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <ItemTemplate>
                        <asp:Label ID="lblcontry" runat="server" Text='<%# Eval("Country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Visa Duration Status">
                    <ItemTemplate>
                        <asp:Label ID="lblvisaduration" runat="server" Text='<%# Eval("DurationDescription") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Process Time Status">
                    <ItemTemplate>
                        <asp:Label ID="lblprocesstime" runat="server" Text='<%# Eval("ProcessTimeDesc") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="VFS/BLS/TTS Fees (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbltts" runat="server" Text='<%# Eval("VfsBlsFee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Token Fees (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lbltokenfee" runat="server" Text='<%# Eval("TokenFee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Attestation Fees (INR)">
                    <ItemTemplate>
                        <asp:Label ID="lblattastationfee" runat="server" Text='<%# Eval("AttastationFee") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Handling Fees (INR)">
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
    </ContentTemplate>
    
    </asp:UpdatePanel>   
</asp:Content>
