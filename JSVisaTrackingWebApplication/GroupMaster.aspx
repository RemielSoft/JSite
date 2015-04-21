<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="GroupMaster.aspx.cs" Inherits="JSVisaTrackingWebApplication.GroupMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .accordionContent
        {
            background-color:White;
            border-color: -moz-use-text-color #2F4F4F #2F4F4F;
            border-right: 1px dashed #2F4F4F;
            border-style: none dashed dashed;
            border-width: medium 1px 1px;
            padding: 10px 5px 5px;
            width: 80%;
        }
        .accordionHeaderSelected
        {
            background-color: White;
            border: 1px solid #2F4F4F;
            color: Black;
            cursor: pointer;
            font-family: Arial,Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            margin-top: 5px;
            padding: 5px;
            width: 80%;
        }
        .accordionHeader
        {
            background-color#5078B3;
            border: 1px solid #2F4F4F;
            color:Black;
            cursor: pointer;
            font-family: Arial,Sans-Serif;
            font-size: 12px;
            font-weight: bold;
            margin-top: 5px;
            padding: 5px;
            width: 80%;
            
        }
        .href
        {
            color: White;
            font-weight: bold;
            
            text-decoration: none;
            
        }
        .style1
        {
            width: 889px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="g"
        ShowSummary="false" ShowMessageBox="true" />
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="gg"
        ShowSummary="false" ShowMessageBox="true" />
    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="ggg"
        ShowSummary="false" ShowMessageBox="true" />
    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ValidationGroup="valdationmember"
        ShowSummary="false" ShowMessageBox="true" />
    <h2>
        <i class=" icon-user-2 fg-color-blue">Group Master</i>
    </h2>
    <asp:ToolkitScriptManager ID="Scriptmanager1" runat="server" />
    <div>
        <table class="table table-bordered table-striped table-condensed">
            <tr>
                <td>
                    <asp:Panel ID="panel1" runat="server">
                        <table class="table table-bordered table-striped table-condensed">
                            <tr>
                                <td class="left">
                                    <strong>Group</strong> <span class="red">*</span>
                                </td>
                                <td class="left">
                                    <div class="input-control select">
                                        <asp:DropDownList ID="DrpdnGroupName" runat="server" OnSelectedIndexChanged="DrpdnGroupName_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Group Name"
                                        ControlToValidate="DrpdnGroupName" InitialValue="0" Display="None" SetFocusOnError="True"
                                        ValidationGroup="ggg">
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td class="left">
                                    <strong>Group Member</strong> <span class="red">*</span>
                                </td>
                                <td class="left">
                                    <div class="input-control select">
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please Select Group Member"
                                        ControlToValidate="DropDownList1" Display="None" SetFocusOnError="True" ValidationGroup="valdationmember">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="UserReg" runat="server">
                        <table class="table table-bordered table-striped table-condensed">
                            <tr>
                                <td class="left">
                                    <strong>Group Name</strong> <span class="red">*</span>
                                </td>
                                <td class="left">
                                    <div class="input-control text">
                                        <asp:TextBox ID="txtGroupName" runat="server"></asp:TextBox>
                                        <button class="btn-clear" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" ControlToValidate="txtGroupName"
                                        ErrorMessage="Please Enter Group Name" ValidationGroup="g" Display="None"></asp:RequiredFieldValidator>
                                </td>
                                <td class="left">
                                    <strong>Group Area</strong> <span class="red">*</span>
                                </td>
                                <td class="left">
                                    <div class="input-control text">
                                        <asp:TextBox ID="txtGroupArea" runat="server"></asp:TextBox>
                                        <button class="btn-clear" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvGroupArea" runat="server" ControlToValidate="txtGroupArea"
                                        ErrorMessage="Please Enter Group Area" ValidationGroup="g" Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="left">
                                    <strong>Countries</strong> <span class="red">*</span>
                                </td>
                                <td class="left" colspan="3">
                                    <div class="input-control select">
                                        <div style="overflow-y: scroll; width: 330px; height: 200px">
                                            <asp:CheckBoxList ID="Chklistcountry" runat="server">
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div align="right">
                                        <asp:Button ID="btnaddgroup" runat="server" Text="Save" OnClick="btnaddgroup_Click"
                                            ValidationGroup="g" />
                                        <asp:Button ID="btnGroupupdate" runat="server" Text="Update" OnClick="btnGroupupdate_Click" />
                                        <asp:Button ID="btnExit1" runat="server" Text="Exit" OnClick="btnExit1_Click" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel ID="Panel2" runat="server">
                        <table class="table table-bordered table-striped table-condensed">
                            <tr>
                                <td class="left">
                                    <strong>Group Name</strong> <span class="red">*</span>
                                </td>
                                <td class="left">
                                    <div class="input-control select">
                                        <asp:DropDownList ID="ddlgroupname" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfv_Name" runat="server" ErrorMessage="Please Select Group Name"
                                        ControlToValidate="ddlgroupname" InitialValue="0" Display="None" SetFocusOnError="True"
                                        ValidationGroup="gg">
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td class="left">
                                    <strong>Member Name</strong> <span class="red">*</span>
                                </td>
                                <td class="left">
                                    <div class="input-control text">
                                        <asp:TextBox ID="txtmember" runat="server"></asp:TextBox>
                                        <button class="btn-clear" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmember"
                                        ErrorMessage="Please Enter Member Name" ValidationGroup="gg" Display="None"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <div align="right">
                                        <asp:Button ID="btnmember" runat="server" Text="Save" OnClick="btnmember_Click" ValidationGroup="gg" />
                                        <asp:Button ID="btnMemberUpdate" runat="server" Text="Update" OnClick="btnMemberUpdate_Click" />
                                        <asp:Button ID="btnExit" runat="server" Text="Exit" OnClick="btnExit_Click" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr id="ContolDiv" runat="server">
                <td colspan="4" >
                    <div align="right" colspan="4" >
                        <asp:Button ID="addGroup" runat="server" Text="Add Group" OnClick="addGroup_Click" />
                        <asp:Button ID="editGroup" runat="server" Text="Edit Group" ValidationGroup="ggg"
                            OnClick="editGroup_Click" />
                        <asp:Button ID="adMember" runat="server" Text="Add Member" OnClick="adMember_Click" />
                        <asp:Button ID="editMembwer" runat="server" Text="Edit Member" ValidationGroup="valdationmember"
                            OnClick="editMembwer_Click" />
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
