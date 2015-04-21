<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Query.aspx.cs"
    Inherits="JSVisaTrackingWebApplication.Query" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div class="container-fulid page-heading">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-12">Tours Query</div>
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
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Expected Arrival
                                            </label>

                                            <div class="input-group text datepicker" data-param-year-buttons="1" data-param-lang="en">
                                                <asp:RequiredFieldValidator ID="txtdate" runat="server" ControlToValidate="txtfrmdate" Display="None"
                                                    ErrorMessage="Please Fill The Date First" ForeColor="Red" ToolTip="Arrival is required."
                                                    ValidationGroup="QueryValidationGroup">*</asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txtfrmdate" runat="server" CssClass="form-control"></asp:TextBox>
                                                <i class="input-group-addon glyphicon glyphicon-calendar"></i>
                                                <i class="btn-date"></i>


                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-xs-12 form-group">
                                            <label>
                                                Duration
                                            </label>
                                            <asp:DropDownList ID="ddlduration" runat="server" CssClass="form-control">
                                                <asp:ListItem>---Select---</asp:ListItem>
                                                <asp:ListItem>1-3 Days</asp:ListItem>
                                                <asp:ListItem>4-7 Days</asp:ListItem>
                                                <asp:ListItem>8-14 Days</asp:ListItem>
                                                <asp:ListItem>2-3 Weeks</asp:ListItem>
                                                <asp:ListItem>3 Weeks</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--<select class="form-control">
                                                <option>---Select---</option>
                                                <option>1-3 Days</option>
                                                <option>4-7 Days</option>
                                                <option>8-14 Days</option>
                                                <option>2-3 Weeks</option>
                                                <option>> 3 Weeks</option>
                                            </select>--%>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label style="display: block;">
                                                Number of Persons
                                            </label>
                                            <asp:DropDownList ID="ddlnoOfPersons" runat="server">

                                                <asp:ListItem>Adult</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                            </asp:DropDownList>
                                            <%-- <select class="form-control col-sm-6 selct-option">
                                                <option>Adult</option>
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>

                                            </select>--%>
                                            <asp:DropDownList ID="ddlkids" runat="server">

                                                <asp:ListItem>Kid</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                            </asp:DropDownList>

                                            <%--<select class="form-control col-sm-6 selct-option">
                                                <option>Kid</option>
                                                <option>0</option>
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>

                                            </select>--%>
                                        </div>
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                Budget
                                            </label>
                                            <%--<select class="form-control">
                                                <option>--- Select ---</option>
                                                <option>Economy</option>
                                                <option>Standard</option>
                                                <option>Luxury</option>
                                            </select>--%>
                                            <asp:DropDownList ID="ddlbudget" runat="server" CssClass="form-control">
                                                <asp:ListItem>---Select---</asp:ListItem>
                                                <asp:ListItem>Economy</asp:ListItem>
                                                <asp:ListItem>Standard</asp:ListItem>
                                                <asp:ListItem>Luxury</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="row form-group">
                                        <div class="col-sm-3 col-xs-12">
                                            <label>
                                                <b>Also Interested In</b><br />
                                                <span class="small">(optional)</span>
                                            </label>

                                        </div>
                                        <div class="col-sm-3 col-xs-12 no-padding-right">
                                            <%--<input type="checkbox">--%>
                                            <asp:CheckBox ID="chkairrail" runat="server" Text="Air / Rail Ticketing" />
                                            <%--<asp:Label id="lblairticket" runat="server" Text="Air / Rail Ticketing"></asp:Label>--%>
                                        </div>
                                        <div class="col-sm-3 col-xs-12 no-padding-right">
                                            <%--<input type="checkbox">--%>
                                            <asp:CheckBox ID="chkhotel" runat="server" Text="Hotel Reservation" />

                                        </div>
                                        <div class="col-sm-3 col-xs-12 no-padding-right">
                                            <%-- <input type="checkbox">--%>
                                            <asp:CheckBox ID="chkcar" runat="server" Text="Car / Coach Rental" />


                                        </div>
                                    </div>


                                </div>
                                <div class="col-sm-4 col-xs-12">
                                    <img src="Imagess/send-query.jpg" class="img img-responsive pull-right" />
                                </div>

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
                                            <div class="col-sm-4 col-xs-12 text-right">
                                                <%--<input type="Submit" class="send-btn form-group" value="Send Enquiry">--%>
                                                <asp:Button ID="btnSendQuery" runat="server" Text="Send Enquiry" ValidationGroup="QueryValidationGroup" class="send-btn form-group" OnClick="btnSendQuery_Click" />
                                            </div>

                                        </div>

                                    </div>
                                    <div class="row form-group">
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>




            </div>
        </div>
    </div>


</asp:Content>
