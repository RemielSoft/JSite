<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="VisaInformation.aspx.cs" Inherits="JSVisaTrackingWebApplication.VisaInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <script src="Scripts/jquery-1.4.1.min.js"></script>

    <script type="text/javascript">
        function openPDF() {
            debugger;
            var strMessage = '<%= p%>';
            var a = strMessage;
            window.open(a, 'PDF');
            return true;
        }
    </script>


    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }

        .td-bold table tr td:first-child {
            font-weight: bold;
        }

        .anchor {
            color: blue;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="a"
        HeaderText="Following error occurs:" ShowMessageBox="true" DisplayMode="BulletList"
        ShowSummary="false" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="b"
        HeaderText="Following error occurs:" ShowMessageBox="true" DisplayMode="BulletList"
        ShowSummary="false" />

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Add Visa Information</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Visa / Add Visa Information</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-8 center-block" style="float: none;">
                <div class="form-inner-bg" style="background: #f2f2f2;">
                    <div class="col-sm-12 col-xs-12">
                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <label>Country <span class="red">*</span></label>
                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCountry"
                                    ErrorMessage="Please Select Country" ForeColor="Red" InitialValue="0" Display="None"
                                    ValidationGroup="a"></asp:RequiredFieldValidator>

                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <label>Consulate <span class="red">*</span></label>
                                <asp:DropDownList ID="ddlconsulate" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="None"
                                    ControlToValidate="ddlconsulate" ErrorMessage="Please Select Consulate" ForeColor="Red"
                                    InitialValue="0" ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <label>Visa Type <span class="red">*</span></label>
                                <asp:DropDownList ID="ddlVisaType" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlVisaType"
                                    ErrorMessage="Please Select Visa Type" ForeColor="Red" InitialValue="0" Display="None"
                                    ValidationGroup="a"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="text-right form-group">
                            <asp:Button ID="BtnShow1" runat="server" Text="Show Details" OnClick="BtnShow_Click"
                                ValidationGroup="a" CssClass="button-1" />
                        </div>
                    </div>

                    <div class="row" id="noRecordFound" runat="server">
                        <div class="col-sm-12 col-xs-12">
                            <span>No record found.</span>
                        </div>

                    </div>

                    <div class="row" id="recordFound" runat="server">
                        <div class="col-sm-12 col-xs-12">
                            <div class="table-responsive td-bold" id="visaform">
                                <table class="table table-bordered table-striped">
                                    <tr>
                                        <td colspan="2" class="text-center" style="background: #e70012; color: #fff">
                                            <asp:Label ID="lblLocaVisa" runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                    <%--<tr>
                                        <td colspan="2" class="text-center" style="color: #e70012; font-weight: bold">AGENTS ARE NOT ALLOWED, APPLICANTS ARE REQUESTED TO APPLY IN PERSON.</td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="2" class="text-center" style="background: #fff;">
                                            
                                            <asp:Label id="lblcomments" runat="server"></asp:Label>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td style="width: 30%">ADDRESS</td>
                                        <td>
                                            <asp:Label ID="lblAddress" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>BASIC REQUIREMENTS</td>
                                        <td>
                                            <asp:Label ID="lblbasicreq" runat="server"></asp:Label></td>
                                    </tr>
                                     <tr id ="notes" runat ="server">
                                        <td>NOTES</td>
                                        <td>
                                            <asp:Label ID="lblnotes" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id ="medicalInfo" runat="server">
                                        <td>MEDICAL REQUIREMENTS</td>
                                        <td>
                                            <asp:Label ID="lblmedicalreq" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>FEES</td>
                                        <td>
                                            <asp:Label ID="lblFees" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id ="impoInfo" runat="server">
                                        <td>OTHER IMPORTANT INFO </td>
                                        <td>
                                            <asp:Label ID="lblotherinfo" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id ="PROCESS" runat="server">
                                        <td>PROCESS TIME </td>
                                        <td>
                                            <asp:Label ID="lblProcess" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id ="subDate" runat="server">
                                        <td>SUBMISSION DAYS</td>
                                        <td>
                                            <asp:Label ID="lblSubmission" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id ="subTime" runat="server">
                                        <td>SUBMISSION TIME</td>
                                        <td>
                                            <asp:Label ID="lblSubmissionTime" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id ="CollDay" runat="server">
                                        <td>COLLECTION DAYS</td>
                                        <td>
                                            <asp:Label ID="lblCollectionDay" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id ="CollTime" runat="server">
                                        <td>COLLECTION TIME</td>
                                        <td>
                                            <asp:Label ID="lblCollectiontime" runat="server"></asp:Label></td>
                                    </tr>
                                   <%-- <tr>
                                        <td>VISA SECTION WORKING DAYS</td>
                                        <td>
                                            <asp:Label ID="lblWorkingDay" runat="server"></asp:Label></td>
                                    </tr>--%>
                                    <tr>
                                        <td>VISA FORM</td>
                                        <td runat="server" id="visaFormContainer">
                                            <asp:LinkButton ID="lnkButtonView" runat="server" ToolTip="View" CommandName="cmdViewVisaForm" OnClick="lnkButtonView_Click"
                                                CommandArgument='<%#Eval("Form") %>' CssClass="anchor"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div>
        </div>
    </div>
</asp:Content>
