<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserMaster.aspx.cs" Inherits="JSVisaTrackingWebApplication.UserMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Create User Account</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Admin / Create User Account</div>
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
                            <div class="col-sm-3 col-xs-12">
                                <label>Login Id <span class="red">*</span></label>
                                <asp:TextBox ID="txtLoginId" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvlogin" runat="server" ControlToValidate="txtLoginId"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Login Id"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revLoginId" runat="server" ValidationGroup="Summery1"
                                    Display="None" SetFocusOnError="true" ControlToValidate="txtLoginId"></asp:RegularExpressionValidator>

                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <label>Employee Code <span class="red">*</span></label>
                                <asp:TextBox ID="txtEmpCode" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpCode"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Confirm Password"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmpCode" runat="server" ValidationGroup="Summery1"
                                    Display="None" SetFocusOnError="true" ControlToValidate="txtempcode"></asp:RegularExpressionValidator>
                            </div>



                            <div class="col-sm-3 col-xs-12">
                                <label>Password <span class="red">*</span></label>
                                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtpassword"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Password"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revPassword" runat="server" ValidationGroup="Summery1"
                                    Display="None" SetFocusOnError="true" ControlToValidate="txtpassword"></asp:RegularExpressionValidator>

                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <label>Confirm Password <span class="red">*</span></label>
                                <asp:TextBox ID="txtConPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvConfirmPwd" runat="server" ControlToValidate="txtConPass"
                                    ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Confirm Password"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtpassword"
                                    ControlToValidate="txtConPass" SetFocusOnError="true" ValidationGroup="Summery1"
                                    ErrorMessage="Password does Not Match"></asp:CompareValidator>
                            </div>


                        </div>
                        <div class="row form-group">

                            <div class="col-sm-3 col-xs-12">
                                <label>First Name <span class="red">*</span></label>
                                <asp:TextBox ID="txtFName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFName"
                                    ValidationGroup="Summery1" ErrorMessage="Please Enter First Name" SetFocusOnError="true"
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revFName" runat="server" ValidationGroup="Summery1"
                                    Display="None" SetFocusOnError="true" ControlToValidate="txtFName">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <label>Middle Name</label>
                                <asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revMName" runat="server" ValidationGroup="Summery1"
                                    Display="None" SetFocusOnError="true" ControlToValidate="txtMiddleName">
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <label>Last Name</label>
                                <asp:TextBox ID="txtlname" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="revLName" runat="server" ValidationGroup="Summery1"
                                    Display="None" SetFocusOnError="true" ControlToValidate="txtlname"></asp:RegularExpressionValidator>
                            </div>

                            <div class="col-sm-3 col-xs-12">
                                <label>Date Of Birth (mm/dd/yy)</label>
                                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                                    <asp:TextBox ID="txtdob" runat="server" CssClass="form-control"></asp:TextBox>
                                    <i class="btn-date"></i>
                                </div>
                            </div>
                            </div>
                             <div class="row form-group">
                            <div class="col-sm-3 col-xs-12">
                                <label>Address<span style="color: Red">*</span></label>
                                <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please Enter Address"
                                    SetFocusOnError="true" ControlToValidate="txtaddress" ValidationGroup="Summery1"
                                    Display="None"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-3 col-xs-12">
                                <label>Location<span style="color: Red">*</span></label>
                                <asp:DropDownList ID="ddllocation" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvDept" runat="server" ControlToValidate="ddllocation"
                                    Display="None" SetFocusOnError="true" InitialValue="0" ErrorMessage="Please Select Location"
                                    ValidationGroup="Summery1"></asp:RequiredFieldValidator>
                            </div>

                               <div class="col-sm-3 col-xs-12">
                                <label>Gender</label>
                                     <asp:RadioButtonList ID="rdbgender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>

                               </div>
                                  <div class="col-sm-3 col-xs-12">
                                <label>Marital Status</label>
                              <asp:RadioButtonList ID="rdbMaritalstatus" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem Selected="True">No</asp:ListItem>
                    </asp:RadioButtonList>

                                 </div>
                                 </div>

                                 <div class="row form-group">
                                    <div class="col-sm-3 col-xs-12">
                                <label>Email-Id <span class="red">*</span></label>
                                  <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfv_email" runat="server" ControlToValidate="txtemail"
                        ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter User Email-Id"
                        Display="None">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ValidationGroup="Summery1"
                        EnableClientScript="false" Display="None" SetFocusOnError="true" ControlToValidate="txtemail"
                        ErrorMessage="Invalid email address" Visible="True" ClientIDMode="Predictable"
                        EnableViewState="True"></asp:RegularExpressionValidator>
                                        </div>

                                       <div class="col-sm-3 col-xs-12">
                                <label>Phone No.</label>
                                 <asp:TextBox ID="txtphn" runat="server" CssClass="form-control"></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="revPhone" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtphn"></asp:RegularExpressionValidator>
                                       </div>

                                       <div class="col-sm-3 col-xs-12">
                                <label>Mobile No.</label>
                                               <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control"></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="revMobile" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtmobile"></asp:RegularExpressionValidator>
                                       </div>

                                        <div class="col-sm-3 col-xs-12">
                                <label>Office Ext. No.</label>
                                <asp:TextBox ID="txtofficeextno" runat="server" CssClass="form-control"></asp:TextBox>
                              <asp:RegularExpressionValidator ID="revOfficeExtNo" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtofficeextno"></asp:RegularExpressionValidator>
                        </div>


                    </div>
                         <div class="row form-group">
                              <div class="col-sm-6 col-xs-12">
                                <label>User's Type <span class="red">*</span></label>
                                  <asp:RadioButtonList ID="rbtnUserType" runat="server" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="rfvUserType" runat="server" ControlToValidate="rbtnUserType"
                        ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please select user type"
                        Display="None">
                    </asp:RequiredFieldValidator>

                </div>
            </div>
                        </div>
                       
                     <div class="text-right">
        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Summery1" OnClick="btnSave_Click1"  CssClass="button-1"/>
        <asp:Button ID="btnupdate" runat="server" Text="Update" ValidationGroup="Summery1"
            OnClick="btnupdate_Click" CssClass="button-1" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="cancel-btn"/>
    </div>
        </div>
   


   
    <div class="table table-responsive">
        <%--change by Divaker--%>
        <asp:GridView ID="gvw" runat="server" AutoGenerateColumns="false" CellPadding="5"
            AllowPaging="true" CssClass="gridview table table-bordered table-striped table-condensed" OnRowCommand="gvw_RowCommand" PageSize="10"
            OnPageIndexChanging="gvw_PageIndexChanging">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:LinkButton ID="lblUname" runat="server" Text='<%#Eval("FullName") %>' CommandArgument='<%#Eval("UserId") %>'
                            CommandName="cmdDetails"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Login Id">
                    <ItemTemplate>
                        <asp:Label ID="lblLogin" runat="server" Text='<%#Eval("LoginId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Code">
                    <ItemTemplate>
                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("EmpCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location">
                    <ItemTemplate>
                        <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("UserLocation.City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone Number">
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("PhoneNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" HeaderStyle-Width="90px">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#Eval("UserId") %>'
                            CommandName="cmdEditt" ToolTip="Edit"><i class="glyphicon glyphicon-edit"></i></asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#Eval("UserId") %>'
                            CommandName="cmdDelete" OnClientClick="return confirm('Are You Sure You Want To Delete This User?') "
                            ToolTip="Delete"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                        <asp:LinkButton ID="lnkUserTaskMapping" runat="server" CommandArgument='<%#Eval("UserId") %>'
                            CommandName="cmdUserTaskMapping" ToolTip="UserTaskMapping"><i class="glyphicon glyphicon-th"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnPopUp" runat="server" BackColor="#f8f8f8" BorderStyle="None" BorderWidth="0px"
            CommandName="Select" Visible="false"/>
        <div style="position: absolute; top: 1000px; display:none;">
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnPopUp"
                PopupControlID="panel1" BackgroundCssClass="modalBackground" DropShadow="true"
                Enabled="True" PopupDragHandleControlID="PopupMenu">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" CssClass="div-popup" runat="server">
                <div class="message-dialog bg-color-green fg-color-white">
                    <h4>User's Details</h4>
                    <asp:LinkButton ID="LinkButton2" CssClass="popup-close" runat="server"><i class="icon-cancel fg-color-white"></i></asp:LinkButton>
                </div>
                <table class="table table-bordered table-striped table-condensed">
                    <tr>
                        <td align="left">
                            <b>Name</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblname" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            <b>Address</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lbladd" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Employee Code</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblEmpCode" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            <b>Login Id</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblLid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Password</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPwd" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            <b>Date Of Birth</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDOB" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Gender</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblgender" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            <b>Location</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lbllocation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Email Id</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblemail" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            <b>Phone No.</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblphone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Office Ext No.</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblOfficeExtNo" runat="server"></asp:Label>
                        </td>
                        <td align="left">
                            <b>Mobile No.</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMobNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <b>Marital Status</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMarritalS" runat="server"></asp:Label>
                        </td>
                        <%--<td align="left">
                            <b>Mobile No</b>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label2" runat="server"></asp:Label>
                        </td>--%>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>

 </div></div></div>
</asp:Content>
