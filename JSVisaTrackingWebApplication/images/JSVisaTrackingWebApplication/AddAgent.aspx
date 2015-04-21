<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddAgent.aspx.cs" Inherits="JSVisaTrackingWebApplication.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmation() {
            if (confirm('Are you sure you want to Save ?')) {
                return true;
            } else {
                return false;
            }
        }
        
    </script>
    <style type="text/css">
        .style1
        {
            width: 170px;
        }
        .style2
        {
            width: 170px;
            height: 37px;
        }
        .style3
        {
            height: 37px;
            width: 289px;
        }
        .style4
        {
            width: 289px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-user fg-color-blue"></i>Create Agent
    </h2>
    <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
        runat="server" ValidationGroup="Summery1" />
    <table style="width: 936px; height: 661px;">
        <tr>
            <td class="style1">
                Agent's UserName<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_agusername" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_username" runat="server" ControlToValidate="txt_agusername"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent's UserName"
                Display="None">
            </asp:RequiredFieldValidator>
            <td class="style1">
                Agent' Password<span class="red">*</span>
            </td>
            <td>
                <asp:TextBox ID="txt_agpassword" runat="server" Height="31px" Width="265px" TextMode="Password"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="txt_agpassword"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Password"
                Display="None">
            </asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td class="style1">
                Agent Prority<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_agproperty" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_priority" runat="server" ControlToValidate="txt_agproperty"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Prority"
                Display="None">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txt_agproperty" 
                ErrorMessage="Please Enter 0 or 1 for priority" ValidationExpression="^[0-1]" 
                ForeColor="Red" SetFocusOnError="True" ValidationGroup="Summery1"></asp:RegularExpressionValidator>
            <td class="style1">
                Contact Person
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_contect" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Agent Name(Company Name)<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_agcompanyname" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_company" runat="server" ControlToValidate="txt_agcompanyname"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Name(Company Name)"
                Display="None">
            </asp:RequiredFieldValidator>
            <td class="style1">
                Agent Name(Tally Account)<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_tally" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_tally" runat="server" ControlToValidate="txt_tally"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Name(Tally Account)"
                Display="None">
            </asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td class="style1">
                Agent Address<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_agaddress" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_address" runat="server" ControlToValidate="txt_agaddress"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Address"
                Display="None">
            </asp:RequiredFieldValidator>
            <td class="style1">
                Agent City<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_agcity" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_city" runat="server" ControlToValidate="txt_agcity"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent City"
                Display="None">
            </asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td class="style1">
                Pin Code
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_agpin" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <td class="style1">
                Agent E-Mail<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_email" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_email" runat="server" ControlToValidate="txt_email"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent E-Mail"
                Display="None">
            </asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td class="style1">
                Phone Number<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_agphone" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_phone" runat="server" ControlToValidate="txt_agphone"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Phone Number"
                Display="None">
            </asp:RequiredFieldValidator>
            <td class="style1">
                Fax Number
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_fax" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Service Charge(Per Passport)<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_agservice" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_servicecharge" runat="server" ControlToValidate="txt_agservice"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Service Charge(Per Passport)"
                Display="None">
            </asp:RequiredFieldValidator>
            <td class="style1">
                Courier Charge(Per Consignment)<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_Courier" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_Coriercharge" runat="server" ControlToValidate="txt_Courier"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Courier Charge(Per Consignment)"
                Display="None">
            </asp:RequiredFieldValidator>
        </tr>
        <tr>
            <td class="style1">
                Draft Charge(Per Consignment)<span class="red">*</span>
            </td>
            <td class="style4">
                <asp:TextBox ID="txt_agDraft" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
            <asp:RequiredFieldValidator ID="rfv_Draftcharge" runat="server" ControlToValidate="txt_agDraft"
                ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Draft Charge(Per Consignment)"
                Display="None">
            </asp:RequiredFieldValidator>
            <td class="style2">
                Opening Balance
            </td>
            <td class="style3">
                <asp:TextBox ID="txt_agOpening" runat="server" Height="31px" Width="265px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Active
            </td>
            <td class="style4">
                <asp:CheckBox ID="chbox_enable" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Button ID="btn_addagent" runat="server" Text="ADD AGENT" ValidationGroup="Summery1"
                    OnClick="btn_addagent_Click" />
                <asp:Button ID="btn_cancel" runat="server" Text="CANCEL" OnClick="btn_cancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
