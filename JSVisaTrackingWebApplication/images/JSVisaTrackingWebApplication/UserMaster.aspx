<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="UserMaster.aspx.cs" Inherits="JSVisaTrackingWebApplication.UserMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <h2>
        <i class="icon-user fg-color-blue"></i>Creat User Account</h2>
    <%--<asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false"
        runat="server" ValidationGroup="Summery1" />--%>
    <table class="bordered">
        <tbody>
            <tr>
                <td class="left">
                    Login Id<span class="red">*</span>
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <asp:RequiredFieldValidator ID="rfvlogin" runat="server" ControlToValidate="txtLoginId"
                        ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please EnterLogin Id"
                        Display="None">
                    </asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="revLoginId" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtLoginId"></asp:RegularExpressionValidator>--%>
                </td>
                <td class="left">
                    Password
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtpassword" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtpassword"
                        ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Password"
                        Display="None">
                    </asp:RequiredFieldValidator>
                    <%-- <asp:RegularExpressionValidator ID="revPassword" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtpassword"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="left">
                    Employee Code
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtEmpCode" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <%--<asp:RegularExpressionValidator ID="revEmpCode" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtempcode"></asp:RegularExpressionValidator>--%>
                </td>
                <td class="left">
                    Confirm Password<span class="red">*</span>
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtConPass" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <asp:RequiredFieldValidator ID="rfvConfirmPwd" runat="server" ControlToValidate="txtConPass"
                        ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Confirm Password"
                        Display="None">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="txtpassword"
                        ControlToValidate="txtConPass" SetFocusOnError="true" ValidationGroup="Summery1"
                        ErrorMessage="Password does Not Matched"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="left">
                    First Name:<span class="red">*</span>
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <%-- <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFName"
                        ValidationGroup="Summery1" ErrorMessage="Please Enter First Name" SetFocusOnError="true"
                        Display="None">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revFName" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtFName">
                    </asp:RegularExpressionValidator>--%>
                </td>
                <td class="left">
                    Middle Name:
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <%-- <asp:RegularExpressionValidator ID="revMName" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtMiddleName">
                    </asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="left">
                    Last Name:
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtlname" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <%--<asp:RegularExpressionValidator ID="revLName" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtlname"></asp:RegularExpressionValidator>--%>
                </td>
                <td class="left">
                    Date Of Birth (mm/dd/yy)
                </td>
                <td class="left">
                    <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                        <asp:TextBox ID="txtdob" runat="server"></asp:TextBox>
                        <i class="btn-date"></i>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="left">
                    Address:<span style="color: Red">*</span>
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtaddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Please Enter Address"
                        SetFocusOnError="true" ControlToValidate="txtaddress" ValidationGroup="Summery1"
                        Display="None"></asp:RequiredFieldValidator>
                </td>
                <td class="left">
                    Location:<span style="color: Red">*</span>
                </td>
                <td class="left">
                    <div class="input-control select">
                        <asp:DropDownList ID="ddllocation" runat="server">
                        </asp:DropDownList>
                    </div>
                    <asp:RequiredFieldValidator ID="rfvDept" runat="server" ControlToValidate="ddllocation"
                        Display="None" SetFocusOnError="true" InitialValue="0" ErrorMessage="Please Select Location"
                        ValidationGroup="Summery1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="left">
                    Gender:
                </td>
                <td class="left">
                    <asp:RadioButtonList ID="rdbgender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="left">
                    Marital Status:
                </td>
                <td class="left">
                    <asp:RadioButtonList ID="rdbMaritalstatus" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem Selected="True">No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="left">
                    Email-Id<span style="color: Red">*</span>
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <%-- <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtemail"
                        ValidationGroup="Summery1" SetFocusOnError="true" ErrorMessage="Please Enter Email-Id"
                        Display="None">
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmailId" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtemail"></asp:RegularExpressionValidator>--%>
                </td>
                <td class="left">
                    Phone No
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtphn" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <%-- <asp:RegularExpressionValidator ID="revPhone" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtphn"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="left">
                    Mobile No.
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtmobile" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <%--<asp:RegularExpressionValidator ID="revMobile" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtmobile"></asp:RegularExpressionValidator>--%>
                </td>
                <td class="left">
                    Office Ext. No.
                </td>
                <td class="left">
                    <div class="input-control text">
                        <asp:TextBox ID="txtofficeextno" runat="server"></asp:TextBox>
                        <button class="btn-clear" />
                    </div>
                    <%--<asp:RegularExpressionValidator ID="revOfficeExtNo" runat="server" ValidationGroup="Summery1"
                        Display="None" SetFocusOnError="true" ControlToValidate="txtofficeextno"></asp:RegularExpressionValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="left">
                    User's Type:
                </td>
                <td class="left">
                    <asp:RadioButtonList ID="rbtnUserType" runat="server" RepeatDirection="Horizontal">
                        <%--<asp:ListItem>Company_User</asp:ListItem>
                        <asp:ListItem >Agent_User</asp:ListItem>--%>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </tbody>
    </table>
    <div align="right">
        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Summery1" OnClick="btnSave_Click1" />
        <asp:Button ID="btnupdate" runat="server" Text="Update" ValidationGroup="Summery1" OnClick="btnupdate_Click"/>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" ValidationGroup="Summery1" />
    </div>
    <div>
        <asp:GridView ID="gvw" runat="server" AutoGenerateColumns="false" CellPadding="5"
            CssClass="gridview" OnRowCommand="gvw_RowCommand" PageSize="10">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="UserName">
                    <ItemTemplate>
                        <asp:Label ID="lblUname" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                        <%-- <asp:LinkButton ID="LinkButton1" runat="server" CommandName="cmdDetails" CommandArgument='<%#Eval("UserId") %>' OnClientClick="ModalPopupExtender1" >LinkButton</asp:LinkButton>--%>
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
                <asp:TemplateField HeaderText="Phone No">
                    <ItemTemplate>
                        <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("PhoneNo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%#Eval("UserId") %>'
                            CommandName="cmdEditt" ToolTip="Edit"><i class="icon-pencil black"></i></asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%#Eval("UserId") %>'
                            CommandName="cmdDelete" ToolTip="Delete"><i class=" icon-remove red"></i></asp:LinkButton>
                        <asp:LinkButton ID="lnkUserTaskMapping" runat="server" CommandArgument='<%#Eval("UserId") %>'
                            CommandName="cmdUserTaskMapping" ToolTip="UserTaskMapping"><i class="icon-share-2 black"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="Showpopup" runat="server" Style="display: none" />
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Showpopup"
            PopupControlID="Panel1">
        </asp:ModalPopupExtender>
        <asp:Panel ID="Panel1" CssClass="div-popup" runat="server">
            <div class="message-dialog bg-color-green fg-color-white">
                <h4>
                    User's Details</h4>
                <asp:LinkButton ID="LinkButton2" CssClass="popup-close" runat="server"><i class="icon-cancel fg-color-white"></i></asp:LinkButton>
            </div>
            <table class="bordered">
                <tr>
                    <td align="left">
                        User name:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblname" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        LoginId:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblLid" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        EmpCode:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblEmpCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Gender:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblgender" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Address:
                    </td>
                    <td align="left">
                        <asp:Label ID="lbladd" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Location:
                    </td>
                    <td align="left">
                        <asp:Label ID="lbllocation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Email_Id:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblemail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        Phone No:
                    </td>
                    <td align="left">
                        <asp:Label ID="lblphone" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
