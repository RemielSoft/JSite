<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddConsignment.aspx.cs" Inherits="JSVisaTrackingWebApplication.AddConsignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="Controls/PaxEntry.ascx" TagName="PaxEntry" TagPrefix="uc1" %>
<%@ Register Src="Controls/MailRemarks.ascx" TagName="MailRemarks" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">
        function validateText() {

            var text1 = document.getElementById("txtNoPassport");
            var text2 = document.getElementById("txtNoDD");
            if (text1.value == text2.value)
                alert("equal");
            else
                alert("not equal");

        }
        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else
                event.returnValue = false;
        }


        function Openpopup(popurl) {
            winpops = window.open(popurl, "", "width=900, height=500, left=100, top=100, scrollbars=yes, menubar=no,resizable=no,directories=no,location=no")
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
    <asp:Wizard ID="Wizard1" runat="server" BackColor="White" BorderColor="#B5C7DE" BorderWidth="1px"
        Font-Names="Verdana" Font-Size="0.8em" OnNextButtonClick="Wizard1_NextButtonClick">
        <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
        <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
        <SideBarStyle BackColor="#507CD1" Width="15%" Font-Size="0.9em" VerticalAlign="Top" />
        <StepStyle Font-Size="0.8em" ForeColor="#333333" />
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" Title="Consignment">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <h2>
                            Consignment</h2>
                        <table class="bordered">
                            <tbody>
                                <tr>
                                    <td class="left">
                                        Ref No.
                                    </td>
                                    <td class="left" colspan="3">
                                        <asp:Label ID="Lblrefno1" runat="server" Text="Refrence Number"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Agent's Name
                                    </td>
                                    <td class="left" colspan="3">
                                        <asp:Label ID="LblAgentName" runat="server" Text="Agent Name"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:LinkButton ID="setupDialog" PostBackUrl="~/Login.aspx" runat="server">Select Agent's Name <i class="icon-user"></i></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" rowspan="4">
                                        <table class="bordered">
                                            <tr>
                                                <td>
                                                    Country
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    Countries Selected
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="left">
                                                    <div class="input-control select">
                                                        <asp:ListBox ID="LstCountry" runat="server"></asp:ListBox>
                                                    </div>
                                                </td>
                                                <td class="span1">
                                                    <asp:Button CssClass="bg-color-darken" ID="BtnMveCountryRht" runat="server" Text=">>"
                                                        ForeColor="Black" Font-Bold="True" Font-Size="18px" OnClick="BtnMveCountryRht_Click" />
                                                    <asp:Button CssClass="bg-color-darken" ID="BtnMveCountryLft" runat="server" Text="<<"
                                                        ForeColor="Black" Font-Bold="True" Font-Size="18px" OnClick="BtnMveCountryLft_Click" />
                                                </td>
                                                <td class="right">
                                                    <div class="input-control select">
                                                        <asp:ListBox ID="LstSelectedCountry" runat="server"></asp:ListBox>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td class="left">
                                        Visa Country
                                    </td>
                                    <td class="left">
                                        <div class="input-control select">
                                            <asp:DropDownList ID="DrpdnVisaCountry" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Submission Date
                                    </td>
                                    <td class="left">
                                        <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                            <asp:TextBox ID="txtSubmDate" runat="server" formate="MM/dd/yyyy"></asp:TextBox>
                                            <i class="btn-date"></i>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Checked on Date
                                    </td>
                                    <td class="left">
                                        <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                            <asp:TextBox ID="txtChkDate" runat="server" formate="MM/dd/yyyy"></asp:TextBox>
                                            <i class="btn-date"></i>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Group Rep.
                                    </td>
                                    <td class="left">
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtGroup" runat="server"></asp:TextBox>
                                            <button class="btn-clear" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Collection Date
                                    </td>
                                    <td class="left">
                                        <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                            <asp:TextBox ID="txtColDate" runat="server" formate="MM/dd/yyyy"></asp:TextBox>
                                            <i class="btn-date"></i>
                                        </div>
                                    </td>
                                    <td class="left">
                                        Travel Dates
                                    </td>
                                    <td class="left">
                                        <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                            <asp:TextBox ID="txtTravlDate" runat="server" required="required" requiredmessage="Date is required."></asp:TextBox>
                                            <i class="btn-date"></i>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Instructions
                                    </td>
                                    <td class="left">
                                        <div class="input-control text">
                                            <asp:TextBox ID="TxtInstruction" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </td>
                                    <td class="left">
                                        Remarks
                                    </td>
                                    <td class="left">
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left" colspan="4">
                                        <div class="input-control text">
                                            <%--<asp:LinkButton ID="LinkButton6" runat="server"><i class="btn-search"></i></asp:LinkButton>--%>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <label class="input-control checkbox" onclick="">
                                            <asp:CheckBox ID="ChckbxCollctd" runat="server" />
                                            <span class="helper">Collected</span>
                                        </label>
                                        <label class="input-control checkbox" onclick="">
                                            <asp:CheckBox ID="ChckbxBlnkColDate" runat="server" />
                                            <span class="helper">Blank Collection Date</span>
                                        </label>
                                        <label class="input-control checkbox" onclick="">
                                            <asp:CheckBox ID="ChckbxDisabl" runat="server" />
                                            <span class="helper">Disabled</span>
                                        </label>
                                        <label class="input-control checkbox" onclick="">
                                            <asp:CheckBox ID="ChckbxBlankSubDate" runat="server" />
                                            <span class="helper">Blank Submission Date</span>
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Area Code
                                    </td>
                                    <td class="left">
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtAreaCod" runat="server"></asp:TextBox>
                                            <button class="btn-clear" />
                                        </div>
                                    </td>
                                    <td>
                                        No.of Passport
                                    </td>
                                    <td class="left">
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtNoPassport" runat="server" onkeypress="return NumberOnly()"></asp:TextBox>
                                            
                                            <button class="btn-clear" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="left">
                                        Entered By
                                    </td>
                                    <td class="left">
                                        <div class="input-control text">
                                            <asp:TextBox ID="txtEnterdBy" runat="server"></asp:TextBox>
                                            <button class="btn-clear" />
                                        </div>
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
                                                ValidationGroup="test" ControlToCompare="txtNoDD" Operator="GreaterThanEqual"
                                                Type="Integer" ForeColor="Red" ErrorMessage="No Of Passport can not be less then no of DD" /><br />
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
                                        <table class="bordered">
                                            <tbody>
                                                <tr>
                                                    <td class="left">
                                                        Name
                                                    </td>
                                                    <td class="left">
                                                        <div class="input-control text">
                                                            <asp:TextBox ID="txtSntName" runat="server"></asp:TextBox>
                                                            <button class="btn-clear" />
                                                        </div>
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
                                                        Corporate
                                                    </td>
                                                    <td class="left">
                                                        <div class="input-control text">
                                                            <asp:TextBox ID="txtCorporate" runat="server"></asp:TextBox>
                                                            <button class="btn-clear" />
                                                        </div>
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
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="right">
                                        <asp:Button ID="BtnConsignmentSave" runat="server" Text="Save" ValidationGroup="Test"
                                            OnClick="BtnConsignmentSave_Click" />
                                        <asp:Button ID="BtnConsignmentUpdate" runat="server" Text="Update" OnClick="BtnConsignmentUpdate_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" Title="Mail Remarks">
                <h2>
                    Collection Details</h2>
                <table class="bordered">
                    <tr>
                        <td colspan="3">
                            <asp:GridView runat="server" ID="GridViewMailRemark" AutoGenerateColumns="False"
                                AllowPaging="True" CssClass="gridview" PageSize="10" CellPadding="5">
                                <HeaderStyle CssClass="gridViewHeader" />
                                <RowStyle CssClass="gridViewRow" />
                                <AlternatingRowStyle CssClass="gridViewAltRow" />
                                <SelectedRowStyle CssClass="gridViewSelectedRow" />
                                <PagerStyle CssClass="gridViewPager" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Consignment Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("ConsignmentId") %>' Font-Bold="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Country Name">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("CountryName") %>' Font-Bold="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Submission Date">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("SubmissionDate") %>' Font-Bold="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Check-On-Date">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("CheckOnDate") %>' Font-Bold="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Collection Date">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("CollectionDate") %>' Font-Bold="true" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Collected">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkboxCollected" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Remarks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td colspan="7" align="right">
                            <asp:Button ID="BtnMailremarkSave" runat="server" OnClick="BtnMailremarkSave_Click"
                                Text="Save" />
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep3" runat="server" Title="PAX Details">
                <h2>
                    Pax Details</h2>
                <div id="DivPaxEntry" runat="server">
                    <table class="bordered">
                        <tr>
                            <td class="left">
                                Agent
                            </td>
                            <td >
                                <div class="input-control select">
                                    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                            <td class="left">
                                Ref No..
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:Label ID="LblRefNo" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left" >
                                PAX Name
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txt_paxname" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                            <td class="left" >
                                Passport No.
                            </td>
                            <td class="left">
                                <div class="input-control text">
                                    <asp:TextBox ID="txt_PassportNo" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                VTT No.
                            </td>
                            <td class="left">
                            <div class="input-control text">
                                <asp:TextBox ID="txtvttNo" runat="server"></asp:TextBox>
                                <button class="btn-clear" />
                                </div>
                            </td>
                            <td class="left">
                                Date of Birth
                            </td>
                            <td class="left" colspan="2">
                                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txt_dob" runat="server"></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left" colspan="6">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="left" colspan="6">
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="DodgerBlue" Text="Documents"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left" colspan="6">
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="chktickets" runat="server" />
                                    <span class="helper">Tickets</span>
                                </label>
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="chkMedIns" runat="server" />
                                    <span class="helper">Med. Insurance</span>
                                </label>
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="chkCreditCard" runat="server" />
                                    <span class="helper">Credit Cards</span>
                                </label>
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="chkcertificate" runat="server" />
                                    <span class="helper">Certificates</span>
                                </label>
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="chkItPaper" runat="server" />
                                    <span class="helper">IT Papers</span>
                                </label>
                                <label class="input-control checkbox" onclick="">
                                    <asp:CheckBox ID="chkDraft" runat="server" />
                                    <span class="helper">Draft</span>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left" >
                                Other
                            </td>
                            <td class="left" colspan="4">
                                <div class="input-control text">
                                    <asp:TextBox ID="Txt_Others" runat="server"></asp:TextBox>
                                    <button class="btn-clear" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left" colspan="1">
                                Remark
                            </td>
                            <td class="left" colspan="5">
                                <div class="input-control text">
                                    <asp:TextBox ID="txtPaxRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="right">
                                <asp:Button ID="btnPaxEntry_Save" runat="server" Text="Save" OnClick="btnPaxEntry_Save_Click" />
                                <asp:Button ID="btnPaxEntry_Update" runat="server" Text="update" OnClick="btnPaxEntry_Update_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="DivAdditional" runat="server" visible="False">
                    <table class="bordered">
                        <tr>
                            <td class="left" colspan="4">
                                <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="DodgerBlue" Text="Fill Additional Details"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                <span>Embassy</span>
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="dropdown" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td class="left">
                                Visa Type
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlVisaType" runat="server" AutoPostBack="True" CssClass="dropdown"
                                        OnSelectedIndexChanged="ddlVisaType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left">
                                Number of Visit
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlnoofvisit" runat="server" AutoPostBack="True" CssClass="dropdown"
                                        OnSelectedIndexChanged="ddlnoofvisit_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </td>
                            <td class="left">
                                Duration
                            </td>
                            <td class="left">
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlVisaDuration" runat="server" AutoPostBack="True" CssClass="dropdown"
                                        OnSelectedIndexChanged="ddlVisaDuration_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="left" colspan="1">
                                Process Time
                            </td>
                            <td class="left" colspan="3">
                                <div class="input-control select">
                                    <asp:DropDownList ID="ddlprocesstime" runat="server" CssClass="dropdown" AutoPostBack="True">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="right">
                                <asp:Button ID="addpax" runat="server" Text="Save" OnClick="addpax_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="DivPaxGrid" runat="server" visible="False">
                    <table class="bordered">
                        <tr>
                            <td colspan="3">
                                <asp:GridView runat="server" ID="gridFillPax" AutoGenerateColumns="False" AllowPaging="True"
                                    OnRowCommand="gridFillPax_RowCommand" CssClass="gridview" PageSize="10" CellPadding="5">
                                    <HeaderStyle CssClass="gridViewHeader" />
                                    <RowStyle CssClass="gridViewRow" />
                                    <AlternatingRowStyle CssClass="gridViewAltRow" />
                                    <SelectedRowStyle CssClass="gridViewSelectedRow" />
                                    <PagerStyle CssClass="gridViewPager" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="PAX ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPAX" runat="server" Text='<%#Eval("PaxId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PAX NAME">
                                            <%-- <ItemTemplate>
                                    <a href="javascript:Openpopup('PaxEntry.aspx?BId=<%# Eval("PaxId") %> & cid=<%# Eval("PaxId") %>')">
                                    <asp:Label ID="Label6" runat="server" Text="Pervesh"></asp:Label></a>
                                     </ItemTemplate>--%>
                                            <ItemTemplate>
                                                <asp:Label ID="lblREQ_ID" runat="server" Text='<%#Eval("PaxName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PAX PASSPORT NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCOUNTRY_NAME" runat="server" Text='<%#Eval("PaxPassportNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" ToolTip="Edit" CommandName="cmdEdit"
                                                    CommandArgument='<%#Eval("PaxId") %>'><i class="icon-pencil black"></i></asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" runat="server" ToolTip="Delete" CommandName="cmdDelete"
                                                    CommandArgument='<%#Eval("PaxId") %>'><i class=" icon-remove red"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="3">
                                <asp:Button ID="btnaddPax" OnClick="btnaddPax_Click" runat="server" Text="AddPax" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
    <%--<div class="page-control" id="tabs" data-role="page-control">
        <ul>
            <li class="active"><a href="#page1" id="tab11d">Consignment</a></li>
            <li><a href="#page2" id="tab12d">Mail Remarks</a></li>
            <li><a href="#page3" id="tab13d">PAX Details</a></li>
            <li class="place-right"><a href="#page5">To Create Invoice Click Here <i class="icon-copy">
            </i></a></li>
        </ul>
        <asp:HiddenField ID="hdnSelectedTab" runat="server" Value="tab12d" />
        <div class="frames">
            <div class="frame active" id="page1">
                
            </div>
            <div class="frame" id="page2">
               
                    
            </div>
            <div class="frame" id="page3">
                
            </div>
            <div class="frame" id="page5">
                <h2>
                    Create Invoice</h2>
                
            </div>
        </div>
    </div>--%>
</asp:Content>
