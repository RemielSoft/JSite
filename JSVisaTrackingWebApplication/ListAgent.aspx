<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ListAgent.aspx.cs" Inherits="JSVisaTrackingWebApplication.ListAgent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!--[if lt IE 9]>
<script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
<![endif]-->
    <script type="text/javascript">
        document.createElement('header');
        document.createElement('section');
        document.createElement('article');
        document.createElement('aside');
        document.createElement('nav');
        document.createElement('footer');
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container-fulid page-heading">
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-6">Agent List</div>
                <div class="col-xs-12 col-sm-6 caption text-right">Agent / Agent List</div>
            </div>
        </div>
    </div>


     <div class="container" style="margin-top:20px;">
        <div class="row">
            <div class="col-xs-12 col-sm-12">
       <div class="table table-responsive">
    <asp:GridView ID="gridlist" runat="server" AutoGenerateColumns="False" 
        AllowPaging="True" OnPageIndexChanging="gridlist_PageIndexChanging"  CssClass="gridview table table-bordered table-striped table-condensed" PageSize="10" CellPadding="5">
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
            <asp:BoundField HeaderText="Agent TelePhone" DataField="AgentPhone" />
            <asp:BoundField HeaderText="Agent UserName" DataField="AgentUserName" />
        </Columns>
                
    </asp:GridView>
    </div>
</div></div></div>

</asp:Content>
