<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ViewList.aspx.cs" Inherits="JSVisaTrackingWebApplication.ViewList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 416px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="icon-search  fg-color-blue"></i>View Consignment List</h2>
    <table class="table table-bordered table-striped table-condensed">
        <tr>
            <td class="left">
            Country Name:
            </td>
            <td class="left">
             <div class="input-control select">
                    <asp:DropDownList ID="ddlCountryName" runat="server">
                    </asp:DropDownList>
                </div>
                </td>
        </tr>
        <tr>
            <td class="left">
            Status:
            </td>
            <td class="left">
            <div class="input-control select">
                    <asp:DropDownList ID="ddlStatus" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
            Pax Name:
            </td>
            <td class="left">
            <div class="input-control text">
                    <asp:TextBox ID="txtPaxName" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="left">
            Pax Passport No.:
            </td>
            <td class="left">
             <div class="input-control text">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <button class="btn-clear" />
                </div>
            </td>
        </tr>
        <tr>
        <td colspan="2" align="right"> 
        <asp:Button ID="btnSearch" runat="server" Text="Search"/>
        </td>
        </tr>
    </table>
    <table class="table table-bordered table-striped table-condensed">
    <tr>
        <td class="style1">
        Location:
        </td>
         <td class="left" colspan="2">
            <div class="input-control select">
                    <asp:DropDownList ID="ddlLocation" runat="server">
                    </asp:DropDownList>
                </div>
            </td>
    </tr>
    <tr>
        <td colspan="2" align="right"> 
        <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel"/>
        </td>
    </tr>
    
    </table>
</asp:Content>
