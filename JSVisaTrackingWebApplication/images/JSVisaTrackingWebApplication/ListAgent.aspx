<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"
    CodeBehind="ListAgent.aspx.cs" Inherits="JSVisaTrackingWebApplication.ListAgent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2>
       <i class="icon-list  fg-color-blue"></i> Agent List</h2>
       <div>
    <asp:GridView ID="gridlist" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" OnPageIndexChanging="gridlist_PageIndexChanging"  CssClass="gridview" PageSize="10" CellPadding="5">
        <HeaderStyle CssClass="gridViewHeader" />
            <RowStyle CssClass="gridViewRow" />
            <AlternatingRowStyle CssClass="gridViewAltRow" />
            <SelectedRowStyle CssClass="gridViewSelectedRow" />
            <PagerStyle CssClass="gridViewPager" />
                <Columns>
            <asp:TemplateField HeaderText="Sr. No.">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Agent Name" DataField="AgentName" />
            <asp:BoundField HeaderText="Agent Address" DataField="AgentAddress" />
            <asp:BoundField HeaderText="Agent City" DataField="AgentCity" />
            <asp:BoundField HeaderText="Agent PinCode" DataField="AgentPin" />
            <asp:BoundField HeaderText="Agent TelPhone" DataField="AgentPhone" />
            <asp:BoundField HeaderText="Agent UserName" DataField="AgentUserName" />
        </Columns>
                
    </asp:GridView>
    </div>
</asp:Content>
