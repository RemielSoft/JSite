<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="GenerateInvoiceForm.aspx.cs" Inherits="JSVisaTrackingWebApplication.GenerateInvoiceForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmationSave() {
            if (confirm('Are you sure you want to Save ?')) {
                return true;
            } else {
                return false;
            }
        }

        function confirmationPreview() {

        }
    </script>
    <script type="text/javascript">

        function confirmation() {
            if (confirm('Are you sure you want to Generate Invoice ?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>
    <script type="text/javascript">
        function confirmationGenerate() {
            if (confirm('Are you sure you want to Generate Invoice ?')) {
                return true;
            } else {
                return false;
            }
        }

    </script>
      <style type="text/css">
        #table-3
        {
            border: 1px solid #5D7B9D;
            background-color: #F9F9F9;
            width: 100%;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            -border-radius: 3px;
            font-family: Arial, "Bitstream Vera Sans" ,Helvetica,Verdana,sans-serif;
            color: #333;
        }
        #table-3 td, #table-3 th
        {
            border-top-color: white;
            border-bottom: 1px solid #DFDFDF;
            color: #555;
            font-weight: bold;
        }
        #table-3 th
        {
            font-family: Arial, "Bitstream Vera Sans" ,Helvetica,Verdana,sans-serif;
            font-weight: normal;
            padding: 7px 7px 8px;
            text-align: left;
            line-height: 1.3em;
            font-size: 14px;
            font-weight: bold;
            color: #5D7B9D;
        }
        #table-3 td
        {
            font-size: 12px;
            padding: 4px 7px 2px;
            vertical-align: top;
        }
        input.textbox
        {
        }
        
        .div-popupp
        {
            background-color: #fff;
            -moz-box-shadow: 0px 3px 7px 0px #070101;
            -webkit-box-shadow: 0px 3px 7px 0px #070101;
            box-shadow: 0px 3px 7px 0px #070101;
            padding: 0px 0px 0px 0px;
            width: 300px;
            height: 180px;
        }
        
        .popup-close
        {
            position: absolute;
            top: 5px;
            right: 5px;
        }
        
        .message-dialogg
        {
            position: relative;
            top: 0px;
            left: 0px;
            width:300px;
            height: 30px;
            top: 0px;
            float: left;
            padding: 5px 5px;
            background: #3C86D7;
            color: #ffffff;
            font-family: Arial, Sans-Serif, Verdana;
            font-size: 13px;
            font-weight: bold;
        }
        
        .ScrollPopp
        {
            position: relative;
            width: 500px;
            height: 500px;
            top: 20px;
        }
        .pop
        {
            width: 300px;
            height: 300px;  
        }
        .displaynone
        {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Following error occurs:"
        ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="Mic" />
    <h2>
        <b><i class="  icon-file-word fg-color-blue"></i>Generate Invoice...</b></h2>
    <div align="right">
        <div class="input-control select">
            <asp:DropDownList ID="ddlMiscelaCharge" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlMiscelaCharge"
                ErrorMessage="Please Select Miscellaneous Charge" Display="None" InitialValue="0"
                SetFocusOnError="True" ValidationGroup="Mic"></asp:RequiredFieldValidator>
            <asp:Button ID="BtnAddMiscellaneousCharge" runat="server" Text="Add Charge" Width="200px"
                OnClick="BtnAddMiscellaneousCharge_Click" ValidationGroup="Mic" />
        </div>
        <table class="table table-bordered table-striped table-condensed">
            <tr>
                <td class="left">
                    <asp:Label ID="lblinvtype" runat="server" Text="Invoice Type" Font-Bold="True"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="rbtnInvoice" runat="server" RepeatDirection="Horizontal"
                        AutoPostBack="true" OnSelectedIndexChanged="rbtnInvoice_SelectedIndexChanged">
                        <asp:ListItem Text="Advance" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Normal" Value="2" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Additional" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td colspan="2" align="right">
                    <asp:Label ID="Label1" runat="server" Text="Agent Name:"></asp:Label>
                    <asp:Label ID="lblAgentName" runat="server" BackColor="#CCCCCC" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="left" colspan="1">
                    <asp:Label ID="lblAdjAmt" runat="server" Text="Do you Want to Adjust Advance Amount Against Reciept No."
                        Font-Bold="True" Visible="false"></asp:Label>
                </td>
                <td colspan="3" align="right">
                    <asp:CheckBoxList ID="chkAdjestAdvance" runat="server" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server">
                    <asp:GridView ID="gvInvoice" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                        PageSize="20" CssClass="gridview" CellPadding="5" Width="100%" DataKeyNames=""
                        OnPageIndexChanging="gvInvoice_PageIndexChanging" OnRowCancelingEdit="gvInvoice_RowCancelingEdit"
                        OnRowEditing="gvInvoice_RowEditing" OnRowUpdating="gvInvoice_RowUpdating" OnRowCommand="gvInvoice_RowCommand1">
                        <HeaderStyle CssClass="gridViewHeader" />
                        <RowStyle CssClass="gridViewRow" />
                        <AlternatingRowStyle CssClass="gridViewAltRow" />
                        <SelectedRowStyle CssClass="gridViewSelectedRow" />
                        <PagerStyle CssClass="gridViewPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="Description">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDesc" runat="server" Text='<%#Eval("BillItemDescription") %>'
                                        Enabled="False" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("BillItemDescription") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Charge">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRate" runat="server" Text='<%#Eval("ItemCharge") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="17px"
                                        Width="18px" />
                                    <asp:Label ID="lblRate" runat="server" Text='<%# Eval("ItemCharge") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Quantity">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtqty" runat="server" Text='<%#Eval("ItemQuantity") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblqty" runat="server" Text='<%# Eval("ItemQuantity") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtamt" runat="server" Text='<%#Eval("ItemAmount") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="17px"
                                        Width="18px" />
                                    <asp:Label ID="lblamt" runat="server" Text='<%# Eval("ItemAmount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <EditItemTemplate>
                                    <asp:LinkButton ID="linbtn_update" runat="server" CommandName="Update" ToolTip="Update"><i class=" icon-loading-2 fg-color-greenDark"></i></asp:LinkButton>
                                    <asp:LinkButton ID="linbtn_cancel" runat="server" CommandName="Cancel" ToolTip="Cancel"><i class="icon-cancel-2 red"></i></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:LinkButton ID="linbtn_edit" runat="server" CommandName="Edit" ToolTip="Edit"
                                        CommandArgument='<%#Container.DataItemIndex %>'><i class="icon-pencil black"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <table>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table class="table table-bordered table-striped table-condensed">
                        <tr>
                            <td width="500px" colspan="2">
                            </td>
                            <td class="style2">
                                Total Amount
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:Image ID="imgRsTolal" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="20px"
                                        Width="18px" />
                                    <asp:TextBox ID="txt_totalAmt" runat="server" AutoPostBack="true" OnTextChanged="txt_totalAmt_TextChanged"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                            <td class="style2">
                                Service Charge
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:Image ID="imgRsService" runat="server" ImageUrl="~/image/Rupees-symbol.png"
                                        Height="20px" Width="18px" />
                                    <asp:TextBox ID="txt_serviceCharge" runat="server" OnTextChanged="txt_serviceCharge_TextChanged"
                                        AutoPostBack="true"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                            <td class="style7">
                                Service Tax
                                <asp:Label ID="lbl_serviceTax" runat="server" BackColor="#99CCFF" ForeColor="Black"></asp:Label>
                            </td>
                            <td class="style8">
                                <div class="input-control text">
                                    <asp:Image ID="imgrsTax" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="20px"
                                        Width="18px" />
                                    <asp:TextBox ID="txt_serviceTax" runat="server" OnTextChanged="txt_serviceTax_TextChanged"
                                        AutoPostBack="true"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                            </td>
                            <td class="style2">
                                Net Amount
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:Image ID="imgRsNetAmount" runat="server" ImageUrl="~/image/Rupees-symbol.png"
                                        Height="20px" Width="18px" />
                                    <asp:TextBox ID="txt_NetAmt" runat="server"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div>
                        <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
                            PopupControlID="pnlpopup" DynamicServicePath="" Enabled="true">
                        </asp:ModalPopupExtender>
                        <asp:Panel ID="pnlpopup" CssClass="div-popupp" runat="server">
                            <div class="message-dialogg">
                                Supper Admin Login
                            </div>
                            <div class="ScrollPopp">
                                <table>
                                    <tr>
                                        <td>
                                            User Name:<span class="red">*</span>
                                        </td>
                                        <td>
                                            <div class="input-control text">
                                                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                                <hr />
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Password:<span class="red">*</span>
                                        </td>
                                        <td>
                                            <div class="input-control text">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                    <td colspan="2">
                                        <asp:Label ID="Label3" runat="server" Text="" ForeColor="#FF0066"></asp:Label>
                                    </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="right">
                                            <asp:Button ID="btnLogin" runat="server" Text="Ok" Width="62px" OnClick="btnLogin_Click" />
                                            <asp:Button ID="btnCnl" runat="server" Text="Exit" OnClick="btnCnl_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Panel ID="Panel3" runat="server">
            <div>
                <table id="table-3">
                    <thead>
                        <tr>
                            <th>
                                Item Entries :
                            </th>
                            <th colspan="3">
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr valign="middle">
                            <td width="30%">
                                Description :
                                <asp:TextBox ID="txtItemDesc" runat="server" CssClass="textbox1" TabIndex="4" Width="176px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvItem" runat="server" ControlToValidate="txtItemDesc"
                                    ErrorMessage="Item Description is Required" ForeColor="Red" ValidationGroup="add">*</asp:RequiredFieldValidator>
                            </td>
                            <td width="20%">
                                &nbsp;&nbsp;&nbsp;&nbsp; Quantity :
                                <asp:TextBox ID="txtQuantity" runat="server" AutoPostBack="True" CssClass="textbox"
                                    MaxLength="10" OnTextChanged="txtQuantity_TextChanged" ValidationGroup="add"
                                    TabIndex="5" Width="71px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity"
                                    ErrorMessage="Quantity is Required" ForeColor="Red" ValidationGroup="add">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revQuantity" runat="server" ControlToValidate="txtQuantity"
                                    ErrorMessage="Only Numeric Value is Allowed" ValidationGroup="add" ForeColor="Red"
                                    ValidationExpression="^\d{0,7}(\.\d{1,2})?$">*
                                </asp:RegularExpressionValidator>
                            </td>
                            <td width="25%">
                                Rate :
                                <asp:TextBox ID="txtRate" runat="server" AutoPostBack="True" CssClass="textbox" MaxLength="7"
                                    OnTextChanged="txtRate_TextChanged" TabIndex="6" Width="116px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvRate" runat="server" ControlToValidate="txtRate"
                                    ErrorMessage="Rate Per Unit is Required" ForeColor="Red" ValidationGroup="add">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revRate" runat="server" ControlToValidate="txtRate"
                                    ErrorMessage="Only Numeric Value is Allowed" ValidationGroup="add" ForeColor="Red"
                                    ValidationExpression="^\d{0,7}(\.\d{1,2})?$">*
                                </asp:RegularExpressionValidator>
                            </td>
                            <td width="25%">
                                Amount :
                                <asp:TextBox ID="txtAmount" runat="server" CssClass="textbox" Enabled="False" TabIndex="20"
                                    Width="111px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1" height="10">
                            </td>
                            <td colspan="1" height="10">
                                &nbsp;
                            </td>
                            <td colspan="2" height="10">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td align="right" colspan="2">
                                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" ValidationGroup="add"
                                    Width="60" TabIndex="8" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <br />
            <div align="center">
                <asp:GridView ID="gvItemDesc" runat="server" AutoGenerateColumns="False" CssClass="gridview"
                    CellPadding="4" AllowPaging="True" ForeColor="#333333" Width="100%" 
                     onrowcommand="gvItemDesc_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("BillItemDescription") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Charge">
                            <ItemTemplate>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="17px"
                                    Width="18px" />
                                <asp:Label ID="lblRate" runat="server" Text='<%# Eval("ItemCharge") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:Label ID="lblqty" runat="server" Text='<%# Eval("ItemQuantity") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="17px"
                                    Width="18px" />
                                <asp:Label ID="lblamt" runat="server" Text='<%# Eval("ItemAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="DeleteButton" runat="server" CssClass="DeleteButton" CommandName="DeletePart"
                                    CommandArgument='<%# Container.DataItemIndex %>' Text="Delete" ToolTip="Delete"><i class=" icon-remove red"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
            <table class="table table-bordered table-striped table-condensed">
                <tr>
                    <td colspan="2" width="500px">
                    </td>
                    <td>
                        Total Amount
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="20px"
                                Width="18px" />
                            <asp:TextBox ID="txtAmt" runat="server" AutoPostBack="true" OnTextChanged="txtAmt_TextChanged"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        Service Charge
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="20px"
                                Width="18px" />
                            <asp:TextBox ID="txtSerCharge" runat="server" AutoPostBack="true" OnTextChanged="txtSerCharge_TextChanged"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        Service Tax
                        <asp:Label ID="Label2" runat="server" BackColor="#99CCFF" ForeColor="Black"></asp:Label>
                    </td>
                    <td class="style8">
                        <div class="input-control text">
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="20px"
                                Width="18px" />
                            <asp:TextBox ID="txtSerTax" runat="server" AutoPostBack="true" OnTextChanged="txtSerTax_TextChanged"></asp:TextBox>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        Net Amount
                    </td>
                    <td class="left">
                        <div class="input-control text">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/image/Rupees-symbol.png" Height="20px"
                                Width="18px" />
                            <asp:TextBox ID="txtNetAmt" runat="server" Enabled="False"></asp:TextBox>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <div align="right">
            <asp:Button ID="btnSave" runat="server" Text="Temporary Save" OnClick="btnSave_Click"
                OnClientClick="return confirmationSave();" />
            <asp:Button ID="btnPreview" runat="server" Text="Preview Invoice" OnClick="btnPreview_Click"
                OnClientClick="return confirmationPreview();" />
            <asp:Button ID="btnGenerateInvoice" runat="server" Text="Permanent Save" OnClientClick="return confirm('Are you sure you want to Generate Invoice ?');"
                OnClick="btnGenerateInvoice_Click" />
            <asp:Button ID="btnExit" runat="server" Text="Exit" OnClick="btnExit_Click" OnClientClick="return confirmationPreview();" />
        </div>
    </div>
</asp:Content>
