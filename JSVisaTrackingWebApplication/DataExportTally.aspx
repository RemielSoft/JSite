<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    ValidateRequest="true" CodeBehind="DataExportTally.aspx.cs" Inherits="JSVisaTrackingWebApplication.TallyExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <i class="fg-color-blue icon-file-openoffice"></i>Data Export To Tally...
    </h2>
    
    <table class="table table-bordered table-striped table-condensed">
        <tr>
            <td class="left">
                From Date <span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                    <i class="btn-date"></i>
                </div>
            </td>
            <td class="left">
                To Date <span class="red">*</span>
            </td>
            <td class="left">
                <div class="input-control text datepicker span4" data-param-year-buttons="1" data-param-lang="en">
                    <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                    <i class="btn-date"></i>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <div align="right">
        <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click"
            OnClientClick="ShowProgress();"/>
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
    
</asp:Content>
