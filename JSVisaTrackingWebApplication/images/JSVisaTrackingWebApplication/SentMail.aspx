<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SentMail.aspx.cs" Inherits="JSVisaTrackingWebApplication.SentMail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
    function confirmation() {
        if (confirm('Are you sure you want to Save ?')) {
            return true;
        } else {
            return false;
        }
    }
    </script> 
    <style type="text/css">
        .style1
        {
            width: 199px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>
        <i class="icon-user fg-color-blue"></i>Sent Mail
    </h2>

    <table>
    <tr>
        <td class="left">
            Select Agent
        </td>
         <td class="left">
                <div class="input-control select">
                    <asp:DropDownList ID="DropDownList_agent" runat="server">
                    </asp:DropDownList>
                </div>
        </td>
        </tr>
        <tr>
        <td class="left">
            Agent Email
        </td>
        <td class="left">
            <div class="input-control text">
                    <asp:TextBox ID="txtvisatitle" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
        
        </td>
    </tr>
        <tr>
            <td class="left">
                Name
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
         <tr>
            <td class="left">
                Address
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
         <tr>
            <td class="left">
                City
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="style1">
                State
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
                Query
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" Height="282px"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div align="right"><asp:Button ID="btnsent" runat="server" Text="Sent" OnClick="btnsent_Click"  OnClientClick="return confirmation();"/></div>
            </td>
        </tr>
    </table>
</asp:Content>
