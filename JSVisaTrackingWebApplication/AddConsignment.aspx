<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddConsignment.aspx.cs" Inherits="JSVisaTrackingWebApplication.AddConsignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">

        window.history.forward();
        function noBack() {
            window.history.forward();
        }

        //        function clearTextBox(TxtInstruction) {
        //            var d = new Date();
        //            var n = d.toDateString();
        //            document.getElementById("<%=TxtInstruction.ClientID%>").value = "Updated On\n" + n;
        //        }
        //        function clearTextBoxRemarks(txtRemark) {
        //            var d = new Date();
        //            var n = d.toDateString();
        //            document.getElementById("<%=txtRemark.ClientID%>").value = "Updated On\n" + n;
        //        }

        //        function Confirm() {
        //            var confirm_value = document.createElement("INPUT");
        //            confirm_value.type = "hidden";
        //            confirm_value.name = "confirm_value";
        //            if (confirm("Do You Want To Generate Invoice!!!")) {
        //                confirm_value.value = "Yes";
        //            } else {
        //                confirm_value.value = "No";
        //            }
        //            document.forms[0].appendChild(confirm_value);
        //        }

        function confirmationDelete() {
            if (confirm('Are you sure you want to Delete ?')) {
                return true;
            } else {
                return false;
            }
        }
        //        function confirmationCancel() {
        //            if (confirm('Are you sure you want to Cancel Consignment Details ?')) {
        //                return true;
        //            } else {
        //                return false;
        //            }
        //        }
        //        function confirmationFinish() {
        //            if (confirm('Are you sure you want to Save Consignment Details ?')) {
        //                return true;
        //            } else {
        //                return false;
        //            }
        //        }
        //        function NumberOnly() {
        //            var AsciiValue = event.keyCode
        //            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
        //                event.returnValue = true;
        //            else
        //                event.returnValue = false;
        //        }

        function ValidateListBox(sender, args) {
            var options = document.getElementById("<%=LstSelectedCountry.ClientID%>").options;
            if (options.length > 0) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
        function ValidateListBoxCountry(sender, args) {
            var options = document.getElementById("<%=LstCountry.ClientID%>").options;
            if (options.length > 0) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
    </script>
    <script type="text/javascript">
        function ValidateModuleList(source, args) {
            var chkListModules = document.getElementById('<%= rbtProcessTime.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    </script>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
        .visible
        {
            display: inline;
        }
    </style>
    <style type="text/css">
        .hidden
        {
            display: none;
        }
        .visible
        {
            display: inline;
        }
        #wizHeader li .prevStep
        {
            background-color: #2D89EF;
        }
        #wizHeader li .prevStep:after
        {
            border-left-color: #2D89EF !important;
        }
        #wizHeader li .currentStep
        {
            background-color: #DF6126;
        }
        #wizHeader li .currentStep:after
        {
            border-left-color: #DF6126 !important;
        }
        #wizHeader li .nextStep
        {
            background-color: #C2C2C2;
        }
        #wizHeader li .nextStep:after
        {
            border-left-color: #C2C2C2 !important;
        }
        #wizHeader
        {
            list-style: none;
            overflow: hidden;
            font: 18px Helvetica, Arial, Sans-Serif;
            margin: 0px;
            padding: 0px;
        }
        #wizHeader li
        {
            float: left;
        }
        #wizHeader li a
        {
            color: white;
            text-decoration: none;
            padding: 10px 0 10px 55px;
            background: brown; /* fallback color */
            background: hsla(34,85%,35%,1);
            position: relative;
            display: block;
            float: left;
        }
        #wizHeader li a:after
        {
            content: " ";
            display: block;
            width: 0;
            height: 0;
            border-top: 50px solid transparent; /* Go big on the size, and let overflow hide */
            border-bottom: 50px solid transparent;
            border-left: 30px solid hsla(34,85%,35%,1);
            position: absolute;
            top: 50%;
            margin-top: -50px;
            left: 100%;
            z-index: 2;
        }
        #wizHeader li a:before
        {
            content: " ";
            display: block;
            width: 0;
            height: 0;
            border-top: 50px solid transparent;
            border-bottom: 50px solid transparent;
            border-left: 30px solid white;
            position: absolute;
            top: 50%;
            margin-top: -50px;
            margin-left: 1px;
            left: 100%;
            z-index: 1;
        }
        #wizHeader li:first-child a
        {
            padding-left: 10px;
        }
        #wizHeader li:last-child
        {
            padding-right: 50px;
        }
        #wizHeader li a:hover
        {
            background: #9CAAC1;
        }
        #wizHeader li a:hover:after
        {
            border-left-color: #9CAAC1 !important;
        }
        .content
        {
            height: 150px;
            padding-top: 75px;
            text-align: center;
            background-color: #F9F9F9;
            font-size: 48px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"
    OnLoad="noBack();" onpageshow="if (event.persisted) noBack();">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" HeaderText="Following error occurs:"
        ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="consignment" />
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" HeaderText="Following error occurs:"
        ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" ValidationGroup="pax" />
    <asp:Wizard ID="Wizard1" runat="server" BackColor="White" OnFinishButtonClick="Wizard1_FinishButtonClick"
        OnPreviousButtonClick="previous_button" DisplaySideBar="false" Font-Names="Verdana"
        Font-Size="0.8em" OnNextButtonClick="Wizard1_NextButtonClick" Width="100%">
        <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
        <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" CssClass="SideBarStyle"
            ForeColor="White" />
        <SideBarStyle BackColor="#507CD1" Width="17%" Font-Size="0.9em" VerticalAlign="Top" />
        <StepStyle Font-Size="0.8em" ForeColor="#333333" />
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Consignment">
                <table class="table table-bordered table-striped table-condensed">
                    <tbody>
                        <tr>
                            <td class="left" >
                                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Agent's Name"></asp:Label>
                            </td>
                            <td class="left" >
                                <asp:Label ID="LblAgentName" runat="server" Font-Bold="true" Text="Agent Name"></asp:Label>
                            </td>
                            <td class="left">
                            Consignment No.
                        </td>
                        <td class="left">
                            <div class="input-control text">
                                <asp:TextBox ID="txtConsignNo" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                        </td>
                        </tr>
                        <tr>
                            <td>
                                Visa Country<span class="red">*</span>
                            </td>
                            <td colspan="3">
                                <div class="input-control select">
                                    <asp:DropDownList ID="DrpdnVisaCountry" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="DrpdnVisaCountry"
                                    Display="None" ErrorMessage="Please Select Visa Country " InitialValue="0" SetFocusOnError="True"
                                    ValidationGroup="consignment"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td width="35%">
                                Other Countries
                            </td>
                            <td width="25%">
                            </td>
                            <td colspan="2" width="40%">
                                Selected Countries
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:ListBox ID="LstCountry" runat="server" Width="300px" Height="120px"></asp:ListBox>
                                </div>
                            </td>
                            <td width="100px">
                                <div class="ListButtonDiv">
                                    <asp:Button ID="BtnMveCountryRht" runat="server" CssClass="bg-color-darken" Font-Bold="True"
                                        Font-Size="18px" ForeColor="Black" OnClick="BtnMveCountryRht_Click" Text="&gt;&gt;"
                                        ValidationGroup="ListCountry" />
                                    <asp:Button ID="BtnMveCountryLft" runat="server" CssClass="bg-color-darken" Font-Bold="True"
                                        Font-Size="18px" ForeColor="Black" OnClick="BtnMveCountryLft_Click" Text="&lt;&lt;" />
                                </div>
                            </td>
                            <td class="right" colspan="2">
                                <div class="input-control select">
                                    <asp:ListBox ID="LstSelectedCountry" runat="server" Width="300px" Height="120px">
                                    </asp:ListBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Submission Date
                            </td>
                            <td class="left">
                                <div class="input-control text datepicker  span4" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txtSubmDate" runat="server" format="MM/dd/yyyy"></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                            </td>
                            <td class="left">
                                Checked on Date
                            </td>
                            <td class="left">
                                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txtChkDate" runat="server" format="MM/dd/yyyy"></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                                <asp:CompareValidator runat="server" ID="CompareValidator1" ControlToValidate="txtChkDate"
                                    ValidationGroup="consignment" ControlToCompare="txtSubmDate" Operator="GreaterThanEqual"
                                    Display="None" Type="Date" ForeColor="Red" ErrorMessage="Check On Date Can not be Less Then Submission date" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Collection Date
                            </td>
                            <td class="left">
                                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txtColDate" runat="server" format="MM/dd/yyyy"></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                                <asp:CompareValidator runat="server" ID="CompareValidator2" ControlToValidate="txtColDate"
                                    ValidationGroup="consignment" ControlToCompare="txtSubmDate" Operator="GreaterThanEqual"
                                    Display="None" Type="Date" ForeColor="Red" ErrorMessage="Collection Date Can not be Less Then Submission date" /><br />
                            </td>
                            <td class="left">
                                Travel Date
                            </td>
                            <td class="left">
                                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txtTravlDate" runat="server"></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                                <asp:CompareValidator runat="server" ID="CompareValidator3" ControlToValidate="txtTravlDate"
                                    ValidationGroup="consignment" ControlToCompare="txtSubmDate" Operator="GreaterThanEqual"
                                    Display="None" Type="Date" ForeColor="Red" ErrorMessage="Travel Date Can not be Less Then Submission date" /><br />
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Group Rep.
                            </td>
                            <td class="left" colspan="3">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtGroup" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Instructions(Internal Use)
                            </td>
                            <td class="left">
                                &nbsp;
                                <asp:TextBox ID="TxtInstruction" runat="server" align="center" Width="160px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td class="left">
                                Remark(External Use)
                            </td>
                            <td class="left">
                                &nbsp;
                                <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="160px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Area Code<span class="red">*</span>
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtAreaCod" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                                <asp:CompareValidator ID="cvDocument" runat="server" ControlToValidate="txtAreaCod"
                                    Operator="DataTypeCheck" Type="Integer" ErrorMessage="Area Code Must Be An Integer"
                                    ValidationGroup="consignment" Display="None" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please Enter Area Code"
                                    ControlToValidate="txtAreaCod" ValidationGroup="consignment" Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                No.of Passport<span class="red">*</span>
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtNoPassport" runat="server" onkeypress="return NumberOnly()"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please Enter No. Of Passport"
                                    ControlToValidate="txtNoPassport" ValidationGroup="consignment" Display="None"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Entered By<span class="red">*</span>
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtEnterdBy" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please Enter Entered By"
                                    ControlToValidate="txtEnterdBy" ValidationGroup="consignment" Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td class="left">
                                No.of DD
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtNoDD" runat="server" onkeypress="return NumberOnly()"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                                <asp:CompareValidator runat="server" ID="cmpNumbers" ControlToValidate="txtNoPassport"                                    
                                    ValidationGroup="consignment" ControlToCompare="txtNoDD" Operator="GreaterThanEqual"
                                    Display="None" Type="Integer"  ErrorMessage="No. Of Passport Can Not Be Less Then No. Of DD" /><br />
                            <asp:CompareValidator runat="server" ID="CompareValidator4" ControlToValidate="txtNoDD"
                                    Operator="DataTypeCheck"   ValidationGroup="consignment" 
                                    Display="None" Type="Integer"  ErrorMessage="DD Must Be in Integer" /><br />
                           
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <h4 class="fg-color-blue">
                                    Sent by :</h4>
                                <div class="progress-bar">
                                    <div class="bar bg-color-blue" style="width: 100%;">
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Name<span class="red">*</span>
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtSntName" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please Enter Name"
                                    ControlToValidate="txtSntName" ValidationGroup="consignment" Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td class="left">
                                Mobile No.
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtmob" runat="server" onkeypress="return NumberOnly()" MaxLength="10"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Corporate<span class="red">*</span>
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtCorporate" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please Enter Corporate"
                                    ControlToValidate="txtCorporate" ValidationGroup="consignment" Display="None"></asp:RequiredFieldValidator>
                            </td>
                            <td class="left">
                                Email:
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <div align="right">
                </div>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="PAX Details">
                <table class="table table-bordered table-striped table-condensed" id="paxTable" runat="server">
                    <tr>
                        <td class="left">
                            <b>Agent </b>
                        </td>
                        <td>
                            <div class="input-control select">
                                <asp:Label ID="LblpaxAgent" runat="server" Text="" Font-Bold="true"></asp:Label>
                            </div>
                        </td>
                        <td class="left">
                            Consignment No.
                        </td>
                        <td class="left">
                            <div class="input-control text">
                                <asp:TextBox ID="txtConsignemntNo" runat="server" Enabled="false"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            Passport No.<span class="red">*</span>
                        </td>
                        <td class="left">
                            <div class="input-control text">
                                <asp:TextBox ID="txt_PassportNo" runat="server" AutoPostBack="true" OnTextChanged="txtPassport_textChanged"></asp:TextBox>
                                <button class="btn-clear" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="Please Enter  Passport No."
                                    ControlToValidate="txt_PassportNo" ValidationGroup="pax" Display="None"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td class="left">
                            PAX Name<span class="red">*</span>
                        </td>
                        <td class="left">
                            <div class="input-control text">
                                <asp:TextBox ID="txt_paxname" runat="server"></asp:TextBox>
                                <button class="btn-clear" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Please Enter PAX Name"
                                    ControlToValidate="txt_paxname" ValidationGroup="pax" Display="None"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            VTT No.
                        </td>
                        <td class="left" colspan="3">
                            <div class="input-control text">
                                <asp:TextBox ID="txtvttNo" runat="server"></asp:TextBox>
                                <button class="btn-clear" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="left" colspan="4">
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="DodgerBlue" Text="Documents"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            <label class="input-control checkbox" onclick="">
                                <asp:CheckBox ID="chktickets" runat="server" />
                                <span class="helper">Tickets</span>
                            </label>
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="TxtTicketRemark" TextMode="MultiLine" Width="160px" runat="server"></asp:TextBox>
                            <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="TxtTicketRemark"
                                WatermarkText="Remark" runat="server">
                            </asp:TextBoxWatermarkExtender>--%>
                        </td>
                        <td>
                            <label class="input-control checkbox" onclick="">
                                <asp:CheckBox ID="chkMedIns" runat="server" />
                                <span class="helper">Med. Insurance</span>
                            </label>
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="txtMedRemark" TextMode="MultiLine" Width="160px" runat="server"></asp:TextBox>
                            <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" TargetControlID="txtMedRemark"
                                WatermarkText="Remark" runat="server">
                            </asp:TextBoxWatermarkExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="input-control checkbox" onclick="">
                                <asp:CheckBox ID="chkCreditCard" runat="server" />
                                <span class="helper">Credit Cards</span>
                            </label>
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="txtCreditRemarks" TextMode="MultiLine" Width="160px" runat="server"></asp:TextBox>
                           <%-- <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" TargetControlID="txtCreditRemarks"
                                WatermarkText="Remark" runat="server">
                            </asp:TextBoxWatermarkExtender>--%>
                        </td>
                        <td>
                            <label class="input-control checkbox" onclick="">
                                <asp:CheckBox ID="chkcertificate" runat="server" />
                                <span class="helper">Certificates</span>
                            </label>
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="txtCertificateRemark" TextMode="MultiLine" Width="160px" runat="server"></asp:TextBox>
                            <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" TargetControlID="txtCertificateRemark"
                                WatermarkText="Remark" runat="server">
                            </asp:TextBoxWatermarkExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="input-control checkbox" onclick="">
                                <asp:CheckBox ID="chkItPaper" runat="server" />
                                <span class="helper">IT Papers</span>
                            </label>
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="TxtITRemark" TextMode="MultiLine" Width="160px" runat="server"></asp:TextBox>
                            <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" TargetControlID="TxtITRemark"
                                WatermarkText="Remark" runat="server">
                            </asp:TextBoxWatermarkExtender>--%>
                        </td>
                        <td>
                            <label class="input-control checkbox" onclick="">
                                <asp:CheckBox ID="chkDraft" runat="server" />
                                <span class="helper">Draft</span>
                            </label>
                        </td>
                        <td>
                            &nbsp;<asp:TextBox ID="txtDraftRemark" TextMode="MultiLine" Width="160px" runat="server"></asp:TextBox>
                            <%--<asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" TargetControlID="txtDraftRemark"
                                WatermarkText="Remark" runat="server">
                            </asp:TextBoxWatermarkExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="input-control checkbox" onclick="">
                                <asp:CheckBox ID="chckOther" runat="server" />
                                <span class="helper">Other</span>
                            </label>
                        </td>
                        <td colspan="3">
                            &nbsp;<asp:TextBox ID="Txt_Others" TextMode="MultiLine" Width="160px" runat="server"></asp:TextBox>
<%--                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" TargetControlID="Txt_Others"
                                WatermarkText="Remark" runat="server">
                            </asp:TextBoxWatermarkExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="left">
                            Overall Remark
                        </td>
                        <td class="left" colspan="3">
                            &nbsp;<asp:TextBox ID="txtPaxRemarks" runat="server" TextMode="MultiLine" Height="70px"
                                Width="500px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                </br>
                <asp:Panel ID="Panel1" runat="server">
                    <table class="table table-bordered table-striped table-condensed" id="additionalTable">
                        <tr>
                            <td class="left" colspan="4">
                                <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="DodgerBlue" Text="Fill Additional Details"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                <span>Country</span><span class="red">*</span>
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="dropdown" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlCountry"
                                    ErrorMessage="Please Select Country " InitialValue="0" SetFocusOnError="True"
                                    Display="None" ValidationGroup="pax"></asp:RequiredFieldValidator>
                            </td>
                            <td class="left">
                                Visa Type<span class="red">*</span>
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlVisaType" runat="server" AutoPostBack="True" CssClass="dropdown"
                                        OnSelectedIndexChanged="ddlVisaType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlVisaType"
                                    ErrorMessage="Please Select Visa Type" InitialValue="0" Display="None" SetFocusOnError="True"
                                    ValidationGroup="pax"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Number of Visit<span class="red">*</span>
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlnoofvisit" runat="server" AutoPostBack="True" CssClass="dropdown">
                                    </asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlnoofvisit"
                                    ErrorMessage="Please Select No Of Visit" Display="None" InitialValue="0" SetFocusOnError="True"
                                    ValidationGroup="pax"></asp:RequiredFieldValidator>
                            </td>
                            <td class="left" colspan="2">
                                <asp:RadioButtonList ID="rbtProcessTime" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Urgent" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Normal" Value="2"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:CustomValidator runat="server" ID="CustValProducttype" ClientValidationFunction="ValidateModuleList"
                                    ErrorMessage="Please Select Process Time." ValidationGroup="pax" Display="None"></asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="ChckBxGrp" runat="server" AutoPostBack="true" OnCheckedChanged="ChckBxGrp_CheckedChanged" />
                                    <span class="helper">Is Group</span>
                                </label>
                            </td>
                            <td>
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="dropdown">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td colspan="2">
                                &nbsp;&nbsp;
                                <asp:Button ID="BtnAdditionalPax" runat="server" Text="Add " ValidationGroup="pax"
                                    OnClick="BtnAdditionalPax_Save_Click" />
                                     <asp:Button ID="btnPaxEntry_Update" runat="server" Text="Update" ValidationGroup="pax"
                    OnClick="btnPaxEntry_Update_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:GridView runat="server" ID="gridFillPax" OnRowCommand="gridFillPax_RowCommand" Width="100%"
                    OnRowDataBound="gridFillPax_RowDataBound" AutoGenerateColumns="False" AllowPaging="True"
                    CssClass="gridview" PageSize="10" CellPadding="5">
                    <HeaderStyle CssClass="gridViewHeader" />
                    <RowStyle CssClass="gridViewRow" />
                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                    <PagerStyle CssClass="gridViewPager" />
                    <Columns>
                        <asp:TemplateField HeaderText="PAX Name">
                            <ItemTemplate>
                                <asp:Label ID="lblREQ_ID" runat="server" Text='<%#Eval("pax.PaxName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pax PassportNo.">
                            <ItemTemplate>
                                <asp:Label ID="lblCOUNTRY_NAME" runat="server" Text='<%#Eval("pax.PaxPassportNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Country ">
                            <ItemTemplate>
                                <asp:Label ID="lblCountryName" runat="server" Text='<%#Eval("CountryName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Visa Type">
                            <ItemTemplate>
                                <asp:Label ID="lblvisatype" runat="server" Text='<%#Eval("DescriptionOne") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="No. Of Visit">
                            <ItemTemplate>
                                <asp:Label ID="lblNoVisit" runat="server" Text='<%#Eval("DescriptionTwo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Group Name">
                            <ItemTemplate>
                                <asp:Label ID="lblVisaDuration" runat="server" Text='<%#Eval("GroupName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Process Time">
                            <ItemTemplate>
                                <asp:Label ID="lblProcessTime" runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" ToolTip="Edit" CommandName="cmdEdit"
                                    CommandArgument='<%#Container.DataItemIndex+ "," + Eval("consignment.ConsignmentId")+","+Eval("pax.PaxId").ToString() %>'><i class="icon-pencil black"></i></asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" ToolTip="Delete" CommandName="cmdDelete"
                                    OnClientClick="return confirmationDelete();" CommandArgument='<%#Container.DataItemIndex + ","+Eval("consignment.ConsignmentId")+"," + Eval("AddinfoId").ToString()+","+Eval("pax.PaxId").ToString()  %>'><i class=" icon-remove red"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
            </asp:WizardStep>
        </WizardSteps>
        <StartNavigationTemplate>
            <div align="right">
                <asp:Button ID="btnCancel" runat="server" Text="Reset" OnClick="btnCancel_Click"
                    OnClientClick="return confirm('Are you sure you want to Reset');" CausesValidation="false" />
                <asp:Button ID="btnConsignmentSave" runat="server" ValidationGroup="consignment"
                    Text="Save" OnClick="btnConsignmentSave_Click" />
                <asp:Button ID="BtnConsignmentUpdate" runat="server" ValidationGroup="consignment"
                    Text="Save" OnClick="BtnConsignmentUpdate_Click" />
                <asp:Button ID="StartNextButton" runat="server" ValidationGroup="consignment" CommandName="MoveNext"
                    Text="Next" />
            </div>
        </StartNavigationTemplate>
        <StepNavigationTemplate>
            <div align="right">
                <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                    Text="Previous" />
                <asp:Button ID="StepNextButton" runat="server" ValidationGroup="grouptemp" CommandName="MoveNext"
                    Text="Next" />
            </div>
        </StepNavigationTemplate>
        <FinishNavigationTemplate>
            <div align="right">
                <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                    Text="Previous" />
                <asp:Button ID="BtnCancelPax" runat="server" Text="Reset " OnClick="BtnCancelPax_Click" />
                <asp:Button ID="btnPaxEntry_Save" runat="server" Text="Save"  OnClick="btnPaxEntry_Save_Click" />
               
                <asp:Button ID="btnFinish" runat="server" Text="Finish" CausesValidation="true" CommandName="MoveComplete"
                    OnClientClick="Confirm()" />
            </div>
        </FinishNavigationTemplate>
        <HeaderTemplate>
            <ul id="wizHeader">
                <asp:Repeater ID="SideBarList" runat="server">
                    <ItemTemplate>
                        <li id="Li1" runat="server">
                            <asp:LinkButton ID="SideBarButton" CssClass="<%# GetClassForWizardStep(Container.DataItem) %>"
                                OnClick="Step_Click" ToolTip='<%#Eval("Name")%>' runat="server" Text='<%#Eval("Name") %>'>
                            </asp:LinkButton>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </HeaderTemplate>
    </asp:Wizard>
</asp:Content>
