<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddVisaInformation.aspx.cs" Inherits="JSVisaTrackingWebApplication.Test1"  ValidateRequest="false"%>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <style type="text/css">
        .unselectable {
            width: auto !important;
            height: 210px !important;
        }
    </style>
    <script type="text/javascript">
        document.createElement('header');
        document.createElement('section');
        document.createElement('article');
        document.createElement('aside');
        document.createElement('nav');
        document.createElement('footer');


        $(document).ready(function () {

            $(".unselectable").removeAttr("style");

            $("#btnSave").click()
        });
    </script>


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
            <div class="col-xs-12 col-sm-12">


                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>



                <div class="form-inner-bg">
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

                        <div class="text-right">
                            <asp:Button ID="BtnShow" runat="server" Text="Show Details" OnClick="BtnShow_Click"
                                ValidationGroup="a" CssClass="button-1" />
                        </div>
                    </div>
                </div>
                <div class="form-inner-bg" runat="server" id="showTable">
                    <div class="col-sm-12 col-xs-12">
                        <div class="row form-group">

                            <div class="col-sm-4 col-xs-12">

                                <asp:Label ID="lblcomments" runat="server" Text="Comments"></asp:Label>
                                <asp:TextBox ID="txtcmmnts" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:HtmlEditorExtender ID="HtmlEditorExtender2" runat="server" TargetControlID="txtcmmnts"
                                    EnableSanitization="False" Enabled="True">
                                </asp:HtmlEditorExtender>
                            </div>

                            <div class="col-sm-4 col-xs-12">
                                <label>Basic Requirements</label>
                                <asp:TextBox ID="txtBasic" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" TargetControlID="txtBasic"
                                    EnableSanitization="False" Enabled="True">
                                </asp:HtmlEditorExtender>
                            </div>


                            <div class="col-sm-4 col-xs-12">
                                <label>Note</label>
                                <asp:TextBox ID="TxtNote" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:HtmlEditorExtender ID="HtmlEditorExtender3" runat="server" TargetControlID="TxtNote"
                                    EnableSanitization="False" Enabled="True">
                                </asp:HtmlEditorExtender>

                            </div>




                        </div>



                        <div class="row form-group">
                            <div class="col-sm-4 col-xs-12">
                                <label>Medical Requirements</label>
                                <asp:TextBox ID="TxtMed" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:HtmlEditorExtender ID="HtmlEditorExtender4" runat="server" TargetControlID="TxtMed"
                                    EnableSanitization="False" Enabled="True">
                                </asp:HtmlEditorExtender>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Fee <span class="red">*</span></label>
                                <asp:TextBox ID="txtFee" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:HtmlEditorExtender ID="HtmlEditorExtender5" runat="server" TargetControlID="Txtfee"
                                    EnableSanitization="False" Enabled="True">
                                </asp:HtmlEditorExtender>
                                <asp:RequiredFieldValidator ID="rfv_phone" runat="server" ControlToValidate="txtFee"
                                    ValidationGroup="b" SetFocusOnError="true" ErrorMessage="please enter Fee" Display="None">
                                </asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-4 col-xs-12">
                                <label>Other Informations</label>
                                <asp:TextBox ID="Txtother" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:HtmlEditorExtender ID="HtmlEditorExtender6" runat="server" TargetControlID="Txtother"
                                    EnableSanitization="False" Enabled="True">
                                </asp:HtmlEditorExtender>

                            </div>
                        </div>
                        <div class="row form-group">


                            <div class="col-sm-4 col-xs-12">
                                <label>Process Time <span class="red">*</span></label>
                                <asp:TextBox ID="txtprotime" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtprotime"
                                    ValidationGroup="b" SetFocusOnError="true" ErrorMessage="please enter process Time"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                            </div>

                            <div class="col-sm-4 col-xs-12">
                                <label>Submission Days</label>
                                <asp:TextBox ID="txtSubday" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Submission Time</label>
                                <asp:TextBox ID="txtsubtime" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-group">




                            <div class="col-sm-4 col-xs-12">
                                <label>Collection days</label>
                                <asp:TextBox ID="txtcolday" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Collection Time</label>
                                <asp:TextBox ID="txtcoltime" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <label>Address <span class="red">*</span></label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAddress"
                                    ValidationGroup="b" SetFocusOnError="true" ErrorMessage="please enter Address" Display="None">
                                </asp:RequiredFieldValidator>
                            </div>



                        </div>


                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblNormalFee" runat="server" Text="Normal Fee"></asp:Label>
                                <asp:TextBox ID="txtnormlfee" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblurgentfee" runat="server" Text="Urgent Fee"></asp:Label>
                                <asp:TextBox ID="txturgntfee" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblvfs" runat="server" Text="VFS"></asp:Label>
                                <asp:TextBox ID="txtvfs" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lbltiming" runat="server" Text="Timing"></asp:Label>
                                <asp:TextBox ID="txttiming" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblstudentfee" runat="server" Text="Student Fee"></asp:Label>
                                <asp:TextBox ID="txtstufee" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblvisawrk" runat="server" Text="Visa working Days"></asp:Label>
                                <asp:TextBox ID="txtvisawrk" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>



                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lbloff" runat="server" Text="Off"></asp:Label>
                                <asp:TextBox ID="txtoff" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblcoid" runat="server" Text="Copy Of Interview Date"></asp:Label>
                                <asp:TextBox ID="txtIntrvw" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>

                        </div>


                        <div class="row form-group">


                            <div class="col-sm-3 col-xs-12">
                                <asp:Label ID="lblgr" runat="server" Text="General Requirement"></asp:Label>
                                <asp:TextBox ID="txtGenReq" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            <div class="col-sm-3 col-xs-12">
                                <asp:Label Text="Normal Collection" ID="lblnc" runat="server"></asp:Label>
                                <asp:TextBox ID="txtNormlcl" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>


                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <asp:Label Text="My Application" runat="server" ID="lblmyapp"></asp:Label>
                                <asp:TextBox ID="txtmyapp" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="text-right">

                            <asp:Button ID="btnAddVisaForm" runat="server" Text="Add Visa Form" OnClick="btnAddVisaForm_Click" CssClass="button-1" />
                            
                            <asp:Button ID="Btnupdate" runat="server" Text="Update" OnClick="Btnupdate_Click"
                                Visible="False" CssClass="button-1" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="b" OnClick="btnSave_Click" CssClass="button-1" />
                        </div>

                    </div>
                </div>




            </div>
        </div>
    </div>
</asp:Content>
