<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="Miscelllaneous_charges.aspx.cs" Inherits="JSVisaTrackingWebApplication.Miscelllaneous_charges" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=CheckService.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;

            }
        }
    </script>
    <h2>
        Miscellaneous Charges</h2>
    <table class="bordered">
        <tr>
            <td class="left">
                Description<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                    ErrorMessage="Please Enter The Description" ValidationGroup="validgroup" ControlToValidate="txtDescription">
                </asp:RequiredFieldValidator>
            </td>
            <td class="left">
                Amount(INR)<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"  Display="None"
                    ErrorMessage="Please Enter The NumericValue in Amount" ControlToValidate="txtAmount" ValidationGroup="validgroup"
                    ValidationExpression="^[1-9]\d*(\.\d+)?$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                    ErrorMessage="Please Enter The Amount" ValidationGroup="validgroup" ControlToValidate="txtAmount">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="left">
                Per Consignmend/Visa<span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="drpvisa" runat="server">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="c" Text="Per Consignmend"></asp:ListItem>
                        <asp:ListItem Value="v" Text="Per Visa"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Select The Consignmend/Visa"
                    InitialValue="--Select--" ValidationGroup="validgroup" ControlToValidate="drpvisa"
                    Display="None">
                </asp:RequiredFieldValidator>
            </td>
               <td class="left">
                ServiceTax<span class="red">*</span>
            </td>
            <td class="left">
                <label class="input-control checkbox" onclick="">
                    <asp:CheckBox ID="CheckService" runat="server" />
                    <span class="helper"></span>
                </label>
                <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please check ServiceTax"
                    ClientValidationFunction="ValidateCheckBox" ValidationGroup="validgroup"  Display="None"></asp:CustomValidator><br />
            </td>
           <%-- <td class="left">
            </td>
            <td class="left">
            </td>--%>
        </tr>
        <tr>
            <td class="left">
                <asp:Label ID="lblm" runat="server" Text="Mandatory"></asp:Label>
            </td>
            <td class="left">
                <label class="input-control checkbox" onclick="" style="display: none;">
                    <asp:CheckBox ID="CheckMandatory" runat="server" Text="True" />
                    <span class="helper"></span>
                </label>
            </td>
         
        </tr>
         <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
        runat="server" ValidationGroup="validgroup" />
        <tr>
            <td colspan="4" class="right">
                <asp:Label ID="lbll_msg" runat="server" ForeColor="Red"></asp:Label>
                <asp:Button ID="btnupdate" runat="server" Text="UPDATE" Visible="false" OnClick="btnupdate_Click" />
                <asp:Button ID="BtnAdd" runat="server" Text="ADD" OnClick="BtnAdd_Click" ValidationGroup="validgroup" />
                <asp:Button ID="btnc" runat="server" Text="CANCLE" OnClick="btnc_Click" />
            </td>
        </tr>
    </table>
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
                <asp:TemplateField HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Description">
                    <ItemTemplate>
                        <asp:Label ID="lbldes" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <asp:Label ID="lblamount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Per_consignment/visa">
                    <ItemTemplate>
                        <asp:Label ID="lblper" runat="server" Text='<%# Eval("Per_consignment") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ServiceTax">
                    <ItemTemplate>
                        <asp:Label ID="lbltax" runat="server" Text='<%# Eval("ServiceTax") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mandatory">
                    <ItemTemplate>
                        <asp:Label ID="lblmandatory" runat="server" Text='<%# Eval("Mandatory") %>'></asp:Label>
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
