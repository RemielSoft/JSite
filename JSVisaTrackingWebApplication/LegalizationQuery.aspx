<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LegalizationQuery.aspx.cs"
    Inherits="JSVisaTrackingWebApplication.LegalizationQuery" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container-fulid page-heading">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12">Legalization Query</div>
                </div>
            </div>
        </div>
    </section>
    <div class="container">
        <div class="row">
            <div class="middle">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-12 col-xs-12">
                            <div class="content">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 form-group">
                                            <div style="background: #e70012; color: #fff; padding: 4px 8px; padding-top: 8px;">
                                                <label>
                                                    <b>Your Contact Details</b>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Your Name <span class="red">*</span>
                                            </label>
                                            <%--<input type="text" class="form-control" />--%>
                                            <asp:RequiredFieldValidator ID="requireValidate" runat="server" ControlToValidate="txtyourname" Display="None"
                                                ErrorMessage="Please Fill The Your Name" ForeColor="Red" ToolTip="Arrival is required."
                                                ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtyourname" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Your Email <span class="red">*</span>
                                            </label>
                                            <asp:RequiredFieldValidator ID="requireMail" runat="server" ControlToValidate="txtyouremail" Display="None"
                                                ErrorMessage="Please Fill The Your Email" ForeColor="Red" ToolTip="Arrival is required."
                                                ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtyouremail" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Company Name
                                            </label>
                                            <%-- <input type="text" class="form-control" />--%>
                                            <asp:TextBox ID="txtcompanyname" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Website
                                            </label>
                                            <%--<input type="text" class="form-control" />--%>
                                            <asp:TextBox ID="txtwebsite" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row form-group">
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Country <span class="red">*</span>
                                            </label>
                                            <%--<input type="text" class="form-control" />--%>
                                            <asp:TextBox ID="txtcountry" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                City <span class="red">*</span>
                                            </label>
                                            <%--<input type="text" class="form-control" />--%>
                                            <asp:TextBox ID="txtcity" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 col-xs-12">
                                            <label style="display: block">
                                                Mobile <span class="red">*</span>
                                            </label>
                                            <div class="col-sm-2 col-xs-12 no-padding">


                                                <input type="text" class="form-control" placeholder="+91" />
                                            </div>
                                            <div class="col-sm-6 col-xs-12">
                                                <asp:RequiredFieldValidator ID="requireMobiel" runat="server" ControlToValidate="txtmobile" Display="None"
                                                    ErrorMessage="Please Fill The Your Mobile No." ForeColor="Red" ToolTip="Arrival is required."
                                                    ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator runat="server" ID="rexNumber" Display="Dynamic" ForeColor="Red" ControlToValidate="txtmobile"
                                                    ValidationExpression="^[7-9][0-9]{9}$" ErrorMessage="Please enter a valid mobile number" />

                                            </div>


                                        </div>

                                    </div>


                                </div>






                                <div class="col-sm-8 col-xs-12">
                                    <div class="package">
                                        <span class="packages-heading">Send Your Query</span>
                                    </div>
                                    <asp:ValidationSummary ID="QueryValidationSummary" runat="server" ValidationGroup="QueryValidationGroup" CssClass="failureNotification"
                                        ShowMessageBox="true" ShowSummary="false" EnableClientScript="true" Enabled="true" />
                                    <div class="row">
                                        <div class="col-sm-12 col-xs-12 form-group">
                                            <label>
                                                Describe Your Travel Plan/Requirements
                                            </label>
                                            <asp:RequiredFieldValidator ID="requireDescribe" runat="server" ControlToValidate="txtdescribe" Display="None"
                                                ErrorMessage="Please Fill Your Requirement" ForeColor="Red"
                                                ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                            <asp:TextBox ID="txtdescribe" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row  form-group">
                                        <div class="col-sm-4 col-xs-12">
                                            <label>
                                                Country
                                            </label>
                                            <div style="height: 80px; padding: 2px; overflow: auto; border: 1px solid #ccc;">
                                                <asp:CheckBoxList ID="chkCountry" runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                        <div class="col-sm-4 col-xs-12 form-group">
                                            <label>
                                                Type of Document
                                            </label>
                                            <asp:TextBox ID="txtDocument" runat="server" Height="80px" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label style="display: block;">
                                                Legalization Service
                                            </label>
                                            <div style="height: 80px; padding: 2px; width: 178px; overflow: auto; border: 1px solid #ccc;">
                                                <asp:CheckBoxList ID="chklegalization" runat="server">
                                                    <asp:ListItem>HRO</asp:ListItem>
                                                    <asp:ListItem>MEA</asp:ListItem>
                                                    <asp:ListItem>Embassy Attestation</asp:ListItem>
                                                    <asp:ListItem>Translation</asp:ListItem>
                                                    <asp:ListItem>Notary</asp:ListItem>

                                                </asp:CheckBoxList>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 col-xs-12">
                                            <label>
                                                Any Other fields
                                            </label>
                                            <asp:TextBox ID="txtOtherfield" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 col-xs-12"></div>

                                    </div>
                                    <div></div>
                                    <div class="row">
                                        
                                            <div class="col-sm-12 col-xs-12 text-right">
                                                <%--<input type="Submit" class="send-btn form-group" value="Send Enquiry">--%>
                                                <asp:Button ID="btnSendQuery" runat="server" Text="Send Enquiry" ValidationGroup="QueryValidationGroup" class="send-btn form-group" OnClick="btnSendQuery_Click" />
                                            </div>
                                       
                                    </div>
                                </div>

                                <div class="col-sm-4 col-xs-12 ">
                                    <img src="Imagess/send-query.jpg" class="img img-responsive pull-right" />
                                </div>



                            </div>


                        </div>


                    </div>
                </div>
            </div>
        </div>




    </div>


</asp:Content>

