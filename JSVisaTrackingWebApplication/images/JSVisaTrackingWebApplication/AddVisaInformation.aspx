<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="AddVisaInformation.aspx.cs" Inherits="JSVisaTrackingWebApplication.Test1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-copy fg-color-blue"></i>Add Visa Information
    </h2>
    <table class="border">
        <tr>
            <td colspan="4" class="right">
                <asp:LinkButton ID="LinkButton1" PostBackUrl="~/ViewVisaInformation.aspx" runat="server"><span class="label info">View Visa Info <i class="icon-search fg-color-white"></i></span></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="left">
                Country
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCountry"
                    ErrorMessage="*" ForeColor="Red" InitialValue="0"
                    ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddlCountry" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                </div>
            </td>
            <td class="left">
                Consulate
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlconsulate"
                    ErrorMessage="*" ForeColor="Red" InitialValue="0"
                    ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddlconsulate" runat="server" CssClass="dropdown">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Visa Type
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlVisaType"
                    ErrorMessage="*" ForeColor="Red" InitialValue="0"
                    ValidationGroup="a"></asp:RequiredFieldValidator>
            </td>
            <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="ddlVisaType" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
            <td colspan="2">
            </td>
        </tr>
    </table>
    <div align="right">
        <asp:Button ID="BtnShow" CssClass="label success" runat="server" Text="Show Details"
            OnClick="BtnShow_Click" ValidationGroup="a" /></div>
    <table class="bordered" id="showTable" runat="server" visible="false">
        <tr>
            <td colspan="4">
                <blockquote>
                    <p>
                        (please seperate each line in consulate address with &)</p>
                </blockquote>
            </td>
        </tr>
        <tr>
            <td class="left">
                Consulate Address
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtconAdd" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </td>
            <td class="left">
            </td>
            <td class="left">
            </td>
        </tr>
        <tr>
            <td class="left">
                Fee*
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtFee" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Process Time
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtprotime" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Submission Days
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtSubday" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Submission Time
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtsubtime" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Collection days
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtcolday" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Collection Time
            </td>
            <td class="left">
                <div class="input-control text">
                    </div>
                    <asp:TextBox ID="txtcoltime" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="left">
                Visa Section Working Days
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtvisawrk" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Off
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtoff" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Normal Fee
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtnormlfee" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Urgent Fee
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txturgntfee" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                VFS
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtvfs" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Timing
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txttiming" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Student Fee
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtstufee" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
            <td class="left">
                Comments
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtcmmnts" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Basic Requirements
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtBasic" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </td>
            <td class="left">
                Note
            </td>
            <td>
                <div class="input-control text">
                    <asp:TextBox ID="TxtNote" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Medical Requirements
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="TxtMed" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </td>
            <td class="left">
                Other Informations
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="Txtother" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Copy Of Interview Date
            </td>
            <td class="lef">
                <div class="input-control text">
                    <asp:TextBox ID="txtIntrvw" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </td>
            <td class="left">
                General Requirement
            </td>
            <td colspan="3">
                <div class="input-control text">
                    <asp:TextBox ID="txtGenReq" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Normal Collection
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtNormlcl" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </td>
            <td class="left">
                My Application
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txtmyapp" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="right">
                <asp:Button ID="Btnupdate" runat="server" Text="Update" OnClick="Btnupdate_Click"
                    Visible="False" />
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
