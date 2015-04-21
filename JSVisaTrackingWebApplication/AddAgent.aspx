<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddAgent.aspx.cs" Inherits="JSVisaTrackingWebApplication.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function confirmation() {
            if (confirm('Are you sure you want to Save ?')) {
                return true;
            } else {
                return false;
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Add Agent</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Agent / Add Agent</div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
                <div class="form-inner-bg">
                    <div class="col-sm-12 col-xs-12">
                        <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
                            runat="server" ValidationGroup="Summery1" />
                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Agent's UserName<span class="red">*</span></label>
                                <asp:TextBox ID="txt_agusername" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_username" runat="server" ControlToValidate="txt_agusername"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent's UserName"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Agent's Password<span class="red">*</span></label>
                                <asp:TextBox ID="txt_agpassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="txt_agpassword"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Password"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-4 col-xs-12">
                                <label>Confirm Password<span class="red">*</span></label>
                                <asp:TextBox ID="txt_cpassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="crfv_password" runat="server" ControlToValidate="txt_cpassword"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Password"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="comparePasswords"
                                    runat="server" ControlToCompare="txt_agpassword" ControlToValidate="txt_cpassword" ErrorMessage="Your passwords do not match up!"
                                    Display="Dynamic" />
                            </div>
                        </div>
                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Agent Name(Company Name) <span class="red">*</span></label>
                                <asp:TextBox ID="txt_agcompanyname" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_company" runat="server" ControlToValidate="txt_agcompanyname"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Name(Company Name)"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Agent Name(Tally Account)<span class="red">*</span></label>
                                <asp:TextBox ID="txt_tally" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_tally" runat="server" ControlToValidate="txt_tally"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Name(Tally Account)"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Agent Prority<span class="red">*</span></label>
                                <asp:TextBox ID="txt_agproperty" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_priority" runat="server" ControlToValidate="txt_agproperty"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Prority"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_agproperty"
                                    SetFocusOnError="true" MinimumValue="0" MaximumValue="1" Type="Integer" ErrorMessage="Please Enter Prority only 0 or 1"
                                    ForeColor="Red" ValidationGroup="Summery1" Display="None" />
                            </div>

                        </div>



                       <%-- ----------------------------------
                        ------------------------------------%>
                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Country<span class="red"></span></label>
                                <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <div class="col-sm-4 col-xs-12">
                                <label>State<span class="red">*</span></label>
                                <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlState"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Address"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>City<span class="red">*</span></label>
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Agent city"
                                    InitialValue="0" Display="None" ForeColor="Red" ValidationGroup="Summery1"
                                    ControlToValidate="ddlCity">
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>
                       <%-- ////////////////////////////////////////////////////
                        ////////////////////////////////////////////////--%>





































                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Contact Person<span class="red">*</span></label>
                                <asp:TextBox ID="txt_contect" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-4 col-xs-12">
                                <label>Agent Address<span class="red">*</span></label>
                                <asp:TextBox ID="txt_agaddress" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_address" runat="server" ControlToValidate="txt_agaddress"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent Address"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                            </div>
                           <%-- <div class="col-sm-4 col-xs-12">
                                <label>Agent City<span class="red">*</span></label>
                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please Select Agent city"
                                    InitialValue="0" Display="None" ForeColor="Red" ValidationGroup="Summery1"
                                    ControlToValidate="ddlCity">
                                </asp:RequiredFieldValidator>
                            </div>--%>
                        </div>

                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Pin Code<span class="red">*</span></label>
                                <asp:TextBox ID="txt_agpin" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="regularPinCode" runat="server" ControlToValidate="txt_agpin"
                                    ValidationExpression="\d{6}" Display="None" SetFocusOnError="true" ErrorMessage="please enter
                    six digit pin code number."
                                    ValidationGroup="Summery1"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Agent E-Mail<span class="red">*</span></label>
                                <asp:TextBox ID="txt_email" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_email" runat="server" ControlToValidate="txt_email"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent E-Mail"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revPhone" runat="server" ValidationGroup="Summery1"
                                    ValidationExpression="^(\s*;?\s*[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})+\s*$"
                                    EnableClientScript="false" Display="None" SetFocusOnError="true" ControlToValidate="txt_email"
                                    ErrorMessage="Invalid email address" Visible="True" ClientIDMode="Predictable"
                                    EnableViewState="True"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Phone Number<span class="red">*</span></label>
                                <asp:TextBox ID="txt_agphone" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_phone" runat="server" ControlToValidate="txt_agphone"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="please enter only integer in phone number"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regularExPhone" runat="server" ControlToValidate="txt_agphone"
                                    ValidationExpression="/^\(?([0-9]{3})\)?\s*[\. -]?\s*([0-9]{3})\s*[\. -]?\s*([0-9]{4})\s?((ext|x)\s*\.?:?\s*([0-9]+))?$/i">
                                </asp:RegularExpressionValidator>
                            </div>

                        </div>

                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Fax Number<span class="red">*</span></label>
                                <asp:TextBox ID="txt_fax" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="Regularfax" runat="server" ControlToValidate="txt_agphone"
                                    ErrorMessage="Invalid" ValidationExpression="/^\(?([0-9]{3})\)?\s*[\. -]?\s*([0-9]{3})\s*[\. -]?\s*([0-9]{4})\s?((ext|x)\s*\.?:?\s*([0-9]+))?$/i">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Service Charge(Per Passport)<span class="red">*</span></label>
                                <asp:TextBox ID="txt_agservice" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_servicecharge" runat="server" ControlToValidate="txt_agservice"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Service Charge(Per Passport)"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="validator" runat="server" ControlToValidate="txt_agservice"
                                    Operator="DataTypeCheck" Type="Double" ErrorMessage="Service Charge must be a number"
                                    ValidationGroup="Summery1" Display="None" />
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Courier Charge(Per Consignment)<span class="red">*</span></label>
                                <asp:TextBox ID="txt_Courier" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_Coriercharge" runat="server" ControlToValidate="txt_Courier"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Courier Charge(Per Consignment)"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_Courier"
                                    Operator="DataTypeCheck" Type="Double" ErrorMessage="Couriers Charge must be a number"
                                    ValidationGroup="Summery1" Display="None" />
                            </div>
                        </div>

                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Draft Charge(Per Consignment)<span class="red">*</span></label>
                                <asp:TextBox ID="txt_agDraft" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_Draftcharge" runat="server" ControlToValidate="txt_agDraft"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Draft Charge(Per Consignment)"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_agDraft"
                                    Operator="DataTypeCheck" Type="Double" ErrorMessage="Draft Charge must be a number"
                                    ValidationGroup="Summery1" Display="None" />
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Opening Balance<span class="red">*</span></label>
                                <asp:TextBox ID="txt_agOpening" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_agOpening"
                                    Operator="DataTypeCheck" Type="Integer" ErrorMessage="Draft Charge must be a number"
                                    ValidationGroup="Summery1" Display="None" />
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label style="margin-top: 30px;">Active<span class="red">*</span></label>
                                <asp:CheckBox ID="chbox_enable" runat="server" />
                            </div>
                        </div>
                        <div class="text-right">
                            <asp:Button ID="btn_addagent" runat="server" Text="ADD AGENT" ValidationGroup="Summery1"
                                OnClick="btn_addagent_Click" CssClass="button-1" />
                            <asp:Button ID="btn_cancel" runat="server" Text="CANCEL" OnClick="btn_cancel_Click" CssClass="cancel-btn" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




    <%--<div class="input-control text">
                <asp:TextBox ID="txt_agcity" runat="server"></asp:TextBox>
                <button class="btn-clear" />
            </div>
     <asp:RequiredFieldValidator ID="rfv_city" runat="server" ControlToValidate="txt_agcity"
            ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Agent City"
            Display="None">
        </asp:RequiredFieldValidator>--%>
</asp:Content>

