<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AgentEmailList.aspx.cs" Inherits="JSVisaTrackingWebApplication.AgentEmailList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <h2>
       <i class="icon-mail-2  fg-color-blue"></i> Agent E-Mail list</h2>
    <table class="bordered">
        <tr>
            <td class="left">
            Enter City name to search  
            </td>
            <td class="left">
                <div class="input-control text">
                    <asp:TextBox ID="txt_city" runat="server"></asp:TextBox>
                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txt_city"
                        MinimumPrefixLength="1" EnableCaching="false" CompletionSetCount="1" CompletionInterval="100"
                        ServiceMethod="GetCityName" FirstRowSelected="false">
                    </asp:AutoCompleteExtender>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click1">
                            <i class="btn-search"></i>
                    </asp:LinkButton>
                </div>
            </td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="grid_search" runat="server" AutoGenerateColumns="False" AllowPaging="True"
            OnPageIndexChanging="grid_search_PageIndexChanging1" CssClass="gridview" PageSize="10"
            CellPadding="5">
            <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
            <Columns>
                <asp:TemplateField HeaderText="Agent Name">
                    <ItemTemplate>
                        <asp:Label ID="lbl_agentname" runat="server" Text='<%# Eval("AgentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agent Email">
                    <ItemTemplate>
                        <asp:Label ID="lbl_email" runat="server" Text='<%# Eval("AgentEmail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <div align="right">
        <asp:Button ID="btn_download" runat="server" Text="Download" OnClick="btn_download_Click" /></div>
</asp:Content>
